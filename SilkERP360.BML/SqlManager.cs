using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML
{
    /// <summary>
    /// This class will execute sql query and return datareader or ExecuteScaler func.
    /// There will be no facade class for this class.
    /// </summary>
    public class SqlManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        /// <summary>
        /// This DBManager must not be closed if the desired function returns a DataReader
        /// </summary>
        SilkERP360.DAL.DBManager m_obj_DBManager = null;

        

        /// <summary>
        /// If a func of this class returns DataReader, The DBManager
        /// Must not be closed as long as the datareader is in operation
        /// </summary>
        public SilkERP360.DAL.DBManager DBManager
        {
          get { return this.m_obj_DBManager; }
        }

        public SqlManager()
        {
            this.Initialize();
            this.m_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource;
            if (this.m_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
            {
                this.m_obj_DBManager.Open();
            }
            //this.m_obj_DBManager.Open();
        }

        public void Close()
        {
            this.m_obj_DBManager.Close();
        }

        /// <summary>
        /// Executes a query and returns the first column of the first row  in the result
        /// set as .net data type System.object
        /// Examp: SQL ' "Select COUNT(*) FROM <TABLE>
        /// Returns the count
        /// /// </summary>
        /// <param name="StrSql"></param>
        /// <returns>System.Object</returns>
        public System.Object ExecuteScaler(System.String IP_str_SqlQuery)
        {
            System.Object lcl_obj_Return = null;

            lcl_obj_Return = this.ExceptionManager.Process<System.Object>(() =>
                {
                    System.Object lcl_obj_TmpReturn = this.m_obj_DBManager.ExecuteScalar(IP_str_SqlQuery);
                    return lcl_obj_TmpReturn;
                }, "BMLExceptionPolicy");
            return lcl_obj_Return;
        }

        /// <summary>
        /// Executes the IP_strQuery and returns the number of rows affected
        /// </summary>
        /// <param name="IP_strQuery">Query to execute</param>
        /// <returns>Number of Rows affected by the query</returns>
        //public System.Int32 ExecuteNonQuery(System.String IP_str_SqlQuery)
        //{
        //    //throws Error.104
        //    System.Int32 lcl_i32_RowsAffected = 0;
        //    lcl_i32_RowsAffected = this.ExceptionManager.Process<System.Int32>(() =>
        //    {
        //        System.Int32 lcl_i32_RowsAffectedTmp = this.m_obj_DBManager.ExecuteNonQuery(IP_str_SqlQuery);
        //        return lcl_i32_RowsAffectedTmp;
        //    },
        //    "BMLExceptionPolicy");
        //    return lcl_i32_RowsAffected;
        //}

        public Oracle.ManagedDataAccess.Client.OracleDataReader ExecuteDataReader(System.String IP_str_SqlQuery)
        {
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DataReader = null;
            //throws Error.109
            lcl_obj_DataReader = this.ExceptionManager.Process<Oracle.ManagedDataAccess.Client.OracleDataReader>(() =>
            {
                try
                {
                    return this.m_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                }
                catch (System.Exception Ex)
                {
                    throw Ex;
                }
            },
            "BMLExceptionPolicy");
            return lcl_obj_DataReader;
        }

        public void CloseReader()
        {
            //throws Error.110

            this.ExceptionManager.Process(() =>
            {
                this.m_obj_DBManager.CloseReader();
            },"BMLExceptionPolicy");
        }

        public void CommitTransaction()
        {
            this.ExceptionManager.Process(() =>
            {
                this.m_obj_DBManager.CommitTransaction();
            }, "BMLExceptionPolicy");
        }
    }
}
