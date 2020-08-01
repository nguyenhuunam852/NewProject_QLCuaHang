using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class SucKhoeControllers
    {
        public static DataSet getData()
        {
            return SucKhoe.GetData();
        }
        public static DataSet getDataKH(string id)
        {
            //KhachHang kh = new KhachHang(id);
            //return kh.getListBenh() ;
            return null;
        }
        public static int insertSucKhoe(string ten)
        {
            SucKhoe sk = new SucKhoe();
            sk.setTen(ten);
            return sk.InsertBenh();
        }
        public static int deleteSucKhoe(string id)
        {
            SucKhoe sk = new SucKhoe(id);
            return sk.deleteBenh();
        }
        public static DataSet timkiem(string ten,DataTable dtb)
        {
            return SucKhoe.TimKiem(ten,dtb);
        }
        public static int ThemSucKhoeKhachHang(int idkh,string idbenh)
        {
            KhachHang kh = new KhachHang(idkh);
            return kh.themTinhTrangBenh(idbenh);
        }
        public static DataSet LayThongTinvuathem()
        {
            return SucKhoe.LayThongTinVuaThem();
        }
        public static DataSet getBenhAvailable(DataTable dtb)
        {
            return KhachHang.GetListBenhConLai(dtb);
        }
        public static int XoaSucKhoeKhachHang(string idkh, string idbenh)
        {
            //KhachHang kh = new KhachHang(idkh);
            //return kh.XoaTinhTrangBenh(idbenh);
            return 0;
        }
    }
}
