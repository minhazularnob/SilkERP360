using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.SCPM
{
    public partial class QCDMTest : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.UInt64 lcl_ui64_CompanyCode = 111000000006; //Silkcard Production Department

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
                lcl_ui64_CompanyCode = lcl_obj_UserProfile.Company.CompanyCode;

                SilkERP360.FL.SqlFacade lcl_sql_Facade = new FL.SqlFacade();
                lcl_sql_Facade.Initialize();

                //Populate Production Section
                System.Int32 lcl_i32_DDLStartIndex = 1;
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //PVC Sheet Vendor Configuration Configuration
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT V.* FROM VENDOR V JOIN VENDOR_GROUP VG ON V.VENDOR_CODE = VG.VENDOR_CODE WHERE VG.GROUP_TYPE = {0} AND V.STATUS = {1} AND V.COMPANY_CODE = {2}", (System.Int16)SilkERP360.CCL.Enums.SCPM.VendorGroup.PVCSheetSupplier, (System.Int16)SilkERP360.CCL.Enums.Status.Active, lcl_ui64_CompanyCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_VendorReader = lcl_sql_Facade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_VendorReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("No Active Vendor Was Found!!!");
                }
                lcl_i32_DDLStartIndex = 1;
                while (lcl_obj_VendorReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_VendorItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_VendorItem.Value = lcl_obj_VendorReader["VENDOR_CODE"].ToString();
                    lcl_obj_VendorItem.Text = lcl_obj_VendorReader["NAME"].ToString();
                    this.ddlSheetVendor.Items.Insert(lcl_i32_DDLStartIndex++, lcl_obj_VendorItem);
                }
                lcl_obj_VendorReader.Close();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            catch (System.Exception Ex)
            {
            }
        }
    }
}