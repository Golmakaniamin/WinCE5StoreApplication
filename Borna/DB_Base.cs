using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.SqlServerCe;

namespace Borna
{
    class DB_Base
    {
        ////localhost
        //public static string Constr0 = @"localhost\SQLEXPRESS";
        //public static string Constr1 = "CharityOne";
        //public static Boolean Constr2 = true;
        //public static string Constr3 = "Falaghuser4";
        //public static string Constr4 = "123456";

        //نبی اعظم
        public static string Constr3 = @"\Program Files\Borna\";
        public static string Constr4 = "123456";

        //public static string ConStr = "Data Source=" + Constr0 + ";Initial Catalog=" + Constr1 + ";Persist Security Info=" + Constr2 + ";User ID=" + Constr3 + ";Password=" + Constr4 + "";
        public static string ConStr = @"Data Source=" + Constr3 + "STM-Charityone.sdf;Password=" + Constr4 + ";Persist Security Info=True";

        public SqlCeConnection objConnection = new SqlCeConnection();
        public SqlCeDataAdapter objDataAdapter = new SqlCeDataAdapter();
        public SqlCeCommand objCommand = new SqlCeCommand();

        public void Connection_Open()
        {
            //try
            //{
                objConnection.Open();
            //}
            //catch
            //{
            //    System.Windows.Forms.MessageBox.Show("خطا در اتصال پایگاه داده");
            //    Environment.Exit(1);
            //}
        }

        public void Connection_Close()
        {
           objConnection.Close();
        }

        public DB_Base()
        {
            objDataAdapter.SelectCommand = new SqlCeCommand();
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
