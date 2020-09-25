using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Excel
{
    class Customer
    {
        [ExcelColumn("id")]
        public string id { get; set; }

        [ExcelColumn("customerid")]
        public string customerid { get; set; }

        [ExcelColumn("code")]
        public string code { get; set; }

        [ExcelColumn("CreateAt")]
        public string creatat { get; set; }

        [ExcelColumn("firstname")]
        public string fname { get; set; }

        [ExcelColumn("lastname")]
        public string lname { get; set; }

        [ExcelColumn("phone")]
        public string phone { get; set; }

        [ExcelColumn("email")]
        public string email { get; set; }

        [ExcelColumn("birthday")]
        public string birthday { get; set; }

        [ExcelColumn("sex")]
        public string sex { get; set; }

        [ExcelColumn("address")]
        public string address { get; set; }

        [ExcelColumn("type")]
        public string type { get; set; }

        [ExcelColumn("nameoftype")]
        public string nameoftype { get; set; }

        [ExcelColumn("available")]
        public string available { get; set; }




    }
}
