﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models.GheState;

namespace WindowsFormsApp1.Models
{
    class Ghe
    {
        private string id;
        public string pid
        {
            get { return id; }
            set { id = value; }
        }
        private string tinhtrang;
        public string ptinhtrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }
      
        private string lx;
        public string plx
        {
            get { return lx; }
            set { lx = value; }
        }
        private string ly;
        public string ply
        {
            get { return ly; }
            set { ly = value; }
        }
        private State state;
        public State pstate
        {
            get { return state; }
            set { state = value; }
        }
        private int quanli;
        public int pquanli
        {
            get { return quanli; }
            set { quanli = value; }
        }
        private string tenban;
        public string ptenban
        {
            get { return tenban; }
            set { tenban = value; }
        }
        public Ghe()
        {
          
        }
        public Ghe(string _id)
        {
            this.id = _id;
        }
        public void getInfoById()
        {
            DataSet dts = new DataSet();
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { id };
            dts = Models.Connection.FillDataSet("getDeskInfobyId", CommandType.StoredProcedure, paras, values);
            this.tinhtrang = dts.Tables[0].Rows[0]["status"].ToString();
            this.lx = dts.Tables[0].Rows[0]["locationX"].ToString();
            this.ly = dts.Tables[0].Rows[0]["locationY"].ToString();
            this.quanli = Convert.ToInt32(dts.Tables[0].Rows[0]["iduser"].ToString());
            this.tenban = dts.Tables[0].Rows[0]["name"].ToString();
        }
        public State getStateInfo()
        {
            getInfoById();
            if(this.tinhtrang=="0")
            {
                return new GheDangBaoTri(this);
            }
            if(this.tinhtrang=="1")
            {
                return new GheDangHoatDong(this);
            }
            return null;
        }
        public void insertGhe()
        {
            DataSet dts = new DataSet();
            string[] paras = new string[] { "@iduser", "@name" };
            object[] values = new object[] { User.getUser().pbranch,tenban };
            dts = Models.Connection.FillDataSet("InsertandgetInformation", CommandType.StoredProcedure, paras, values);
            this.id = dts.Tables[0].Rows[0]["id"].ToString();
            this.lx = dts.Tables[0].Rows[0]["locationx"].ToString();
            this.ly = dts.Tables[0].Rows[0]["locationy"].ToString();
            this.quanli = Convert.ToInt32(dts.Tables[0].Rows[0]["iduser"].ToString());
            this.tenban = dts.Tables[0].Rows[0]["name"].ToString();
        }

        internal static int TiepTucHoatDong(string text)
        {
            string[] paras = new string[] { "@id" };
            object[] values = new object[] { text };
            return Models.Connection.Excute_Sql("Continue_to_work", CommandType.StoredProcedure, paras, values);
        }

        internal static int TamDung(string text)
        {
            string[] paras = new string[] { "@id"};
            object[] values = new object[] { text };
            return Models.Connection.Excute_Sql("Stop_now", CommandType.StoredProcedure, paras, values);
        }

        public void insertGhe1(int x,int y)
        {
            DataSet dts = new DataSet();
            string[] paras = new string[] { "@iduser", "@name","@lx","@ly" };
            object[] values = new object[] { User.getUser().pbranch, tenban,x,y };
            dts = Models.Connection.FillDataSet("InsertandgetInformation1", CommandType.StoredProcedure, paras, values);
            this.id = dts.Tables[0].Rows[0]["id"].ToString();
            this.lx = dts.Tables[0].Rows[0]["locationx"].ToString();
            this.ly = dts.Tables[0].Rows[0]["locationy"].ToString();
            this.quanli = Convert.ToInt32(dts.Tables[0].Rows[0]["iduser"].ToString());
            this.tenban = dts.Tables[0].Rows[0]["name"].ToString();
        }
        public int updateGhe()
        {
            DataSet dts = new DataSet();
            string[] paras = new string[] { "@id", "@status", "@name" };
            object[] values = new object[] { id,tinhtrang, tenban };
            return Models.Connection.Excute_Sql("updateDesk", CommandType.StoredProcedure, paras, values);
            
        }
        public DataSet laytthoatdong()
        {
            string[] paras = new string[1] { "@idghe" };
            object[] values = new object[1] { id };
            return Models.Connection.FillDataSet("CheckCustomerDesk", CommandType.StoredProcedure,paras,values);
        }
        public static DataSet layDSHoatDong()
        {
            return Models.Connection.FillDataSet("getlistdeskcustomer", CommandType.StoredProcedure);
        }
     
        public static DataSet layThongTin()
        {
            string[] paras = new string[1] { "@iduser" };
            object[] values = new object[1] { User.getUser().pbranch };
            return Models.Connection.FillDataSet("getdeskbyuserId", CommandType.StoredProcedure,paras,values);
        }
        public static int LuuTrangThai(DataTable dtb)
        {
            string[] paras = new string[1] { "@TempTable" };
            object[] values = new object[1] { dtb };
            return Models.Connection.Excute_Sql("savedesklocation", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet layThongTinTactCaGhe()
        {
            string[] paras = new string[1] { "@iduser" };
            object[] values = new object[1] { User.getUser().pbranch };
            return Models.Connection.FillDataSet("getdeskbyuserId1", CommandType.StoredProcedure, paras, values);
        }

        internal static int KhoiphucGhe(string p)
        {
            string[] paras = new string[1] { "@idghe" };
            object[] values = new object[1] { p };
            return Models.Connection.Excute_Sql("RestoreDesk", CommandType.StoredProcedure, paras, values);

        }
    } 
}
