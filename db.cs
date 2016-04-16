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


          public string DBPath(){
               string sysPath = System.Windows.Forms.Application.StartupPath + @"../../../";
              System.IO.Directory.SetCurrentDirectory(sysPath);
              string path = System.IO.Directory.GetCurrentDirectory() + @"\db\sentence.db";
              return path;
          }
          
          //所有文件的路径集合
          public DBConnection()
          {


              string sConn = SQLiteConnectionString.GetConnectionString( DBPath() );

              SQLiteConnection conn = new SQLiteConnection(sConn);

              try
              {
                  conn.Open();
              }
              catch (Exception)
              {
                  //为什么链接失败也不会结束？
                  //为什么程序自己会创建一个sentence.db文件？
                  MessageBox.Show("\n找不到数据库数据文件！");
                  System.Environment.Exit(0);
              }

              Console.WriteLine(conn.FileName);



              Stopwatch stopwatch = new Stopwatch();
              stopwatch.Start();


              File2DB(filePath, conn);
             
                  stopwatch.Stop();
                  Console.WriteLine(stopwatch.Elapsed);
              }


          public bool Fold2DB(DirectoryInfo dbDir, SQLiteConnection conn)
          {
              string searchPattern = @"*.txt";

              foreach (DirectoryInfo NextFolder in dbDir.GetDirectories())
              {

                  foreach (FileInfo NextFile in dbDir.GetFiles(searchPattern))
                  {
                      string filePath = NextFile.ToString();
                      File2DB(filePath, conn);
                  }
                  
              }
              return true;

              
          }
          public bool File2DB(string filePath2, SQLiteConnection conn){

              using (SQLiteCommand cmd = conn.CreateCommand())
              {
                  IDbTransaction trans = conn.BeginTransaction();
                  try
                  {

                      //文件路径，应该改为遍历文件夹类型
                      string filePath = @"C:\Users\ludwig\Documents\sentence.txt";
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

                  conn.Close();
return true;
          }
}

      public class SentcHandler
      {
          public bool CreatDB(){
          }
          
          public bool RefreshDB{
          }

          private bool IsDBReady{

          }
    

          }

      }
  }