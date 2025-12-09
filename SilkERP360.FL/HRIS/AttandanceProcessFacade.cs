using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class AttandanceProcessFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {

        public AttandanceProcessFacade()
        {
            this.Initialize();
        }


//        public System.UInt64 SaveAttandanceProcess(SilkERP360.CCL.BusinessEntities.HRIS.Base.AttandanceCore IP_Obj_Attendance)
//        {

            


//                 System.UInt64 lcl_ui64_EmployeeCode = 0, lcl_i32_j = 0;
//                 System.String lcl_str_SqlQuery = System.String.Empty, SearchShift = "Where 1=1 ";
//                 if (IP_Obj_Attendance.ShiftCode != 0)
//                 {
//                     SearchShift = "Where RShift=" + IP_Obj_Attendance.ShiftCode + "";
//                 }

//                 SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();

//                 lcl_str_SqlQuery = System.String.Format(@"Select EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,PunchDate,StTime,EnTime,INWtin,OutWtin,LateTime,RegHour,ProcssDay,Intime,Outtime,IsHoliday,Weekend,
//                Late, Whour ,case when OT=1 And IsHoliday=0 And Weekend is  null and  Whour>RegHour
//                then Whour-RegHour when OT=1 And (IsHoliday=1 OR ProcssDay=Weekend) then Whour  else 0 end OTHour,
//                case 
//                when IsHoliday=0 and  Weekend is  null and Intime is null then 2
//                when IsHoliday=1 then 5
//                when IsHoliday=0 and  Weekend is not null  then 7
//                when IsHoliday=0 and  Weekend is  null and Late>0 then 3
//                when IsHoliday=0 and  Weekend is  null and  Intime  is not null And Late=0 then 1
//                else null end AttSts From
//                (Select EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,to_date('{1}','dd-mon-yyyy')PunchDate,StTime,EnTime,INWtin,OutWtin,LateTime,RegHour,ProcssDay,Intime,
//                Case when Outtime=Intime then null else Outtime end  Outtime,IsHoliday,Weekend,case when Intime>LateTime 
//                then Round(((Intime-StTime)*24*60*60),0) else 0 end Late,
//                case when  Outtime is not null then floor(((Outtime-DutyStart)*24*60*60)/60/60)+Case when Outtime is not null And mod(((Outtime-DutyStart)*24*60*60)/60,60)>50 then 1  else 0 end else 0 end Whour 
//                From (Select A.EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift, case when (Select SHIFT_NAME From SHIFT where  SHIFT_CODE=RShift)='Executive' AND ProcssDay='Sat' then (StTime + 1/24) else StTime end StTime,EnTime,INWtin,OutWtin,case when (Select SHIFT_NAME From SHIFT where  SHIFT_CODE=RShift)='Executive' AND ProcssDay='Sat' then (StTime + 1/24) else LateTime end LateTime,RegHour,ProcssDay,Intime,Case when Outtime=Intime then null else Outtime end  Outtime,nvl(IsHoliday,0)IsHoliday,Weekend,case When Intime>StTime then Intime else StTime end DutyStart From
//                (Select EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,StTime,EnTime,INWtin,OutWtin,LateTime,RegHour,ProcssDay,min(TRAN_DATE_TIME)Intime,max(TRAN_DATE_TIME)Outtime From
//                (
//                Select L.EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,StTime,EnTime,INWtin,OutWtin,LateTime,RegHour,TRAN_DATE_TIME,ProcssDay From
//                (
//                Select EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,StTime,EnTime,(StTime - 3/24) INWtin,(StTime - 3/24+1) OutWtin,
//                LateTime,RegHour,to_char(to_date('{1}','dd-mon-yyyy'), 'Dy')ProcssDay From
//                (Select EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,
//                To_Date( To_char('{1}')||' '||StTime, 'dd-mon-yyyy hh24:mi:ss') StTime,
//                To_Date(To_char(case when DD>0 then To_Date('{1}')+DD  else To_Date('{1}') end ,'dd-mon-yyyy') ||' '||EnTime,'dd-mon-yyyy hh24:mi:ss') EnTime,
//                To_Date(To_char('{1}') ||' '||LateTime,'dd-mon-yyyy hh24:mi:ss') LateTime,RegHour From
//                ( Select A.EMPLOYEE_CODE,EMPLOYEE_ID,
//                OT, case when    ( Select SHIFT_CODE From ROOSTER_MASTER RM 
//                inner join EMPLOYEE_ROOSTER RD
//                ON RM.ROOSTER_MASTER_CODE=RD.ROOSTER_MASTER_CODE
//                Where DUTY_DATE=to_date('{1}','dd-mon-yyyy') And RD.EMPLOYEE_CODE=A.EMPLOYEE_CODE And RD.IS_DELETED=1) is null then SHIFT_CODE else ( Select SHIFT_CODE From ROOSTER_MASTER RM 
//                inner join EMPLOYEE_ROOSTER RD
//                ON RM.ROOSTER_MASTER_CODE=RD.ROOSTER_MASTER_CODE
//                Where DUTY_DATE=to_date('{1}','dd-mon-yyyy') And RD.EMPLOYEE_CODE=A.EMPLOYEE_CODE And RD.IS_DELETED=1) End RShift From
//                (Select EMPLOYEE_CODE,EMPLOYEE_ID,case when IS_OT_ELIGIBLE is null then 0 else IS_OT_ELIGIBLE end OT ,
//                case when SHIFT_CODE is null then (Select SHIFT_CODE From SHIFT where  COMPANY_CODE={0} And SHIFT_NAME='Executive') 
//                else SHIFT_CODE end SHIFT_CODE
//                from EMPLOYEE
//                Where COMPANY_CODE={0} AND IS_DELETED=1 And EMPLOYEE_STATUS in(0,1,2)
//                And to_date(JOINING_DATE)<=to_date('{1}','dd-mon-yyyy'))A)X
//                Left Outer join
//                (
//
//                Select SHIFT_CODE,to_char(START_TIME, 'hh24:mi:ss')StTime,to_char(END_TIME, 'hh24:mi:ss') EnTime,
//                to_char(TOLERANCE_TIME, 'hh24:mi:ss') LateTime,REGULAR_DUTY_HOUR RegHour,
//                to_date(END_TIME)-to_date(START_TIME)DD
//                From SHIFT
//                 where  COMPANY_CODE={0} And IS_DELETED=1
//
//                 )Y on  X.RShift=Y.SHIFT_CODE)S)L
//                Left outer join
//                -----------All Transaction------------------------------
//
//                (
//                Select  P.EMPLOYEE_CODE,TRAN_DATE_TIME From 
//                (Select  EMPLOYEE_CODE,TRAN_DATE_TIME From 
//                (Select  E.EMPLOYEE_CODE,TRAN_DATE_TIME From BMS_ROWS B inner join EMPLOYEE E
//                on B.EMPLOYEE_CODE=E.EMPLOYEE_ID
//                Where COMPANY_CODE={0} And (to_Date(TRAN_DATE_TIME) between to_date('{1}','dd-mon-yyyy') and to_date('{1}','dd-mon-yyyy')+1)
//                Union ALL
//                Select EMPLOYEE_CODE,TRANS_DATETIME TRAN_DATE_TIME From ACS_FILE_ROWS AD Inner join  EMPLOYEE E
//                ON AD.CARD_NO=E.EMPLOYEE_ACS_CODE
//                Where COMPANY_CODE={0} And
//                (to_Date(TRANS_DATETIME) between to_date('{1}','dd-mon-yyyy') and to_date('{1}','dd-mon-yyyy')+1))X)P
//                Left outer join
//                (
//                Select EMPLOYEE_CODE,StTime- 3/24 INWtin,StTime- 3/24+1 OutWtin
//                From
//                (
//                Select EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,
//                To_Date(To_Char('{1}')||' '||StTime,'dd-mon-yyyy hh24:mi:ss') StTime,
//                To_Date(To_Date('{1}')+DD ||' '||EnTime,'dd-mon-yyyy hh24:mi:ss') EnTime From
//                (
//
//                Select A.EMPLOYEE_CODE,EMPLOYEE_ID,
//                OT, case when RSHIFT_CODE is null then SHIFT_CODE else RSHIFT_CODE End RShift From
//                (Select EMPLOYEE_CODE,EMPLOYEE_ID,case when IS_OT_ELIGIBLE is null then 0 else IS_OT_ELIGIBLE end OT ,
//                case when SHIFT_CODE is null then (Select SHIFT_CODE From SHIFT where  COMPANY_CODE={0} And SHIFT_NAME='Executive') 
//                else SHIFT_CODE end SHIFT_CODE
//                from EMPLOYEE
//                Where COMPANY_CODE={0} AND IS_DELETED=1 And EMPLOYEE_STATUS in(0,1,2)
//                And to_date(JOINING_DATE)<=to_date('{1}','dd-mon-yyyy'))A
//                Left Outer  Join
//                (Select EMPLOYEE_CODE REMPLOYEE_CODE ,SHIFT_CODE RSHIFT_CODE From ROOSTER_MASTER RM 
//                inner join EMPLOYEE_ROOSTER RD
//                ON RM.ROOSTER_MASTER_CODE=RD.ROOSTER_MASTER_CODE
//                Where '{1}' between to_date(ROOSTER_DATE_FROM) And to_date(ROOSTER_DATE_TO))B on A.EMPLOYEE_CODE=B.REMPLOYEE_CODE
//                )X
//                Left Outer join
//                (
//                Select SHIFT_CODE,to_char(START_TIME, 'hh24:mi:ss')StTime,to_char(END_TIME, 'hh24:mi:ss') EnTime,
//                to_char(TOLERANCE_TIME, 'hh24:mi:ss') LateTime,REGULAR_DUTY_HOUR RegHour,
//                to_date(END_TIME)-to_date(START_TIME)DD
//                From SHIFT
//                 where  COMPANY_CODE={0} And IS_DELETED=1 )Y 
//                 on  X.RShift=Y.SHIFT_CODE
// 
//                 )S 
//                 )Q 
//                ON P.EMPLOYEE_CODE=Q.EMPLOYEE_CODE
//                where TRAN_DATE_TIME between  INWtin and OutWtin
//                )H ON L.EMPLOYEE_CODE=H.EMPLOYEE_CODE
//
//                )F
//                Group by EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,StTime,EnTime,INWtin,OutWtin,LateTime,RegHour,ProcssDay
//                )A 
//                Left Outer join
//                -----Holiday----------
//                (Select HOLIDAY_DATE,1 IsHoliday From HOLIDAY_DETAILS HD left outer join
//                HOLIDAY_MASTER HM On HD.HOLIDAY_MASTER_CODE=hm.holiday_master_code
//                where hm.is_deleted=1 And To_Date(HOLIDAY_DATE)=to_date('{1}','dd-mon-yyyy') And hm.company_code={0})B On To_DAte(A.StTime)=To_date(B.HOLIDAY_DATE)
//                Left outer join 
//                ---------------Weekend----------------
//                (Select EMPLOYEE_CODE,Weekend From
//                (Select EMPLOYEE_CODE,case 
//                when DAY=1 then 'Sat'
//                when DAY=2 then 'Sun'
//                when DAY=3 then 'Mon'
//                when DAY=4 then 'Tus'
//                when DAY=5 then 'Wed'
//                when DAY=6 then 'Thu'
//                when DAY=7 then 'Fri' end Weekend
//                From EMPLOYEE_WEEKEND
//                Where IS_DELETED=1)A where Weekend=to_char(to_date('{1}','dd-mon-yyyy'), 'Dy'))C On A.EMPLOYEE_CODE=C.EMPLOYEE_CODE)F)A  " + SearchShift + "", IP_Obj_Attendance.CompanyCode, IP_Obj_Attendance.ProcessDate.ToString("dd-MMM-yyyy"), IP_Obj_Attendance.ShiftCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
//                 Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RawDataReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
//                 if (!(lcl_obj_RawDataReader.HasRows))
//                 {
//                     throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Raw Data Not Found!!!");
//                 }
//                 SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster lcl_obj_AttendanceMaster = new SilkERP360.CCL.BusinessEntities.HRIS.AttendanceMaster();
//                 while (lcl_obj_RawDataReader.Read())
//                 {
//                     string Intime, Outtime;
//                      //EMPLOYEE_CODE,EMPLOYEE_ID,OT,RShift,StTime,EnTime,INWtin,OutWtin,LateTime,RegHour,ProcssDay,Intime, Outtime,IsHoliday,Weekend,Late
//                     SilkERP360.CCL.BusinessEntities.HRIS.AttendanceDetails lcl_obj_AttendanceDetails = new SilkERP360.CCL.BusinessEntities.HRIS.AttendanceDetails();
//                      Intime = lcl_obj_RawDataReader["Intime"].ToString();
//                      Outtime = lcl_obj_RawDataReader["Outtime"].ToString();
//                     lcl_obj_AttendanceDetails.EmployeeCode = System.UInt64.Parse(lcl_obj_RawDataReader["EMPLOYEE_CODE"].ToString());
//                     lcl_obj_AttendanceDetails.PunchDate = System.DateTime.Parse(lcl_obj_RawDataReader["PunchDate"].ToString());
//                     lcl_obj_AttendanceDetails.ShiftCode = System.UInt64.Parse(lcl_obj_RawDataReader["RShift"].ToString());
//                     if (Intime != "")
//                     {
//                         lcl_obj_AttendanceDetails.InDataTime = System.DateTime.Parse(lcl_obj_RawDataReader["Intime"].ToString());
//                     }
//                     if (Outtime != "")
//                     {
//                         lcl_obj_AttendanceDetails.OutDateTime = System.DateTime.Parse(lcl_obj_RawDataReader["Outtime"].ToString());
//                     }
//                     lcl_obj_AttendanceDetails.OT = System.Int16.Parse(lcl_obj_RawDataReader["OTHour"].ToString());
//                     lcl_obj_AttendanceDetails.Late = System.Int64.Parse(lcl_obj_RawDataReader["Late"].ToString());
//                     lcl_obj_AttendanceDetails.AttanSatus = System.Int16.Parse(lcl_obj_RawDataReader["AttSts"].ToString());


//                     lcl_obj_AttendanceMaster.Attendances.Add(lcl_obj_AttendanceDetails);

//                 }
//                 lcl_obj_AttendanceMaster.ShiftCode = IP_Obj_Attendance.ShiftCode;
//                 lcl_obj_AttendanceMaster.AttendDate =  IP_Obj_Attendance.ProcessDate;
                
                

//                 SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
//                 System.UInt64 lcl_ui64_EmployeeCodeTmp = lcl_obj_AttendanceManager.Save(lcl_obj_AttendanceMaster);

//                 lcl_obj_SqlFacade.CloseReader();

                
//            return lcl_ui64_EmployeeCode;
//        }

//        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceDetails> GetInOutDepartmentwise(System.UInt64 IP_ui64_DepartmentCode)
//        {
//            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceDetails> lcl_obj_EmployeeInOutList = null;
//            lcl_obj_EmployeeInOutList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceDetails>>(() =>
//            {
//                System.String lcl_str_SqlQuery = System.String.Format(@"Select A.EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_NAME,DEGN_NAME,ATTENDANCE_DATE,SHIFT_CODE,IN_DATE_TIME,OUT_DATE_TIME,OT,
//
// LATE_TIME
//
//,case when ATTN_STATUS=1 then 'P' when ATTN_STATUS=2 then 'A' when ATTN_STATUS=3 then 'L'  when ATTN_STATUS=7 then 'W' else '' end ATTN_STATUS
//  From
//(Select EMPLOYEE_CODE,ATTENDANCE_DATE,SHIFT_CODE,to_char(IN_DATE_TIME,'hh24:mi:ss')IN_DATE_TIME,to_char(OUT_DATE_TIME,'hh24:mi:ss')OUT_DATE_TIME,OT,
//to_char(Floor((LATE_TIME/3600)),'FM00') ||':'||to_char(mod(floor(LATE_TIME/60),60),'FM00')||':'||to_char(mod(LATE_TIME,60),'FM00')LATE_TIME,ATTN_STATUS From
//(Select ATTENDANCE_MASTER_CODE,ATTENDANCE_DATE,SHIFT_CODE
//From ATTENDANCE_MASTER Where IS_DELETED=1
//And ATTENDANCE_DATE between '27-oct-2013' And '27-oct-2013')A
//Left outer join
//(Select  EMPLOYEE_CODE,IN_DATE_TIME,OUT_DATE_TIME,OT,LATE_TIME,ATTN_STATUS,ATTENDANCE_MASTER_CODE
//From EMPLOYEE_ATTENDANCE
//Where IS_DELETED=1)B On A.ATTENDANCE_MASTER_CODE=B.ATTENDANCE_MASTER_CODE)A
//
//Left outer Join 
//(select EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_NAME,JOINING_DATE,NAME,DEPT_NAME,DEGN_NAME, E.COMPANY_CODE, E.DEPARTMENT_CODE,E.DESIGNATION_CODE From  EMPLOYEE E inner JOIn
//COMPANY C ON E.COMPANY_CODE=C.COMPANY_CODE INNER JOIN DEPARTMENT Dp
//ON E.DEPARTMENT_CODE=Dp.DEPARTMENT_CODE Inner Join DESIGNATION D
//On E.DESIGNATION_CODE=D.DESIGNATION_CODE)B On A.EMPLOYEE_CODE=B.EMPLOYEE_CODE
//Where COMPANY_CODE=110000000001 And DEPARTMENT_CODE=111000000004", IP_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated);
//                SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
//                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AttendanceDetails> lcl_obj_EmployeeInOutListTmp =
//                    lcl_obj_AttendanceManager.GetList(lcl_str_SqlQuery);
//                return lcl_obj_EmployeeInOutListTmp;
//            }, "FLExceptionPolicy");
//            return lcl_obj_EmployeeInOutList;
//        }

//        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.ExtendedAttendanceData> GetInOutDepartmentwise(System.UInt64 IP_ui64_CompanyCode, System.UInt64 IP_ui64_DepartmentCode, System.String IP_str_PunchDate)
//        {
//            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.ExtendedAttendanceData> lcl_obj_ExtendedAttendanceData = null;
//            lcl_obj_ExtendedAttendanceData = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.ExtendedAttendanceData>>(() =>
//            {
//                System.String lcl_str_SqlQuery = System.String.Format(@"Select A.EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_NAME,DEGN_NAME,to_char(ATTENDANCE_DATE,'dd-mon-yyyy')ATTENDANCE_DATE,SHIFT_CODE,IN_DATE_TIME,OUT_DATE_TIME,OT,
//                LATE_TIME ,case when ATTN_STATUS=1 then 'P' when ATTN_STATUS=2 then 'A' when ATTN_STATUS=3 then 'L'  when ATTN_STATUS=7 then 'W' else '' end ATTN_STATUS
//                From
//(Select EMPLOYEE_CODE,ATTENDANCE_DATE,SHIFT_CODE,to_char(IN_DATE_TIME,'hh24:mi:ss')IN_DATE_TIME,to_char(OUT_DATE_TIME,'hh24:mi:ss')OUT_DATE_TIME,OT,
//to_char(Floor((LATE_TIME/3600)),'FM00') ||':'||to_char(mod(floor(LATE_TIME/60),60),'FM00')||':'||to_char(mod(LATE_TIME,60),'FM00')LATE_TIME,ATTN_STATUS From
//(Select ATTENDANCE_MASTER_CODE,ATTENDANCE_DATE,SHIFT_CODE
//From ATTENDANCE_MASTER Where IS_DELETED=1
//And ATTENDANCE_DATE between to_date('{2}','dd-mon-yyyy') And to_date('{2}','dd-mon-yyyy'))A
//Left outer join
//(Select  EMPLOYEE_CODE,IN_DATE_TIME,OUT_DATE_TIME,OT,LATE_TIME,ATTN_STATUS,ATTENDANCE_MASTER_CODE
//From EMPLOYEE_ATTENDANCE
//Where IS_DELETED=1)B On A.ATTENDANCE_MASTER_CODE=B.ATTENDANCE_MASTER_CODE)A
//
//Left outer Join 
//(select EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_NAME,JOINING_DATE,NAME,DEPT_NAME,DEGN_NAME, E.COMPANY_CODE, E.DEPARTMENT_CODE,E.DESIGNATION_CODE From  EMPLOYEE E inner JOIn
//COMPANY C ON E.COMPANY_CODE=C.COMPANY_CODE INNER JOIN DEPARTMENT Dp
//ON E.DEPARTMENT_CODE=Dp.DEPARTMENT_CODE Inner Join DESIGNATION D
//On E.DESIGNATION_CODE=D.DESIGNATION_CODE)B On A.EMPLOYEE_CODE=B.EMPLOYEE_CODE
//Where COMPANY_CODE={0} And DEPARTMENT_CODE={1}", IP_ui64_CompanyCode, IP_ui64_DepartmentCode, IP_str_PunchDate, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Resigned, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Suspended, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Terminated);
//                SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
//                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.ExtendedAttendanceData> lcl_obj_EmployeeInOutListTmp =
//                    lcl_obj_AttendanceManager.GetInOutListByDepartment(lcl_str_SqlQuery);
//                return lcl_obj_EmployeeInOutListTmp;
//            }, "FLExceptionPolicy");
//            return lcl_obj_ExtendedAttendanceData;
//        }





    }
}