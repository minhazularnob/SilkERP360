using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class MenuPermission : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Response.Redirect("ListInstructors.aspx");
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                //setup ddlDepartment
                System.String lcl_str_SqlQuery = System.String.Empty, lcl_str_SqlQuerym = System.String.Empty;
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
                    this.ddl_MenuUserID.Items.Insert(lcl_i32_j++, lcl_obj_UserItem);
                }
                lcl_obj_SqlFacade.CloseReader();

                // Module Load

                lcl_str_SqlQuerym = System.String.Format("select module_code,module_name from Module order by Module_Code");
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserReaderm = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuerym);
                if (!(lcl_obj_UserReaderm.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Module Not Found!!!");
                }
                System.Int32 lcl_i32_jm = 1;
                while (lcl_obj_UserReaderm.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_UserItemm = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_UserItemm.Value = lcl_obj_UserReaderm["Module_Code"].ToString();
                    lcl_obj_UserItemm.Text = lcl_obj_UserReaderm["module_name"].ToString();
                    this.ddl_ModuleName.Items.Insert(lcl_i32_jm++, lcl_obj_UserItemm);
                }

                lcl_obj_SqlFacade.CloseReader();
            }
        }
    }
}