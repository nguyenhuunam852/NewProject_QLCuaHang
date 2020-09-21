using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class GheControllers
    {
        public static object[] themGhe(string tinhtrang,string tenban)
        {
            Models.Ghe ghe = new Models.Ghe();
            ghe.ptinhtrang = tinhtrang;
            ghe.ptenban = tenban;
            ghe.insertGhe();
            object[] ghe_obj = { ghe.pid, ghe.ptinhtrang, ghe.plx, ghe.ply,ghe.ptenban };
            return ghe_obj;
        }
        public static object[] themGhe1(string tinhtrang, string tenban,int x,int y)
        {
            Models.Ghe ghe = new Models.Ghe();
            ghe.ptinhtrang = tinhtrang;
            ghe.ptenban = tenban;
            ghe.insertGhe1(x,y);
            object[] ghe_obj = { ghe.pid, ghe.ptinhtrang, ghe.plx, ghe.ply, ghe.ptenban };
            return ghe_obj;
        }
        public static int suathongtinGhe(string id,string tinhtrang, string tenban)
        {
            Models.Ghe ghe = new Models.Ghe();
            ghe.pid = id;
            ghe.ptinhtrang = tinhtrang;
            ghe.ptenban = tenban;
            return ghe.updateGhe();
        }
        public static int BaoTri(string id)
        {
            Models.Ghe ghe = new Models.Ghe(id);
            return ghe.getStateInfo().BaoTri();
        }
        public static int DuaVaoHoatDong(string id)
        {
            Models.Ghe ghe = new Models.Ghe(id);
            return ghe.getStateInfo().duavaohoatdong();
        }
        public static object[] LayThongTinGhebangID(string id)
        {
            Models.Ghe ghe = new Models.Ghe(id);
            ghe.getInfoById();
            object[] ghe_obj = { ghe.pid, ghe.ptinhtrang, ghe.plx, ghe.ply, ghe.ptenban };

            return ghe_obj;
        }
        public static int XoaGhe(string id)
        {
            Models.Ghe ghe = new Models.Ghe(id);
            return ghe.getStateInfo().XoaGhe();
        }
        public static DataSet LayThongTinGhe()
        {
            return Models.Ghe.layThongTin();
        }
        public static DataSet LayThongTinGheTatCaGhe()
        {
            return Models.Ghe.layThongTinTactCaGhe();
        }
        public static int LuuTrangThai(DataTable dtb)
        {
            return Models.Ghe.LuuTrangThai(dtb);
        }


        internal static int khoiphucGhe(string p)
        {
            return Models.Ghe.KhoiphucGhe(p);
        }

        internal static int NgungHoatDong(string text)
        {
            return Models.Ghe.TamDung(text);
        }

        internal static int TiepTucHoatDong(string text)
        {
            return Models.Ghe.TiepTucHoatDong(text);
        }
    }
}
