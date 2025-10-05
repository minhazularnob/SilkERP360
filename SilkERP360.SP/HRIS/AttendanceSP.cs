using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class AttendanceSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public AttendanceSP()
        {
            this.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_WorkGroupCode"></param>
        /// <param name="IP_dt_AttendanceDate"></param>
        /// <returns>If Attendance Not Found, returns null</returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster GetAttendanceMasterByWorkGroupAndDate(System.UInt64 IP_ui64_WorkGroupCode, System.DateTime IP_dt_AttendanceDate)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    //Get Assigned Employee List of selected WorkGroup on Selected date
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT EMP.EMPLOYEE_CODE FROM EMPLOYEE EMP JOIN DESIGNATION DESIG ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE WHERE EMP.EMPLOYEE_CODE =Any(SELECT WGOH.EMPLOYEE_CODE FROM WORK_GROUP_OPERATION_MASTER WGOM JOIN WORK_GROUP_OPERATION_HISTORY WGOH ON WGOM.WG_OPERATION_MASTER_CODE = WGOH.WG_OPERATION_MASTER_CODE WHERE WGOM.WORK_GROUP_CODE = {0} AND WGOM.WORK_DATE = TO_DATE('{1}','DD/MM/YYYY')) ORDER BY DESIG.RANK ASC",IP_ui64_WorkGroupCode,IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
                    System.Data.OracleClient.OracleDataReader lcl_obj_WGReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_WGReader.HasRows == false)
                    {
                        //No Employee Assigned To This WG or WG has not yet been configured
                        return null;
                    }
                    System.Collections.Generic.List<System.UInt64> lcl_objLst_EmployeeCodeList = new List<System.UInt64>();
                    while (lcl_obj_WGReader.Read())
                    {
                        lcl_objLst_EmployeeCodeList.Add(System.UInt64.Parse(lcl_obj_WGReader["EMPLOYEE_CODE"].ToString()));
                    }

                    lcl_obj_TmpAttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
                    SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new BML.HRIS.AttendanceManager();
                    lcl_obj_AttendanceManager.Initialize();
                    System.Double lcl_dbl_TotalOvertime = 0.0;
                    foreach (System.UInt64 lcl_ui64_EmployeeCode in lcl_objLst_EmployeeCodeList)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','DD/MM/YYYY')",lcl_ui64_EmployeeCode,IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
                        SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_SqlQuery,lcl_obj_DBManager.InternalResource);

                        if (lcl_obj_Attendance == null)
                        {
                            //Attendance Has Not Yet Been Processed
                            //return null;
                            continue;
                        }

                        lcl_obj_TmpAttendanceMaster.TotalProcessed++;
                        lcl_dbl_TotalOvertime += lcl_obj_Attendance.OvertimeTotal;
                        switch (lcl_obj_Attendance.AttnStatus)
                        {
                            case CCL.Enums.AttendanceStatus.PRESENT:
                            case CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
                                lcl_obj_TmpAttendanceMaster.TotalPresent++;
                                break;
                            case CCL.Enums.AttendanceStatus.ABSENT:
                                lcl_obj_TmpAttendanceMaster.TotalAbsent++;
                                break;
                            case CCL.Enums.AttendanceStatus.HOLIDAY:
                            case CCL.Enums.AttendanceStatus.WEEKEND:
                                lcl_obj_TmpAttendanceMaster.TotalHoliday++;
                                break;
                            case CCL.Enums.AttendanceStatus.LATE:
                            case CCL.Enums.AttendanceStatus.LATE_APPROVED:
                                lcl_obj_TmpAttendanceMaster.TotalLate++;
                                break;
                            case CCL.Enums.AttendanceStatus.ON_LEAVE:
                                lcl_obj_TmpAttendanceMaster.TotalLeave++;
                                break;
                        }
                        lcl_obj_TmpAttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                    }
                    lcl_obj_TmpAttendanceMaster.TotalOvertime = (System.UInt32)lcl_dbl_TotalOvertime;
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpAttendanceMaster;
            }, "SPExceptionPolicy");
            return lcl_obj_AttendanceMaster;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_WorkGroupCode"></param>
        /// <param name="IP_dt_AttendanceDate"></param>
        /// <returns>If Attendance Not Found, returns null</returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster GetAttendanceMasterByDesignationAndDate(System.UInt64 IP_ui64_DesignationCode, System.DateTime IP_dt_AttendanceDate)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    //Get Assigned Employee List of selected WorkGroup on Selected date
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT EMP.EMPLOYEE_CODE FROM EMPLOYEE EMP JOIN DESIGNATION DESIG ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE WHERE DESIG.DESIGNATION_CODE = {0}", IP_ui64_DesignationCode );
                    System.Data.OracleClient.OracleDataReader lcl_obj_WGReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_WGReader.HasRows == false)
                    {
                        //No Employee Assigned To This WG or WG has not yet been configured
                        return null;
                    }
                    System.Collections.Generic.List<System.UInt64> lcl_objLst_EmployeeCodeList = new List<System.UInt64>();
                    while (lcl_obj_WGReader.Read())
                    {
                        lcl_objLst_EmployeeCodeList.Add(System.UInt64.Parse(lcl_obj_WGReader["EMPLOYEE_CODE"].ToString()));
                    }

                    lcl_obj_TmpAttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
                    SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new BML.HRIS.AttendanceManager();
                    lcl_obj_AttendanceManager.Initialize();
                    System.Double lcl_dbl_TotalOvertime = 0.0;
                    foreach (System.UInt64 lcl_ui64_EmployeeCode in lcl_objLst_EmployeeCodeList)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','DD/MM/YYYY')", lcl_ui64_EmployeeCode, IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
                        SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                        if (lcl_obj_Attendance == null)
                        {
                            //Attendance Has Not Yet Been Processed
                            //return null;
                            continue;
                        }

                        lcl_obj_TmpAttendanceMaster.TotalProcessed++;
                        lcl_dbl_TotalOvertime += lcl_obj_Attendance.OvertimeTotal;
                        switch (lcl_obj_Attendance.AttnStatus)
                        {
                            case CCL.Enums.AttendanceStatus.PRESENT:
                            case CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
                                lcl_obj_TmpAttendanceMaster.TotalPresent++;
                                break;
                            case CCL.Enums.AttendanceStatus.ABSENT:
                                lcl_obj_TmpAttendanceMaster.TotalAbsent++;
                                break;
                            case CCL.Enums.AttendanceStatus.HOLIDAY:
                            case CCL.Enums.AttendanceStatus.WEEKEND:
                                lcl_obj_TmpAttendanceMaster.TotalHoliday++;
                                break;
                            case CCL.Enums.AttendanceStatus.LATE:
                            case CCL.Enums.AttendanceStatus.LATE_APPROVED:
                                lcl_obj_TmpAttendanceMaster.TotalLate++;
                                break;
                            case CCL.Enums.AttendanceStatus.ON_LEAVE:
                                lcl_obj_TmpAttendanceMaster.TotalLeave++;
                                break;
                        }
                        lcl_obj_TmpAttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                    }
                    lcl_obj_TmpAttendanceMaster.TotalOvertime = (System.UInt32)lcl_dbl_TotalOvertime;
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpAttendanceMaster;
            }, "SPExceptionPolicy");
            return lcl_obj_AttendanceMaster;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_WorkGroupCode"></param>
        /// <param name="IP_dt_AttendanceDate"></param>
        /// <returns>If Attendance Not Found, returns null</returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster GetAttendanceMasterByDesignationListAndDate(System.Collections.Generic.List<System.UInt64> IP_ui64Lst_DesignationCodes, System.DateTime IP_dt_AttendanceDate)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_TmpAttendanceMaster = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    //Get Assigned Employee List of selected WorkGroup on Selected date
                    System.Collections.Generic.List<System.UInt64> lcl_objLst_EmployeeCodeList = new List<System.UInt64>();
                    System.String lcl_str_SqlQuery = System.String.Empty;
                    foreach (System.UInt64 lcl_ui64_DesignationCode in IP_ui64Lst_DesignationCodes)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT EMP.EMPLOYEE_CODE FROM EMPLOYEE EMP JOIN DESIGNATION DESIG ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE WHERE DESIG.DESIGNATION_CODE = {0}", lcl_ui64_DesignationCode);
                        System.Data.OracleClient.OracleDataReader lcl_obj_EmpReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                        if (lcl_obj_EmpReader.HasRows == false)
                        {
                            //No Employee Assigned To This WG or WG has not yet been configured
                            //lcl_obj_DBManager.InternalResource.Close();
                            lcl_obj_EmpReader.Close();
                            continue;
                        }
                        
                        while (lcl_obj_EmpReader.Read())
                        {
                            lcl_objLst_EmployeeCodeList.Add(System.UInt64.Parse(lcl_obj_EmpReader["EMPLOYEE_CODE"].ToString()));
                        }
                        lcl_obj_EmpReader.Close();
                    }

                    lcl_obj_TmpAttendanceMaster = new CCL.BusinessEntities.HRIS.AttendanceMaster();
                    SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new BML.HRIS.AttendanceManager();
                    lcl_obj_AttendanceManager.Initialize();
                    System.Double lcl_dbl_TotalOvertime = 0.0;
                    foreach (System.UInt64 lcl_ui64_EmployeeCode in lcl_objLst_EmployeeCodeList)
                    {
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM ATTENDANCE WHERE EMPLOYEE_CODE = {0} AND ATTENDANCE_DATE = TO_DATE('{1}','DD/MM/YYYY')", lcl_ui64_EmployeeCode, IP_dt_AttendanceDate.ToString("dd/MM/yyyy"));
                        SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = lcl_obj_AttendanceManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                        if (lcl_obj_Attendance == null)
                        {
                            //Attendance Has Not Yet Been Processed
                            //return null;
                            continue;
                        }

                        lcl_obj_TmpAttendanceMaster.TotalProcessed++;
                        lcl_dbl_TotalOvertime += lcl_obj_Attendance.OvertimeTotal;
                        switch (lcl_obj_Attendance.AttnStatus)
                        {
                            case CCL.Enums.AttendanceStatus.PRESENT:
                            case CCL.Enums.AttendanceStatus.WORK_ON_HOLIDAY:
                                lcl_obj_TmpAttendanceMaster.TotalPresent++;
                                break;
                            case CCL.Enums.AttendanceStatus.ABSENT:
                                lcl_obj_TmpAttendanceMaster.TotalAbsent++;
                                break;
                            case CCL.Enums.AttendanceStatus.HOLIDAY:
                            case CCL.Enums.AttendanceStatus.WEEKEND:
                                lcl_obj_TmpAttendanceMaster.TotalHoliday++;
                                break;
                            case CCL.Enums.AttendanceStatus.LATE:
                            case CCL.Enums.AttendanceStatus.LATE_APPROVED:
                                lcl_obj_TmpAttendanceMaster.TotalLate++;
                                break;
                            case CCL.Enums.AttendanceStatus.ON_LEAVE:
                                lcl_obj_TmpAttendanceMaster.TotalLeave++;
                                break;
                        }
                        lcl_obj_TmpAttendanceMaster.AttendanceList.Add(lcl_obj_Attendance);
                    }
                    lcl_obj_TmpAttendanceMaster.TotalOvertime = (System.UInt32)lcl_dbl_TotalOvertime;
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpAttendanceMaster;
            }, "SPExceptionPolicy");
            return lcl_obj_AttendanceMaster;
        }
    }
}
