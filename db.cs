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
using System.Xml;

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
          public string DBPath()
          {
              string sysPath = System.Windows.Forms.Application.StartupPath + @"../../../";
              System.IO.Directory.SetCurrentDirectory(sysPath);
              string path = System.IO.Directory.GetCurrentDirectory() + @"\db\sentence.db";
              return path;
          }
          
          public DBConnection()
          {
          }

          public SQLiteConnection Start( string DBPath)
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

          public void End(SQLiteConnection sqliteConnection )
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
          public bool File2DB(string filePath, SQLiteConnection sqliteConnection){

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

      public class SentcHandler
      {
          //public bool CreatDB(){
          //}
          
          //public bool RefreshDB{
          //}

          //private bool IsDBReady{

          //}
    

          }

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
                  cmd.CommandText = "CREATE TABLE `(@tableName)` (`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,`sentence`	INTEGER NOT NULL);";

                  cmd.Parameters.Add(new SQLiteParameter("@tableName"));
                  cmd.Parameters["@tableName"].Value = tableName;
                  cmd.ExecuteNonQuery();


              }
          }

      }
  }