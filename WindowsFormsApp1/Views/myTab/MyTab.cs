using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views.myTab
{
    class MyTab
    {
       
        public static Panel pn;
        public MyTab()
        {

        }
        public Panel createTab(Label label2,Label label1)
        {
           
            pn = new Panel();


            pn.AutoSize = true;
            pn.TabIndex = 1;
            pn.Margin = new Padding(0,0,0,0);
            pn.Controls.Add(label2);
            pn.Controls.Add(label1);
            return pn;
        }
        public Label getbuttonx(Label label1)
        {
            label1.AutoSize = false;
            label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
          
            label1.Location = new System.Drawing.Point(0, 0);
          
            label1.Size = new System.Drawing.Size(15, 13);
            label1.TabIndex = 3;
            label1.Text = "x";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label1;
        }
        public Label getLabel(Label label2)
        {
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            label2.Location = new System.Drawing.Point(15, 0);
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 2;
           

            return label2;
        }
    }
}
