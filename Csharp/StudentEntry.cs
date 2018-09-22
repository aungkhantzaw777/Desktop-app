using Csharp.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp
{
    public partial class StudentEntry : Form
    {
        public StudentEntry()
        {
            InitializeComponent();
        }
        public int _StudentID = 0;
        public bool _IsEdit = false;


        clsStudent obj_student = new clsStudent();

        public void ShowEntry()
        {
            String SPString = string.Format("SP_Select_Student '{0}','{1}','{2}'",_StudentID,' ',2);

        }

        public void clear()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtType.Text = "";
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string type = txtType.Text.Trim();

            if ("" == name)
                MessageBox.Show("Please Enter Name");
            else if ("" == type)
                MessageBox.Show("Please Enter Type");
            else if ("" == address)
                MessageBox.Show("Please Enter Address");
            else
            {
                frmStudentDisplay frm = new frmStudentDisplay();
                obj_student.StudentID = _StudentID;
                obj_student.name = txtName.Text.ToString().Trim();
                obj_student.address = txtAddress.Text.ToString().Trim();
                obj_student.type = txtType.Text.ToString().Trim();
                if (_IsEdit == false)
                {
                    obj_student.action = 1;
                    obj_student.SaveData();
                    MessageBox.Show("successfully save!","success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    clear();
                    this.Close();
                    //frm.ShowData();
                    
                }
                else
                {
                    
                    obj_student.action = 2;
                    obj_student.SaveData();
                    MessageBox.Show("successfully edit!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    //frm.ShowData();
                }

                //MessageBox.Show("wait database will work later");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void StudentEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
