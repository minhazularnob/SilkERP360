using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.SCPM
{
    public partial class SPMNewPO : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
                //setup ddlDepartment
                System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM SPM_CUSTOMER WHERE IS_ACTIVE = {0}", (System.Int32)SilkERP360.CCL.Enums.YesNo.Yes);
                System.Data.OracleClient.OracleDataReader lcl_obj_CustomerReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_CustomerReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Departments for The Selected Company Was Not Found!!!");
                }
                System.Int32 lcl_i32_j = 1;
                while (lcl_obj_CustomerReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_CustomerItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_CustomerItem.Value = lcl_obj_CustomerReader["CUSTOMER_CODE"].ToString();
                    lcl_obj_CustomerItem.Text = lcl_obj_CustomerReader["COMPANY_NAME"].ToString() + " (" + lcl_obj_CustomerReader["SHORT_NAME"].ToString() + " )";
                    this.ddlTelco.Items.Insert(lcl_i32_j++, lcl_obj_CustomerItem);
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