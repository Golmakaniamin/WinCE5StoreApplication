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

namespace Borna
{
    public partial class Form7 : Form
    {
        SqlCeConnection objConnection = new SqlCeConnection(DB_Base_Ce.ConStr);
        SqlCeDataAdapter objDataAdapter = new SqlCeDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base_Ce Database = new DB_Base_Ce();
        U_Base u_set = new U_Base();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label2.Text = u_set.u_hard();
            label3.Text = u_set.u_user();
            label5.Text = u_set.u_date();

            Database.Connection_Open();
            Database.Fill("SELECT Count(Tmpid_hard) AS C_Tmpid_hard FROM Sandogh", objDataSet, "Sandogh", true);
            Database.Connection_Close();

            label13.Text = objDataSet.Tables["Sandogh"].Rows[0]["C_Tmpid_hard"].ToString();

            Database.Connection_Open();
            Database.Fill("SELECT Count(Tmpid_hard) AS C_Tmpid_hard, Sum(money1) AS S_money1 FROM ghabz", objDataSet, "ghabz", true);
            Database.Connection_Close();

            label7.Text = objDataSet.Tables["ghabz"].Rows[0]["C_Tmpid_hard"].ToString();
            label11.Text = objDataSet.Tables["ghabz"].Rows[0]["S_money1"].ToString();

            Database.Connection_Open();
            Database.Fill("SELECT Count(Tmpid_hard) AS C_Tmpid_hard FROM Peygiri", objDataSet, "Peygiri", true);
            Database.Connection_Close();

            label9.Text = objDataSet.Tables["Peygiri"].Rows[0]["C_Tmpid_hard"].ToString();
        }
    }
}