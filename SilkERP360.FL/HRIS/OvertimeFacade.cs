using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class OvertimeFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Overtime>
    {
        public OvertimeFacade()
        {
            this.Initialize();
        }

        public System.Boolean Update(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> IP_objLst_UpdatedOvertime)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                System.Boolean lcl_b_TmpResponse = false;
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.Overtime lcl_obj_Overtime in IP_objLst_UpdatedOvertime)
                {
                    System.String lcl_str_SqlUpdate = System.String.Format("UPDATE OVERTIME SET OT_HOUR = {0},ENTRY_EMPLOYEE_CODE = {1} WHERE OVERTIME_CODE = {2}", lcl_obj_Overtime.OvertimeHour, lcl_obj_Overtime.EntryEmployeeCode, lcl_obj_Overtime.OvertimeCode);
                    lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlUpdate);
                }
                lcl_obj_SqlFacade.CommitTransaction();
                lcl_b_TmpResponse = true;
                return lcl_b_TmpResponse;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Overtime IP_obj_T)
        {
            System.UInt64 lcl_ui64_OvertimeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.OvertimeManager lcl_obj_OvertimeManager = new BML.HRIS.OvertimeManager();
                System.UInt64 lcl_ui64_OvertimeCodeTmp = lcl_obj_OvertimeManager.Save(IP_obj_T);
                return lcl_ui64_OvertimeCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_OvertimeCode;
        }

        public CCL.BusinessEntities.HRIS.Overtime Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Overtime Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Overtime> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.HRIS.Overtime IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
