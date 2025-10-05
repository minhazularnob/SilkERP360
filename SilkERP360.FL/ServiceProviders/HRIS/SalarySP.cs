using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.ServiceProviders.HRIS
{
    public class SalarySP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SalarySP()
        {
        }

        public System.Boolean IsSalaryProcessed(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear)
        {
            System.Boolean Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.BML.HRISFactory.SalaryFactory lcl_obj_SalaryFactory = new BML.HRISFactory.SalaryFactory();
                lcl_obj_SalaryFactory.Initialize();
                return lcl_obj_SalaryFactory.IsSalaryProcessed(IP_ui64_CompanyCode, IP_enm_SalaryMonth, IP_ui16_SalaryYear);
            }, "FLExceptionPolicy");
            return Response;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster GenerateSalary(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear, System.DateTime IP_dt_SalaryCycleFrom, System.DateTime IP_dt_SalaryCycleUpto, SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMasterRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                SilkERP360.BML.Services.HRIS.SalaryServices lcl_obj_SalaryService = new BML.Services.HRIS.SalaryServices();
                lcl_obj_SalaryService.Initialize();
                return lcl_obj_SalaryService.GenerateSalary(IP_ui64_CompanyCode, IP_enm_SalaryMonth, IP_ui16_SalaryYear,IP_dt_SalaryCycleFrom,IP_dt_SalaryCycleUpto,IP_obj_SalaryMaster);
            }, "FLExceptionPolicy");
            return lcl_obj_SalaryMasterRet;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster GetSalaryMaster(System.UInt64 IP_ui64_CompanyCode, SilkERP360.CCL.Enums.Month IP_enm_SalaryMonth, System.UInt16 IP_ui16_SalaryYear)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMasterRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster>(() =>
            {
                SilkERP360.BML.Services.HRIS.SalaryServices lcl_obj_SalaryService = new BML.Services.HRIS.SalaryServices();
                lcl_obj_SalaryService.Initialize();
                return lcl_obj_SalaryService.GetSalaryMaster(IP_ui64_CompanyCode, IP_enm_SalaryMonth, IP_ui16_SalaryYear);
            }, "FLExceptionPolicy");
            return lcl_obj_SalaryMasterRet;
        }

        public System.Boolean SaveSalary(SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster IP_obj_SalaryMaster)
        {
            System.Boolean lcl_obj_SalaryMasterRet = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.BML.Services.HRIS.SalaryServices lcl_obj_SalaryService = new BML.Services.HRIS.SalaryServices();
                lcl_obj_SalaryService.Initialize();
                return lcl_obj_SalaryService.SaveSalary(IP_obj_SalaryMaster);
            }, "FLExceptionPolicy");
            return lcl_obj_SalaryMasterRet;
        }
    }
}
