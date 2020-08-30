using System;
using System.Collections.Generic;
using System.Data;
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
        public static int insertKhachHang(string id,string ten,string ho,string sdt,string email,string diachi,string ns,string idlkh,int sex,DataTable dsbenh)
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
        public static int updateKhachHang(int id,string code, string ten,string ho, string sdt, string email, string diachi, string ns,string idlkh,int sex,DataTable dtb)
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
    }
}
