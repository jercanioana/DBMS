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

namespace Lab1_DBMS
{
    
    public partial class Form1 : Form
    {
        SqlConnection dbConn;
        SqlDataAdapter daNurse, daPatient;
        DataSet ds;
        SqlCommandBuilder cb;
        BindingSource bsNurse, bsPatient;

        DataTable patientTable;
        DataRow drCurrent;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            dbConn = new SqlConnection(@"Data Source = HP-IOANA\SQLEXPRESS; Initial Catalog = Clinic; Integrated Security = true");
            dbConn.Open();
            ds = new DataSet();
            daNurse = new SqlDataAdapter("SELECT * FROM Nurse", dbConn);
            daPatient = new SqlDataAdapter("SELECT * FROM Patient", dbConn);
            cb = new SqlCommandBuilder(daPatient);
            daNurse.Fill(ds, "Nurse");
            daPatient.Fill(ds, "Patient");
            DataRelation dr = new DataRelation("FK_Patient_Nurse", ds.Tables["Nurse"].Columns["NurseID"], ds.Tables["Patient"].Columns["NurseID"]) ;
            ds.Relations.Add(dr);
            
            bsNurse = new BindingSource();
            bsNurse.DataSource = ds;
            bsNurse.DataMember = "Nurse";
            bsPatient = new BindingSource();
            bsPatient.DataSource = bsNurse;
            bsPatient.DataMember = "FK_Patient_Nurse";
            dgvNurse.DataSource = bsNurse;
            dgvPatient.DataSource = bsPatient;
            
            

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteBox_TextChanged(object sender, EventArgs e)
        {
            int id;
            String ID = deleteBox.Text;
            Int32.TryParse(ID,out id);

            patientTable = ds.Tables["Patient"];
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = patientTable.Columns["PatientID"];
            patientTable.PrimaryKey = keyColumns;
            
            drCurrent = patientTable.Rows.Find(id);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            drCurrent.Delete();
            daPatient.Update(ds, "Patient");
            daNurse.Update(ds, "Nurse");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daNurse.Update(ds, "Nurse");
            daPatient.Update(ds, "Patient");
            

        }
    }
}
