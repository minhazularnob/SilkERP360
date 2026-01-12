using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.WPMS
{
    public partial class SalesContract : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
            ShowPOCode(lcl_obj_SqlFacade);

        }
        void ShowPOCode(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryProduct = System.String.Empty;
            lcl_str_SqlQueryProduct = System.String.Format("Select PURCHASE_ORDER_CODE From WPMS_PURCHASE_ORDER order by PURCHASE_ORDER_CODE desc", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryProduct);
            System.Int32 lcl_i32_K = 1;
            while (lcl_obj_Reader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_Reader["PURCHASE_ORDER_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_Reader["PURCHASE_ORDER_CODE"].ToString();
                this.ddlPOCode.Items.Insert(lcl_i32_K++, lcl_obj_EmployeeItem);
            }
            lcl_obj_Reader.Close();

        }
    }
}