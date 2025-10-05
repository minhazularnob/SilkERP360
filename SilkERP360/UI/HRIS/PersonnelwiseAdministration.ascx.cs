using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class PersonnelwiseAdministration : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
                this.Session.Remove("comp_c");

                //SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new SilkERP360.FL.HRIS.DepartmentFacade();
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_Departments = lcl_obj_DepartmentFacade.GetDepartmentCoresByCompany(lcl_ui64_CompanyCode);

                //System.Int32 lcl_i32_j = 1;
                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_DepartmentCore in lcl_obj_Departments)
                //{
                //    System.Web.UI.WebControls.ListItem lcl_obj_DepartmentItem = new System.Web.UI.WebControls.ListItem();
                //    lcl_obj_DepartmentItem.Value = lcl_obj_DepartmentCore.DepartmentCode.ToString();
                //    lcl_obj_DepartmentItem.Text = lcl_obj_DepartmentCore.Name;
                //    this.ddl_Off_Department.Items.Insert(lcl_i32_j++, lcl_obj_DepartmentItem);
                //}

                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                //setup ddlDepartment
                System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format("Select DEPARTMENT_CODE,DEPT_NAME From Department Where Company_Code = {0} AND Status = {1} AND Is_Deleted = 1 order by DEPT_NAME", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_DepartmentReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Departments for The Selected Company Was Not Found!!!");
                }
                System.Int32 lcl_i32_j = 1;
                while (lcl_obj_DepartmentReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_DepartmentItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_DepartmentItem.Value = lcl_obj_DepartmentReader["DEPARTMENT_CODE"].ToString();
                    lcl_obj_DepartmentItem.Text = lcl_obj_DepartmentReader["DEPT_NAME"].ToString();
                    this.ddlDepartment.Items.Insert(lcl_i32_j++, lcl_obj_DepartmentItem);
                }
                lcl_obj_SqlFacade.CloseReader();
                lcl_obj_SqlFacade.Close();
            }
            catch (System.Exception Ex)
            {
            }
        }
    }
}