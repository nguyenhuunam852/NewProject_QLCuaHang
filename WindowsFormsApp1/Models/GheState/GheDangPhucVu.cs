using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models.GheState
{
    class GheDangphucVu : State
    {
        private Ghe ghe;
        public GheDangphucVu(Ghe _ghe)
        {
            this.ghe = _ghe;
        }
        public override int BaoTri()
        {
            return -5;
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
            return -2;
        }

        public override int KetthucHoatDong(string idkh,int tghd)
        {
            string[] paras = new string[3] { "@idghe", "@idkh", "@hd " };
            object[] values = new object[] { ghe.pid, idkh, tghd };
            return Models.Connection.Excute_Sql("DeleteCustomerDesk", CommandType.StoredProcedure, paras, values);
        }

        public override int XoaGhe()
        {
            return -5;
        }
    }
}
