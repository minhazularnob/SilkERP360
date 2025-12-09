using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class NewLeaveApplication : SilkERP360.UI.Base.SilkWebUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initialize();
            this.ExceptionManager.Process(() =>
            {

                System.String lcl_str_EmployeeCode = this.Session["emp_c"].ToString();
                if (lcl_str_EmployeeCode.Trim().Length == 0)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Required EmployeeCode Could Not Be Retrieved From Session!");
                }
                this.Session.Remove("emp_c");
                System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_str_EmployeeCode);
                System.Int32 lcl_i32_j = 1;
                System.UInt64 lcl_ui64_DepartmentCode = 0;
                System.UInt64 lcl_ui64_CompanyCode = 0;
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                //Load Employee Information
                System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format(@"Select EMPLOYEE_ID,EMPLOYEE_NAME,To_char(JOINING_DATE,'DD-Mon-yyyy')JOINING_DATE,c.COMPANY_CODE,c.name As Company,ds.degn_name,DEPT_NAME, e.department_code 
                from employee E inner join COMPANY C On e.company_code=c.company_code
                inner join DESIGNATION DS on E.DESIGNATION_CODE=ds.designation_code
                Inner join DEPARTMENT Dp on  e.department_code=dp.DEPARTMENT_CODE
                where employee_code={0}", lcl_ui64_EmployeeCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeInfoReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeInfoReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee information Was Not Found!!!");
                }

                lcl_obj_EmployeeInfoReader.Read();
                txt_Lve_EmpID.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_ID"].ToString();
                txt_Lve_EmpName.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_NAME"].ToString();
                txt_Lve_Department.Text = lcl_obj_EmployeeInfoReader["DEPT_NAME"].ToString();
                txt_Lve_Designation.Text = lcl_obj_EmployeeInfoReader["degn_name"].ToString();
                txt_Lve_Company.Text = lcl_obj_EmployeeInfoReader["Company"].ToString();
                txt_Lve_JoinDate.Text = lcl_obj_EmployeeInfoReader["JOINING_DATE"].ToString();
                lcl_ui64_DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeInfoReader["department_code"].ToString());
                lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_obj_EmployeeInfoReader["COMPANY_CODE"].ToString());

                System.Text.StringBuilder lcl_obj_HTMLBuilder = new System.Text.StringBuilder();
                lcl_obj_HTMLBuilder.Append("var gbl_ui64_EmployeeCode = ");
                lcl_obj_HTMLBuilder.Append(lcl_str_EmployeeCode);
                lcl_obj_HTMLBuilder.Append(" ;");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "EMP_CODE", lcl_obj_HTMLBuilder.ToString(), true);
                lcl_obj_HTMLBuilder.Clear();
                lcl_obj_SqlFacade.CloseReader();

                //Load Leave Type
                lcl_str_SqlQuery = System.String.Format(@"Select leave_code,short_name
                    from leave Where company_code={0} And is_deleted=1 And status={1} Order by leave_code ", lcl_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_LeaveTypeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_LeaveTypeReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Leave Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_LeaveTypeReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_LeaveType = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_LeaveType.Value = lcl_obj_LeaveTypeReader["leave_code"].ToString();
                    lcl_obj_LeaveType.Text = lcl_obj_LeaveTypeReader["short_name"].ToString();
                    this.ddl_LeaveType_id.Items.Insert(lcl_i32_j++, lcl_obj_LeaveType);
                }
                lcl_obj_SqlFacade.CloseReader();

                //Load Leave Type
                lcl_str_SqlQuery = System.String.Format(@"select EMPLOYEE_CODE,EmpName From
                (select EMPLOYEE_CODE,EMPLOYEE_NAME||'('||EMPLOYEE_ID||')' AS EmpName,IS_DELETED,EMPLOYEE_STATUS,DEPARTMENT_CODE
                From EMPLOYEE )X  Where DEPARTMENT_CODE={0} AND  EMPLOYEE_STATUS =0  And EMPLOYEE_CODE<>{2} AND IS_DELETED = 1 Order by EmpName  ", lcl_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active, lcl_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RefEpmloyeeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_RefEpmloyeeReader.HasRows))
                {
                    //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("RefEmployee Was Not Found!!!");
                    //}
                    lcl_i32_j = 1;
                    while (lcl_obj_RefEpmloyeeReader.Read())
                    {
                        System.Web.UI.WebControls.ListItem lcl_obj_RefEpmloyeItem = new System.Web.UI.WebControls.ListItem();
                        lcl_obj_RefEpmloyeItem.Value = lcl_obj_RefEpmloyeeReader["EMPLOYEE_CODE"].ToString();
                        lcl_obj_RefEpmloyeItem.Text = lcl_obj_RefEpmloyeeReader["EmpName"].ToString();
                        this.ddl_emp_Replacmnt.Items.Insert(lcl_i32_j++, lcl_obj_RefEpmloyeItem);
                    }
                    lcl_obj_SqlFacade.CloseReader();
                }
                //////Load Leave History employee wise

                lcl_str_SqlQuery = System.String.Format(@"select leave.Short_name,leave.no_of_days as due,(leave.no_of_days-employee_entitle_leave.balance) as Taken,employee_entitle_leave.balance as balance from
                                                        employee_entitle_leave join leave on leave.Leave_code=employee_entitle_leave.Leave_code WHERE employee_code = {0} and employee_entitle_leave.is_deleted=1", lcl_str_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_LeaveEmployeehistoryReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_LeaveEmployeehistoryReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Leave history Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_LeaveEmployeehistoryReader.Read())
                {
                    System.Web.UI.HtmlControls.HtmlTableRow lcl_obj_LD_Row = new System.Web.UI.HtmlControls.HtmlTableRow();
                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveTypeCell = new System.Web.UI.HtmlControls.HtmlTableCell();

                    lcl_obj_LD_LeaveTypeCell.InnerText = lcl_obj_LeaveEmployeehistoryReader["Short_name"].ToString();
                    lcl_obj_LD_LeaveTypeCell.Align = "center";


                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveDue = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_LeaveDue.InnerText = lcl_obj_LeaveEmployeehistoryReader["due"].ToString();
                    lcl_obj_LD_LeaveDue.Align = "center";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveTaken = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_LeaveTaken.InnerText = lcl_obj_LeaveEmployeehistoryReader["Taken"].ToString();
                    lcl_obj_LD_LeaveTaken.Align = "center";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveBalance = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_LeaveBalance.InnerText = lcl_obj_LeaveEmployeehistoryReader["balance"].ToString();
                    lcl_obj_LD_LeaveBalance.Align = "center";

                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveTypeCell);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveDue);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveTaken);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveBalance);

                    this.tblLeaveDetails.Rows.Add(lcl_obj_LD_Row);


                    //lcl_obj_LeaveType.Value = lcl_obj_LeaveTypeReader["leave_code"].ToString();
                    //lcl_obj_LeaveType.Text = lcl_obj_LeaveTypeReader["short_name"].ToString();
                    //this.ddl_LeaveType_id.Items.Insert(lcl_i32_j++, lcl_obj_LeaveType);
                }
                lcl_obj_SqlFacade.CloseReader();


            }, "UIExceptionPolicy");
            

        }
    }
}