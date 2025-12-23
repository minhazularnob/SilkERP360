using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeReferenceManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference>
    {
        public EmployeeReferenceManager()
        {
            this.Initialize();
        }
        /// <summary>
        /// Save Method
        /// </summary>
        /// <param name="lcl_obj_EmployeeEducation"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference lcl_obj_EmployeeReference, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ReferenceCode = 0;

            lcl_ui64_ReferenceCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_ReferenceCode = new OracleParameter("v_REFERENCE_CODE", OracleDbType.Int64);
                lcl_obj_ReferenceCode.Direction = System.Data.ParameterDirection.Output;

                OracleParameter lcl_obj_Name = new OracleParameter("v_NAME", OracleDbType.NVarchar2, 256);
                lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Name.Value = lcl_obj_EmployeeReference.Name;

                OracleParameter lcl_obj_Address = new OracleParameter("v_ADDRESS", OracleDbType.NVarchar2, 200);
                lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Address.Value = lcl_obj_EmployeeReference.Address;

                OracleParameter lcl_obj_ContactNo = new OracleParameter("v_CONTACT_NO", OracleDbType.NVarchar2, 50);
                lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ContactNo.Value = lcl_obj_EmployeeReference.ContactNo;

                OracleParameter lcl_obj_Designation = new OracleParameter("v_DESIGNATION", OracleDbType.NVarchar2, 100);
                lcl_obj_Designation.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Designation.Value = lcl_obj_EmployeeReference.Designation;

                OracleParameter lcl_obj_CompanyOrganization = new OracleParameter("v_COMPANY_ORGANIZATION", OracleDbType.NVarchar2, 100);
                lcl_obj_CompanyOrganization.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyOrganization.Value = lcl_obj_EmployeeReference.CompanyOrganization;

                OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeReference.EmployeeCode;

                OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = 1;


                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ReferenceCode, lcl_obj_Name, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_Designation, lcl_obj_CompanyOrganization, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_REFERENCE_IU", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_ReferenceCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_ReferenceCode;
        }
        public ulong Update(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference lcl_obj_EmployeeReference, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ReferenceCode = 0;

            lcl_ui64_ReferenceCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_ReferenceCode = new OracleParameter("v_REFERENCE_CODE", OracleDbType.Int64);
                lcl_obj_ReferenceCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ReferenceCode.Value = lcl_obj_EmployeeReference.ReferenceCode;

                OracleParameter lcl_obj_Name = new OracleParameter("v_NAME", OracleDbType.NVarchar2, 256);
                lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Name.Value = lcl_obj_EmployeeReference.Name;

                OracleParameter lcl_obj_Address = new OracleParameter("v_ADDRESS", OracleDbType.NVarchar2, 200);
                lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Address.Value = lcl_obj_EmployeeReference.Address;

                OracleParameter lcl_obj_ContactNo = new OracleParameter("v_CONTACT_NO", OracleDbType.NVarchar2, 50);
                lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ContactNo.Value = lcl_obj_EmployeeReference.ContactNo;

                OracleParameter lcl_obj_Designation = new OracleParameter("v_DESIGNATION", OracleDbType.NVarchar2, 100);
                lcl_obj_Designation.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Designation.Value = lcl_obj_EmployeeReference.Designation;

                OracleParameter lcl_obj_CompanyOrganization = new OracleParameter("v_COMPANY_ORGANIZATION", OracleDbType.NVarchar2, 100);
                lcl_obj_CompanyOrganization.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyOrganization.Value = lcl_obj_EmployeeReference.CompanyOrganization;

                OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeReference.EmployeeCode;

                OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = 1;


                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ReferenceCode, lcl_obj_Name, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_Designation, lcl_obj_CompanyOrganization, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_UPDT_EMPLOYEE_REFERENCE", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_ReferenceCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_ReferenceCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference lcl_obj_EmployeeReference)
        {
             System.UInt64 lcl_ui64_ReferenceCode = 0;

            lcl_ui64_ReferenceCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_ReferenceCode = new OracleParameter("v_REFERENCE_CODE", OracleDbType.Int64);
                    lcl_obj_ReferenceCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ReferenceCode.Value = lcl_obj_EmployeeReference.ReferenceCode;

                    OracleParameter lcl_obj_Name = new OracleParameter("v_NAME", OracleDbType.NVarchar2, 256);
                    lcl_obj_Name.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Name.Value = lcl_obj_EmployeeReference.Name;

                    OracleParameter lcl_obj_Address = new OracleParameter("v_ADDRESS", OracleDbType.NVarchar2, 200);
                    lcl_obj_Address.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Address.Value = lcl_obj_EmployeeReference.Address;

                    OracleParameter lcl_obj_ContactNo = new OracleParameter("v_CONTACT_NO", OracleDbType.NVarchar2, 50);
                    lcl_obj_ContactNo.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_ContactNo.Value = lcl_obj_EmployeeReference.ContactNo;

                    OracleParameter lcl_obj_Designation = new OracleParameter("v_DESIGNATION", OracleDbType.NVarchar2, 100);
                    lcl_obj_Designation.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Designation.Value = lcl_obj_EmployeeReference.Designation;

                    OracleParameter lcl_obj_CompanyOrganization = new OracleParameter("v_COMPANY_ORGANIZATION", OracleDbType.NVarchar2, 100);
                    lcl_obj_CompanyOrganization.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_CompanyOrganization.Value = lcl_obj_EmployeeReference.CompanyOrganization;

                    OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.NVarchar2, 8);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeReference.EmployeeCode;

                    OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_IsDeleted.Value = lcl_obj_EmployeeReference.IsDeleted;

                    OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Status.Value = lcl_obj_EmployeeReference.Status;


                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ReferenceCode, lcl_obj_Name, lcl_obj_Address, lcl_obj_ContactNo, lcl_obj_Designation, lcl_obj_CompanyOrganization, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("EMPLOYEE_REFERENCE_IU", lcl_obj_SP_Parameters);

                    return System.UInt64.Parse(lcl_obj_ReferenceCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");

            return lcl_ui64_ReferenceCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>

        public CCL.BusinessEntities.HRIS.EmployeeReference Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {

            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeReference Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeReference Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeReference Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeReference> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeReference> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
