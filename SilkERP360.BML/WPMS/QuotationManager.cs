using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class QuotationManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>
    {
       public QuotationManager()
       {
           this.Initialize();
       }

       public ulong Save(CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_QuotationMCode = 0;
           System.String lcl_str_Sequence = lcl_obj_Quotation.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_QuotationMCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               lcl_obj_Quotation.QuotationMCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = lcl_obj_Quotation.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               lcl_obj_DBManager.CommitTransaction();
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_QuotationMCode;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation)
       {
            System.UInt64 lcl_ui64_QuotationMCode = 0;
           System.String lcl_str_Sequence = lcl_obj_Quotation.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_QuotationMCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   lcl_obj_IDReader.Read();
                   System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                   lcl_obj_IDReader.Close();

                   lcl_obj_Quotation.QuotationMCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = lcl_obj_Quotation.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();


                   lcl_obj_DBManager.InternalResource.CommitTransaction();



                   
                   SilkERP360.BML.WPMS.QuotationDetailsManager lcl_obj_QuotationDetailsManager = new SilkERP360.BML.WPMS.QuotationDetailsManager();
                   foreach (SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails lcl_obj_Quotationkend in lcl_obj_Quotation.QuotationDetails)
                   {

                       lcl_obj_QuotationDetailsManager.Save(lcl_obj_Quotationkend, lcl_obj_DBManager);

                   }
  lcl_obj_DBManager.InternalResource.Close();

                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_QuotationMCode;
           
              
                
               }
     
       public CCL.BusinessEntities.WPMS.Quotation Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation = null;

           lcl_obj_Quotation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_Quotation where quotation_code = {0} and status = {1}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_Reader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error QuotationManager.Get(QUOTATION_CODE,DBManger)) : Error Retrieving Data!");
               }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Quotation();
                lcl_obj_QuotationTmp.QuotationMCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_M_CODE"].ToString());
                lcl_obj_QuotationTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                lcl_obj_QuotationTmp.QuotationDate = System.DateTime.Parse(lcl_obj_Reader["QUOTATION_DATE"].ToString());
                //lcl_obj_QuotationTmp.IsActive = System.Enums.Parse(lcl_obj_Reader["IS_ACTIVE"].ToString());
                lcl_obj_QuotationTmp.CustomerReq = lcl_obj_Reader["CUSTOMER_REQ"].ToString();

                lcl_obj_Reader.Close();
                return lcl_obj_QuotationTmp;
           }, "BMLExceptionPolicy");
                return lcl_obj_Quotation;
       }

       public CCL.BusinessEntities.WPMS.Quotation Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation = null;
          
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From WPMS_QUOTATION Where QUOTATION_CODE = {0}", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                   if (!(lcl_obj_Reader.HasRows))
                   {
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (QuotationManager.Get(ID)) : No Quotation Data Found In The Database!!!");
                   }

                   lcl_obj_Reader.Read();
                    SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Quotation();
                    lcl_obj_QuotationTmp.QuotationMCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_M_CODE"].ToString());
                    lcl_obj_QuotationTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                    lcl_obj_QuotationTmp.QuotationDate = System.DateTime.Parse(lcl_obj_Reader["QUOTATION_DATE"].ToString());
                    //lcl_obj_QuotationTmp.IsAactive = System.UInt16.Parse(lcl_obj_Reader["IS_ACTIVE"].ToString());
                    lcl_obj_QuotationTmp.CustomerReq = lcl_obj_Reader["CUSTOMER_REQ"].ToString();

                    lcl_obj_Reader.Close();
                    return lcl_obj_QuotationTmp;
               }
         
                    return lcl_obj_Quotation;
       }

       public CCL.BusinessEntities.WPMS.Quotation Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation = null;

           lcl_obj_Quotation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_Reader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error QuotationManager.Get(SqlQuery,DBManger)) : Error Retrieving Data!");
               }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Quotation();
                lcl_obj_QuotationTmp.QuotationMCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_M_CODE"].ToString());
                lcl_obj_QuotationTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                lcl_obj_QuotationTmp.QuotationDate = System.DateTime.Parse(lcl_obj_Reader["QUOTATION_DATE"].ToString());
                //lcl_obj_QuotationTmp.IsAactive = System.UInt16.Parse(lcl_obj_Reader["IS_ACTIVE"].ToString());
                lcl_obj_QuotationTmp.CustomerReq = lcl_obj_Reader["CUSTOMER_REQ"].ToString();

               lcl_obj_Reader.Close();
                return lcl_obj_QuotationTmp;
           }, "BMLExceptionPolicy");
                return lcl_obj_Quotation;
       }

       public CCL.BusinessEntities.WPMS.Quotation Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_Quotation = null;
           lcl_obj_Quotation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   lcl_obj_Reader.Read();
                  
                    SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Quotation();
                    lcl_obj_QuotationTmp.QuotationMCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_M_CODE"].ToString());
                    lcl_obj_QuotationTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                    lcl_obj_QuotationTmp.QuotationDate = System.DateTime.Parse(lcl_obj_Reader["QUOTATION_DATE"].ToString());
                    //lcl_obj_QuotationTmp.IsAactive = System.UInt16.Parse(lcl_obj_Reader["IS_ACTIVE"].ToString());
                    lcl_obj_QuotationTmp.CustomerReq = lcl_obj_Reader["CUSTOMER_REQ"].ToString();

                    lcl_obj_Reader.Close();
                    return lcl_obj_QuotationTmp;
               }
           }, "BMLExceptionPolicy");
                    return lcl_obj_Quotation;
       }

       public List<CCL.BusinessEntities.WPMS.Quotation> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_objLst_Quotation = null;

           lcl_objLst_Quotation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_Reader.HasRows))
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error QuotationManager.GetList(SqlQuery,DBManager)) : No Data Found In The Database!!!");
               }
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_objLst_Items2Tmp = new
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>();
               while (lcl_obj_Reader.Read())
               {
                    SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Quotation();
                    lcl_obj_QuotationTmp.QuotationMCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_M_CODE"].ToString());
                    lcl_obj_QuotationTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                    lcl_obj_QuotationTmp.QuotationDate = System.DateTime.Parse(lcl_obj_Reader["QUOTATION_DATE"].ToString());
                    //lcl_obj_QuotationTmp.IsAactive = System.UInt16.Parse(lcl_obj_Reader["IS_ACTIVE"].ToString());
                    lcl_obj_QuotationTmp.CustomerReq = lcl_obj_Reader["CUSTOMER_REQ"].ToString();

                    lcl_objLst_Items2Tmp.Add(lcl_obj_QuotationTmp);
               }
                    lcl_obj_Reader.Close();
                    return lcl_objLst_Items2Tmp;

           }, "BMLExceptionPolicy");
                    return lcl_objLst_Quotation;
       }

       public List<CCL.BusinessEntities.WPMS.Quotation> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_objLst_Quotation = null;
                   lcl_objLst_Quotation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>>(() =>
                   {
                       using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                       {
                           if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                           {
                               lcl_obj_DBManager.InternalResource.Open();
                           }

                           Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                           if (!(lcl_obj_Reader.HasRows))
                           {
                               throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (QuotationManager.GetList(SqlQuery)) : No Data Found In The Database!!!");
                           }
                           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_objLst_Items2Tmp = new
                               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation>();
                           while (lcl_obj_Reader.Read())
                           {
                                SilkERP360.CCL.BusinessEntities.WPMS.Quotation lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Quotation();
                                lcl_obj_QuotationTmp.QuotationMCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_M_CODE"].ToString());
                                lcl_obj_QuotationTmp.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                                lcl_obj_QuotationTmp.QuotationDate = System.DateTime.Parse(lcl_obj_Reader["QUOTATION_DATE"].ToString());
                                //lcl_obj_QuotationTmp.IsAactive = System.UInt16.Parse(lcl_obj_Reader["IS_ACTIVE"].ToString());
                                lcl_obj_QuotationTmp.CustomerReq = lcl_obj_Reader["CUSTOMER_REQ"].ToString();

                                lcl_objLst_Items2Tmp.Add(lcl_obj_QuotationTmp);
                           }
                                lcl_obj_Reader.Close();
                                return lcl_objLst_Items2Tmp;
                       }
                   }, "BMLExceptionPolicy");
                   return lcl_objLst_Quotation;
               }
       }
    }