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
    public partial class Admin1 : Form
    {
        public Admin1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.previousForm.ContainsKey("Admin1") == false)
            {
                Program.previousForm.Add("Admin1", this);
            }
            this.Hide();
            delete form = new delete();
            form.ShowDialog();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.previousForm.ContainsKey("Admin1") == false)
            {
                Program.previousForm.Add("Admin1", this);
            }
            //Form frm1 = Program.previousForm["form1"];

            this.Hide();
            InsertForm form = new InsertForm(); 
            form.ShowDialog();  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.previousForm.ContainsKey("Admin1") == false)
            {
                Program.previousForm.Add("Admin1", this);
            }
            this.Hide();
            update form = new update();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           // Form frm1 = Program.previousForm["form1"];
           Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }
    }
}
