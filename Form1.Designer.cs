﻿namespace sentence
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.insert = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btn_Path = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listbSentence = new System.Windows.Forms.ListBox();
            this.listbFile = new System.Windows.Forms.ListBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.paragraph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sentence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(426, 12);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(75, 23);
            this.insert.TabIndex = 3;
            this.insert.Text = "insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(164, 12);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(104, 23);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "choose_file";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btn_Path
            // 
            this.btn_Path.Location = new System.Drawing.Point(29, 12);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Size = new System.Drawing.Size(106, 23);
            this.btn_Path.TabIndex = 5;
            this.btn_Path.Text = "btnPath";
            this.btn_Path.UseVisualStyleBackColor = true;
            this.btn_Path.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(296, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(106, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "open directy";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listbSentence);
            this.panel1.Controls.Add(this.listbFile);
            this.panel1.Location = new System.Drawing.Point(12, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 108);
            this.panel1.TabIndex = 7;
            // 
            // listbSentence
            // 
            this.listbSentence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listbSentence.FormattingEnabled = true;
            this.listbSentence.ItemHeight = 12;
            this.listbSentence.Location = new System.Drawing.Point(165, 4);
            this.listbSentence.Name = "listbSentence";
            this.listbSentence.Size = new System.Drawing.Size(324, 340);
            this.listbSentence.TabIndex = 1;
            // 
            // listbFile
            // 
            this.listbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listbFile.FormattingEnabled = true;
            this.listbFile.ItemHeight = 12;
            this.listbFile.Location = new System.Drawing.Point(4, 4);
            this.listbFile.Name = "listbFile";
            this.listbFile.Size = new System.Drawing.Size(155, 340);
            this.listbFile.TabIndex = 0;
            this.listbFile.SelectedIndexChanged += new System.EventHandler(this.listbFile_SelectedIndexChanged);
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "句子",
            "文件"});
            this.comboBox.Location = new System.Drawing.Point(4, 3);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(155, 20);
            this.comboBox.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(165, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(374, 21);
            this.textBox1.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(550, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(12, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 31);
            this.panel2.TabIndex = 11;
            // 
            // dgv
            // 
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paragraph,
            this.sentence});
            this.dgv.GridColor = System.Drawing.SystemColors.Window;
            this.dgv.Location = new System.Drawing.Point(38, 52);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(565, 288);
            this.dgv.TabIndex = 12;
            // 
            // paragraph
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.paragraph.DefaultCellStyle = dataGridViewCellStyle6;
            this.paragraph.HeaderText = "文件列表";
            this.paragraph.Name = "paragraph";
            this.paragraph.ReadOnly = true;
            this.paragraph.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.paragraph.ToolTipText = "文件列表2";
            // 
            // sentence
            // 
            this.sentence.HeaderText = "句子列表";
            this.sentence.Name = "sentence";
            this.sentence.Width = 400;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 503);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btn_Path);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.insert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btn_Path;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listbSentence;
        private System.Windows.Forms.ListBox listbFile;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn paragraph;
        private System.Windows.Forms.DataGridViewTextBoxColumn sentence;
    }
}

