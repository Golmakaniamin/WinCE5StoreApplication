using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace Borna
{
    class DB_Base_Sc
    {
        //نبی اعظم
        public static string Constr0 = @"192.168.160.1,1433";
        public static string Constr1 = "CharityMoney";
        public static Boolean Constr2 = true;
        public static string Constr3 = @"Amin_Money";
        public static string Constr4 = "258456";

        public static string ConStr = "Data Source=" + Constr0 + "; Persist Security Info=true; Initial Catalog=" + Constr1 + "; User ID =" + Constr3 + "; Password =" + Constr4 + ";";

        public SqlConnection objConnection = new SqlConnection();
        public SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        public SqlCommand objCommand = new SqlCommand();

        public void Connection_Open()
        {
            try
            {
                objConnection.Open();
            }
            catch (SqlException SqlExceptionErr)
            {
                System.Windows.Forms.MessageBox.Show(SqlExceptionErr.Message);
                //System.Windows.Forms.MessageBox.Show("خطا در اتصال پایگاه داده");
                //Environment.Exit(1);
            }
        }

        public void Connection_Close()
        {
           objConnection.Close();
        }

        public DB_Base_Sc()
        {
            objDataAdapter.SelectCommand = new SqlCommand();
            objConnection.ConnectionString = ConStr;
            objDataAdapter.SelectCommand.Connection = objConnection;
            objCommand.Connection = objConnection;
        }

        public int Fill(string Qry, DataSet objDataSet, string TableName, bool ClearTable)
        {
            objDataAdapter.SelectCommand.CommandText = Qry;
            if (ClearTable == true)
                if (objDataSet.Tables[TableName] != null)
                    objDataSet.Tables[TableName].Clear();
            return (objDataAdapter.Fill(objDataSet, TableName));
        }

        public int ExecuteNonQuery(string Qry)
        {
            objCommand.CommandText = Qry;
            return (objCommand.ExecuteNonQuery());
        }

        public object ExecuteScalar(string Qry)
        {
            objCommand.CommandText = Qry;
            return (objCommand.ExecuteScalar());
        }
    }
}
