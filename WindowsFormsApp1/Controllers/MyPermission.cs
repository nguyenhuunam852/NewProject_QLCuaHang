using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class MyPermission
    {
        public static int getpermission(string table,string permission)
        {
            DataRow dr = User.getUser().ppermission.AsEnumerable().SingleOrDefault(r => r.Field<string>("name") == table);
            if (dr != null)
            {
                return (int)dr[permission];
            }
            else
            {
                return 0;
            }
        }
    }
}
