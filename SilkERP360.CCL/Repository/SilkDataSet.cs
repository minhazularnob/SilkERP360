using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Repository
{
    public sealed class SilkDataSet : System.Data.DataSet
    {
        private static System.Boolean m_b_Initialized = false;
        private static readonly System.String m_str_DBConnectionString;

        public static System.String DBConnectionString
        {
            get { return SilkDataSet.m_str_DBConnectionString; }
            //set { SilkERP360.m_str_DBConnectionString = value; }
        }

        private static System.Data.OracleClient.OracleConnection m_obj_OracleConnection;

        static SilkDataSet()
        {
            SilkDataSet.m_str_DBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SILKERP_CONNECTION"].ToString();
            SilkDataSet.m_obj_OracleConnection = new System.Data.OracleClient.OracleConnection();
            SilkDataSet.m_obj_OracleConnection.ConnectionString = SilkDataSet.m_str_DBConnectionString;
        }

        /// <summary>
        /// Must be called in application_start event
        /// </summary>
        public  void Initialize()
        {
            try
            {
                
                SilkDataSet.m_obj_OracleConnection.Open();
                System.String [] lcl_str_Restrictions = new System.String[3];
                lcl_str_Restrictions[1] = "Module";
                System.Data.DataTable lcl_tblObj_Module = SilkDataSet.m_obj_OracleConnection.GetSchema("Columns", lcl_str_Restrictions);
                SilkDataSet.m_obj_OracleConnection.Close();
                this.Tables.Clear();
            }
            catch (System.Exception Ex)
            {
                SilkDataSet.m_obj_OracleConnection.Close();
            }
        }
    }
}
