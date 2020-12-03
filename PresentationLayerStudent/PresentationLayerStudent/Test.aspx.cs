using StudentBussinessLayer;
using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Wpf.Toolkit;

namespace PresentationLayerStudent
{
    public partial class Test : System.Web.UI.Page
    {
        private  StudentBussiness studentBussiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillList();
        }

        public void FillList()
        {
            ListBoxIspis.Items.Clear();
            this.studentBussiness = new StudentBussiness();
            List<Student> students = this.studentBussiness.GetAllStudents();
            foreach(Student s in students)
            {
                ListBoxIspis.Items.Add(s.Id + "." + s.Ime + "," + s.BrojIndeksa + "," + s.Ocena + "");
            }
        }

        protected void ButtonIspis_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Ime = TextBoxIme.Text;
            s.BrojIndeksa = TextBoxBrojIndexa.Text;
            s.Ocena = Convert.ToDecimal(TextBoxOcena.Text);

            bool result = this.studentBussiness.InsertStudent(s);

            if (result)
            {
                FillList();
                TextBoxIme.Text = " ";
                TextBoxBrojIndexa.Text = " ";
                TextBoxOcena.Text = " ";

            }
            else
            {
                
            }
        }
    }
}