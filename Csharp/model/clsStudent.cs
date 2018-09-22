using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Csharp.model
{
    class clsStudent
    {
        DBcon conn = new DBcon();

        public int StudentID { set; get; }
        public string name { set; get; }
        public string address { set; get; }
        public string type { set; get; }
        public int action { set; get; }

        public bool SaveData()
        {
            bool SaveData = false;
            conn.s_string = "SP_Insert_Process";
            conn.DatabaseConnection();
            conn.c_Command = new SqlCommand(conn.s_string, conn.c_Connection);
            conn.c_Command.CommandType = CommandType.StoredProcedure;
            conn.c_Command.Parameters.AddWithValue("@StudentID", StudentID);
            conn.c_Command.Parameters.AddWithValue("@Name", name);
            conn.c_Command.Parameters.AddWithValue("@Address", address);
            conn.c_Command.Parameters.AddWithValue("@Type", type);
            conn.c_Command.Parameters.AddWithValue("@action", action);

            try
            {
                if (conn.c_Connection.State == ConnectionState.Open) conn.c_Connection.Close();
                conn.c_Connection.Open();

                conn.c_RecordAffect = conn.c_Command.ExecuteNonQuery();
                if (conn.c_RecordAffect >= 0)
                {
                    SaveData = true;
                }
                else
                {
                    SaveData = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.c_Connection.Close();
            }
            return SaveData;
        }


       /*public void CreateGridViewDetail(ref DataGridView _DGView, string SPName)
        {
            try
            {
                _DGView.Rows.Clear();
                SqlDataAdapter DA_Grid = new SqlDataAdapter();
                DataSet DS_Grid = new DataSet();

                conn.DatabaseConnection();
                DA_Grid = new SqlDataAdapter(SPName, conn.c_Connection);
                DA_Grid.Fill(DS_Grid, "Student");

                for (int i = 0; i <= DS_Grid.Tables[0].Rows.Count - 1; i++)
                {
                    _DGView.Rows.Add();
                    _DGView.Rows[i].Cells[0].Value = DS_Grid.Tables[0].Rows[i]["StudentID"].ToString();
                    _DGView.Rows[i].Cells["Name"].Value = Convert.ToBoolean(DS_Grid.Tables[0].Rows[i]["Name"]);
                    
                    _DGView.Rows[i].Cells["Item"].Value = DS_Grid.Tables[0].Rows[i]["ItemName"].ToString();
                    _DGView.Rows[i].Cells["Code"].Value = DS_Grid.Tables[0].Rows[i]["ItemCode"].ToString();

                    _DGView.Rows[i].Cells["PurchasePrice"].Value = Convert.ToDouble(DS_Grid.Tables[0].Rows[i]["PurchasePrice"]).ToString("0.00");
                    _DGView.Rows[i].Cells["SalePrice"].Value = Convert.ToDouble(DS_Grid.Tables[0].Rows[i]["SalePrice"]).ToString("0.00");

                    _DGView.Rows[i].Cells["Discount"].Value = Convert.ToDouble(DS_Grid.Tables[0].Rows[i]["Discount"]).ToString("0.00");
                    _DGView.Rows[i].Cells["Amount"].Value = Convert.ToDouble(DS_Grid.Tables[0].Rows[i]["LineTotal"]).ToString("0.00");
                    _DGView.Rows[i].Cells["itemid"].Value = DS_Grid.Tables[0].Rows[i]["ItemID"].ToString();
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Exception Error");
            }
        }
        */
    }
}
