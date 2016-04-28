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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listbR = new System.Windows.Forms.ListBox();
            this.listbL = new System.Windows.Forms.ListBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.text.Location = new System.Drawing.Point(568, 15);
            this.text.Margin = new System.Windows.Forms.Padding(4);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(100, 29);
            this.text.TabIndex = 3;
            this.text.Text = "test";
            this.text.UseVisualStyleBackColor = true;
            this.text.Click += new System.EventHandler(this.test_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(219, 15);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(139, 29);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "choose_file";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btn_Path
            // 
            this.btn_Path.Location = new System.Drawing.Point(39, 15);
            this.btn_Path.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Size = new System.Drawing.Size(141, 29);
            this.btn_Path.TabIndex = 5;
            this.btn_Path.Text = "set fold Path";
            this.btn_Path.UseVisualStyleBackColor = true;
            this.btn_Path.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(395, 15);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(141, 29);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "open fold Path";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listbR);
            this.panel1.Controls.Add(this.listbL);
            this.panel1.Location = new System.Drawing.Point(16, 98);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 465);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // listbR
            // 
            this.listbR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listbR.FormattingEnabled = true;
            this.listbR.ItemHeight = 15;
            this.listbR.Location = new System.Drawing.Point(220, 5);
            this.listbR.Margin = new System.Windows.Forms.Padding(4);
            this.listbR.Name = "listbR";
            this.listbR.Size = new System.Drawing.Size(756, 754);
            this.listbR.TabIndex = 1;
            this.listbR.DoubleClick += new System.EventHandler(this.listbR_DoubleClick);
            // 
            // listbL
            // 
            this.listbL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listbL.FormattingEnabled = true;
            this.listbL.ItemHeight = 15;
            this.listbL.Location = new System.Drawing.Point(5, 5);
            this.listbL.Margin = new System.Windows.Forms.Padding(4);
            this.listbL.Name = "listbL";
            this.listbL.Size = new System.Drawing.Size(205, 754);
            this.listbL.TabIndex = 0;
            this.listbL.SelectedIndexChanged += new System.EventHandler(this.listbFile_SelectedIndexChanged);
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "句子",
            "文件"});
            this.comboBox.Location = new System.Drawing.Point(5, 4);
            this.comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(205, 23);
            this.comboBox.TabIndex = 8;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(220, 4);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(497, 25);
            this.searchBox.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(733, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.searchBox);
            this.panel2.Location = new System.Drawing.Point(16, 51);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 39);
            this.panel2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 629);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btn_Path);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.text);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listbR;
        private System.Windows.Forms.ListBox listbL;
    }
}

