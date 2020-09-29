using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class Branch
    {
        private string id;
        public string pid
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string pname
        {
            get { return name; }
            set { name = value; }
        }
        private string code;
        public string pcode
        {
            get { return code; }
            set { code = value; }
        }

        private string address;
        public string paddress
        {
            get { return address; }
            set { address = value; }
        }
        private string token1;
        public string ptoken1
        {
            get { return token1; }
            set { token1 = value; }
        }

        public void getInformation(int pbranch)
        {
            string[] paras = new string[] { "@id" };
            object[] values = new object[] { pbranch };
            DataTable dtb= Models.Connection.FillDataSet("getInforofBranch", CommandType.StoredProcedure, paras, values).Tables[0];
            name = dtb.Rows[0]["name"].ToString();
            address = dtb.Rows[0]["address"].ToString();
            code = dtb.Rows[0]["code"].ToString();
            token1 = dtb.Rows[0]["apptoken"].ToString();
            token2 = dtb.Rows[0]["usetoken"].ToString();
        }

        internal int updateBranch()
        {
            string[] paras = new string[] { "@id", "@name", "@address", "@code", "@apptoken", "@usetoken" };
            object[] values = new object[] { User.getUser().pbranch,name,address,code,token1,token2 };
            return Models.Connection.Excute_Sql("updateBranch", CommandType.StoredProcedure, paras, values);
        }

        private string token2;
        public string ptoken2
        {
            get { return token2; }
            set { token2 = value; }
        }

        public static DataTable getData()
        {
            return Models.Connection.FillDataSet("getAllBranch", CommandType.StoredProcedure).Tables[0];
        }
        public static Branch br;
        public static Branch getBranch()
        {
            if(br==null)
            {
                br = new Branch();
            }
            return br;
        }
        public int InsertBranch()
        {
            string[] paras = new string[5] { "@name", "@address","@code", "@apptoken", "@usetoken" };
            object[] values = new object[5] { name, address,code,token1,token2 };
            return Models.Connection.Excute_Sql("insertBranch", CommandType.StoredProcedure, paras, values);
        }

        internal static string getmachinhanh(string machinhanh)
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { machinhanh };
            return Models.Connection.ExcuteScalar("getcodeofbranch", CommandType.StoredProcedure, paras, values);
        }

        internal static int getslkh(string v)
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { v };
            return int.Parse(Models.Connection.ExcuteScalar("getamountofCustomer", CommandType.StoredProcedure, paras, values));

        }
    }
}
