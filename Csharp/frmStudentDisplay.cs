using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using Csharp.model;

namespace Csharp
{
    public partial class frmStudentDisplay : Form
    {
        public frmStudentDisplay()
        {
            InitializeComponent();
        }
        DataTable DT = new DataTable();
        clsStudent obj_student = new clsStudent();
        String SPstring = "";
        DBcon obj_main = new DBcon();
        bool _isEdit = false;

        public void ShowData()
        {
            SPstring = string.Format("SP_Select_Student '{0}', '{1}', '{2}'", "0", "0", "1");
            dgvResult.DataSource = obj_main.SelectData(SPstring);

            dgvResult.Columns[0].Visible = false;
            dgvResult.Columns[1].Width = (dgvResult.Width / 100) * 50;
            dgvResult.Columns[2].Width = (dgvResult.Width / 100) * 20;
            dgvResult.Columns[3].Width = (dgvResult.Width / 100) * 40;
            dgvResult.Columns[4].Width = (dgvResult.Width / 100) * 50;
            //dgvResult.Columns[5].Width = (dgvResult.Width / 100) * 20;
            

        }

        private void frmStudentDisplay_Load(object sender, EventArgs e)
        {
            
            ShowData();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentEntry frm = new StudentEntry();
            frm.ShowDialog();
        }

        private void ShowEntry()
        {
            if (dgvResult.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Please Chose Data Entry", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StudentEntry frm = new StudentEntry();
                frm._StudentID = Convert.ToInt32(dgvResult.CurrentRow.Cells["StudentID"].Value.ToString());
                frm._IsEdit = true;
                frm.txtName.Text = dgvResult.CurrentRow.Cells["Name"].Value.ToString();
                frm.txtAddress.Text = dgvResult.CurrentRow.Cells["Address"].Value.ToString();
                frm.txtType.Text = dgvResult.CurrentRow.Cells["Type"].Value.ToString();
                frm.ShowDialog();
                //_StudentID = dgvResult.CurrentRow[0].value.tostring();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Please Choose Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                obj_student.StudentID = Convert.ToInt32(dgvResult.CurrentRow.Cells["StudentID"].Value.ToString());
                obj_student.name = dgvResult.CurrentRow.Cells["Name"].Value.ToString();
                obj_student.address = dgvResult.CurrentRow.Cells["Address"].Value.ToString();
                obj_student.type = dgvResult.CurrentRow.Cells["Type"].Value.ToString();
                obj_student.action = 3;
                obj_student.SaveData();
                MessageBox.Show("successfully Delete");
                //ShowData();
            }
        }
    }
}
