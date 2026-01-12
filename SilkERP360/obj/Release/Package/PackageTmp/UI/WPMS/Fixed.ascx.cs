using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.WPMS
{
    public partial class RawMaterial : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductFixedTab();
            BuyerFixedTab();

        }

        void ProductFixedTab()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select PRODUCT_CATAGORY_CODE,CATAGORY_NAME from WPMS_FINISHED_PRODUCT", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_FinishedProductReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["PRODUCT_CATAGORY_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["CATAGORY_NAME"].ToString();
                this.ddlProductName1.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();

        }

        void BuyerFixedTab()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select BUYER_CODE,COMPANY_NAME from WPMS_BUYER", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_FinishedProductReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["BUYER_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["COMPANY_NAME"].ToString();
                this.ddlCustomerName0.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();
        }
    }
}