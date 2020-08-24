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

        internal static int insertGroupUser(string name, DataTable dtb)
        {
            return GroupUser.InsertNew(name,dtb);   
        }

        internal static DataTable getlistpermisson()
        {
            try
            {
                return GroupUser.getlistPermission().Tables[0];
            }
            catch
            {
                return null;
            }

        }

        internal static DataTable getListPermissionbyId(string a)
        {
            return GroupUser.getlistPermission(a).Tables[0];
        }

        internal static int UpdateGroupUser(string text, DataTable savedtb)
        {
            return GroupUser.Update(text, savedtb);
        }

        internal static int deleteGrouUser(string a)
        {
            GroupUser gu = new GroupUser(a);
            return gu.deleteGroupUSer();
        }
    }
}
