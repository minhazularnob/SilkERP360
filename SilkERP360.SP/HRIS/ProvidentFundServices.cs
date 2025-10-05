using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class ProvidentFundServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public ProvidentFundServices()
        {
            this.Initialize();
        }


        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile GetProvidentFundProfileAndTransactionsListByEmployeeCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfileTmp = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_DBQuery = System.String.Format(@"SELECT EMP.*,PFA.*,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,IS_DELETED
                                                                        FROM EMPLOYEE EMP
                                                                        JOIN EMPLOYEE_PERSONAL EMP_P
                                                                        ON EMP.EMPLOYEE_CODE = EMP_P.EMPLOYEE_CODE 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        join PF_ACCOUNT PFA
                                                                        ON EMP.EMPLOYEE_CODE = PFA.EMPLOYEE_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE PFA.EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);

                    SilkERP360.BML.HRIS.DataStructures.EmployeeProvidentFundProfileManager lcl_obj_EmployeeProvidentFundProfileManager = new BML.HRIS.DataStructures.EmployeeProvidentFundProfileManager();
                    lcl_obj_EmployeeProvidentFundProfileManager.Initialize();

                    lcl_obj_EmployeeProvidentFundProfileTmp = lcl_obj_EmployeeProvidentFundProfileManager.Get(lcl_str_DBQuery, lcl_obj_DBManager.InternalResource);
                    if (lcl_obj_EmployeeProvidentFundProfileTmp == null)
                    {
                        return null;
                    }
                    //Get PFAccountTransaction for each account
                    return lcl_obj_EmployeeProvidentFundProfileTmp;
                }

            }, "SPExceptionPolicy");
            return lcl_obj_EmployeeProvidentFundProfile;
        }


        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> GetAllProvidentFundProfileAndTransactionsByAllDurationForCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileTmp = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                     System.String lcl_str_DBQuery = System.String.Format(@"SELECT EMP.*,PFA.*,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,IS_DELETED
                                                                        FROM EMPLOYEE EMP
                                                                        JOIN EMPLOYEE_PERSONAL EMP_P
                                                                        ON EMP.EMPLOYEE_CODE = EMP_P.EMPLOYEE_CODE 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        join PF_ACCOUNT PFA
                                                                        ON EMP.EMPLOYEE_CODE = PFA.EMPLOYEE_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE COMP.COMPANY_CODE = {0}", IP_ui64_CompanyCode);
                    //Get PF Accounts for Provided Company
//                    lcl_str_DBQuery = System.String.Format(@"select EMP.*,PFA.PF_ACCOUNT_NUMBER  
//                                                                         from EMPLOYEE EMP join COMPANY COMP 
//                                                                         on EMP.COMPANY_CODE = COMP.COMPANY_CODE
//                                                                         join PF_ACCOUNT PFA
//                                                                         ON EMP.EMPLOYEE_CODE = PFA.EMPLOYEE_CODE
//                                                                         WHERE COMP.COMPANY_CODE = {0}", IP_ui64_CompanyCode);

                    SilkERP360.BML.HRIS.DataStructures.EmployeeProvidentFundProfileManager lcl_obj_EmployeeProvidentFundProfileManager = new BML.HRIS.DataStructures.EmployeeProvidentFundProfileManager();
                    lcl_obj_EmployeeProvidentFundProfileManager.Initialize();

                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileListTmp = lcl_obj_EmployeeProvidentFundProfileManager.GetList(lcl_str_DBQuery, lcl_obj_DBManager.InternalResource);
                    if (lcl_objLst_EmployeeProvidentFundProfileListTmp.Count == 0)
                    {
                        return lcl_objLst_EmployeeProvidentFundProfileListTmp;
                    }
                    //Get PFAccountTransaction for each account
                    BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransactionManager = new BML.HRIS.PFAccountTransactionManager();
                    lcl_obj_PFAccountTransactionManager.Initialize();
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfile in lcl_objLst_EmployeeProvidentFundProfileListTmp)
                    {
                        //lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList = new List<CCL.BusinessEntities.HRIS.PFAccountTransaction>();
                        lcl_str_DBQuery = System.String.Format("select * from PF_ACCOUNT_TRANSACTION where PF_ACCOUNT_NUMBER = {0}", lcl_obj_EmployeeProvidentFundProfile.PFAccountNumber);
                        lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList = lcl_obj_PFAccountTransactionManager.GetList(lcl_str_DBQuery, lcl_obj_DBManager.InternalResource);

                    }

                    return lcl_objLst_EmployeeProvidentFundProfileListTmp;
                }

            }, "SPExceptionPolicy");
            return lcl_objLst_EmployeeProvidentFundProfileList;
        }


        /// <summary>
        /// Provide All PF Transactions of all PF Accounts of Provided company
        /// By Provided Month & Year
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_enm_Month"></param>
        /// <param name="IP_ui16_Year"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> GetAllProvidentFundProfileAndTransactionsByMonthAndYearForCompany(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_Month, System.UInt16 IP_ui16_Year)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileTmp = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    //Get PF Accounts for Provided Company
                    System.String lcl_str_DBQuery = System.String.Format(@"select EMP.*,PFA.PF_ACCOUNT_NUMBER  
                                                                         from EMPLOYEE EMP join COMPANY COMP 
                                                                         on EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                         join PF_ACCOUNT PFA
                                                                         ON EMP.EMPLOYEE_CODE = PFA.EMPLOYEE_CODE
                                                                         WHERE COMP.COMPANY_CODE = {0}", IP_ui64_CompanyCode);

                    SilkERP360.BML.HRIS.DataStructures.EmployeeProvidentFundProfileManager lcl_obj_EmployeeProvidentFundProfileManager = new BML.HRIS.DataStructures.EmployeeProvidentFundProfileManager();
                    lcl_obj_EmployeeProvidentFundProfileManager.Initialize();

                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileListTmp = lcl_obj_EmployeeProvidentFundProfileManager.GetList(lcl_str_DBQuery, lcl_obj_DBManager.InternalResource);
                    //Get PFAccountTransaction for each account
                    BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransactionManager = new BML.HRIS.PFAccountTransactionManager();
                    lcl_obj_PFAccountTransactionManager.Initialize();
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfile in lcl_objLst_EmployeeProvidentFundProfileListTmp)
                    {
                        //lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList = new List<CCL.BusinessEntities.HRIS.PFAccountTransaction>();
                        lcl_str_DBQuery = System.String.Format("select * from PF_ACCOUNT_TRANSACTION where PF_ACCOUNT_NUMBER = {0} and TRANSACTION_MONTH = {1} and TRANSACTION_YEAR = {2}", lcl_obj_EmployeeProvidentFundProfile.PFAccountNumber, (UInt16)IP_enm_Month, (UInt16)IP_ui16_Year);
                        lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList = lcl_obj_PFAccountTransactionManager.GetList(lcl_str_DBQuery, lcl_obj_DBManager.InternalResource);

                    }

                    return lcl_objLst_EmployeeProvidentFundProfileListTmp;
                }

            }, "SPExceptionPolicy");
            return lcl_objLst_EmployeeProvidentFundProfileList;
        }


        /// <summary>
        /// Returns All PF Transaction by Provided PF AccountNumber of All Month & Year
        /// </summary>
        /// <param name="IP_ui64_PFAccountNumber"></param>
        /// <returns></returns>
        public SilkERP360.CCL.Misc.WSResponse GetAllProvidentFundTransactionsByPFAccount(System.UInt64 IP_ui64_PFAccountNumber)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponseTmp = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                }
                return lcl_obj_WSResponseTmp;
            }, "SPExceptionPolicy");
            return lcl_obj_WSResponse;
        }
    }
}

