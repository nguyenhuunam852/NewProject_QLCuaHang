using Microsoft.SqlServer.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

using System.Security.AccessControl;
using System.Security.Principal;

namespace WindowsFormsApp1.Models
{
    class BackUp
    {
        string path =  Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "\\backup\\");
        ServerConnection _serverConnection;

        private Server _server;
        public Server Server
        {
            get
            {
                if (_server == null)
                {
                    Connect();
                }
                return _server;
            }
        }

       
        public DataTable getDTB(string txtFileName, string txtFolder)
        {
            DataTable ds = new DataTable();
            string path = txtFolder + "\\" + txtFileName;
            SqlConnection con = new SqlConnection(Connection.server);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "restore filelistonly from disk= N'"+path+"'";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        internal static string getbase(string v)
        {
            try
            {
                SqlConnection con = new SqlConnection(Connection.server);
                con.Open();
                string sql = "SELECT b.name FROM sys.master_files a join sys.databases b on a.database_id = b.database_id where a.physical_name =N'" + v + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteScalar().ToString();
            }
            catch {
                return null;
            }
        }
        internal static string getbase1(string v)
        {
            SqlCommand cmd;
            try
            {
                SqlConnection con = new SqlConnection(Connection.server);
                con.Open();
                string sql = "SELECT b.name FROM sys.master_files a join sys.databases b on a.database_id = b.database_id where a.physical_name =N'1'";
                cmd = new SqlCommand(sql, con);
                return cmd.ExecuteScalar().ToString();
            }
            catch
            {
                return null;
            }
            
        }

        public void Connect()
        {
            _serverConnection = new ServerConnection();
            _serverConnection.LoginSecure = false;
            _server = new Server(_serverConnection);
        }
        public string getstring(string a)
        {
            if(int.Parse(a)<10)
            {
                return "0" + a;
            }
            return a;
        }

        public int BackupDatabase(string text)
        {
            using (SqlConnection cn = new SqlConnection(Connection.sqlcon))
            {
                string name = getstring(DateTime.Now.Day.ToString()) + getstring(DateTime.Now.Month.ToString()) + getstring(DateTime.Now.Year.ToString())+'_'+getstring(DateTime.Now.Hour.ToString())+getstring(DateTime.Now.Minute.ToString())+getstring(DateTime.Now.Second.ToString());
                cn.Open();
                string path = text + "\\" + name+".bak";
                AddDirectorySecurity(text);
                string sql = "Backup database " + Settings.getSettings().pdatabasename + " to disk= N'" + path + "'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteNonQuery();
            }
        }

        public static void AddDirectorySecurity(string path)
        {

            var directoryInfo = new DirectoryInfo(path);
            var directorySecurity = directoryInfo.GetAccessControl();
            
            var fileSystemRule = new FileSystemAccessRule(@"Authenticated Users",
                                                          FileSystemRights.FullControl,
                                                          InheritanceFlags.ObjectInherit |
                                                          InheritanceFlags.ContainerInherit,
                                                          PropagationFlags.None,
                                                          AccessControlType.Allow);

            directorySecurity.AddAccessRule(fileSystemRule);
            directoryInfo.SetAccessControl(directorySecurity);
        }

        public int RestoreDatabase(string text, string text1, string text2)
        {
            using (SqlConnection cn = new SqlConnection(Connection.server))
            {
                cn.Open();
                string path = text2 + "\\" + text1;
                string sql = "Restore database "+text+" from disk= N'"+path+"'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
