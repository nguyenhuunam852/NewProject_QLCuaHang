using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class firstpage : UserControl
    {
        public firstpage()
        {
            InitializeComponent();
        }

        private void firstpage_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(Directory.GetCurrentDirectory()+"\\picture\\bgp.jpg");
            this.BackgroundImage = myimage;
        }
    }
}
