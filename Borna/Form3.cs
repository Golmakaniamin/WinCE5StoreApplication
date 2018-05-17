using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Borna
{
    public partial class Form3 : Form
    {
        SqlCeConnection objConnection = new SqlCeConnection(DB_Base_Ce.ConStr);
        SqlCeDataAdapter objDataAdapter = new SqlCeDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base_Ce Database = new DB_Base_Ce();
        U_Base u_set = new U_Base();

        public string tmpid_sel;
        public string tmpid_Hard;

        public Form3()
        {
            InitializeComponent();
        }

        private void Frm_sel()
        {
            Database.Connection_Open();
            Database.Fill("SELECT id2,id4,name1,address1,tmpid,Tmpid_hard FROM Sandogh WHERE (tmpid = '" + tmpid_sel + "')", objDataSet, "Sel_Sandogh", true);
            Database.Connection_Close();

            if (objDataSet.Tables["Sel_Sandogh"].Rows.Count > 0)
            {
                label1.Text = objDataSet.Tables["Sel_Sandogh"].Rows[0]["id2"].ToString();
                label2.Text = objDataSet.Tables["Sel_Sandogh"].Rows[0]["id4"].ToString();
                label3.Text = objDataSet.Tables["Sel_Sandogh"].Rows[0]["name1"].ToString();
                textBox1.Text = objDataSet.Tables["Sel_Sandogh"].Rows[0]["address1"].ToString();
                tmpid_Hard = objDataSet.Tables["Sel_Sandogh"].Rows[0]["Tmpid_hard"].ToString();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Frm_sel();
        }

        private void btn_clic()
        {
            SqlCeCommand objCommand = new SqlCeCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE sandogh SET [amal] = @amal WHERE (tmpid = '" + tmpid_sel + "')";
            objCommand.CommandType = CommandType.Text;
            objCommand.Parameters.AddWithValue("@amal", "مراجعه شد");

            objConnection.Open();
            objCommand.ExecuteNonQuery();
            objConnection.Close();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn_clic();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.karbord = "1";
            f4.Text = tmpid_sel;
            f4.tmpid_sel = tmpid_sel;
            f4.sel_name = label3.Text;
            f4.sel_idsandogh = label2.Text;
            f4.Show();
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_clic();
            }
            if (e.KeyCode == Keys.F2)
            {
                Form4 f4 = new Form4();
                f4.karbord = "1";
                f4.Text = tmpid_sel;
                f4.tmpid_sel = tmpid_sel;
                f4.Show();
            }

            if (e.KeyCode == Keys.F3)
            {
                Form5 f5 = new Form5();
                f5.karbord = "1";
                f5.Text = tmpid_sel;
                f5.tmpid_sel = tmpid_sel;
                f5.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.karbord = "1";
            f5.Text = tmpid_sel;
            f5.tmpid_sel = tmpid_sel;
            f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT TOP (1)* FROM Sandogh WHERE (Tmpid_hard > '" + tmpid_Hard + "') ORDER BY Tmpid_hard ASC", objDataSet, "Sandogh", true);
            Database.Connection_Close();

            if (objDataSet.Tables["Sandogh"].Rows.Count > 0)
            {
                button1.Enabled = true;
                tmpid_sel = objDataSet.Tables["Sandogh"].Rows[0]["tmpid"].ToString();
                Frm_sel();
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT TOP (1)* FROM Sandogh WHERE (Tmpid_hard < '" + tmpid_Hard + "') ORDER BY Tmpid_hard DESC", objDataSet, "Sandogh", true);
            Database.Connection_Close();

            if (objDataSet.Tables["Sandogh"].Rows.Count > 0)
            {
                button3.Enabled = true;
                tmpid_sel = objDataSet.Tables["Sandogh"].Rows[0]["tmpid"].ToString();
                Frm_sel();
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}