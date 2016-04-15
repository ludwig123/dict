using System;  
using System.IO;
using System.Collections.Generic;  
using System.Linq;  
using System.Text;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace sentence
{

    DirectoryInfo TheFolder = new DirectoryInfo(foldPath);
    //遍历文件夹
    foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
        this.listbFile.Items.Add(NextFolder.Name);
    //遍历文件
    foreach (FileInfo NextFile in TheFolder.GetFiles())
        this.listbSentence.Items.Add(NextFile.Name);



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

}
