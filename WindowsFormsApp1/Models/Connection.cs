﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WindowsFormsApp1.Models
{
    class Connection
    {
        public static string sqlcon = @"Data Source="+Settings.getSettings().pservername+"\\"+Settings.getSettings().pinstance+";Initial Catalog="+Settings.getSettings().pdatabasename+";Integrated Security=True";
        public static SqlConnection Getconnection()
        {
            SqlConnection con = new SqlConnection(sqlcon);
            return con;
        }
        public static SqlConnection connectMaster()
        {
            string master = @"Data Source=" + Settings.getSettings().pservername + "\\" + Settings.getSettings().pinstance + ";Initial Catalog=master;Integrated Security=True";
            SqlConnection con = new SqlConnection(master);
            return con;
        }
        public static void close()
        {
            try
            {
                if (Getconnection().State == ConnectionState.Open)
                    Getconnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public static DataSet FillDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, Getconnection());
                da.Fill(ds);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return ds;
        }
        public static DataSet FillDataSet(string sql, string table)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, Getconnection());
                da.Fill(ds, table);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return ds;
        }


        public static DataSet FillDataSet(string strQuery, CommandType cmdtype)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return ds;
        }

        public static DataSet FillDataSet(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlParameter sqlpara;
                for (int i = 0; i < para.Length; i++)
                {
                    sqlpara = new SqlParameter();
                    sqlpara.ParameterName = para[i];
                    sqlpara.SqlValue = values[i];

                    cmd.Parameters.Add(sqlpara);
                }

                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(ds);
                sqlda.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        public static DataSet FillDataSet1(string strQuery, CommandType cmdtype, string a, DataTable b)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

       
                SqlCommand cmd = new SqlCommand(strQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value=a;
                cmd.Parameters.Add("@temp", SqlDbType.Structured).Value =b ;
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(ds);
                sqlda.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public static DataSet DataSetReader(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            DataSet dsReader = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlParameter sqlpara;
                for (int i = 0; i < para.Length; i++)
                {
                    sqlpara = new SqlParameter();
                    sqlpara.ParameterName = para[i];
                    sqlpara.SqlValue = values[i];

                    cmd.Parameters.Add(sqlpara);
                }
                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                dsReader.Tables[0].Load(dataReader);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dsReader;
        }

        public static SqlDataReader DataReader(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection();
            con = Getconnection();
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strQuery;
            cmd.CommandType = cmdtype;

            cmd.Connection = con;
            SqlParameter sqlpara;
            for (int i = 0; i < para.Length; i++)
            {
                sqlpara = new SqlParameter();
                sqlpara.ParameterName = para[i];
                sqlpara.SqlValue = values[i];
                cmd.Parameters.Add(sqlpara);
            }
            dataReader = cmd.ExecuteReader();

            return dataReader;
        }

        public static DataSet DataSetReader1(string strQuery, CommandType cmdtype)
        {
            DataSet dsReader = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                dsReader.Tables[0].Load(dataReader);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dsReader;
        }
        public static DataSet DataSetReader(string strQuery, CommandType cmdtype)
        {
            DataSet dsReader = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                dsReader.Tables[0].Load(dataReader);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dsReader;
        }
        public static DataTable FillDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, Getconnection());
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return dt;
        }
        public static int Excute_Sql(string sql)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return i;
        }
        public static int Excute_Sql(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            int efftectRecord = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = strQuery;
            sqlcmd.Connection = conn;
            sqlcmd.CommandType = cmdtype;

            SqlParameter sqlpara;
            for (int i = 0; i < para.Length; i++)
            {
                sqlpara = new SqlParameter();
                sqlpara.ParameterName = para[i];
                sqlpara.SqlValue = values[i];
                sqlcmd.Parameters.Add(sqlpara);
            }
            try
            {
                efftectRecord = sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return efftectRecord;
        }

        public static int thucThiLenh(string sql)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    count = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra\r\n" + ex.Message);
                }
            }
            return count;
        }
        public static object docGiaTri(string sql)
        {
            object result = null;
            SqlConnection conn = Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra\r\n" + ex.Message);
            }
            return result;
        }
        public static string ExcuteScalar(string stringSQL)
        {
            string giaTri = "";
            try
            {
                SqlConnection sqlconn = Getconnection();
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand(stringSQL, sqlconn);
                giaTri = cmd.ExecuteScalar().ToString();
            }
            catch { }
            return giaTri;
        }
        public static string ExcuteScalar(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            string efftectRecord = "";
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = strQuery;
            sqlcmd.Connection = conn;
            sqlcmd.CommandType = cmdtype;

            SqlParameter sqlpara;
            for (int i = 0; i < para.Length; i++)
            {
                sqlpara = new SqlParameter();
                sqlpara.ParameterName = para[i];
                sqlpara.SqlValue = values[i];
                sqlcmd.Parameters.Add(sqlpara);
            }
            try
            {
                efftectRecord = sqlcmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return efftectRecord;
        }
    }

}
