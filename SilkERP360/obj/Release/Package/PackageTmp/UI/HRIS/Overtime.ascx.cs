using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class Overtime : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
                System.String lcl_str_DepartmentCode = this.Session["Dept_c"].ToString();
                this.Session.Remove("comp_c");
                this.Session.Remove("Dept_c");

                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new SilkERP360.FL.HRIS.DepartmentFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength> lcl_obj_DepartmentStrengths
                    = lcl_obj_DepartmentFacade.GetDepartmentStrengthByCompany(lcl_ui64_CompanyCode);

                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM DEPARTMENT WHERE DEPARTMENT_CODE = {0}", lcl_str_DepartmentCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_DepartmentReader.Read();
                this.txtDepartment.Text = lcl_obj_DepartmentReader["DEPT_NAME"].ToString();
                this.hdnDepartmentCode.Value = lcl_str_DepartmentCode;
                lcl_obj_SqlFacade.CloseReader();
                lcl_obj_SqlFacade.Close();
            }
            catch (System.Exception Ex)
            {
            }
        }
    }
}