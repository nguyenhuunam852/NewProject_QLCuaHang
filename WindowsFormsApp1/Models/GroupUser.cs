using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class GroupUser
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
        public static DataSet GetData()
        {
            string[] paras = new string[] { "@idbranch" };
            object[] values = new object[] { User.getUser().pbranch };
            return Models.Connection.FillDataSet("getGroupUser", CommandType.StoredProcedure, paras, values);
        }

    }
}
