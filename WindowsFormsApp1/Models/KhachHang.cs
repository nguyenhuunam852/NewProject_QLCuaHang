using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class KhachHang
    {
        private int id;
        public int pid
        {
            get { return id; }
            set { id = value; }
        }
        private string code;
        public string pcode
        {
            get { return code; }
            set { code = value; }
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
        public string pns
        {
            get { return ns; }
            set { ns = value; }
        }
        private int gt;
        public int pgt
        {
            get { return gt; }
            set { gt = value; }
        }
        private string idlkh;
        public string pidlkh
        {
            get { return idlkh; }
            set { idlkh = value; }
        }
        private DataTable dsb;
        public DataTable pdsb
        {
            get { return dsb; }
            set { dsb = value; }
        }
        public KhachHang()
        {

        }
        public KhachHang(int _id)
        {
            this.id = _id;
        }
        public KhachHang(string _id,string _ho,string _ten,string _email,string _sdt,string _dc,string _ns,string _idlkh,int _gt)
        {
            this.ho = _ho;
            this.ten = _ten;
            this.email = _email;
            this.sdt = _sdt;
            this.dc = _dc;
            this.ns = _ns;
            this.idlkh = _idlkh;
            this.gt = _gt;
        }

        internal static int checkKH(string mkh)
        {
            return int.Parse(Models.Connection.ExcuteScalar("select dbo.CheckCustomerinDay(" + User.getUser().pid + "," + mkh + ")"));
        }

        public int themTinhTrangBenh(string idb)
        {
          
                string[] paras = new string[2] { "@idkh", "@idbenh" };
                object[] values = new object[2] { id, idb };
                return Models.Connection.Excute_Sql("insertSKKH", System.Data.CommandType.StoredProcedure, paras, values);
            
        }
        public int XoaTinhTrangBenh(string idb)
        {

            string[] paras = new string[2] { "@idkh", "@idbenh" };
            object[] values = new object[2] { id, idb };
            return Models.Connection.Excute_Sql("deleteSKKH", System.Data.CommandType.StoredProcedure, paras, values);

        }
        public int insertKH()
        {
            string[] paras = new string[] { "@id","@ho","@ten","@sdt","@email","@dc","@ns","@ca", "@idlkh","@sex","@available","@user", "@temp" };
            object[] values = new object[] { code,ho,ten,sdt,email,dc,ns,DateTime.Now,idlkh,gt,1,User.getUser().pid,dsb };
            return Models.Connection.Excute_Sql("insertCustomer", System.Data.CommandType.StoredProcedure,paras,values);
        }
        public int updateKH()
        {
            string[] paras = new string[] { "@id","@code", "@ho", "@ten", "@sdt", "@email", "@ca", "@dc", "@ns", "@idlkh","@sex","@available", "@user","@Temp" };
            object[] values = new object[] { id,code, ho, ten, sdt, email,DateTime.Now, dc, ns,idlkh,gt, 1, User.getUser().pid,dsb };
            return Models.Connection.Excute_Sql("updateCustomer", System.Data.CommandType.StoredProcedure, paras, values);
        }
        public int xoaKH()
        {
            string[] paras = new string[1] { "@id"};
            object[] values = new object[1] { id };
            return Models.Connection.Excute_Sql("deleteCustomer", System.Data.CommandType.StoredProcedure, paras, values);
        }

        public static DataSet getData()
        {
            string[] paras = new string[1] { "@user" };
            object[] values = new object[1] { User.getUser().pid };
            return Models.Connection.FillDataSet("GetListCustomer", CommandType.StoredProcedure,paras,values);
        }
     
        public static DataSet timTC(string st)
        {
            string sql = "exec FindInfor N'" + st + "',"+User.getUser().pid;
            return Models.Connection.FillDataSet(sql);
        }
        public DataSet getListBenh()
        {
                string[] paras = new string[1] { "@idcs" };
                object[] values = new object[1] { id };
                return Models.Connection.FillDataSet("getListHeathofCustomer", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet GetListBenhConLai(DataTable dtb)
        {
            string[] paras = new string[1] { "@temp" };
            object[] values = new object[1] { dtb };
            return Models.Connection.FillDataSet("getlistHealthAvailable", CommandType.StoredProcedure, paras, values);
        }
        public DataSet layThongTinKH()
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { id };
            return Models.Connection.FillDataSet("getCustomerInfor", CommandType.StoredProcedure, paras, values);
        }
    }
}
