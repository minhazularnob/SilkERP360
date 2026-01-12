using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.SCPM
{
    public partial class QCMaster : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.UInt64 lcl_ui64_DepartmentCode = 111000000006; //Silkcard Production Department
                this.txtDate.Text = System.DateTime.Now.ToString("dd/MMMM/yyyy");

                if (this.Session["USR_CNTXT"] == null)
                {
                    //session not marked.
                    //intrusion detected
                    System.String lcl_str_URL = HttpContext.Current.Request.ApplicationPath + "index.aspx";
                    Response.Redirect(lcl_str_URL, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = (SilkERP360.CCL.Repository.AuthenticUserContext)this.Session["USR_CNTXT"];
                if (lcl_obj_AuthenticUserContext == null)
                {
                    //redirect to error page
                    System.String lcl_str_URL = HttpContext.Current.Request.ApplicationPath + "index.aspx";
                    Response.Redirect(lcl_str_URL, false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfile = lcl_obj_AuthenticUserContext.UserProfile;
                this.txtQAEngineer.Text = lcl_obj_UserProfile.EmployeeName + "(" + lcl_obj_UserProfile.EmployeeID + ")";
                this.hdnQAEngineerCode.Value = lcl_obj_UserProfile.EmployeeCode.ToString();

                SilkERP360.FL.SqlFacade lcl_sql_Facade = new FL.SqlFacade();
                lcl_sql_Facade.Initialize();

                //Populate Production Section
                System.Int32 lcl_i32_DDLStartIndex = 1;
                System.String lcl_str_SqlQuery = System.String.Format("Select * from SCPM_Section where status = 1");
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SectionReader = lcl_sql_Facade.ExecuteDataReader(lcl_str_SqlQuery);

                if (!(lcl_obj_SectionReader.HasRows))
                {
                    throw new System.Exception("No Machines Configured for Scratch Card Sections!!!");
                }
                this.ddlSection.Items.Add("-----Select Production Section");
                while (lcl_obj_SectionReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_SectionItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_SectionItem.Value = lcl_obj_SectionReader["SECTION_CODE"].ToString();
                    lcl_obj_SectionItem.Text = lcl_obj_SectionReader["NAME"].ToString();
                    this.ddlSection.Items.Insert(lcl_i32_DDLStartIndex++, lcl_obj_SectionItem);
                }
                lcl_obj_SectionReader.Close();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Shift Configuration
                lcl_str_SqlQuery = System.String.Format(@"SELECT * FROM SHIFT WHERE DEPARTMENT_CODE = {0}", lcl_ui64_DepartmentCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ShiftReader = lcl_sql_Facade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_ShiftReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("No Shift Was Found!!!");
                }
                lcl_i32_DDLStartIndex = 1;
                while (lcl_obj_ShiftReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_ShiftItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_ShiftItem.Value = lcl_obj_ShiftReader["SHIFT_CODE"].ToString();
                    lcl_obj_ShiftItem.Text = lcl_obj_ShiftReader["SHIFT_NAME"].ToString();
                    this.ddlShift.Items.Insert(lcl_i32_DDLStartIndex++, lcl_obj_ShiftItem);
                }
                lcl_obj_ShiftReader.Close();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
              
                //populate Machine Field
                //this.ddlMachine.Items.Add("-----Select Machine");
                //lcl_i32_DDLStartIndex = 1;
                //lcl_str_SqlQuery = System.String.Format("Select * from SCPM_Machine where status = 1");
                //Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_sql_Facade.ExecuteDataReader(lcl_str_SqlQuery);
                //if (!(lcl_obj_MachineReader.HasRows))
                //{
                //    throw new System.Exception("No Machines Configured for Scratch Card Sections!!!");
                //}
                //while (lcl_obj_MachineReader.Read())
                //{
                //    System.Web.UI.WebControls.ListItem lcl_obj_MachineItem = new System.Web.UI.WebControls.ListItem();
                //    lcl_obj_MachineItem.Value = lcl_obj_MachineReader["MACHINE_CODE"].ToString();
                //    lcl_obj_MachineItem.Text = lcl_obj_MachineReader["NAME"].ToString();
                //    this.ddlMachine.Items.Insert(lcl_i32_DDLStartIndex++, lcl_obj_MachineItem);
                //}

                lcl_i32_DDLStartIndex = 1;
                this.ddlOperator.Items.Add("-----Select Machine Operator");
                
                lcl_str_SqlQuery = System.String.Format(@"SELECT * FROM SILKERP.EMPLOYEE WHERE DEPARTMENT_CODE = {0} AND EMPLOYEE_STATUS = {1}", lcl_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RefEpmloyeeReader = lcl_sql_Facade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_RefEpmloyeeReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("RefEmployee Was Not Found!!!");
                }
                lcl_i32_DDLStartIndex = 1;
                System.Text.StringBuilder lcl_obj_SB = new System.Text.StringBuilder();
                while (lcl_obj_RefEpmloyeeReader.Read())
                {
                    lcl_obj_SB.Append(lcl_obj_RefEpmloyeeReader["EMPLOYEE_NAME"].ToString());
                    lcl_obj_SB.Append(" [");
                    lcl_obj_SB.Append(lcl_obj_RefEpmloyeeReader["EMPLOYEE_ID"].ToString());
                    lcl_obj_SB.Append("] ");
                    System.Web.UI.WebControls.ListItem lcl_obj_OperatorItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_OperatorItem.Value = lcl_obj_RefEpmloyeeReader["EMPLOYEE_CODE"].ToString();
                    lcl_obj_OperatorItem.Text = lcl_obj_SB.ToString();
                    this.ddlOperator.Items.Insert(lcl_i32_DDLStartIndex, lcl_obj_OperatorItem);
                    lcl_obj_SB.Clear();
                }

                //this.ddlProductionProcess.Items.Add("-----Select Production Process");

                lcl_sql_Facade.CloseReader();
            }
            catch (System.Exception Ex)
            {
            }
        }
    }
}