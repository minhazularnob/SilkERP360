using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.SCPM
{
    public partial class scpm_hm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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

                //get Modulecode from query string
                System.String lcl_str_ModuleCode = this.Context.Request.QueryString["Mod"].ToString();
                if ((lcl_str_ModuleCode == null) || (lcl_str_ModuleCode == System.String.Empty))
                {
                    //redirect to error page
                    return;
                }
                System.UInt64 lcl_ui64_ModuleCode = System.UInt64.Parse(lcl_str_ModuleCode.ToString());
                SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfile = lcl_obj_AuthenticUserContext.UserProfile;
                //paste User Image

                System.Boolean lcl_b_IsModulePermitted = false;
                SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany lcl_obj_ModuleMenuCompany = null;
                foreach (SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany lcl_obj_ModuleMenuCompanyTmp in lcl_obj_UserProfile.ModuleMenusCompanies)
                {
                    if (lcl_obj_ModuleMenuCompanyTmp.ModuleCode == lcl_ui64_ModuleCode)
                    {
                        lcl_b_IsModulePermitted = true;
                        lcl_obj_ModuleMenuCompany = lcl_obj_ModuleMenuCompanyTmp;
                        break;
                    }
                    lcl_b_IsModulePermitted = false;
                }
                if (lcl_b_IsModulePermitted == false)
                {
                    //redirect
                    return;
                }
                lcl_obj_AuthenticUserContext.ActiveModuleCode = lcl_ui64_ModuleCode;

                //list of all departments for the permitted companies are stored here
                System.Collections.Generic.Dictionary<System.UInt64, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>> lcl_obj_CompanyDepartments =
                    new System.Collections.Generic.Dictionary<System.UInt64, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>>();

                ///set company
                /////get all departments of permitted company for the user
                System.Int32 i = 1;
                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new SilkERP360.FL.HRIS.DepartmentFacade();


                /************************************************************************************************************************/
                //this.lblModuleName.InnerText = lcl_obj_ModuleMenuCompany.ModuleName + "(" + lcl_obj_ModuleMenuCompany.ShortName + ")";
                this.txtName.Text = lcl_obj_UserProfile.EmployeeName;
                this.txtUserName.Text = lcl_obj_UserProfile.UserName;
                this.txtIP.Text = lcl_obj_AuthenticUserContext.IPAddress;
                this.txtAccessLevel.Text = lcl_obj_UserProfile.AccessLevel.ToString();
                this.txtSignedEmployeeCode.Value = lcl_obj_UserProfile.EmployeeCode.ToString();
                this.txtDesignation.Text = lcl_obj_UserProfile.Designation.Name;
                this.companyIdHidden.Value = lcl_obj_UserProfile.Company.CompanyCode.ToString();


                this.imgEmpImage.ImageUrl = "data:" + lcl_obj_UserProfile.Image.ImageType + ";base64," + lcl_obj_UserProfile.Image.ImageData;

                this.lblDay.Text = System.DateTime.Now.Day.ToString();
                this.lblMonth.Text = System.DateTime.Now.ToString("MMMM").Substring(0, 3);
                this.lblYear.Text = System.DateTime.Now.Year.ToString();
                /************************************************SORT/CONFIGURE MENU****************************************************/
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.Menu> lcl_obj_Menus = lcl_obj_ModuleMenuCompany.Menus;
                IEnumerable<SilkERP360.CCL.BusinessEntities.UI.Menu> lcl_obj_ParentMenus = (from lcl_obj_Menu in lcl_obj_Menus
                                                                                           where (lcl_obj_Menu.ParentMenuCode == 101)
                                                                                           select lcl_obj_Menu).ToList();

                
                System.Text.StringBuilder lcl_obj_MenuBuilder = new System.Text.StringBuilder();
                //lcl_obj_MenuBuilder.Append("function ConfigureMenu(){$('#mnuContainer').html(\"<ul id='scpmFuncMenu'>");

                //lcl_obj_MenuBuilder.Append("var lcl_str_HorizontalMenuHTML = \"<ul id='menu'>");
                //lcl_obj_MenuBuilder.Append("var lcl_str_HorizontalMenuHTML = \"<ul id='mnuSCPM'><li class='current'><a href='#' onclick='Logout();return false;'>Logout</a></li>");
                lcl_obj_MenuBuilder.Append("var lcl_str_HorizontalMenuHTML = \"<ul id='menu'>");
                foreach (SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_ParentMenu in lcl_obj_ParentMenus)
                {
                    //System.Web.UI.WebControls.MenuItem lcl_obj_ParentMenuItem = new System.Web.UI.WebControls.MenuItem(lcl_obj_ParentMenu.MenuName, lcl_obj_ParentMenu.MenuCode.ToString(), lcl_obj_ParentMenu.Link);
                    lcl_obj_MenuBuilder.Append("<li><a href='" + '#' + "'>" + lcl_obj_ParentMenu.MenuName + "</a>");
                    
                    IEnumerable<SilkERP360.CCL.BusinessEntities.UI.Menu> lcl_obj_ChildMenus = from lcl_obj_Menu in lcl_obj_Menus
                                                                                              where (lcl_obj_Menu.ParentMenuCode == lcl_obj_ParentMenu.MenuCode)
                                                                                              select lcl_obj_Menu;
                    if (lcl_obj_ChildMenus.Count() <= 0)
                    {
                        lcl_obj_MenuBuilder.Append("</li>");
                        continue;
                    }
                    lcl_obj_MenuBuilder.Append("<ul>");
                    foreach (SilkERP360.CCL.BusinessEntities.UI.Menu lcl_obj_ChildMenu in lcl_obj_ChildMenus)
                    {
                        //System.Web.UI.WebControls.MenuItem lcl_obj_ChildMenuItem = new System.Web.UI.WebControls.MenuItem(lcl_obj_ChildMenu.MenuName, lcl_obj_ChildMenu.MenuCode.ToString(), lcl_obj_ChildMenu.Link);
                        //lcl_obj_ParentMenuItem.ChildItems.Add(lcl_obj_ChildMenuItem);
                        lcl_obj_MenuBuilder.Append("<li><a href='" + lcl_obj_ChildMenu.Link + "'>" + lcl_obj_ChildMenu.MenuName + "</a></li>");
                    }
                    lcl_obj_MenuBuilder.Append("</ul>");
                    lcl_obj_MenuBuilder.Append("</li>");
                    //this.mnuHRIS.Items.Add(lcl_obj_ParentMenuItem);
                }
                //lcl_obj_MenuBuilder.Append("</ul>\");}");
                lcl_obj_MenuBuilder.Append("<li class='current'><a href='#' onclick='Logout();return false;'>LOGOUT</a></li>");
                lcl_obj_MenuBuilder.Append("</ul>\";");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SCPM_MNU", lcl_obj_MenuBuilder.ToString(), true);

            }
            catch (System.Exception Ex)
            {
                //redirect to error page
                this.Session["Err"] = Ex.Message;
                this.Session["StTrace"] = Ex.StackTrace;
                //this.Session["TarS"] = this.Session["SEC_TKN"].ToString(); 
                this.Response.Redirect("Error.aspx");
            }
        }
    }
}