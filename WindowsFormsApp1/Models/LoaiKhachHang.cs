using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class LoaiKhachHang
    {
        private string id;
        public string pid
        {
            get { return id; }
            set { id = value; }
        }
        private string tenloai;
        public string ptenloai
        {
            get { return tenloai; }
            set { tenloai = value; }
        }
        public LoaiKhachHang()
        {

        }
        public int InsertLoaiKH()
        {
            string[] paras = new string[] { "@name" };
            object[] values = new object[] { tenloai };
            return Models.Connection.Excute_Sql("InsertTypeCustomer", CommandType.StoredProcedure, paras, values);
        }
        public int DeleteLoaiKH()
        {
            string[] paras = new string[] { "@id" };
            object[] values = new object[] { id };
            return Models.Connection.Excute_Sql("DeleteTypeCustomer", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet LayDSLoaiKH()
        {
            return Models.Connection.FillDataSet("GetListTypeCustomer", CommandType.StoredProcedure);
        }

    }
}
