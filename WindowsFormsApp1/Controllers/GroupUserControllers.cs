using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class GroupUserControllers
    {
        public static DataSet getData()
        {
            return GroupUser.GetData();
        }
    }
}
