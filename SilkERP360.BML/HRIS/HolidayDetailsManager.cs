using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class HolidayDetailsManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>
    {
       public HolidayDetailsManager()
       {
       }


       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDetails, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_HolidayDtlCode = 0;

           lcl_ui64_HolidayDtlCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

               OracleParameter lcl_obj_HolidayDtlCode = new OracleParameter("v_HolidayDtlCode", OracleDbType.Int64);
               lcl_obj_HolidayDtlCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_HolidayDtlCode.Value = lcl_obj_HolidayDetails.HolidayDtlCode;

               OracleParameter lcl_obj_HolidayMasterCode = new OracleParameter("v_HolidayMasterCode", OracleDbType.Int64);
               lcl_obj_HolidayMasterCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_HolidayMasterCode.Value = lcl_obj_HolidayDetails.HolidayMasterCode;

               OracleParameter lcl_obj_WeekDayName = new OracleParameter("v_WeekDayName", OracleDbType.Int64);
               lcl_obj_WeekDayName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_WeekDayName.Value = lcl_obj_HolidayDetails.WeekDayName;

               OracleParameter lcl_obj_HolidayDate = new OracleParameter("v_HolidayDate", OracleDbType.NVarchar2, 32);
               lcl_obj_HolidayDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_HolidayDate.Value = lcl_obj_HolidayDetails.HolidayDate;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_HolidayDtlCode, lcl_obj_HolidayMasterCode, lcl_obj_WeekDayName, lcl_obj_HolidayDate };
               lcl_obj_DBManager.ExecuteStoredProcedure("HOLIDAY_DETAILS", lcl_obj_SP_Parameters);
               return System.UInt64.Parse(lcl_obj_HolidayDtlCode.Value.ToString());
           }, "BMLExceptionPolicy");
           return lcl_ui64_HolidayDtlCode;
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDetails)
       {
           System.UInt64 lcl_ui64_HolidayDtlCode = 0;

           lcl_ui64_HolidayDtlCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_HolidayDtlCode = new OracleParameter("v_HolidayDtlCode", OracleDbType.Int64);
               lcl_obj_HolidayDtlCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_HolidayDtlCode.Value = lcl_obj_HolidayDetails.HolidayDtlCode;

               OracleParameter lcl_obj_HolidayMasterCode = new OracleParameter("v_HolidayMasterCode", OracleDbType.Int64);
               lcl_obj_HolidayMasterCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_HolidayMasterCode.Value = lcl_obj_HolidayDetails.HolidayMasterCode;

               OracleParameter lcl_obj_WeekDayName = new OracleParameter("v_WeekDayName", OracleDbType.Int64);
               lcl_obj_WeekDayName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_WeekDayName.Value = lcl_obj_HolidayDetails.WeekDayName;

               OracleParameter lcl_obj_HolidayDate = new OracleParameter("v_HolidayDate", OracleDbType.NVarchar2, 32);
               lcl_obj_HolidayDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_HolidayDate.Value = lcl_obj_HolidayDetails.HolidayDate;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_HolidayDtlCode, lcl_obj_HolidayMasterCode, lcl_obj_WeekDayName, lcl_obj_HolidayDate };
               lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HOLIDAY_DETAILS", lcl_obj_SP_Parameters);
               return System.UInt64.Parse(lcl_obj_HolidayDtlCode.Value.ToString());
                }
               }, "BMLExceptionPolicy");
           return lcl_ui64_HolidayDtlCode;
       }

       public CCL.BusinessEntities.HRIS.HolidayDetails Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtl = null;

           lcl_obj_HolidayDtl = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From HOLIDAY_DETAILS Where HOLIDAY_DTL_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_HolidayDtlReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_HolidayDtlReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error HolidayDetailsManager.Get(ID,DBManger)) : Error Retrieving HolidayDetails Data!");
               }
               lcl_obj_HolidayDtlReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtlTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails();
               lcl_obj_HolidayDtlTmp.HolidayDtlCode = System.UInt64.Parse(lcl_obj_HolidayDtlReader["HOLIDAY_DTL_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayMasterCode = System.UInt64.Parse(lcl_obj_HolidayDtlReader["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.WeekDayName = System.UInt16.Parse(lcl_obj_HolidayDtlReader["WEEK_DAY_NAME"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayDate = System.DateTime.Parse(lcl_obj_HolidayDtlReader["HOLIDAY_DATE"].ToString());

               lcl_obj_HolidayDtlReader.Close();
               return lcl_obj_HolidayDtlTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_HolidayDtl;
       }

       public CCL.BusinessEntities.HRIS.HolidayDetails Get(ulong IP_ui64_Code)
       {
          SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtl = null;

           lcl_obj_HolidayDtl = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>(() =>
                {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From ATTENDANCE_RAW_DTL Where ATTEN_RAW_DTL_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
       if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (HolidayDetailsManager.Get(ID)) : No HolidayDetails Data Found In The Database!!!");
                    }
               SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtlTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails();
               lcl_obj_HolidayDtlTmp.HolidayDtlCode = System.UInt64.Parse(dr["HOLIDAY_DTL_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.WeekDayName = System.UInt16.Parse(dr["WEEK_DAY_NAME"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayDate = System.DateTime.Parse(dr["HOLIDAY_DATE"].ToString());
                    dr.Close();
                    return lcl_obj_HolidayDtlTmp;
                }
                }, "BMLExceptionPolicy");
           return lcl_obj_HolidayDtl;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails> lcl_objLst_HolidayDtl = null;
            
            lcl_objLst_HolidayDtl = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (HolidayDetailsManager.GetList(SqlQuery,DBManager)) : No HolidayDetails Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails> lcl_objLst_HolidayDtlTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtlTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails();
                    lcl_obj_HolidayDtlTmp.HolidayDtlCode = System.UInt64.Parse(dr["HOLIDAY_DTL_CODE"].ToString());
                    lcl_obj_HolidayDtlTmp.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
                    lcl_obj_HolidayDtlTmp.WeekDayName = System.UInt16.Parse(dr["WEEK_DAY_NAME"].ToString());
                    lcl_obj_HolidayDtlTmp.HolidayDate = System.DateTime.Parse(dr["HOLIDAY_DATE"].ToString());
                }
                dr.Close();
                return lcl_objLst_HolidayDtlTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_HolidayDtl;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails> GetList(string IP_str_SqlQuery)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails> lcl_objLst_HolidayDtl = null;
            lcl_objLst_HolidayDtl = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>>(() =>
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
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (HolidayDetailsManager.GetList(SqlQuery)) : No HolidayDetails Data Found In The Database!!!");
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails> lcl_objLst_HolidayDtllTmp = new
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>();
                        while (dr.Read())
                        {
                SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtl = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails();
                lcl_obj_HolidayDtl.HolidayDtlCode = System.UInt64.Parse(dr["HOLIDAY_DTL_CODE"].ToString());
               lcl_obj_HolidayDtl.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayDtl.WeekDayName = System.UInt16.Parse(dr["WEEK_DAY_NAME"].ToString());
               lcl_obj_HolidayDtl.HolidayDate = System.DateTime.Parse(dr["HOLIDAY_DATE"].ToString());
               lcl_objLst_HolidayDtllTmp.Add(lcl_obj_HolidayDtl);
                        }
                        dr.Close();
                        return lcl_objLst_HolidayDtllTmp;
                    }
                }, "BMLExceptionPolicy");
            return lcl_objLst_HolidayDtl;
       }

       public CCL.BusinessEntities.HRIS.HolidayDetails Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {

           SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtl = null;
           lcl_obj_HolidayDtl = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_HolidayDtlReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_HolidayDtlReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorHolidayDetailsManager.Get(SqlQuery,DBManger)) : Error Retrieving HolidayDetails Data!");
               }
               lcl_obj_HolidayDtlReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtlTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails();
               lcl_obj_HolidayDtlTmp.HolidayDtlCode = System.UInt64.Parse(lcl_obj_HolidayDtlReader["HOLIDAY_DTL_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayMasterCode = System.UInt64.Parse(lcl_obj_HolidayDtlReader["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.WeekDayName = System.UInt16.Parse(lcl_obj_HolidayDtlReader["WEEK_DAY_NAME"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayDate = System.DateTime.Parse(lcl_obj_HolidayDtlReader["HOLIDAY_DATE"].ToString());
               lcl_obj_HolidayDtlReader.Close();
               return lcl_obj_HolidayDtlTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_HolidayDtl;
       }
       public CCL.BusinessEntities.HRIS.HolidayDetails Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtl = null;
            lcl_obj_HolidayDtl = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (HolidayDetailsManager.Get(SqlQuery)) : No HolidayDetails Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDtlTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails();
               lcl_obj_HolidayDtlTmp.HolidayDtlCode = System.UInt64.Parse(dr["HOLIDAY_DTL_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayDtlTmp.WeekDayName = System.UInt16.Parse(dr["WEEK_DAY_NAME"].ToString());
               lcl_obj_HolidayDtlTmp.HolidayDate = System.DateTime.Parse(dr["HOLIDAY_DATE"].ToString());
               dr.Close();
               return lcl_obj_HolidayDtlTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_HolidayDtl;
       }
    }
}
