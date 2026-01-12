using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SilkERP360.BML.HRISFactory
{
    public class WorkGroupFactory : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public WorkGroupFactory()
        {
            this.Initialize();
        }

        /// <summary>
        /// /If OperationalStatus == 0 -> Update all other fields except OperationalStatus 
        /// </summary>
        /// <param name="IP_obj_WorkGroupOperationMasterProfile"></param>
        /// <returns>
        /// 0 -> All Update Ok
        //-1 -> If Attendance Has Already been processed, dont update anything
        /// </returns>
        public System.Int32 UpdateWorkGroupOperationMaster(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile IP_obj_WorkGroupOperationMasterProfile)
        {
            if (IP_obj_WorkGroupOperationMasterProfile.IsAttendanceProcessed == CCL.Enums.YesNo.Yes)
            {
                //CHECKING HERE BECAUSE, USER CANNOT UPDATE THIS VALUE.
                //NO NEED TO DISABLE UPDATE BUTTON ON THE CLIENT
                return -1;
            }

            System.Int32 Response = this.ExceptionManager.Process<System.Int32>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new BML.HRIS.WorkGroupManager();
                lcl_obj_WorkGroupManager.Initialize();
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlUpdate = System.String.Empty;
                    if (IP_obj_WorkGroupOperationMasterProfile.OperationalStatus == CCL.Enums.WorkGroupOperationalStatus.NotYetInitialized)
                    {
                        lcl_str_SqlUpdate = System.String.Format(@"UPDATE WORK_GROUP_OPERATION_MASTER SET DUTY_HOUR = {0},DUTY_START_FROM = '{1}',OVERTIME_LIMIT = {2} WHERE WG_OPERATION_MASTER_CODE = {3}", IP_obj_WorkGroupOperationMasterProfile.DutyHour, IP_obj_WorkGroupOperationMasterProfile.DutyFrom, IP_obj_WorkGroupOperationMasterProfile.OvertimeLimit, IP_obj_WorkGroupOperationMasterProfile.WorkGroupOperationMasterCode);
                    }
                    else
                    {
                        lcl_str_SqlUpdate = System.String.Format(@"UPDATE WORK_GROUP_OPERATION_MASTER SET DUTY_HOUR = {0},DUTY_START_FROM = '{1}',OVERTIME_LIMIT = {2},OPERATIONAL_STATUS = {3} WHERE WG_OPERATION_MASTER_CODE = {4}", IP_obj_WorkGroupOperationMasterProfile.DutyHour, IP_obj_WorkGroupOperationMasterProfile.DutyFrom, IP_obj_WorkGroupOperationMasterProfile.OvertimeLimit, (System.Int32)IP_obj_WorkGroupOperationMasterProfile.OperationalStatus, IP_obj_WorkGroupOperationMasterProfile.WorkGroupOperationMasterCode);
                    }
                    //WHERE COMP.COMPANY_CODE = {0} AND EMP.JOINING_DATE <= TO_DATE('{1}','dd/mm/yyyy') AND (EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3} OR EMP.EMPLOYEE_STATUS = {4}) AND EMP.IS_DELETED = 1  Order By  DEPT.RANK,DESIG.RANK ASC", IP_ui64_CompanyCode, IP_dt_Date.ToString("dd/M/yyyy"), (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                    //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlUpdate);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();

                }
                return 0;
            }, "BMLExceptionPolicy");
            return Response;
        }

        public System.Int32 DeleteWorkGroupOperationMaster(List<UInt64> IP_obj_workGroupMasterCodeList, string User)
        {
            // Nothing to delete
            if (IP_obj_workGroupMasterCodeList == null || IP_obj_workGroupMasterCodeList.Count == 0)
                return -1;
            System.Int32 Response = this.ExceptionManager.Process<System.Int32>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new BML.HRIS.WorkGroupManager();
                lcl_obj_WorkGroupManager.Initialize();
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlUpdate = System.String.Empty;

                    string idList = string.Join(",", IP_obj_workGroupMasterCodeList);

                    System.String lcl_str_SqlQuery = $"SELECT WG_OPERATION_MASTER_CODE FROM work_group_operation_master WHERE wg_operation_master_code IN ({idList}) and is_processed=1";
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WGReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (lcl_obj_WGReader.HasRows)
                    {
                        lcl_obj_WGReader.Close();
                        return -1;
                    }

                    /* Insert HISTORY backup */
                    string sqlInsertHistoryBkp = $@"INSERT INTO work_group_operation_history_bkp
                                                    (WG_OPERATION_HISTORY_CODE,
                                                     WG_OPERATION_MASTER_CODE,
                                                     EMPLOYEE_CODE,
                                                     ASSESSMENT_STATUS,
                                                     IS_DELETED)
                                                    SELECT
                                                     WG_OPERATION_HISTORY_CODE,
                                                     WG_OPERATION_MASTER_CODE,
                                                     EMPLOYEE_CODE,
                                                     ASSESSMENT_STATUS,
                                                     IS_DELETED
                                                    FROM work_group_operation_history
                                                    WHERE wg_operation_master_code IN ({idList})";

                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(sqlInsertHistoryBkp);

                    /*Insert MASTER backup */
                    string sqlInsertMasterBkp = $@"INSERT INTO work_group_operation_master_bkp
                                                    (
                                                     WG_OPERATION_MASTER_CODE,
                                                     WORK_GROUP_CODE,
                                                     WORK_DATE,
                                                     WORKER_STRENGTH,
                                                     OPERATIONAL_STATUS,
                                                     IS_PROCESSED,
                                                     TOTAL_PRESENT,
                                                     TOTAL_ABSENT,
                                                     TOTAL_LATE,
                                                     DUTY_START_FROM,
                                                     DUTY_HOUR,
                                                     IS_PROCESSED_FOR_SALARY,
                                                     DAY_ATTRIBUTE,
                                                     ENTRY_EMPLOYEE_CODE,
                                                     ENTRY_DATE,
                                                     TOTAL_MAN_HOUR,
                                                     TOTAL_OVERTIME,
                                                     TOTAL_LEAVE,
                                                     TOTAL_OFF,
                                                     OVERTIME_LIMIT,
                                                     DELETED_BY,
                                                     DELETED_TIME
                                                    )
                                                    SELECT
                                                     WG_OPERATION_MASTER_CODE,
                                                     WORK_GROUP_CODE,
                                                     WORK_DATE,
                                                     WORKER_STRENGTH,
                                                     OPERATIONAL_STATUS,
                                                     IS_PROCESSED,
                                                     TOTAL_PRESENT,
                                                     TOTAL_ABSENT,
                                                     TOTAL_LATE,
                                                     DUTY_START_FROM,
                                                     DUTY_HOUR,
                                                     IS_PROCESSED_FOR_SALARY,
                                                     DAY_ATTRIBUTE,
                                                     ENTRY_EMPLOYEE_CODE,
                                                     ENTRY_DATE,
                                                     TOTAL_MAN_HOUR,
                                                     TOTAL_OVERTIME,
                                                     TOTAL_LEAVE,
                                                     TOTAL_OFF,
                                                     OVERTIME_LIMIT,
                                                     '{User}',
                                                     SYSDATE
                                                    FROM work_group_operation_master
                                                    WHERE wg_operation_master_code IN ({idList})";

                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(sqlInsertMasterBkp);

                    string sqlDeleteChild = $"DELETE FROM work_group_operation_history WHERE wg_operation_master_code IN ({idList})";
                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(sqlDeleteChild);

                    // 2️⃣ Delete from parent table
                    string sqlDeleteParent = $"DELETE FROM work_group_operation_master WHERE wg_operation_master_code IN ({idList})";
                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(sqlDeleteParent);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();

                }
                return 0;
            }, "BMLExceptionPolicy");
            return Response;
        }

        /// <summary>
        /// Gets WorkGroupOperation Master details for all WorkGroups of a Company for a date
        /// </summary>
        /// <param name="IP_ui64_CompanyCode"></param>
        /// <param name="IP_dt_Date"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile> GetWorkGroupSchedules(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_Date)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile> lcl_objLst_WorkGroupOperationMasterProfileRet = null;
            lcl_objLst_WorkGroupOperationMasterProfileRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile>>(() =>
            {
                SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new BML.HRIS.WorkGroupManager();
                lcl_obj_WorkGroupManager.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile> lcl_objLst_WorkGroupOperationMasterProfile = new List<CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile>();
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT * FROM WORK_GROUP WHERE COMPANY_CODE = {0} ORDER BY WORK_GROUP_CODE ASC",IP_ui64_CompanyCode);
                                                                            //WHERE COMP.COMPANY_CODE = {0} AND EMP.JOINING_DATE <= TO_DATE('{1}','dd/mm/yyyy') AND (EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3} OR EMP.EMPLOYEE_STATUS = {4}) AND EMP.IS_DELETED = 1  Order By  DEPT.RANK,DESIG.RANK ASC", IP_ui64_CompanyCode, IP_dt_Date.ToString("dd/M/yyyy"), (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                    //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WGReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (!(lcl_obj_WGReader.HasRows))
                    {
                        lcl_obj_WGReader.Close();
                        return null;
                    }
                    else
                    {
                        while (lcl_obj_WGReader.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile lcl_obj_WorkGroupOperationMasterProfile = new CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile();
                            lcl_obj_WorkGroupOperationMasterProfile.WorkGroupCode = System.UInt64.Parse(lcl_obj_WGReader["WORK_GROUP_CODE"].ToString());
                            lcl_obj_WorkGroupOperationMasterProfile.WorkGroupName = lcl_obj_WGReader["WORK_GROUP_NAME"].ToString();
                            lcl_objLst_WorkGroupOperationMasterProfile.Add(lcl_obj_WorkGroupOperationMasterProfile);
                        }
                        lcl_obj_WGReader.Close();

                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile lcl_obj_WorkGroupOperationMasterProfile in lcl_objLst_WorkGroupOperationMasterProfile)
                        {
                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WHERE WORK_GROUP_CODE = {0} AND WORK_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_WorkGroupOperationMasterProfile.WorkGroupCode, IP_dt_Date.ToString("dd/M/yyyy"));
                            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WGOperationMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                            if (!(lcl_obj_WGOperationMasterReader.HasRows))
                            {
                                lcl_obj_WGOperationMasterReader.Close();
                                continue;
                            }
                            else
                            {
                                lcl_obj_WGOperationMasterReader.Read();
                                lcl_obj_WorkGroupOperationMasterProfile.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_WGOperationMasterReader["WG_OPERATION_MASTER_CODE"].ToString());
                                lcl_obj_WorkGroupOperationMasterProfile.WorkerStrength = System.UInt32.Parse(lcl_obj_WGOperationMasterReader["WORKER_STRENGTH"].ToString());
                                lcl_obj_WorkGroupOperationMasterProfile.OvertimeLimit = System.UInt32.Parse(lcl_obj_WGOperationMasterReader["OVERTIME_LIMIT"].ToString());
                                lcl_obj_WorkGroupOperationMasterProfile.DutyHour = System.UInt32.Parse(lcl_obj_WGOperationMasterReader["DUTY_HOUR"].ToString());
                                lcl_obj_WorkGroupOperationMasterProfile.DutyFrom = lcl_obj_WGOperationMasterReader["DUTY_START_FROM"].ToString();
                                lcl_obj_WorkGroupOperationMasterProfile.WorkDate = System.DateTime.Parse(lcl_obj_WGOperationMasterReader["WORK_DATE"].ToString());
                                lcl_obj_WorkGroupOperationMasterProfile.OperationalStatus = (SilkERP360.CCL.Enums.WorkGroupOperationalStatus)System.Int32.Parse(lcl_obj_WGOperationMasterReader["OPERATIONAL_STATUS"].ToString());
                                lcl_obj_WorkGroupOperationMasterProfile.IsAttendanceProcessed = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(lcl_obj_WGOperationMasterReader["IS_PROCESSED"].ToString());
                                lcl_obj_WGOperationMasterReader.Close();
                            }
                        }
                    }

                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_objLst_WorkGroupOperationMasterProfile;
            }, "BMLExceptionPolicy");
            return lcl_objLst_WorkGroupOperationMasterProfileRet;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule> GetEmployeeWorkGroupScheduleByDate(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_Date)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule> lcl_objLst_EmployeeWorkGroupScheduleRet = null;
            lcl_objLst_EmployeeWorkGroupScheduleRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule>>(() =>
            {
                SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = new BML.HRIS.DataStructures.EmployeeProfileManager();
                lcl_obj_EmployeeProfileManager.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule> lcl_objLst_EmployeeWorkGroupSchedule = new List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule>();
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
                                                                            WHERE COMP.COMPANY_CODE = {0} AND EMP.JOINING_DATE <= TO_DATE('{1}','dd/mm/yyyy') AND (EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3} OR EMP.EMPLOYEE_STATUS = {4}) AND EMP.IS_DELETED = 1  Order By  DEPT.RANK,DESIG.RANK ASC", IP_ui64_CompanyCode, IP_dt_Date.ToString("dd/M/yyyy"), (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                    //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileManager.GetListWithoutImage(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);

                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (!(lcl_obj_EmployeeReader.HasRows))
                    {
                        lcl_obj_EmployeeReader.Close();
                        return null;
                    }
                    else
                    {
                        while (lcl_obj_EmployeeReader.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule lcl_obj_EmployeeWorkGroupScheduleTmp = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule();
                            lcl_obj_EmployeeWorkGroupScheduleTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_CODE"].ToString());
                            lcl_obj_EmployeeWorkGroupScheduleTmp.EmployeeId = lcl_obj_EmployeeReader["EMPLOYEE_ID"].ToString();
                            lcl_obj_EmployeeWorkGroupScheduleTmp.EmployeeName = lcl_obj_EmployeeReader["EMPLOYEE_NAME"].ToString();
                            lcl_obj_EmployeeWorkGroupScheduleTmp.Department = lcl_obj_EmployeeReader["DEPT_NAME"].ToString();
                            lcl_obj_EmployeeWorkGroupScheduleTmp.Designation = lcl_obj_EmployeeReader["DEGN_NAME"].ToString();
                            lcl_objLst_EmployeeWorkGroupSchedule.Add(lcl_obj_EmployeeWorkGroupScheduleTmp);
                        }
                        lcl_obj_EmployeeReader.Close();
                    }

                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule lcl_obj_EmployeeWorkGroupSchedule in lcl_objLst_EmployeeWorkGroupSchedule)
                    {
                        

                        lcl_str_SqlQuery = System.String.Format("SELECT WG.WORK_GROUP_NAME,WGOM.WG_OPERATION_MASTER_CODE,WGOM.WORK_DATE,WGOM.DUTY_START_FROM,WGOM.DUTY_HOUR " +
                            " FROM WORK_GROUP WG JOIN WORK_GROUP_OPERATION_MASTER WGOM " +
                            "ON WG.WORK_GROUP_CODE = WGOM.WORK_GROUP_CODE " +
                            "JOIN WORK_GROUP_OPERATION_HISTORY WGOH " +
                            "ON WGOM.WG_OPERATION_MASTER_CODE = WGOH.WG_OPERATION_MASTER_CODE " +
                            "WHERE WGOH.EMPLOYEE_CODE = {0} AND WGOM.WORK_DATE = TO_DATE('{1}','dd/mm/yyyy')", lcl_obj_EmployeeWorkGroupSchedule.EmployeeCode, IP_dt_Date.ToString("dd/M/yyyy"));

                        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WGReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                        if (!(lcl_obj_WGReader.HasRows))
                        {
                            //employee not assigned to any WorkGroup for the date
                            lcl_obj_EmployeeWorkGroupSchedule.WorkGroupOperationMasterCode = 0;
                            lcl_obj_EmployeeWorkGroupSchedule.WorkGroupName = "";
                            lcl_obj_EmployeeWorkGroupSchedule.DutyScheduleFrom = System.DateTime.MinValue;
                            lcl_obj_EmployeeWorkGroupSchedule.DutyScheduleUpto = System.DateTime.MinValue;
                            //lcl_objLst_EmployeeWorkGroupSchedule.Add(lcl_obj_EmployeeWorkGroupSchedule);
                            lcl_obj_WGReader.Close();
                            continue;
                        }
                        lcl_obj_WGReader.Read();
                        System.String lcl_str_DutyStartDateTime = IP_dt_Date.ToString("dd/M/yyyy");
                        lcl_str_DutyStartDateTime += " " + lcl_obj_WGReader["DUTY_START_FROM"].ToString();
                        System.UInt32 lcl_ui32_DutyHour = System.UInt32.Parse(lcl_obj_WGReader["DUTY_HOUR"].ToString());
                        lcl_obj_EmployeeWorkGroupSchedule.DutyScheduleFrom = System.DateTime.ParseExact(lcl_str_DutyStartDateTime, "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        System.DateTime lcl_obj_DutyScheduleFrom = System.DateTime.ParseExact(lcl_str_DutyStartDateTime, "dd/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        System.DateTime lcl_obj_DutyScheduleUpto = lcl_obj_DutyScheduleFrom.AddHours(lcl_ui32_DutyHour);

                        lcl_obj_EmployeeWorkGroupSchedule.WorkGroupOperationMasterCode = System.UInt64.Parse(lcl_obj_WGReader["WG_OPERATION_MASTER_CODE"].ToString());
                        lcl_obj_EmployeeWorkGroupSchedule.WorkGroupName = lcl_obj_WGReader["WORK_GROUP_NAME"].ToString();
                        lcl_obj_EmployeeWorkGroupSchedule.DutyScheduleFrom = lcl_obj_DutyScheduleFrom;
                        lcl_obj_EmployeeWorkGroupSchedule.DutyScheduleUpto = lcl_obj_DutyScheduleUpto;
                        //lcl_objLst_EmployeeWorkGroupSchedule.Add(lcl_obj_EmployeeWorkGroupSchedule);
                        lcl_obj_WGReader.Close();
                    }
                    lcl_obj_DBManager.InternalResource.Close();
                }

                return lcl_objLst_EmployeeWorkGroupSchedule;
            }, "BMLExceptionPolicy");
            return lcl_objLst_EmployeeWorkGroupScheduleRet;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup ManufWorkGroupEntityInDetail(System.UInt64 IP_ui64_WorkGroupCode, System.DateTime IP_dt_Date)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroup = null;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP WHERE WORK_GROUP_CODE = {0} AND STATUS = {1}", IP_ui64_WorkGroupCode, (System.Int16)SilkERP360.CCL.Enums.Status.Active);
            lcl_obj_WorkGroup = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    //get WorkGroup Object
                    SilkERP360.BML.HRIS.WorkGroupManager lcl_obj_WorkGroupManager = new SilkERP360.BML.HRIS.WorkGroupManager();
                    SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroupTmp = lcl_obj_WorkGroupManager.Get(IP_ui64_WorkGroupCode, lcl_obj_DBManager.InternalResource);
                    if (lcl_obj_WorkGroupTmp == null)
                    {
                        //Incorrect WorkGroupCode
                        return null;
                    }

                    SilkERP360.BML.HRIS.WorkGroupOperationMasterManager lcl_obj_WorkGroupOperationMasterManager = new SilkERP360.BML.HRIS.WorkGroupOperationMasterManager();
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_MASTER WHERE WORK_GROUP_CODE = {0} AND WORK_DATE = TO_DATE('{1}','DD/MM/YYYY')", IP_ui64_WorkGroupCode, IP_dt_Date.ToString("dd/MM/yyyy"));
                    SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationMaster lcl_obj_WorkGroupOperationMaster = lcl_obj_WorkGroupOperationMasterManager.Get(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    if (lcl_obj_WorkGroupOperationMaster == null)
                    {
                        //lcl_obj_WorkGroupOperationMaster == null -> WorkGroupOperationMaster has not yet been configured
                        return lcl_obj_WorkGroupTmp; 
                    }

                    lcl_obj_WorkGroupTmp.WorkGroupOperationMaster = lcl_obj_WorkGroupOperationMaster;
                    //Get WorkGroupOperationHistory lists containning employees assigned in the WorkGroup
                    SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new HRIS.WorkGroupOperationHistoryManager();
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0} AND IS_DELETED = 0", lcl_obj_WorkGroupTmp.WorkGroupOperationMaster.WorkGroupOperationMasterCode);
                    lcl_obj_WorkGroupTmp.WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = lcl_obj_WorkGroupOperationHistoryManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager.InternalResource);
                    SilkERP360.BML.HRIS.DataStructures.EmployeeProfileManager lcl_obj_EmployeeProfileManager = null;
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
                    return lcl_obj_WorkGroupTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_WorkGroup;
        }

        public System.Boolean SynchronizeEmployeeInclusion(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_IncludedWorkGroupOperationHistory)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    if (IP_objLst_IncludedWorkGroupOperationHistory != null)
                    {
                        //Update AssessmentStatus
                        System.String lcl_str_SqlQuery = System.String.Empty;
                        SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new HRIS.WorkGroupOperationHistoryManager();
                        lcl_obj_WorkGroupOperationHistoryManager.Initialize();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in IP_objLst_IncludedWorkGroupOperationHistory)
                        {
                            lcl_obj_WorkGroupOperationHistoryManager.Save(lcl_obj_WorkGroupOperationHistory, lcl_obj_DBManager.InternalResource);
                            //lcl_str_SqlQuery = System.String.Format("DELETE WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_HISTORY_CODE = {0}", lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode);
                            //lcl_str_SqlQuery = System.String.Format("UPDATE WORK_GROUP_OPERATION_HISTORY SET IS_DELETED = 1 WHERE WG_OPERATION_HISTORY_CODE = {0}", lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode);
                            //lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);
                            lcl_str_SqlQuery = System.String.Format("UPDATE WORK_GROUP_OPERATION_MASTER SET WORKER_STRENGTH = WORKER_STRENGTH + 1 WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_obj_WorkGroupOperationHistory.WorkGroupOperationMasterCode);
                            lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);
                        }
                    }

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return true;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.Boolean SynchronizeEmployeeRemoval(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_DeletableWorkGroupOperationHistory)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    if (IP_objLst_DeletableWorkGroupOperationHistory != null)
                    {
                        //Update AssessmentStatus
                        System.String lcl_str_SqlQuery = System.String.Empty;
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in IP_objLst_DeletableWorkGroupOperationHistory)
                        {
                            lcl_str_SqlQuery = System.String.Format("DELETE FROM WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_HISTORY_CODE = {0}", lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode);
                            //lcl_str_SqlQuery = System.String.Format("UPDATE WORK_GROUP_OPERATION_HISTORY SET IS_DELETED = 1 WHERE WG_OPERATION_HISTORY_CODE = {0}", lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode);
                            lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);
                            lcl_str_SqlQuery = System.String.Format("UPDATE WORK_GROUP_OPERATION_MASTER SET WORKER_STRENGTH = WORKER_STRENGTH - 1 WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_obj_WorkGroupOperationHistory.WorkGroupOperationMasterCode);
                            lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);
                        }
                    }

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return true;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.Boolean SynchronizeEmployeeAssessmentStatus(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_UpdatableWorkGroupOperationHistory)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                   
                    if (IP_objLst_UpdatableWorkGroupOperationHistory != null)
                    {

                        //Update AssessmentStatus
                        System.String lcl_str_SqlUpdate = System.String.Empty;
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in IP_objLst_UpdatableWorkGroupOperationHistory)
                        {
                            lcl_str_SqlUpdate = System.String.Format("UPDATE WORK_GROUP_OPERATION_HISTORY SET ASSESSMENT_STATUS = {0} WHERE WG_OPERATION_HISTORY_CODE = {1}", (System.Int16)lcl_obj_WorkGroupOperationHistory.AssessmentStatus,lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode);
                            lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlUpdate);
                        }
                    }
                   
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return true;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.Boolean SynchronizeWorkGroupOperationHistory(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_InsertableWorkGroupOperationHistory,
                                                                                  System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_EditableWorkGroupOperationHistory,
                                                                                  System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_DeletableWorkGroupOperationHistory)
        {
            throw new NotImplementedException();
            //System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            //{
            //    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
            //    {
            //        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
            //        {
            //            lcl_obj_DBManager.InternalResource.Open();
            //        }
            //        if (IP_objLst_InsertableWorkGroupOperationHistory != null)
            //        {
            //            SilkERP360.BML.HRIS.WorkGroupOperationHistoryManager lcl_obj_WorkGroupOperationHistoryManager = new BML.HRIS.WorkGroupOperationHistoryManager();
            //            foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in IP_objLst_InsertableWorkGroupOperationHistory)
            //            {
            //                lcl_obj_WorkGroupOperationHistoryManager.Save(lcl_obj_WorkGroupOperationHistory, lcl_obj_DBManager.InternalResource);
            //            }
            //        }
            //        if (IP_objLst_EditableWorkGroupOperationHistory != null)
            //        {
            //            //Update AssessmentStatus
            //            System.String lcl_str_SqlUpdate = System.String.Empty;
            //            foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in IP_objLst_EditableWorkGroupOperationHistory)
            //            {
            //                lcl_str_SqlUpdate = System.String.Format("UPDATE WORK_GROUP_OPERATION_HISTORY SET ASSESSMENT_STATUS = {0} WHERE WG_OPERATION_HISTORY_CODE = {1}", lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode, (System.Int16)lcl_obj_WorkGroupOperationHistory.AssessmentStatus);
            //                lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlUpdate);
            //            }
            //        }
            //        if (IP_objLst_DeletableWorkGroupOperationHistory != null)
            //        {
            //            //Update AssessmentStatus
            //            System.String lcl_str_SqlDelete = System.String.Empty;
            //            foreach (SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory lcl_obj_WorkGroupOperationHistory in IP_objLst_EditableWorkGroupOperationHistory)
            //            {
            //                lcl_str_SqlDelete = System.String.Format("DELETE WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_HISTORY_CODE = {0}", lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode);
            //                lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlDelete);
            //            }
            //        }

            //        lcl_obj_DBManager.InternalResource.CommitTransaction();
            //        lcl_obj_DBManager.InternalResource.Close();
            //    }
            //    return true;
            //}, "FLExceptionPolicy");
            //return lcl_b_Response;
        }
    }
}
