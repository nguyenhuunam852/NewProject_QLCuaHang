using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models.GheState
{
    class GheDangBaoTri : State
    {
        private Ghe ghe;
        public GheDangBaoTri(Ghe _ghe)
        {
            this.ghe = _ghe;
        }
        public override int BaoTri()
        {
            return -2;
        }

        public override int duavaohoatdong()
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { ghe.pid };
            return Models.Connection.Excute_Sql("active", CommandType.StoredProcedure, paras, values);
        }

        public override State GetTrangThai()
        {
            return null;
        }

        public override int InsertHoatDong(string idkh)
        {
            return -1;
        }

        public override int KetthucHoatDong(string idkh,int tghd)
        {
            return -1;
        }

        public override int XoaGhe()
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { ghe.pid };
            return Models.Connection.Excute_Sql("deleteDesk", CommandType.StoredProcedure, paras, values);
        }
    }

}
