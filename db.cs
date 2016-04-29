using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Text.RegularExpressions;

namespace sentence
{
    //create datapath for sqlite
    public static class SQLiteConnectionString
    {

        public static string GetConnectionString(string path)
        {
            return GetConnectionString(path, null);
        }

        public static string GetConnectionString(string path, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "Data Source=" + path;
            }
            else
            {
                return "Data Source=" + path + ";Password=" + password;
            }
        }
    }


    //connect sqlite connection
    public class DBConnection
    {

        //自动查找安装目录
        //当前目录是sentence/bin/debug/sentence.exe   
        //转到sentence/db/sentence.db
        public static string GetDBPath()
        {
            string sysPath = System.Windows.Forms.Application.StartupPath + @"../../../";
            System.IO.Directory.SetCurrentDirectory(sysPath);
            string path = System.IO.Directory.GetCurrentDirectory() + @"\db\sentence.db";
            return path;
        }

        public DBConnection()
        {
        }

        public static SQLiteConnection OpenConnection(string DBPath)
        {
            SQLiteConnection myconn = DBConnection.Start(DBPath);
            return myconn;
        }

        public static void CloseConnection( SQLiteConnection myconn)
        {
            myconn.Close();
        }
        public static SQLiteConnection Start(string DBPath)
        {
            string sConn = SQLiteConnectionString.GetConnectionString(DBPath);

            SQLiteConnection conn = new SQLiteConnection(sConn);

            try { conn.Open(); }
            catch (Exception)
            {
                //为什么链接失败也不会结束？
                //为什么程序自己会创建一个sentence.db文件？
                MessageBox.Show("\n找不到数据库数据文件！");
                System.Environment.Exit(0);
            }

            Console.WriteLine(conn.FileName);
            return conn;
        }

        public void End(SQLiteConnection sqliteConnection)
        {
            sqliteConnection.Close();
        }

        public bool Fold2DB(DirectoryInfo dbDir, SQLiteConnection sqliteConnection)
        {
            string searchPattern = @"*.txt";

            foreach (DirectoryInfo NextFolder in dbDir.GetDirectories())
            {

                foreach (FileInfo NextFile in dbDir.GetFiles(searchPattern))
                {
                    string filePath = NextFile.ToString();
                    File2DB(filePath, sqliteConnection);
                }

            }
            return true;


        }
        public bool File2DB(string filePath, SQLiteConnection sqliteConnection)
        {

            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                IDbTransaction trans = sqliteConnection.BeginTransaction();
                try
                {
                    //以 .  切分句子
                    StreamReader sr = File.OpenText(filePath);
                    string sentence = sr.ReadToEnd();
                    string[] split_s = sentence.Split(new char[] { '.' });


                    //should create a table named as filename
                    for (int i = 0; i < split_s.Length; i++)
                    {
                        cmd.CommandText = "insert into (@file) (sentence) values (@sentence);";
                        cmd.Parameters.Add(new SQLiteParameter("@file"));
                        cmd.Parameters["@file"].Value = Path.GetFileNameWithoutExtension(filePath);

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

                sqliteConnection.Close();
                return true;
            }
        }
    }

    public class DBOperate
    {
        public DBOperate()
        {
        }


        public static void CreateTable4File(SQLiteConnection sqliteConnection)
        {
            CreateTable4File(@"sentence", sqliteConnection);
        }
        private static void CreateTable4File(string tableName, SQLiteConnection sqliteConnection)
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "CREATE TABLE `" + tableName + "` (`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,`sentence`	TEXT NOT NULL,'filename' TEXT NOT NULL);";

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Console.WriteLine(" CreateTable4File falie");
                }
            }


        }

        private static long GetLastModifyTime(string filePath)
        {
            long timeLong = 0;
            FileInfo fileinfo = new FileInfo(filePath);
            timeLong = fileinfo.LastWriteTime.ToFileTimeUtc();
            return timeLong;
        }

        private static string createREG(string keyWord)
        {
            string stringREG = "%" + keyWord + "%";
            return stringREG;
        }

        private static void SetFileInfo(string targetFile, SQLiteConnection sqliteConnection)
        {
            //temp 测试数据
            string fileName = Path.GetFileNameWithoutExtension(targetFile);
            string filePath = targetFile;
            long lastModifiedTime = GetLastModifyTime(filePath);

            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "insert into files values (@fileName,@filePath, @lastModifiedTime);";
                //匹配字符 fileName 等！！！
                //string 会自动添加单引号
                cmd.Parameters.AddWithValue("@fileName", fileName);
                cmd.Parameters.AddWithValue("@filePath", filePath);
                cmd.Parameters.AddWithValue("@lastModifiedTime", lastModifiedTime);
                try
                {
                    cmd.ExecuteNonQuery();
                }

                catch (Exception)
                {
                    Console.WriteLine(@"set_flies_info falure");
                }

            }
        }

        public static void SetFiles(string FoldPath, SQLiteConnection sqliteConnection)
        {

            string searchPattern = @"*.txt";

            DirectoryInfo TheFolder = new DirectoryInfo(FoldPath);
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(FoldPath, searchPattern);


            foreach (string filePath in fileEntries)
            {
                //这里fileName是绝对路径
                SetFileContent(filePath, sqliteConnection);
                
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(FoldPath);
            foreach (string subdirectory in subdirectoryEntries)
                SetFiles(subdirectory, sqliteConnection);
        }

        //返回单行信息
        public static SQLiteDataReader GetFileInfo(string targetFile, SQLiteConnection sqliteConnection)
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "select * from files where name like @filePath;";
                cmd.Parameters.AddWithValue("@filePath", targetFile);

                SQLiteDataReader fileInfoReader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                return fileInfoReader;

            }
        }

        public static SQLiteDataReader GetFilesInfo(SQLiteConnection sqliteConnection)
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "select * from files ;";
                SQLiteDataReader fileInfoReader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                return fileInfoReader;
            }
        }


        public static ArrayList search(string keyWord, string fileName, SQLiteConnection sqliteConnection)
        {
            string key = createREG(keyWord);
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "select * from '"+fileName+"' where sentence like '"+key+"';";

                SQLiteDataReader fileInfoReader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                return Reader2ArrayList( fileInfoReader);
            }
        }

        public static ArrayList Reader2ArrayList(SQLiteDataReader sqliteDateReader)
        {
            ArrayList arrayList = new ArrayList();
            while(sqliteDateReader.Read())
            {
                arrayList.Add(sqliteDateReader[1]);
            }

            return arrayList;
        }


        public bool IsModifid(string filePath)
            {
            //用当前的文件和数据库的文件比较
                //if(LastModifyTime(filePath) 
                    return true;
            }
        public static void SetFileContent(string filePath, SQLiteConnection sqliteConnection)
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
              IDbTransaction trans = sqliteConnection.BeginTransaction();
                try
                {
                    //以pattern切分句子
                    string pattern = @"\d{1,2}\.\s";
                    StreamReader sr =new StreamReader(filePath,Encoding.UTF8);
                    string sentence = sr.ReadToEnd();
                    string[] split_s = Regex.Split(sentence, pattern);

                   string fileName =  Path.GetFileNameWithoutExtension(filePath);

                    //should create a table named as filename
                    for (int i = 0; i < split_s.Length; i++)
                    {
                        cmd.CommandText = "insert into sentence (sentence,filename) values (@sentence,@filename);";

                        cmd.Parameters.Add(new SQLiteParameter("@sentence"));
                        cmd.Parameters["@sentence"].Value = split_s[i];

                        cmd.Parameters.AddWithValue("@filename", fileName);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("write file erro");
                }
            trans.Commit();
            }
        }

    }
}

