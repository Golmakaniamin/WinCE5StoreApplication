using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;

namespace Borna
{
    class U_Base
    {
        SqlCeConnection objConnection = new SqlCeConnection(DB_Base_Ce.ConStr);
        SqlCeDataAdapter objDataAdapter = new SqlCeDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base_Ce Database = new DB_Base_Ce();

        public string u_date()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM info", objDataSet, "info", true);
            Database.Connection_Close();

            string main_date = objDataSet.Tables["info"].Rows[0]["i_date"].ToString().Substring(0, 4) + "/" + objDataSet.Tables["info"].Rows[0]["i_date"].ToString().Substring(4, 2) + "/" + objDataSet.Tables["info"].Rows[0]["i_date"].ToString().Substring(6, 2);

            return (main_date);
        }

        public string u_time()
        {
            return (DateTime.Now.ToString("hh:mm:ss"));
        }

        public string u_hard()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM info", objDataSet, "info", true);
            Database.Connection_Close();

            return (objDataSet.Tables["info"].Rows[0]["i_hard_code"].ToString());
        }

        public string u_user()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM info", objDataSet, "info", true);
            Database.Connection_Close();

            return (objDataSet.Tables["info"].Rows[0]["i_name"].ToString());
        }

        public string u_serial()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM info", objDataSet, "info", true);
            Database.Connection_Close();

            return (objDataSet.Tables["info"].Rows[0]["i_serial"].ToString());
        }

        public string u_numbergroup()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM info", objDataSet, "info", true);
            Database.Connection_Close();

            return (objDataSet.Tables["info"].Rows[0]["i_numbergroup"].ToString());
        }
    }
}
