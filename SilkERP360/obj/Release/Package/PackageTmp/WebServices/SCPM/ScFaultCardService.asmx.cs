using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for ScFaultCardService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ScFaultCardService : System.Web.Services.WebService
    {

        /// <summary>
        ///If CardSL valid returns true in WSResponse.BResponse else false
        /// </summary>
        /// <param name="IP_ui64_CardSL"></param>
        /// <returns>True if CardSL exists in database. True is returned in WSResponse.BResponse field</returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CheckSCSerialValidity(System.UInt64 IP_ui64_BatchCode,System.UInt64 IP_ui64_CardSL)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                //check if CardSL is within startsl and end_sl of the batch
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_BATCH Where SC_BATCH_CODE = {0}",IP_ui64_BatchCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_BatchReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_BatchReader.HasRows))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Error : Failed To Retrieved Batch Details!!!", false, null);
                }

                lcl_obj_BatchReader.Read();
                System.UInt64 lcl_ui64_StartSL = System.UInt64.Parse(lcl_obj_BatchReader["START_SL"].ToString());
                System.UInt64 lcl_ui64_EndSL = System.UInt64.Parse(lcl_obj_BatchReader["END_SL"].ToString());

                if ((!(IP_ui64_CardSL >= lcl_ui64_StartSL) && (IP_ui64_CardSL <= lcl_ui64_EndSL)))
                {
                    //card serial is not within batch data range
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Card : " + IP_ui64_CardSL.ToString() + " is not Within the Data Range Of The Batch!!!", false, null);
                }
                lcl_obj_SqlFacade.CloseReader();
                lcl_str_SqlQuery = System.String.Format("Select COUNT(*) From SCPM_SC_FAULTY_PERSO_CARD Where Card_Sl = {0}",IP_ui64_CardSL);
                System.Object lcl_obj_Count = lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlQuery);
                lcl_obj_SqlFacade.Close();
                if(System.UInt32.Parse(lcl_obj_Count.ToString()) > 0)
                {
                    //card already been reported
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success,0,"Card : " + IP_ui64_CardSL.ToString() + " has already been reported as faulty!!!",false,null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success,0,"",true,null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetSCPersoFaultyCards(System.UInt64 IP_ui64_MachineCode, System.UInt64 IP_ui64_JobOrderCode, System.UInt64 IP_ui64_BatchCode)
        {
            try
            {
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                lcl_obj_SqlFacade.Initialize();
                System.String lcl_str_Query = System.String.Format("Select * From SCPM_SC_FAULTY_PERSO_CARD Where Machine_Code = {0} And SC_Batch_Code = {1} And Re_Persoed = {2}", IP_ui64_MachineCode, IP_ui64_BatchCode, (System.Int32)SilkERP360.CCL.Enums.YesNo.No);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FaultCardReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_Query);

                if (!(lcl_obj_FaultCardReader.HasRows))
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, "No Faulty Card Found For Selected Job Order!!!", false, null);
                }

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard> lcl_objLstFaultCards = new List<CCL.BusinessEntities.SCPM.ScPersoFaultCard>();
                while (lcl_obj_FaultCardReader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard lcl_obj_ScPersoFaultCard = new CCL.BusinessEntities.SCPM.ScPersoFaultCard();
                    lcl_obj_ScPersoFaultCard.FaultyCardCode = System.UInt64.Parse(lcl_obj_FaultCardReader["FAULTY_CARD_CODE"].ToString());
                    lcl_obj_ScPersoFaultCard.BatchCode = System.UInt64.Parse(lcl_obj_FaultCardReader["SC_BATCH_CODE"].ToString());
                    lcl_obj_ScPersoFaultCard.MachineCode = System.UInt64.Parse(lcl_obj_FaultCardReader["MACHINE_CODE"].ToString());
                    lcl_obj_ScPersoFaultCard.FaultType = System.UInt64.Parse(lcl_obj_FaultCardReader["FAULT_TYPE"].ToString());
                    lcl_obj_ScPersoFaultCard.FaultTypeStr = ((SilkERP360.CCL.SCPMEnumerations.ScratchCardFaultType)lcl_obj_ScPersoFaultCard.FaultType).ToString();
                    lcl_obj_ScPersoFaultCard.CardSl = System.UInt64.Parse(lcl_obj_FaultCardReader["CARD_SL"].ToString());
                    lcl_obj_ScPersoFaultCard.Remarks = lcl_obj_FaultCardReader["REMARKS"].ToString();
                    lcl_objLstFaultCards.Add(lcl_obj_ScPersoFaultCard);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLstFaultCards);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveScPersoFaultCards(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard> IP_lstObj_ScFaultyPersoCard)
        {
            try
            {
                SilkERP360.FL.SCPM.SCPersoFaultCardFacade lcl_obj_FaultyCardFacade = new FL.SCPM.SCPersoFaultCardFacade();
                lcl_obj_FaultyCardFacade.SaveSCFaultPersoCardList(IP_lstObj_ScFaultyPersoCard);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
