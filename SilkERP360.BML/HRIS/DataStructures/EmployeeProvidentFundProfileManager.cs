using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class EmployeeProvidentFundProfileManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeProvidentFundProfileManager()
        {
            this.Initialize();
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmpLeaveProvidentFundProfile = null;
            lcl_obj_EmpLeaveProvidentFundProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfileTemp = new
                                                                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile();
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    //Return null
                    return null;
                }
                dr.Read();
                lcl_obj_EmployeeProvidentFundProfileTemp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_EmployeeProvidentFundProfileTemp.PFAccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(dr["ACCOUNT_STATUS"].ToString());
                lcl_obj_EmployeeProvidentFundProfileTemp.PFAccountNumber = System.UInt64.Parse(dr["PF_ACCOUNT_NUMBER"].ToString());
                lcl_obj_EmployeeProvidentFundProfileTemp.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                lcl_obj_EmployeeProvidentFundProfileTemp.EmployeeStatus = (SilkERP360.CCL.Enums.EmployeeStatus)(System.UInt16.Parse(dr["EMPLOYEE_STATUS"].ToString()));
                lcl_obj_EmployeeProvidentFundProfileTemp.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                lcl_obj_EmployeeProvidentFundProfileTemp.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                lcl_obj_EmployeeProvidentFundProfileTemp.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                lcl_obj_EmployeeProvidentFundProfileTemp.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                lcl_obj_EmployeeProvidentFundProfileTemp.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                lcl_obj_EmployeeProvidentFundProfileTemp.EmployeeImage = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                
                dr.Close();
                //Get Employee Salary Structure
                System.String lcl_str_SqlQuery = System.String.Format("Select * From PF_ACCOUNT_TRANSACTION Where PF_ACCOUNT_NUMBER = {0} ORDER BY TRANSACTION_YEAR ASC", lcl_obj_EmployeeProvidentFundProfileTemp.PFAccountNumber);
                SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransactionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                lcl_obj_PFAccountTransactionManager.Initialize();
                lcl_obj_EmployeeProvidentFundProfileTemp.EmployeePFAccountTransactionList = lcl_obj_PFAccountTransactionManager.GetList(lcl_str_SqlQuery, IP_obj_DBManager);
                
                return lcl_obj_EmployeeProvidentFundProfileTemp;

            }, "BMLExceptionPolicy");
            return lcl_obj_EmpLeaveProvidentFundProfile;
        }



        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmpLeaveProvidentFundProfile = null;
            lcl_objLst_EmpLeaveProvidentFundProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileTemp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>();
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    //Return Empty Collection
                    return lcl_objLst_EmployeeProvidentFundProfileTemp;
                }

                
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmpProvidentFundProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile();
                    lcl_obj_EmpProvidentFundProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmpProvidentFundProfile.PFAccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(dr["ACCOUNT_STATUS"].ToString());
                    lcl_obj_EmpProvidentFundProfile.PFAccountNumber = System.UInt64.Parse(dr["PF_ACCOUNT_NUMBER"].ToString());
                    lcl_obj_EmpProvidentFundProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EmpProvidentFundProfile.EmployeeStatus = (SilkERP360.CCL.Enums.EmployeeStatus)(System.UInt16.Parse(dr["EMPLOYEE_STATUS"].ToString()));
                    lcl_obj_EmpProvidentFundProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_EmpProvidentFundProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                    lcl_obj_EmpProvidentFundProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                    lcl_obj_EmpProvidentFundProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                    lcl_obj_EmpProvidentFundProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                    lcl_objLst_EmployeeProvidentFundProfileTemp.Add(lcl_obj_EmpProvidentFundProfile);
                }
                dr.Close();
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfile in lcl_objLst_EmployeeProvidentFundProfileTemp)
                //{
                //    //Get Employee Salary Structure
                //    System.String lcl_str_SqlQuery = System.String.Format("Select * From PF_ACCOUNT_TRANSACTION Where PF_ACCOUNT_NUMBER = {0}", lcl_obj_EmployeeProvidentFundProfile.PFAccountNumber);
                //    SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransactionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                //    lcl_obj_PFAccountTransactionManager.Initialize();
                //    lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList = lcl_obj_PFAccountTransactionManager.GetList(lcl_str_SqlQuery, IP_obj_DBManager);
                //}
                return lcl_objLst_EmployeeProvidentFundProfileTemp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EmpLeaveProvidentFundProfile;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmpLeaveProvidentFundProfile = null;
            lcl_objLst_EmpLeaveProvidentFundProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfileTemp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile>();
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    //SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                    //if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    //{
                    //    lcl_obj_DBManager.Open();
                    //}
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                    }

                    
                    while (dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmpProvidentFundProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile();
                        lcl_obj_EmpProvidentFundProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EmpProvidentFundProfile.PFAccountNumber = System.UInt64.Parse(dr["PF_ACCOUNT_NUMBER"].ToString());
                        lcl_obj_EmpProvidentFundProfile.PFAccountStatus = (SilkERP360.CCL.Enums.ProvidentFundAccountStatus)System.UInt16.Parse(dr["ACCOUNT_STATUS"].ToString());
                        lcl_obj_EmpProvidentFundProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EmpProvidentFundProfile.EmployeeStatus = (SilkERP360.CCL.Enums.EmployeeStatus)(System.UInt16.Parse(dr["EMPLOYEE_STATUS"].ToString()));
                        lcl_obj_EmpProvidentFundProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_EmpProvidentFundProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                        lcl_obj_EmpProvidentFundProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                        lcl_obj_EmpProvidentFundProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                        lcl_obj_EmpProvidentFundProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                        lcl_objLst_EmployeeProvidentFundProfileTemp.Add(lcl_obj_EmpProvidentFundProfile);
                    }
                    dr.Close();
                    //foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfile in lcl_objLst_EmployeeProvidentFundProfileTemp)
                    //{
                    //    //Get Employee Salary Structure
                    //    System.String lcl_str_SqlQuery = System.String.Format("Select * From PF_ACCOUNT_TRANSACTION Where PF_ACCOUNT_NUMBER = {0}", lcl_obj_EmployeeProvidentFundProfile.PFAccountNumber);
                    //    SilkERP360.BML.HRIS.PFAccountTransactionManager lcl_obj_PFAccountTransactionManager = new SilkERP360.BML.HRIS.PFAccountTransactionManager();
                    //    lcl_obj_PFAccountTransactionManager.Initialize();
                    //    lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList = lcl_obj_PFAccountTransactionManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    //}
                }
                return lcl_objLst_EmployeeProvidentFundProfileTemp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EmpLeaveProvidentFundProfile;
        }
    }
}
