using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class WorkGroupIPByRange : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
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
            lcl_str_SqlQuery = System.String.Format("SELECT * FROM WORK_GROUP WHERE COMPANY_CODE = {0}", lcl_ui64_CompanyCode);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
            if (!(lcl_obj_WorkGroupReader.HasRows))
            {
                throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Departments for The Selected Company Was Not Found!!!");
            }
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_WorkGroupReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_WorkGroupItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_WorkGroupItem.Value = lcl_obj_WorkGroupReader["WORK_GROUP_CODE"].ToString();
                lcl_obj_WorkGroupItem.Text = lcl_obj_WorkGroupReader["WORK_GROUP_NAME"].ToString();
                this.ddlWorkGroup.Items.Insert(lcl_i32_j++, lcl_obj_WorkGroupItem);
            }
            lcl_obj_SqlFacade.CloseReader();
        }
    }
}