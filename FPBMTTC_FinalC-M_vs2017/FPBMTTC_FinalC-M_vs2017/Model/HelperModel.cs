using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace MagicECertService.Models
{
    public class HelperModel
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string role { get; set; }
        public static string constring { get; set; }
        //read and get values
        public HelperModel()
        {
            StreamReader reader = new StreamReader("ConnectString.con");
            this.Server = reader.ReadLine().Split(':')[1];
            this.Database = reader.ReadLine().Split(':')[1];
            this.UserName = reader.ReadLine().Split(':')[1];
            this.Password = reader.ReadLine().Split(':')[1];
            this.role = reader.ReadLine().Split(':')[1];
            reader.Close();
        }
        public SqlConnection GetConnect()
        {
            if (this.UserName != "")
                return new SqlConnection("Data Source=" + this.Server + ";Initial Catalog=" + this.Database + ";User Id=" + this.UserName + ";Password=" + this.Password + ";");
            else
                return new SqlConnection("Data Source=" + this.Server + ";Initial Catalog=" + this.Database + ";Integrated Security=True");
        }
        public static void WriteFile(string server, string data, string uid, string pass, string role)
        {
            StreamWriter writer = new StreamWriter("ConnectString.con");
            writer.WriteLine("Server:" + server);
            writer.WriteLine("Database:" + data);
            writer.WriteLine("UserName:" + uid);
            writer.WriteLine("PassWord:" + pass);
            writer.WriteLine("role:" + role);
            writer.Close();
        }
        public string BuildConnectionString()
        {
            // Build the connection string from the provided datasource and database
            String connString = "";
            if (UserName.Trim() == "")
                connString = @"data source=" + Server + ";initial catalog=" +
               Database + ";integrated security=True;";
            else
                connString = "data source=" + Server + ";initial catalog=" + Database + ";user id=" + UserName + ";password=" + Password + ";"
                    + ";integrated security=True;";
            constring = connString;
            return connString;
        }
        public static string GetsystemAdminLogin(string Server, string Database, string pass)
        {
            return "data source=" + Server + ";initial catalog=" + Database + ";user id=sa;password=" + pass + "; "
                    + ";integrated security=True;";
        }
    }
}