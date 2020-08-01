using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models.GheState
{
    abstract class State
    {
        public abstract int BaoTri();
        public abstract int XoaGhe();
        public abstract int duavaohoatdong();
        public abstract State GetTrangThai();
        public abstract int InsertHoatDong(string idkh);
        public abstract int KetthucHoatDong(string idkh,int tghd);
    }
}
