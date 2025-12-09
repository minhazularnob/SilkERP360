using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
  public  class employeeStatusHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
      public employeeStatusHistoryManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }




      public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeStatusHistory lcl_obj_EmployeeStatusHistory)
      {
          System.UInt64 lcl_ui64_HistoryRoeID = 0;
          lcl_ui64_HistoryRoeID = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    OracleParameter lcl_obj_HistoryCode = new OracleParameter("p_STATUS_HISTORY_CODE", OracleDbType.Int64);
                    lcl_obj_HistoryCode.Direction = System.Data.ParameterDirection.Output;


                    OracleParameter lcl_obj_EmployeeCode = new OracleParameter("p_EMPLOYEE_CODE", OracleDbType.Int64);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeStatusHistory.EmployeeCode;
                    OracleParameter lcl_obj_CurretnStatusCode = new OracleParameter("p_EMP_CURRENT_STATUS_CODE", OracleDbType.Int64);
                    lcl_obj_CurretnStatusCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CurretnStatusCode.Value = Convert.ToInt16((SilkERP360.CCL.Enums.EmployeeStatus)lcl_obj_EmployeeStatusHistory.CurrentStatusCode);

                    OracleParameter lcl_obj_OldStatusCode = new OracleParameter("p_EMP_OLD_STATUS_CODE", OracleDbType.Int64);
                    lcl_obj_OldStatusCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_OldStatusCode.Value = Convert.ToInt16( (SilkERP360.CCL.Enums.EmployeeStatus)lcl_obj_EmployeeStatusHistory.OldtStatusCode);

                    OracleParameter lcl_obj_EffectDate = new OracleParameter("p_EFFECT_DATE", OracleDbType.Date);
                    lcl_obj_EffectDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EffectDate.Value = lcl_obj_EmployeeStatusHistory.EffectDate;



                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_HistoryCode, lcl_obj_EmployeeCode, lcl_obj_CurretnStatusCode, lcl_obj_OldStatusCode, lcl_obj_EffectDate };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("EMP_STATUS_HISTORY_IU", lcl_obj_SP_Parameters);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
                   
                }
            }, "BMLExceptionPolicy");
          return lcl_ui64_HistoryRoeID;
      }

     
    }
}
