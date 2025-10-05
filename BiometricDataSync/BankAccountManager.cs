using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    
    public class BankAccountManager
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        

       

        public BankAccountManager()
        {
        }

        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            
            try
            {
                this.m_obj_DBManager = new SilkERP360.DAL.DBManager(IP_str_DatabaseConnectionString);
                this.m_obj_DBManager.Initialize();
            }
            catch (System.Exception Ex)
            {
                
            }
        }

        public void Init(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            
            try
            {
                this.m_obj_DBManager = IP_obj_DBManager;
            }
            catch (System.Exception Ex)
            {
                //this.m_obj_ServiceLog.LogData("Initialization Error : " + Ex.Message);
            }
        }

        public void UpdateBankAccount(System.UInt64 IP_ui64_CompanyCode,System.String IP_str_BankAccountCSVFile)
        {
            try
            {
                if (IP_ui64_CompanyCode == 110000000002)
                {
                    return;
                }
                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,EMP.IS_UNIFORM_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,0 IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN EMPLOYEE_PERSONAL EMP_PER
                                                                        ON EMP.EMPLOYEE_CODE = EMP_PER.EMPLOYEE_CODE
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        WHERE EMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) Order By DEPT.Rank,DESIG.Rank ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, this.m_obj_DBManager);

                
                #region BANK_ACCOUNT
                System.Collections.Generic.List<System.String> lcl_strLst_BAccountSQLUpdateQuery = new List<string>();
                using (System.IO.StreamReader lcl_obj_BAccountSR = new System.IO.StreamReader(IP_str_BankAccountCSVFile))
                {
                    while (!(lcl_obj_BAccountSR.EndOfStream))
                    {
                        System.String lcl_str_BAccountFileLine = lcl_obj_BAccountSR.ReadLine();
                        System.String[] lcl_arr_lcl_str_BAccountFileLineSegments = lcl_str_BAccountFileLine.Split(',');
                        System.String lcl_str_EmployeeID = lcl_arr_lcl_str_BAccountFileLineSegments[0].Trim();
                        System.String lcl_str_BAccountNo = lcl_arr_lcl_str_BAccountFileLineSegments[1].Trim();
                        var lcl_obj_EmployeeProfileSorted =
                                               from Emp in lcl_objLst_EmployeeProfile
                                               where Emp.EmployeeID.Trim().Equals(lcl_str_EmployeeID.Trim())
                                               select Emp;

                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                        if (lcl_obj_EmployeeProfileSorted.Count<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>() == 0)
                        {
                            //Employee Does Not Exist in the PF List from DB
                            //lcl_strLst_InvalidEmployeeIds.Add("Inavlid Employee Id : " + lcl_str_EmployeeID);
                            Console.WriteLine("Inavlid Employee Id : " + lcl_str_EmployeeID);
                            //continue;
                        }
                        else
                        {
                            foreach (var lcl_obj_EmployeeProfileTmp in lcl_obj_EmployeeProfileSorted)
                            {
                                lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileTmp;
                            }
                            //System.String lcl_str_BAccountUpdateSQLQuery = System.String.Format("UPDATE EMPLOYEE SET BANK_NAME = 'JAMUNA BANK LTD', BANK_ACCOUNT_NO = '{0}' WHERE EMPLOYEE_CODE = {1}", lcl_str_BAccountNo, lcl_obj_EmployeeProfile.EmployeeCode);
                            System.String lcl_str_BAccountUpdateSQLQuery = System.String.Format("UPDATE EMPLOYEE SET BANK_NAME = '', BANK_ACCOUNT_NO = '{0}' WHERE EMPLOYEE_CODE = {1}", "", lcl_obj_EmployeeProfile.EmployeeCode);
                            lcl_strLst_BAccountSQLUpdateQuery.Add(lcl_str_BAccountUpdateSQLQuery);
                        }
                    }
                    lcl_obj_BAccountSR.Close();
                }

                //this.m_obj_DBManager.Open();

                foreach (System.String lcl_str_SQLUpdate in lcl_strLst_BAccountSQLUpdateQuery)
                {
                    //this.m_obj_DBManager.ExecuteNonQuery(lcl_str_SQLUpdate);
                }


                #endregion



                
                // ************************* SSL 20161128, 2 ******************
                //this.m_obj_DBManager.CommitTransaction();
                this.m_obj_DBManager.Close();
                int a = 0;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
