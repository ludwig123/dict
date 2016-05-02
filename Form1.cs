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
        public static string DBPath ;



        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.DBPath = DBConnection.GetDBPath();
            
        }

        public void DispayListbox(ArrayList arrayList, ListBox listBox)
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
        }

        private void test_Click(object sender, EventArgs e)
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
            SQLiteConnection myconn = DBConnection.OpenConnection(DBConnection.GetDBPath());

            string keyword = this.searchBox.Text;
            string filename = "sentence";

            ArrayList myArray = DBOperate.search(keyword, filename, myconn);


            DispayListbox(myArray,this.listbR);
            myconn.Close();
        }

        private void btn_rewriteDB_Click(object sender, EventArgs e)
        {
            Stopwatch myWatch =  Stopwatch.StartNew();
            myWatch.Start();
            if (File.Exists(DBPath))
            {
                //如果存在则删除
                File.Delete(DBPath);
            } 
            SQLiteConnection myconn = DBConnection.Start(DBPath);
            DBOperate.CreateTable4File(myconn);
            DBOperate.SetFiles(foldPath, myconn);
            myconn.Close();
            myWatch.Stop();
            TimeSpan ts = myWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");

        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            
        }

    }
}


