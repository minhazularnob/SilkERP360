using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
               System.Data.OracleClient.OracleParameter lcl_obj_ExperienceCode = new System.Data.OracleClient.OracleParameter("v_EXPERIENCE_CODE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_ExperienceCode.Direction = System.Data.ParameterDirection.Output;


               System.Data.OracleClient.OracleParameter lcl_obj_EmployerName = new System.Data.OracleClient.OracleParameter("v_EMPLOYER_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
               lcl_obj_EmployerName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployerName.Value = lcl_obj_EmployeeExperience.EmployerName;

               System.Data.OracleClient.OracleParameter lcl_obj_Address = new System.Data.OracleClient.OracleParameter("v_ADDRESS", System.Data.OracleClient.OracleType.NVarChar, 200);
               lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Address.Value = lcl_obj_EmployeeExperience.Address;

               System.Data.OracleClient.OracleParameter lcl_obj_ContactNo = new System.Data.OracleClient.OracleParameter("v_CONTACT_NO", System.Data.OracleClient.OracleType.NVarChar, 50);
               lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ContactNo.Value = lcl_obj_EmployeeExperience.ContactNo;

               System.Data.OracleClient.OracleParameter lcl_obj_NatureOfJob = new System.Data.OracleClient.OracleParameter("v_NATURE_OF_JOB", System.Data.OracleClient.OracleType.NVarChar, 200);
               lcl_obj_NatureOfJob.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_NatureOfJob.Value = lcl_obj_EmployeeExperience.NatureOfJob;

               System.Data.OracleClient.OracleParameter lcl_obj_Responsibility = new System.Data.OracleClient.OracleParameter("v_RESPONSIBILITY", System.Data.OracleClient.OracleType.NVarChar, 200);
               lcl_obj_Responsibility.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Responsibility.Value = lcl_obj_EmployeeExperience.Responsibility;

               System.Data.OracleClient.OracleParameter lcl_obj_FromDate = new System.Data.OracleClient.OracleParameter("v_DATE_FROM", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_FromDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_FromDate.Value = lcl_obj_EmployeeExperience.FromDate;

               System.Data.OracleClient.OracleParameter lcl_obj_ToDate = new System.Data.OracleClient.OracleParameter("v_DATE_TO", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_ToDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ToDate.Value = lcl_obj_EmployeeExperience.ToDate;

               System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeExperience.EmployeeCode;

               System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_ISDELETED", System.Data.OracleClient.OracleType.Number);
               lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_IsDeleted.Value = 1;

               System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
               lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Status.Value =1;

               System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ExperienceCode, lcl_obj_EmployerName, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_NatureOfJob, lcl_obj_Responsibility, lcl_obj_FromDate, lcl_obj_ToDate, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
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
               System.Data.OracleClient.OracleParameter lcl_obj_ExperienceCode = new System.Data.OracleClient.OracleParameter("v_EXPERIENCE_CODE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_ExperienceCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ExperienceCode.Value = lcl_obj_EmployeeExperience.ExperienceCode;

               System.Data.OracleClient.OracleParameter lcl_obj_EmployerName = new System.Data.OracleClient.OracleParameter("v_EMPLOYER_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
               lcl_obj_EmployerName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployerName.Value = lcl_obj_EmployeeExperience.EmployerName;

               System.Data.OracleClient.OracleParameter lcl_obj_Address = new System.Data.OracleClient.OracleParameter("v_ADDRESS", System.Data.OracleClient.OracleType.NVarChar, 200);
               lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Address.Value = lcl_obj_EmployeeExperience.Address;

               System.Data.OracleClient.OracleParameter lcl_obj_ContactNo = new System.Data.OracleClient.OracleParameter("v_CONTACT_NO", System.Data.OracleClient.OracleType.NVarChar, 50);
               lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ContactNo.Value = lcl_obj_EmployeeExperience.ContactNo;

               System.Data.OracleClient.OracleParameter lcl_obj_NatureOfJob = new System.Data.OracleClient.OracleParameter("v_NATURE_OF_JOB", System.Data.OracleClient.OracleType.NVarChar, 200);
               lcl_obj_NatureOfJob.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_NatureOfJob.Value = lcl_obj_EmployeeExperience.NatureOfJob;

               System.Data.OracleClient.OracleParameter lcl_obj_Responsibility = new System.Data.OracleClient.OracleParameter("v_RESPONSIBILITY", System.Data.OracleClient.OracleType.NVarChar, 200);
               lcl_obj_Responsibility.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Responsibility.Value = lcl_obj_EmployeeExperience.Responsibility;

               System.Data.OracleClient.OracleParameter lcl_obj_FromDate = new System.Data.OracleClient.OracleParameter("v_DATE_FROM", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_FromDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_FromDate.Value = lcl_obj_EmployeeExperience.FromDate;

               System.Data.OracleClient.OracleParameter lcl_obj_ToDate = new System.Data.OracleClient.OracleParameter("v_DATE_TO", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_ToDate.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ToDate.Value = lcl_obj_EmployeeExperience.ToDate;

               System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
               lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeExperience.EmployeeCode;

               System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_ISDELETED", System.Data.OracleClient.OracleType.Number);
               lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_IsDeleted.Value = 1;

               System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
               lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Status.Value = 1;

               System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ExperienceCode, lcl_obj_EmployerName, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_NatureOfJob, lcl_obj_Responsibility, lcl_obj_FromDate, lcl_obj_ToDate, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
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
                    
                    System.Data.OracleClient.OracleParameter lcl_obj_ExperienceCode = new System.Data.OracleClient.OracleParameter("v_EXPERIENCE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ExperienceCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ExperienceCode.Value = lcl_obj_EmployeeExperience.ExperienceCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_EmployerName = new System.Data.OracleClient.OracleParameter("v_EMPLOYER_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                    lcl_obj_EmployerName.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_EmployerName.Value = lcl_obj_EmployeeExperience.EmployerName;

                    System.Data.OracleClient.OracleParameter lcl_obj_Address = new System.Data.OracleClient.OracleParameter("v_ADDRESS", System.Data.OracleClient.OracleType.NVarChar, 200);
                    lcl_obj_Address.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Address.Value = lcl_obj_EmployeeExperience.Address;

                    System.Data.OracleClient.OracleParameter lcl_obj_ContactNo = new System.Data.OracleClient.OracleParameter("v_CONTACT_NO", System.Data.OracleClient.OracleType.NVarChar, 50);
                    lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_ContactNo.Value = lcl_obj_EmployeeExperience.ContactNo;

                    System.Data.OracleClient.OracleParameter lcl_obj_NatureOfJob = new System.Data.OracleClient.OracleParameter("v_NATURE_OF_JOB", System.Data.OracleClient.OracleType.NVarChar, 200);
                    lcl_obj_NatureOfJob.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_NatureOfJob.Value = lcl_obj_EmployeeExperience.NatureOfJob;

                    System.Data.OracleClient.OracleParameter lcl_obj_Responsibility = new System.Data.OracleClient.OracleParameter("v_RESPONSIBILITY", System.Data.OracleClient.OracleType.NVarChar, 200);
                    lcl_obj_Responsibility.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Responsibility.Value = lcl_obj_EmployeeExperience.Responsibility;

                    System.Data.OracleClient.OracleParameter lcl_obj_FromDate = new System.Data.OracleClient.OracleParameter("v_DATE_FROM", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_FromDate.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_FromDate.Value = lcl_obj_EmployeeExperience.FromDate;

                    System.Data.OracleClient.OracleParameter lcl_obj_ToDate = new System.Data.OracleClient.OracleParameter("v_DATE_TO", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_ToDate.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_ToDate.Value = lcl_obj_EmployeeExperience.ToDate;

                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeExperience.EmployeeCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_ISDELETED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = 1;

                    System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = 1;

                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ExperienceCode, lcl_obj_EmployerName, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_NatureOfJob, lcl_obj_Responsibility, lcl_obj_FromDate, lcl_obj_ToDate, lcl_obj_EmployeeCode };
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
