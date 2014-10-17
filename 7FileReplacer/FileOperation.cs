using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace _7FileReplacer
{
    class FileOperation
    {
        /// <summary>
        /// 存储需要替换的文件和替换完成文件的列表
        /// </summary>
        private static List<String> allFileList = new List<string>();
        private static List<String> compFileList = new List<string>();

        /// <summary>
        /// 定义需要替换文件的路劲，默认为System32
        /// </summary>
        static String SysDir = Environment.SystemDirectory;

        /// <summary>
        /// 获取管理员权限
        /// </summary>
        /// <param name="filepath"></param>
        private static void TakeOwner(string filepath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "takeown",
                Arguments = string.Format("/f \"{0}\" /a", filepath),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(startInfo).WaitForExit();
            startInfo.FileName = "icacls";
            startInfo.Arguments = string.Format("\"{0}\" /grant administrators:F", filepath);
            Process.Start(startInfo).WaitForExit();
        }

        /// <summary>
        /// 替换文件
        /// </summary>
        /// <param name="oldName">需要替换文件的全路径</param>
        private static void ReplaceFile(String oldName)
        {
            String tmpName = oldName + ".tmp";
            String fileName = GetFileName(oldName, true);
            String curFileName = FileOperation.GetCurrentPath() + "\\ReplaceFiles\\" + fileName;
            TakeOwner(oldName);
            try
            {
                //若重启过则删除临时文件再替换
                if (File.Exists(tmpName))
                {
                    File.Delete(tmpName);
                }
                File.Move(oldName, tmpName);
                File.Copy(curFileName, oldName);
            }
            catch (Exception)
            {
                //若未重启过则直接覆盖目标文件
                File.Copy(curFileName, oldName, true);
            }

        }

        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="filePath">需要备份文件的全路径</param>
        private static void BackUpFile(String filePath)
        {
            String fileName=GetFileName(filePath,true);
            String backUpFileName=GetCurrentPath()+"\\BackUpFiles\\"+fileName;
            if(!File.Exists(backUpFileName))
            {
            File.Copy(filePath, backUpFileName);
            }
        }


        /// <summary>
        /// 获取当前目录路径
        /// </summary>
        /// <returns></returns>
        internal static String GetCurrentPath()
        {
            return Application.StartupPath.ToString();
        }

        /// <summary>
        /// 根据传来的文件全路径，获取文件名称部分
        /// </summary>
        /// <param name="FileFullPath">文件全路径</param>
        /// <param name="IncludeExtension">是否包括文件扩展名</param>
        /// <returns>string 文件名称</returns>
        private static String GetFileName(string FileFullPath, bool IncludeExtension)
        {
            if (File.Exists(FileFullPath) == true)
            {
                FileInfo F = new FileInfo(FileFullPath);
                if (IncludeExtension == true)
                {
                    return F.Name;
                }
                else
                {
                    return F.Name.Replace(F.Extension, "");
                }
            }
            else//文件不存在
            {
                return null;
            }
        }

        /// <summary>
        /// 替换文件函数封装
        /// </summary>
        /// <param name="isBackUp">是否要备份</param>
        internal static void Replace(Boolean isBackUp)
        {
            allFileList.Clear();
            compFileList.Clear();
            if (!Directory.Exists("BackUpFiles"))
            {
                Directory.CreateDirectory("BackUpFiles");
            }
            if (!Directory.Exists("ReplaceFiles"))
            {
                Directory.CreateDirectory("ReplaceFiles");
            }
            DirectoryInfo replaceFilePath = new DirectoryInfo(FileOperation.GetCurrentPath() + "\\ReplaceFiles");
            if (isBackUp)
            {
                    foreach (var item in replaceFilePath.GetFiles())
                    {
                        allFileList.Add(item.Name);
                        String destFileName = SysDir + "\\" + item.Name;
                        if (File.Exists(destFileName))
                        {
                            BackUpFile(destFileName);
                            ReplaceFile(destFileName);
                            compFileList.Add(item.Name);
                        }
                    }
            }
            else
            {
                foreach (var item in replaceFilePath.GetFiles())
                {
                    allFileList.Add(item.Name);
                    String destFileName = SysDir + "\\" + item.Name;
                    if (File.Exists(destFileName))
                    {
                        ReplaceFile(destFileName);
                        compFileList.Add(item.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 获取要替换的文件列表
        /// </summary>
        internal static List<String> GetAllFileList()
        {
            allFileList.Clear();
            DirectoryInfo replaceFilePath = new DirectoryInfo(FileOperation.GetCurrentPath() + "\\ReplaceFiles");
            if (replaceFilePath.Exists)
            {
                foreach (var item in replaceFilePath.GetFiles())
                {
                    allFileList.Add(item.Name);
                }
            }
            return allFileList;
        }

        /// <summary>
        /// 获取替换完成的文件列表
        /// </summary>
        /// <returns></returns>
        internal static List<String> GetCompFileList()
        {
            return compFileList;
        }

        /// <summary>
        /// 判断系统是否重启过
        /// </summary>
        /// <returns></returns>
        private static Boolean IsReboot()
        {
            if (!Directory.Exists(SysDir + "\\IsRebotFlag"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 创建重启标志文件
        /// </summary>
        internal static void CreateFlag()
        {
            if (!Directory.Exists(SysDir + "\\IsRebotFlag"))
            {
                Directory.CreateDirectory(SysDir + "\\IsRebotFlag");
            }
        }

        /// <summary>
        /// 删除重启标志文件
        /// </summary>
        internal static void DeleteFlag()
        {
            if (Directory.Exists(SysDir + "\\IsRebotFlag"))
            {
                Directory.Delete(SysDir + "\\IsRebotFlag");
            }
        }

        /// <summary>
        /// 删除临时文件
        /// </summary>
        internal static void DeleteTempFile()
        {
            foreach (var item in GetAllFileList())
            {
                if (File.Exists(SysDir + "\\" + item + ".tmp"))
                    File.Delete(SysDir + "\\" + item + ".tmp");
            }
        }
    }
}
