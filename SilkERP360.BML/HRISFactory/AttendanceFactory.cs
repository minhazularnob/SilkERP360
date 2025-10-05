using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SilkERP360.BML.HRISFactory
{
    public class AttendanceFactory : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public AttendanceFactory()
        {
            this.Initialize();
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange GetEmployeewiseAttendanceByDateRange(System.UInt64 IP_ui64_EmployeeCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange lcl_obj_EmployeewiseAttendanceByDateRangeRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange lcl_obj_EmployeewiseAttendanceByDateRange = new CCL.BusinessEntities.HRIS.DataStructures.EmployeewiseAttendanceByDateRange();
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new HRIS.DataStructures.EmployeeProfileManager();
                    lcl_obj_EmployeeProfileManager.Initialize();
                    CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = lcl_obj_EmployeeProfileManager.Get(IP_ui64_EmployeeCode, lcl_obj_DBManager.InternalResource);
                    if (lcl_obj_EmployeeProfile == null)
                    {
                        return null;
                    }
                    lcl_obj_EmployeewiseAttendanceByDateRange.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
                    lcl_obj_EmployeewiseAttendanceByDateRange.Name = lcl_obj_EmployeeProfile.EmployeeName;
                    lcl_obj_EmployeewiseAttendanceByDateRange.Company = lcl_obj_EmployeeProfile.Company.Name;
                    lcl_obj_EmployeewiseAttendanceByDateRange.Department = lcl_obj_EmployeeProfile.Department.Name;
                    lcl_obj_EmployeewiseAttendanceByDateRange.Designation = lcl_obj_EmployeeProfile.Designation.Name;
                    lcl_obj_EmployeewiseAttendanceByDateRange.EmployeeImage = lcl_obj_EmployeeProfile.Image;

                    System.TimeSpan lcl_obj_DateRangeDiff = IP_dt_EndDate - IP_dt_StartDate;
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalAttendanceDays = lcl_obj_DateRangeDiff.Days;
                    lcl_obj_EmployeewiseAttendanceByDateRange.ReportDateRange = IP_dt_StartDate.ToLongDateString() + " TO " + IP_dt_EndDate.ToLongDateString();

                    BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new HRIS.AttendanceManager();
                    lcl_obj_AttendanceManager.Initialize();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND (ATTENDANCE_DATE BETWEEN TO_DATE('{1}','dd/mm/yyyy') AND TO_DATE('{2}','dd/mm/yyyy'))", IP_ui64_EmployeeCode, IP_dt_StartDate.ToString("dd/M/yyyy"), IP_dt_EndDate.ToString("dd/M/yyyy"));
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Attendance> lcl_objLst_Attendance = lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    if (lcl_objLst_Attendance == null)
                    {
                        return null;
                    }

                    System.Double lcl_dbl_TotalDutyMinute = 0;
                    System.Int32 lcl_ui32_TotalWorkHourExpected = 0;
                    System.Double lcl_dbl_TotalWorkHourServed = 0;
                    System.Double lcl_dbl_TotalOvertimeAuto = 0;
                    System.Double lcl_dbl_TotalOvertimeManual = 0;
                    System.Double lcl_dbl_TotalOvertime = 0;
                    System.Decimal lcl_dcm_TotalNightAllowance = 0;

                    System.Double lcl_dbl_TotalWorkingDays = 0;
                    System.Double lcl_dbl_TotalLate = 0;
                    System.Double lcl_dbl_TotalAbsent = 0;

                    foreach (CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance in lcl_objLst_Attendance)
                    {
                        CCL.BusinessEntities.HRIS.DataStructures.DaysAttendance lcl_obj_DaysAttendance = new CCL.BusinessEntities.HRIS.DataStructures.DaysAttendance();
                        lcl_obj_DaysAttendance.NightAllowance = lcl_obj_Attendance.NightAllowance.ToString();
                        lcl_obj_DaysAttendance.AttendanceDate = lcl_obj_Attendance.AttendaneDate.ToString("dd/M/yyyy");
                        lcl_dcm_TotalNightAllowance += lcl_obj_Attendance.NightAllowance;
                        if ((lcl_obj_Attendance.AttendaneDate.Day == 31) && (lcl_obj_Attendance.AttendaneDate.Month == 12) && (lcl_obj_Attendance.AttendaneDate.Year == 2014))
                        {
                            //Only Exception 31/December/2014 As O.T input was manual
                            lcl_obj_DaysAttendance.DutyDateTime = "";
                            lcl_obj_DaysAttendance.DutyHour = "00:00";
                            lcl_obj_DaysAttendance.OvertimeAuto = "0";
                            if (lcl_obj_Attendance.OvertimeManualAdjustment > 0)
                            {
                                lcl_obj_DaysAttendance.OvertimeManual = ((int)(System.Math.Ceiling(lcl_obj_Attendance.OvertimeManualAdjustment) / 60)).ToString() + ":" + (System.Math.Ceiling(lcl_obj_Attendance.OvertimeManualAdjustment) % 60);
                                lcl_obj_DaysAttendance.Overtime = ((int)(System.Math.Ceiling(lcl_obj_Attendance.OvertimeTotal) / 60)).ToString() + ":" + (System.Math.Ceiling(lcl_obj_Attendance.OvertimeTotal) % 60);
                            }
                            lcl_dbl_TotalDutyMinute += lcl_obj_Attendance.DutyMinutes;
                            lcl_ui32_TotalWorkHourExpected += (lcl_obj_Attendance.DutyScheduleUpto - lcl_obj_Attendance.DutyScheduleFrom).Hours;
                            lcl_dbl_TotalWorkHourServed += System.TimeSpan.FromMinutes(lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal).Hours;

                            lcl_dbl_TotalOvertimeAuto += System.Math.Ceiling(lcl_obj_Attendance.OvertimeAuto);
                            lcl_dbl_TotalOvertimeManual += System.Math.Ceiling(lcl_obj_Attendance.OvertimeManualAdjustment);
                            lcl_dbl_TotalOvertime += System.Math.Ceiling(lcl_obj_Attendance.OvertimeTotal);
                        }
                        else
                        {
                            if ((lcl_obj_Attendance.DutyScheduleFrom != System.DateTime.MinValue) && (lcl_obj_Attendance.DutyScheduleUpto != System.DateTime.MinValue))
                            {
                                lcl_obj_DaysAttendance.DutyScheduleDateTime = lcl_obj_Attendance.DutyScheduleFrom.ToString("dd/M/yyyy hh:mm:ss tt") + " TO " + lcl_obj_Attendance.DutyScheduleUpto.ToString("dd/M/yyyy hh:mm:ss tt");


                                if ((lcl_obj_Attendance.DutyFrom != System.DateTime.MinValue) && (lcl_obj_Attendance.DutyUpto != System.DateTime.MinValue))
                                {
                                    lcl_obj_DaysAttendance.DutyDateTime = lcl_obj_Attendance.DutyFrom.ToString("dd/M/yyyy hh:mm:ss tt") + " TO " + lcl_obj_Attendance.DutyUpto.ToString("dd/M/yyyy hh:mm:ss tt");
                                    lcl_obj_DaysAttendance.DutyHour = ((int)(lcl_obj_Attendance.DutyMinutes / 60)).ToString() + ":" + ((int)(lcl_obj_Attendance.DutyMinutes % 60)).ToString();
                                    lcl_obj_DaysAttendance.OvertimeAuto = ((int)(System.Math.Ceiling(lcl_obj_Attendance.OvertimeAuto) / 60)).ToString() + ":" + (System.Math.Ceiling(lcl_obj_Attendance.OvertimeAuto) % 60);
                                    lcl_obj_DaysAttendance.OvertimeManual = ((int)(System.Math.Ceiling(lcl_obj_Attendance.OvertimeManualAdjustment) / 60)).ToString() + ":" + (System.Math.Ceiling(lcl_obj_Attendance.OvertimeManualAdjustment) % 60);
                                    lcl_obj_DaysAttendance.Overtime = ((int)(System.Math.Ceiling(lcl_obj_Attendance.OvertimeTotal) / 60)).ToString() + ":" + (System.Math.Ceiling(lcl_obj_Attendance.OvertimeTotal) % 60);
                                }

                                if((lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.HOLIDAY) && 
                                    (lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.ON_LEAVE) &&
                                    (lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.WEEKEND) && 
                                    (lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY))
                                {
                                    //lcl_ui32_TotalWorkHourExpected += (lcl_obj_Attendance.DutyScheduleUpto - lcl_obj_Attendance.DutyScheduleFrom).Hours;
                                    lcl_ui32_TotalWorkHourExpected += (int)((lcl_obj_Attendance.DutyScheduleUpto - lcl_obj_Attendance.DutyScheduleFrom).TotalMinutes);
                                }

                                lcl_dbl_TotalDutyMinute += lcl_obj_Attendance.DutyMinutes;
                                //lcl_dbl_TotalWorkHourServed += System.TimeSpan.FromMinutes(lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal).Hours;
                                lcl_dbl_TotalWorkHourServed += lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal;

                                lcl_dbl_TotalOvertimeAuto += System.Math.Ceiling(lcl_obj_Attendance.OvertimeAuto);
                                lcl_dbl_TotalOvertimeManual += System.Math.Ceiling(lcl_obj_Attendance.OvertimeManualAdjustment);
                                lcl_dbl_TotalOvertime += System.Math.Ceiling(lcl_obj_Attendance.OvertimeTotal);
                                //lcl_dbl_TotalWorkHourServed += (lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal);
                            }
                        }
                        switch (lcl_obj_Attendance.AttnStatus)
                        {
                            case CCL.Enums.AttendanceStatus.ABSENT:
                                lcl_obj_DaysAttendance.AttendanceStatus = "ABSENT";
                                lcl_dbl_TotalAbsent++;
                                lcl_dbl_TotalWorkingDays++;
                                break;
                            case CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND:
                                lcl_obj_DaysAttendance.AttendanceStatus = "ABSENT NO WG";
                                lcl_dbl_TotalWorkingDays++;
                                break;
                            case CCL.Enums.AttendanceStatus.HOLIDAY:
                                lcl_obj_DaysAttendance.AttendanceStatus = "HOLIDAY";
                                lcl_obj_DaysAttendance.DutyScheduleDateTime = "XXXXX";
                                lcl_obj_DaysAttendance.DutyDateTime = "XXXXX";
                                break;
                            case CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY:
                                lcl_obj_DaysAttendance.AttendanceStatus = "SHFT CHNG HOLIDAY";
                                lcl_obj_DaysAttendance.DutyScheduleDateTime = "XXXXX";
                                lcl_obj_DaysAttendance.DutyDateTime = "XXXXX";
                                break;
                            case CCL.Enums.AttendanceStatus.LATE:
                                lcl_dbl_TotalWorkingDays++;
                                lcl_dbl_TotalLate++;
                                lcl_obj_DaysAttendance.AttendanceStatus = "LATE";
                                break;
                            case CCL.Enums.AttendanceStatus.LATE_APPROVED:
                                lcl_dbl_TotalWorkingDays++;
                                lcl_dbl_TotalLate++;
                                lcl_obj_DaysAttendance.AttendanceStatus = "LATE APPROVED";
                                break;
                            case CCL.Enums.AttendanceStatus.ON_LEAVE:
                                lcl_dbl_TotalWorkingDays++;
                                lcl_obj_DaysAttendance.AttendanceStatus = "LEAVE";
                                break;
                            case CCL.Enums.AttendanceStatus.PRESENT:
                                lcl_obj_DaysAttendance.AttendanceStatus = "PRESENT";
                                lcl_dbl_TotalWorkingDays++;
                                break;
                            case CCL.Enums.AttendanceStatus.WEEKEND:
                                lcl_obj_DaysAttendance.AttendanceStatus = "WEEKEND";
                                lcl_obj_DaysAttendance.DutyScheduleDateTime = "XXXXX";
                                lcl_obj_DaysAttendance.DutyDateTime = "XXXXX";
                                break;
                            case CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
                                lcl_obj_DaysAttendance.AttendanceStatus = "WRK ON HOLIDAY";
                                break;
                            case CCL.Enums.AttendanceStatus.OUTSIDE_DUTY:
                                lcl_dbl_TotalWorkingDays++;
                                lcl_obj_DaysAttendance.AttendanceStatus = "OUTSIDE DUTY";
                                break;
                        }
                        lcl_obj_DaysAttendance.Remarks = lcl_obj_Attendance.Remarks;
                        lcl_obj_EmployeewiseAttendanceByDateRange.DaysAttendanceList.Add(lcl_obj_DaysAttendance);
                    }

                    //Calculate Late and Absent Percentage
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalAbsentPercentage = (lcl_dbl_TotalAbsent == 0) ? 0 : System.Math.Round(((System.Double)(lcl_dbl_TotalAbsent / lcl_dbl_TotalWorkingDays) * 100), 2);

                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalLatePercentage = (lcl_dbl_TotalLate == 0) ? 0 : System.Math.Round((System.Double)(lcl_dbl_TotalLate / lcl_dbl_TotalWorkingDays) * 100,2); 

 
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalWorkHourExpected = ((int)(lcl_ui32_TotalWorkHourExpected / 60)).ToString() + ":" + ((int)(lcl_ui32_TotalWorkHourExpected % 60)).ToString();
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalWorkHourServed = ((int)(lcl_dbl_TotalWorkHourServed / 60)).ToString() + ":" + ((int)(lcl_dbl_TotalWorkHourServed % 60)).ToString();
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalOvertimeAuto = ((int)(lcl_dbl_TotalOvertimeAuto / 60)).ToString() + ":" + ((int)(lcl_dbl_TotalOvertimeAuto % 60)).ToString();
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalOvertimeManual = ((int)(lcl_dbl_TotalOvertimeManual / 60)).ToString() + ":" + ((int)(lcl_dbl_TotalOvertimeManual % 60)).ToString();
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalOvertime = ((int)(lcl_dbl_TotalOvertime / 60)).ToString() + ":" + ((int)(lcl_dbl_TotalOvertime % 60)).ToString();
                    lcl_obj_EmployeewiseAttendanceByDateRange.TotalNightAllowance = lcl_dcm_TotalNightAllowance.ToString();
                    return lcl_obj_EmployeewiseAttendanceByDateRange;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeewiseAttendanceByDateRangeRet;
        }

        /// <summary>
        /// 1. Create One EmployeeAttendanceSummery object for each employee and save in a List<>
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_dt_DateFrom"></param>
        /// <param name="IP_dt_DateUpto"></param>
        /// <returns></returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster GetAttendanceSummery(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_DateFrom, System.DateTime IP_dt_DateUpto)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster lcl_obj_EmployeeAttendanceSummeryMasterRet = null;
            //System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE_MASTER WHERE WORK_GROUP_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','DD/MM/YYYY')", IP_ui64_WorkGroupCode, IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
            lcl_obj_EmployeeAttendanceSummeryMasterRet = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster lcl_obj_EmployeeAttendanceSummeryMaster = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummeryMaster();

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery> lcl_objLst_AttendanceSummery = new List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery>();

                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP_PER.FATHER_NAME,EMP_PER.MOTHER_NAME,EMP_PER.CITIZEN_CARD_ID,EMP_PER.DATE_OF_BIRTH,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                            DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS
                                                                            FROM EMPLOYEE EMP 
                                                                            JOIN EMPLOYEE_PERSONAL EMP_PER
                                                                            ON EMP.EMPLOYEE_CODE = EMP_PER.EMPLOYEE_CODE
                                                                            JOIN COMPANY COMP
                                                                            ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                            JOIN DEPARTMENT DEPT
                                                                            ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                            JOIN DESIGNATION DESIG
                                                                            ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                            JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                            ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                            WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1  Order By  DEPT.RANK,DESIG.RANK ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);

                    //Create List<> of EmployeeAttendanceSummery for all active employee as of Today
                    System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (!(lcl_obj_EmployeeReader.HasRows))
                    {
                        lcl_obj_EmployeeReader.Close();
                        return null;
                    }
                    else
                    {
                        while (lcl_obj_EmployeeReader.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery lcl_obj_EmployeeAttendanceSummeryTmp = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery();
                            lcl_obj_EmployeeAttendanceSummeryTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_CODE"].ToString());
                            lcl_obj_EmployeeAttendanceSummeryTmp.EmployeeId = lcl_obj_EmployeeReader["EMPLOYEE_ID"].ToString();
                            lcl_obj_EmployeeAttendanceSummeryTmp.EmployeeName = lcl_obj_EmployeeReader["EMPLOYEE_NAME"].ToString();
                            lcl_obj_EmployeeAttendanceSummeryTmp.Department = lcl_obj_EmployeeReader["DEPT_NAME"].ToString();
                            lcl_obj_EmployeeAttendanceSummeryTmp.Designation = lcl_obj_EmployeeReader["DEGN_NAME"].ToString();
                            lcl_objLst_AttendanceSummery.Add(lcl_obj_EmployeeAttendanceSummeryTmp);
                        }
                        lcl_obj_EmployeeReader.Close();
                    }

                    /*
                     * IMPORTANT!
                     * Filter lcl_objLst_AttendanceSummery. Filter out EmployeeAttendanceSummery of employees who did not join within the date range
                     * If An employees data not found in Attendance table for a particular date, Means Employee Did not join during the specified period
                     * */
                    SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new HRIS.AttendanceManager();
                    lcl_obj_AttendanceManager.Initialize();
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery lcl_obj_EmployeeAttendanceSummery in lcl_objLst_AttendanceSummery)
                    {
                        //Check Attendance of Each day of the Date Range specified
                        for (System.DateTime lcl_obj_AttendanceDate = IP_dt_DateFrom; lcl_obj_AttendanceDate <= IP_dt_DateUpto; lcl_obj_AttendanceDate = lcl_obj_AttendanceDate.AddDays(1))
                        {
                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_EmployeeAttendanceSummery.EmployeeCode, lcl_obj_AttendanceDate.ToString("dd/M/yyyy"));
                            SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                            //if (lcl_obj_Attendance.OvertimeTotal > 0)
                            //{
                            //    int k = 0;
                            //}
                            if (lcl_obj_Attendance == null)
                            {
                                continue;
                            }
                            else
                            {
                                //Calculate AttendanceSummery
                                switch (lcl_obj_Attendance.AttnStatus)
                                {
                                    case CCL.Enums.AttendanceStatus.LATE:
                                        lcl_obj_EmployeeAttendanceSummery.TotalLate++;
                                        break;
                                    case CCL.Enums.AttendanceStatus.LATE_APPROVED:
                                        lcl_obj_EmployeeAttendanceSummery.TotalLateApproved++;
                                        break;
                                    case CCL.Enums.AttendanceStatus.HOLIDAY:
                                    case CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY:
                                        lcl_obj_EmployeeAttendanceSummery.TotalHoliday++;
                                        break;
                                    case CCL.Enums.AttendanceStatus.ON_LEAVE:
                                        lcl_obj_EmployeeAttendanceSummery.TotalLeave++;
                                        break;
                                    case CCL.Enums.AttendanceStatus.PRESENT:
                                        lcl_obj_EmployeeAttendanceSummery.TotalPresent++;
                                        break;
                                    case CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
                                        lcl_obj_EmployeeAttendanceSummery.TotalWorkOnHoliday++;
                                        break;
                                    case CCL.Enums.AttendanceStatus.WEEKEND:
                                        lcl_obj_EmployeeAttendanceSummery.TotalWeekend++;
                                        break;
                                    case CCL.Enums.AttendanceStatus.ABSENT:
                                    case CCL.Enums.AttendanceStatus.ABSENT_NO_DATA_FOUND:
                                        lcl_obj_EmployeeAttendanceSummery.TotalAbsent++;
                                        break;
                                }
                                System.TimeSpan lcl_obj_DesignatedWorkHour = System.TimeSpan.MinValue;
                                if ((lcl_obj_Attendance.DutyScheduleFrom == System.DateTime.MinValue) ||
                                    (lcl_obj_Attendance.DutyScheduleUpto == System.DateTime.MinValue))
                                {
                                    lcl_obj_DesignatedWorkHour = System.TimeSpan.Parse("0");
                                }
                                else
                                {
                                    lcl_obj_DesignatedWorkHour = lcl_obj_Attendance.DutyScheduleUpto - lcl_obj_Attendance.DutyScheduleFrom;
                                }
                                if (lcl_obj_DesignatedWorkHour != System.TimeSpan.MinValue)
                                {
                                    if ((lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.ON_LEAVE) &&
                                        (lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.SHIFT_CHANGE_HOLIDAY) &&
                                        (lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.WEEKEND) &&
                                        (lcl_obj_Attendance.AttnStatus != CCL.Enums.AttendanceStatus.HOLIDAY))
                                    {
                                        lcl_obj_EmployeeAttendanceSummery.TotalDesignatedWorkHour += (System.Double)lcl_obj_DesignatedWorkHour.TotalHours;
                                    }
                                    lcl_obj_EmployeeAttendanceSummery.TotalWorkHour += ((System.Double)(lcl_obj_Attendance.DutyMinutes - lcl_obj_Attendance.OvertimeTotal) / 60);
                                    lcl_obj_EmployeeAttendanceSummery.TotalWorkHour = System.Math.Ceiling(lcl_obj_EmployeeAttendanceSummery.TotalWorkHour);
                                }
                                lcl_obj_EmployeeAttendanceSummery.TotalOvertimeAuto += lcl_obj_Attendance.OvertimeAuto;
                                lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual += lcl_obj_Attendance.OvertimeManualAdjustment;
                                lcl_obj_EmployeeAttendanceSummery.TotalOvertime += lcl_obj_Attendance.OvertimeTotal;
                                lcl_obj_EmployeeAttendanceSummery.TotalNightAllowance += lcl_obj_Attendance.NightAllowance;
                                //Round Up value
                                //lcl_obj_EmployeeAttendanceSummery.TotalDesignatedWorkHour += System.Math.Floor(lcl_obj_EmployeeAttendanceSummery.TotalDesignatedWorkHour);
                                //lcl_obj_EmployeeAttendanceSummery.TotalWorkHour += System.Math.Floor(lcl_obj_EmployeeAttendanceSummery.TotalWorkHour);

                                lcl_obj_EmployeeAttendanceSummery.TotalDays++;
                                
                            }
                            //if (lcl_obj_EmployeeAttendanceSummery.TotalDays > 0)
                            //{
                            //    System.TimeSpan lcl_ts_TotalOvertimeAuto = System.TimeSpan.FromMinutes(lcl_obj_EmployeeAttendanceSummery.TotalOvertimeAuto);
                            //    System.TimeSpan lcl_ts_TotalOvertimeManual = System.TimeSpan.FromMinutes(lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual);
                            //    System.TimeSpan lcl_ts_TotalOvertime = System.TimeSpan.FromMinutes(lcl_obj_EmployeeAttendanceSummery.TotalOvertime);

                            //    lcl_obj_EmployeeAttendanceSummery.TotalOvertimeAuto += lcl_obj_EmployeeAttendanceSummery.TotalOvertimeAuto;// lcl_ts_TotalOvertimeAuto.TotalHours;//    (double)(lcl_obj_Attendance.OvertimeAuto / 60);
                            //    lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual += lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual;// lcl_ts_TotalOvertimeManual.TotalHours;
                            //    lcl_obj_EmployeeAttendanceSummery.TotalOvertime += lcl_obj_EmployeeAttendanceSummery.TotalOvertime;
                            
                                
                            //}
                        }
                        lcl_obj_EmployeeAttendanceSummeryMaster.AttendanceSummeryList.Add(lcl_obj_EmployeeAttendanceSummery);
                    }

                    //Generate AttendanceSummeryMaster
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery lcl_obj_EmployeeAttendanceSummery in lcl_obj_EmployeeAttendanceSummeryMaster.AttendanceSummeryList)
                    {
                        //Convert To Hours
                        System.TimeSpan lcl_ts_TotalOvertimeAuto = System.TimeSpan.FromMinutes(lcl_obj_EmployeeAttendanceSummery.TotalOvertimeAuto);
                        System.TimeSpan lcl_ts_TotalOvertimeManual = System.TimeSpan.FromMinutes(lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual);
                        System.TimeSpan lcl_ts_TotalOvertime = System.TimeSpan.FromMinutes(lcl_obj_EmployeeAttendanceSummery.TotalOvertime);

                        lcl_obj_EmployeeAttendanceSummery.TotalOvertimeAuto = System.Math.Round(lcl_ts_TotalOvertimeAuto.TotalHours, 2); ;// lcl_ts_TotalOvertimeAuto.TotalHours;//    (double)(lcl_obj_Attendance.OvertimeAuto / 60);
                        lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual = System.Math.Round(lcl_ts_TotalOvertimeManual.TotalHours,2);// lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual;// lcl_ts_TotalOvertimeManual.TotalHours;
                        lcl_obj_EmployeeAttendanceSummery.TotalOvertime = System.Math.Round(lcl_ts_TotalOvertime.TotalHours,2);// lcl_obj_EmployeeAttendanceSummery.TotalOvertime;

                        lcl_obj_EmployeeAttendanceSummeryMaster.TotalEmployees++;
                        lcl_obj_EmployeeAttendanceSummeryMaster.TotalDesignatedWorkHour += lcl_obj_EmployeeAttendanceSummery.TotalDesignatedWorkHour;
                        lcl_obj_EmployeeAttendanceSummeryMaster.TotalWorkHour += lcl_obj_EmployeeAttendanceSummery.TotalWorkHour;
                        lcl_obj_EmployeeAttendanceSummeryMaster.TotalOvertimeAuto += lcl_obj_EmployeeAttendanceSummery.TotalOvertimeAuto;
                        lcl_obj_EmployeeAttendanceSummeryMaster.TotalOvertimeManual += lcl_obj_EmployeeAttendanceSummery.TotalOvertimeManual;
                        lcl_obj_EmployeeAttendanceSummeryMaster.TotalOvertime += lcl_obj_EmployeeAttendanceSummery.TotalOvertime;
                        lcl_obj_EmployeeAttendanceSummeryMaster.TotalNightAllowance += lcl_obj_EmployeeAttendanceSummery.TotalNightAllowance;
                    }
                    //lcl_obj_EmployeeAttendanceSummeryMaster.TotalEmployees += 1;
                }
                return lcl_obj_EmployeeAttendanceSummeryMaster;
            }, "BMLExceptionPolicy");
            //return lcl_obj_WorkGroup;
            return lcl_obj_EmployeeAttendanceSummeryMasterRet;
        }

        public SilkERP360.CCL.Misc.WSResponse ProcessAttendanceByGroupAndDate(System.UInt64 IP_ui64_WorkGroupCode, System.DateTime IP_dt_AttendanceDate)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE_MASTER WHERE WORK_GROUP_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','DD/MM/YYYY')", IP_ui64_WorkGroupCode, IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
            lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    //check if attendance already processed 
                    SilkERP360.BML.HRIS.AttendanceMasterManager lcl_obj_AttendanceMasterManager = new HRIS.AttendanceMasterManager();
                    lcl_obj_AttendanceMasterManager.Initialize();
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster> lcl_objLst_AttendanceMaster = lcl_obj_AttendanceMasterManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    if ((lcl_objLst_AttendanceMaster != null) || (lcl_objLst_AttendanceMaster.Count > 0))
                    {
                        //Attendance Already Processed
                        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "Attendance For the selected WorkGroup for the selected date has already been processed!!!", false, null);
                    }

                    //Get WorkGroupOperationMaster for the selected WorkGroup and Date
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WHERE WORK_GROUP_CODE = {0} AND WORK_DATE = TO_DATE('{1}','DD/MM/YYYY')", IP_ui64_WorkGroupCode, IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
                    SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                    lcl_obj_WorkGroupOperationMasterManager.Initialize();
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster> lcl_objLst_WorkGroupOperationMaster = lcl_obj_WorkGroupOperationMasterManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    if ((lcl_objLst_WorkGroupOperationMaster == null) || (lcl_objLst_WorkGroupOperationMaster.Count == 0))
                    {
                        //WorkGroup Not Yet Configured
                        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -2, "Selected WorkGroup has not yet been configured!!!", false, null);
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = lcl_objLst_WorkGroupOperationMaster[0];
                    //AttendanceMaster to be returned after processing
                    SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
                    lcl_obj_AttendanceMaster.AttendaneDate = IP_dt_AttendanceDate;
                    //lcl_obj_AttendanceMaster.WorkGroupCode = IP_ui64_WorkGroupCode;

                    SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new HRIS.DataStructures.EmployeeProfileManager();
                    lcl_obj_EmployeeProfileManager.Initialize();

                    System.String lcl_str_DutyStartTime = lcl_obj_WorkGroupOperationMaster.DutyStartFrom;
                    System.String lcl_str_DutyStartDateTime = System.String.Format("{0} {1}", IP_dt_AttendanceDate.ToString("dd/MM/yyyy"), lcl_str_DutyStartTime);
                    System.DateTime lcl_dt_DutyStartFrom = System.DateTime.ParseExact(lcl_str_DutyStartDateTime, "dd/MMMM/yyyy hh:mm tt",CultureInfo.InvariantCulture); 
                    System.UInt32 lcl_ui32_DutyHour = lcl_obj_WorkGroupOperationMaster.DutyHour;
                    System.DateTime lcl_dt_DutyUpto = lcl_dt_DutyStartFrom.AddHours(lcl_ui32_DutyHour);

                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection)
                    {
                    }



                    //get WorkGroup Object
                    SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new SilkERP360.BML.HRIS.WorkGroupManager();
                    SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroupTmp = lcl_obj_WorkGroupManager.Get(IP_ui64_WorkGroupCode, lcl_obj_DBManager.InternalResource);
                    if (lcl_obj_WorkGroupTmp == null)
                    {
                        //Incorrect WorkGroupCode
                        return null;
                    }

                    //SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WHERE WORK_GROUP_CODE = {0} AND WORK_DATE = TO_DATE('{1}','DD/MM/YYYY')", IP_ui64_WorkGroupCode, IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
                    //SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = lcl_obj_WorkGroupOperationMasterManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    if (lcl_obj_WorkGroupOperationMaster == null)
                    {
                        //lcl_obj_WorkGroupOperationMaster == null -> WorkGroupOperationMaster has not yet been configured
                        //return lcl_obj_WorkGroupTmp;
                        return null;
                    }

                    lcl_obj_WorkGroupTmp.WorkGroupOperationMaster = lcl_obj_WorkGroupOperationMaster;
                    //Get WorkGroupOperationHistory lists containning employees assigned in the WorkGroup
                    SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new HRIS.WorkGroupOperationHistoryManager();
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0} AND IS_DELETED = 0", lcl_obj_WorkGroupTmp.WorkGroupOperationMaster.WorkGroupOperationMasterCode);
                    lcl_obj_WorkGroupTmp.WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    //SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = null;
                    if (lcl_obj_WorkGroupTmp.WorkGroupOperationMaster.WorkGroupOperationHistoryCollection.Count > 0)
                    {
                        lcl_obj_EmployeeProfileManager = new HRIS.DataStructures.EmployeeProfileManager();

                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in lcl_obj_WorkGroupTmp.WorkGroupOperationMaster.WorkGroupOperationHistoryCollection)
                        {
                            //Get EmployeeProfile for each WorkGroupOperationHistory
                            //lcl_obj_WorkGroupOperationHistory.EmployeeProfile = lcl_obj_EmployeeProfileManager.GetWithoutImage(lcl_obj_WorkGroupOperationHistory.EmployeeCode, lcl_obj_DBManager.InternalResource);
                        }
                    }

                    lcl_obj_DBManager.InternalResource.Close();
                    //return lcl_obj_WorkGroupTmp;
                    return null;
                }
            }, "BMLExceptionPolicy");
            //return lcl_obj_WorkGroup;
            return null;
        }
    }
}
