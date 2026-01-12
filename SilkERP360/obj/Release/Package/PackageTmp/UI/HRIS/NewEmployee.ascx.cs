using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class NewEmployee : SilkERP360.UI.Base.SilkWebUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                lcl_str_SqlQuery = System.String.Format("Select DEPARTMENT_CODE,DEPT_NAME From Department Where Company_Code = {0} AND Status = {1} AND Is_Deleted = 1 order by DEPT_NAME", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_DepartmentReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Departments for The Selected Company Was Not Found!!!");
                }
                System.Int32 lcl_i32_j = 1;
                while (lcl_obj_DepartmentReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_DepartmentItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_DepartmentItem.Value = lcl_obj_DepartmentReader["DEPARTMENT_CODE"].ToString();
                    lcl_obj_DepartmentItem.Text = lcl_obj_DepartmentReader["DEPT_NAME"].ToString();
                    this.ddl_Off_Department.Items.Insert(lcl_i32_j++, lcl_obj_DepartmentItem);
                }
                lcl_obj_SqlFacade.CloseReader();

                //setup ddlShift
                lcl_str_SqlQuery = System.String.Format(@"Select SHIFT_CODE,SHIFT_NAME||' ('||to_char(START_TIME, 'hh24:mi:ss')||'-To-'||
to_char(END_TIME, 'hh24:mi:ss')||')'SHIFT_NAME From Shift Where COMPANY_CODE = {0} AND Status = {1} AND Is_Deleted = 1 order by SHIFT_NAME", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
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
                    this.ddl_Off_Shift_Code.Items.Insert(lcl_i32_j++, lcl_obj_ShiftItem);
                }
                lcl_obj_SqlFacade.CloseReader();


                //setup ddlDesignation
                lcl_str_SqlQuery = System.String.Format(@" SELECT DESIGNATION_CODE, DEGN_NAME FROM DESIGNATION Where COMPANY_CODE = {0} AND Status = {1} AND Is_Deleted = 1 order by DEGN_NAME ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DesignationReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_DesignationReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Designation for The Selected Company Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_DesignationReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_DesignationItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_DesignationItem.Value = lcl_obj_DesignationReader["DESIGNATION_CODE"].ToString();
                    lcl_obj_DesignationItem.Text = lcl_obj_DesignationReader["DEGN_NAME"].ToString();
                    this.ddl_Off_Designation.Items.Insert(lcl_i32_j++, lcl_obj_DesignationItem);
                }
                lcl_obj_SqlFacade.CloseReader();

                //setup ddlRefEpmloyee
                lcl_str_SqlQuery = System.String.Format(@"select EMPLOYEE_CODE,EmpName From
(select EMPLOYEE_CODE,EMPLOYEE_NAME||'('||EMPLOYEE_ID||')' AS EmpName,IS_DELETED,EMPLOYEE_STATUS
From EMPLOYEE )X  Where  EMPLOYEE_STATUS ={1} AND IS_DELETED = 1 Order by EmpName  ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RefEpmloyeeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_RefEpmloyeeReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("RefEmployee Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_RefEpmloyeeReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_RefEpmloyeItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_RefEpmloyeItem.Value = lcl_obj_RefEpmloyeeReader["EMPLOYEE_CODE"].ToString();
                    lcl_obj_RefEpmloyeItem.Text = lcl_obj_RefEpmloyeeReader["EmpName"].ToString();
                    this.ddl_Off_RefEmployee.Items.Insert(lcl_i32_j++, lcl_obj_RefEpmloyeItem);
                }
                lcl_obj_SqlFacade.CloseReader();

                //setup ddl_Pers_PresentDistrict
                lcl_str_SqlQuery = System.String.Format(@"Select DISTRICT_CODE,NAME From district Where is_deleted=1 And status={1}Order by NAME ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_PresentDistrictReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_PresentDistrictReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("PresentDistrict Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_PresentDistrictReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_PresentDistrictItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_PresentDistrictItem.Value = lcl_obj_PresentDistrictReader["DISTRICT_CODE"].ToString();
                    lcl_obj_PresentDistrictItem.Text = lcl_obj_PresentDistrictReader["NAME"].ToString();
                    this.ddl_Pers_PresentDistrict.Items.Insert(lcl_i32_j++, lcl_obj_PresentDistrictItem);
                }
                lcl_obj_SqlFacade.CloseReader();
                //setup ddl_Pers_PermanentDistrict
                lcl_str_SqlQuery = System.String.Format(@"Select DISTRICT_CODE,NAME From district Where is_deleted=1 And status={1}Order by NAME ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_PermanentDistrictReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_PermanentDistrictReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("PermanentDistrict Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_PermanentDistrictReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_PermanentDistrictItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_PermanentDistrictItem.Value = lcl_obj_PermanentDistrictReader["DISTRICT_CODE"].ToString();
                    lcl_obj_PermanentDistrictItem.Text = lcl_obj_PermanentDistrictReader["NAME"].ToString();
                    this.ddl_Pers_PermanentDistrict.Items.Insert(lcl_i32_j++, lcl_obj_PermanentDistrictItem);
                }
                lcl_obj_SqlFacade.CloseReader();


                lcl_obj_SqlFacade.Close();

            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void txt_Ref_Organization2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}