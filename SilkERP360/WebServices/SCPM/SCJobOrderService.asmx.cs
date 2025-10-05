using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for SCJobOrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SCJobOrderService : System.Web.Services.WebService
    {
        /// <summary>
        /// Get list of those JobOrders whose ProductType matches with the ProductType
        /// that the Section Produces
        /// </summary>
        /// <param name="IP_ui64_SectionCode"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetSCPMJobOrdersBySection(System.UInt64 IP_ui64_SectionCode)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                //Step-1
                //Get the Product_Type that IP_ui64_SectionCode Produces
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SECTION where SECTION_CODE = {0}", IP_ui64_SectionCode.ToString());
                System.Data.OracleClient.OracleDataReader lcl_obj_SectionReaderReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_SectionReaderReader.HasRows))
                {
                    //error
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + "No Product Type For The Selected Section!!!", false, null);
                }
                lcl_obj_SectionReaderReader.Read();
                SilkERP360.CCL.Enums.SCPM.ProductType lcl_enm_ProductType = (SilkERP360.CCL.Enums.SCPM.ProductType)System.Int32.Parse(lcl_obj_SectionReaderReader["PRODUCT_TYPE"].ToString());
                lcl_obj_SectionReaderReader.Close();
                //Step-2
                //Get the JobOrders of the Product_Type
                lcl_str_SqlQuery = System.String.Format("Select * From SCPM_JOB_ORDER where PRODUCT_TYPE = {0}", (System.Int16)lcl_enm_ProductType);


                //lcl_str_SqlQuery = System.String.Format("Select Start_Production From SCPM_SC_BATCH Where SC_BATCH_CODE = {0}", (System.Int32)lcl_enm_ProductType);
                //SilkERP360.FL.SCPM.SCPMJobOrderFacade lcl_obj_JobOrderFacade = new FL.SCPM.SCPMJobOrderFacade();
                //System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMJobOrder> lcl_objList_JobOrder = lcl_obj_JobOrderFacade.GetList(lcl_str_SqlQuery);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, null);//lcl_objList_JobOrder);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }


        /// <summary>
        /// checks if the provided batch has been cleared for production
        /// returns true or false in WSResponse.BResponse
        /// </summary>
        /// <param name="IP_ui64_ScBatchCode"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckIfBatchClearedForProduction(System.UInt64 IP_ui64_ScBatchCode)
        {
            try
            {

                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();

                System.String lcl_str_SqlQuery = System.String.Format("Select Start_Production From SCPM_SC_BATCH Where SC_BATCH_CODE = {0}", IP_ui64_ScBatchCode);
                System.Data.OracleClient.OracleDataReader lcl_obj_BatchReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_BatchReader.HasRows))
                {
                    //error
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + "Selected Batch Data Not Found!!!", false, null);
                }
                lcl_obj_BatchReader.Read();
                System.Int32 lcl_i32_StartProduction = System.Int32.Parse(lcl_obj_BatchReader["Start_Production"].ToString());
                if (lcl_i32_StartProduction == (System.Int32)SilkERP360.CCL.Enums.YesNo.Yes)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetScBatchByJobOrder(System.UInt64 IP_ui64_ScJobOrderCode)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();

                System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_BATCH Where SC_J_O_CODE = {0} AND PRODUCTION_STATUS = {1} And Status = 1", IP_ui64_ScJobOrderCode, (System.Int32)SilkERP360.CCL.SCPMEnumerations.JobOrderProductionStatus.NotCompleted);
                System.Data.OracleClient.OracleDataReader lcl_obj_ScBatchReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);

                if (!(lcl_obj_ScBatchReader.HasRows))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, "No Batch Was Found For The Selected Job Order!!!", false, null);
                }

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch> lcl_objLstBatches = new List<CCL.BusinessEntities.SCPM.ScBatch>();
                while (lcl_obj_ScBatchReader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.ScBatch lcl_obj_ScBatch = new CCL.BusinessEntities.SCPM.ScBatch();
                    lcl_obj_ScBatch.BatchCode = System.UInt64.Parse(lcl_obj_ScBatchReader["SC_BATCH_CODE"].ToString());
                    lcl_obj_ScBatch.ScBatchName = lcl_obj_ScBatchReader["SC_BATCH"].ToString();
                    lcl_obj_ScBatch.ScJOCode = System.UInt64.Parse(lcl_obj_ScBatchReader["SC_J_O_CODE"].ToString());
                    lcl_obj_ScBatch.Quantity = System.UInt64.Parse(lcl_obj_ScBatchReader["QUANTITY"].ToString());
                    lcl_obj_ScBatch.StartSl = System.UInt64.Parse(lcl_obj_ScBatchReader["START_SL"].ToString());
                    lcl_obj_ScBatch.EndSl = System.UInt64.Parse(lcl_obj_ScBatchReader["END_SL"].ToString());
                    lcl_obj_ScBatch.ProductionStatus = (SilkERP360.CCL.SCPMEnumerations.JobOrderProductionStatus)System.Int32.Parse(lcl_obj_ScBatchReader["PRODUCTION_STATUS"].ToString());
                    lcl_obj_ScBatch.Status = (SilkERP360.CCL.SCPMEnumerations.Status)System.Int32.Parse(lcl_obj_ScBatchReader["STATUS"].ToString());

                    lcl_objLstBatches.Add(lcl_obj_ScBatch);
                }

                lcl_obj_SqlFacade.CloseReader();
                lcl_obj_SqlFacade.Close();

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLstBatches);
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
