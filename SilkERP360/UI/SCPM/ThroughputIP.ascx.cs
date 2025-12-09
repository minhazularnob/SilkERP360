using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.SCPM
{
    public partial class ThroughputIP : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE STATUS = {0}",(System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SectionReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_SectionReader.HasRows == false)
                {
                    throw new System.Exception("Data for 'Production Section' was not found in SilkERP!!!");
                }
                System.Int32 lcl_i32_IndexStart = 1;
                while (lcl_obj_SectionReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_SectionItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_SectionItem.Value = lcl_obj_SectionReader["SECTION_CODE"].ToString();
                    lcl_obj_SectionItem.Text = lcl_obj_SectionReader["NAME"].ToString();
                    this.ddlSection.Items.Insert(lcl_i32_IndexStart++, lcl_obj_SectionItem);
                }
                lcl_obj_SectionReader.Close();

                ////Load Shift
                //HARD CODED
                System.Web.UI.WebControls.ListItem lcl_obj_DayShiftItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DayShiftItem.Value = "115000000002";
                lcl_obj_DayShiftItem.Text = "Day Shift";
                this.ddlShift.Items.Insert(1, lcl_obj_DayShiftItem);

                System.Web.UI.WebControls.ListItem lcl_obj_NightShiftItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_NightShiftItem.Value = "115000000003";
                lcl_obj_NightShiftItem.Text = "Night Shift";
                this.ddlShift.Items.Insert(2, lcl_obj_NightShiftItem);

                
            }
            catch (System.Exception Ex)
            {
            }
        }
    }
}