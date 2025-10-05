using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class LeaveBalanceManager:SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {


        public LeaveBalanceManager()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> getLeaveBalancebyeEmployeeCode(System.UInt64 IP_ui64_EmployeeCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {

            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> lcl_obj_LeaveBalanceList = null;
            lcl_obj_LeaveBalanceList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance>>(() =>
            {
                if (IP_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBManager.Open();
                }

                System.Data.OracleClient.OracleDataReader lcl_obj_dr = IP_obj_DBManager.ExecuteDataReader(System.String.Format(@"SELECT A.EMPLOYEE_CODE,A.LEAVE_CODE, BALANCE ,LEAVE_NAME, SHORT_NAME,NO_OF_DAYS,IS_CARRY_FORWARDED From (SELECT e.EMPLOYEE_CODE,LEAVE_CODE, BALANCE  
                                                                       FROM EMPLOYEE E inner join  EMPLOYEE_ENTITLE_LEAVE ETL on e.EMPLOYEE_CODE=ETL.EMPLOYEE_CODE)A Left outer join (SELECT LEAVE_CODE, LEAVE_NAME, SHORT_NAME, NO_OF_DAYS, COMPANY_CODE,nvl(IS_CARRY_FORWARDED,0)IS_CARRY_FORWARDED,
                                                                       IS_DELETED, STATUS FROM LEAVE)B on A.LEAVE_CODE=B.LEAVE_CODE  where employee_code={0}", IP_ui64_EmployeeCode));

                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (getLeaveBalancebyeEmployeeCode.GetList(EMPLOYEE CODE,DBManager)) : No Leave balance found Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance(System.UInt64.Parse(lcl_obj_dr["LEAVE_CODE"].ToString()),
                        System.UInt16.Parse(lcl_obj_dr["BALANCE"].ToString()),
                        lcl_obj_dr["LEAVE_NAME"].ToString(),
                        lcl_obj_dr["SHORT_NAME"].ToString(),
                        System.UInt16.Parse(lcl_obj_dr["NO_OF_DAYS"].ToString()),
                        System.UInt16.Parse(lcl_obj_dr["IS_CARRY_FORWARDED"].ToString()),
                        System.UInt16.Parse(lcl_obj_dr["NO_OF_DAYS"].ToString()));

                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_LeaveBalanceList;    






        }

    }
}
