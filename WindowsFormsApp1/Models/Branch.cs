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
            string[] paras = new string[2] { "@name", "@address" };
            object[] values = new object[2] { name, address };
            return Models.Connection.Excute_Sql("insertBranch", CommandType.StoredProcedure, paras, values);

        }
    }
}
