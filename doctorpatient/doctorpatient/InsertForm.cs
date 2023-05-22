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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Allergy (AllergyType) values (@AllergyType)", con);
            cmd.Parameters.Add(new SqlParameter("AllergyType", textBox1.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("successs");
            con.Close();
           // cmd.ExecuteNonQuery();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Disabilities (DisabilityName) values (@DisabilityName)", con);
            cmd.Parameters.Add(new SqlParameter("DisabilityName", textBox2.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("success");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Diseases (DiseaseName) values (@DiseaseName)", con);
            cmd.Parameters.Add(new SqlParameter("DiseaseName", textBox3.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("success");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Building (BuildingName) values (@BuildingName)", con);
            cmd.Parameters.Add(new SqlParameter("BuildingName", textBox4.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("success");
           // con.Close();

           // string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            //SqlConnection con = new SqlConnection(constring);

            comboBox1.Items.Clear();

            //con.Open();
            SqlCommand cmd1;
            cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select BuildingName From Building";
            cmd1.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd1);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["BuildingName"].ToString());
            }

            con.Close();
        

    }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            comboBox1.Items.Clear();

            //con.Open();
            SqlCommand cmd1;
            cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select BuildingName From Building";
            cmd1.ExecuteNonQuery();
            DataTable dt;

            dt = new DataTable();
            SqlDataAdapter sda;

            sda = new SqlDataAdapter(cmd1);

            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["BuildingName"].ToString());
            }

            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand sda = new SqlCommand("select BuildingId from Building where BuildingName = '" + comboBox1.Text + "'", con);
            int id = Convert.ToInt32(sda.ExecuteScalar());
            SqlCommand cmd = new SqlCommand("Insert into Department (DepartmentName, BuildingId) values " +
                "(@DepartmentName, @BuildingId)", con
                );
            cmd.Parameters.Add(new SqlParameter("DepartmentName", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("BuildingId", id));
            

            cmd.ExecuteNonQuery();
            MessageBox.Show("Department inserted yay");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin1 frm1 = new Admin1();
            this.Hide();
            frm1.ShowDialog();
        }
    }
}
