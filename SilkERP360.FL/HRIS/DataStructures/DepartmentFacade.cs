using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class DepartmentFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Department>
    {
        public DepartmentFacade()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> GetDepartmentCoresByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCores = null;
            lcl_obj_DepartmentCores = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>>(() =>
            {
                SilkERP360.BML.HRIS.DepartmentManager lcl_obj_DepartmentManager = new SilkERP360.BML.HRIS.DepartmentManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCoresTmp = lcl_obj_DepartmentManager.GetDepartmentCoresByCompany(IP_ui64_CompanyCode);
                return lcl_obj_DepartmentCoresTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_DepartmentCores; 
        }



        public ulong Save(CCL.BusinessEntities.HRIS.Department IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Department Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Department Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Department> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.HRIS.Department IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
