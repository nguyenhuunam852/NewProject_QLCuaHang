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

        public int BackupDatabase()
        {
            using (SqlConnection cn = new SqlConnection(Connection.sqlcon))
            {
                ServerConnection svCon = new ServerConnection(cn);
                Server svr = new Server(svCon);
                cn.Open();
                cn.ChangeDatabase("master");
                string name = getstring(DateTime.Now.Day.ToString()) + getstring(DateTime.Now.Month.ToString()) + getstring(DateTime.Now.Year.ToString())+'_'+getstring(DateTime.Now.Hour.ToString())+getstring(DateTime.Now.Minute.ToString())+getstring(DateTime.Now.Second.ToString());
                string testFolder = path;
                string databaseName = Settings.getSettings().pdatabasename;
                Backup backup = new Backup();
                backup.Action = BackupActionType.Database;
                backup.Database = databaseName;
                backup.Incremental = false;
                backup.Initialize = true;
                backup.LogTruncation = BackupTruncateLogType.Truncate;

                string fileName = string.Format("{0}\\{1}.bak", testFolder, name);
                BackupDeviceItem backupItemDevice = new BackupDeviceItem(fileName, DeviceType.File);
                backup.Devices.Add(backupItemDevice);
                backup.PercentCompleteNotification = 10;
               
                AddDirectorySecurity(path);

                backup.SqlBackup(svr);

                if (!VerifyBackup(svr,name))
                {
                    return 0;
                }
                svr = null;
                cn.Close();
            }
            return 1;
        }

        public bool VerifyBackup(Server svr,string name)
        {
            string testFolder = path;
            string databaseName = Settings.getSettings().pdatabasename;
            Restore restore = new Restore();
            restore.Action = RestoreActionType.Database;
            string fileName = string.Format("{0}\\{1}.bak", testFolder, name);
            BackupDeviceItem backupItemDevice = new BackupDeviceItem(fileName, DeviceType.File);
            restore.Devices.AddDevice(fileName, DeviceType.File);
            restore.Database = databaseName;
            restore.PercentCompleteNotification = 10;
            //restore.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
            AddDirectorySecurity(path);
            bool verified = restore.SqlVerify(svr);
            return verified;
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
                ServerConnection svCon = new ServerConnection(cn);
                Server srv = new Server(svCon);
                cn.Open();
                cn.ChangeDatabase("master");

                string testFolder = path;
                string databaseName = text;
                Restore res = new Restore();
                string filePath = text2 + "\\" + text1; 
                res.Devices.AddDevice(filePath, DeviceType.File);

                RelocateFile DataFile = new RelocateFile();
                string MDF = res.ReadFileList(srv).Rows[0][1].ToString();
                DataFile.LogicalFileName = res.ReadFileList(srv).Rows[0][0].ToString();
                DataFile.PhysicalFileName = srv.Databases[databaseName].FileGroups[0].Files[0].FileName;

                RelocateFile LogFile = new RelocateFile();
                string LDF = res.ReadFileList(srv).Rows[1][1].ToString();
                LogFile.LogicalFileName = res.ReadFileList(srv).Rows[1][0].ToString();
                LogFile.PhysicalFileName = srv.Databases[databaseName].LogFiles[0].FileName;

                res.RelocateFiles.Add(DataFile);
                res.RelocateFiles.Add(LogFile);

                res.Database = databaseName;
                res.NoRecovery = false;
                res.ReplaceDatabase = true;
                res.SqlRestore(srv);
                cn.Close();
            }
            return 1;
        }

    }
}
