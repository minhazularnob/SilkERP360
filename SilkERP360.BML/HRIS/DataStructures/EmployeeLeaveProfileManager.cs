using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class EmployeeLeaveProfileManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeLeaveProfileManager()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmpLeaveProfile = null;
            lcl_objLst_EmpLeaveProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    dr.Close();
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                }
                
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmpLeaveProfileTemp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmpLeaveProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile();
                    lcl_obj_EmpLeaveProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmpLeaveProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EmpLeaveProfile.EmployeeStatus = (SilkERP360.CCL.Enums.EmployeeStatus)(System.UInt16.Parse(dr["EMPLOYEE_STATUS"].ToString()));
                    lcl_obj_EmpLeaveProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_EmpLeaveProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                    lcl_obj_EmpLeaveProfile.Gender = System.Char.Parse(dr["SEX"].ToString());
                    lcl_obj_EmpLeaveProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                    lcl_obj_EmpLeaveProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                    lcl_obj_EmpLeaveProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                    lcl_objLst_EmpLeaveProfileTemp.Add(lcl_obj_EmpLeaveProfile);
                }
                dr.Close();

                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmpLeaveProfile in lcl_objLst_EmpLeaveProfileTemp)
                {
                    //Get Employee Salary Structure
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From Employee_Leave_Account Where Employee_Code = {0}", lcl_obj_EmpLeaveProfile.EmployeeCode);
                    SilkERP360.BML.HRIS.EmployeeLeaveAccountManager lcl_obj_EmpLeaveAccountManager = new SilkERP360.BML.HRIS.EmployeeLeaveAccountManager();
                    lcl_obj_EmpLeaveAccountManager.Initialize();
                    lcl_obj_EmpLeaveProfile.LeaveAccount = lcl_obj_EmpLeaveAccountManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);

                    lcl_str_SqlQuery = System.String.Format("Select * From Employee_Leave_Application Where Employee_Code = {0}", lcl_obj_EmpLeaveProfile.EmployeeCode);
                    SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmpLeaveApplicationManager = new SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager();
                    lcl_obj_EmpLeaveApplicationManager.Initialize();
                    lcl_obj_EmpLeaveProfile.EmployeeLeaveApplicationList = lcl_obj_EmpLeaveApplicationManager.GetList(lcl_str_SqlQuery, IP_obj_DBManager);
                }
                return lcl_objLst_EmpLeaveProfileTemp;
               


                

            }, "BMLExceptionPolicy");
            return lcl_objLst_EmpLeaveProfile;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmpLeaveProfile = null;
            lcl_objLst_EmpLeaveProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile>>(() =>
            {
                try
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
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                        }

                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile> lcl_objLst_EmpLeaveProfileTemp = new
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile>();
                        while (dr.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmpLeaveProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile();
                            lcl_obj_EmpLeaveProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                            lcl_obj_EmpLeaveProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                            lcl_obj_EmpLeaveProfile.EmployeeStatus = (SilkERP360.CCL.Enums.EmployeeStatus)(System.UInt16.Parse(dr["EMPLOYEE_STATUS"].ToString()));
                            lcl_obj_EmpLeaveProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                            lcl_obj_EmpLeaveProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                            lcl_obj_EmpLeaveProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                            lcl_obj_EmpLeaveProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                            lcl_obj_EmpLeaveProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                            lcl_objLst_EmpLeaveProfileTemp.Add(lcl_obj_EmpLeaveProfile);
                        }
                        dr.Close();

                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeLeaveProfile lcl_obj_EmpLeaveProfile in lcl_objLst_EmpLeaveProfileTemp)
                        {
                            //Get Employee Salary Structure
                            System.String lcl_str_SqlQuery = System.String.Format("Select * From Employee_Leave_Account Where Employee_Code = {0}", lcl_obj_EmpLeaveProfile.EmployeeCode);
                            SilkERP360.BML.HRIS.EmployeeLeaveAccountManager lcl_obj_EmpLeaveAccountManager = new SilkERP360.BML.HRIS.EmployeeLeaveAccountManager();
                            lcl_obj_EmpLeaveAccountManager.Initialize();
                            lcl_obj_EmpLeaveProfile.LeaveAccount = lcl_obj_EmpLeaveAccountManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                            lcl_str_SqlQuery = System.String.Format("Select * From Employee_Leave_Application Where Employee_Code = {0}", lcl_obj_EmpLeaveProfile.EmployeeCode);
                            SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmpLeaveApplicationManager = new SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager();
                            lcl_obj_EmpLeaveApplicationManager.Initialize();
                            lcl_obj_EmpLeaveProfile.EmployeeLeaveApplicationList = lcl_obj_EmpLeaveApplicationManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                        }


                        return lcl_objLst_EmpLeaveProfileTemp;
                    }
                }
                catch (System.Exception EX)
                {
                    throw EX;
                }

            }, "BMLExceptionPolicy");
            return lcl_objLst_EmpLeaveProfile;
        }
    }
}
