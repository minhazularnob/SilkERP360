using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
   public class HolidayFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
       public HolidayFacade()
        {
            this.Initialize();
        }

       public System.UInt64 SaveHolidayMaster(SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster IP_Obj_HolidayMaster)
       {
           System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.BML.HRIS.HolidayMstrManager lcl_obj_HolidayMasterManager = new BML.HRIS.HolidayMstrManager();
               System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_HolidayMasterManager.Save(IP_Obj_HolidayMaster);
               return lcl_ui64_EmployeeCodeTmp;
           }, "FLExceptionPolicy");
           return lcl_ui64_EmployeeCode;
       }

       public System.UInt64 DeletHoliday(System.UInt64  IP_ui64_HolidayMasterCode)
       {
           System.UInt64 lcl_ui64_HolidayMasterCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.BML.HRIS.HolidayMstrManager lcl_obj_HolidayMasterManager = new BML.HRIS.HolidayMstrManager();
               System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_HolidayMasterManager.DeleteHoliday(IP_ui64_HolidayMasterCode);
               return lcl_ui64_EmployeeCodeTmp;
           }, "FLExceptionPolicy");
           return lcl_ui64_HolidayMasterCode;
       }
       //DeletHoliday
       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> GetAllHolidayCompanyWise(System.UInt64 IP_ui64_CompanyCode, System.String IP_str_SerchDate)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> lcl_obj_HolidayMaster = null;
           lcl_obj_HolidayMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster>>(() =>
           {
               System.String lcl_str_SqlQuery = System.String.Format(@"Select HOLIDAY_MASTER_CODE,HOLIDAY_NAME,DEC_DATE,START_DATE,END_DATE,NUM_OF_DAYS,REMARKS From  HOLIDAY_MASTER
               where is_deleted=1 And COMPANY_CODE={0} And to_char(DEC_DATE,'yyyy')=to_char(to_date('{1}'),'yyyy') order by START_DATE desc", IP_ui64_CompanyCode, IP_str_SerchDate, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated);
               SilkERP360.BML.HRIS.HolidayMstrManager lcl_obj_HolidayMstrManager = new SilkERP360.BML.HRIS.HolidayMstrManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.HolidayMaster> lcl_obj_HolidayMasterTmp =
                   lcl_obj_HolidayMstrManager.GetList(lcl_str_SqlQuery);
               return lcl_obj_HolidayMasterTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_HolidayMaster;
       }
    }
}
