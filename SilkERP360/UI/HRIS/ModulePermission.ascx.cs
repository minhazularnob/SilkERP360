using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class ModulePermission : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Response.Redirect("ListInstructors.aspx");
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                //setup ddlDepartment
                System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format("Select USER_CODE,USER_NAME From USERS Where IS_DELETED=1");
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_UserReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("User Not Found!!!");
                }
                System.Int32 lcl_i32_j = 1;
                while (lcl_obj_UserReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_UserItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_UserItem.Value = lcl_obj_UserReader["USER_CODE"].ToString();
                    lcl_obj_UserItem.Text = lcl_obj_UserReader["USER_NAME"].ToString();
                    this.ddl_UserID.Items.Insert(lcl_i32_j++, lcl_obj_UserItem);
                }
                lcl_obj_SqlFacade.CloseReader();
            }

            
        }



        protected void btnShow_Click(object sender, EventArgs e)
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            //setup ddlDepartment
            System.String lcl_str_SqlQuery = System.String.Empty;
            lcl_str_SqlQuery = System.String.Format(@"Select user_code,Employee_Name,DEGN_NAME,DEPT_NAME,NAME from 
                                            (Select user_code,employee_code from users
                                            Where user_code=" + ddl_UserID.SelectedValue + @")A 
                                            Left outer join 
                                            (select employee_code,Employee_Name,DEGN_NAME,DEPT_NAME,NAME from employee E 
                                            Inner join DESIGNATION D On E.DESIGNATION_CODE=D.DESIGNATION_CODE
                                            Inner join DEPARTMENT Dp On E.DEPARTMENT_CODE=Dp.DEPARTMENT_CODE
                                            Inner join COMPANY c On E.COMPANY_CODE=c.COMPANY_CODE)B On A.employee_code=B.employee_code");
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
            if (!(lcl_obj_UserReader.HasRows))
            {
                throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("User Not Found!!!");
            }

            lcl_obj_UserReader.Read();


            txt_Name.Text = lcl_obj_UserReader["Employee_Name"].ToString();
            txt_Designation.Text = lcl_obj_UserReader["DEGN_NAME"].ToString();
            txt_Department.Text = lcl_obj_UserReader["DEPT_NAME"].ToString();
            txt_CompanyName.Text = lcl_obj_UserReader["NAME"].ToString();
            
        }
    }
}