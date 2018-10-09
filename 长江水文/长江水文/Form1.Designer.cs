namespace 长江水文
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btRefresh = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.主窗体显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上次操作时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开Excel查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbCountdown = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTimer2 = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.lbTimer1 = new System.Windows.Forms.Label();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.btDownloadData = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btRecorder = new System.Windows.Forms.Button();
            this.contextMenuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(430, 216);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRefresh.ForeColor = System.Drawing.Color.Lime;
            this.btRefresh.Location = new System.Drawing.Point(14, 19);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(119, 34);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Text = "刷新网站";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "长江水文";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主窗体显示ToolStripMenuItem,
            this.上次操作时间ToolStripMenuItem,
            this.打开Excel查看ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(159, 92);
            // 
            // 主窗体显示ToolStripMenuItem
            // 
            this.主窗体显示ToolStripMenuItem.Name = "主窗体显示ToolStripMenuItem";
            this.主窗体显示ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.主窗体显示ToolStripMenuItem.Text = "主窗体显示";
            this.主窗体显示ToolStripMenuItem.Click += new System.EventHandler(this.主窗体显示ToolStripMenuItem_Click);
            // 
            // 上次操作时间ToolStripMenuItem
            // 
            this.上次操作时间ToolStripMenuItem.Name = "上次操作时间ToolStripMenuItem";
            this.上次操作时间ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.上次操作时间ToolStripMenuItem.Text = "上次操作时间：";
            // 
            // 打开Excel查看ToolStripMenuItem
            // 
            this.打开Excel查看ToolStripMenuItem.Name = "打开Excel查看ToolStripMenuItem";
            this.打开Excel查看ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.打开Excel查看ToolStripMenuItem.Text = "打开Excel查看";
            this.打开Excel查看ToolStripMenuItem.Click += new System.EventHandler(this.打开Excel查看ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbTimer2);
            this.panel1.Controls.Add(this.lbRecord);
            this.panel1.Controls.Add(this.lbTimer1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 185);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbCountdown);
            this.panel2.Location = new System.Drawing.Point(119, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 55);
            this.panel2.TabIndex = 1;
            // 
            // lbCountdown
            // 
            this.lbCountdown.AutoSize = true;
            this.lbCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountdown.ForeColor = System.Drawing.Color.Lime;
            this.lbCountdown.Location = new System.Drawing.Point(18, 4);
            this.lbCountdown.Name = "lbCountdown";
            this.lbCountdown.Size = new System.Drawing.Size(108, 55);
            this.lbCountdown.TabIndex = 0;
            this.lbCountdown.Text = "060";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "操作记录！";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作倒计时:";
            // 
            // lbTimer2
            // 
            this.lbTimer2.AutoSize = true;
            this.lbTimer2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimer2.ForeColor = System.Drawing.Color.Black;
            this.lbTimer2.Location = new System.Drawing.Point(12, 64);
            this.lbTimer2.Name = "lbTimer2";
            this.lbTimer2.Size = new System.Drawing.Size(115, 21);
            this.lbTimer2.TabIndex = 0;
            this.lbTimer2.Text = "计时器2关闭！";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRecord.ForeColor = System.Drawing.Color.Black;
            this.lbRecord.Location = new System.Drawing.Point(12, 37);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(90, 21);
            this.lbRecord.TabIndex = 0;
            this.lbRecord.Text = "局部时间：";
            // 
            // lbTimer1
            // 
            this.lbTimer1.AutoSize = true;
            this.lbTimer1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimer1.ForeColor = System.Drawing.Color.Black;
            this.lbTimer1.Location = new System.Drawing.Point(12, 10);
            this.lbTimer1.Name = "lbTimer1";
            this.lbTimer1.Size = new System.Drawing.Size(115, 21);
            this.lbTimer1.TabIndex = 0;
            this.lbTimer1.Text = "计时器1开启！";
            // 
            // btOpenFile
            // 
            this.btOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btOpenFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenFile.ForeColor = System.Drawing.Color.Lime;
            this.btOpenFile.Location = new System.Drawing.Point(14, 129);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(119, 34);
            this.btOpenFile.TabIndex = 2;
            this.btOpenFile.Text = "打开Excel查看";
            this.btOpenFile.UseVisualStyleBackColor = false;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // btDownloadData
            // 
            this.btDownloadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDownloadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btDownloadData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btDownloadData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDownloadData.ForeColor = System.Drawing.Color.Lime;
            this.btDownloadData.Location = new System.Drawing.Point(14, 74);
            this.btDownloadData.Name = "btDownloadData";
            this.btDownloadData.Size = new System.Drawing.Size(119, 34);
            this.btDownloadData.TabIndex = 2;
            this.btDownloadData.Text = "添加到Excel";
            this.btDownloadData.UseVisualStyleBackColor = false;
            this.btDownloadData.Click += new System.EventHandler(this.btDownloadData_Click);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btRefresh);
            this.panel3.Controls.Add(this.btOpenFile);
            this.panel3.Controls.Add(this.btDownloadData);
            this.panel3.Location = new System.Drawing.Point(288, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(151, 185);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.webBrowser1);
            this.panel4.Controls.Add(this.btRecorder);
            this.panel4.Location = new System.Drawing.Point(5, 197);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(434, 220);
            this.panel4.TabIndex = 7;
            // 
            // btRecorder
            // 
            this.btRecorder.Location = new System.Drawing.Point(190, 129);
            this.btRecorder.Name = "btRecorder";
            this.btRecorder.Size = new System.Drawing.Size(124, 31);
            this.btRecorder.TabIndex = 2;
            this.btRecorder.Text = "添加到Excel";
            this.btRecorder.UseVisualStyleBackColor = true;
            this.btRecorder.Visible = false;
            this.btRecorder.Click += new System.EventHandler(this.btRecorder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(445, 425);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "长江水文数据记录";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTimer2;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Label lbTimer1;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.Button btDownloadData;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbCountdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 主窗体显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上次操作时间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开Excel查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btRecorder;
    }
}

