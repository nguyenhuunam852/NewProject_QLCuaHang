using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models.GheState
{
    class GheDangHoatDong : State
    {
        private Ghe ghe;
        public GheDangHoatDong(Ghe _ghe)
        {
            this.ghe = _ghe;
        }
        public override int BaoTri()
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { ghe.pid };
            return Models.Connection.Excute_Sql("maintenance", CommandType.StoredProcedure, paras, values);

        }

        public override int duavaohoatdong()
        {
            return -2;
        }

        public override State GetTrangThai()
        {
            string sql = "select dbo.CheckExistinDeskCustomer('" + ghe.pid + "')";
            string ck = Models.Connection.ExcuteScalar(sql);
            if(ck == "1")
            {
                return new GheDangphucVu(ghe);
            }
            if(ck=="0")
            {
                return new GheKhongPhucVu(ghe);
            }
            return null;
        }

        public override int InsertHoatDong(string idkh)
        {
            return GetTrangThai().InsertHoatDong(idkh);
        }

        public override int KetthucHoatDong(string idkh,int tghd)
        {
            return GetTrangThai().KetthucHoatDong(idkh,tghd);
        }

        public override int XoaGhe()
        {
            return GetTrangThai().XoaGhe();
        }
    }
}
