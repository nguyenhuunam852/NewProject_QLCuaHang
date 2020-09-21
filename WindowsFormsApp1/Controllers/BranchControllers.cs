using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class BranchControllers
    {
        public static DataTable getData()
        {
            return Branch.getData();
        }

        internal static int insertBranch(string text1, string text2,string txtmanhanh)
        {
            Branch br = new Branch();
            br.pname = text1;
            br.paddress = text2;
            br.pcode = txtmanhanh;
            return br.InsertBranch();
        }
    }
}
