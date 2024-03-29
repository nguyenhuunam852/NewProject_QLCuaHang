﻿using System;
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
        private string a;

        public GroupUser(string id)
        {
            this.id = id;
        }

        public string pname
        {
            get { return name; }
            set { name = value; }
        }

        internal static int InsertNew(string name,DataTable dtb)
        {
            string[] paras = new string[] { "@idbranch", "@name","@table" };
            object[] values = new object[] { User.getUser().pbranch,name,dtb };
            return Models.Connection.Excute_Sql("InsertNewGroupUser", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet getlistPermission(string a)
        {
            string[] paras = new string[] { "@idgroup" };
            object[] values = new object[] { a };
            return Models.Connection.FillDataSet("getPermissionById", CommandType.StoredProcedure, paras, values);
        }

        public int deleteGroupUSer()
        {
            string[] paras = new string[] { "@idgroup" };
            object[] values = new object[] { id };
            return Models.Connection.Excute_Sql("DeleteGroupUser", CommandType.StoredProcedure, paras, values);
        }

        internal static int Update(string text,string name, DataTable savedtb)
        {
            string[] paras = new string[] { "@idgroup", "@table","@name" };
            object[] values = new object[] { text, savedtb,name };
            return Models.Connection.Excute_Sql("UpdateGroupUser", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet getlistPermission()
        {
            return Models.Connection.FillDataSet("getlistPermission", CommandType.StoredProcedure);
        }

        public static DataSet GetData()
        {
            string[] paras = new string[] { "@idbranch" };
            object[] values = new object[] { User.getUser().pbranch };
            return Models.Connection.FillDataSet("getGroupUser", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet GetData1()
        {
            string[] paras = new string[] { "@idbranch" };
            object[] values = new object[] { User.getUser().pbranch };
            return Models.Connection.FillDataSet("getGroupUser1", CommandType.StoredProcedure, paras, values);
        }
        internal static int insertAdmin(int br)
        {
            string[] paras = new string[] { "@idbranch" };
            object[] values = new object[] { br };
            return Models.Connection.Excute_Sql("insertAdmin", CommandType.StoredProcedure, paras, values);
        }

        internal int RestoreGroupUSer()
        {
            string[] paras = new string[] { "@id" };
            object[] values = new object[] { id };
            return Models.Connection.Excute_Sql("RestoregroupUser", CommandType.StoredProcedure, paras, values);
        }
    }
}
