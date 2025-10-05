using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class EmployeeSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeSP()
        {
            this.Initialize();
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile GetEmployeeProfileByEmployeeCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_TmpEmployeeProfile = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new BML.HRIS.DataStructures.EmployeeProfileManager();
                    lcl_obj_TmpEmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(IP_ui64_EmployeeCode, lcl_obj_DBManager.InternalResource);
                    
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpEmployeeProfile;
            }, "SPExceptionPolicy");
            return lcl_obj_EmployeeProfile;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini GetMiniEmployeeProfile(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfileMini = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_TmpEmployeeProfileMini = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    SilkERP360.BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeServices = new BML.Services.HRIS.EmployeeServices();
                    lcl_obj_TmpEmployeeProfileMini = lcl_obj_EmployeeServices.GetMiniEmplpoyeeProfile(IP_ui64_EmployeeCode, lcl_obj_DBManager.InternalResource);
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpEmployeeProfileMini;
            }, "SPExceptionPolicy");
            return lcl_obj_EmployeeProfileMini;
        }
    }
}
