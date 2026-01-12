using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SilkERP360.UI.HRIS
{
    public partial class HRISReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.String lcl_str_ReportCode = Request["RptCode"].ToString();
            System.UInt32 lcl_ui32_ReportCode = UInt32.Parse(lcl_str_ReportCode);

            if (lcl_ui32_ReportCode == 1)
            {
                //PrintSalarySheet
                System.String lcl_str_CompanyCode = Request["Comp"].ToString();
                System.String lcl_str_SalaryMonth = Request["SalMon"].ToString();
                System.String lcl_str_SalaryYear = Request["SalYr"].ToString();

                System.UInt64 lcl_ui64_CompanyCode = UInt64.Parse(lcl_str_CompanyCode);
                CCL.Enums.Month lcl_enm_Month = (CCL.Enums.Month)(int.Parse(lcl_str_SalaryMonth));
                System.UInt16 lcl_ui16_Year = ushort.Parse(lcl_str_SalaryYear);

                ReportDocument lcl_obj_ReportDocument = new ReportDocument();
                lcl_obj_ReportDocument.Load(Server.MapPath(@"\Reports\HRIS\HRISSalary.rpt"));
                
                SilkERP360.FL.ServiceProviders.HRIS.SalarySP lcl_obj_SalarySP = new FL.ServiceProviders.HRIS.SalarySP();
                lcl_obj_SalarySP.Initialize();
                CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = lcl_obj_SalarySP.GetSalaryMaster(lcl_ui64_CompanyCode, lcl_enm_Month, lcl_ui16_Year);
                lcl_obj_ReportDocument.Database.Tables[0].SetDataSource(lcl_obj_SalaryMaster.SalaryList);

                this.reportViewer.ControlStyle.Height = 10;
                this.reportViewer.ReportSource = lcl_obj_ReportDocument;
            }
            
        }
    }
}