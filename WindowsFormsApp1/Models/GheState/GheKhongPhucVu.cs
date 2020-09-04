using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApp1.Models.GheState
{
    class GheKhongPhucVu : State
    {
        private Ghe ghe;
        public GheKhongPhucVu(Ghe _ghe)
        {
            this.ghe = _ghe;
        }
        public override int BaoTri()
        {
            string[] paras = new string[1] { "@id" };
            object[] values = new object[1] { ghe.pid };
            return Models.Connection.Excute_Sql("BaoTriBan", CommandType.StoredProcedure, paras, values);
        }

        public override int duavaohoatdong()
        {
            return -2;
        }

        public override State GetTrangThai()
        {
            return null;
        }

        public override int InsertHoatDong(string idkh)
        {
            string[] paras = new string[4] { "@idghe", "@idkh", "@tg", "@activetime" };
            object[] values = new object[4] { ghe.pid, idkh, DateTime.Now,Settings.getSettings().ptghd };
            return Models.Connection.Excute_Sql("InsertDeskCustomer", CommandType.StoredProcedure, paras, values);
        }

        public override int KetthucHoatDong(string idkh, int tghd)
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
