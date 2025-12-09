using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.SCPM
{
    public partial class SC_Perso_Recovery : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_sql_Facade = new FL.SqlFacade();
                lcl_sql_Facade.Initialize();
                
                //populate Machine Field
                //this.ddlMachine.Items.Add("-----Select Machine");
                System.Int32 lcl_i32_DDLStartIndex = 1;
                System.String lcl_str_SqlQuery = System.String.Format("Select * from SCPM_Machine where status = 1");
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_MachineReader = lcl_sql_Facade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_MachineReader.HasRows))
                {
                    throw new System.Exception("No Machines Configured for Scratch Card Sections!!!");
                }
                while (lcl_obj_MachineReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_MachineItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_MachineItem.Value = lcl_obj_MachineReader["MACHINE_CODE"].ToString();
                    lcl_obj_MachineItem.Text = lcl_obj_MachineReader["NAME"].ToString();
                    this.ddlMachine.Items.Insert(lcl_i32_DDLStartIndex++, lcl_obj_MachineItem);
                }
                lcl_sql_Facade.CloseReader();
                lcl_i32_DDLStartIndex = 1;
                //this.ddlJobOrder.Items.Add("-----Select Job Order");
                //get job order
                lcl_str_SqlQuery = System.String.Format("Select * from SCPM_SC_J_O Where Production_Status = {0} And Status = 1", (System.Int32)SilkERP360.CCL.SCPMEnumerations.JobOrderProductionStatus.NotCompleted);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_JOReader = lcl_sql_Facade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_JOReader.HasRows))
                {
                    throw new System.Exception("No Job Order in Production Now!!!");
                }
                while (lcl_obj_JOReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_JOItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_JOItem.Value = lcl_obj_JOReader["SC_J_O_CODE"].ToString();
                    lcl_obj_JOItem.Text = lcl_obj_JOReader["SC_J_O_NO"].ToString();
                    this.ddlJobOrder.Items.Insert(lcl_i32_DDLStartIndex++, lcl_obj_JOItem);
                }
                lcl_sql_Facade.CloseReader();

                lcl_sql_Facade.Close();
                
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}