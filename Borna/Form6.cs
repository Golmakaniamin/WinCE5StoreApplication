using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.IO;

namespace Borna
{
    public partial class Form6 : Form
    {
        DB_Base_Ce DatabaseCe = new DB_Base_Ce();
        DB_Base_Sc DatabaseSc = new DB_Base_Sc();

        U_Base u_set = new U_Base();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private bool Send_Data_To_Server()
        {
            SqlCeConnection objConnectionce = new SqlCeConnection(DB_Base_Ce.ConStr);
            SqlCeDataAdapter objDataAdapterce = new SqlCeDataAdapter();
            DataSet objDataSetce = new DataSet();

            SqlConnection objConnectionsc = new SqlConnection(DB_Base_Sc.ConStr);
            SqlDataAdapter objDataAdaptersc = new SqlDataAdapter();
            DataSet objDataSetsc = new DataSet();

            DatabaseCe.Connection_Open();
            DatabaseCe.Fill("SELECT * FROM Info", objDataSetce, "Info", true);
            DatabaseCe.Connection_Close();

            DatabaseCe.Connection_Open();
            DatabaseCe.Fill("SELECT * FROM ghabz", objDataSetce, "ghabz", true);
            DatabaseCe.Connection_Close();

            if (objDataSetce.Tables["ghabz"].Rows.Count > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = objDataSetce.Tables["ghabz"].Rows.Count;

                for (int q = 0; q < objDataSetce.Tables["ghabz"].Rows.Count; q++)
                {
                    //Add To Server
                    SqlCommand objCommand1 = new SqlCommand();
                    objCommand1.Connection = objConnectionsc;
                    objCommand1.CommandText = "INSERT INTO Ghabz (tmpid_sandogh,money1,id_ghabz,uuser,udate,utime,uhard,serial,numbergroup,sarfasl) VALUES (@tmpid_sandogh,@money1,@id_ghabz,@uuser,@udate,@utime,@uhard,@serial,@numbergroup,@sarfasl)";
                    objCommand1.CommandType = CommandType.Text;
                    objCommand1.Parameters.AddWithValue("@tmpid_sandogh", objDataSetce.Tables["ghabz"].Rows[q]["tmpid_sandogh"].ToString());
                    objCommand1.Parameters.AddWithValue("@money1", objDataSetce.Tables["ghabz"].Rows[q]["money1"].ToString());
                    objCommand1.Parameters.AddWithValue("@id_ghabz", objDataSetce.Tables["ghabz"].Rows[q]["id_ghabz"].ToString());
                    objCommand1.Parameters.AddWithValue("@uuser", objDataSetce.Tables["ghabz"].Rows[q]["uuser"].ToString());
                    objCommand1.Parameters.AddWithValue("@udate", objDataSetce.Tables["ghabz"].Rows[q]["udate"].ToString());
                    objCommand1.Parameters.AddWithValue("@utime", objDataSetce.Tables["ghabz"].Rows[q]["utime"].ToString());
                    objCommand1.Parameters.AddWithValue("@uhard", objDataSetce.Tables["ghabz"].Rows[q]["uhard"].ToString());
                    objCommand1.Parameters.AddWithValue("@serial", objDataSetce.Tables["ghabz"].Rows[q]["serial"].ToString());
                    objCommand1.Parameters.AddWithValue("@numbergroup", objDataSetce.Tables["ghabz"].Rows[q]["numbergroup"].ToString());
                    objCommand1.Parameters.AddWithValue("@sarfasl", objDataSetce.Tables["ghabz"].Rows[q]["sarfasl"].ToString());

                    try
                    {
                        objConnectionsc.Open();
                        objCommand1.ExecuteNonQuery();
                        objConnectionsc.Close();

                        label3.Text = "OK";
                    }
                    catch (SqlException SqlExceptionErr)
                    {
                        label3.Text = SqlExceptionErr.Message;
                        return (false);
                    }

                    //Delete From Device
                    if (label3.Text == "OK")
                    {
                        SqlCeCommand objCommand2 = new SqlCeCommand();
                        objCommand2.Connection = objConnectionce;
                        objCommand2.CommandText = "DELETE FROM ghabz WHERE (Tmpid_hard = '" + objDataSetce.Tables["ghabz"].Rows[q]["Tmpid_hard"].ToString() + "')";
                        objCommand2.CommandType = CommandType.Text;

                        objConnectionce.Open();
                        objCommand2.ExecuteNonQuery();
                        objConnectionce.Close();
                    }
                    progressBar1.Value++;
                }
            }

            DatabaseCe.Connection_Open();
            DatabaseCe.Fill("SELECT * FROM Peygiri", objDataSetce, "Peygiri", true);
            DatabaseCe.Connection_Close();

            if (objDataSetce.Tables["Peygiri"].Rows.Count > 0)
            {
                progressBar2.Minimum = 0;
                progressBar2.Value = 0;
                progressBar2.Maximum = objDataSetce.Tables["Peygiri"].Rows.Count;

                for (int q = 0; q < objDataSetce.Tables["Peygiri"].Rows.Count; q++)
                {
                    //Add To Server
                    SqlCommand objCommand1 = new SqlCommand();
                    objCommand1.Connection = objConnectionsc;
                    objCommand1.CommandText = "INSERT INTO Peygiri (tmpid_sandogh,T_peygiri,uuser,udate,utime,uhard,serial,numbergroup) VALUES (@tmpid_sandogh,@T_peygiri,@uuser,@udate,@utime,@uhard,@serial,@numbergroup)";
                    objCommand1.CommandType = CommandType.Text;
                    objCommand1.Parameters.AddWithValue("@tmpid_sandogh", objDataSetce.Tables["Peygiri"].Rows[q]["tmpid_sandogh"].ToString());
                    objCommand1.Parameters.AddWithValue("@T_peygiri", objDataSetce.Tables["Peygiri"].Rows[q]["P_peygiri"].ToString());
                    objCommand1.Parameters.AddWithValue("@uuser", objDataSetce.Tables["Peygiri"].Rows[q]["uuser"].ToString());
                    objCommand1.Parameters.AddWithValue("@udate", objDataSetce.Tables["Peygiri"].Rows[q]["udate"].ToString());
                    objCommand1.Parameters.AddWithValue("@utime", objDataSetce.Tables["Peygiri"].Rows[q]["utime"].ToString());
                    objCommand1.Parameters.AddWithValue("@uhard", objDataSetce.Tables["Peygiri"].Rows[q]["uhard"].ToString());
                    objCommand1.Parameters.AddWithValue("@serial", objDataSetce.Tables["Peygiri"].Rows[q]["serial"].ToString());
                    objCommand1.Parameters.AddWithValue("@numbergroup", objDataSetce.Tables["Peygiri"].Rows[q]["numbergroup"].ToString());

                    try
                    {
                        objConnectionsc.Open();
                        objCommand1.ExecuteNonQuery();
                        objConnectionsc.Close();

                        label3.Text = "OK";
                    }
                    catch (SqlException SqlExceptionErr)
                    {
                        label3.Text = SqlExceptionErr.Message;
                        return (false);
                    }

                    //Delete From Device
                    if (label3.Text == "OK")
                    {
                        SqlCeCommand objCommand2 = new SqlCeCommand();
                        objCommand2.Connection = objConnectionce;
                        objCommand2.CommandText = "DELETE FROM Peygiri WHERE (Tmpid_hard = '" + objDataSetce.Tables["Peygiri"].Rows[q]["Tmpid_hard"].ToString() + "')";
                        objCommand2.CommandType = CommandType.Text;

                        objConnectionce.Open();
                        objCommand2.ExecuteNonQuery();
                        objConnectionce.Close();
                    }
                    progressBar2.Value++;
                }
            }

            label3.Text = "موفق";
            return (true);
        }

        private void Recive_Data_From_Server()
        {
            SqlCeConnection objConnectionce = new SqlCeConnection(DB_Base_Ce.ConStr);
            SqlCeDataAdapter objDataAdapterce = new SqlCeDataAdapter();
            DataSet objDataSetce = new DataSet();

            SqlConnection objConnectionsc = new SqlConnection(DB_Base_Sc.ConStr);
            SqlDataAdapter objDataAdaptersc = new SqlDataAdapter();
            DataSet objDataSetsc = new DataSet();

            string dv_name = System.Net.Dns.GetHostName().Substring(9, 2);

            DatabaseCe.Connection_Open();
            DatabaseCe.Fill("SELECT * FROM Info", objDataSetce, "Info", true);
            DatabaseCe.Connection_Close();

            if (objDataSetce.Tables["Info"].Rows.Count > 0)
            {
                SqlCeCommand objCommand1 = new SqlCeCommand();
                objCommand1.Connection = objConnectionce;
                objCommand1.CommandText = "UPDATE Info SET [i_hard_code]='" + dv_name + "'";
                objCommand1.CommandType = CommandType.Text;

                objConnectionce.Open();
                objCommand1.ExecuteNonQuery();
                objConnectionce.Close();
            }

            DatabaseSc.Connection_Open();
            DatabaseSc.Fill("SELECT * FROM H_ezam WHERE ((tmpid_hard = '" + objDataSetce.Tables["Info"].Rows[0]["i_hard_code"].ToString() + "') AND (edate_sh = '" + textBox1.Text + "'))", objDataSetsc, "H_ezam", true);
            DatabaseSc.Connection_Close();

            if (objDataSetsc.Tables["H_ezam"].Rows.Count > 0)
            {
                //Delete From Device
                if (label3.Text == "موفق")
                {
                    SqlCeCommand objCommand1 = new SqlCeCommand();
                    objCommand1.Connection = objConnectionce;
                    objCommand1.CommandText = "DELETE FROM Sandogh";
                    objCommand1.CommandType = CommandType.Text;

                    objConnectionce.Open();
                    objCommand1.ExecuteNonQuery();
                    objConnectionce.Close();

                    SqlCeCommand objCommand2 = new SqlCeCommand();
                    objCommand2.Connection = objConnectionce;
                    objCommand2.CommandText = "DELETE FROM ghabz";
                    objCommand2.CommandType = CommandType.Text;

                    objConnectionce.Open();
                    objCommand2.ExecuteNonQuery();
                    objConnectionce.Close();

                    SqlCeCommand objCommand3 = new SqlCeCommand();
                    objCommand3.Connection = objConnectionce;
                    objCommand3.CommandText = "DELETE FROM Peygiri";
                    objCommand3.CommandType = CommandType.Text;

                    objConnectionce.Open();
                    objCommand3.ExecuteNonQuery();
                    objConnectionce.Close();
                }

                DatabaseSc.Connection_Open();
                DatabaseSc.Fill("SELECT * FROM H_Personel WHERE (tmpid = '" + objDataSetsc.Tables["H_ezam"].Rows[0]["tmpid_personel"].ToString() + "')", objDataSetsc, "H_Personel", true);
                DatabaseSc.Connection_Close();

                if (objDataSetsc.Tables["H_Personel"].Rows.Count > 0)
                {
                    //u_set.u_date().Substring(0, 4) + u_set.u_date().Substring(5, 2) + u_set.u_date().Substring(8, 2)
                    SqlCeCommand objCommand5 = new SqlCeCommand();
                    objCommand5.Connection = objConnectionce;
                    objCommand5.CommandText = "UPDATE Info SET [i_date]='" + textBox1.Text.Substring(0, 4) + textBox1.Text.Substring(5, 2) + textBox1.Text.Substring(8, 2) + "' ,[i_name]='" + objDataSetsc.Tables["H_Personel"].Rows[0]["name"].ToString() + " " + objDataSetsc.Tables["H_Personel"].Rows[0]["family"].ToString() + "' ,[i_serial]='" + objDataSetsc.Tables["H_ezam"].Rows[0]["serial"].ToString() + "' ,[i_numbergroup]='" + objDataSetsc.Tables["H_ezam"].Rows[0]["numbergroup"].ToString() + "'";
                    objCommand5.CommandType = CommandType.Text;

                    objConnectionce.Open();
                    objCommand5.ExecuteNonQuery();
                    objConnectionce.Close();
                }

                for (int w = 0; w <= objDataSetsc.Tables["H_ezam"].Rows.Count - 1; w++)
                {
                    DatabaseSc.Connection_Open();
                    DatabaseSc.Fill("SELECT * FROM Sandogh WHERE ((serial = '" + objDataSetsc.Tables["H_ezam"].Rows[w]["serial"].ToString() + "') AND (numbergroup = '" + objDataSetsc.Tables["H_ezam"].Rows[w]["numbergroup"].ToString() + "'))", objDataSetsc, "Sandogh", true);
                    DatabaseSc.Connection_Close();

                    if (objDataSetsc.Tables["Sandogh"].Rows.Count > 0)
                    {
                        progressBar3.Minimum = 0;
                        progressBar3.Value = 0;
                        progressBar3.Maximum = objDataSetsc.Tables["Sandogh"].Rows.Count;

                        for (int q = 0; q < objDataSetsc.Tables["Sandogh"].Rows.Count; q++)
                        {
                            progressBar3.Value++;
                            //Add To MYDB
                            SqlCeCommand objCommand1 = new SqlCeCommand();
                            objCommand1.Connection = objConnectionce;
                            objCommand1.CommandText = "INSERT INTO Sandogh (  id2, id3, id4, name1, address1, phone1, phone2, mobile, amal, tmpid) VALUES (  @id2, @id3, @id4, @name1, @address1, @phone1, @phone2, @mobile, @amal, @tmpid)";
                            objCommand1.CommandType = CommandType.Text;
                            objCommand1.Parameters.AddWithValue("@id2", objDataSetsc.Tables["sandogh"].Rows[q]["id2"].ToString());
                            objCommand1.Parameters.AddWithValue("@id3", objDataSetsc.Tables["sandogh"].Rows[q]["id3"].ToString());
                            objCommand1.Parameters.AddWithValue("@id4", objDataSetsc.Tables["sandogh"].Rows[q]["id4"].ToString());
                            objCommand1.Parameters.AddWithValue("@name1", objDataSetsc.Tables["sandogh"].Rows[q]["name1"].ToString());
                            objCommand1.Parameters.AddWithValue("@address1", objDataSetsc.Tables["sandogh"].Rows[q]["address1"].ToString());
                            objCommand1.Parameters.AddWithValue("@phone1", objDataSetsc.Tables["sandogh"].Rows[q]["phone1"].ToString());
                            objCommand1.Parameters.AddWithValue("@phone2", objDataSetsc.Tables["sandogh"].Rows[q]["phone2"].ToString());
                            objCommand1.Parameters.AddWithValue("@mobile", objDataSetsc.Tables["sandogh"].Rows[q]["mobile"].ToString());
                            objCommand1.Parameters.AddWithValue("@amal", objDataSetsc.Tables["sandogh"].Rows[q]["amal"].ToString());
                            objCommand1.Parameters.AddWithValue("@tmpid", objDataSetsc.Tables["sandogh"].Rows[q]["tmpid"].ToString());

                            try
                            {
                                objConnectionce.Open();
                                objCommand1.ExecuteNonQuery();
                                objConnectionce.Close();

                                label4.Text = "OK";
                            }
                            catch (SqlException SqlExceptionErr)
                            {
                                label4.Text = SqlExceptionErr.Message;
                            }

                            label4.Text = "موفق";
                        }
                    }
                    else
                    {
                        label4.Text = "صندوقی برای اعزام وجود ندارد";
                    }
                }
            }
            else
            {
                label4.Text = "اعزام ثبت نشده است";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            if (Send_Data_To_Server() == true)
                Recive_Data_From_Server();
            button3.Enabled = true;
        }
    }
}