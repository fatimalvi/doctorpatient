using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doctorpatient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // Program.previousForm.Add("form1", this);
        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.previousForm.ContainsKey("form1") == false)
            {
                Program.previousForm.Add("form1", this);
            }
            //Form frm1 = Program.previousForm["form1"];
            this.Hide();
            Form2 Form = new Form2();
            Form.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "a")
            {
                if (Program.previousForm.ContainsKey("form1") == false)
                {
                    Program.previousForm.Add("form1", this);
                }
                this.Hide();
                Form3 Formm = new Form3();
                Formm.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" &&  textBox3.Text == "admin")
            {
                
                
                    if (Program.previousForm.ContainsKey("form1") == false)
                    {
                        Program.previousForm.Add("form1", this);
                    }
                    
                this.Hide();
                Admin1 form = new Admin1();
                form.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
              
                if (Program.previousForm.ContainsKey("form1") == false)
                {
                    Program.previousForm.Add("form1", this);
                }
               
            
            if (textBox5.Text == "a" && textBox4.Text == "a")
            {
                this.Hide();
                doctorapp form = new doctorapp();
                form.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form20 f = new Form20();
            this.Hide();
            f.ShowDialog();
        }
    }
}
