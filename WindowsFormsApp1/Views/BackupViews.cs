using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Views
{
    public partial class BackupViews : UserControl
    {
        public BackupViews()
        {
            InitializeComponent();
        }
        public static BackupViews bu = new BackupViews();
        private void button1_Click(object sender, EventArgs e)
        {
            BackupControllers.backupData();
        }
    }
}
