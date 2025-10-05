namespace SilkERP360.Globals.classes
{
    public static class ReportSubmitted
    {
        static CrystalDecisions.CrystalReports.Engine.ReportDocument rpt;

        public static CrystalDecisions.CrystalReports.Engine.ReportDocument Rpt
        {
            get { return ReportSubmitted.rpt; }
            set { ReportSubmitted.rpt = value; }
        }
    }
}