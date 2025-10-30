using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class DepartmentwiseAdministration : SilkERP360.UI.Base.SilkWebUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initialize();
            this.ExceptionManager.Process(() =>
            {
                System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
                //lcl_str_CompanyCode = "";
                if (System.String.IsNullOrEmpty(lcl_str_CompanyCode))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Required CompanyCode Could Not Be Retrieved from the Session!!!");
                }
                else
                {
                    this.Session.Remove("comp_c");
                }

                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
                SilkERP360.FL.HRIS.DepartmentFacade lcl_obj_DepartmentFacade = new SilkERP360.FL.HRIS.DepartmentFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength> lcl_obj_DepartmentStrengths
                    = lcl_obj_DepartmentFacade.GetDepartmentStrengthByCompany(lcl_ui64_CompanyCode);
                System.Int32 lcl_i32_Index = 1;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DepartmentStrength lcl_obj_DepartmentStrength in lcl_obj_DepartmentStrengths)
                {
                    System.Web.UI.WebControls.TableRow lcl_obj_TableRow = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell lcl_tblCell_DepartmentName = new System.Web.UI.WebControls.TableCell();
                    lcl_tblCell_DepartmentName.Text = lcl_obj_DepartmentStrength.Name;

                    System.Web.UI.WebControls.TableCell lcl_tblCell_DepartmentStrength = new System.Web.UI.WebControls.TableCell();
                    lcl_tblCell_DepartmentStrength.Text = lcl_obj_DepartmentStrength.EmployeeStrength.ToString();

                    System.Web.UI.WebControls.TableCell lcl_tblCell_Action = new System.Web.UI.WebControls.TableCell();
                    lcl_tblCell_Action.Text = "<button type='button' class='btn btn-light btn-sm ctx_mnu' id='" + lcl_obj_DepartmentStrength.DepartmentCode.ToString() + "' title='Actions' aria-label='Actions' style='border:1px solid #dee2e6;'>⋮</button>";

                    lcl_obj_TableRow.Cells.AddRange(new TableCell[] { lcl_tblCell_DepartmentName, lcl_tblCell_DepartmentStrength, lcl_tblCell_Action });
                    this.tblDepartmentList.Rows.Add(lcl_obj_TableRow);
                }
            }, "UIExceptionPolicy");
        }
    }
}