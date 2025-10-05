using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.WPMS
{
    public partial class RawMaterial1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RawPRoductList();
        }

        public void RawPRoductList()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select RM_CODE,RM_NAME,STATUS FROM WPMS_RAW_PRODUCT Where STATUS=1", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_CustomerReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_CustomerReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_CustomerReader["RM_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_CustomerReader["RM_NAME"].ToString();
                this.ddlProductSelect.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();

        }
    }
}