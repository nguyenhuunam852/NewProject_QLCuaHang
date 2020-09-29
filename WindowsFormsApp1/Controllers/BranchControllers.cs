using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class BranchControllers
    {
        public static DataTable getData()
        {
            return Branch.getData();
        }

        internal static int insertBranch(string text1, string text2,string txtmanhanh,string apptoken,string usetoken)
        {
            Branch br = new Branch();
            br.pname = text1;
            br.paddress = text2;
            br.pcode = txtmanhanh;
            br.ptoken1 = apptoken;
            br.ptoken2 = usetoken;
            return br.InsertBranch();
        }

        internal static void getInformationofBranch(int pbranch)
        {
            Branch.getBranch().getInformation(pbranch);
        }

        internal static int updateBranch(string tennhanhtxt, string codetxt, string dctxt, string apptokentxt, string usetokentxt)
        {
            Branch br = Branch.getBranch();
            br.pname = tennhanhtxt;
            br.paddress = dctxt;
            br.pcode = codetxt;
            br.ptoken1 = apptokentxt;
            br.ptoken2 = usetokentxt;
            return br.updateBranch();
        }
    }
}
