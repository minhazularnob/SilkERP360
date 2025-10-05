using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class BonusMaster : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
                this.Session.Remove("comp_c");

                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM BONUS_MASTER WHERE COMPANY_CODE = {0}", lcl_str_CompanyCode);

                SilkERP360.SP.HRIS.BonusServices lcl_obj_BonusServices = new SP.HRIS.BonusServices();
                lcl_obj_BonusServices.Initialize();

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster> lcl_objLst_BonusMaster = lcl_obj_BonusServices.GetBonusMasterListByCompany(lcl_ui64_CompanyCode);

                int lcl_ui32_Index = 1;
                System.String lcl_str_BonusMasterName = System.String.Empty;
                foreach(SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster in lcl_objLst_BonusMaster)
                {

                    System.Web.UI.WebControls.ListItem lcl_obj_BonusMasterItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_BonusMasterItem.Value = lcl_obj_BonusMaster.BonusMasterCode.ToString();

                    switch (lcl_obj_BonusMaster.Occasion)
                    {
                        case CCL.Enums.BonusOccasion.EidUlFitr:
                            lcl_str_BonusMasterName = "Eid-ul-Fitr-";
                            break;
                        case CCL.Enums.BonusOccasion.EidUlAzha:
                            lcl_str_BonusMasterName = "Eid-ul-Azha-";
                            break;
                    }
                    switch (lcl_obj_BonusMaster.Month)
                    {
                        case CCL.Enums.Month.January:
                            lcl_str_BonusMasterName += "January-";
                            break;
                        case CCL.Enums.Month.February:
                            lcl_str_BonusMasterName += "February-";
                            break;
                        case CCL.Enums.Month.March:
                            lcl_str_BonusMasterName += "March-";
                            break;
                        case CCL.Enums.Month.April:
                            lcl_str_BonusMasterName += "April-";
                            break;
                        case CCL.Enums.Month.May:
                            lcl_str_BonusMasterName += "May-";
                            break;
                        case CCL.Enums.Month.June:
                            lcl_str_BonusMasterName += "June-";
                            break;
                        case CCL.Enums.Month.July:
                            lcl_str_BonusMasterName += "July-";
                            break;
                        case CCL.Enums.Month.August:
                            lcl_str_BonusMasterName += "August-";
                            break;
                        case CCL.Enums.Month.September:
                            lcl_str_BonusMasterName += "September-";
                            break;
                        case CCL.Enums.Month.October:
                            lcl_str_BonusMasterName += "October-";
                            break;
                        case CCL.Enums.Month.November:
                            lcl_str_BonusMasterName += "November-";
                            break;
                        case CCL.Enums.Month.December:
                            lcl_str_BonusMasterName += "December-";
                            break;
                    }
                    lcl_str_BonusMasterName += lcl_obj_BonusMaster.Year.ToString();

                    lcl_obj_BonusMasterItem.Text = lcl_str_BonusMasterName;

                    this.ddlBonusMaster.Items.Insert(lcl_ui32_Index++, lcl_obj_BonusMasterItem);
                }
                int a = 0;
            }
            catch (System.Exception Ex)
            {
                int k = 0;
            }
        }
    }
}