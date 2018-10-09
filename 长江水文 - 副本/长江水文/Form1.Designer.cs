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
            this.btShowData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btRecorder = new System.Windows.Forms.Button();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(487, 685);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(532, 22);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(124, 31);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Text = "刷新网站";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btShowData
            // 
            this.btShowData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btShowData.Location = new System.Drawing.Point(532, 80);
            this.btShowData.Name = "btShowData";
            this.btShowData.Size = new System.Drawing.Size(124, 31);
            this.btShowData.TabIndex = 2;
            this.btShowData.Text = "显示内容";
            this.btShowData.UseVisualStyleBackColor = true;
            this.btShowData.Click += new System.EventHandler(this.btShowData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(493, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(492, 424);
            this.dataGridView1.TabIndex = 4;
            // 
            // btRecorder
            // 
            this.btRecorder.Location = new System.Drawing.Point(335, 295);
            this.btRecorder.Name = "btRecorder";
            this.btRecorder.Size = new System.Drawing.Size(124, 31);
            this.btRecorder.TabIndex = 2;
            this.btRecorder.Text = "添加到Excel";
            this.btRecorder.UseVisualStyleBackColor = true;
            this.btRecorder.Visible = false;
            this.btRecorder.Click += new System.EventHandler(this.btRecorder_Click);
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
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbTimer2);
            this.panel1.Controls.Add(this.lbRecord);
            this.panel1.Controls.Add(this.lbTimer1);
            this.panel1.Location = new System.Drawing.Point(697, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 230);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbCountdown);
            this.panel2.Location = new System.Drawing.Point(128, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 55);
            this.panel2.TabIndex = 1;
            // 
            // lbCountdown
            // 
            this.lbCountdown.AutoSize = true;
            this.lbCountdown.Font = new System.Drawing.Font("LCDMono2", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountdown.Location = new System.Drawing.Point(18, 4);
            this.lbCountdown.Name = "lbCountdown";
            this.lbCountdown.Size = new System.Drawing.Size(97, 43);
            this.lbCountdown.TabIndex = 0;
            this.lbCountdown.Text = "060";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "操作记录！";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作倒计时:";
            // 
            // lbTimer2
            // 
            this.lbTimer2.AutoSize = true;
            this.lbTimer2.Location = new System.Drawing.Point(19, 81);
            this.lbTimer2.Name = "lbTimer2";
            this.lbTimer2.Size = new System.Drawing.Size(115, 21);
            this.lbTimer2.TabIndex = 0;
            this.lbTimer2.Text = "计时器2关闭！";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Location = new System.Drawing.Point(19, 48);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(90, 21);
            this.lbRecord.TabIndex = 0;
            this.lbRecord.Text = "局部时间：";
            // 
            // lbTimer1
            // 
            this.lbTimer1.AutoSize = true;
            this.lbTimer1.Location = new System.Drawing.Point(19, 15);
            this.lbTimer1.Name = "lbTimer1";
            this.lbTimer1.Size = new System.Drawing.Size(115, 21);
            this.lbTimer1.TabIndex = 0;
            this.lbTimer1.Text = "计时器1开启！";
            // 
            // btOpenFile
            // 
            this.btOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenFile.Location = new System.Drawing.Point(532, 196);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(124, 31);
            this.btOpenFile.TabIndex = 2;
            this.btOpenFile.Text = "打开Excel查看";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // btDownloadData
            // 
            this.btDownloadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDownloadData.Location = new System.Drawing.Point(532, 138);
            this.btDownloadData.Name = "btDownloadData";
            this.btDownloadData.Size = new System.Drawing.Size(124, 31);
            this.btDownloadData.TabIndex = 2;
            this.btDownloadData.Text = "添加到Excel";
            this.btDownloadData.UseVisualStyleBackColor = true;
            this.btDownloadData.Click += new System.EventHandler(this.btDownloadData_Click);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 371);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(487, 314);
            this.textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 685);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btShowData);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btDownloadData);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.btRecorder);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "长江水文数据记录";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btShowData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btRecorder;
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
        private System.Windows.Forms.TextBox textBox1;
    }
}

