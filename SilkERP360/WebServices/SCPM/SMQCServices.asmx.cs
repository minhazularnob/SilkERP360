using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for SMQCServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SMQCServices : System.Web.Services.WebService
    {

        #region SCPM_UTILITIES

        /// <summary>
        /// The MasterBatch is generated on the client and client sends the MasterBatch to server for checking.
        /// Upon receiving the SMMasterBatch, following actions are performed:
        /// IF IP_str_SMMasterBatch EXISTS IN DB
        ///     THEN
        ///             1. GET ScpmSmMasterBatch instance
        ///             2. GENERATE NEXT SubBatch
        ///             3. Return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, lcl_str_SubBatch, true, ScpmSmMasterBatch);
        ///     ELSE
        ///             1. SAVE ScpmSMMasterBatch with IP_str_MasterBatch
        ///             2. GENERATE NEXT SubBatch
        ///             3. Return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, lcl_str_SubBatch, false, ScpmSmMasterBatch);
        ///     END
        /// 
        /// new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, lcl_str_SubBatch, false, SMMasterBatch);
        /// </summary>
        /// <param name="IP_str_SMMasterBatch"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse SMPeelOffQCMasterBatchSetup(SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch IP_obj_ScpmSmMasterBatch)
        {
            try
            {
                CCL.Misc.WSResponse lcl_obj_WSResponse = null;

                SilkERP360.FL.SCPMServices.SimServices lcl_obj_SIMService = new FL.SCPMServices.SimServices();
                lcl_obj_WSResponse = lcl_obj_SIMService.SMPeelOffQCMasterBatchSetup(IP_obj_ScpmSmMasterBatch);
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }
        #endregion

        #region SM_QC_SAVE_SERVICES
        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse SaveSMPeelOffQC(SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch IP_obj_SMMasterBatch)
        {
            try
            {
                CCL.Misc.WSResponse lcl_obj_WSResponse = null;

                SilkERP360.FL.SCPMServices.SimServices lcl_obj_SIMService = new FL.SCPMServices.SimServices();
                lcl_obj_WSResponse = lcl_obj_SIMService.SaveSMPeelOffQC(IP_obj_SMMasterBatch);
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }

        #endregion

        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse EvaluateSMPeelOffTest(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> IP_objList_SMPeelOffTests)
        {
            try
            {
                CCL.Misc.WSResponse lcl_obj_WSResponse = null;
                
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> lcl_objList_ScpmSMPeelOffQC = new List<CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>();
                foreach (SilkERP360.CCL.BusinessEntities.SCPM.Base.ScpmSMQCBase lcl_obj_SMQCBase in IP_objList_SMPeelOffTests)
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_ScpmSMPeelOffQC = (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC)lcl_obj_SMQCBase;
                    if ((lcl_obj_ScpmSMPeelOffQC.PeelOffPercentage >= SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC.S_VALUE_RANGE_FROM) &&
                        (lcl_obj_ScpmSMPeelOffQC.PeelOffPercentage <= SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC.S_VALUE_RANGE_TO))
                    {
                        lcl_obj_ScpmSMPeelOffQC.Status = CCL.Enums.SCPM.QCTestResult.Passed;
                    }
                    else
                    {
                        lcl_obj_ScpmSMPeelOffQC.Status = CCL.Enums.SCPM.QCTestResult.Failed;
                    }
                    lcl_objList_ScpmSMPeelOffQC.Add(lcl_obj_ScpmSMPeelOffQC);
                            
                }
                lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_objList_ScpmSMPeelOffQC);
                       
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse GetRandomSequences(SilkERP360.CCL.Utils.SMQCRandomGenerator IP_obj_SMQCRandomGenerator)
        {
            try
            {
                IP_obj_SMQCRandomGenerator.GenerateRandomSequence();
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, IP_obj_SMQCRandomGenerator);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
