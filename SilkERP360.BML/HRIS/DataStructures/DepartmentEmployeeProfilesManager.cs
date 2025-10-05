using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class DepartmentEmployeeProfilesManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles Get(ulong IP_ui64_DepartmentCode, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles lcl_obj_DepertmentEmployeeProfile = null;
            lcl_obj_DepertmentEmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(@" SELECT EMPLOYEE_CODE FROM EMPLOYEE Where DEPARTMENT_CODE={0} And EMPLOYEE_STATUS={1}", IP_ui64_DepartmentCode, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_DepertmentEmployeeProfileReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_DepertmentEmployeeProfileReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error DepartmentEmployeeManager.Get(Dept_Code,DBManger)) : Error Retrieving Department WiseEmployee profile list Data!");
                }
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles lcl_obj_DepertmentEmployeeProfileTmp = new CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objList_EmployeeProfiles =
                    new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                while (lcl_obj_DepertmentEmployeeProfileReader.Read())
                {
                    System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_DepertmentEmployeeProfileReader["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.Get(lcl_ui64_EmployeeCode, lcl_obj_DBManager);
                    lcl_objList_EmployeeProfiles.Add(lcl_obj_EmployeeProfile);
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //get department code
                SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new SilkERP360.BML.HRIS.DepartmentManager();
                SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_DepartmentCore = lcl_obj_DepartmentManager.GetDepartmentCore(IP_ui64_DepartmentCode, lcl_obj_DBManager);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                lcl_obj_DepertmentEmployeeProfileTmp = new CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles(IP_ui64_DepartmentCode, lcl_obj_DepartmentCore.Name, lcl_objList_EmployeeProfiles);
                lcl_obj_DepertmentEmployeeProfileReader.Close();
                return lcl_obj_DepertmentEmployeeProfileTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_DepertmentEmployeeProfile;
        }

        public CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles Get(ulong IP_ui64_DepartmentCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles lcl_obj_DepertmentEmployeeProfile = null;
            lcl_obj_DepertmentEmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_SqlQuery = System.String.Format(@" SELECT EMPLOYEE_CODE FROM EMPLOYEE Where DEPARTMENT_CODE={0} And EMPLOYEE_STATUS={1}", IP_ui64_DepartmentCode, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);

                    System.Data.OracleClient.OracleDataReader lcl_obj_DepertmentEmployeeProfileReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (lcl_obj_DepertmentEmployeeProfileReader.HasRows == false)
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error DepartmentEmployeeManager.Get(Dept_Code)) : Error Retrieving Department WiseEmployee profile list Data!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles lcl_obj_DepertmentEmployeeProfileTmp = new CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles();
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objList_EmployeeProfiles =
                        new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                    SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                    while (lcl_obj_DepertmentEmployeeProfileReader.Read())
                    {
                        System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_DepertmentEmployeeProfileReader["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.Get(lcl_ui64_EmployeeCode, lcl_obj_DBManager);
                        lcl_objList_EmployeeProfiles.Add(lcl_obj_EmployeeProfile);
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //get department code
                    SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new SilkERP360.BML.HRIS.DepartmentManager();
                    SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_DepartmentCore = lcl_obj_DepartmentManager.GetDepartmentCore(IP_ui64_DepartmentCode, lcl_obj_DBManager);
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lcl_obj_DepertmentEmployeeProfileTmp = new CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles(IP_ui64_DepartmentCode, lcl_obj_DepartmentCore.Name, lcl_objList_EmployeeProfiles);
                    lcl_obj_DepertmentEmployeeProfileReader.Close();
                    return lcl_obj_DepertmentEmployeeProfileTmp;
                }
            }, "BMLExceptionPolicy");
        
            return lcl_obj_DepertmentEmployeeProfile;
  
        }

      
    }
}
