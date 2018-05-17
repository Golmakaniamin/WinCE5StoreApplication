using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
using System.Diagnostics;

namespace Borna
{
    public partial class Form4 : Form
    {
        SqlCeConnection objConnection = new SqlCeConnection(DB_Base_Ce.ConStr);
        SqlCeDataAdapter objDataAdapter = new SqlCeDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base_Ce Database = new DB_Base_Ce();
        U_Base u_set = new U_Base();

        public string tmpid_sel;
        public string karbord;

        public string sel_name;
        public string sel_idsandogh;

        public string sel_id_ghabz;

        public Form4()
        {
            InitializeComponent();
        }

        private void Frm_sel()
        {
            Database.Connection_Open();
            Database.Fill("SELECT tmpid_sandogh,money1,id_ghabz,sarfasl FROM ghabz WHERE (tmpid_sandogh = '" + tmpid_sel + "') Order by id_ghabz", objDataSet, "ghabz", true);
            Database.Connection_Close();

            DataGridTableStyle DataGridTableStyle1 = new DataGridTableStyle();
            DataGridTableStyle1.MappingName = "ghabz";

            DataGridTextBoxColumn DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn1.HeaderText = "شماره قبض";
            DataGridTextBoxColumn1.MappingName = "id_ghabz";
            DataGridTextBoxColumn1.Width = 100;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn1);

            DataGridTextBoxColumn DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn2.HeaderText = "مبلغ";
            DataGridTextBoxColumn2.MappingName = "money1";
            DataGridTextBoxColumn2.Width = 100;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn2);

            DataGridTextBoxColumn DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn3.HeaderText = "سرفصل";
            DataGridTextBoxColumn3.MappingName = "sarfasl";
            DataGridTextBoxColumn3.Width = 100;
            DataGridTableStyle1.GridColumnStyles.Add(DataGridTextBoxColumn3);

            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(DataGridTableStyle1);
            dataGrid1.DataSource = objDataSet.Tables["ghabz"];
        }

        private void btn_clic()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا مبلغ را وارد نماييد");
                textBox1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا سرفصل درآمد را انتخاب نمایید");
                comboBox1.Focus();
                return;
            }

            button1.Enabled = false;

            Database.Connection_Open();
            Database.Fill("SELECT * FROM ghabz", objDataSet, "All_ghabz", true);
            Database.Connection_Close();

            Database.Connection_Open();
            Database.Fill("SELECT * FROM info", objDataSet, "info", true);
            Database.Connection_Close();

            sel_id_ghabz = objDataSet.Tables["info"].Rows[0]["i_date"].ToString() + objDataSet.Tables["info"].Rows[0]["i_hard_code"].ToString() + (objDataSet.Tables["All_ghabz"].Rows.Count + 1).ToString().PadLeft(3, '0');

            SqlCeCommand objCommand = new SqlCeCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "INSERT INTO ghabz (tmpid_sandogh,money1,id_ghabz,uuser,udate,utime,uhard,serial,numbergroup,sarfasl) VALUES (@tmpid_sandogh,@money1,@id_ghabz,@uuser,@udate,@utime,@uhard,@serial,@numbergroup,@sarfasl)";
            objCommand.CommandType = CommandType.Text;
            objCommand.Parameters.AddWithValue("@tmpid_sandogh", tmpid_sel);
            objCommand.Parameters.AddWithValue("@money1",Convert.ToDouble(textBox1.Text));
            objCommand.Parameters.AddWithValue("@id_ghabz", sel_id_ghabz);
            objCommand.Parameters.AddWithValue("@uuser", u_set.u_user());
            objCommand.Parameters.AddWithValue("@udate", u_set.u_date());
            objCommand.Parameters.AddWithValue("@utime", u_set.u_time());
            objCommand.Parameters.AddWithValue("@uhard", u_set.u_hard());
            objCommand.Parameters.AddWithValue("@serial", u_set.u_serial());
            objCommand.Parameters.AddWithValue("@numbergroup", u_set.u_numbergroup());
            objCommand.Parameters.AddWithValue("@sarfasl", comboBox1.Text);

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

            btn_clic_print(sel_id_ghabz);
            btn_clic_peygiri(tmpid_sel);

            textBox1.Text = "";

            button1.Enabled = true;
            //this.Hide();
        }

        private void btn_clic_print(string id_ghabz_Prn)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM ghabz WHERE (id_ghabz = '" + id_ghabz_Prn + "')", objDataSet, "Sel_ghabz_Prn", true);
            Database.Connection_Close();

            //Sel_ghabz_Prn

            string[] installs = new string[7];
            installs[0] = u_set.u_date() + "-" + u_set.u_time() + ",";
            installs[1] = objDataSet.Tables["Sel_ghabz_Prn"].Rows[0]["id_ghabz"].ToString() + ",";
            installs[2] = objDataSet.Tables["Sel_ghabz_Prn"].Rows[0]["money1"].ToString() + ",";
            installs[3] = objDataSet.Tables["Sel_ghabz_Prn"].Rows[0]["sarfasl"].ToString() + ",";
            installs[4] = u_set.u_user() + ",";
            installs[5] = sel_idsandogh + ",";
            installs[6] = sel_name + ",";

            string path = DB_Base_Ce.Constr3 + "cp.txt";

            // Delete the file if it exists.
            if (!File.Exists(path))
                File.Delete(path);

            Encoding amin1 = Encoding.Default;

            FileStream fS = File.Create(path);
            BinaryWriter a = new BinaryWriter(fS, Encoding.Default);

            a.Seek(0, SeekOrigin.End);
            for (int q = 0; q <= 6; q++)
            {
                byte[] b = amin1.GetBytes(installs[q]);
                a.Write(b, 0, b.Length);

                a.Seek(0, SeekOrigin.End);
            }

            //refresh
            Frm_sel();

            //run
            ProcessStartInfo start_info = new ProcessStartInfo();
            start_info.FileName = DB_Base_Ce.Constr3 + @"Borna_Print\Borna_Print.exe";
            start_info.UseShellExecute = false;

            Process proc = new Process();
            proc.StartInfo = start_info;

            proc.Start();
        }

        private void btn_clic_peygiri(string index_idsandogh)
        {
            SqlCeCommand objCommand = new SqlCeCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "DELETE FROM Peygiri WHERE ((tmpid_sandogh = '" + index_idsandogh + "') AND ((P_peygiri = '" + "نبود" + "') OR (P_peygiri = '" + "" + "')))";
            objCommand.CommandType = CommandType.Text;

            objConnection.Open();
            objCommand.ExecuteNonQuery();
            objConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_clic();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("صدقات عام");
            comboBox1.Items.Add("حامي");
            comboBox1.Items.Add("صدقات سادات");
            comboBox1.Items.Add("فطريه");
            comboBox1.Items.Add("بيمه امام زمان");
            comboBox1.Items.Add("رد مظالم");
            comboBox1.Items.Add("نذورات");

            Frm_sel();
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_clic();
            }
        }
    }
}