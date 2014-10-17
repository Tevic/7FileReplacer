namespace _7FileReplacer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BtnReplace = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.listBoxComp = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBoxBackUp = new System.Windows.Forms.CheckBox();
            this.BtnDelTemp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnReplace
            // 
            this.BtnReplace.Location = new System.Drawing.Point(12, 317);
            this.BtnReplace.Name = "BtnReplace";
            this.BtnReplace.Size = new System.Drawing.Size(90, 42);
            this.BtnReplace.TabIndex = 0;
            this.BtnReplace.Text = "开始替换";
            this.BtnReplace.UseVisualStyleBackColor = true;
            this.BtnReplace.Click += new System.EventHandler(this.BtnReplace_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 17;
            this.listBoxFiles.Location = new System.Drawing.Point(12, 29);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(149, 276);
            this.listBoxFiles.Sorted = true;
            this.listBoxFiles.TabIndex = 1;
            // 
            // listBoxComp
            // 
            this.listBoxComp.FormattingEnabled = true;
            this.listBoxComp.ItemHeight = 17;
            this.listBoxComp.Location = new System.Drawing.Point(170, 29);
            this.listBoxComp.Name = "listBoxComp";
            this.listBoxComp.Size = new System.Drawing.Size(149, 276);
            this.listBoxComp.Sorted = true;
            this.listBoxComp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(40, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "待替换文件列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(198, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "已替换文件列表";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(263, 342);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 17);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "使用必读";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBoxBackUp
            // 
            this.checkBoxBackUp.AutoSize = true;
            this.checkBoxBackUp.Checked = true;
            this.checkBoxBackUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBackUp.Location = new System.Drawing.Point(232, 317);
            this.checkBoxBackUp.Name = "checkBoxBackUp";
            this.checkBoxBackUp.Size = new System.Drawing.Size(87, 21);
            this.checkBoxBackUp.TabIndex = 5;
            this.checkBoxBackUp.Text = "备份原文件";
            this.checkBoxBackUp.UseVisualStyleBackColor = true;
            // 
            // BtnDelTemp
            // 
            this.BtnDelTemp.Location = new System.Drawing.Point(125, 317);
            this.BtnDelTemp.Name = "BtnDelTemp";
            this.BtnDelTemp.Size = new System.Drawing.Size(90, 42);
            this.BtnDelTemp.TabIndex = 6;
            this.BtnDelTemp.Text = "清理临时文件";
            this.BtnDelTemp.UseVisualStyleBackColor = true;
            this.BtnDelTemp.Click += new System.EventHandler(this.BtnDelTemp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 371);
            this.Controls.Add(this.BtnDelTemp);
            this.Controls.Add(this.checkBoxBackUp);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxComp);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.BtnReplace);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7FileReplacer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnReplace;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.ListBox listBoxComp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBoxBackUp;
        private System.Windows.Forms.Button BtnDelTemp;
    }
}

