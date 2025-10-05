using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL
{
    public class SqlFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        private SilkERP360.BML.SqlManager m_obj_SqlManager = null;

        public SqlFacade()
        {
            this.Initialize();
            this.m_obj_SqlManager = new SilkERP360.BML.SqlManager();
        }

        public void Close()
        {
            this.m_obj_SqlManager.Close();
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
                System.Object lcl_obj_TmpReturn = this.m_obj_SqlManager.ExecuteScaler(IP_str_SqlQuery);
                return lcl_obj_TmpReturn;
            }, "FLExceptionPolicy");
            return lcl_obj_Return;
        }

        //public void ExecuteNonQuery(System.String IP_str_SqlQuery)
        //{
        //    System.Int32 lcl_i32_Return = 0;

        //    lcl_i32_Return = this.ExceptionManager.Process<System.Int32>(() =>
        //    {
        //        return this.m_obj_SqlManager.(IP_str_SqlQuery);
        //        //return lcl_obj_TmpReturn;
        //    }, "FLExceptionPolicy");
        //    //return lcl_obj_Return;
        //}

        public System.Data.OracleClient.OracleDataReader ExecuteDataReader(System.String IP_str_SqlQuery)
        {
            System.Data.OracleClient.OracleDataReader lcl_obj_DataReader = null;
            //throws Error.109
            lcl_obj_DataReader = this.ExceptionManager.Process<System.Data.OracleClient.OracleDataReader>(() =>
            {
                return this.m_obj_SqlManager.ExecuteDataReader(IP_str_SqlQuery);
            },
            "FLExceptionPolicy");
            return lcl_obj_DataReader;
        }

        public void CloseReader()
        {
            //throws Error.110

            this.ExceptionManager.Process(() =>
            {
                this.m_obj_SqlManager.CloseReader();
            },
            "FLExceptionPolicy");
        }

        public void CommitTransaction()
        {
            this.ExceptionManager.Process(() =>
            {
                this.m_obj_SqlManager.CommitTransaction();
            },
            "FLExceptionPolicy");
        }
    }
}
