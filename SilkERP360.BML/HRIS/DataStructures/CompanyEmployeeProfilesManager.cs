using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class CompanyEmployeeProfilesManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.DataStructures.CompanyEmployeeProfiles Get(ulong IP_ui64_CoMp_Code, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.CompanyEmployeeProfiles lcl_obj_CompanyEmployeeProfiles = null;
            lcl_obj_CompanyEmployeeProfiles = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.CompanyEmployeeProfiles>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMPLOYEE_CODE FROM EMPLOYEE Where COMPANY_CODE={0} And EMPLOYEE_STATUS={1}", IP_ui64_CoMp_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);

                System.Data.OracleClient.OracleDataReader lcl_obj_CompanyEmployeeProfilesReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_CompanyEmployeeProfilesReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error CompanyEmployeeProfilesManager.Get(Dept_Code,DBManger)) : Error Retrieving Company WiseEmployee profile list Data!");
                }
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.CompanyEmployeeProfiles lcl_obj_CompanyEmployeeProfilesTmp = new CCL.BusinessEntities.HRIS.DataStructures.CompanyEmployeeProfiles();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objList_EmployeeProfiles =
                    new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;

                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager();
                while (lcl_obj_CompanyEmployeeProfilesReader.Read())
                {
                    System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_CompanyEmployeeProfilesReader["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.Get(lcl_ui64_EmployeeCode, lcl_obj_DBManager);
                    lcl_objList_EmployeeProfiles.Add(lcl_obj_EmployeeProfile);
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //get department code
                SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
     

                SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore lcl_obj_CompanyCore = lcl_obj_CompanyManager.getCompanyCore(IP_ui64_CoMp_Code, lcl_obj_DBManager);

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                lcl_obj_CompanyEmployeeProfilesTmp = new CCL.BusinessEntities.HRIS.DataStructures.CompanyEmployeeProfiles(IP_ui64_CoMp_Code, lcl_objList_EmployeeProfiles);
                lcl_obj_CompanyEmployeeProfilesReader.Close();
                return lcl_obj_CompanyEmployeeProfilesTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_CompanyEmployeeProfiles;
        }

        public CCL.BusinessEntities.HRIS.DataStructures.DepartmentEmployeeProfiles Get(ulong IP_ui64_DepartmentCode)
        {
            throw new NotImplementedException();
        }

      
    }
}
