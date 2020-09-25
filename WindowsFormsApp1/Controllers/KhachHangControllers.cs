using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;


namespace WindowsFormsApp1.Controllers
{
    class KhachHangControllers
    {
        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string getMaMoi()
        {
            return RandomString(4) + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        }
        public static int insertKhachHang(string id,string ten,string ho,string sdt,string email,string diachi,string ns,string idlkh,int sex,DataTable dsbenh, string text)
        {
            KhachHang kh = new KhachHang();
            kh.pcode = id;
            kh.pho = ho;
            kh.pten = ten;
            kh.pemail = email;
            kh.psdt = sdt;
            kh.pdc = diachi;
            kh.pns = ns;
            kh.pidlkh = idlkh;
            kh.pgt = sex;
            kh.pdsb = dsbenh;
            kh.pcustomerid = text;
            return kh.insertKH();
        }
        public static DataSet LoadLoaiKh()
        {
            return LoaiKhachHang.LayDSLoaiKH();
        }
        public static int ThemLoaiKhachHang(string tenloai)
        {
            LoaiKhachHang lkh = new LoaiKhachHang();
            lkh.ptenloai = tenloai;
            return lkh.InsertLoaiKH();
        }
        public static int XoaLoaiKhachHang(string id)
        {
            LoaiKhachHang lkh = new LoaiKhachHang();
            lkh.pid = id;
            return lkh.DeleteLoaiKH();
        }
        public static DataSet TimKiemTatCa(string id)
        {
         
            return KhachHang.timTC(id);
        }
        public static DataSet TimKiemTatCa1(string id)
        {

            return KhachHang.timTC1(id);
        }
       
        public static int xoaKhachHang(int id)
        {
            KhachHang kh = new KhachHang(id);
            return kh.xoaKH();
        }
        public static int updateKhachHang(int id,string code, string ten,string ho, string sdt, string email, string diachi, string ns,string idlkh,int sex,DataTable dtb,string mkh)
        {
           
            KhachHang kh = new KhachHang();
            kh.pid = id;
            kh.pcode = code;
            kh.pho = ho;
            kh.pten = ten;
            kh.pemail = email;
            kh.psdt = sdt;
            kh.pdc = diachi;
            kh.pns = ns;
            kh.pidlkh = idlkh;
            kh.pgt = sex;
            kh.pdsb = dtb;
            kh.pcustomerid = mkh;
            return kh.updateKH();


        }

        internal static int SuaLoaiKhachHang(string text1, string text2)
        {
            LoaiKhachHang lkh = new LoaiKhachHang();
            lkh.pid = text1;
            lkh.ptenloai = text2;
            return lkh.UpdateLoaiKH();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static DataSet getData()
        {
            return KhachHang.getData();
        }
        public static DataSet getBenhLiData(int id)
        {
            KhachHang kh = new KhachHang(id);
            return kh.getListBenh();
        }
        public static DataSet getAllBenhLi()
        {
            return SucKhoe.GetData();
        }
        public static DataSet getAllBenhLi1()
        {
            return SucKhoe.GetData1();
        }
        public static DataSet LayThongTinKH(int id)
        {
            KhachHang kh = new KhachHang(id);
            return kh.layThongTinKH();
        }

        internal static int khoiphucKH(string p)
        {
            int id = int.Parse(p);
            KhachHang kh = new KhachHang(id);
            return kh.KhoiPhuc();
        }

        internal static int restoreTypeCustomer(string p)
        {
            LoaiKhachHang lkh = new LoaiKhachHang();
            lkh.pid = p;
            return lkh.RestoreLKH();

        }

        internal static DataSet LoadLoaiKh1()
        {
            return LoaiKhachHang.LayDSLoaiKH1();
        }

        internal static string getMaKHMoi()
        {
            string machinhanh = Branch.getmachinhanh(User.getUser().pbranch.ToString());
            int idkh = Branch.getslkh(User.getUser().pbranch.ToString())+1;
            return machinhanh+"-" + idkh.ToString();
        }

        internal static int ExportData(DataTable dtb,string path)
        {
            
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = false;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Customer";
            for (int i = 1; i < dtb.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtb.Columns[i - 1].ColumnName;
            }
            for (int i = 0; i < dtb.Rows.Count ; i++)
            {
                for (int j = 0; j < dtb.Columns.Count; j++)
                {
                    DateTime dateTime;
                    if (DateTime.TryParse(dtb.Rows[i][j].ToString(), out dateTime) == true)
                    {
                        DateTime getdate = DateTime.Parse(dtb.Rows[i][j].ToString());
                        string date = getdate.Day + "/" + getdate.Month + "/" + getdate.Year + "-" + getdate.Hour + ":" + getdate.Minute + ":" + getdate.Second;
                        worksheet.Cells[i + 2, j + 1] = date;
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = dtb.Rows[i][j].ToString();
                    }
                }
            }
       
            DateTime csvtime = DateTime.Now;
            string time = csvtime.ToString("HH_mm_ss");
            string Path = path+@"\" + time + ".csv";
            workbook.SaveAs(Path , 62);
            // Exit from the application  
            app.Quit();
            if (File.Exists(Path))
            {
                return 1;
            }
            return 0;
        }

        internal static int ThemDsLoaiKhachHang(DataTable type)
        {
            return KhachHang.ThemDSLKH(type);
        }

        internal static int ThemDsKhachHang(DataTable addCustomer)
        {
            return KhachHang.ThemDSKH(addCustomer);
        }
    }
}
