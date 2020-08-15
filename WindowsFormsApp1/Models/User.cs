using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WindowsFormsApp1.Models
{
    class User
    {
        private string id;
        public string pid
        {
            get { return id; }
            set { id = value; }
        }
        private string username;
        public string pusername
        {
            get { return username; }
            set { username = value; }
        }
        private string password;
        public string ppassword
        {
            get { return password; }
            set { password = value; }
        }
        private string code;
        public string pcode
        {
            get { return code; }
            set { code = value; }
        }
        public int group;
        public int pgroup
        {
            get { return group; }
            set { group = value; }
        }
        public int branch;
        public int pbranch
        {
            get { return branch; }
            set { branch = value; }
        }

        public static User _user;
        public User()
        {

        }
        public User(string _username,string _pass)
        {
            this.username = _username;
            this.password = _pass;
            this.id = getId();
            this.group = int.Parse(getGroupid(id));
            this.branch = int.Parse(getBranchid(id));
        }
        public string getId()
        {
            string[] paras = new string[1] { "@username" };
            object[] values = new object[1] { username };
            return Models.Connection.ExcuteScalar("getUserId", CommandType.StoredProcedure, paras, values);
        }
        public string getGroupid(string id)
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { id };
            return Models.Connection.ExcuteScalar("getGroupId", CommandType.StoredProcedure, paras, values);
        }
        public string getBranchid(string id)
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { id };
            return Models.Connection.ExcuteScalar("getBranchId", CommandType.StoredProcedure, paras, values);
        }
        public static User getUser()
        {
            if(_user==null)
            {
                _user= new User();
            }
            return _user;
        }
        public string DangNhap()
        {
            string sql = "select dbo.Login('" + username + "','" + password + "')";
            return Models.Connection.ExcuteScalar(sql);
        }
    }
}
