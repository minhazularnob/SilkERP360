using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.Services.HRIS
{
    public class EmployeeServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeServices()
        {
            this.Initialize();
        }

        /// <summary>
        /// //
        /// </summary>
        /// <param name="IP_ui64_EmployeeCode"></param>
        /// <param name="IP_obj_DBmanager"></param>
        /// <returns>If Employee Non-Existant-> Returns DateTime.MinValue</returns>
        public System.DateTime GetJoiningDate(System.UInt64 IP_ui64_EmployeeCode, DAL.DBManager IP_obj_DBmanager)
        {
            System.DateTime lcl_dt_Resonse = this.ExceptionManager.Process<System.DateTime>(() =>
            {
                if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBmanager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT JOINING_DATE FROM EMPLOYEE WHERE EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = IP_obj_DBmanager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeReader.HasRows))
                {
                    lcl_obj_EmployeeReader.Close();
                    return System.DateTime.MinValue;
                }
                lcl_obj_EmployeeReader.Read();
                System.DateTime lcl_dt_Response = System.DateTime.Parse(lcl_obj_EmployeeReader["JOINING_DATE"].ToString());
                lcl_obj_EmployeeReader.Close();
                return lcl_dt_Response;
            }, "BMLExceptionPolicy");
            return lcl_dt_Resonse;
        }

        /// <summary>
        /// If Emp is eligible->Has active entry in Monthly_Allowance Table -> Return Allowance else 0 
        /// </summary>
        /// <param name="IP_ui64_EmployeeCode"></param>
        /// <param name="IP_obj_DBmanager"></param>
        /// <returns></returns>
        public System.Decimal GetMonthlyAllowance(System.UInt64 IP_ui64_EmployeeCode, DAL.DBManager IP_obj_DBmanager)
        {
            System.Decimal MonthlyAllowance = this.ExceptionManager.Process<System.Decimal>(() =>
            {
                if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBmanager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT AMOUNT FROM MONTHLY_ALLOWANCE WHERE EMPLOYEE_CODE = {0} AND STATUS = {1}", IP_ui64_EmployeeCode,(System.Int16)CCL.Enums.YesNo.Yes);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = IP_obj_DBmanager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeReader.HasRows))
                {
                    lcl_obj_EmployeeReader.Close();
                    return 0;
                }
                lcl_obj_EmployeeReader.Read();
                System.Decimal lcl_dbl_MonthlyAllowance = System.Math.Round(System.Decimal.Parse(lcl_obj_EmployeeReader["AMOUNT"].ToString()), 2);
                return lcl_dbl_MonthlyAllowance;
            }, "BMLExceptionPolicy");
            return MonthlyAllowance;
        }

        public System.String GetBankAccount(System.UInt64 IP_ui64_EmployeeCode, DAL.DBManager IP_obj_DBmanager)
        {
            System.String MonthlyAllowance = this.ExceptionManager.Process<System.String>(() =>
            {
                if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBmanager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT BANK_ACCOUNT_NO FROM EMPLOYEE WHERE EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = IP_obj_DBmanager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeReader.HasRows))
                {
                    lcl_obj_EmployeeReader.Close();
                    return System.String.Empty;
                }
                lcl_obj_EmployeeReader.Read();
                System.String lcl_str_BankAccountNo = lcl_obj_EmployeeReader["BANK_ACCOUNT_NO"].ToString();
                lcl_obj_EmployeeReader.Close();
                return lcl_str_BankAccountNo;
            }, "BMLExceptionPolicy");
            return MonthlyAllowance;
        }

        /// <summary>
        /// TIN 28-Jan-2017, SSL
        /// </summary>
        /// <param name="IP_ui64_EmployeeCode"></param>
        /// <param name="IP_obj_DBmanager"></param>
        /// <returns></returns>
        public System.String GetTin(System.UInt64 IP_ui64_EmployeeCode, DAL.DBManager IP_obj_DBmanager)
        {
            System.String MonthlyAllowance = this.ExceptionManager.Process<System.String>(() =>
            {
                if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBmanager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT TIN FROM EMPLOYEE WHERE EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = IP_obj_DBmanager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeReader.HasRows))
                {
                    lcl_obj_EmployeeReader.Close();
                    return System.String.Empty;
                }
                lcl_obj_EmployeeReader.Read();
                System.String lcl_str_Tin = lcl_obj_EmployeeReader["TIN"].ToString();
                lcl_obj_EmployeeReader.Close();
                return lcl_str_Tin;
            }, "BMLExceptionPolicy");
            return MonthlyAllowance;
        }

        public CCL.Enums.YesNo IsPfEligible(System.UInt64 IP_ui64_EmployeeCode,DAL.DBManager IP_obj_DBmanager)
        {
            CCL.Enums.YesNo lcl_enm_Resonse = this.ExceptionManager.Process<CCL.Enums.YesNo>(() =>
            {
                if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBmanager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT IS_PF_ELIGIBLE FROM EMPLOYEE WHERE EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = IP_obj_DBmanager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeReader.HasRows))
                {
                    lcl_obj_EmployeeReader.Close();
                    return CCL.Enums.YesNo.No;
                }
                lcl_obj_EmployeeReader.Read();
                CCL.Enums.YesNo lcl_Response = (CCL.Enums.YesNo)(System.Int16.Parse(lcl_obj_EmployeeReader["IS_PF_ELIGIBLE"].ToString()));
                return lcl_Response;
            }, "BMLExceptionPolicy");
            return lcl_enm_Resonse;
        }

        public CCL.Enums.YesNo IsOTEligble(System.UInt64 IP_ui64_EmployeeCode, DAL.DBManager IP_obj_DBmanager)
        {
            CCL.Enums.YesNo lcl_enm_Resonse = this.ExceptionManager.Process<CCL.Enums.YesNo>(() =>
            {
                if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBmanager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT IS_OT_ELIGIBLE FROM EMPLOYEE WHERE EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = IP_obj_DBmanager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeReader.HasRows))
                {
                    lcl_obj_EmployeeReader.Close();
                    return CCL.Enums.YesNo.No;
                }
                lcl_obj_EmployeeReader.Read();
                CCL.Enums.YesNo lcl_Response = (CCL.Enums.YesNo)(System.Int16.Parse(lcl_obj_EmployeeReader["IS_OT_ELIGIBLE"].ToString()));
                return lcl_Response;
            }, "BMLExceptionPolicy");
            return lcl_enm_Resonse;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini GetMiniEmplpoyeeProfile(System.UInt64 IP_ui64_EmployeeCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMiniRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>(() =>
            {
                //SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini();


                if (IP_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_NAME,DEPT.DEPARTMENT_CODE,
                                                                    DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME
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
                                                                    WHERE EMP.EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeMiniProfileReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeMiniProfileReader.HasRows))
                {
                    lcl_obj_EmployeeMiniProfileReader.Close();
                    return null;
                }

                lcl_obj_EmployeeMiniProfileReader.Read();
                
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini();
                    lcl_obj_EmployeeProfileMini.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmployeeProfileMini.EmployeeID = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_ID"].ToString();
                    lcl_obj_EmployeeProfileMini.EmployeeName = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EmployeeProfileMini.DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DEPARTMENT_CODE"].ToString());
                    lcl_obj_EmployeeProfileMini.DepartmentName = lcl_obj_EmployeeMiniProfileReader["DEPT_NAME"].ToString();
                    lcl_obj_EmployeeProfileMini.Designation = lcl_obj_EmployeeMiniProfileReader["DEGN_NAME"].ToString();
                    lcl_obj_EmployeeProfileMini.DesignationCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DESIGNATION_CODE"].ToString());
                    
                
                lcl_obj_EmployeeMiniProfileReader.Close();
                return lcl_obj_EmployeeProfileMini;

            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeProfileMiniRet;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> GetMiniEmplpoyeeProfileListByCompany(System.UInt64 IP_ui64_CompanyCode,SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMiniRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMini = new List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>();


                if (IP_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_NAME,DEPT.DEPARTMENT_CODE,
                                                                    DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME
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
                                                                    WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DEPT.Rank,DESIG.Rank ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeMiniProfileReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeMiniProfileReader.HasRows))
                {
                    lcl_obj_EmployeeMiniProfileReader.Close();
                    return null;
                }

                while (lcl_obj_EmployeeMiniProfileReader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini();
                    lcl_obj_EmployeeProfileMini.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmployeeProfileMini.EmployeeID = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_ID"].ToString();
                    lcl_obj_EmployeeProfileMini.EmployeeName = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EmployeeProfileMini.DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DEPARTMENT_CODE"].ToString());
                    lcl_obj_EmployeeProfileMini.DepartmentName = lcl_obj_EmployeeMiniProfileReader["DEPT_NAME"].ToString();
                    lcl_obj_EmployeeProfileMini.Designation = lcl_obj_EmployeeMiniProfileReader["DEGN_NAME"].ToString();
                    lcl_obj_EmployeeProfileMini.DesignationCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DESIGNATION_CODE"].ToString());
                    lcl_objLst_EmployeeProfileMini.Add(lcl_obj_EmployeeProfileMini);
                }
                lcl_obj_EmployeeMiniProfileReader.Close();
                return lcl_objLst_EmployeeProfileMini;
                
            }, "BMLExceptionPolicy");
            return lcl_objLst_EmployeeProfileMiniRet;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> GetMiniEmplpoyeeProfileListByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMiniRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMini = new List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>();
                
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME
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
                                                                        WHERE COMP.COMPANY_CODE = {0} AND BOND_YEAR != 0 AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DESIG.Rank,DEPT.Rank ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeMiniProfileReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (!(lcl_obj_EmployeeMiniProfileReader.HasRows))
                    {
                        lcl_obj_EmployeeMiniProfileReader.Close();
                        return null;
                    }

                    while (lcl_obj_EmployeeMiniProfileReader.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini();
                        lcl_obj_EmployeeProfileMini.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EmployeeProfileMini.EmployeeID = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_ID"].ToString();
                        lcl_obj_EmployeeProfileMini.EmployeeName = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EmployeeProfileMini.DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DEPARTMENT_CODE"].ToString());
                        lcl_obj_EmployeeProfileMini.DepartmentName = lcl_obj_EmployeeMiniProfileReader["DEPT_NAME"].ToString();
                        lcl_obj_EmployeeProfileMini.Designation = lcl_obj_EmployeeMiniProfileReader["DEGN_NAME"].ToString();
                        lcl_obj_EmployeeProfileMini.DesignationCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DESIGNATION_CODE"].ToString());
                        lcl_objLst_EmployeeProfileMini.Add(lcl_obj_EmployeeProfileMini);
                    }
                    lcl_obj_EmployeeMiniProfileReader.Close();
                    return lcl_objLst_EmployeeProfileMini;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EmployeeProfileMiniRet;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> GetAllActiveEmployeeByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMiniRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini> lcl_objLst_EmployeeProfileMini = new List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>();

                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME
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
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By DESIG.Rank,DEPT.Rank ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeMiniProfileReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (!(lcl_obj_EmployeeMiniProfileReader.HasRows))
                    {
                        lcl_obj_EmployeeMiniProfileReader.Close();
                        return null;
                    }

                    while (lcl_obj_EmployeeMiniProfileReader.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini();
                        lcl_obj_EmployeeProfileMini.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EmployeeProfileMini.EmployeeID = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_ID"].ToString();
                        lcl_obj_EmployeeProfileMini.EmployeeName = lcl_obj_EmployeeMiniProfileReader["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EmployeeProfileMini.DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DEPARTMENT_CODE"].ToString());
                        lcl_obj_EmployeeProfileMini.DepartmentName = lcl_obj_EmployeeMiniProfileReader["DEPT_NAME"].ToString();
                        lcl_obj_EmployeeProfileMini.Designation = lcl_obj_EmployeeMiniProfileReader["DEGN_NAME"].ToString();
                        lcl_obj_EmployeeProfileMini.DesignationCode = System.UInt64.Parse(lcl_obj_EmployeeMiniProfileReader["DESIGNATION_CODE"].ToString());
                        lcl_objLst_EmployeeProfileMini.Add(lcl_obj_EmployeeProfileMini);
                    }
                    lcl_obj_EmployeeMiniProfileReader.Close();
                    return lcl_objLst_EmployeeProfileMini;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EmployeeProfileMiniRet;
        }

    }
}
