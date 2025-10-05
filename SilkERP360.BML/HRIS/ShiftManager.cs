using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class ShiftManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Shift>

    {
       public ShiftManager()
       {
           this.Initialize();
       }


       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ShiftCode = 0;

           lcl_ui64_ShiftCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;


               System.Data.OracleClient.OracleParameter lcl_obj_hiftCode = new System.Data.OracleClient.OracleParameter("v_ShiftCode", System.Data.OracleClient.OracleType.Number);
               lcl_obj_hiftCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_hiftCode.Value = lcl_obj_Shift.ShiftCode;

               System.Data.OracleClient.OracleParameter lcl_obj_ShiftName = new System.Data.OracleClient.OracleParameter("v_ShiftName", System.Data.OracleClient.OracleType.NVarChar, 20);
               lcl_obj_ShiftName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ShiftName.Value = lcl_obj_Shift.ShiftName;

               System.Data.OracleClient.OracleParameter lcl_obj_StartTime = new System.Data.OracleClient.OracleParameter("v_StartTime", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_StartTime.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_StartTime.Value = lcl_obj_Shift.StartTime;

               System.Data.OracleClient.OracleParameter lcl_obj_EndTime = new System.Data.OracleClient.OracleParameter("v_EndTime", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_EndTime.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EndTime.Value = lcl_obj_Shift.EndTime;

               System.Data.OracleClient.OracleParameter lcl_obj_ToleranceTime = new System.Data.OracleClient.OracleParameter("v_ToleranceTime", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_ToleranceTime.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ToleranceTime.Value = lcl_obj_Shift.ToleranceTime;

               System.Data.OracleClient.OracleParameter lcl_obj_SortOrder = new System.Data.OracleClient.OracleParameter("v_SortOrder", System.Data.OracleClient.OracleType.Number);
               lcl_obj_SortOrder.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_SortOrder.Value = lcl_obj_Shift.SortOrder;

               System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("v_CompanyCode", System.Data.OracleClient.OracleType.Number);
               lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_CompanyCode.Value = lcl_obj_Shift.CompanyCode;

               System.Data.OracleClient.OracleParameter lcl_obj_RegularDutyHour = new System.Data.OracleClient.OracleParameter("v_RegularDutyHour", System.Data.OracleClient.OracleType.Number);
               lcl_obj_RegularDutyHour.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_RegularDutyHour.Value = lcl_obj_Shift.RegularDutyHour;

               System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IsDeleted", System.Data.OracleClient.OracleType.Number);
               lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_IsDeleted.Value = 1;

               System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_Status", System.Data.OracleClient.OracleType.Number);
               lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Status.Value = 1;

               System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_hiftCode, lcl_obj_ShiftName, lcl_obj_StartTime, lcl_obj_EndTime, lcl_obj_ToleranceTime, lcl_obj_SortOrder, lcl_obj_CompanyCode, lcl_obj_RegularDutyHour, lcl_obj_IsDeleted, lcl_obj_Status };
               lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_SHIFT", lcl_obj_SP_Parameters);
               return System.UInt64.Parse(lcl_obj_hiftCode.Value.ToString());
           }, "BMLExceptionPolicy");
           return lcl_ui64_ShiftCode;
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift)
       {
          System.UInt64 lcl_ui64_ShiftCode = 0;

           lcl_ui64_ShiftCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                   using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                   {
                       if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                       {
                           lcl_obj_DBManager.InternalResource.Open();
                       }
                       System.Data.OracleClient.OracleParameter lcl_obj_shiftCode = new System.Data.OracleClient.OracleParameter("v_ShiftCode", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_shiftCode.Direction = System.Data.ParameterDirection.Output;
                      // lcl_obj_hiftCode.Value = lcl_obj_Shift.ShiftCode;

                       System.Data.OracleClient.OracleParameter lcl_obj_ShiftName = new System.Data.OracleClient.OracleParameter("v_ShiftName", System.Data.OracleClient.OracleType.NVarChar, 20);
                       lcl_obj_ShiftName.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_ShiftName.Value = lcl_obj_Shift.ShiftName;

                       System.Data.OracleClient.OracleParameter lcl_obj_StartTime = new System.Data.OracleClient.OracleParameter("v_StartTime", System.Data.OracleClient.OracleType.DateTime);
                       lcl_obj_StartTime.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_StartTime.Value = lcl_obj_Shift.StartTime;

                       System.Data.OracleClient.OracleParameter lcl_obj_EndTime = new System.Data.OracleClient.OracleParameter("v_EndTime", System.Data.OracleClient.OracleType.DateTime);
                       lcl_obj_EndTime.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_EndTime.Value = lcl_obj_Shift.EndTime;

                       System.Data.OracleClient.OracleParameter lcl_obj_ToleranceTime = new System.Data.OracleClient.OracleParameter("v_ToleranceTime", System.Data.OracleClient.OracleType.DateTime);
                       lcl_obj_ToleranceTime.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_ToleranceTime.Value = lcl_obj_Shift.ToleranceTime;

                       System.Data.OracleClient.OracleParameter lcl_obj_SortOrder = new System.Data.OracleClient.OracleParameter("v_SortOrder", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_SortOrder.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_SortOrder.Value = lcl_obj_Shift.SortOrder;

                       System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("v_CompanyCode", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_CompanyCode.Value = lcl_obj_Shift.CompanyCode;

                       System.Data.OracleClient.OracleParameter lcl_obj_RegularDutyHour = new System.Data.OracleClient.OracleParameter("v_RegularDutyHour", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_RegularDutyHour.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_RegularDutyHour.Value = lcl_obj_Shift.RegularDutyHour;

                       System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IsDeleted", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_IsDeleted.Value = 1;

                       System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_Status", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_Status.Value = 1;

                       System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_shiftCode, lcl_obj_ShiftName, lcl_obj_StartTime, lcl_obj_EndTime, lcl_obj_ToleranceTime, lcl_obj_SortOrder, lcl_obj_CompanyCode, lcl_obj_RegularDutyHour, lcl_obj_IsDeleted, lcl_obj_Status };
                       lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INS_SHIFT", lcl_obj_SP_Parameters);

                       lcl_obj_DBManager.InternalResource.CommitTransaction();
                       lcl_obj_DBManager.InternalResource.Close();
                       return System.UInt64.Parse(lcl_obj_shiftCode.Value.ToString());
                   }
           }, "BMLExceptionPolicy");
           return lcl_ui64_ShiftCode;

       }

       public CCL.BusinessEntities.HRIS.Shift Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift = null;

           lcl_obj_Shift = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Shift>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From SHIFT Where SHIFT_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_ShiftReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_ShiftReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error ShiftManager.Get(ID,DBManger)) : Error Retrieving Shift Data!");
               }
               lcl_obj_ShiftReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_ShiftTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Shift();
               lcl_obj_ShiftTmp.ShiftCode = System.UInt64.Parse(lcl_obj_ShiftReader["SHIFT_CODE"].ToString());
               lcl_obj_ShiftTmp.ShiftName = lcl_obj_ShiftReader["SHIFT_NAME"].ToString();
               lcl_obj_ShiftTmp.StartTime = System.DateTime.Parse(lcl_obj_ShiftReader["START_TIME"].ToString());
               lcl_obj_ShiftTmp.EndTime = System.DateTime.Parse(lcl_obj_ShiftReader["END_TIME"].ToString());
               lcl_obj_ShiftTmp.ToleranceTime = System.DateTime.Parse(lcl_obj_ShiftReader["TOLERANCE_TIME"].ToString());
               lcl_obj_ShiftTmp.SortOrder = System.UInt32  .Parse(lcl_obj_ShiftReader["SORT_ORDER"].ToString());
               lcl_obj_ShiftTmp.CompanyCode = System.UInt64.Parse(lcl_obj_ShiftReader["COMPANY_CODE"].ToString());
               lcl_obj_ShiftTmp.RegularDutyHour = System.UInt16.Parse(lcl_obj_ShiftReader["REGULAR_DUTY_HOUR"].ToString());
               lcl_obj_ShiftReader.Close();
               return lcl_obj_ShiftTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_Shift;
       }

       public CCL.BusinessEntities.HRIS.Shift Get(ulong IP_ui64_Code)
       {
          SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift = null;

           lcl_obj_Shift = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Shift>(() =>
                {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From SHIFT Where SHIFT_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
       if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ShiftManager.Get(ID)) : No Shift Data Found In The Database!!!");
                    }
               SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_ShiftTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Shift();
               lcl_obj_ShiftTmp.ShiftCode = System.UInt64.Parse(dr["SHIFT_CODE"].ToString());
               lcl_obj_ShiftTmp.ShiftName = dr["SHIFT_NAME"].ToString();
               lcl_obj_ShiftTmp.StartTime = System.DateTime.Parse(dr["START_TIME"].ToString());
               lcl_obj_ShiftTmp.EndTime = System.DateTime.Parse(dr["END_TIME"].ToString());
               lcl_obj_ShiftTmp.ToleranceTime = System.DateTime.Parse(dr["TOLERANCE_TIME"].ToString());
               lcl_obj_ShiftTmp.SortOrder = System.UInt32.Parse(dr["SORT_ORDER"].ToString());
               lcl_obj_ShiftTmp.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
               lcl_obj_ShiftTmp.RegularDutyHour = System.UInt16.Parse(dr["REGULAR_DUTY_HOUR"].ToString());
               dr.Close();
               return lcl_obj_ShiftTmp;
                }
                }, "BMLExceptionPolicy");
           return lcl_obj_Shift;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift> lcl_objLst_Shift = null;
            
            lcl_objLst_Shift = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ShiftManager.GetList(SqlQuery,DBManager)) : No Shift Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift> lcl_objLst_ShiftTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift = new SilkERP360.CCL.BusinessEntities.HRIS.Shift();
               lcl_obj_Shift.ShiftCode = System.UInt64.Parse(dr["SHIFT_CODE"].ToString());
               lcl_obj_Shift.ShiftName = dr["SHIFT_NAME"].ToString();
               lcl_obj_Shift.StartTime = System.DateTime.Parse(dr["START_TIME"].ToString());
               lcl_obj_Shift.EndTime = System.DateTime.Parse(dr["END_TIME"].ToString());
               lcl_obj_Shift.ToleranceTime = System.DateTime.Parse(dr["TOLERANCE_TIME"].ToString());
               lcl_obj_Shift.SortOrder = System.UInt32.Parse(dr["SORT_ORDER"].ToString());
               lcl_obj_Shift.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
               lcl_obj_Shift.RegularDutyHour = System.UInt16.Parse(dr["REGULAR_DUTY_HOUR"].ToString());                    
               lcl_objLst_ShiftTmp.Add(lcl_obj_Shift);
                }
                dr.Close();
                return lcl_objLst_ShiftTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_Shift;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift> GetList(string IP_str_SqlQuery)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift> lcl_objLst_Shift = null;
            lcl_objLst_Shift = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift>>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.InternalResource.Open();
                        }

                        System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                        if (!(dr.HasRows))
                        {
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ShiftManager.GetList(SqlQuery)) : No Shift Data Found In The Database!!!");
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift> lcl_objLst_ShiftTmp = new
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Shift>();
                        while (dr.Read())
                        {
               SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift = new SilkERP360.CCL.BusinessEntities.HRIS.Shift();
               lcl_obj_Shift.ShiftCode = System.UInt64.Parse(dr["SHIFT_CODE"].ToString());
               lcl_obj_Shift.ShiftName = dr["SHIFT_NAME"].ToString();
               lcl_obj_Shift.StartTime = System.DateTime.Parse(dr["START_TIME"].ToString());
               lcl_obj_Shift.EndTime = System.DateTime.Parse(dr["END_TIME"].ToString());
               lcl_obj_Shift.ToleranceTime = System.DateTime.Parse(dr["TOLERANCE_TIME"].ToString());
               lcl_obj_Shift.SortOrder = System.UInt32.Parse(dr["SORT_ORDER"].ToString());
               lcl_obj_Shift.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
               lcl_obj_Shift.RegularDutyHour = System.UInt16.Parse(dr["REGULAR_DUTY_HOUR"].ToString());                            
               lcl_objLst_ShiftTmp.Add(lcl_obj_Shift);
                        }
                        dr.Close();
                        return lcl_objLst_ShiftTmp;
                    }
                }, "BMLExceptionPolicy");
            return lcl_objLst_Shift;
       }

       public CCL.BusinessEntities.HRIS.Shift Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {

           SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift = null;         
            lcl_obj_Shift = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Shift>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_ShiftReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_ShiftReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error ShiftManager.Get(SqlQuery,DBManger)) : Error Retrieving Shift Data!");
                }
                lcl_obj_ShiftReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_ShiftTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Shift();
               lcl_obj_ShiftTmp.ShiftCode = System.UInt64.Parse(lcl_obj_ShiftReader["SHIFT_CODE"].ToString());
               lcl_obj_ShiftTmp.ShiftName = lcl_obj_ShiftReader["SHIFT_NAME"].ToString();
               lcl_obj_ShiftTmp.StartTime = System.DateTime.Parse(lcl_obj_ShiftReader["START_TIME"].ToString());
               lcl_obj_ShiftTmp.EndTime = System.DateTime.Parse(lcl_obj_ShiftReader["END_TIME"].ToString());
               lcl_obj_ShiftTmp.ToleranceTime = System.DateTime.Parse(lcl_obj_ShiftReader["TOLERANCE_TIME"].ToString());
               lcl_obj_ShiftTmp.SortOrder = System.UInt32.Parse(lcl_obj_ShiftReader["SORT_ORDER"].ToString());
               lcl_obj_ShiftTmp.CompanyCode = System.UInt64.Parse(lcl_obj_ShiftReader["COMPANY_CODE"].ToString());
               lcl_obj_ShiftTmp.RegularDutyHour = System.UInt16.Parse(lcl_obj_ShiftReader["REGULAR_DUTY_HOUR"].ToString());                
                lcl_obj_ShiftReader.Close();
                return lcl_obj_ShiftTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Shift;
       }

       public CCL.BusinessEntities.HRIS.Shift Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_Shift = null;
            lcl_obj_Shift = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Shift>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(IP_str_SqlQuery));
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ShiftManager.Get(SqlQuery)) : No Shift Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Shift lcl_obj_ShiftTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Shift();
               lcl_obj_ShiftTmp.ShiftCode = System.UInt64.Parse(dr["SHIFT_CODE"].ToString());
               lcl_obj_ShiftTmp.ShiftName = dr["SHIFT_NAME"].ToString();
               lcl_obj_ShiftTmp.StartTime = System.DateTime.Parse(dr["START_TIME"].ToString());
               lcl_obj_ShiftTmp.EndTime = System.DateTime.Parse(dr["END_TIME"].ToString());
               lcl_obj_ShiftTmp.ToleranceTime = System.DateTime.Parse(dr["TOLERANCE_TIME"].ToString());
               lcl_obj_ShiftTmp.SortOrder = System.UInt32.Parse(dr["SORT_ORDER"].ToString());
               lcl_obj_ShiftTmp.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
               lcl_obj_ShiftTmp.RegularDutyHour = System.UInt16.Parse(dr["REGULAR_DUTY_HOUR"].ToString());                    
                    dr.Close();
                    return lcl_obj_ShiftTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Shift;
       }
    }
}
