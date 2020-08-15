﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    class UserControllers
    {
        public static string DangNhap(string username,string password)
        {
            Models.User _user = User.getUser();
            _user.pusername = username;
            _user.ppassword = password;
            _user.pid = _user.getId();
            _user.pgroup = int.Parse(_user.getGroupid(_user.pid));
            _user.pbranch = int.Parse(_user.getBranchid(_user.pid));
            return _user.DangNhap();
        }
    }
}
