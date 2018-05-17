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
    public partial class Form2 : Form
    {
        DataSet objDataSet = new DataSet();
        DB_Base_Ce Database = new DB_Base_Ce();
        U_Base u_set = new U_Base();

        int sel_row_dg = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void Frm_List(string idsandogh)
        {
            if (idsandogh == "")
            {
                Database.Connection_Open();
                Database.Fill("SELECT address1,amal,id3,id4,name1,tmpid FROM Sandogh Order by amal DESC,id2 ASC,id3 ASC", objDataSet, "Sandogh", true);
                Database.Connection_Close();
            }
            else
            {
                Database.Connection_Open();
                Database.Fill("SELECT address1,amal,id3,id4,name1,tmpid FROM Sandogh WHERE (id4 = '" + idsandogh + "') Order by amal DESC,id2 ASC,id3 ASC", objDataSet, "Sandogh", true);
                Database.Connection_Close();
            }
            
            DataGridTableStyle DataGridTableStyle1 = new DataGridTableStyle();
            DataGridTableStyle1.MappingName = "Sandogh";

            DataGridTextBoxColumn DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn4.HeaderText = "نشاني";
            DataGridTextBoxColumn4.MappingName = "address1";
            DataGridTextBoxColumn4.Width = 200;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn4);

            DataGridTextBoxColumn DataGridTextBoxColumn6 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn6.HeaderText = "نتيجه";
            DataGridTextBoxColumn6.MappingName = "amal";
            DataGridTextBoxColumn6.Width = 70;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn6);

            DataGridTextBoxColumn DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn1.HeaderText = "رديف";
            DataGridTextBoxColumn1.MappingName = "id3";
            DataGridTextBoxColumn1.Width = 50;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn1);

            DataGridTextBoxColumn DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn2.HeaderText = "شماره صندوق";
            DataGridTextBoxColumn2.MappingName = "id4";
            DataGridTextBoxColumn2.Width = 50;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn2);

            DataGridTextBoxColumn DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn3.HeaderText = "نام مشترک";
            DataGridTextBoxColumn3.MappingName = "name1";
            DataGridTextBoxColumn3.Width = 70;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn3);

            DataGridTextBoxColumn DataGridTextBoxColumn5 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn5.HeaderText = "کد سيستمي";
            DataGridTextBoxColumn5.MappingName = "tmpid";
            DataGridTextBoxColumn5.Width = 50;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn5);

            dataGrid1.PreferredRowHeight = 60;

            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(DataGridTableStyle1);
            dataGrid1.DataSource = objDataSet.Tables["Sandogh"];

            //dataGrid1.Select(sel_row_dg);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Frm_List("");
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            sel_row_dg = dataGrid1.CurrentRowIndex;
            f3.Text = "اطلاعات صندوق : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f3.tmpid_sel = dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f3.Show();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            Frm_List("");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Frm_List(textBox1.Text);

                //Form3 f3 = new Form3();
                //sel_row_dg = dataGrid1.CurrentRowIndex;
                //f3.Text = "اطلاعات صندوق : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
                //f3.tmpid_sel = textBox1.Text;
                //f3.Show();
                //textBox1.Text = "";
            }
        }

        private void dataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form3 f3 = new Form3();
                sel_row_dg = dataGrid1.CurrentRowIndex;
                f3.Text = "اطلاعات صندوق : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
                f3.tmpid_sel = dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
                f3.Show();
            }

            if (e.KeyCode == Keys.F2)
            {
                Form4 f4 = new Form4();
                sel_row_dg = dataGrid1.CurrentRowIndex;
                f4.karbord = "2";
                f4.Text = "ثبت قبض : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
                f4.tmpid_sel = dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
                f4.Show();
            }

            if (e.KeyCode == Keys.F3)
            {
                Form5 f5 = new Form5();
                sel_row_dg = dataGrid1.CurrentRowIndex;
                f5.karbord = "2";
                f5.Text = "ثبت پيگيری : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
                f5.tmpid_sel = dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
                f5.Show();
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            sel_row_dg = dataGrid1.CurrentRowIndex;
            f3.Text = "اطلاعات صندوق : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f3.tmpid_sel = dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f3.Show();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            sel_row_dg = dataGrid1.CurrentRowIndex;
            f4.karbord = "2";
            f4.Text = "ثبت قبض : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f4.tmpid_sel = dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f4.Show();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            sel_row_dg = dataGrid1.CurrentRowIndex;
            f5.karbord = "2";
            f5.Text = "ثبت پيگيری : " + dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f5.tmpid_sel = dataGrid1[dataGrid1.CurrentRowIndex, 5].ToString();
            f5.Show();
        }
    }
}