using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class NewLeaveApproved1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                System.String lcl_str_LeaveCode = this.Session["emp_c"].ToString();
                /// here Emp_c user as LeaveCode
                System.UInt64 lcl_ui64_LeaveCode = System.UInt64.Parse(lcl_str_LeaveCode);
                this.Session.Remove("emp_c");
                System.Int32 lcl_i32_j = 1;
                System.UInt64 lcl_ui64_DepartmentCode = 0;
                txtLeaveCode.Value = lcl_str_LeaveCode;

                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();

                // get employee code from employee Leave Application table by Leave Application Code
                System.String lcl_str_SqlQuery = System.String.Empty;

                lcl_str_SqlQuery = System.String.Format(@"select Employee_Code from employee_leave_application where leave_app_code={0}", lcl_ui64_LeaveCode);

                 System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeCodeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);

                if (!(lcl_obj_EmployeeCodeReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("EmployeeCode Not Found!!!");
                }
                              
                lcl_obj_EmployeeCodeReader.Read();
                System.String lcl_str_EmployeeCode = lcl_obj_EmployeeCodeReader["Employee_Code"].ToString();
                System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_str_EmployeeCode);
                lcl_obj_SqlFacade.CloseReader();

                //Load Employee Information
               
                lcl_str_SqlQuery = System.String.Format(@"Select EMPLOYEE_ID,EMPLOYEE_NAME,JOINING_DATE,Company,degn_name,DEPT_NAME, department_code,LVType,LVCATEGORY,LEAVE_ST_DATE,LEAVE_END_DATE,NO_OF_DAYS,REJOIN_DATE ,LEAVE_REASON,
                (Select EMPLOYEE_NAME||'('||EMPLOYEE_ID||')' from employee
                Where EMPLOYEE_CODE=REPL_EMPLOYEE_CODE)REPL_EMPLOYEE_CODE,
                (Select EMPLOYEE_NAME||'('||EMPLOYEE_ID||')' from employee
                Where EMPLOYEE_CODE=RECOMMEND_BY)RECOMMEND_BY
                From
                (Select employee_code,EMPLOYEE_ID,EMPLOYEE_NAME,To_char(JOINING_DATE,'DD-Mon-yyyy')JOINING_DATE,c.name As Company,ds.degn_name,DEPT_NAME, e.department_code 
                                from employee E inner join COMPANY C On e.company_code=c.company_code
                                inner join DESIGNATION DS on E.DESIGNATION_CODE=ds.designation_code
                                Inner join DEPARTMENT Dp on  e.department_code=dp.DEPARTMENT_CODE
                                where employee_code={0})X

                inner join
                (Select EMPLOYEE_CODE,(Select SHORT_NAME From LEAVE Where LEAVE_CODE=LVCode)LVType,LVCATEGORY
                ,To_char(LEAVE_ST_DATE,'DD-Mon-yyyy')LEAVE_ST_DATE,To_char(LEAVE_END_DATE,'DD-Mon-yyyy')LEAVE_END_DATE,NO_OF_DAYS,To_char(REJOIN_DATE,'DD-Mon-yyyy')REJOIN_DATE ,
                LEAVE_REASON,REPL_EMPLOYEE_CODE,RECOMMEND_BY
                From
                (Select EMPLOYEE_CODE,LEAVE_CODE LVCode,LEAVE_CATEGORY,
                 Case when LEAVE_CATEGORY=1 then 'Paid' else 'Upaid' End LVCATEGORY
                ,LEAVE_ST_DATE,LEAVE_END_DATE,NO_OF_DAYS,REJOIN_DATE ,LEAVE_REASON,REPL_EMPLOYEE_CODE,RECOMMEND_BY
                From employee_leave_application
                where leave_app_code={1})A)Y On X.employee_code=Y.employee_code", lcl_ui64_EmployeeCode,lcl_ui64_LeaveCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeInfoReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeInfoReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee information Was Not Found!!!");
                }
                //Select EMPLOYEE_ID,EMPLOYEE_NAME,JOINING_DATE,Company,degn_name,DEPT_NAME, department_code,LVType,LEAVE_CATEGORY,
                //LEAVE_ST_DATE,LEAVE_END_DATE,NO_OF_DAYS,REJOIN_DATE ,LEAVE_REASON,RECOMMEND_BY
                lcl_obj_EmployeeInfoReader.Read();
                txt_Lve_EmpID.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_ID"].ToString();
                txt_Lve_EmpName.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_NAME"].ToString();
                txt_Lve_Department.Text = lcl_obj_EmployeeInfoReader["DEPT_NAME"].ToString();
                txt_Lve_Designation.Text = lcl_obj_EmployeeInfoReader["degn_name"].ToString();
                txt_Lve_Company.Text = lcl_obj_EmployeeInfoReader["Company"].ToString();
                txt_Lve_JoinDate.Text = lcl_obj_EmployeeInfoReader["JOINING_DATE"].ToString();
                lcl_ui64_DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeInfoReader["department_code"].ToString());
                txt_LeaveType.Text = lcl_obj_EmployeeInfoReader["LVType"].ToString();
                txt_lve_Category.Text = lcl_obj_EmployeeInfoReader["LVCATEGORY"].ToString();
                txt_Leave_from_date.Text = lcl_obj_EmployeeInfoReader["LEAVE_ST_DATE"].ToString();
                txt_Leave_to_date.Text = lcl_obj_EmployeeInfoReader["LEAVE_END_DATE"].ToString();
                txt_lve_total_days.Text = lcl_obj_EmployeeInfoReader["NO_OF_DAYS"].ToString();
                txt_join_date.Text = lcl_obj_EmployeeInfoReader["REJOIN_DATE"].ToString();
                txt_leave_reason.Text = lcl_obj_EmployeeInfoReader["LEAVE_REASON"].ToString();
                txt_lve_ReplcID.Text = lcl_obj_EmployeeInfoReader["REPL_EMPLOYEE_CODE"].ToString();
                txt_Lve_RecBy.Text = lcl_obj_EmployeeInfoReader["RECOMMEND_BY"].ToString();




                System.Text.StringBuilder lcl_obj_HTMLBuilder = new System.Text.StringBuilder();
                lcl_obj_HTMLBuilder.Append("var gbl_ui64_EmployeeCode = ");
                lcl_obj_HTMLBuilder.Append(lcl_str_EmployeeCode);
                lcl_obj_HTMLBuilder.Append(" ;");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "EMP_CODE", lcl_obj_HTMLBuilder.ToString(), true);
                lcl_obj_HTMLBuilder.Clear();
                lcl_obj_SqlFacade.CloseReader();


                //////Load Leave History employee wise

                lcl_str_SqlQuery = System.String.Format(@"Select (Select SHORT_NAME From LEAVE Where LEAVE_CODE=LVCode)LeaveType,To_Char(leave_st_date,'dd-Mon-yyyy')leave_st_date,to_Char(leave_end_date,'dd-Mon-yyyy')leave_end_date,no_of_days From
                                                        (Select LEAVE_CODE LVCode,leave_st_date,leave_end_date,no_of_days From EMPLOYEE_LEAVE_APPLICATION 
                                                        Where EMPLOYEE_CODE={0} And IS_APPROVED=1 And IS_CANCEL='N')A order by leave_st_date", lcl_str_EmployeeCode);
                
                System.Data.OracleClient.OracleDataReader lcl_obj_LeaveEmployeehistoryReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_LeaveEmployeehistoryReader.HasRows))
                {
                   // throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Leave history Was Not Found!!!");
             
                lcl_i32_j = 1;
                while (lcl_obj_LeaveEmployeehistoryReader.Read())
                {
                    System.Web.UI.HtmlControls.HtmlTableRow lcl_obj_LD_Row = new System.Web.UI.HtmlControls.HtmlTableRow();
                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveTypeCell = new System.Web.UI.HtmlControls.HtmlTableCell();

                    lcl_obj_LD_LeaveTypeCell.InnerText = lcl_obj_LeaveEmployeehistoryReader["LeaveType"].ToString();
                    lcl_obj_LD_LeaveTypeCell.Align = "center";


                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_leave_st_date = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_leave_st_date.InnerText = lcl_obj_LeaveEmployeehistoryReader["leave_st_date"].ToString();
                    lcl_obj_leave_st_date.Align = "center";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_leave_end_date = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_leave_end_date.InnerText = lcl_obj_LeaveEmployeehistoryReader["leave_end_date"].ToString();
                    lcl_obj_LD_leave_end_date.Align = "center";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_no_of_days = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_no_of_days.InnerText = lcl_obj_LeaveEmployeehistoryReader["no_of_days"].ToString();
                    lcl_obj_LD_no_of_days.Align = "center";

                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveTypeCell);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_leave_st_date);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_leave_end_date);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_no_of_days);

                    this.tblLeaveDetails.Rows.Add(lcl_obj_LD_Row);


                    //lcl_obj_LeaveType.Value = lcl_obj_LeaveTypeReader["leave_code"].ToString();
                    //lcl_obj_LeaveType.Text = lcl_obj_LeaveTypeReader["short_name"].ToString();
                    //this.ddl_LeaveType_id.Items.Insert(lcl_i32_j++, lcl_obj_LeaveType);
                }
                }
                lcl_obj_SqlFacade.CloseReader();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}