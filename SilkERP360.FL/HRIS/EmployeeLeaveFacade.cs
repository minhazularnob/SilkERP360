using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class EmployeeLeaveFacade: SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
          public EmployeeLeaveFacade()
        {
            this.Initialize();
        }
          public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave >  GetEmployeeLeaveList(System.UInt64 IP_ui64_CompanyCode)
          {

             
              System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objLst_EmployeeLeaveList = null;
              lcl_objLst_EmployeeLeaveList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave>>(() =>
              {
                  
                  SilkERP360.BML.HRIS.LeaveManger lcl_obj_EmployeeLeaveManager = new SilkERP360.BML.HRIS.LeaveManger();
                  string sql = System.String.Format("SELECT * FROM leave WHERE company_code = {0}", IP_ui64_CompanyCode);
                  return lcl_obj_EmployeeLeaveManager.GetList(sql); 
              }, "FLExceptionPolicy");

              return lcl_objLst_EmployeeLeaveList;
          }

          public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> GetEmployeeLeaveListPersonal(System.UInt64 IP_ui64_CompanyCode, System.UInt64 IP_ui64_EmployeeCode)
          {


              System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave> lcl_objLst_EmployeeLeaveList = null;
              lcl_objLst_EmployeeLeaveList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Leave>>(() =>
              {

                  SilkERP360.BML.HRIS.LeaveManger lcl_obj_EmployeeLeaveManager = new SilkERP360.BML.HRIS.LeaveManger();
                  string sql = System.String.Format(@"select Leave_Name,No_Of_Days,leave.leave_code,company_code,short_name,is_carry_forwarded from leave inner join
                                                    employee_entitle_leave on leave.leave_code=employee_entitle_leave.leave_code
                                                    where company_code={0}and employee_code={1} ", IP_ui64_CompanyCode, IP_ui64_EmployeeCode);
                  return lcl_obj_EmployeeLeaveManager.GetList(sql);
              }, "FLExceptionPolicy");

              return lcl_objLst_EmployeeLeaveList;
          }

          public System.UInt64 Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_EmployeeLeaveApplication)
          {
              System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
              {
                  SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManger = new BML.HRIS.EmployeeLeaveApplicationManager();
                  System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_EmployeeLeaveApplicationManger.Save(IP_obj_EmployeeLeaveApplication);
                  return lcl_ui64_EmployeeCodeTmp;
              }, "FLExceptionPolicy");
              return lcl_ui64_EmployeeCode;
          }

          public System.UInt64 UpdateLeaveApproved(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_EmployeeLeaveApproved)
          {
              System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
              {
                  SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManger = new BML.HRIS.EmployeeLeaveApplicationManager();
                  //System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_EmployeeLeaveApplicationManger.UpdateLeaveApprove(IP_obj_EmployeeLeaveApproved);
                  return 0;// lcl_ui64_EmployeeCodeTmp;
              }, "FLExceptionPolicy");
              return lcl_ui64_EmployeeCode;
          }

          public System.UInt64 UpdateLeaveRecomanded(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveApplication IP_obj_EmployeeLeaveRecommended)
          {
              System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
              {
                  SilkERP360.BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManger = new BML.HRIS.EmployeeLeaveApplicationManager();
                  //System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_EmployeeLeaveApplicationManger.UpdateLeaveRecomanded(IP_obj_EmployeeLeaveRecommended);
                  return 0;// lcl_ui64_EmployeeCodeTmp;
              }, "FLExceptionPolicy");
              return lcl_ui64_EmployeeCode;
          }
    }
}
