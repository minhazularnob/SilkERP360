using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class SalesContractManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>
    {
       public SalesContractManager()
       {
           this.Initialize();
       }

       public ulong Save(CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_BuyerCode = 0;
           System.String lcl_str_Sequence = lcl_obj_SalesContract.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_BuyerCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               lcl_obj_SalesContract.BuyerCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = lcl_obj_SalesContract.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               lcl_obj_DBManager.CommitTransaction();
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_BuyerCode;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract)
       {
           System.UInt64 lcl_ui64_SalesContractCode = 0;
         
           using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
           {
               if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.InternalResource.Open();
               }
               System.Data.OracleClient.OracleParameter lcl_obj_SalesContractCode = new System.Data.OracleClient.OracleParameter("v_SALES_CONTRACT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_SalesContractCode.Direction = System.Data.ParameterDirection.Output;
                    //lcl_obj_WrokGroupCode.Value = lcl_obj_WrokGroup.WorkGroupCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_PortOfDelivery = new System.Data.OracleClient.OracleParameter("v_PORT_OF_DELIVERY", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_PortOfDelivery.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PortOfDelivery.Value = lcl_obj_SalesContract.PortOfDelivery;
                    System.Data.OracleClient.OracleParameter lcl_obj_AdvisingBank = new System.Data.OracleClient.OracleParameter("v_ADVISING_BANK", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_AdvisingBank.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_AdvisingBank.Value = lcl_obj_SalesContract.AdvisingBank;
                    System.Data.OracleClient.OracleParameter lcl_obj_LCValidity = new System.Data.OracleClient.OracleParameter("v_LC_VALIDITY", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_LCValidity.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_LCValidity.Value = lcl_obj_SalesContract.LCValidity;
                    System.Data.OracleClient.OracleParameter lcl_obj_TransHipment = new System.Data.OracleClient.OracleParameter("v_TRANSSHIPMENT", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_TransHipment.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_TransHipment.Value = lcl_obj_SalesContract.TransHipment;
                    System.Data.OracleClient.OracleParameter lcl_obj_HSCode = new System.Data.OracleClient.OracleParameter("v_HS_CODE", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_HSCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_HSCode.Value = lcl_obj_SalesContract.HSCode;
                    //SilkERP360.BML.WPMS.QuotationManager lcl_obj_Quotationmanager = new SilkERP360.BML.WPMS.QuotationManager();
                    //SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotationkend = lcl_obj_Quotationmanager.Get(lcl_ui64_QuotationCode, lcl_obj_DBManager);
                    System.Data.OracleClient.OracleParameter lcl_obj_QuotationCode = new System.Data.OracleClient.OracleParameter("v_QUOTATION_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_QuotationCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_QuotationCode.Value = lcl_obj_SalesContract.QuotationCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_BuyerCode = new System.Data.OracleClient.OracleParameter("v_BUYER_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_BuyerCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BuyerCode.Value = lcl_obj_SalesContract.BuyerCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_SalesContractDate = new System.Data.OracleClient.OracleParameter("v_SALES_CONTRACT_DATE", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_SalesContractDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SalesContractDate.Value = lcl_obj_SalesContract.SalesContractDate;
                    System.Data.OracleClient.OracleParameter lcl_obj_Packing = new System.Data.OracleClient.OracleParameter("v_PACKING", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_Packing.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Packing.Value = lcl_obj_SalesContract.Packing;
                    System.Data.OracleClient.OracleParameter lcl_obj_TermsOfPayments = new System.Data.OracleClient.OracleParameter("v_TERMS_OF_PAYMENT", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_TermsOfPayments.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_TermsOfPayments.Value = lcl_obj_SalesContract.TermsOfPayments;
                    System.Data.OracleClient.OracleParameter lcl_obj_Delivery = new System.Data.OracleClient.OracleParameter("v_DELIVERY", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_Delivery.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Delivery.Value = lcl_obj_SalesContract.Delivery;
                    System.Data.OracleClient.OracleParameter lcl_obj_Description = new System.Data.OracleClient.OracleParameter("v_DESCRIPTION", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_Description.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Description.Value = lcl_obj_SalesContract.Description;
                    System.Data.OracleClient.OracleParameter lcl_obj_CountryOrigin = new System.Data.OracleClient.OracleParameter("v_COUNTRY_ORIGIN", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_CountryOrigin.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CountryOrigin.Value = lcl_obj_SalesContract.CountryOrigin;
                    System.Data.OracleClient.OracleParameter lcl_obj_PortofDestination = new System.Data.OracleClient.OracleParameter("v_PORT_OF_DESTINATION", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_PortofDestination.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PortofDestination.Value = lcl_obj_SalesContract.PortofDestination;
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalesContractCode, lcl_obj_PortOfDelivery, lcl_obj_AdvisingBank, lcl_obj_LCValidity, lcl_obj_TransHipment, lcl_obj_HSCode, lcl_obj_QuotationCode, lcl_obj_BuyerCode, lcl_obj_SalesContractDate, lcl_obj_Packing, lcl_obj_TermsOfPayments, lcl_obj_Delivery, lcl_obj_Description, lcl_obj_CountryOrigin, lcl_obj_PortofDestination };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("WPMS_INS_SALES_CONTRACT", lcl_obj_SP_Parameters);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();



                   lcl_ui64_SalesContractCode = System.UInt64.Parse(lcl_obj_SalesContractCode.Value.ToString());
                    SilkERP360.BML.WPMS.SalesContractDetailsManager lcl_obj_SalesContractDetailsManager = new SilkERP360.BML.WPMS.SalesContractDetailsManager();
                    foreach (SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails lcl_obj_SalesContractkend in lcl_obj_SalesContract.SalesContractDetails)
                   {
                       lcl_obj_SalesContractkend.SalesContractCode = lcl_ui64_SalesContractCode;
                       lcl_obj_SalesContractDetailsManager.Save(lcl_obj_SalesContractkend, lcl_obj_DBManager);

                   }
                    lcl_obj_DBManager.InternalResource.Close();
                    return System.UInt64.Parse(lcl_obj_SalesContractCode.Value.ToString());
               }
           }
       
               public CCL.BusinessEntities.WPMS.SalesContract Get(ulong IP_ui64_Code, object IP_obj_DBManager)
               {
                   SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract = null;

                   lcl_obj_SalesContract = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>(() =>
                   {
                       SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                       if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                       {
                           lcl_obj_DBManager.Open();
                       }
                        System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_SALES_CONTRACT Where SALES_CONTRACT_CODE = {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                        System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                       if (lcl_obj_Reader.HasRows == false)
                       {
                           throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error SalesContractManager.Get(SALES_CONTRACT_CODE,DBManger)) : Error Retrieving Sales Contract Data!");
                       }
                        lcl_obj_Reader.Read();
                        SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = new SilkERP360.CCL.BusinessEntities.WPMS.SalesContract();
                        lcl_obj_SalesContractTmp.SalesContractCode = System.UInt64.Parse(lcl_obj_Reader["SALES_CONTRACT_CODE"].ToString());
                        lcl_obj_SalesContractTmp.PortOfDelivery = lcl_obj_Reader["PORT_OF_DELIVERY"].ToString();
                        lcl_obj_SalesContractTmp.AdvisingBank = lcl_obj_Reader["ADVISING_BANK"].ToString();
                        lcl_obj_SalesContractTmp.LCValidity = System.DateTime.Parse(lcl_obj_Reader["LC_VALIDITY"].ToString());
                        lcl_obj_SalesContractTmp.TransHipment = lcl_obj_Reader["TRANSSHIPMENT"].ToString();
                        lcl_obj_SalesContractTmp.HSCode = lcl_obj_Reader["HS_CODE"].ToString();
                        lcl_obj_SalesContractTmp.QuotationCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_CODE"].ToString());
                        lcl_obj_SalesContractTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                        lcl_obj_SalesContractTmp.SalesContractDate = System.DateTime.Parse(lcl_obj_Reader["SALES_CONTRACT_DATE"].ToString());
                        lcl_obj_SalesContractTmp.Packing = lcl_obj_Reader["PACKING"].ToString();
                        lcl_obj_SalesContractTmp.TermsOfPayments = lcl_obj_Reader["TERMS_OF_PAYMENT"].ToString();
                        lcl_obj_SalesContractTmp.Delivery = lcl_obj_Reader["DELIVERY"].ToString();
                        lcl_obj_SalesContractTmp.Description = lcl_obj_Reader["DESCRIPTION"].ToString();
                        lcl_obj_SalesContractTmp.CountryOrigin = lcl_obj_Reader["COUNTRY_ORIGIN"].ToString();
                        lcl_obj_SalesContractTmp.PortofDestination = lcl_obj_Reader["PORT_OF_DESTINATION"].ToString();
                        lcl_obj_Reader.Close();
                        return lcl_obj_SalesContractTmp;
                   }, "BMLExceptionPolicy");
                        return lcl_obj_SalesContract;
               }

               public CCL.BusinessEntities.WPMS.SalesContract Get(ulong IP_ui64_Code)
               {
                    SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract = null;
                    lcl_obj_SalesContract = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>(() =>
                   {
                       using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                       {
                           if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                           {
                               lcl_obj_DBManager.InternalResource.Open();
                           }
                            System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From WPMS_SALES_CONTRACT Where SALES_CONTRACT_CODE = {0}", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                            if (!(lcl_obj_Reader.HasRows))
                           {
                               throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CustomerManager.Get(ID)) : No WorkGroup Data Found In The Database!!!");
                           }
                            SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = new SilkERP360.CCL.BusinessEntities.WPMS.SalesContract();
                            lcl_obj_SalesContractTmp.SalesContractCode = System.UInt64.Parse(lcl_obj_Reader["SALES_CONTRACT_CODE"].ToString());
                            lcl_obj_SalesContractTmp.PortOfDelivery = lcl_obj_Reader["PORT_OF_DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.AdvisingBank = lcl_obj_Reader["ADVISING_BANK"].ToString();
                            lcl_obj_SalesContractTmp.LCValidity = System.DateTime.Parse(lcl_obj_Reader["LC_VALIDITY"].ToString());
                            lcl_obj_SalesContractTmp.TransHipment = lcl_obj_Reader["TRANSSHIPMENT"].ToString();
                            lcl_obj_SalesContractTmp.HSCode = lcl_obj_Reader["HS_CODE"].ToString();
                            lcl_obj_SalesContractTmp.QuotationCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_CODE"].ToString());
                            lcl_obj_SalesContractTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                            lcl_obj_SalesContractTmp.SalesContractDate = System.DateTime.Parse(lcl_obj_Reader["SALES_CONTRACT_DATE"].ToString());
                            lcl_obj_SalesContractTmp.Packing = lcl_obj_Reader["PACKING"].ToString();
                            lcl_obj_SalesContractTmp.TermsOfPayments = lcl_obj_Reader["TERMS_OF_PAYMENT"].ToString();
                            lcl_obj_SalesContractTmp.Delivery = lcl_obj_Reader["DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.Description = lcl_obj_Reader["DESCRIPTION"].ToString();
                            lcl_obj_SalesContractTmp.CountryOrigin = lcl_obj_Reader["COUNTRY_ORIGIN"].ToString();
                            lcl_obj_SalesContractTmp.PortofDestination = lcl_obj_Reader["PORT_OF_DESTINATION"].ToString();
                            lcl_obj_Reader.Close();
                            return lcl_obj_SalesContractTmp;
                       }
                   }, "BMLExceptionPolicy");
                            return lcl_obj_SalesContract;
               }

               public CCL.BusinessEntities.WPMS.SalesContract Get(string IP_str_SqlQuery, object IP_obj_DBManager)
               {
                    SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract = null;

                    lcl_obj_SalesContract = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>(() =>
                    {
                        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                        if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.Open();
                        }
                            System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                            System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                            if (lcl_obj_Reader.HasRows == false)
                            {
                                throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error SalesContractManager.Get(SqlQuery,DBManger)) : Error Retrieving SalesContract Data!");
                            }
                            lcl_obj_Reader.Read();
                            SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = new SilkERP360.CCL.BusinessEntities.WPMS.SalesContract();
                            lcl_obj_SalesContractTmp.SalesContractCode = System.UInt64.Parse(lcl_obj_Reader["SALES_CONTRACT_CODE"].ToString());
                            lcl_obj_SalesContractTmp.PortOfDelivery = lcl_obj_Reader["PORT_OF_DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.AdvisingBank = lcl_obj_Reader["ADVISING_BANK"].ToString();
                            lcl_obj_SalesContractTmp.LCValidity = System.DateTime.Parse(lcl_obj_Reader["LC_VALIDITY"].ToString());
                            lcl_obj_SalesContractTmp.TransHipment = lcl_obj_Reader["TRANSSHIPMENT"].ToString();
                            lcl_obj_SalesContractTmp.HSCode = lcl_obj_Reader["HS_CODE"].ToString();
                            lcl_obj_SalesContractTmp.QuotationCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_CODE"].ToString());
                            lcl_obj_SalesContractTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                            lcl_obj_SalesContractTmp.SalesContractDate = System.DateTime.Parse(lcl_obj_Reader["SALES_CONTRACT_DATE"].ToString());
                            lcl_obj_SalesContractTmp.Packing = lcl_obj_Reader["PACKING"].ToString();
                            lcl_obj_SalesContractTmp.TermsOfPayments = lcl_obj_Reader["TERMS_OF_PAYMENT"].ToString();
                            lcl_obj_SalesContractTmp.Delivery = lcl_obj_Reader["DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.Description = lcl_obj_Reader["DESCRIPTION"].ToString();
                            lcl_obj_SalesContractTmp.CountryOrigin = lcl_obj_Reader["COUNTRY_ORIGIN"].ToString();
                            lcl_obj_SalesContractTmp.PortofDestination = lcl_obj_Reader["PORT_OF_DESTINATION"].ToString();
                            lcl_obj_Reader.Close();
                            return lcl_obj_SalesContractTmp;
                   }, "BMLExceptionPolicy");
                            return lcl_obj_SalesContract;
               }

               public CCL.BusinessEntities.WPMS.SalesContract Get(string IP_str_SqlQuery)
               {
                    SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract = null;
                    lcl_obj_SalesContract = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>(() =>
                    {
                       using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                       {
                           if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                           {
                               lcl_obj_DBManager.InternalResource.Open();
                           }
                            System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                            if (!(lcl_obj_Reader.HasRows))
                           {
                               throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalesContractManager.Get(SqlQuery)) : No Company Data Found In The Database!!!");
                           }
                            SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = new SilkERP360.CCL.BusinessEntities.WPMS.SalesContract();
                            lcl_obj_SalesContractTmp.SalesContractCode = System.UInt64.Parse(lcl_obj_Reader["SALES_CONTRACT_CODE"].ToString());
                            lcl_obj_SalesContractTmp.PortOfDelivery = lcl_obj_Reader["PORT_OF_DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.AdvisingBank = lcl_obj_Reader["ADVISING_BANK"].ToString();
                            lcl_obj_SalesContractTmp.LCValidity = System.DateTime.Parse(lcl_obj_Reader["LC_VALIDITY"].ToString());
                            lcl_obj_SalesContractTmp.TransHipment = lcl_obj_Reader["TRANSSHIPMENT"].ToString();
                            lcl_obj_SalesContractTmp.HSCode = lcl_obj_Reader["HS_CODE"].ToString();
                            lcl_obj_SalesContractTmp.QuotationCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_CODE"].ToString());
                            lcl_obj_SalesContractTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                            lcl_obj_SalesContractTmp.SalesContractDate = System.DateTime.Parse(lcl_obj_Reader["SALES_CONTRACT_DATE"].ToString());
                            lcl_obj_SalesContractTmp.Packing = lcl_obj_Reader["PACKING"].ToString();
                            lcl_obj_SalesContractTmp.TermsOfPayments = lcl_obj_Reader["TERMS_OF_PAYMENT"].ToString();
                            lcl_obj_SalesContractTmp.Delivery = lcl_obj_Reader["DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.Description = lcl_obj_Reader["DESCRIPTION"].ToString();
                            lcl_obj_SalesContractTmp.CountryOrigin = lcl_obj_Reader["COUNTRY_ORIGIN"].ToString();
                            lcl_obj_SalesContractTmp.PortofDestination = lcl_obj_Reader["PORT_OF_DESTINATION"].ToString();
                            lcl_obj_Reader.Close();
                            return lcl_obj_SalesContractTmp;
                        }
                   }, " BMLExceptionPolicy");
                            return lcl_obj_SalesContract;
               }

               public List<CCL.BusinessEntities.WPMS.SalesContract> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
               {
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract> lcl_objLst_SalesContract = null;
                    lcl_objLst_SalesContract = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>>(() =>
                   {
                        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                        if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                       {
                           lcl_obj_DBManager.Open();
                       }
                        System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                        if (!(lcl_obj_Reader.HasRows))
                       {
                           throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error SalesContractManager.GetList(SqlQuery,DBManager)) : No Company Data Found In The Database!!!");
                       }
                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract> lcl_objLst_SalesContractTmp = new
                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>();
                        while (lcl_obj_Reader.Read())
                       {
                            SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = new SilkERP360.CCL.BusinessEntities.WPMS.SalesContract();
                            lcl_obj_SalesContractTmp.SalesContractCode = System.UInt64.Parse(lcl_obj_Reader["SALES_CONTRACT_CODE"].ToString());
                            lcl_obj_SalesContractTmp.PortOfDelivery = lcl_obj_Reader["PORT_OF_DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.AdvisingBank = lcl_obj_Reader["ADVISING_BANK"].ToString();
                            lcl_obj_SalesContractTmp.LCValidity = System.DateTime.Parse(lcl_obj_Reader["LC_VALIDITY"].ToString());
                            lcl_obj_SalesContractTmp.TransHipment = lcl_obj_Reader["TRANSSHIPMENT"].ToString();
                            lcl_obj_SalesContractTmp.HSCode = lcl_obj_Reader["HS_CODE"].ToString();
                            lcl_obj_SalesContractTmp.QuotationCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_CODE"].ToString());
                            lcl_obj_SalesContractTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                            lcl_obj_SalesContractTmp.SalesContractDate = System.DateTime.Parse(lcl_obj_Reader["SALES_CONTRACT_DATE"].ToString());
                            lcl_obj_SalesContractTmp.Packing = lcl_obj_Reader["PACKING"].ToString();
                            lcl_obj_SalesContractTmp.TermsOfPayments = lcl_obj_Reader["TERMS_OF_PAYMENT"].ToString();
                            lcl_obj_SalesContractTmp.Delivery = lcl_obj_Reader["DELIVERY"].ToString();
                            lcl_obj_SalesContractTmp.Description = lcl_obj_Reader["DESCRIPTION"].ToString();
                            lcl_obj_SalesContractTmp.CountryOrigin = lcl_obj_Reader["COUNTRY_ORIGIN"].ToString();
                            lcl_obj_SalesContractTmp.PortofDestination = lcl_obj_Reader["PORT_OF_DESTINATION"].ToString();


                            lcl_objLst_SalesContractTmp.Add(lcl_obj_SalesContractTmp);
                        }
                            lcl_obj_Reader.Close();
                            return lcl_objLst_SalesContractTmp;
                     }, "BMLExceptionPolicy");
                            return lcl_objLst_SalesContract;
               }

               public List<CCL.BusinessEntities.WPMS.SalesContract> GetList(string IP_str_SqlQuery)
               {
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract> lcl_objLst_SalesContract = null;
                   lcl_objLst_SalesContract = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>>(() =>
                   {
                        using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                        {
                            if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                               {
                                   lcl_obj_DBManager.InternalResource.Open();
                               }
                                System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                                if (!(lcl_obj_Reader.HasRows))
                                {
                                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalesContractManager.GetList(SqlQuery)) : No SalesContract Data Found In The Database!!!");
                                }
                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract> lcl_objLst_SalesContractTmp = new
                                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>();
                                while (lcl_obj_Reader.Read())
                                {
                                    SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = new SilkERP360.CCL.BusinessEntities.WPMS.SalesContract();
                                    lcl_obj_SalesContractTmp.SalesContractCode = System.UInt64.Parse(lcl_obj_Reader["SALES_CONTRACT_CODE"].ToString());
                                    lcl_obj_SalesContractTmp.PortOfDelivery = lcl_obj_Reader["PORT_OF_DELIVERY"].ToString();
                                    lcl_obj_SalesContractTmp.AdvisingBank = lcl_obj_Reader["ADVISING_BANK"].ToString();
                                    lcl_obj_SalesContractTmp.LCValidity = System.DateTime.Parse(lcl_obj_Reader["LC_VALIDITY"].ToString());
                                    lcl_obj_SalesContractTmp.TransHipment = lcl_obj_Reader["TRANSSHIPMENT"].ToString();
                                    lcl_obj_SalesContractTmp.HSCode = lcl_obj_Reader["HS_CODE"].ToString();
                                    lcl_obj_SalesContractTmp.QuotationCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_CODE"].ToString());
                                    lcl_obj_SalesContractTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                                    lcl_obj_SalesContractTmp.SalesContractDate = System.DateTime.Parse(lcl_obj_Reader["SALES_CONTRACT_DATE"].ToString());
                                    lcl_obj_SalesContractTmp.Packing = lcl_obj_Reader["PACKING"].ToString();
                                    lcl_obj_SalesContractTmp.TermsOfPayments = lcl_obj_Reader["TERMS_OF_PAYMENT"].ToString();
                                    lcl_obj_SalesContractTmp.Delivery = lcl_obj_Reader["DELIVERY"].ToString();
                                    lcl_obj_SalesContractTmp.Description = lcl_obj_Reader["DESCRIPTION"].ToString();
                                    lcl_obj_SalesContractTmp.CountryOrigin = lcl_obj_Reader["COUNTRY_ORIGIN"].ToString();
                                    lcl_obj_SalesContractTmp.PortofDestination = lcl_obj_Reader["PORT_OF_DESTINATION"].ToString();
                                    lcl_objLst_SalesContractTmp.Add(lcl_obj_SalesContractTmp);
                                }
                                    lcl_obj_Reader.Close();
                                    return lcl_objLst_SalesContractTmp;
                        }
                    }, "BMLExceptionPolicy");
                                    return lcl_objLst_SalesContract;
           }
    }
}
