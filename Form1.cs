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
        private string foldPath = null;
        private string filePath = null;

        //所有文件的路径集合
        private ICollection fileDir = null;


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

            DirectoryInfo TheFolder = new DirectoryInfo(foldPath);
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                this.listbFile.Items.Add(NextFolder.Name);
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                this.listbSentence.Items.Add(NextFile.Name);
                this.fileDir
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //文件路径，应该改为遍历文件夹类型
            string text_path = @"C:\Users\ludwig\Documents\sentence.txt";

            StreamReader sr = File.OpenText(text_path);
            string sentence = sr.ReadToEnd();

            string[] split_s = sentence.Split(new char[] { '.' });


            //database 路径，相对路径！！！！！！！
  //       string path = @"C:\Users\ludwig\Documents\Visual Studio 2010\Projects\sentence\sentence\db\sentence.db";
  //         
            string sysPath = System.Windows.Forms.Application.StartupPath + @"../../../";
            System.IO.Directory.SetCurrentDirectory(sysPath);
            string path = System.IO.Directory.GetCurrentDirectory() + @"\db\sentence.db";
            
 //           Console.WriteLine(path);

            string sConn = SQLiteConnectionString.GetConnectionString(path)  ;

            SQLiteConnection conn = new SQLiteConnection(sConn);

            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                //为什么链接失败也不会结束？
                //为什么程序自己会创建一个sentence.db文件？
                MessageBox.Show(path+"\n找不到数据库数据文件！");
                System.Environment.Exit(0);
            }

            Console.WriteLine(conn.FileName);

            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < split_s.Length; i++)
                    {
                        cmd.CommandText = "insert into (@file) (sentence) values (@sentence);";
                        cmd.Parameters.Add(new SQLiteParameter("@file"));
                        cmd.Parameters["@"].Value = split_s[i];

                        cmd.Parameters.Add(new SQLiteParameter("@sentence"));
                        cmd.Parameters["@sentence"].Value = split_s[i];

                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();

                }
                catch (Exception)
                {
                    trans.Rollback();
                    //这个throw 如何捕获？
                    throw;
                }

                conn.Close();
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
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

