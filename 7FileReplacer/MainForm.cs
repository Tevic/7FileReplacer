using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace _7FileReplacer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请退出所有无关程序后再执行替换任务！\n替换成功后需重启计算机！", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    listBoxFiles.Items.Clear();
                    listBoxComp.Items.Clear();

                    BtnReplace.Enabled = false;
                    BtnReplace.Text = "正在处理";
                    FileOperation.Replace(checkBoxBackUp.Checked);
                    BtnReplace.Text = "开始替换";
                    BtnReplace.Enabled = true;

                    AddListBox(listBoxFiles, FileOperation.GetAllFileList());
                    AddListBox(listBoxComp, FileOperation.GetCompFileList());

                    if (DialogResult.OK == MessageBox.Show("替换完成，是否立即重启计算机？", "完成", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        Reboot();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序出现异常：" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    BtnReplace.Text = "开始替换";
                    BtnReplace.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 填充ListBox
        /// </summary>
        /// <param name="lb">ListBox名字</param>
        /// <param name="list">传入列表</param>
        private static void AddListBox(ListBox lb, List<String> list)
        {
            foreach (var item in list)
            {
                lb.Items.Add(item.ToString());
            }
        }

        /// <summary>
        /// 检测当前系统是否为Windows7
        /// </summary>
        /// <returns></returns>
        private static Boolean IsWin7()
        {
            if (Environment.OSVersion.Version.Major == 6
                && Environment.OSVersion.Version.Minor == 1)
            {
                return true;
            }
            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!IsWin7())
            {
                MessageBox.Show("请在Windows7上运行此程序","提醒",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.Close();
                Application.Exit();
            }
            CreateDir();
            AddListBox(listBoxFiles, FileOperation.GetAllFileList());

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("此软件用于批量替换Winodws 7系统文件，\n替换图标文件后需重启然后刷新图标缓存。\n目前仅支持System32目录文件替换！！！\n\n版权归 Tevic.TT 所有\nCopyright © 2010\nE-Mail : Tevic.TT@Gmail.Com", "关于 7FileReplacer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 初始化文件系统
        /// </summary>
        private static void CreateDir()
        {
            if (!Directory.Exists("BackUpFiles"))
            {
                Directory.CreateDirectory("BackUpFiles");
            }
            if (!Directory.Exists("ReplaceFiles"))
            {
                Directory.CreateDirectory("ReplaceFiles");
            }
        }

        /// <summary>
        /// 重启计算机
        /// </summary>
        private static void Reboot()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "shutdown.exe",
                Arguments = "-t 0 -r -f",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(startInfo).WaitForExit();
        }

        private void BtnDelTemp_Click(object sender, EventArgs e)
        {
            try
            {
                FileOperation.DeleteTempFile();
                MessageBox.Show("临时文件清理完成！","完成",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                if (MessageBox.Show("文件正在被使用，请重启后删除！\n是否立即重启？", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Reboot();
                }
            }
        }

 

    }
}
