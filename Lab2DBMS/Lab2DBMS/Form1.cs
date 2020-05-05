using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab2DBMS
{

    public partial class Form1 : Form
    {
        SqlConnection dbConn;
        SqlDataAdapter daParent, daChild;
        DataSet ds;
        SqlCommandBuilder cb;
        BindingSource bsParent, bsChild;
        
        String selectStmtParent;
        String parentTable;
        String childTable;
        String PKParent;
        String PKChild;
        String selectStmtChild;
        String FKName;
        String dataSource;
        public Form1()
        {
            
            InitializeComponent();
            InitializeParametersForScenario1();
        }
        private void InitializeParametersForScenario1()
        {

            selectStmtParent = ConfigurationSettings.AppSettings["select1"];
            
            parentTable = ConfigurationSettings.AppSettings["parentTable"];
            
            childTable = ConfigurationSettings.AppSettings["childTable"];
            
            PKParent = ConfigurationSettings.AppSettings["PKParent"];
           
            PKChild = ConfigurationSettings.AppSettings["PKChild"];
            
            selectStmtChild = ConfigurationSettings.AppSettings["select2"];

            FKName = ConfigurationSettings.AppSettings["FKName"];
            dataSource = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;



        }
        private void InitializeParametersForScenario2()
        {

            selectStmtParent = ConfigurationSettings.AppSettings["select3"];

            parentTable = ConfigurationSettings.AppSettings["parentTable2"];

            childTable = ConfigurationSettings.AppSettings["childTable2"];

            PKParent = ConfigurationSettings.AppSettings["PKParent2"];

            PKChild = ConfigurationSettings.AppSettings["PKChild2"];

            selectStmtChild = ConfigurationSettings.AppSettings["select4"];

            FKName = ConfigurationSettings.AppSettings["FKName2"];
            
            dataSource = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;


        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            
            

            dbConn = new SqlConnection(dataSource);
            dbConn.Open();
            ds = new DataSet();

            daParent = new SqlDataAdapter(selectStmtParent, dbConn);
           
            daChild = new SqlDataAdapter(selectStmtChild, dbConn);
            cb = new SqlCommandBuilder(daChild);
            daParent.Fill(ds, parentTable);
            daChild.Fill(ds, childTable);

            DataRelation dr = new DataRelation(FKName, ds.Tables[parentTable].Columns[PKParent], ds.Tables[childTable].Columns[PKParent]);
            ds.Relations.Add(dr);
            bsParent = new BindingSource();
            bsParent.DataSource = ds;
            bsParent.DataMember = parentTable;
            bsChild = new BindingSource();
            bsChild.DataSource = bsParent;
            bsChild.DataMember = FKName;
            dgvParent.DataSource = bsParent;
            dgvChild.DataSource = bsChild;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            daParent.Update(ds, parentTable);
            daChild.Update(ds, childTable);

        }

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                InitializeParametersForScenario1();
                Form1_Load_1(sender, e);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                InitializeParametersForScenario2();
                Form1_Load_1(sender, e);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConn.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
