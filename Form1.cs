using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace sentence
{


    public partial class Form1 : Form
    {
        // global enviriment variables;
        public string foldPath = null;
        public string filePath = null;
        public string DBPath = null;


        public Form1()
        {
            InitializeComponent();
            DBConnection myconn = new DBConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (foldPath == null || filePath == null)
            {
                MessageBox.Show("please choos fold or file");
                btn_Path.PerformClick();
            }

            DirectoryInfo TheFolder = new DirectoryInfo(foldPath);
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                this.listbFile.Items.Add(NextFolder.Name);
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                this.listbSentence.Items.Add(NextFile.Name);

            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
           

        }

        private void btnFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                MessageBox.Show("已选择文件:" + filePath, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                 foldPath = dialog.SelectedPath;
                MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", foldPath);
        }


    }
}

