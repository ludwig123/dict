namespace sentence
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.text = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btn_Path = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.listbR = new System.Windows.Forms.ListBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_rewriteDB = new System.Windows.Forms.Button();
            this.btn_output = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // text
            // 
            this.text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text.Location = new System.Drawing.Point(242, 2);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(100, 30);
            this.text.TabIndex = 3;
            this.text.Text = "test";
            this.text.UseVisualStyleBackColor = true;
            this.text.Visible = false;
            this.text.Click += new System.EventHandler(this.test_Click);
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFile.Location = new System.Drawing.Point(30, 2);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(100, 30);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "choose_file";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Visible = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btn_Path
            // 
            this.btn_Path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Path.Location = new System.Drawing.Point(18, 26);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Size = new System.Drawing.Size(100, 30);
            this.btn_Path.TabIndex = 5;
            this.btn_Path.Text = "设置文件夹";
            this.btn_Path.UseVisualStyleBackColor = true;
            this.btn_Path.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.Location = new System.Drawing.Point(136, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 30);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "open fold Path";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Visible = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // listbR
            // 
            this.listbR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listbR.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listbR.FormattingEnabled = true;
            this.listbR.HorizontalScrollbar = true;
            this.listbR.ItemHeight = 20;
            this.listbR.Location = new System.Drawing.Point(14, 124);
            this.listbR.MinimumSize = new System.Drawing.Size(652, 284);
            this.listbR.Name = "listbR";
            this.listbR.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listbR.Size = new System.Drawing.Size(652, 284);
            this.listbR.TabIndex = 1;
            this.listbR.DoubleClick += new System.EventHandler(this.listbR_DoubleClick);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.searchBox.Location = new System.Drawing.Point(144, 80);
            this.searchBox.MaximumSize = new System.Drawing.Size(10000, 30);
            this.searchBox.Name = "searchBox";
            this.searchBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.searchBox.Size = new System.Drawing.Size(522, 27);
            this.searchBox.TabIndex = 9;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(18, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_output);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btn_rewriteDB);
            this.panel2.Controls.Add(this.listbR);
            this.panel2.Controls.Add(this.searchBox);
            this.panel2.Controls.Add(this.btn_Path);
            this.panel2.Location = new System.Drawing.Point(12, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 445);
            this.panel2.TabIndex = 11;
            // 
            // btn_rewriteDB
            // 
            this.btn_rewriteDB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_rewriteDB.Location = new System.Drawing.Point(144, 26);
            this.btn_rewriteDB.Name = "btn_rewriteDB";
            this.btn_rewriteDB.Size = new System.Drawing.Size(100, 30);
            this.btn_rewriteDB.TabIndex = 12;
            this.btn_rewriteDB.Text = "刷新数据库";
            this.btn_rewriteDB.UseVisualStyleBackColor = true;
            this.btn_rewriteDB.Click += new System.EventHandler(this.btn_rewriteDB_Click);
            // 
            // btn_output
            // 
            this.btn_output.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_output.Location = new System.Drawing.Point(272, 26);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(100, 30);
            this.btn_output.TabIndex = 13;
            this.btn_output.Text = "导出为txt";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 495);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.text);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button text;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btn_Path;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ListBox listbR;
        private System.Windows.Forms.Button btn_rewriteDB;
        private System.Windows.Forms.Button btn_output;
    }
}

