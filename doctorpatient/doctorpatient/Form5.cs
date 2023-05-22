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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            comboBox1.Items.Clear();

            con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select DepartmentName From Department";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["DepartmentName"].ToString());
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Form frm1 = Program.previousForm["form1"];
            this.Hide();
            Form1 frm1 = new Form1();   
            frm1.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            comboBox1.Items.Clear();

            con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select DepartmentName From Department";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["DepartmentName"].ToString());
            }

            con.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            comboBox2.Items.Clear();

            con.Open();
            SqlCommand a = new SqlCommand("select Departmentid from Department where DepartmentName = '" + comboBox1.Text + "'", con);
            int id = Convert.ToInt32(a.ExecuteScalar());

            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select DoctorName From Doctor Where DepartmentId = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["DoctorName"].ToString());
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            comboBox3.Items.Clear();

            con.Open();
            SqlCommand a = new SqlCommand("select doctorid from doctor where doctorname = '" + comboBox2.Text + "'", con);
            int id = Convert.ToInt32(a.ExecuteScalar());

            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Day From Schedule Where Doctorid = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["Day"].ToString());
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            //comboBox2.Items.Clear();

            con.Open();

            SqlCommand command = new SqlCommand("Select Timings from Schedule where [Day] = '" + comboBox3.Text + "'" +
                "and doctorid in (select doctorid from doctor where doctorname = '" + comboBox2.Text + "') ", con);
            
            textBox1.Text = command.ExecuteScalar().ToString();


            if (comboBox3.Text == "Wednesday")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add(1);
                comboBox4.Items.Add(8);
                comboBox4.Items.Add(15);
                comboBox4.Items.Add(22);
                comboBox4.Items.Add(29);
            }
            else if (comboBox3.Text == "Thursday")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add(2);
                comboBox4.Items.Add(9);
                comboBox4.Items.Add(16);
                comboBox4.Items.Add(23);
                comboBox4.Items.Add(30);
            }
            else if (comboBox3.Text == "Friday")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add(3);
                comboBox4.Items.Add(10);
                comboBox4.Items.Add(17);
                comboBox4.Items.Add(24);
                comboBox4.Items.Add(31);
            }
            else if (comboBox3.Text == "Tuesday")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add(7);
                comboBox4.Items.Add(14);
                comboBox4.Items.Add(21);
                comboBox4.Items.Add(28);
                
            }
            else if (comboBox3.Text == "Monday")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add(6);
                comboBox4.Items.Add(13);
                comboBox4.Items.Add(20);
                comboBox4.Items.Add(27);
                
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);

            con.Open();

            string query1 = "Select PatientId from PatientDetails where CNIC = '" + textBox2.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            int id = Convert.ToInt32(cmd1.ExecuteScalar());
           
            SqlCommand doctor = new SqlCommand("Select DoctorId from Doctor where Doctorname = '" + comboBox2.Text + "'", con);

            int doctorid = Convert.ToInt32(doctor.ExecuteScalar());

            string query = "Insert into Appointment (PatientId, DoctorId, AppointmentDate, AppointmentTime)" +
                "values (@PatientId, @DoctorId, @AppointmentDate, @AppointmentTime)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.Add(new SqlParameter("PatientId", id));
            cmd.Parameters.Add(new SqlParameter("DoctorId", doctorid));
            cmd.Parameters.Add(new SqlParameter("AppointmentDate", comboBox4.Text));
            cmd.Parameters.Add(new SqlParameter("AppointmentTime", textBox1.Text));

            cmd.ExecuteNonQuery();

            string queryy = "Select Appointmentid from appointment " +
                "where doctorid = (Select DoctorId from Doctor where Doctorname = '" + comboBox2.Text + "') and " +
                "patientid = (Select PatientId from PatientDetails where CNIC = '" + textBox2.Text + "') ";
            SqlCommand cmdd = new SqlCommand(queryy, con);

            int idd = Convert.ToInt32(cmdd.ExecuteScalar());

            MessageBox.Show("Your AppointmentID is '" + idd + "' .Please Dont Forget it. ");
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
