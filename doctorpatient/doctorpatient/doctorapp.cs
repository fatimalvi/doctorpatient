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
    public partial class doctorapp : Form
    {
        public doctorapp()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "Select patientId from appointment";
            SqlCommand cmd = new SqlCommand(query, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "select doctorId where CNIC = '" +textBox1.Text+ "'";

            SqlCommand command = new SqlCommand(query, con);
            int id = Convert.ToInt32(command.ExecuteScalar());  

            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select AppointmentId from Appointment where doctorid = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["AppointmentId"].ToString());
            }

            con.Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "select doctorId from Doctor where CNIC = '" + textBox1.Text + "'";

            SqlCommand command = new SqlCommand(query, con);
            int id = Convert.ToInt32(command.ExecuteScalar());

            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select AppointmentId from Appointment where doctorid = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["AppointmentId"].ToString());
            }

            con.Close();
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "select patientid from appointment where appointmentid = '" + comboBox1.Text + "'";

            SqlCommand command = new SqlCommand(query, con);
            int id = Convert.ToInt32(command.ExecuteScalar());
            richTextBox1.Clear();   
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from PatientDetails where patientid = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);
            
            foreach (DataColumn dr in dt.Columns)
            {
                //comboBox1.Items.Add(dr["AppointmentId"].ToString());
                //foreach (DataRow dc in dt.Rows){
                //  if (dr == '')
                //  {

                //  }
                if (dr.ToString() == "BloodTypeId")
                {
                    string querynew = "Select BloodType from BloodType where Bloodtypeid = '" + int.Parse(dt.Rows[0][dr].ToString()) + "'";
                    SqlCommand cmdnew = new SqlCommand(querynew, con);
                   // cmdnew.ExecuteNonQuery();
                    richTextBox1.AppendText("Blood Type");
                    richTextBox1.AppendText(": ");
                    richTextBox1.AppendText(cmdnew.ExecuteScalar().ToString());
                    richTextBox1.AppendText("\r");
                    // cmd.ExecuteScalar

                }
                else { 
                    richTextBox1.AppendText(dr.ToString());
                    richTextBox1.AppendText(": ");
                    richTextBox1.AppendText(dt.Rows[0][dr].ToString());
                    richTextBox1.AppendText("\r");
                 }
                // richTextBox1.AppendText(dr.ToString());
            }

            SqlCommand cmd1;
            cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select AllergyType from Allergy where allergyid in (select allergyid from [Patient-Allergy] where patientid = '" + id + "')";
            cmd1.ExecuteNonQuery();
            DataTable dt1;

            dt1 = new DataTable();
            SqlDataAdapter sda1;

            sda1 = new SqlDataAdapter(cmd1);

            sda1.Fill(dt1);
            richTextBox1.AppendText("Allergy: ");
            foreach (DataRow dr in dt1.Rows)
            {
                //comboBox1.Items.Add(dr["AppointmentId"].ToString());
                //foreach (DataRow dc in dt.Rows){
                
                richTextBox1.AppendText(dr["AllergyType"].ToString());
                richTextBox1.AppendText(" ");
                richTextBox1.AppendText("\r");
                // }
                // richTextBox1.AppendText(dr.ToString());
            }
            SqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select DiseaseName from Diseases where Diseaseid in (select Diseaseid from [Disease-Patient] where patientid = '" + id + "')";
            cmd2.ExecuteNonQuery();
            DataTable dt2;

            dt2 = new DataTable();
            SqlDataAdapter sda2;

            sda2 = new SqlDataAdapter(cmd2);

            sda2.Fill(dt2);
            richTextBox1.AppendText("Disease: ");
            foreach (DataRow dr in dt2.Rows)
            {
                //comboBox1.Items.Add(dr["AppointmentId"].ToString());
                //foreach (DataRow dc in dt.Rows){

                richTextBox1.AppendText(dr["DiseaseName"].ToString());
                richTextBox1.AppendText(" ");
                // }
                // richTextBox1.AppendText(dr.ToString());
            }
            richTextBox1.AppendText("\r");
            richTextBox1.AppendText("DIsability: ");
            SqlCommand cmd3;
            cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select DisabilityName from Disabilities where Disabilityid in (select DisabilityId from [Patient-Disability] where patientid = '" + id + "')";
            cmd3.ExecuteNonQuery();
            DataTable dt3;

            dt3 = new DataTable();
            SqlDataAdapter sda3;

            sda3 = new SqlDataAdapter(cmd3);

            sda3.Fill(dt3);

            foreach (DataRow dr in dt3.Rows)
            {
                //comboBox1.Items.Add(dr["AppointmentId"].ToString());
                //foreach (DataRow dc in dt.Rows){

                richTextBox1.AppendText(dr["DisabilityName"].ToString());
                richTextBox1.AppendText(" ");
                // }
                // richTextBox1.AppendText(dr.ToString());
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm1 = Program.previousForm["form1"];
            this.Hide();
            frm1.ShowDialog();
        }
    }
}
