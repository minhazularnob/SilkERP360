using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.BML.HRIS
{
   public class EmployeeExperienceManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience>
    {
       public EmployeeExperienceManager()
       {
           this.Initialize();
       }



       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience lcl_obj_EmployeeExperience, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ExperienceCode = 0;

           lcl_ui64_ExperienceCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               OracleParameter lcl_obj_ExperienceCode = new OracleParameter("v_EXPERIENCE_CODE", OracleDbType.Int64);
               lcl_obj_ExperienceCode.Direction = System.Data.ParameterDirection.Output;


               OracleParameter lcl_obj_EmployerName = new OracleParameter("v_EMPLOYER_NAME", OracleDbType.NVarchar2, 100);
               lcl_obj_EmployerName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployerName.Value = lcl_obj_EmployeeExperience.EmployerName;

               OracleParameter lcl_obj_Address = new OracleParameter("v_ADDRESS", OracleDbType.NVarchar2, 200);
               lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Address.Value = lcl_obj_EmployeeExperience.Address;

               OracleParameter lcl_obj_ContactNo = new OracleParameter("v_CONTACT_NO", OracleDbType.NVarchar2, 50);
               lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ContactNo.Value = lcl_obj_EmployeeExperience.ContactNo;

               OracleParameter lcl_obj_NatureOfJob = new OracleParameter("v_NATURE_OF_JOB", OracleDbType.NVarchar2, 200);
               lcl_obj_NatureOfJob.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_NatureOfJob.Value = lcl_obj_EmployeeExperience.NatureOfJob;

               OracleParameter lcl_obj_Responsibility = new OracleParameter("v_RESPONSIBILITY", OracleDbType.NVarchar2, 200);
               lcl_obj_Responsibility.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Responsibility.Value = lcl_obj_EmployeeExperience.Responsibility;

               OracleParameter lcl_obj_FromDate = new OracleParameter("v_DATE_FROM", OracleDbType.Date);
               lcl_obj_FromDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_FromDate.Value = lcl_obj_EmployeeExperience.FromDate;

               OracleParameter lcl_obj_ToDate = new OracleParameter("v_DATE_TO", OracleDbType.Date);
               lcl_obj_ToDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ToDate.Value = lcl_obj_EmployeeExperience.ToDate;

               OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
               lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeExperience.EmployeeCode;

               OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_ISDELETED", OracleDbType.Int64);
               lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_IsDeleted.Value = 1;

               OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
               lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Status.Value =1;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ExperienceCode, lcl_obj_EmployerName, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_NatureOfJob, lcl_obj_Responsibility, lcl_obj_FromDate, lcl_obj_ToDate, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
               lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_EMPLOYEE_EXPERIENCE", lcl_obj_SP_Parameters);

               return System.UInt64.Parse(lcl_obj_ExperienceCode.Value.ToString());

           }, "BMLExceptionPolicy");

           return lcl_ui64_ExperienceCode;
       }
       public ulong update(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience lcl_obj_EmployeeExperience, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ExperienceCode = 0;

           lcl_ui64_ExperienceCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               OracleParameter lcl_obj_ExperienceCode = new OracleParameter("v_EXPERIENCE_CODE", OracleDbType.Int64);
               lcl_obj_ExperienceCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ExperienceCode.Value = lcl_obj_EmployeeExperience.ExperienceCode;

               OracleParameter lcl_obj_EmployerName = new OracleParameter("v_EMPLOYER_NAME", OracleDbType.NVarchar2, 100);
               lcl_obj_EmployerName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployerName.Value = lcl_obj_EmployeeExperience.EmployerName;

               OracleParameter lcl_obj_Address = new OracleParameter("v_ADDRESS", OracleDbType.NVarchar2, 200);
               lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Address.Value = lcl_obj_EmployeeExperience.Address;

               OracleParameter lcl_obj_ContactNo = new OracleParameter("v_CONTACT_NO", OracleDbType.NVarchar2, 50);
               lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ContactNo.Value = lcl_obj_EmployeeExperience.ContactNo;

               OracleParameter lcl_obj_NatureOfJob = new OracleParameter("v_NATURE_OF_JOB", OracleDbType.NVarchar2, 200);
               lcl_obj_NatureOfJob.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_NatureOfJob.Value = lcl_obj_EmployeeExperience.NatureOfJob;

               OracleParameter lcl_obj_Responsibility = new OracleParameter("v_RESPONSIBILITY", OracleDbType.NVarchar2, 200);
               lcl_obj_Responsibility.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Responsibility.Value = lcl_obj_EmployeeExperience.Responsibility;

               OracleParameter lcl_obj_FromDate = new OracleParameter("v_DATE_FROM", OracleDbType.Date);
               lcl_obj_FromDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_FromDate.Value = lcl_obj_EmployeeExperience.FromDate;

               OracleParameter lcl_obj_ToDate = new OracleParameter("v_DATE_TO", OracleDbType.Date);
               lcl_obj_ToDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ToDate.Value = lcl_obj_EmployeeExperience.ToDate;

               OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
               lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeExperience.EmployeeCode;

               OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_ISDELETED", OracleDbType.Int64);
               lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_IsDeleted.Value = 1;

               OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
               lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Status.Value = 1;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ExperienceCode, lcl_obj_EmployerName, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_NatureOfJob, lcl_obj_Responsibility, lcl_obj_FromDate, lcl_obj_ToDate, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
               lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_UPDT_EMPLOYEE_EXPERIENCE", lcl_obj_SP_Parameters);

               return System.UInt64.Parse(lcl_obj_ExperienceCode.Value.ToString());

           }, "BMLExceptionPolicy");

           return lcl_ui64_ExperienceCode;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="IP_obj_A"></param>
       /// <returns></returns>

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience lcl_obj_EmployeeExperience)
       {
           System.UInt64 lcl_ui64_ExperienceCode = 0;

            lcl_ui64_ExperienceCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    
                    OracleParameter lcl_obj_ExperienceCode = new OracleParameter("v_EXPERIENCE_CODE", OracleDbType.Int64);
                    lcl_obj_ExperienceCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ExperienceCode.Value = lcl_obj_EmployeeExperience.ExperienceCode;

                    OracleParameter lcl_obj_EmployerName = new OracleParameter("v_EMPLOYER_NAME", OracleDbType.NVarchar2, 100);
                    lcl_obj_EmployerName.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_EmployerName.Value = lcl_obj_EmployeeExperience.EmployerName;

                    OracleParameter lcl_obj_Address = new OracleParameter("v_ADDRESS", OracleDbType.NVarchar2, 200);
                    lcl_obj_Address.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Address.Value = lcl_obj_EmployeeExperience.Address;

                    OracleParameter lcl_obj_ContactNo = new OracleParameter("v_CONTACT_NO", OracleDbType.NVarchar2, 50);
                    lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_ContactNo.Value = lcl_obj_EmployeeExperience.ContactNo;

                    OracleParameter lcl_obj_NatureOfJob = new OracleParameter("v_NATURE_OF_JOB", OracleDbType.NVarchar2, 200);
                    lcl_obj_NatureOfJob.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_NatureOfJob.Value = lcl_obj_EmployeeExperience.NatureOfJob;

                    OracleParameter lcl_obj_Responsibility = new OracleParameter("v_RESPONSIBILITY", OracleDbType.NVarchar2, 200);
                    lcl_obj_Responsibility.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Responsibility.Value = lcl_obj_EmployeeExperience.Responsibility;

                    OracleParameter lcl_obj_FromDate = new OracleParameter("v_DATE_FROM", OracleDbType.Date);
                    lcl_obj_FromDate.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_FromDate.Value = lcl_obj_EmployeeExperience.FromDate;

                    OracleParameter lcl_obj_ToDate = new OracleParameter("v_DATE_TO", OracleDbType.Date);
                    lcl_obj_ToDate.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_ToDate.Value = lcl_obj_EmployeeExperience.ToDate;

                    OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeExperience.EmployeeCode;

                    OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_ISDELETED", OracleDbType.Int64);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = 1;

                    OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = 1;

                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ExperienceCode, lcl_obj_EmployerName, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_NatureOfJob, lcl_obj_Responsibility, lcl_obj_FromDate, lcl_obj_ToDate, lcl_obj_EmployeeCode };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("EMPLOYEE_REFERENCE_IU", lcl_obj_SP_Parameters);

                    return System.UInt64.Parse(lcl_obj_ExperienceCode.Value.ToString());
                }
           }, "BMLExceptionPolicy");

           return lcl_ui64_ExperienceCode;
       }

       public CCL.BusinessEntities.HRIS.EmployeeExperience Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.EmployeeExperience Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.EmployeeExperience Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.EmployeeExperience Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.HRIS.EmployeeExperience> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.HRIS.EmployeeExperience> GetList(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }
    }
}
