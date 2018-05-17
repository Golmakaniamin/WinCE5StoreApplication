using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Borna
{
    public partial class Form1 : Form
    {
        U_Base u_set = new U_Base();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Form2 f1 = new Form2();
            f1.Show();
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            Form6 f1 = new Form6();
            f1.textBox1.Text = u_set.u_date();
            f1.Show();
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Form7 f1 = new Form7();
            f1.Text = "مشخصات دستگاه";
            f1.Show();
            button2.Enabled = true;
        }
    }
}