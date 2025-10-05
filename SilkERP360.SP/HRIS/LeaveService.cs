using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class LeaveService : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public LeaveService()
        {
            this.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_LeaveApplicationCode">Code of the application to be cancelled</param>
        /// <param name="IP_ui64_CancelEmployeeCode">Employee Who cancelled the leave</param>
        /// <returns>
        /// WSResponse.ResponseCode = -1 > Leave Back Dated. Cannot Be Cancelled.
        /// </returns>
        public SilkERP360.CCL.Misc.WSResponse CancelLeaveApplication(System.UInt64 IP_ui64_LeaveApplicationCode,System.UInt64 IP_ui64_CancelEmployeeCode)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponseTmp = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    BML.HRIS.EmployeeLeaveApplicationManager lcl_obj_EmployeeLeaveApplicationManager = new BML.HRIS.EmployeeLeaveApplicationManager();
                    lcl_obj_EmployeeLeaveApplicationManager.Initialize();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE_LEAVE_APPLICATION WHERE LEAVE_APPLICATION_CODE = {0}", IP_ui64_LeaveApplicationCode);
                    CCL.BusinessEntities.HRIS.EmployeeLeaveApplication lcl_obj_LeaveApp = lcl_obj_EmployeeLeaveApplicationManager.Get(IP_ui64_LeaveApplicationCode, lcl_obj_DBManager.InternalResource);

                    BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new BML.HRIS.DataStructures.EmployeeProfileManager();
                    lcl_obj_EmployeeProfileManager.Initialize();
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_LeaveApp.EmployeeCode, lcl_obj_DBManager.InternalResource);

                    //Policy 1: BackDated Leave cannot be cancelled
                    System.DateTime lcl_dt_Today = System.DateTime.Today;

                    if (((lcl_dt_Today > lcl_obj_LeaveApp.LeaveStartDate) && (lcl_dt_Today > lcl_obj_LeaveApp.LeaveEndDate)))
                    {
                        //Leave back dated and cannot be cancelled
                        //lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "Back Dated Leave Applications Cannot Be Cancelled!!!", true, null);
                        //return lcl_obj_WSResponseTmp;
                    }

                    SilkERP360.SP.HRIS.AttendanceProcessor lcl_obj_AttendanceProcessor = new SilkERP360.SP.HRIS.AttendanceProcessor();
                    lcl_obj_AttendanceProcessor.Init(lcl_obj_DBManager.InternalResource);

                    SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
                    lcl_obj_AttendanceManager.Initialize();
                    System.String lcl_str_AttendanceQuery = System.String.Empty;
                    System.String lcl_str_LeaveAccountUpdate = System.String.Empty;
                    System.String lcl_str_LeaveDelete = System.String.Empty;
                    //for (System.DateTime lcl_dt_Date = lcl_obj_LeaveApp.LeaveStartDate; lcl_dt_Date <= lcl_dt_Today; lcl_dt_Date = lcl_dt_Date.AddDays(1))
                    for (System.DateTime lcl_dt_Date = lcl_obj_LeaveApp.LeaveStartDate; lcl_dt_Date <= lcl_obj_LeaveApp.LeaveEndDate; lcl_dt_Date = lcl_dt_Date.AddDays(1))
                    {
                        //Check If Attendance Has Been Processed for the day
                        lcl_str_AttendanceQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_LeaveApp.EmployeeCode, lcl_dt_Date.ToString("dd/M/yyyy"));
                        SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_PreviousAttendance = lcl_obj_AttendanceManager.Get(lcl_str_AttendanceQuery, lcl_obj_DBManager.InternalResource);
                        if (lcl_obj_PreviousAttendance == null)
                        {
                            //Attendance Not Yet been Processed. No need to update Attendance
                            continue;
                        }
                        //ReProcess Attendance
                        SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceProcessor.Process(lcl_obj_EmployeeProfile, lcl_dt_Date);
                        //Update Attendance
                        lcl_str_AttendanceQuery = System.String.Format(@"UPDATE ATTENDANCE SET DUTY_FROM = TO_DATE('{0}','dd/mm/yyyy hh:mi:ss am'), 
                                                                        IN_THROUGH = '{1}', 
                                                                        DUTY_UPTO = TO_DATE('{2}','dd/mm/yyyy hh:mi:ss am'), 
                                                                        OUT_THROUGH = '{3}', 
                                                                        DUTY_MINUTES = {4}, 
                                                                        OVERTIME_AUTO = {5}, 
                                                                        ATTN_STATUS = {6}, 
                                                                        PAID_PER_HOUR = {7}, 
                                                                        OVERTIME_ENTRY_TYPE = {8},
                                                                        DUTY_SCHEDULE_FROM = TO_DATE('{9}','dd/mm/yyyy hh:mi:ss am'), 
                                                                        DUTY_SCHEDULE_UPTO = TO_DATE('{10}','dd/mm/yyyy hh:mi:ss am'),
                                                                        OVERTIME_MANUAL_ADJUSTMENT = {11}, 
                                                                        OVERTIME_TOTAL = {12},
                                                                        IN_DOOR_NO = {13},
                                                                        OUT_DOOR_NO = {14},
                                                                        NIGHT_ALLOWANCE = {15}
                                                                        WHERE ATTENDANCE_CODE = {16}", lcl_obj_Attendance.DutyFrom.ToString("dd/MM/yyyy hh:mm:ss tt"),
                                                                                                       (lcl_obj_Attendance.InThrough == null) ? System.String.Empty : lcl_obj_Attendance.InThrough.ToString(),
                                                                                                       lcl_obj_Attendance.DutyUpto.ToString("dd/MM/yyyy hh:mm:ss tt"),
                                                                                                       (lcl_obj_Attendance.OutThrough == null) ? System.String.Empty : lcl_obj_Attendance.OutThrough.ToString(),
                                                                                                       lcl_obj_Attendance.DutyMinutes,
                                                                                                       lcl_obj_Attendance.OvertimeAuto,
                                                                                                       (int)lcl_obj_Attendance.AttnStatus,
                                                                                                       lcl_obj_Attendance.PaidPerHour,
                                                                                                       (int)lcl_obj_Attendance.OvertimeEntryType,
                                                                                                       lcl_obj_Attendance.DutyScheduleFrom.ToString("dd/MM/yyyy hh:mm:ss tt"),
                                                                                                       lcl_obj_Attendance.DutyScheduleUpto.ToString("dd/MM/yyyy hh:mm:ss tt"),
                                                                                                       lcl_obj_Attendance.OvertimeManualAdjustment,
                                                                                                       lcl_obj_Attendance.OvertimeTotal,
                                                                                                       lcl_obj_Attendance.InDoorNo,
                                                                                                       lcl_obj_Attendance.OutDoorNo,
                                                                                                       lcl_obj_Attendance.NightAllowance,
                                                                                                       lcl_obj_PreviousAttendance.AttendanceCode);
                        lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_AttendanceQuery);
                    }
                    //update LeaveAccount
                    switch (lcl_obj_LeaveApp.LeaveType)
                    {
                        case CCL.Enums.LeaveType.CL:
                            lcl_str_LeaveAccountUpdate = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET CL = CL + {0} WHERE EMPLOYEE_CODE = {1}", lcl_obj_LeaveApp.NumOfDays, lcl_obj_LeaveApp.EmployeeCode);
                            break;
                        case CCL.Enums.LeaveType.EL:
                            lcl_str_LeaveAccountUpdate = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET EL = EL + {0} WHERE EMPLOYEE_CODE = {1}", lcl_obj_LeaveApp.NumOfDays, lcl_obj_LeaveApp.EmployeeCode);
                            break;
                        case CCL.Enums.LeaveType.ML:
                            lcl_str_LeaveAccountUpdate = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET ML = ML + {0} WHERE EMPLOYEE_CODE = {1}", lcl_obj_LeaveApp.NumOfDays, lcl_obj_LeaveApp.EmployeeCode);
                            break;
                        case CCL.Enums.LeaveType.SL:
                            lcl_str_LeaveAccountUpdate = System.String.Format("UPDATE EMPLOYEE_LEAVE_ACCOUNT SET SL = SL + {0} WHERE EMPLOYEE_CODE = {1}", lcl_obj_LeaveApp.NumOfDays, lcl_obj_LeaveApp.EmployeeCode);
                            break;
                    }
                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_LeaveAccountUpdate);
                    lcl_str_LeaveDelete = System.String.Format("DELETE FROM EMPLOYEE_LEAVE_APPLICATION WHERE LEAVE_APPLICATION_CODE = {0}", lcl_obj_LeaveApp.LeaveApplicationCode);
                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_LeaveDelete);

                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled lcl_obj_EmployeeLeaveCanceled = new CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled();
                    lcl_obj_EmployeeLeaveCanceled.ApplicationDate = lcl_obj_LeaveApp.ApplicationDate;
                    lcl_obj_EmployeeLeaveCanceled.CancelEmployeeCode = IP_ui64_CancelEmployeeCode;
                    lcl_obj_EmployeeLeaveCanceled.EmployeeCode = lcl_obj_LeaveApp.EmployeeCode;
                    lcl_obj_EmployeeLeaveCanceled.EntryEmployeeCode = lcl_obj_LeaveApp.EntryEmployeeCode;
                    lcl_obj_EmployeeLeaveCanceled.LeaveApplicationCode = lcl_obj_LeaveApp.LeaveApplicationCode;
                    lcl_obj_EmployeeLeaveCanceled.LeaveCategory = lcl_obj_LeaveApp.LeaveCategory;
                    lcl_obj_EmployeeLeaveCanceled.LeaveEndDate = lcl_obj_LeaveApp.LeaveEndDate;
                    lcl_obj_EmployeeLeaveCanceled.LeaveStartDate = lcl_obj_LeaveApp.LeaveStartDate;
                    lcl_obj_EmployeeLeaveCanceled.LeaveType = lcl_obj_LeaveApp.LeaveType;
                    lcl_obj_EmployeeLeaveCanceled.NumOfDays = lcl_obj_LeaveApp.NumOfDays;
                    lcl_obj_EmployeeLeaveCanceled.Reason = lcl_obj_LeaveApp.Reason;
                    lcl_obj_EmployeeLeaveCanceled.RejoinDate = lcl_obj_LeaveApp.RejoinDate;
                    lcl_obj_EmployeeLeaveCanceled.Remarks = lcl_obj_EmployeeLeaveCanceled.Remarks;

                    BML.HRIS.EmployeeLeaveCanceledManager lcl_obj_EmployeeLeaveCanceledManager = new BML.HRIS.EmployeeLeaveCanceledManager();
                    lcl_obj_EmployeeLeaveCanceledManager.Initialize();
                    lcl_obj_EmployeeLeaveCanceledManager.Save(lcl_obj_EmployeeLeaveCanceled, lcl_obj_DBManager.InternalResource);


                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Employee Leave Cancelled. Attendance Assessed and Updated successfully!!!", true, null);
                }
                return lcl_obj_WSResponseTmp;
            }, "SPExceptionPolicy");
            return lcl_obj_WSResponse;  
        }
    }
}
