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

            DisplayFold(foldPath);

        }


        public void ProcessDirectory(string targetDirectory)
        {
            string searchPattern = @"*.exe";

            DirectoryInfo TheFolder = new DirectoryInfo(targetDirectory);
            ArrayList files = new ArrayList();
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory,searchPattern);
            foreach (string fileName in fileEntries)
            {
                //这里fileName是绝对路径
                files.Add(fileName);
//                ProcessFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);


            foreach (string path in files)
            {
                this.listbSentence.Items.Add(path);
            }
        }

        // Insert logic for processing found files here.
        //public  void ProcessFile(string path)
        //{
           
        //    Console.WriteLine("Processed file '{0}'.", path);
        //}


        public void DisplayFold(string foldPath)
        {
            this.ProcessDirectory(foldPath);


            //foreach (string path in files)
            //{
            //    this.listbSentence.Items.Add(path);
            //}

            //DirectoryInfo TheFolder = new DirectoryInfo(foldPath);
            ////遍历文件夹
            //foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            //{
            //    string[] subdirectoryEntries = Directory.GetDirectories(NextFolder.ToString());
            //    foreach (string subdirectory in subdirectoryEntries)
              
            //    this.listbFile.Items.Add(NextFolder.Name);
            //}
            ////遍历文件
            //foreach (FileInfo NextFile in TheFolder.GetFiles())
            //{
            //    this.listbSentence.Items.Add(NextFile.Name);
            //}
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string hello = @"hello";
            DBConnection conn = new DBConnection();
           SQLiteConnection myconn =  conn.Start(conn.DBPath());
           DBOperate createTable = new DBOperate();
           createTable.CreateTable(hello,myconn);



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
                //                MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", foldPath);
        }

        private void listbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listbFile.SelectedItem.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


 



