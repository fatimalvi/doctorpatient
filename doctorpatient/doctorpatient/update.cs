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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "PatientDetails")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("FirstName");
                comboBox2.Items.Add("LastName");
                comboBox2.Items.Add("DOB");
                comboBox2.Items.Add("CNIC");
                comboBox2.Items.Add("Gender");
                comboBox2.Items.Add("MaritalStatus");
                comboBox2.Items.Add("PhoneNo");
                comboBox2.Items.Add("Email");
                comboBox2.Items.Add("Height");
                comboBox2.Items.Add("Weight");
               // comboBox2.Items.Add("FirstName");
            }
            else if (comboBox1.Text == "Doctor"){

                comboBox2.Items.Clear();
                comboBox2.Items.Add("DoctorName");
                comboBox2.Items.Add("DepartmentId");
                comboBox2.Items.Add("CNIC");
            }
            else if (comboBox1.Text == "Schedule")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Day");
                comboBox2.Items.Add("Timings");
                comboBox2.Items.Add("DoctorID");
            }
            else if (comboBox1.Text == "Department")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("DepartmentName");
                comboBox2.Items.Add("BuildingId");
                
            }
            else if (comboBox1.Text == "Building")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("BuildingName");
                //comboBox2.Items.Add("DepartmentId");
                //comboBox2.Items.Add("CNIC");
            }
            else if (comboBox1.Text == "Disease")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("DiseaseName");
            }
            else if (comboBox1.Text == "Allergy")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("AllergyType");
            }
            else if (comboBox1.Text == "Disabilities")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("DisabilityName");
            }
            else if (comboBox1.Text == "Medicines")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("MedicineName");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                 




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         /*   comboBox3.Items.Clear();

            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlCommand cmd1;
            cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
string a = comboBox1.Text;
            a.Replace("'", "");
            string b = comboBox2.Text;
            b.Replace("'", "");
            cmd1.CommandText = "Select '" + comboBox2.Text + "' From '" + comboBox1.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1;

            dt1 = new DataTable();
            SqlDataAdapter sda1;

            sda1 = new SqlDataAdapter(cmd1);

            sda1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                comboBox3.Items.Add(dr[comboBox2.Text].ToString());
            }*/
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            comboBox3.Items.Clear();

            con.Open();
          //  SqlCommand a = new SqlCommand("select '" + comboBox2.Text + "' from '" + comboBox1.Text + "'", con);
          //  int id = Convert.ToInt32(a.ExecuteScalar());

            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select " + comboBox2.Text + " from " + comboBox1.Text;
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr[comboBox2.Text].ToString());
            }

            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            update frm = new update();
            frm.ShowDialog();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // update PatientDetails set FirstName = 'Bee' where FirstName = 'a'
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            string query = "update " + comboBox1.Text + " set " + comboBox2.Text + " = '" + textBox1.Text + "' where " + comboBox2.Text + " = '" + comboBox3.Text + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Form frm1 = Program.previousForm["Admin1"];
            Admin1 frm1 = new Admin1();
           // this.Hide();
            //rm1.ShowDialog();
            this.Hide();
            frm1.ShowDialog();
        }
    }
}
