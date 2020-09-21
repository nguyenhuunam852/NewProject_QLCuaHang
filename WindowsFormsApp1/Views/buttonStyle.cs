using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    class buttonStyle
    {
        public static Button createBtn(Button addbutton)
        {
            addbutton.BackColor = Color.LightPink;
            addbutton.EnabledChanged += Addbutton_EnabledChanged;
            addbutton.Size = new Size(31, 27);
            addbutton.Font = Fonts.FontAwesome;
            addbutton.Text = Fonts.fa.plus;
            addbutton.AutoSize = true;
            
            return addbutton;
        }

        private static void Addbutton_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Enabled==true)
            {
                btn.BackColor= Color.LightPink;
            }
            else
            {
                btn.BackColor = Color.DarkRed;
            }
        }

        public static Button updateBtn(Button updatebutton)
        {

            updatebutton.BackColor = Color.LightGreen;
            updatebutton.Size = new Size(31, 27);
            updatebutton.EnabledChanged += Updatebutton_EnabledChanged;
            updatebutton.Font = Fonts.FontAwesome;
            updatebutton.Text = Fonts.fa.pencil;
            updatebutton.AutoSize = true;
            return updatebutton;
        }

        private static void Updatebutton_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled == true)
            {
                btn.BackColor = Color.LightGreen;
            }
            else
            {
                btn.BackColor = Color.DarkGreen;
            }
        }

        public static Button deleteBtn(Button deletebutton)
        {

            deletebutton.BackColor = Color.LightBlue;
            deletebutton.Size = new Size(31, 27);
            deletebutton.EnabledChanged += Deletebutton_EnabledChanged;
            deletebutton.Font = Fonts.FontAwesome;
            deletebutton.Text = Fonts.fa.trash;
            deletebutton.AutoSize = true;
            return deletebutton;
        }

        private static void Deletebutton_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled == true)
            {
                btn.BackColor = Color.LightBlue;
            }
            else
            {
                btn.BackColor = Color.DarkBlue;
            }
        }

        public static Button saveBtn(Button savebutton)
        {

            savebutton.BackColor = Color.LightYellow;
            savebutton.Size = new Size(31, 27);
            savebutton.EnabledChanged += Savebutton_EnabledChanged;
            savebutton.Font = Fonts.FontAwesome;
            savebutton.Text = Fonts.fa.floppy_o;
            savebutton.AutoSize = true;
            return savebutton;
        }

        private static void Savebutton_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled == true)
            {
                btn.BackColor = Color.LightYellow;
            }
            else
            {
                btn.BackColor = Color.DarkGoldenrod;
            }
        }

        public static Button closeBtn(Button cancelbutton)
        {

            cancelbutton.BackColor = Color.LightSteelBlue;
            cancelbutton.Size = new Size(31, 27);
            cancelbutton.EnabledChanged += Cancelbutton_EnabledChanged;
            cancelbutton.Font = Fonts.FontAwesome;
            cancelbutton.Text = Fonts.fa.ban;
            cancelbutton.AutoSize = true;
            return cancelbutton;
        }

        private static void Cancelbutton_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled == true)
            {
                btn.BackColor = Color.LightSteelBlue;
            }
            else
            {
                btn.BackColor = Color.DarkSlateBlue;
            }
        }
    }
}
