using Oracle.ManagedDataAccess.Client;
using SilkERP360.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class EmployeeWeekendManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>
    {
       public EmployeeWeekendManager()
       {
           this.Initialize();
       }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="IP_obj_A"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        //public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend, System.Object IP_obj_DBManager)
        //{
        //    System.UInt64 lcl_ui64_WeekendCode = 0;

        //    lcl_ui64_WeekendCode = this.ExceptionManager.Process<System.UInt64>(() =>
        //    {
        //        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;


        //        OracleParameter lcl_obj_WeekendCode = new OracleParameter("v_WeekendCode", OracleDbType.Int64);
        //        lcl_obj_WeekendCode.Direction = System.Data.ParameterDirection.Output;
        //        lcl_obj_WeekendCode.Value = lcl_obj_EmpWeekend.WeekendCode;

        //        OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EmployeeCode", OracleDbType.Int64);
        //        lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_EmployeeCode.Value = lcl_obj_EmpWeekend.EmployeeCode;

        //        OracleParameter lcl_obj_Day = new OracleParameter("v_Day", OracleDbType.Int64);
        //        lcl_obj_Day.Direction = System.Data.ParameterDirection.Input;
        //        lcl_obj_Day.Value = lcl_obj_EmpWeekend.Day;

        //        OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_WeekendCode, lcl_obj_EmployeeCode, lcl_obj_Day };
        //        lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_WEEKEND_IU", lcl_obj_SP_Parameters);

        //        return System.UInt64.Parse(lcl_obj_WeekendCode.Value.ToString());
        //    }, "BMLExceptionPolicy");
        //    return lcl_ui64_WeekendCode;
        //}

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend, object IP_obj_DBManager)
        {
            ulong lcl_ui64_WeekendCode = 0;

            lcl_ui64_WeekendCode = this.ExceptionManager.Process<ulong>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

                if (lcl_obj_DBManager.TransactionState != TransactionState.Pending)
                    lcl_obj_DBManager.Open();

                // 1. Get next sequence value if WeekendCode is 0
                if (lcl_obj_EmpWeekend.WeekendCode == 0)
                {
                    using (var seqCmd = new OracleCommand("select max(WEEKEND_CODE)+1 from EMPLOYEE_WEEKEND", lcl_obj_DBManager.Connection))
                    {
                        seqCmd.Transaction = lcl_obj_DBManager.Transaction;
                        lcl_ui64_WeekendCode = Convert.ToUInt64(seqCmd.ExecuteScalar());
                    }
                }
                else
                {
                    lcl_ui64_WeekendCode = lcl_obj_EmpWeekend.WeekendCode;
                }

                // 2. Insert or Update
                string sql;
                if (lcl_obj_EmpWeekend.WeekendCode == 0)
                {
                    sql = @"
                INSERT INTO EMPLOYEE_WEEKEND
                (
                    WEEKEND_CODE,
                    EMPLOYEE_CODE,
                    DAY
                )
                VALUES
                (
                    :WEEKEND_CODE,
                    :EMPLOYEE_CODE,
                    :DAY
                )";
                }
                else
                {
                    sql = @"
                UPDATE EMPLOYEE_WEEKEND
                SET EMPLOYEE_CODE = :EMPLOYEE_CODE,
                    DAY = :DAY
                WHERE WEEKEND_CODE = :WEEKEND_CODE";
                }

                using (var cmd = new OracleCommand(sql, lcl_obj_DBManager.Connection))
                {
                    cmd.Transaction = lcl_obj_DBManager.Transaction;

                    cmd.Parameters.Add(":WEEKEND_CODE", OracleDbType.Int64).Value = lcl_ui64_WeekendCode;
                    cmd.Parameters.Add(":EMPLOYEE_CODE", OracleDbType.Int64).Value = lcl_obj_EmpWeekend.EmployeeCode;
                    cmd.Parameters.Add(":DAY", OracleDbType.Int64).Value = lcl_obj_EmpWeekend.Day;

                    cmd.ExecuteNonQuery();
                }

                return lcl_ui64_WeekendCode;

            }, "BMLExceptionPolicy");

            return lcl_ui64_WeekendCode;
        }

        public ulong Update(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_WeekendCode = 0;

           lcl_ui64_WeekendCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;


               OracleParameter lcl_obj_WeekendCode = new OracleParameter("v_WeekendCode", OracleDbType.Int64);
               lcl_obj_WeekendCode.Direction = System.Data.ParameterDirection.Output;
               lcl_obj_WeekendCode.Value = lcl_obj_EmpWeekend.WeekendCode;

               OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EmployeeCode", OracleDbType.Int64);
               lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployeeCode.Value = lcl_obj_EmpWeekend.EmployeeCode;

               OracleParameter lcl_obj_Day = new OracleParameter("v_Day", OracleDbType.Int64);
               lcl_obj_Day.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Day.Value = lcl_obj_EmpWeekend.Day;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_WeekendCode, lcl_obj_EmployeeCode, lcl_obj_Day };
               lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_WEEKEND_UPD", lcl_obj_SP_Parameters);

               return System.UInt64.Parse(lcl_obj_WeekendCode.Value.ToString());
           }, "BMLExceptionPolicy");
           return lcl_ui64_WeekendCode;
       }
       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend)
       {
          System.UInt64 lcl_ui64_WeekendCode = 0;

           lcl_ui64_WeekendCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_WeekendCode = new OracleParameter("v_WeekendCode", OracleDbType.Int64);
               lcl_obj_WeekendCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_WeekendCode.Value = lcl_obj_EmpWeekend.WeekendCode;

               OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EmployeeCode", OracleDbType.Int64);
               lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployeeCode.Value = lcl_obj_EmpWeekend.EmployeeCode;

               OracleParameter lcl_obj_Day = new OracleParameter("v_Day", OracleDbType.Date);
               lcl_obj_Day.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Day.Value = lcl_obj_EmpWeekend.Day;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_WeekendCode, lcl_obj_EmployeeCode, lcl_obj_Day };
               lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_EMPLOYEE_WEEKEND", lcl_obj_SP_Parameters);
               return System.UInt64.Parse(lcl_obj_WeekendCode.Value.ToString());
                }
               }, "BMLExceptionPolicy");
           return lcl_ui64_WeekendCode;
       }

       public CCL.BusinessEntities.HRIS.EmployeeWeekend Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend = null;

           lcl_obj_EmpWeekend = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_WEEKEND Where WEEKEND_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmpWeekendReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_EmpWeekendReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error EmployeeWeekendManager.Get(ID,DBManger)) : Error Retrieving EmployeeWeekend Data!");
               }
               lcl_obj_EmpWeekendReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekendTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend();
               lcl_obj_EmpWeekendTmp.WeekendCode = System.UInt64.Parse(lcl_obj_EmpWeekendReader["WEEKEND_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmpWeekendReader["EMPLOYEE_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.Day = System.UInt64.Parse(lcl_obj_EmpWeekendReader["DAY"].ToString());
               

               lcl_obj_EmpWeekendReader.Close();
               return lcl_obj_EmpWeekendTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_EmpWeekend;
       }

       public CCL.BusinessEntities.HRIS.EmployeeWeekend Get(ulong IP_ui64_Code)
       {
          SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend = null;

           lcl_obj_EmpWeekend = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>(() =>
                {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_WEEKEND Where WEEKEND_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
       if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.Get(ID)) : No EmployeeWeekend Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekendTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend();
               lcl_obj_EmpWeekendTmp.WeekendCode = System.UInt64.Parse(dr["WEEKEND_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.Day = System.UInt64.Parse(dr["DAY"].ToString());
               dr.Close();
               return lcl_obj_EmpWeekendTmp;
                }
                }, "BMLExceptionPolicy");
           return lcl_obj_EmpWeekend;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> lcl_objLst_EmpWeekend = null;
            
            lcl_objLst_EmpWeekend = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No EmployeeWeekend Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> lcl_objLst_EmpWeekendTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend();
               lcl_obj_EmpWeekend.WeekendCode = System.UInt64.Parse(dr["WEEKEND_CODE"].ToString());
               lcl_obj_EmpWeekend.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_EmpWeekend.Day = System.UInt64.Parse(dr["DAY"].ToString());
               lcl_objLst_EmpWeekendTmp.Add(lcl_obj_EmpWeekend);
                }
                dr.Close();
                return lcl_objLst_EmpWeekendTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EmpWeekend;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> GetList(string IP_str_SqlQuery)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> lcl_objLst_EmpWeekend = null;
            lcl_objLst_EmpWeekend = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.InternalResource.Open();
                        }

                        Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                        if (!(dr.HasRows))
                        {
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery)) : No EmployeeWeekend Data Found In The Database!!!");
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> lcl_objLst_EmpWeekendTmp = new
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>();
                        while (dr.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend();
                            lcl_obj_EmpWeekend.WeekendCode = System.UInt64.Parse(dr["WEEKEND_CODE"].ToString());
                            lcl_obj_EmpWeekend.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                            lcl_obj_EmpWeekend.Day = System.UInt64.Parse(dr["DAY"].ToString());
                            lcl_objLst_EmpWeekendTmp.Add(lcl_obj_EmpWeekend);
                        }
                        dr.Close();
                        return lcl_objLst_EmpWeekendTmp;
                    }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EmpWeekend;
       }

       public CCL.BusinessEntities.HRIS.EmployeeWeekend Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {

           SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend = null;         
            lcl_obj_EmpWeekend = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmpWeekendReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_EmpWeekendReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error EmployeeWeekendManager.Get(SqlQuery,DBManger)) : Error Retrieving EmployeeWeekend Data!");
                }
                lcl_obj_EmpWeekendReader.Read();
                 SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekendTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend();
               lcl_obj_EmpWeekendTmp.WeekendCode = System.UInt64.Parse(lcl_obj_EmpWeekendReader["WEEKEND_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmpWeekendReader["EMPLOYEE_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.Day = System.UInt64.Parse(lcl_obj_EmpWeekendReader["DAY"].ToString());
               lcl_obj_EmpWeekendReader.Close();
               return lcl_obj_EmpWeekendTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmpWeekend;
       }


       public CCL.BusinessEntities.HRIS.EmployeeWeekend Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekend = null;
            lcl_obj_EmpWeekend = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(IP_str_SqlQuery));
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.Get(SqlQuery)) : No EmployeeWeekend Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmpWeekendTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend();
               lcl_obj_EmpWeekendTmp.WeekendCode = System.UInt64.Parse(dr["WEEKEND_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_EmpWeekendTmp.Day = System.UInt64.Parse(dr["DAY"].ToString());
               dr.Close();
               return lcl_obj_EmpWeekendTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmpWeekend;
       }
    }
}
