using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.ServiceProviders.HRIS
{
    public class AttendanceSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public AttendanceSP()
        {
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange GetEmployeewiseAttendanceByDateRange(System.UInt64 IP_ui64_EmployeeCode,System.DateTime IP_dt_StartDate,System.DateTime IP_dt_EndDateTime)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange lcl_obj_EmployeewiseAttendanceByDateRangeRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange>(() =>
            {
                SilkERP360.BML.HRISFactory.AttendanceFactory lcl_obj_AttendanceFactory = new BML.HRISFactory.AttendanceFactory();
                lcl_obj_AttendanceFactory.Initialize();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange lcl_obj_EmployeewiseAttendanceByDateRange = lcl_obj_AttendanceFactory.GetEmployeewiseAttendanceByDateRange(IP_ui64_EmployeeCode, IP_dt_StartDate, IP_dt_EndDateTime);
                return lcl_obj_EmployeewiseAttendanceByDateRange;// lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeewiseAttendanceByDateRangeRet;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster GetAttendanceSummery(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_DateFrom, System.DateTime IP_dt_DateUpto)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster lcl_obj_EmployeeAttendanceSummeryMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster>(() =>
            {
                SilkERP360.BML.HRISFactory.AttendanceFactory lcl_obj_AttendanceFactory = new BML.HRISFactory.AttendanceFactory();
                lcl_obj_AttendanceFactory.Initialize();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster lcl_obj_EmployeeAttendanceSummeryMasterTmp = lcl_obj_AttendanceFactory.GetAttendanceSummery(IP_ui64_CompanyCode, IP_dt_DateFrom, IP_dt_DateUpto);
                return lcl_obj_EmployeeAttendanceSummeryMasterTmp;// lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_EmployeeAttendanceSummeryMaster;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction> GetBiometricTransactionListByDateRange(System.UInt64 IP_ui64_EmployeeCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction> lcl_objLst_BMSTransaction = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction>>(() =>
            {
                SilkERP360.BML.SqlManager lcl_obj_SqlManager = new BML.SqlManager();
                lcl_obj_SqlManager.Initialize();
                //Get Corresponding EmployeeId
                System.String lcl_str_SqlQuery = System.String.Format("SELECT EMPLOYEE_ID FROM EMPLOYEE WHERE EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeIdReader = lcl_obj_SqlManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeIdReader.HasRows))
                {
                    lcl_obj_EmployeeIdReader.Close();
                    return null;
                }

                lcl_obj_EmployeeIdReader.Read();
                System.String lcl_str_EmployeeId = lcl_obj_EmployeeIdReader["EMPLOYEE_ID"].ToString();
                lcl_obj_EmployeeIdReader.Close();

                lcl_str_SqlQuery = System.String.Format("SELECT * FROM BMS_TRANSACTION WHERE RTRIM(EMPLOYEE_ID) = '{0}' AND TRAN_DATE_TIME >= TO_DATE('{1}','dd/mm/yyyy hh:mi:ss am') AND TRAN_DATE_TIME <= TO_DATE('{2}','dd/mm/yyyy hh:mi:ss am') ORDER BY TRAN_DATE_TIME DESC", lcl_str_EmployeeId.Trim(), IP_dt_StartDate.ToString("dd/M/yyyy hh:mm:ss tt"), IP_dt_EndDate.ToString("dd/M/yyyy hh:mm:ss tt"));
                
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction> lcl_objLst_BMSTransactionTmp = new List<CCL.BusinessEntities.HRIS.BMSTransaction>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_BMSTransactionReader = lcl_obj_SqlManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_BMSTransactionReader.HasRows))
                {
                    lcl_obj_BMSTransactionReader.Close();
                    return lcl_objLst_BMSTransactionTmp;
                }
                while (lcl_obj_BMSTransactionReader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.BMSTransaction lcl_obj_BMSTransaction = new CCL.BusinessEntities.HRIS.BMSTransaction();
                    lcl_obj_BMSTransaction.EmployeeId = lcl_str_EmployeeId;
                    lcl_obj_BMSTransaction.Trancode = System.UInt64.Parse(lcl_obj_BMSTransactionReader["BMS_TRAN_CODE"].ToString());
                    lcl_obj_BMSTransaction.ReaderName = lcl_obj_BMSTransactionReader["READER_NAME"].ToString();
                    lcl_obj_BMSTransaction.ReaderNo = lcl_obj_BMSTransactionReader["READER_CODE"].ToString();
                    lcl_obj_BMSTransaction.TranDateTime = System.DateTime.Parse(lcl_obj_BMSTransactionReader["TRAN_DATE_TIME"].ToString());
                    lcl_objLst_BMSTransactionTmp.Add(lcl_obj_BMSTransaction);
                }

                lcl_obj_BMSTransactionReader.Close();
                return lcl_objLst_BMSTransactionTmp;// lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_objLst_BMSTransaction;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster GetAttendanceMasterByCompanyDate(System.UInt64 IP_ui64_CompanyCode,System.DateTime IP_dt_AttendanceDate)
        {
            //System.String lcl_str_SqlQuery = 
            SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE_MASTER WHERE ATTENDANCE_DATE = TO_DATE('{0}','dd/mm/yyyy') AND COMPANY_CODE = {1}",IP_dt_AttendanceDate.ToString("dd/M/yyyy"),IP_ui64_CompanyCode);
                SilkERP360.BML.HRIS.AttendanceMasterManager lcl_obj_AttendanceMasterManager = new SilkERP360.BML.HRIS.AttendanceMasterManager();
                lcl_obj_AttendanceMasterManager.Initialize();
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMasterTmp = lcl_obj_AttendanceMasterManager.Get(lcl_str_SqlQuery);
                //System.UInt64 lcl_ui64_LeaveApplicationCodeTmp = lcl_obj_EmployeeLeaveApplicationManager.Save(IP_obj_EmployeeLeaveApplication);
                return lcl_obj_AttendanceMasterTmp;// lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_AttendanceMaster;
        }

        public System.Boolean AdjustOvertime(System.UInt64 IP_ui64_AttendanceCode, System.Int32 IP_i32_OvertimeAdjustment,System.UInt64 IP_ui64_OvertimeAdjustmentEmpCode, System.String IP_str_Remarks)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                System.String lcl_str_Query = System.String.Format("SELECT EMP.IS_OT_ELIGIBLE FROM EMPLOYEE EMP JOIN ATTENDANCE ATN ON EMP.EMPLOYEE_CODE = ATN.EMPLOYEE_CODE WHERE ATN.ATTENDANCE_CODE = {0}", IP_ui64_AttendanceCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeProfileReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_Query);
                lcl_obj_EmployeeProfileReader.Read();
                SilkERP360.CCL.Enums.YesNo lcl_enm_OtEligibility = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(lcl_obj_EmployeeProfileReader["IS_OT_ELIGIBLE"].ToString());
                lcl_obj_EmployeeProfileReader.Close();
                System.String lcl_str_SqlUpdate = System.String.Empty;
                lcl_str_Query = System.String.Format("SELECT AM.ATTENDANCE_MASTER_CODE FROM ATTENDANCE_MASTER AM JOIN ATTENDANCE ATTN ON AM.ATTENDANCE_MASTER_CODE = ATTN.ATTENDANCE_MASTER_CODE WHERE ATTN.ATTENDANCE_CODE = {0}", IP_ui64_AttendanceCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_AttendanceMasterReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_Query);
                lcl_obj_AttendanceMasterReader.Read();
                System.UInt64 lcl_ui64_AttendanceMasterCode = System.UInt64.Parse(lcl_obj_AttendanceMasterReader["ATTENDANCE_MASTER_CODE"].ToString());
                lcl_obj_AttendanceMasterReader.Close();
                if (lcl_enm_OtEligibility == CCL.Enums.YesNo.Yes)
                {
                    //UPDATE OVERTIME
                    if (IP_i32_OvertimeAdjustment < 0)
                    {
                        //Deduct Overtime
                        System.Int32 lcl_i32_TmpOvertimeAdjustment = System.Math.Abs(IP_i32_OvertimeAdjustment);

                        lcl_str_SqlUpdate = System.String.Format("UPDATE ATTENDANCE SET OVERTIME_MANUAL_ADJUSTMENT = {0}" +
                           ",OVERTIME_TOTAL = OVERTIME_AUTO - {1}, " +
                           "REMARKS = '{2}',MANUAL_OT_ADJUSTMENT_EMP_CODE = {3} WHERE ATTENDANCE_CODE = {4}", IP_i32_OvertimeAdjustment, lcl_i32_TmpOvertimeAdjustment, IP_str_Remarks, IP_ui64_OvertimeAdjustmentEmpCode, IP_ui64_AttendanceCode);
                        lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlUpdate);
                        //Update AttendanceMaster.TotalOvertime
                        lcl_str_SqlUpdate = System.String.Format("UPDATE ATTENDANCE_MASTER SET TOTAL_OVERTIME = TOTAL_OVERTIME - {0} WHERE ATTENDANCE_MASTER_CODE = {1}", lcl_i32_TmpOvertimeAdjustment, lcl_ui64_AttendanceMasterCode);
                        lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlUpdate);

                    }
                    else
                    {
                        //Add Overtime
                        System.Int32 lcl_i32_TmpOvertimeAdjustment = System.Math.Abs(IP_i32_OvertimeAdjustment);
                        lcl_str_SqlUpdate = System.String.Format("UPDATE ATTENDANCE SET OVERTIME_MANUAL_ADJUSTMENT = {0}" +
                           ",OVERTIME_TOTAL = OVERTIME_AUTO + {1}, " +
                           "REMARKS = '{2}',MANUAL_OT_ADJUSTMENT_EMP_CODE = {3} WHERE ATTENDANCE_CODE = {4}", lcl_i32_TmpOvertimeAdjustment, lcl_i32_TmpOvertimeAdjustment, IP_str_Remarks, IP_ui64_OvertimeAdjustmentEmpCode, IP_ui64_AttendanceCode);
                        //UPDATE ATTENDANCE SET OVERTIME_MANUAL_ADJUSTMENT = 23,OVERTIME_TOTAL = OVERTIME_TOTAL + 23, REMARKS = '101000000001',MANUAL_OT_ADJUSTMENT_EMP_CODE =  WHERE ATTENDANCE_CODE = 15600000029763
                        lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlUpdate);
                        //Update AttendanceMaster.TotalOvertime
                        lcl_str_SqlUpdate = System.String.Format("UPDATE ATTENDANCE_MASTER SET TOTAL_OVERTIME = TOTAL_OVERTIME + {0} WHERE ATTENDANCE_MASTER_CODE = {1}", lcl_i32_TmpOvertimeAdjustment, lcl_ui64_AttendanceMasterCode);
                        lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlUpdate);
                    }
                }
                else
                {
                    return false;
                }
            
                lcl_obj_SqlFacade.CommitTransaction();
                lcl_obj_SqlFacade.Close();
                return true;// lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.Boolean UpdateAttendanceStatus(System.UInt64 IP_ui64_AttendanceCode, SilkERP360.CCL.Enums.AttendanceStatus IP_enm_AttendanceStatus, System.String IP_str_Remarks)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SqlFacade();
                lcl_obj_SqlFacade.Initialize();

                System.String lcl_str_SqlUpdate = System.String.Format("UPDATE ATTENDANCE SET ATTN_STATUS = {0}, REMARKS = '{1}' WHERE ATTENDANCE_CODE = {2}", (System.UInt32)IP_enm_AttendanceStatus, IP_str_Remarks, IP_ui64_AttendanceCode);
                lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlUpdate);
                lcl_obj_SqlFacade.CommitTransaction();
                lcl_obj_SqlFacade.Close();
                return true;// lcl_ui64_LeaveApplicationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }
    }
}
