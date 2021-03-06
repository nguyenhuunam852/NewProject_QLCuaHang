﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Views;
namespace WindowsFormsApp1.Controllers
{
    class UserControllers
    {
        public static string DangNhap(string username,string password)
        {
            Models.User _user = User.getUser();
            _user.pusername = username;
            _user.ppassword = password;
           
            return _user.DangNhap();
           
        }

        internal static int insertUser(string ten,string ho, string sdt, string email, string dc, string ns, string idluser, int gt)
        {
            
            User user = new User();
            user.pho = ho;
            user.pten = ten;
            user.pemail = email;
            user.psdt = sdt;
            user.pgroup = int.Parse(idluser);
            user.pdc = dc;
            user.pns = ns;
            user.pgt = gt;
            return user.insertuser();
        }

        internal static int DoiMatKhau(string id,string text1, string text2)
        {
            return User.DoiMatKhau(id,text1, text2);
        }

        internal static int DoiMatKhau(string id, string text)
        {
            return User.DoiMatKhau(id, text);
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        internal static int CountUserinBranch(int v)
        {
            return User.CountUserinBranch(v);
        }

        internal static void getAllInformation()
        {
            Models.User _user = User.getUser();
            _user.pid = _user.getId();
            _user.getAllinfor();
           
        }

        internal static DataTable getData()
        {
            return User.getData();
        }

        internal static int updateUser(int id, string ten,string ho, string sdt, string email, string dc, string ns, string idluser, int gt)
        {
           
            User user = new User();
            user.pid = id.ToString();
            user.pho = ho;
            user.pten = ten;
            user.pemail = email;
            user.psdt = sdt;
            user.pgroup = int.Parse(idluser);
            user.pdc = dc;
            user.pns = ns;
            user.pgt = gt;
            return user.updateuser();
        }

        internal static int deleteUser(int id)
        {
            User us = new User(id);
            return us.deleteUser();
        }

        internal static int RestoreUser(string p)
        {
            int id = int.Parse(p);
            User us = new User(id);
            return us.RestoreUser();
        }
    }
}
