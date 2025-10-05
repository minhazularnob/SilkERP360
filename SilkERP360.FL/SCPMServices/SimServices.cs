using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPMServices
{
    public class SimServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SimServices()
        {
            this.Initialize();
        }

        public SilkERP360.CCL.Misc.WSResponse SMPeelOffQCMasterBatchSetup(SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch IP_obj_ScpmSmMasterBatch)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponseTmp = null;
                SilkERP360.BML.SCPM.ScpmSmMasterBatchManager lcl_obj_ScpmSmMasterBatchManager = new BML.SCPM.ScpmSmMasterBatchManager();
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MASTER_BATCH WHERE MASTER_BATCH = '{0}'", IP_obj_ScpmSmMasterBatch.MasterBatch);
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                System.Data.OracleClient.OracleDataReader lcl_obj_ScpmMasterBatchReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                SilkERP360.BML.SCPM.ScpmSmMasterBatchManager lcl_obj_ScpmMasterBatchManager = new BML.SCPM.ScpmSmMasterBatchManager();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_ScpmSmMasterBatch = null;
                if (!(lcl_obj_ScpmMasterBatchReader.HasRows))
                {
                    //MasterBatch Not Saved. Create MasterBatch
                    System.UInt64 lcl_ui64_ScpmMasterBatchCode = lcl_obj_ScpmMasterBatchManager.Save(IP_obj_ScpmSmMasterBatch);
                    IP_obj_ScpmSmMasterBatch.MasterBatchCode = lcl_ui64_ScpmMasterBatchCode;
                    lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, IP_obj_ScpmSmMasterBatch);
                    return lcl_obj_WSResponseTmp;
                }
                else
                {
                    //lcl_obj_ScpmMasterBatch
                    lcl_obj_ScpmSmMasterBatch = lcl_obj_ScpmSmMasterBatchManager.Get(lcl_str_SqlQuery);
                    if (lcl_obj_ScpmSmMasterBatch == null)
                    {
                        //ScpmSmMasterBatch does not exist. Create New One
                        System.UInt64 lcl_ui64_ScpmSmMasterBatchCode = lcl_obj_ScpmSmMasterBatchManager.Save(IP_obj_ScpmSmMasterBatch);
                        lcl_obj_ScpmSmMasterBatch = lcl_obj_ScpmSmMasterBatchManager.Get(lcl_ui64_ScpmSmMasterBatchCode);
                    }
                }
                lcl_obj_ScpmMasterBatchReader.Close();
                lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_obj_ScpmSmMasterBatch);
                return lcl_obj_WSResponseTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_WSResponse;    
        }

        public SilkERP360.CCL.Misc.WSResponse SaveSMPeelOffQC(SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch IP_obj_SMMasterBatch)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponseTmp = null;
                SilkERP360.BML.SCPM.ScpmSmMasterBatchManager lcl_obj_ScpmSmMasterBatchManager = new BML.SCPM.ScpmSmMasterBatchManager();
                lcl_obj_ScpmSmMasterBatchManager.Save(IP_obj_SMMasterBatch);
                lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, IP_obj_SMMasterBatch);
                return lcl_obj_WSResponseTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_WSResponse;    
        }
    }
}
