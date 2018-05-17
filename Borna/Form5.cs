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
    public partial class Form5 : Form
    {
        SqlCeConnection objConnection = new SqlCeConnection(DB_Base_Ce.ConStr);
        SqlCeDataAdapter objDataAdapter = new SqlCeDataAdapter();

        DataSet objDataSet = new DataSet();
        DB_Base_Ce Database = new DB_Base_Ce();
        U_Base u_set = new U_Base();

        public string tmpid_sel;
        public string karbord;

        public Form5()
        {
            InitializeComponent();
        }

        private void Frm_sel()
        {
            Database.Connection_Open();
            Database.Fill("SELECT tmpid_sandogh,P_peygiri FROM Peygiri WHERE (tmpid_sandogh = '" + tmpid_sel + "')", objDataSet, "Peygiri", true);
            Database.Connection_Close();

            DataGridTableStyle DataGridTableStyle1 = new DataGridTableStyle();
            DataGridTableStyle1.MappingName = "Peygiri";

            DataGridTextBoxColumn DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn1.HeaderText = "موارد پيگيری";
            DataGridTextBoxColumn1.MappingName = "P_peygiri";
            DataGridTextBoxColumn1.Width = 300;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn1);

            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(DataGridTableStyle1);
            dataGrid1.DataSource = objDataSet.Tables["Peygiri"];
        }

        private void btn_clic()
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نتيجه پيگيري را انتخاب نمایید");
                comboBox1.Focus();
                return;
            }

            button1.Enabled = false;

            SqlCeCommand objCommand = new SqlCeCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "INSERT INTO Peygiri (tmpid_sandogh,P_peygiri,uuser,udate,utime,uhard,serial,numbergroup) VALUES (@tmpid_sandogh,@P_peygiri,@uuser,@udate,@utime,@uhard,@serial,@numbergroup)";
            objCommand.CommandType = CommandType.Text;
            objCommand.Parameters.AddWithValue("@tmpid_sandogh", tmpid_sel);
            objCommand.Parameters.AddWithValue("@P_peygiri", comboBox1.Text);
            objCommand.Parameters.AddWithValue("@uuser", u_set.u_user());
            objCommand.Parameters.AddWithValue("@udate", u_set.u_date());
            objCommand.Parameters.AddWithValue("@utime", u_set.u_time());
            objCommand.Parameters.AddWithValue("@uhard", u_set.u_hard());
            objCommand.Parameters.AddWithValue("@serial", u_set.u_serial());
            objCommand.Parameters.AddWithValue("@numbergroup", u_set.u_numbergroup());

            objConnection.Open();
            objCommand.ExecuteNonQuery();
            objConnection.Close();

            SqlCeCommand objCommand1 = new SqlCeCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE sandogh SET [amal] = @amal WHERE (tmpid = '" + tmpid_sel + "')";
            objCommand1.CommandType = CommandType.Text;
            objCommand1.Parameters.AddWithValue("@amal", "مراجعه شد");

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            Frm_sel();

            button1.Enabled = true;
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_clic();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("پيگيري فوري");
            comboBox1.Items.Add("مرجوع");
            comboBox1.Items.Add("خالي");
            comboBox1.Items.Add("نبود");
            comboBox1.Items.Add("نقل مکان");
            comboBox1.Items.Add("بردند جايي");
            comboBox1.Items.Add("قبلا مرجوع شد");
            comboBox1.Items.Add("نشاني اشتباه");
            comboBox1.Items.Add("تحويل دادند");
            comboBox1.Items.Add("سرقتي");
            comboBox1.Items.Add("گمشده");
            comboBox1.Items.Add("انداختند دور");
            comboBox1.Items.Add("تخريب ساختمان");
            comboBox1.Items.Add("خارج از مسير");

            Frm_sel();
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_clic();
            }
        }
    }
}