using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class SucKhoe
    {
        private string id;
        public string pid
        {
            get { return id; }
            set { id = value; }
        }
        private string ten;
        public string pten
        {
            get { return ten; }
            set { ten = value; }
        }
        public SucKhoe()
        {

        }
        public void setTen(string _ten)
        {
            this.ten = _ten;
        }
        public SucKhoe(string _id)
        {
            this.id = _id;
        }

        public int InsertBenh()
        {
            string[] paras = new string[] { "@name" };
            object[] values = new object[] { ten };
            return Models.Connection.Excute_Sql("InsertHeath", CommandType.StoredProcedure, paras, values);
        }
        public int deleteBenh()
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { this.id };
            return Models.Connection.Excute_Sql("deleteHealth", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet GetData()
        {
            return Models.Connection.FillDataSet("getListHeath1", CommandType.StoredProcedure);
        }
        public static DataSet LayThongTinVuaThem()
        {
            return Models.Connection.FillDataSet("getinfoHealthafterInsert", CommandType.StoredProcedure);
        }
        public static DataSet TimKiem(string ten,DataTable dtb)
        {
            string[] paras = new string[2] { "@ten", "@temp" };
            object[] values = new object[2] { ten,dtb };
            return Models.Connection.FillDataSet1("FindHealth", CommandType.StoredProcedure,ten,dtb);
        }

        internal int UpdateSK()
        {
            string[] paras = new string[] { "@id","@name" };
            object[] values = new object[] { id,ten };
            return Models.Connection.Excute_Sql("updateHealth", CommandType.StoredProcedure, paras, values);
        }

        internal int Restore()
        {
            string[] paras = new string[] { "@id" };
            object[] values = new object[] { id };
            return Models.Connection.Excute_Sql("RestoreHealth", CommandType.StoredProcedure, paras, values);
        }
    }
}
