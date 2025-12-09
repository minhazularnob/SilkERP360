using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class HolidayMstrManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>
    {
       public HolidayMstrManager()
       {
           this.Initialize();
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMaster, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_HolidayMstrCode = 0;

           lcl_ui64_HolidayMstrCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                   SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;


                   OracleParameter lcl_obj_HolidayMasterCode = new OracleParameter("p_HOLIDAY_MASTER_CODE", OracleDbType.Int64);
                   lcl_obj_HolidayMasterCode.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_HolidayMasterCode.Value = lcl_obj_HolidayMaster.HolidayMasterCode;

                   OracleParameter lcl_obj_CompanyCode = new OracleParameter("p_COMPANY_CODE", OracleDbType.Int64);
                   lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_CompanyCode.Value = lcl_obj_HolidayMaster.CompanyCode;

                   OracleParameter lcl_obj_DecDate = new OracleParameter("p_DEC_DATE", OracleDbType.Date);
                   lcl_obj_DecDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_DecDate.Value = lcl_obj_HolidayMaster.DecDate;

                   OracleParameter lcl_obj_NumOfDays = new OracleParameter("p_NUM_OF_DAYS", OracleDbType.Int64);
                   lcl_obj_NumOfDays.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_NumOfDays.Value = lcl_obj_HolidayMaster.NumOfDays;

                   OracleParameter lcl_obj_StartDate = new OracleParameter("p_START_DATE", OracleDbType.Date);
                   lcl_obj_StartDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_StartDate.Value = lcl_obj_HolidayMaster.StartDate;
                   OracleParameter lcl_obj_EndDate = new OracleParameter("p_END_DATE", OracleDbType.Date);
                   lcl_obj_EndDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_EndDate.Value = lcl_obj_HolidayMaster.EndDate;
                   OracleParameter lcl_obj_Remarks = new OracleParameter("p_REMARKS", OracleDbType.NVarchar2, 20);
                   lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Remarks.Value = lcl_obj_HolidayMaster.Remarks;
                   OracleParameter lcl_obj_HolidayName = new OracleParameter("p_HOLIDAY_NAME", OracleDbType.NVarchar2, 128);
                   lcl_obj_HolidayName.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_HolidayName.Value = lcl_obj_HolidayMaster.HolidayName;

                   OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_HolidayMasterCode, lcl_obj_CompanyCode, lcl_obj_DecDate, lcl_obj_NumOfDays, lcl_obj_StartDate, lcl_obj_EndDate, lcl_obj_Remarks, lcl_obj_HolidayName };
                   lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_HOLIDAY_MASTER", lcl_obj_SP_Parameters);
                   return System.UInt64.Parse(lcl_obj_HolidayMasterCode.Value.ToString());
               }, "BMLExceptionPolicy");
           return lcl_ui64_HolidayMstrCode;

       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMaster)
       {
          System.UInt64 lcl_ui64_HolidayMstrCode = 0;

           lcl_ui64_HolidayMstrCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_HolidayMasterCode = new OracleParameter("v_HOLIDAY_MASTER_CODE", OracleDbType.Int64);
                   lcl_obj_HolidayMasterCode.Direction = System.Data.ParameterDirection.Output;
                  // lcl_obj_HolidayMasterCode.Value = lcl_obj_HolidayMaster.HolidayMasterCode;

                   OracleParameter lcl_obj_CompanyCode = new OracleParameter("v_COMPANY_CODE", OracleDbType.Int64);
                   lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_CompanyCode.Value = lcl_obj_HolidayMaster.CompanyCode;

                   OracleParameter lcl_obj_DecDate = new OracleParameter("v_DEC_DATE", OracleDbType.Date);
                   lcl_obj_DecDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_DecDate.Value = lcl_obj_HolidayMaster.DecDate;

                   OracleParameter lcl_obj_NumOfDays = new OracleParameter("v_NUM_OF_DAYS", OracleDbType.Int64);
                   lcl_obj_NumOfDays.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_NumOfDays.Value = lcl_obj_HolidayMaster.NumOfDays;

                   OracleParameter lcl_obj_StartDate = new OracleParameter("v_START_DATE", OracleDbType.Date);
                   lcl_obj_StartDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_StartDate.Value = lcl_obj_HolidayMaster.StartDate;

                   OracleParameter lcl_obj_EndDate = new OracleParameter("v_END_DATE", OracleDbType.Date);
                   lcl_obj_EndDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_EndDate.Value = lcl_obj_HolidayMaster.EndDate;

                   OracleParameter lcl_obj_Remarks = new OracleParameter("v_REMARKS", OracleDbType.NVarchar2, 20);
                   lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Remarks.Value = lcl_obj_HolidayMaster.Remarks;

                   OracleParameter lcl_obj_HolidayName = new OracleParameter("v_HOLIDAY_NAME", OracleDbType.NVarchar2, 128);
                   lcl_obj_HolidayName.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_HolidayName.Value = lcl_obj_HolidayMaster.HolidayName;

                   OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                   lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_IsDeleted.Value = 1;

                   OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                   lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Status.Value = 1;


                   OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_HolidayMasterCode, lcl_obj_CompanyCode, lcl_obj_DecDate, lcl_obj_NumOfDays, lcl_obj_StartDate, lcl_obj_EndDate, lcl_obj_Remarks, lcl_obj_HolidayName, lcl_obj_IsDeleted, lcl_obj_Status };
                   lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INS_HOLIDAY_MASTER", lcl_obj_SP_Parameters);

                   System.UInt64 lcl_ui64_HoliDayMstCode = System.UInt64.Parse(lcl_obj_HolidayMasterCode.Value.ToString());           

                   SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails lcl_obj_HolidayDetails = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayDetails();


                    /// Holiday Deaills Save////
                    /// 
                   for (int i = 0; i < Convert.ToInt16(lcl_obj_NumOfDays.Value.ToString()); i++)
                   {

                       OracleParameter lcl_obj_HolidayDtlCode = new OracleParameter("v_HOLIDAY_DTL_CODE", OracleDbType.Int64);
                       lcl_obj_HolidayDtlCode.Direction = System.Data.ParameterDirection.Output;


                       OracleParameter lcl_obj_HolidayMasterCodeD = new OracleParameter("v_HOLIDAY_MASTER_CODE", OracleDbType.Int64);
                       lcl_obj_HolidayMasterCodeD.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_HolidayMasterCodeD.Value = lcl_ui64_HoliDayMstCode;

                       OracleParameter lcl_obj_WeekDayName = new OracleParameter("v_WEEK_DAY_NAME", OracleDbType.Int64);
                       lcl_obj_WeekDayName.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_WeekDayName.Value = lcl_obj_HolidayDetails.WeekDayName;

                       OracleParameter lcl_obj_HolidayDate = new OracleParameter("v_HOLIDAY_DATE", OracleDbType.Date);
                       lcl_obj_HolidayDate.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_HolidayDate.Value = Convert.ToDateTime(lcl_obj_StartDate.Value.ToString()).AddDays(i);

                       OracleParameter lcl_obj_IsDeletedD = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                       lcl_obj_IsDeletedD.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_IsDeletedD.Value = 1;

                       OracleParameter lcl_obj_StatusD = new OracleParameter("v_STATUS", OracleDbType.Int64);
                       lcl_obj_StatusD.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_StatusD.Value = 1;

                       OracleParameter[] lcl_obj_SP_ParametersD = { lcl_obj_HolidayDtlCode, lcl_obj_HolidayMasterCodeD, lcl_obj_WeekDayName, lcl_obj_HolidayDate, lcl_obj_IsDeletedD, lcl_obj_StatusD };
                       lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INS_HOLIDAY_DETAILS", lcl_obj_SP_ParametersD);

                   }
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   lcl_obj_DBManager.InternalResource.Close();

                   return System.UInt64.Parse(lcl_obj_HolidayMasterCode.Value.ToString());
                     }
               }, "BMLExceptionPolicy");
           return lcl_ui64_HolidayMstrCode;
       }

       public CCL.BusinessEntities.HRIS.HolidayMaster Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMaster = null;

           lcl_obj_HolidayMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From HOLIDAY_MASTER Where HOLIDAY_MASTER_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_HolidayMstrReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_HolidayMstrReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error HolidayMasterManager.Get(ID,DBManger)) : Error Retrieving HolidayMaster Data!");
               }
               lcl_obj_HolidayMstrReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstrTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster();
               lcl_obj_HolidayMstrTmp.HolidayMasterCode = System.UInt64.Parse(lcl_obj_HolidayMstrReader["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.CompanyCode = System.UInt64.Parse(lcl_obj_HolidayMstrReader["COMPANY_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.DecDate = System.DateTime.Parse(lcl_obj_HolidayMstrReader["DEC_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.NumOfDays = System.UInt16.Parse(lcl_obj_HolidayMstrReader["READER_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.StartDate = System.DateTime.Parse(lcl_obj_HolidayMstrReader["END_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.EndDate = System.DateTime.Parse(lcl_obj_HolidayMstrReader["DEC_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.Remarks = lcl_obj_HolidayMstrReader["REMARKS"].ToString();
               lcl_obj_HolidayMstrTmp.HolidayName = lcl_obj_HolidayMstrReader["HOLIDAY_NAME"].ToString();

               lcl_obj_HolidayMstrReader.Close();
               return lcl_obj_HolidayMstrTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_HolidayMaster;
       }

       public CCL.BusinessEntities.HRIS.HolidayMaster Get(ulong IP_ui64_Code)
       {
          SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMaster = null;

           lcl_obj_HolidayMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>(() =>
                {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From HOLIDAY_MASTER Where HOLIDAY_MASTER_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
       if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (HolidayMasterManager.Get(ID)) : No HolidayMaster Data Found In The Database!!!");
                    }
                     SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstrTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster();
               lcl_obj_HolidayMstrTmp.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.DecDate = System.DateTime.Parse(dr["DEC_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.NumOfDays = System.UInt16.Parse(dr["READER_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.StartDate = System.DateTime.Parse(dr["END_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.EndDate = System.DateTime.Parse(dr["DEC_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.Remarks = dr["REMARKS"].ToString();
               lcl_obj_HolidayMstrTmp.HolidayName = dr["HOLIDAY_NAME"].ToString();
                    dr.Close();
                    return lcl_obj_HolidayMstrTmp;
                }
                }, "BMLExceptionPolicy");
           return lcl_obj_HolidayMaster;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> lcl_objLst_HolidayMstr = null;
            
            lcl_objLst_HolidayMstr = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (HolidayMasterManager.GetList(SqlQuery,DBManager)) : No HolidayMaster Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> lcl_objLst_HolidayMstrTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>();
                while (dr.Read())
                {
               SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstr = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster();
               lcl_obj_HolidayMstr.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayMstr.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
               lcl_obj_HolidayMstr.DecDate = System.DateTime.Parse(dr["DEC_DATE"].ToString());
               lcl_obj_HolidayMstr.NumOfDays = System.UInt16.Parse(dr["READER_CODE"].ToString());
               lcl_obj_HolidayMstr.StartDate = System.DateTime.Parse(dr["END_DATE"].ToString());
               lcl_obj_HolidayMstr.EndDate = System.DateTime.Parse(dr["DEC_DATE"].ToString());
               lcl_obj_HolidayMstr.Remarks = dr["REMARKS"].ToString();
               lcl_obj_HolidayMstr.HolidayName = dr["HOLIDAY_NAME"].ToString();
                }
                dr.Close();
                return lcl_objLst_HolidayMstrTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_HolidayMstr;

       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> GetList(string IP_str_SqlQuery)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> lcl_objLst_HolidayMstr = null;
            lcl_objLst_HolidayMstr = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> lcl_objLst_HolidayDtlTmp = null;
                        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.InternalResource.Open();
                        }

                        Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                        if (!(dr.HasRows))
                        {                            
                            System.String lcl_str_ErrorMsg = System.String.Format("DataError : No HolidayMaster Data Found In The Database!!!");
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_str_ErrorMsg);
                        }
                        else
                        {
                            lcl_objLst_HolidayDtlTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>();
                            while (dr.Read())
                            {
                                SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstr = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster();
                                lcl_obj_HolidayMstr.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
                                //lcl_obj_HolidayMstr.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                                lcl_obj_HolidayMstr.DecDate = System.DateTime.Parse(dr["DEC_DATE"].ToString());
                                lcl_obj_HolidayMstr.NumOfDays = System.UInt16.Parse(dr["NUM_OF_DAYS"].ToString());
                                lcl_obj_HolidayMstr.StartDate = System.DateTime.Parse(dr["START_DATE"].ToString());
                                lcl_obj_HolidayMstr.EndDate = System.DateTime.Parse(dr["END_DATE"].ToString());
                                lcl_obj_HolidayMstr.Remarks = dr["REMARKS"].ToString();
                                lcl_obj_HolidayMstr.HolidayName = dr["HOLIDAY_NAME"].ToString();

                                lcl_objLst_HolidayDtlTmp.Add(lcl_obj_HolidayMstr);
                            }
                            dr.Close();
                        }
                        return lcl_objLst_HolidayDtlTmp;
                    }
                }, "BMLExceptionPolicy");
            return lcl_objLst_HolidayMstr;

       }

       public CCL.BusinessEntities.HRIS.HolidayMaster Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {

           SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstr = null;
           lcl_obj_HolidayMstr = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_HolidayMstrReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_HolidayMstrReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error HolidayMasterManager.Get(SqlQuery,DBManger)) : Error Retrieving HolidayMaster Data!");
               }
               lcl_obj_HolidayMstrReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstrTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster();
               lcl_obj_HolidayMstrTmp.HolidayMasterCode = System.UInt64.Parse(lcl_obj_HolidayMstrReader["HOLIDAY_MASTER_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.CompanyCode = System.UInt64.Parse(lcl_obj_HolidayMstrReader["COMPANY_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.DecDate = System.DateTime.Parse(lcl_obj_HolidayMstrReader["DEC_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.NumOfDays = System.UInt16.Parse(lcl_obj_HolidayMstrReader["READER_CODE"].ToString());
               lcl_obj_HolidayMstrTmp.StartDate = System.DateTime.Parse(lcl_obj_HolidayMstrReader["END_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.EndDate = System.DateTime.Parse(lcl_obj_HolidayMstrReader["DEC_DATE"].ToString());
               lcl_obj_HolidayMstrTmp.Remarks = lcl_obj_HolidayMstrReader["REMARKS"].ToString();
               lcl_obj_HolidayMstrTmp.HolidayName = lcl_obj_HolidayMstrReader["HOLIDAY_NAME"].ToString();

               lcl_obj_HolidayMstrReader.Close();
               return lcl_obj_HolidayMstrTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_HolidayMstr;
       }

       public CCL.BusinessEntities.HRIS.HolidayMaster Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstr = null;
           lcl_obj_HolidayMstr = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>(() =>
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
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (HolidayMasterManager.Get(SqlQuery)) : No HolidayMaster Data Found In The Database!!!");
                   }
                   SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster lcl_obj_HolidayMstrTmp = new SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster();
                   lcl_obj_HolidayMstrTmp.HolidayMasterCode = System.UInt64.Parse(dr["HOLIDAY_MASTER_CODE"].ToString());
                   lcl_obj_HolidayMstrTmp.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                   lcl_obj_HolidayMstrTmp.DecDate = System.DateTime.Parse(dr["DEC_DATE"].ToString());
                   lcl_obj_HolidayMstrTmp.NumOfDays = System.UInt16.Parse(dr["READER_CODE"].ToString());
                   lcl_obj_HolidayMstrTmp.StartDate = System.DateTime.Parse(dr["END_DATE"].ToString());
                   lcl_obj_HolidayMstrTmp.EndDate = System.DateTime.Parse(dr["DEC_DATE"].ToString());
                   lcl_obj_HolidayMstrTmp.Remarks = dr["REMARKS"].ToString();
                   lcl_obj_HolidayMstrTmp.HolidayName = dr["HOLIDAY_NAME"].ToString();
                   dr.Close();
                   return lcl_obj_HolidayMstrTmp;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_HolidayMstr;
       }


       public ulong DeleteHoliday(System.UInt64  IP_ui64_holidayMstCode)
       {
           System.UInt64 IP_ui64_holidayMstCodeTemp = 0;
           IP_ui64_holidayMstCodeTemp = this.ExceptionManager.Process<System.UInt64>(() =>
           {

               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.String lcl_str_SqlQuery = System.String.Format(@"Update holiday_master Set  is_deleted=0 where holiday_master_code={0}", IP_ui64_holidayMstCode);
                   lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);

                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   lcl_obj_DBManager.InternalResource.Close();

                   return IP_ui64_holidayMstCodeTemp = IP_ui64_holidayMstCode;
               }
           }, "BMLExceptionPolicy");
           return IP_ui64_holidayMstCodeTemp;
       }
    }
}
