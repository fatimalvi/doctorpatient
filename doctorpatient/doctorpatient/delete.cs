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
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            string query1 = "Delete from [Patient-Disability] where PatientID " +
                "in (Select PatientID from PatientDetails " +
                "where CNIC = '" + comboBox1.Text + "')";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader myreader;
            myreader = cmd1.ExecuteReader();
            myreader.Close();

            string newquery = "delete from Appointment where PatientId in (select patientid from PatientDetails where CNIC = '" + comboBox1.Text + "')";
            SqlCommand newe = new SqlCommand(newquery, con);    
            myreader = newe.ExecuteReader();
            myreader.Close();

            string query3 = "Delete from [Disease-Patient] where PatientID " +
                "in (Select PatientID from PatientDetails " +
                "where CNIC = '" + comboBox1.Text + "')";
            SqlCommand cmd2 = new SqlCommand(query3, con);

            myreader = cmd2.ExecuteReader();
            myreader.Close();


            string query4 = "Delete from [Patient-Allergy] where PatientID " +
                "in (Select PatientID from PatientDetails " +
                "where CNIC = '" + comboBox1.Text + "')";
            SqlCommand cmd3 = new SqlCommand(query4, con);

            myreader = cmd3.ExecuteReader();
            myreader.Close();

            string query = "Delete from PatientDetails where CNIC = '" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
         //   SqlDataReader myreader;
            myreader = cmd.ExecuteReader();
            MessageBox.Show("successfully data Deleted", "user information");
           

}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void delete_Load(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            comboBox1.Items.Clear();

            //con.Open();
            SqlCommand cmd1;
            cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select CNIC From PatientDetails";
            cmd1.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd1);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["CNIC"].ToString());
            }

           // string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
           // SqlConnection con = new SqlConnection(constring);

            comboBox2.Items.Clear();

            //con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select DepartmentName From Department";
            cmd.ExecuteNonQuery();
            DataTable dt1;

            dt1 = new DataTable();
            SqlDataAdapter sda1;

            sda1 = new SqlDataAdapter(cmd);

            sda1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                comboBox2.Items.Add(dr["DepartmentName"].ToString());
            }

            // con.Close();
            comboBox3.Items.Clear();

            //con.Open();
            SqlCommand cmd3;
            cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select BuildingName From Building";
            cmd3.ExecuteNonQuery();
            DataTable dt3;

            dt3 = new DataTable();
            SqlDataAdapter sda3;

            sda3 = new SqlDataAdapter(cmd3);

            sda3.Fill(dt3);

            foreach (DataRow dr in dt3.Rows)
            {
                comboBox3.Items.Add(dr["BuildingName"].ToString());
            }


            comboBox4.Items.Clear();

            //con.Open();
            SqlCommand cmd4;
            cmd4 = con.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "Select CNIC From Doctor";
            cmd4.ExecuteNonQuery();
            DataTable dt4;

            dt4 = new DataTable();
            SqlDataAdapter sda4;

            sda4 = new SqlDataAdapter(cmd4);

            sda4.Fill(dt4);

            foreach (DataRow dr in dt4.Rows)
            {
                comboBox4.Items.Add(dr["CNIC"].ToString());
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataReader myreader;

            string query5 = "Delete from Schedule where DoctorId in " +
                "(select doctorid from doctor where Departmentid in " +
                "(Select DepartmentId from Department where DepartmentName = '" + comboBox2.Text + "' ))";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            myreader = cmd5.ExecuteReader();
            myreader.Close();


        
            string query2 = "Delete from Doctor where DepartmentId in (Select DepartmentId from Department where DepartmentName = '" + comboBox2.Text + "')";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            myreader = cmd2.ExecuteReader();
            myreader.Close();

            string query1 = "Delete from Department where DepartmentName = '" + comboBox2.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query1, con);
           // SqlDataReader myreader;
            myreader = cmd1.ExecuteReader();
            myreader.Close();

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataReader myreader;

            string query5 = "Delete from Schedule where DoctorId in (select doctorid from doctor where" +
                "Departmentid in (Select DepartmentId from Department where BuildingId in " +
                "(Select buildingid from building where buildingname = '" + comboBox3.Text + "')))";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            myreader = cmd5.ExecuteReader();
            myreader.Close();

            string query2 = "Delete from Doctor where DepartmentId in " +
                "(Select DepartmentId from Department where BuildingId in " +
                "(Select buildingid from building where buildingname = '" + comboBox3.Text + "'))";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            myreader = cmd2.ExecuteReader();
            myreader.Close();

           
            string query3 = "Delete from Department where BuildingId in (Select BuildingId from Building where BuildingName = '" + comboBox3.Text + "')";
            SqlCommand cmd3 = new SqlCommand(query2, con);
            myreader = cmd3.ExecuteReader();
            myreader.Close();



            string query1 = "Delete from Building where BuildingName = '" + comboBox3.Text + "'";


            SqlCommand cmd1 = new SqlCommand(query1, con);
            // SqlDataReader myreader;
            myreader = cmd1.ExecuteReader();
            myreader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Form frm1 = Program.previousForm["form1"];
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //delete Appointment where doctorid = 8
            //delete Schedule where doctorid = 8
            //delete doctor where DoctorId = 8

            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataReader myreader;

            string query5 = "delete Appointment where doctorid = (select doctorID from doctor where CNIC = '" + comboBox4.Text + "' )";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            myreader = cmd5.ExecuteReader();
            myreader.Close();



            string query2 = "delete Schedule where doctorid =  (select doctorID from doctor where CNIC = '" + comboBox4.Text + "' )";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            myreader = cmd2.ExecuteReader();
            myreader.Close();

            string query1 = "Delete from doctor where CNIC = '" + comboBox4.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            // SqlDataReader myreader;
            myreader = cmd1.ExecuteReader();
            myreader.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Form frm1 = Program.previousForm["Admin1"];
            Admin1 frm1 = new Admin1();
  
            this.Hide();
            frm1.ShowDialog();
        }
    }
}
