using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class CompanyFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
      public CompanyFacade()
      {
          this.Initialize();
      }

      public System.UInt64 SaveCompany(SilkERP360.CCL.BusinessEntities.HRIS.Company IP_Obj_Company)
      {
          System.UInt64 lcl_ui64_CompanyCode = this.ExceptionManager.Process<System.UInt64>(() =>
          {
              SilkERP360.BML.HRIS.CompanyManager lcl_obj_HolidayMasterManager = new BML.HRIS.CompanyManager();
              System.UInt64 lcl_ui64_CompanyCodeTmp = lcl_obj_HolidayMasterManager.Save(IP_Obj_Company);
              return lcl_ui64_CompanyCodeTmp;
          }, "FLExceptionPolicy");
          return lcl_ui64_CompanyCode;
      }



      public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> GetAllCompanyWise()
      {
          System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_obj_Company = null;
          lcl_obj_Company = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company>>(() =>
          {
              System.String lcl_str_SqlQuery = System.String.Format(@"Select COMPANY_CODE,NAME,ADDRESS,PHONE_NO,FAX_NO,EMAIL,WEB_SITE,COMPANY_SHORT_NAME From  COMPANY
               where is_deleted=1 order by COMPANY_CODE desc");
              SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
              System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_obj_CompanyTmp =
                  lcl_obj_CompanyManager.GetList(lcl_str_SqlQuery);
              return lcl_obj_CompanyTmp;
          }, "FLExceptionPolicy");
          return lcl_obj_Company;
      }



    }
}
