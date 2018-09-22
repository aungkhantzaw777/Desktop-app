using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Forms;

namespace Csharp.model
{
    class DBcon
    {
        public string AppName = "Csharp";
        public string MessageTitle = "Csharp";

        public string dbServer = "student"; //".";
        public string dbUser = "sa"; //"";
        public string dbPassword = "kmdsysdba"; //"pr3c10us";
        public string dbName = ""; //"tempdb";

        public SqlConnectionStringBuilder c_ConnectionBuilder;
        public SqlConnection c_Connection;
        public SqlCommand c_Command;
        public SqlDataReader c_Reader;
        public SqlDataAdapter c_Adapter;

        public string s_string;
        public SqlConnection db_conn;
        public SqlDataAdapter db_adapt;
        public DataSet DTSet = new DataSet();
        public SqlCommand cmd;
        public int Affect;
        public SqlDataReader Reader;
        public DataTable _MtmpDT;

        readonly XmlTextReader xmlReader;
        public Boolean _tmp;
        public DataSet c_DataSet;
        public DataTable c_DataTable;
        public DataRow c_DataRow;
        public int c_RecordAffect;
        public int c_RecordCount;
        public string t_CurrentLogin;
        public string _LoginUserID = "000001";
        public string LoginPostID;

        public string c_string;
        public string LoginName;

        public string code;
        public int c_Quantity;
        public int r_Count;

        public int wizCount;

        //------For AppDefault.xml -----//
        public string user;
        public string password;

        string[] xmlstring = { "0", "1", "2", "3" };

        public Boolean LoadDbConnInfo()
        {
            try
            {
                //Dim dbInfo = XDocument.Load(Application.StartupPath & "\dbconnect.xml")
                using (XmlReader xmlReader = XmlReader.Create(Application.StartupPath + @"\dbconnect.xml"))
                {
                    xmlReader.Read();
                    xmlReader.ReadStartElement("dbinfo");
                    xmlReader.ReadStartElement("connection");

                    xmlReader.ReadStartElement("svname");
                    dbServer = xmlReader.ReadString();
                    xmlReader.ReadEndElement();
                    xmlReader.ReadStartElement("dbname");
                    dbName = xmlReader.ReadString();
                    xmlReader.ReadEndElement();
                    xmlReader.ReadStartElement("uid");
                    dbUser = xmlReader.ReadString();
                    xmlReader.ReadEndElement();
                    xmlReader.ReadStartElement("pwd");
                    dbPassword = xmlReader.ReadString();
                    xmlReader.ReadEndElement();

                    xmlReader.ReadEndElement();
                    xmlReader.ReadEndElement();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean LoadAppdefaultInfo()
        {
            try
            {
                //Dim dbInfo = XDocument.Load(Application.StartupPath & "\dbconnect.xml")
                using (XmlReader xmlReader = XmlReader.Create(Application.StartupPath + @"\appdefault.xml"))
                {
                    xmlReader.Read();
                    xmlReader.ReadStartElement("appinfo");
                    xmlReader.ReadStartElement("applogin");

                    xmlReader.ReadStartElement("uid");
                    user = xmlReader.ReadString();
                    xmlReader.ReadEndElement();

                    xmlReader.ReadStartElement("pwd");
                    password = xmlReader.ReadString();
                    xmlReader.ReadEndElement();

                    xmlReader.ReadEndElement();
                    xmlReader.ReadEndElement();
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void InitConnection()
        {
            if (LoadDbConnInfo())
            {
                //string tmpSQLString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\SC_POSKAGE.mdf;Integrated Security=True;User Instance=True";
                string tmpSQLString = String.Format("Persist Security info = true; User id = {0}; Password = {1}; Initial catalog = {2}; Data source = {3}", dbUser, dbPassword, dbName, dbServer);
                c_string = tmpSQLString;
                c_Connection = new SqlConnection(tmpSQLString);
            }
        }

        public void DatabaseConnection()
        {
            if (c_Connection == null)
            {
                InitConnection();
            }
            else
            {
                c_Connection.Close();
            }
        }

        public DataTable SelectData(String SPString)
        {
            DataTable DT = new DataTable();
            try
            {
                DatabaseConnection();
                SqlDataAdapter adpt = new SqlDataAdapter(SPString, c_Connection);
                adpt.Fill(DT);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                c_Connection.Close();
            }
            return DT;
        }
    }
}
