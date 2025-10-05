using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    public class TaxProcessor
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        private ServiceLog m_obj_ServiceLog;

        private SilkERP360.CCL.Enums.Month m_enm_Month;
        private System.UInt16 m_ui16_Year;

        public TaxProcessor(SilkERP360.CCL.Enums.Month IP_enm_Month,System.UInt16 IP_ui16_Year)
        {
            this.m_enm_Month = IP_enm_Month;
            this.m_ui16_Year = IP_ui16_Year;
        }

        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            this.m_obj_ServiceLog = new ServiceLog();
            this.m_obj_ServiceLog.Init(ServiceLogType.TaxProcessor);
            try
            {
                this.m_obj_DBManager = new SilkERP360.DAL.DBManager(IP_str_DatabaseConnectionString);
                this.m_obj_DBManager.Initialize();
            }
            catch (System.Exception Ex)
            {
                this.m_obj_ServiceLog.LogData("Initialization Error : " + Ex.Message);
            }
        }

        public void Process(System.UInt64 IP_ui64_CompanyCode)
        {

        }
    }
}
