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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           /* string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
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

            con.Close();*/
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e1)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e1)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.previousForm.ContainsKey("form2") == false)
            {
                Program.previousForm.Add("form2", this);
            }
            this.Hide();
            Form4 Form= new Form4();
            Form.ShowDialog();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm1 = Program.previousForm["form1"];
            this.Hide();
            frm1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
            //SqlConnection con = new SqlConnection(constring);
            //con.Open();
            // SqlCommand cmd = new SqlCommand("insert into PatientDetails
            // (FirstName, LastName, CNIC, Gender, MaritalStatus, PhoneNo, Email,Height, Weight)
            // values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "', '"
            // + groupBox1.Text + "' , '" + groupBox2.Text + "','" + textBox4.Text + "', '" +
            // textBox6.Text + comboBox1 + "', '" + textBox7.Text + "',  '" + textBox8.Text + "' )", con);
            //  cmd.ExecuteNonQuery();
            // Add Datetime   - 
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox2.Text == "" || textBox4.Text == ""
                || comboBox3.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "") 
            {
                MessageBox.Show("Please Fill out all the required information");
            }
            else
            {

                string constring = @"Server= DESKTOP-V7FIRL5\MSSQLSERVER01;Database=projectdb;Integrated security=true";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand sda = new SqlCommand("select BloodTypeID from BloodType where BloodType = '" + comboBox1.Text + "'", con);
                int id = Convert.ToInt32(sda.ExecuteScalar());
                SqlCommand cmd = new SqlCommand("Insert into PatientDetails (FirstName, LastName, DOB, CNIC, Gender, " +
                    "PhoneNo, Email, MaritalStatus, Referredby, Height, Weight, BloodTypeId) values " +
                    "(@FirstName, @LastName,@DOB, @CNIC, @Gender, @PhoneNo, @Email, @MaritalStatus, @Referredby, @Height, @Weight, @BloodTypeId)", con
                    );
                cmd.Parameters.Add(new SqlParameter("FirstName", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("LastName", textBox2.Text));
                cmd.Parameters.Add(new SqlParameter("DOB", dateTimePicker1.Value));
                cmd.Parameters.Add(new SqlParameter("CNIC", textBox3.Text));
                cmd.Parameters.Add(new SqlParameter("Gender", comboBox2.Text));
                cmd.Parameters.Add(new SqlParameter("PhoneNo", textBox4.Text));
                cmd.Parameters.Add(new SqlParameter("Email", textBox6.Text));
                cmd.Parameters.Add(new SqlParameter("MaritalStatus", comboBox3.Text));
                cmd.Parameters.Add(new SqlParameter("Referredby", textBox5.Text));
                cmd.Parameters.Add(new SqlParameter("Height", textBox7.Text));
                cmd.Parameters.Add(new SqlParameter("Weight", textBox8.Text));

               // cmd.ExecuteNonQuery();

               // MessageBox.Show("succes");
                //SqlCommand sda = new SqlCommand("select BloodTypeID from BloodType where BloodType = '" + comboBox1.Text + "'",con );
               // int id = Convert.ToInt32(sda.ExecuteScalar());
               // SqlCommand cmd1 = new SqlCommand("Insert into PatientDetails (BloodTypeId) values (@BloodTypeId)", con);
                cmd.Parameters.Add(new SqlParameter("BloodTypeID", id));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Proceed to Next Form");


                con.Close();
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
