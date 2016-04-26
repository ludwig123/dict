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
        public static string DBPath()
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
    public class SentcHandler
    {
        //public bool CreatDB(){
        //}

        //public bool RefreshDB{
        //}

        //private bool IsDBReady{

        //}


    }

    public class DBOperate
    {
        public DBOperate()
        {
        }

        public void CreateTable(string tableName, SQLiteConnection sqliteConnection)
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "CREATE TABLE `" + tableName + "` (`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,`sentence`	INTEGER NOT NULL);";

                //cmd.Parameters.Add(new SQLiteParameter("@tableName"));
                //cmd.Parameters["@tableName"].Value = tableName;
                cmd.ExecuteNonQuery();
            }
        }

        public static long GetLastModifyTime(string filePath)
        {
            long timeLong = 0;
            FileInfo fileinfo = new FileInfo(filePath);
            timeLong = fileinfo.LastWriteTime.ToFileTimeUtc();
            return timeLong;
        }

        //查询并返回修改过的文件的列表，文件名和最后的修改时间
        //public Array ModifiedFlies(string dbPath, string foldPath)
        //{

        //}

        //public Array Search(string keyWord)
        //{

        //}

        public string createREG(string keyWord)
        {
            string stringREG = "%" + keyWord + "%";
            return stringREG;
        }

        public static void WriteFileInfo(string targetFile, SQLiteConnection sqliteConnection)
        {
            //temp 测试数据
            string fileName = targetFile, filePath = targetFile;
            long lastModifiedTime = GetLastModifyTime(filePath);

            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "insert into files values (@fileName,@filePath, @lastModifiedTime);";
                //匹配字符 fileName 等！！！
                //string 会自动添加单引号
                cmd.Parameters.AddWithValue("@fileName", fileName);
                cmd.Parameters.AddWithValue("@filePath", filePath);
                cmd.Parameters.AddWithValue("@lastModifiedTime", lastModifiedTime);
                cmd.ExecuteNonQuery();

                //                 cmd.CommandText = "insert into (@file) (sentence) values (@sentence);";
                //                 cmd.Parameters.Add(new SQLiteParameter("@file"));
                //                 cmd.Parameters["@file"].Value = Path.GetFileNameWithoutExtension(filePath);

            }
        }

        //返回单行信息
        public static SQLiteDataReader GetFileInfo(string targetFile, SQLiteConnection sqliteConnection)
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "select * from files where name like @filePath;";
                cmd.Parameters.AddWithValue("@filePath", targetFile);

                ////test语句
                //cmd.CommandText = "select * from files ;";

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

        public bool IsModifid(string filePath)
            {
            //用当前的文件和数据库的文件比较
                //if(LastModifyTime(filePath) 
                    return true;
            }
        //public void WriteTable(string tableName, SQLiteConnection sqliteConnection)
        // {
        //     using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
        //     {
        //         IDbTransaction trans = sqliteConnection.BeginTransaction();
        //         try
        //         {
        //             //以 .  切分句子
        //             StreamReader sr = File.OpenText(filePath);
        //             string sentence = sr.ReadToEnd();
        //             string[] split_s = sentence.Split(new char[] { '.' });


        //             //should create a table named as filename
        //             for (int i = 0; i < split_s.Length; i++)
        //             {
        //                 cmd.CommandText = "insert into (@file) (sentence) values (@sentence);";
        //                 cmd.Parameters.Add(new SQLiteParameter("@file"));
        //                 cmd.Parameters["@file"].Value = Path.GetFileNameWithoutExtension(filePath);

        //                 cmd.Parameters.Add(new SQLiteParameter("@sentence"));
        //                 cmd.Parameters["@sentence"].Value = split_s[i];

        //                 cmd.ExecuteNonQuery();
        //             }
        //         }
        //         catch (Exception)
        //         {

        //         }
        //     }
        // }

    }

    public static class TimeHandler
    {
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime TimeStamp2DateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static int DateTime2TimeStamp(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

    }
}

