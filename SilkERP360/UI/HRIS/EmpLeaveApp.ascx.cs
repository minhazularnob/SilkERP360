using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class EmpLeaveApp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
                this.Session.Remove("comp_c");

                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                //Load Employee Information
               // System.String lcl_str_SqlQuery = System.String.Empty;
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_CODE,EMP.EMPLOYEE_ID,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.EMPLOYEE_STATUS,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,IS_DELETED
                                                                        FROM EMPLOYEE EMP
                                                                        JOIN EMPLOYEE_PERSONAL EMP_P
                                                                        ON EMP.EMPLOYEE_CODE = EMP_P.EMPLOYEE_CODE 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE COMP.COMPANY_CODE = {0} AND (EMP.EMPLOYEE_STATUS = {1} OR EMP.EMPLOYEE_STATUS = {2} OR EMP.EMPLOYEE_STATUS = {3}) AND EMP.IS_DELETED = 1", lcl_str_CompanyCode,(System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Temporary, (System.UInt16)SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeInfoReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeInfoReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee information Was Not Found!!!");
                }

                int lcl_ui32_Index = 1;
                while (lcl_obj_EmployeeInfoReader.Read())
                {

                    System.Web.UI.WebControls.ListItem lcl_obj_EmployeeId = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_EmployeeId.Value = lcl_obj_EmployeeInfoReader["EMPLOYEE_CODE"].ToString();
                    lcl_obj_EmployeeId.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_NAME"].ToString() + " [" + lcl_obj_EmployeeInfoReader["EMPLOYEE_ID"].ToString() + "]";
                    this.ddlEmployeeId.Items.Insert(lcl_ui32_Index++, lcl_obj_EmployeeId);

                    //txt_Lve_EmpID.Text = ;
                    //txt_Lve_EmpName.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_NAME"].ToString();
                    //txt_Lve_Department.Text = lcl_obj_EmployeeInfoReader["DEPT_NAME"].ToString();
                    //txt_Lve_Designation.Text = lcl_obj_EmployeeInfoReader["degn_name"].ToString();
                    //txt_Lve_Company.Text = lcl_obj_EmployeeInfoReader["Company"].ToString();
                    //txt_Lve_JoinDate.Text = lcl_obj_EmployeeInfoReader["JOINING_DATE"].ToString();
                    //lcl_ui64_DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeInfoReader["department_code"].ToString());
                    //lcl_ui64_CompanyCode = 
                }
                //this.ddlEmployeeId.Items.RemoveAt(0);
                lcl_obj_EmployeeInfoReader.Close();
            }
            catch (System.Exception Ex)
            {
            }
        }
    }
}