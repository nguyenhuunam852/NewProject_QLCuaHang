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
        public static int XoaGhe(string id)
        {
            Models.Ghe ghe = new Models.Ghe(id);
            return ghe.getStateInfo().XoaGhe();
        }
        public static DataSet LayThongTinGhe()
        {
            return Models.Ghe.layThongTin();
        }
        public static int LuuTrangThai(DataTable dtb)
        {
            return Models.Ghe.LuuTrangThai(dtb);
        }

    }
}
