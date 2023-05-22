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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();


            SqlCommand sda = new SqlCommand("Select DoctorID from Doctor where CNIC = '" + textBox2.Text + "'", con);
            int CNIC = Convert.ToInt32(sda.ExecuteScalar());

            SqlCommand cmd1 = new SqlCommand("Insert into Schedule (Day, Timings, DoctorID) values " +
                "(@Day, @Timings, @DoctorID)", con);

            if (radioButton3.Checked)
            {
               cmd1.Parameters.Add(new SqlParameter("Day", comboBox2.Text));
               cmd1.Parameters.Add(new SqlParameter("Timings", "8:00 AM - 9:00 AM"));
            }
            else if (radioButton4.Checked)
            {
                cmd1.Parameters.Add(new SqlParameter("Day", comboBox2.Text));
                cmd1.Parameters.Add(new SqlParameter("Timings", "10:00 AM - 11:00 AM"));
            }

   

            cmd1.Parameters.Add(new SqlParameter("DoctorID", CNIC));

            cmd1.ExecuteNonQuery();

            

            SqlCommand cmd2 = new SqlCommand("Insert into Schedule (Day, Timings, DoctorID) values " +
                "(@Day, @Timings, @DoctorID)", con);

   

            if (radioButton8.Checked)
            {
                cmd2.Parameters.Add(new SqlParameter("Day", comboBox3.Text));
                cmd2.Parameters.Add(new SqlParameter("Timings", "11:00 AM - 12:00 PM"));
            }
            else if (radioButton7.Checked)
            {
                cmd2.Parameters.Add(new SqlParameter("Day", comboBox3.Text));
                cmd2.Parameters.Add(new SqlParameter("Timings", "12:00 PM - 1:00 PM"));
            }

            cmd2.Parameters.Add(new SqlParameter("DoctorID", CNIC));

            cmd2.ExecuteNonQuery();




            MessageBox.Show("success");


            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand sda = new SqlCommand("select DepartmentId from Department where DepartmentName = '" + comboBox1.Text + "'", con);
            int id = Convert.ToInt32(sda.ExecuteScalar());
            SqlCommand cmd = new SqlCommand("Insert into Doctor (DoctorName, DepartmentId, CNIC) values " +
                "(@DoctorName, @DepartmentId, @CNIC)", con
                );
            cmd.Parameters.Add(new SqlParameter("DoctorName", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("DepartmentId", id));
            cmd.Parameters.Add(new SqlParameter("CNIC", textBox2.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Add Schedule");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm1 = Program.previousForm["form1"];
            this.Hide();
            frm1.ShowDialog();
        }
    }
}
