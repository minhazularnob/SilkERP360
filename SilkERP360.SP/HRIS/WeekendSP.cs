using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class WeekendSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public WeekendSP()
        {
            this.Initialize();
        }

        /// <summary>
        /// Uses SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeWithWeekend to send to client
        /// </summary>
        /// <param name="IP_dt_WeekendDate"></param>
        /// <returns></returns>
        public SilkERP360.CCL.Misc.WSResponse GetWeekendEmployeesByDate(System.DateTime IP_dt_WeekendDate)
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

                    SilkERP360.BML.HRIS.WeekendManager lcl_obj_WeekendManager = new BML.HRIS.WeekendManager();
                    lcl_obj_WeekendManager.Initialize();

                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM WEEKEND WHERE WEEKEND_DATE = TO_DATE('{0}','dd/mm/yyyy')", IP_dt_WeekendDate.ToString("dd/M/yyyy"));
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Weekend> lcl_objLst_Weekends = lcl_obj_WeekendManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    SilkERP360.BML.Services.HRIS.EmployeeServices lcl_obj_EmployeeService = new BML.Services.HRIS.EmployeeServices();
                    lcl_obj_EmployeeService.Initialize();

                    if (lcl_objLst_Weekends.Count == 0)
                    {
                        //No EmployeeWeekend found on selected day
                        lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "No Employee Was assigned to have Weekend on the selected day!", true, null);
                        lcl_obj_DBManager.InternalResource.Close();
                        return lcl_obj_WSResponseTmp;
                    }

                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeWithWeekend> lcl_objLst_EmployeeWithWeekend
                                                                                        = new List<CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeWithWeekend>();
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Weekend lcl_obj_Weekend in lcl_objLst_Weekends)
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfileMini lcl_obj_EmployeeProfile = lcl_obj_EmployeeService.GetMiniEmplpoyeeProfile(lcl_obj_Weekend.EmployeeCode, lcl_obj_DBManager.InternalResource);
                        SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeWithWeekend lcl_obj_EmployeeWithWeekend = new CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeWithWeekend();
                        lcl_obj_EmployeeWithWeekend.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                        lcl_obj_EmployeeWithWeekend.EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
                        lcl_obj_EmployeeWithWeekend.EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                        lcl_obj_EmployeeWithWeekend.DepartmentName = lcl_obj_EmployeeProfile.DepartmentName;
                        lcl_obj_EmployeeWithWeekend.DesignationName = lcl_obj_EmployeeProfile.Designation;
                        lcl_obj_EmployeeWithWeekend.WeekendCode = lcl_obj_Weekend.WeekendCode;
                        lcl_obj_EmployeeWithWeekend.WeekendDate = lcl_obj_Weekend.WeekendDate;
                        lcl_obj_EmployeeWithWeekend.WeekDayName = lcl_obj_Weekend.Weekday;
                        switch (lcl_obj_EmployeeWithWeekend.WeekDayName)
                        {
                            case CCL.Enums.WeekDay.Friday:
                                lcl_obj_EmployeeWithWeekend.WeekDayNameSTR = "FRIDAY";
                                break;
                            case CCL.Enums.WeekDay.Saturday:
                                lcl_obj_EmployeeWithWeekend.WeekDayNameSTR = "SATURDAY";
                                break;
                            case CCL.Enums.WeekDay.Sunday:
                                lcl_obj_EmployeeWithWeekend.WeekDayNameSTR = "SUNDAY";
                                break;
                            case CCL.Enums.WeekDay.Monday:
                                lcl_obj_EmployeeWithWeekend.WeekDayNameSTR = "MONDAY";
                                break;
                            case CCL.Enums.WeekDay.Tuesday:
                                lcl_obj_EmployeeWithWeekend.WeekDayNameSTR = "TUESDAY";
                                break;
                            case CCL.Enums.WeekDay.Wednesday:
                                lcl_obj_EmployeeWithWeekend.WeekDayNameSTR = "WEDNESDAY";
                                break;
                            case CCL.Enums.WeekDay.Thursday:
                                lcl_obj_EmployeeWithWeekend.WeekDayNameSTR = "THURSDAY";
                                break;
                        }
                        lcl_objLst_EmployeeWithWeekend.Add(lcl_obj_EmployeeWithWeekend);
                    }
                    lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Weekend Employees Retrieved Successfully!", true, lcl_objLst_EmployeeWithWeekend);
                    lcl_obj_DBManager.InternalResource.Close();
                    return lcl_obj_WSResponseTmp;
                }
            }, "SPExceptionPolicy");
            return lcl_obj_WSResponse;  
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_FromDate"></param>
        /// <param name="IP_str_UptoDate"></param>
        /// <param name="IP_objLst_EmployeeAssignedWeekend"></param>
        /// <returns></returns>
        public SilkERP360.CCL.Misc.WSResponse AssignWeekend(System.UInt64 IP_ui64_EntryEmployeeCode, System.DateTime IP_dt_FromDate, System.DateTime IP_dt_UptoDate, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeAssignedWeekend> IP_objLst_EmployeeAssignedWeekend)
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

                    //Global Objects
                    SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new BML.HRIS.WorkGroupOperationHistoryManager();
                    lcl_obj_WorkGroupOperationHistoryManager.Initialize();
                    SilkERP360.BML.HRIS.WeekendManager lcl_obj_WeekendManager = new BML.HRIS.WeekendManager();
                    lcl_obj_WeekendManager.Initialize();
                    System.String lcl_str_SqlQuery = System.String.Empty;
                    //New WeekendObject
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Weekend> lcl_objLst_NewWeekends = new List<CCL.BusinessEntities.HRIS.Weekend>();

                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeAssignedWeekend lcl_obj_EmployeeAssignedWeekend in IP_objLst_EmployeeAssignedWeekend)
                    {
                        //Sort the Date that is Weekend by the WeekdayName assigned
                        System.Collections.Generic.List<System.DateTime> lcl_objLst_WeekendDates = new List<DateTime>();
                        for (System.DateTime lcl_obj_Date = IP_dt_FromDate; lcl_obj_Date.Date < IP_dt_UptoDate.Date; lcl_obj_Date = lcl_obj_Date.AddDays(1))
                        {
                            System.Int32 lcl_i32_TmpWeekDayNameIndex = (System.Int32)lcl_obj_Date.DayOfWeek;
                            System.Int32 lcl_i32_ModifiedWeekdayNameIndex = ((lcl_i32_TmpWeekDayNameIndex >= 0) && (lcl_i32_TmpWeekDayNameIndex <= 5)) ? lcl_i32_TmpWeekDayNameIndex + 2 : 1;
                            if (lcl_obj_EmployeeAssignedWeekend.WeekDayName == (SilkERP360.CCL.Enums.WeekDay)lcl_i32_ModifiedWeekdayNameIndex)
                            {
                                lcl_objLst_WeekendDates.Add(lcl_obj_Date);
                            }
                            
                        }
                        if (lcl_objLst_WeekendDates.Count == 0)
                        {
                            //No Selected WeekendDay does not fall in Selected Date Range
                            lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Selected Day Not Found in the Date Range Selected!!!No Weekend Updated!!!", true, null);
                            lcl_obj_DBManager.InternalResource.RollbackTransaction();
                            lcl_obj_DBManager.InternalResource.Close();
                            return lcl_obj_WSResponseTmp;
                            //break;
                        }

                        //Check WorkGroup Assignment of Emp. on All Weekend dates. If assigned, Remove All Assignment
                        System.Collections.Generic.List<System.String> lcl_strLst_WorkGroupOperationHistoryCleanupSql = new List<string>();
                        foreach (System.DateTime lcl_dt_WeekendDate in lcl_objLst_WeekendDates)
                        {
                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WGOH JOIN WORK_GROUP_OPERATION_MASTER WGOM ON WGOH.WG_OPERATION_MASTER_CODE = WGOM.WG_OPERATION_MASTER_CODE WHERE WGOH.EMPLOYEE_CODE = {0} AND WGOM.WORK_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_EmployeeAssignedWeekend.EmployeeCode, lcl_dt_WeekendDate.ToString("dd/M/yyyy"));
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> lcl_objLst_WorkGroupOperationHistory = lcl_obj_WorkGroupOperationHistoryManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                            if (lcl_objLst_WorkGroupOperationHistory.Count == 0)
                            {
                                continue;
                            }
                            foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_TmpWorkGroupOperationHistory in lcl_objLst_WorkGroupOperationHistory)
                            {
                                lcl_strLst_WorkGroupOperationHistoryCleanupSql.Add(System.String.Format("DELETE FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_HISTORY_CODE = {0}", lcl_obj_TmpWorkGroupOperationHistory.EmployeeWorkGroupHistoryCode));
                            }
                        }
                        //Cleanup WorkGroupOperationHistory
                        foreach (System.String lcl_str_SqlDelete in lcl_strLst_WorkGroupOperationHistoryCleanupSql)
                        {
                            //lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlDelete);
                        }
                      /**********************************************************************************************************************/
                        
                        //Create new Weekend Object for Each Weekend Date sorted Earlier
                        foreach (System.DateTime lcl_dt_WeekendDate in lcl_objLst_WeekendDates)
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.Weekend lcl_obj_WeekEnd = new CCL.BusinessEntities.HRIS.Weekend();
                            lcl_obj_WeekEnd.EmployeeCode = lcl_obj_EmployeeAssignedWeekend.EmployeeCode;
                            lcl_obj_WeekEnd.EntryEmployeeCode = IP_ui64_EntryEmployeeCode;
                            lcl_obj_WeekEnd.Weekday = lcl_obj_EmployeeAssignedWeekend.WeekDayName;
                            System.Globalization.CultureInfo cul = System.Globalization.CultureInfo.CurrentCulture;
                            //lcl_obj_WeekEnd.WeekNumber = cul.Calendar.GetWeekOfYear(lcl_dt_WeekendDate, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Saturday);
                            lcl_obj_WeekEnd.WeekNumber = cul.Calendar.GetWeekOfYear(lcl_dt_WeekendDate, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Saturday);
                            lcl_obj_WeekEnd.Year = lcl_dt_WeekendDate.Year;
                            lcl_obj_WeekEnd.WeekendDate = lcl_dt_WeekendDate;
                            lcl_objLst_NewWeekends.Add(lcl_obj_WeekEnd);
                        }
                    }
                    //Cleanup Weekend 
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Weekend lcl_obj_NewWeekEnd in lcl_objLst_NewWeekends)
                    {
                        //Check If Weekend already assigned for the selected Week.
                        //If assigned and Weekend already passed, return with appropriate message
                        lcl_str_SqlQuery = System.String.Format("SELECT * FROM WEEKEND WHERE EMPLOYEE_CODE = {0} AND WEEK_NUMBER = {1} AND YEAR = {2}", lcl_obj_NewWeekEnd.EmployeeCode, (System.Int32)lcl_obj_NewWeekEnd.WeekNumber, lcl_obj_NewWeekEnd.Year);
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Weekend> lcl_objLst_ExistingWeekends = lcl_obj_WeekendManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                        if (lcl_objLst_ExistingWeekends.Count == 0)
                        {
                            continue;
                        }
                        else
                        {
                            foreach (SilkERP360.CCL.BusinessEntities.HRIS.Weekend lcl_obj_ExistingWeekEnd in lcl_objLst_ExistingWeekends)
                            {
                                //Check Existing Weekend Date is a day in the past
                                if (lcl_obj_ExistingWeekEnd.WeekendDate <= System.DateTime.Today)
                                {
                                    //Weekend Already Enjoyed For this week. Cannot Assign New Weekend
                                    System.String lcl_str_Message = System.String.Format("Weekend Already Enjoyed on {0} For the Weeknumber : {1} of Year : {2}. Cannot Reassign.Forward Weekend Start Date!!", lcl_obj_ExistingWeekEnd.WeekendDate.ToString("dd/M/yyyy"), lcl_obj_ExistingWeekEnd.WeekNumber, lcl_obj_ExistingWeekEnd.Year);
                                    lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, lcl_str_Message, true, null);
                                    lcl_obj_DBManager.InternalResource.RollbackTransaction();
                                    lcl_obj_DBManager.InternalResource.Close();
                                    return lcl_obj_WSResponseTmp;
                                }
                            }
                        }
                    }

                    //Cleanup All Future Weekend compared to IP_dt_DateFrom for selected employees
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeAssignedWeekend lcl_obj_EmployeeAssignedWeekend in IP_objLst_EmployeeAssignedWeekend)
                    {
                        System.String lcl_str_Delete = System.String.Format("DELETE FROM WEEKEND WHERE EMPLOYEE_CODE = {0} AND WEEKEND_DATE >= TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_EmployeeAssignedWeekend.EmployeeCode, IP_dt_FromDate.ToString("dd/M/yyyy"));
                        lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_Delete);
                    }

                    //Save The Weekends
                   

                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Weekend lcl_obj_NewWeekEnd in lcl_objLst_NewWeekends)
                    {
                        lcl_obj_WeekendManager.Save(lcl_obj_NewWeekEnd, lcl_obj_DBManager.InternalResource);
                    }
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Weekend Updated Successfully!!", true, null);
                    return lcl_obj_WSResponseTmp;
                }
                return lcl_obj_WSResponseTmp;
            }, "SPExceptionPolicy");
            return lcl_obj_WSResponse;  
        }

        public SilkERP360.CCL.Misc.WSResponse CancelWeekend(System.UInt64 IP_ui64_WeekendCode)
        {
             SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
             {
                 if (IP_ui64_WeekendCode == 0)
                 {
                     return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "FATAL ERROR ON THE CLIENT : INFORM R&D!", false, null);
                 }
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponseTmp = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    //Global Objects
                    SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new BML.HRIS.WorkGroupOperationHistoryManager();
                    lcl_obj_WorkGroupOperationHistoryManager.Initialize();
                    SilkERP360.BML.HRIS.WeekendManager lcl_obj_WeekendManager = new BML.HRIS.WeekendManager();
                    lcl_obj_WeekendManager.Initialize();
                    SilkERP360.CCL.BusinessEntities.HRIS.Weekend lcl_obj_Weekend = lcl_obj_WeekendManager.Get(IP_ui64_WeekendCode, lcl_obj_DBManager.InternalResource);

                    if (lcl_obj_Weekend == null)
                    {
                        lcl_obj_DBManager.InternalResource.Close();
                        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "FATAL SERVICE ERROR : INFORM R&D!", false, null);
                    }
                    //If Weekend Already been enjoyed
                    if (lcl_obj_Weekend.WeekendDate <= System.DateTime.Today)
                    {
                        lcl_obj_DBManager.InternalResource.Close();
                        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "WEEKEND ALREADY AVAILED. CANNOT CANCEL!!!", false, null);
                    }
                    //Cancel Weekend
                    System.String lcl_str_DeleteQuery = System.String.Format("DELETE WEEKEND WHERE WEEKEND_CODE = {0}", IP_ui64_WeekendCode);
                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_DeleteQuery);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    System.String lcl_str_SqlQuery = System.String.Empty;
                    //New WeekendObject

                    lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "WEEKEND CANCELED SUCCESSFULLY!!", false, null);
                    return lcl_obj_WSResponseTmp;
                }
                 
            }, "SPExceptionPolicy");
            return lcl_obj_WSResponse;
        }
    }
}
