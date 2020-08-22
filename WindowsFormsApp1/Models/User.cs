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
        private string ho;
        public string pho
        {
            get { return ho; }
            set { ho = value; }
        }

        private string ten;
        public string pten
        {
            get { return ten; }
            set { ten = value; }
        }
        private string sdt;
        public string psdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string email;
        public string pemail
        {
            get { return email; }
            set { email = value; }
        }
        private string dc;
        public string pdc
        {
            get { return dc; }
            set { dc = value; }
        }
        private string ns;

        public static int DoiMatKhau(string text1, string text2, string text21)
        {
            string[] paras = new string[] { "@id","@mkc","@mkm" };
            object[] values = new object[] { text1,text2,text21 };
            return Models.Connection.Excute_Sql("DoiMatKhau", System.Data.CommandType.StoredProcedure, paras, values);
        }

        internal static int DoiMatKhau(string id, string text)
        {
            string[] paras = new string[] { "@id", "@mkm" };
            object[] values = new object[] { id, text };
            return Models.Connection.Excute_Sql("DoiMatKhau2", System.Data.CommandType.StoredProcedure, paras, values);
        }

        public string pns
        {
            get { return ns; }
            set { ns = value; }
        }

        internal int insertuser()
        {
            string[] paras = new string[] { "@ho", "@ten", "@sdt", "@email", "@dc", "@ns", "@ca", "@idlkh", "@sex", "@available"};
            object[] values = new object[] { ho, ten, sdt, email, dc, ns, DateTime.Now, group, gt, 1};
            return Models.Connection.Excute_Sql("insertUser", System.Data.CommandType.StoredProcedure, paras, values);
        }

        internal void getAllinfor()
        {
            string[] paras = new string[] { "@id" };
            object[] values = new object[] { id };
            DataTable dtb = Models.Connection.FillDataSet("getUserbyid", System.Data.CommandType.StoredProcedure, paras, values).Tables[0];
            ho = dtb.Rows[0]["lastname"].ToString();
            ten = dtb.Rows[0]["firstname"].ToString();
            sdt = dtb.Rows[0]["phone"].ToString();
            email = dtb.Rows[0]["email"].ToString();
            ns = dtb.Rows[0]["birthday"].ToString();
            if(dtb.Rows[0]["sex"].ToString()=="Nam")
            {
                gt = 0;
            }
            if (dtb.Rows[0]["sex"].ToString() == "Nữ")
            {
                gt = 1;
            }
            else
            {
                gt = 2;
            }

            dc = dtb.Rows[0]["address"].ToString();
            group = Convert.ToInt32(dtb.Rows[0]["idgroup"].ToString());
            branch = int.Parse(getBranchid(id));
            permission = getPermission();
        }

        private int gt;
        public int pgt
        {
            get { return gt; }
            set { gt = value; }
        }
        
       
        private int group;
        public int pgroup
        {
            get { return group; }
            set { group = value; }
        }
        private int branch;
        public int pbranch
        {
            get { return branch; }
            set { branch = value; }
        }

        internal static DataTable getData()
        {
            string[] paras = new string[1] { "@idbranch" };
            object[] values = new object[1] { User.getUser().pbranch };
            return Models.Connection.FillDataSet("getAllUserinBranch", CommandType.StoredProcedure, paras, values).Tables[0];
        }

        internal int updateuser()
        {
            string[] paras = new string[] { "@id","@ho", "@ten", "@sdt", "@email", "@dc", "@ns", "@ca", "@idlkh", "@sex", "@available" };
            object[] values = new object[] { id,ho, ten, sdt, email, dc, ns, DateTime.Now, group, gt, 1 };
            return Models.Connection.Excute_Sql("updateUser", System.Data.CommandType.StoredProcedure, paras, values);
        }

        internal int deleteUser()
        {
            string[] paras = new string[] { "@id"};
            object[] values = new object[] { id};
            return Models.Connection.Excute_Sql("deleteUser", System.Data.CommandType.StoredProcedure, paras, values);
        }

        private DataTable permission;
        public DataTable ppermission
        {
            get { return permission; }
            set { permission = value; }
        }

        public static User _user;
        private int id1;

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

        public User(int id)
        {
            this.id = id.ToString();
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
        public DataTable getPermission()
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { group };
            return Models.Connection.FillDataSet("getPermissionbyIdUser", CommandType.StoredProcedure, paras, values).Tables[0];
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
        public User DangXuat()
        {
            _user = new User();
            return _user;
        }
    }
}
