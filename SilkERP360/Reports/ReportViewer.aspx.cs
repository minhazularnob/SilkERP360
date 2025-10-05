using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SilkERP360.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            System.UInt64 empCode;
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            System.UInt64 deptCode;
            System.DateTime ddate;
            System.UInt64 CompCode;
           
            
            switch (Session["ReportID"].ToString())
            {
                case "ECL":
                    empCode =System.UInt64.Parse(Session["EmployeeCode"].ToString());
                    report.Load(Server.MapPath("HRIS/AttendanceReport.rpt"));
                    report.SetDataSource(getConfirmation(empCode).Data);
                    SilkERP360.Globals.classes.ReportSubmitted.Rpt = report;
                    break;
                case "ADR":

                    deptCode = System.UInt64.Parse(Session["DeptCode"].ToString());
                    ddate = System.DateTime.Parse(Session["dDate"].ToString());
                    CompCode = System.UInt64.Parse(Session["CompCode"].ToString());


                  //  HRIS.rptAttan vv = new HRIS.rptAttan();
                    report.Load(Server.MapPath("HRIS/rptAttan.rpt"));
                   report.SetDataSource(DailyAttendance(deptCode, ddate, CompCode).Data);
                    //vv.Load(Server.MapPath("HRIS/rptAttan.rpt"));
                   // vv.SetDataSource(DailyAttendancedt(deptCode, ddate, CompCode));
                    //report.SetDataSource(DailyAttendancedt(deptCode, ddate, CompCode));
                   SilkERP360.Globals.classes.ReportSubmitted.Rpt = report;
                    //crv(vv);
                    //rv.sh
                    break;
                default:
                    report.Load(Server.MapPath("TransferLetterRO.rpt"));
                    //report.SetDataSource(getTransfer(System.UInt64.Parse(ddlEmp.SelectedValue)).Data);
                    break;
            }
        
            crv.ReportSource = SilkERP360.Globals.classes.ReportSubmitted.Rpt;
                      
            crv.HasPrintButton = true;
       

        }

       

       
        private SilkERP360.Globals.classes.WSReturn DailyAttendance(System.UInt64 deptCode, System.DateTime ddate, System.UInt64 CompCode)
        {

            try
            {

                 DataTable dt = new DataTable();
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format(@"Select A.EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_NAME,DEGN_NAME,to_char(ATTENDANCE_DATE,'dd-mon-yyyy')ATTENDANCE_DATE,SHIFT_CODE,IN_DATE_TIME,OUT_DATE_TIME,OT,
                LATE_TIME ,case when ATTN_STATUS=1 then 'P' when ATTN_STATUS=2 then 'A' when ATTN_STATUS=3 then 'L'  when ATTN_STATUS=7 then 'W' else '' end ATTN_STATUS
                From (Select EMPLOYEE_CODE,ATTENDANCE_DATE,SHIFT_CODE,to_char(IN_DATE_TIME,'hh24:mi:ss')IN_DATE_TIME,to_char(OUT_DATE_TIME,'hh24:mi:ss')OUT_DATE_TIME,OT,
                to_char(Floor((LATE_TIME/3600)),'FM00') ||':'||to_char(mod(floor(LATE_TIME/60),60),'FM00')||':'||to_char(mod(LATE_TIME,60),'FM00')LATE_TIME,ATTN_STATUS From
                (Select ATTENDANCE_MASTER_CODE,ATTENDANCE_DATE,SHIFT_CODE From ATTENDANCE_MASTER Where IS_DELETED=1
                And ATTENDANCE_DATE between to_date('{2}','dd-mon-yyyy') And to_date('{2}','dd-mon-yyyy'))A
                Left outer join
                (Select  EMPLOYEE_CODE,IN_DATE_TIME,OUT_DATE_TIME,OT,LATE_TIME,ATTN_STATUS,ATTENDANCE_MASTER_CODE
                From EMPLOYEE_ATTENDANCE
                Where IS_DELETED=1)B On A.ATTENDANCE_MASTER_CODE=B.ATTENDANCE_MASTER_CODE)A
                Left outer Join 
                (select EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_NAME,JOINING_DATE,NAME,DEPT_NAME,DEGN_NAME, E.COMPANY_CODE, E.DEPARTMENT_CODE,E.DESIGNATION_CODE From  EMPLOYEE E inner JOIn
                COMPANY C ON E.COMPANY_CODE=C.COMPANY_CODE INNER JOIN DEPARTMENT Dp
                ON E.DEPARTMENT_CODE=Dp.DEPARTMENT_CODE Inner Join DESIGNATION D
                On E.DESIGNATION_CODE=D.DESIGNATION_CODE)B On A.EMPLOYEE_CODE=B.EMPLOYEE_CODE
                Where COMPANY_CODE={0} And DEPARTMENT_CODE={1}", CompCode, deptCode, ddate.ToString("dd-MMM-yyyy"));
                
                List<SilkERP360.Reports.Classes.DailyAttendenceReport> lstDt = new List<SilkERP360.Reports.Classes.DailyAttendenceReport>();
                System.Data.OracleClient.OracleDataReader DailyReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
               
                if (DailyReader.HasRows)
                {
                    while (DailyReader.Read())
                    {
                        SilkERP360.Reports.Classes.DailyAttendenceReport lcl_obj_Attendaily = new SilkERP360.Reports.Classes.DailyAttendenceReport();
                        lcl_obj_Attendaily.EmployeeCode = UInt64.Parse((DailyReader["EMPLOYEE_CODE"].ToString()));
                        lcl_obj_Attendaily.EmployeeID = DailyReader["EMPLOYEE_ID"].ToString();
                        lcl_obj_Attendaily.Designation = DailyReader["DEGN_NAME"].ToString();
                        lcl_obj_Attendaily.EmployeeName = DailyReader["EMPLOYEE_NAME"].ToString();
                        lcl_obj_Attendaily.InTime = (DailyReader["IN_DATE_TIME"].ToString());
                        lcl_obj_Attendaily.OutTime = (DailyReader["OUT_DATE_TIME"].ToString());
                        lcl_obj_Attendaily.OT = UInt16.Parse(DailyReader["OT"].ToString());
                        lcl_obj_Attendaily.PunchDate = (DailyReader["ATTENDANCE_DATE"].ToString());
                        lcl_obj_Attendaily.Status = (DailyReader["ATTN_STATUS"].ToString());
                        lcl_obj_Attendaily.LateTime = (DailyReader["LATE_TIME"].ToString());
                        lstDt.Add(lcl_obj_Attendaily);
                        
                    }
                }
                DailyReader.Close();
                DailyReader.Dispose();
                lcl_obj_SqlFacade.CloseReader();
                return new SilkERP360.Globals.classes.WSReturn(0, "Operation Successful", lstDt);
            }

            catch (System.Exception Ex)
            {
                return new SilkERP360.Globals.classes.WSReturn(1, Ex.Message);
            }

        }


        private SilkERP360.Globals.classes.WSReturn getConfirmation(System.UInt64 employeeCode)
        {

            try
            {
                

                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format(@"Select EMPLOYEE_CODE,EMPLOYEE_ID from employee");


                List<SilkERP360.Reports.Classes.AttendanceReport> lst = new List<SilkERP360.Reports.Classes.AttendanceReport>();
               
                System.Data.OracleClient.OracleDataReader reader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
             
                SilkERP360.Reports.Classes.AttendanceReport lcl_obj_Atten = new    SilkERP360.Reports.Classes.AttendanceReport();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        lcl_obj_Atten.EmployeeCode = UInt64.Parse((reader["EMPLOYEE_CODE"].ToString()));
                        lcl_obj_Atten.EmployeeID = reader["EMPLOYEE_ID"].ToString();
                        lst.Add(lcl_obj_Atten);
                    }
                }
                reader.Close();

                reader.Dispose();

                lcl_obj_SqlFacade.CloseReader();


                return new SilkERP360.Globals.classes.WSReturn(0, "Operation Successful", lst);
            }
            
            catch (System.Exception Ex)
            {
                return new SilkERP360.Globals.classes.WSReturn(1, Ex.Message);
            }

        }

        

    }
}