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
        public static DataTable getData()
        {
            return Models.Connection.FillDataSet("getAllBranch", CommandType.StoredProcedure).Tables[0];
        }

        public int InsertBranch()
        {
            string[] paras = new string[3] { "@name", "@address","@code" };
            object[] values = new object[3] { name, address,code };
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
