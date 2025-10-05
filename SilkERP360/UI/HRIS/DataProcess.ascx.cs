using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class DataProcess : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
            System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
            this.Session.Remove("comp_c");



            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            //setup ddlDepartment
            System.String lcl_str_SqlQuery = System.String.Empty;
            System.Int32 lcl_i32_j = 0;
            //setup ddlShift
            lcl_str_SqlQuery = System.String.Format(@"Select SHIFT_CODE,SHIFT_NAME||' ('||to_char(START_TIME, 'hh24:mi:ss')||'-To-'||
                to_char(END_TIME, 'hh24:mi:ss')||')'SHIFT_NAME From Shift Where COMPANY_CODE = {0} AND Status = {1} AND Is_Deleted = 1 order by SHIFT_NAME", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_ShiftReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
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
                this.ddl_AttenShift.Items.Insert(lcl_i32_j++, lcl_obj_ShiftItem);
            }
            lcl_obj_SqlFacade.CloseReader();
        }
    }
}