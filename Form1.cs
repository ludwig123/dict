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
        public string foldPath = @"C:\Users\hejin.DESKTOP-HCOCNG6\Documents\Visual Studio 2010\Projects\WindowsFormsApplication2\WindowsFormsApplication2\db\test_files";
        public string filePath = @"C:\Users\hejin.DESKTOP-HCOCNG6\Documents\Visual Studio 2010\Projects\WindowsFormsApplication2\WindowsFormsApplication2\db\test_files\2007年高考模拟试题英语.txt";
        public string DBPath = null;



        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (foldPath == null || filePath == null)
            //{
            //    MessageBox.Show("please choos fold or file");
            //    btn_Path.PerformClick();
            //}

            //DisplayFold(foldPath);

        }

        public void DispayListboxR(ArrayList arrayList, ListBox listBox)
        {
            listBox.Items.Clear();

            listBox.BeginUpdate();
            foreach (string path in arrayList)
            {
                listBox.Items.Add(path);
            }
            listBox.EndUpdate();
        }


        
        public void ProcessDirectory(string targetDirectory)
        {
            string searchPattern = @"*.txt";

            DirectoryInfo TheFolder = new DirectoryInfo(targetDirectory);
            ArrayList files = new ArrayList();
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory,searchPattern);


            foreach (string fileName in fileEntries)
            {
                //这里fileName是绝对路径
                files.Add(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);


            foreach (string path in files)
            {
                this.listbR.Items.Add(path);
            }
        }


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

        private void test_Click(object sender, EventArgs e)
        {
            {
                // string hello = @"hello";
                // DBConnection conn = new DBConnection();
                //SQLiteConnection myconn =  conn.Start(conn.DBPath());

                //DBOperate createTable = new DBOperate();
                //createTable.CreateTable(hello,myconn);
            }

            //测试Utctime
            //DBOperate test = new DBOperate();
            //DateTime test2 = DateTime.UtcNow;
            //Console.WriteLine( test2.ToFileTimeUtc());

            //测试写入文件信息功能
            //DBConnection conn = new DBConnection();
            //SQLiteConnection myconn = conn.Start(conn.DBPath());
            //DBOperate test = new DBOperate();





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
               // MessageBox.Show("已选择文件:" + filePath, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //打开文件库
        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", foldPath);
        }

        private void listbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listbL.SelectedItem.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listbR_DoubleClick(object sender, EventArgs e)
        {
            //未测试代码
            this.searchBox.Location = new System.Drawing.Point(165, 3);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(374, 21);
//            this.searchBox.TabIndex = 9;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SQLiteConnection myconn = DBConnection.OpenConnection(DBConnection.DBPath());

            string keyword = this.searchBox.Text;
            string filename = "2007年高考模拟试题英语";

            ArrayList myArray = DBOperate.search(keyword, filename, myconn);


            DispayListboxR(myArray,this.listbR);
            myconn.Close();
        }

    }
}


