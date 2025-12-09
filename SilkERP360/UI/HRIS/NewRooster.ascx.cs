using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class NewRooster : SilkERP360.UI.Base.SilkWebUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initialize();
            this.ExceptionManager.Process(() =>
            {
                System.String lcl_str_DepartmentCode = this.Session["dept_c"].ToString();
                System.UInt64 lcl_ui64_DepartmentCode = System.UInt64.Parse(lcl_str_DepartmentCode);
                this.Session.Remove("dept_c");

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
                lcl_str_SqlQuery = System.String.Format("Select DEPT_NAME,COMPANY_CODE from Department Where Department_Code = {0}", lcl_str_DepartmentCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_DepartmentReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Department Details Was Not Found For Department with Code : " + lcl_str_DepartmentCode + "!!!");
                }
                lcl_obj_DepartmentReader.Read();
                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_obj_DepartmentReader["COMPANY_CODE"].ToString());
                this.txtDepartment.Text = lcl_obj_DepartmentReader["DEPT_NAME"].ToString();
                System.Int32 lcl_i32_j = 1;

                //SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile =
                //    lcl_obj_EmployeeProfileFacade.GetRoosterAvailableEmployeeProfileListByDepartmentCode(lcl_ui64_DepartmentCode);
                //System.Int32 lcl_i32_Index = 1;
                //foreach(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile in lcl_objLst_EmployeeProfile)
                //{
                //    System.Web.UI.WebControls.TableRow lcl_obj_TableRow = new System.Web.UI.WebControls.TableRow();
                //    System.Web.UI.WebControls.TableCell lcl_tblCell_Select = new System.Web.UI.WebControls.TableCell();
                //    lcl_tblCell_Select.Text = "<input id='chkSelectEmployee-" + lcl_i32_Index.ToString() + "' />";

                //    System.Web.UI.WebControls.TableCell lcl_tblCell_DepartmentStrength = new System.Web.UI.WebControls.TableCell();
                //    lcl_tblCell_DepartmentStrength.Text = lcl_obj_DepartmentStrength.EmployeeStrength.ToString();

                //    System.Web.UI.WebControls.TableCell lcl_tblCell_Action = new System.Web.UI.WebControls.TableCell();
                //    lcl_tblCell_Action.Text = "<a id='hlnkContextMenu-" + lcl_i32_Index.ToString() + "' class='ctx_mnu' href='#'><img id=" + lcl_obj_DepartmentStrength.DepartmentCode.ToString() + " src='/Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";

                //    lcl_obj_TableRow.Cells.AddRange(new TableCell[] { lcl_tblCell_DepartmentName, lcl_tblCell_DepartmentStrength, lcl_tblCell_Action });
                //    this.tblDepartmentList.Rows.Add(lcl_obj_TableRow);
                //}


                lcl_obj_SqlFacade.CloseReader();

                //setup ddlShift
                lcl_str_SqlQuery = System.String.Format(@"Select SHIFT_CODE,SHIFT_NAME||' ('||to_char(START_TIME, 'hh24:mi:ss')||'-To-'||
                to_char(END_TIME, 'hh24:mi:ss')||')'SHIFT_NAME From Shift Where COMPANY_CODE = {0} AND Status = {1} AND Is_Deleted = 1 order by SHIFT_NAME", lcl_ui64_CompanyCode.ToString(), (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ShiftReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_ShiftReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Shift for The Selected Company Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_ShiftReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_ShiftItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_ShiftItem.Value = lcl_obj_ShiftReader["SHIFT_CODE"].ToString();
                    lcl_obj_ShiftItem.Text = lcl_obj_ShiftReader["SHIFT_NAME"].ToString();
                    this.ddlShift.Items.Insert(lcl_i32_j++, lcl_obj_ShiftItem);
                }
                lcl_obj_SqlFacade.CloseReader();

                lcl_obj_SqlFacade.Close();
                this.txtRoosterDepartmentCode.Value = lcl_str_DepartmentCode;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ROOSTER_DEPARTMENT", "$('#txtDepartment').data('DepartmentCode','" + lcl_str_DepartmentCode + "');", true);
            }, "FLExceptionPolicy");

        }
    }
}