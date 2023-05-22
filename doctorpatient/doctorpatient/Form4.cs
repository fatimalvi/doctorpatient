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
namespace doctorpatient
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            comboBox4.Items.Clear();

            con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select AllergyType From Allergy";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr["AllergyType"].ToString());
            }

            //New
            comboBox1.Items.Clear();

           // con.Open();
            SqlCommand cmd1;
            cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select DisabilityName From Disabilities";
            cmd1.ExecuteNonQuery();
            DataTable dt1;

            dt1 = new DataTable();
            SqlDataAdapter sda1;

            sda1 = new SqlDataAdapter(cmd1);

            sda1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["DisabilityName"].ToString());
            }

            //Disease

            comboBox2.Items.Clear();

            // con.Open();
            SqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select DiseaseName From Diseases";
            cmd2.ExecuteNonQuery();
            DataTable dt2;

            dt2 = new DataTable();
            SqlDataAdapter sda2;

            sda2 = new SqlDataAdapter(cmd2);

            sda2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {
                comboBox2.Items.Add(dr["DiseaseName"].ToString());
            }
            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

           // comboBox4.Items.Clear();

            con.Open();
            // richTextBox1.Text = comboBox4.Text;
            string CNIC = textBox1.Text;
            SqlCommand cmd = new SqlCommand("Select PatientID from PatientDetails where CNIC = '" +  CNIC + "'", con);
            int patientid = Convert.ToInt32(cmd.ExecuteScalar());

            SqlCommand cmd1 = new SqlCommand("Select AllergyID from Allergy where AllergyType = '" + comboBox4.Text + "'", con);

            int allergyid = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand("Insert into [Patient-Allergy] (PatientID, AllergyID) values (@PatientID, @AllergyID)", con);

            cmd2.Parameters.Add(new SqlParameter("PatientID", patientid));
            cmd2.Parameters.Add(new SqlParameter("AllergyID", allergyid));
            cmd2.ExecuteNonQuery();
            MessageBox.Show("If you would like to select another Allergy, change the Allergy and press confirm again");
            con.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            // comboBox4.Items.Clear();

            con.Open();
            // richTextBox1.Text = comboBox4.Text;
            string CNIC = textBox1.Text;
            SqlCommand cmd = new SqlCommand("Select PatientID from PatientDetails where CNIC = '" + CNIC + "'", con);
            int patientid = Convert.ToInt32(cmd.ExecuteScalar());

            SqlCommand cmd1 = new SqlCommand("Select DisabilityID from Disabilities where DisabilityName = '" + comboBox1.Text + "'", con);

            int allergyid = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand("Insert into [Patient-Disability] (PatientID, DisabilityId) values (@PatientID, @DisabilityId)", con);

            cmd2.Parameters.Add(new SqlParameter("PatientID", patientid));
            cmd2.Parameters.Add(new SqlParameter("DisabilityId", allergyid));
            cmd2.ExecuteNonQuery();
            MessageBox.Show("If you would like to select another Disability, change the Disability and press confirm again");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Select* from[Disease - Patient]
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            // comboBox4.Items.Clear();

            con.Open();
            // richTextBox1.Text = comboBox4.Text;
            string CNIC = textBox1.Text;
            SqlCommand cmd = new SqlCommand("Select PatientID from PatientDetails where CNIC = '" + CNIC + "'", con);
            int patientid = Convert.ToInt32(cmd.ExecuteScalar());

            SqlCommand cmd1 = new SqlCommand("Select DiseaseId from Diseases where DiseaseName = '" + comboBox2.Text + "'", con);

            int id = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand("Insert into [Disease-Patient] (PatientID, DiseaseId) values (@PatientID, @DiseaseId)", con);

            cmd2.Parameters.Add(new SqlParameter("PatientID", patientid));
            cmd2.Parameters.Add(new SqlParameter("DiseaseId", id));
            cmd2.ExecuteNonQuery();
            MessageBox.Show("If you would like to select another Disease, change the Disease and press confirm again");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 Form = new Form5();
            Form.ShowDialog();
        }
    }
}
