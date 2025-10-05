using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class RawMatarialManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>
    {
       public RawMatarialManager()
       { 

       }

       public ulong Save(CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterials, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_BuyerCode = 0;
           System.String lcl_str_Sequence = lcl_obj_RawMaterials.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_BuyerCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               lcl_obj_RawMaterials.RMCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = lcl_obj_RawMaterials.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               lcl_obj_DBManager.CommitTransaction();
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_BuyerCode;
           
       }

       public ulong update(SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterials)
       {
           throw new NotImplementedException();
       }

       public ulong Save(CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterials)
       {
           System.UInt64 lcl_ui64_RawMaterialsCode = 0;
           System.String lcl_str_Sequence = lcl_obj_RawMaterials.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
       
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   lcl_obj_IDReader.Read();
                   System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                   lcl_obj_IDReader.Close();

                   lcl_obj_RawMaterials.ProductUpdateCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = lcl_obj_RawMaterials.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           
           return lcl_ui64_RawMaterialsCode;
       }

       public CCL.BusinessEntities.WPMS.RawMaterials Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterials = null;

           lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_RAW_MATERIAL Where RM_CODE = {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_Reader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RawMaterialsManager.Get(SALES_CONTRACT_CODE,DBManger)) : Error Retrieving RawMaterials Data!");
               }
                    lcl_obj_Reader.Read();
                    SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                    lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.ProductUpdateCode = System.UInt64.Parse(lcl_obj_Reader["PRODUCT_UPDATE_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                    //lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_RawMaterialsTmp.PriceMTon = System.UInt16.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                    lcl_obj_Reader.Close();
                    return lcl_obj_RawMaterialsTmp;
           }, "BMLExceptionPolicy");
                    return lcl_obj_RawMaterials;
       }

       public CCL.BusinessEntities.WPMS.RawMaterials Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterials = null;
           lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>(() =>
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
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RawMaterialsManager.Get(ID)) : No RawMaterials Data Found In The Database!!!");
                   }
                   SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                   lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                        lcl_obj_RawMaterialsTmp.ProductUpdateCode = System.UInt64.Parse(lcl_obj_Reader["PRODUCT_UPDATE_CODE"].ToString());
                        lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                        lcl_obj_RawMaterialsTmp.PriceMTon = System.UInt16.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                        //lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                        lcl_obj_Reader.Close();
                        return lcl_obj_RawMaterialsTmp;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_RawMaterials;
       }

       public CCL.BusinessEntities.WPMS.RawMaterials Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
          SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterials = null;

           lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>(() =>
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
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RawMaterialsManager.Get(SqlQuery,DBManger)) : Error Retrieving RawMaterials Data!");
               }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                lcl_obj_RawMaterialsTmp.ProductUpdateCode = System.UInt64.Parse(lcl_obj_Reader["PRODUCT_UPDATE_CODE"].ToString());
                lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                lcl_obj_RawMaterialsTmp.PriceMTon = System.UInt16.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                //lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                lcl_obj_Reader.Close();
                return lcl_obj_RawMaterialsTmp;
           }, "BMLExceptionPolicy");
                return lcl_obj_RawMaterials;
       }

       public CCL.BusinessEntities.WPMS.RawMaterials Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterials = null;
           lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>(() =>
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
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RawMaterialsManager.Get(SqlQuery)) : No RawMaterials Data Found In The Database!!!");
                   }
                   SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                   lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                        lcl_obj_RawMaterialsTmp.ProductUpdateCode = System.UInt64.Parse(lcl_obj_Reader["PRODUCT_UPDATE_CODE"].ToString());
                        lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                        lcl_obj_RawMaterialsTmp.PriceMTon = System.UInt16.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                        //lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                        lcl_obj_Reader.Close();
                        return lcl_obj_RawMaterialsTmp;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_RawMaterials;
       }

       public List<CCL.BusinessEntities.WPMS.RawMaterials> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_RawMaterials = null;

           lcl_objLst_RawMaterials = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_Reader.HasRows))
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RawMaterialsManager.GetList(SqlQuery,DBManager)) : No RawMaterials Data Found In The Database!!!");
               }
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_RawMaterialsTmp = new
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>();
               while (lcl_obj_Reader.Read())
               {
                   SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                   lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.ProductUpdateCode = System.UInt64.Parse(lcl_obj_Reader["PRODUCT_UPDATE_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                    lcl_obj_RawMaterialsTmp.PriceMTon = System.UInt16.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                    //lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_objLst_RawMaterialsTmp.Add(lcl_obj_RawMaterialsTmp);
               }
               lcl_obj_Reader.Close();
               return lcl_objLst_RawMaterialsTmp;

           }, "BMLExceptionPolicy");
           return lcl_objLst_RawMaterials;
       }

       public List<CCL.BusinessEntities.WPMS.RawMaterials> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_Quotation = null;
        
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                  
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_Items2Tmp = new
                       System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>();
                   while (lcl_obj_Reader.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                       lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                       lcl_obj_RawMaterialsTmp.ProductUpdateCode = System.UInt64.Parse(lcl_obj_Reader["PRODUCT_UPDATE_CODE"].ToString());
                       lcl_obj_RawMaterialsTmp.PriceMTon = System.Decimal.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                       lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                      // lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                       lcl_objLst_Items2Tmp.Add(lcl_obj_RawMaterialsTmp);
                   }
                   lcl_obj_Reader.Close();
                   return lcl_objLst_Items2Tmp;
               }
                     return lcl_objLst_Quotation;
       }


       public List<CCL.BusinessEntities.WPMS.RawMaterials> GetListJoin(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_Quotation = null;

           using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
           {
               if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.InternalResource.Open();
               }

               System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);

               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_Items2Tmp = new
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>();
               while (lcl_obj_Reader.Read())
               {
                   SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                   lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                   lcl_obj_RawMaterialsTmp.lcl_RawProductList.RMName = lcl_obj_Reader["RM_NAME"].ToString();
                   lcl_obj_RawMaterialsTmp.PriceMTon = System.Decimal.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                   lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["to_char(D.MONTH,'dd-Mon-yyyy')"].ToString());
                  // lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                   lcl_objLst_Items2Tmp.Add(lcl_obj_RawMaterialsTmp);
               }
               lcl_obj_Reader.Close();
               return lcl_objLst_Items2Tmp;
           }
           return lcl_objLst_Quotation;
       }

       public List<CCL.BusinessEntities.WPMS.RawMaterials> GetListAllJoin(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_Quotation = null;

           using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
           {
               if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.InternalResource.Open();
               }

               System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);

               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials> lcl_objLst_Items2Tmp = new
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials>();
               while (lcl_obj_Reader.Read())
               {
                   SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials();
                   lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                   lcl_obj_RawMaterialsTmp.lcl_RawProductList.RMName = lcl_obj_Reader["RM_NAME"].ToString();
                   lcl_obj_RawMaterialsTmp.PriceMTon = System.Decimal.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());
                   lcl_obj_RawMaterialsTmp.Month = System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                   //lcl_obj_RawMaterialsTmp.IsActive = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                   lcl_objLst_Items2Tmp.Add(lcl_obj_RawMaterialsTmp);
               }
               lcl_obj_Reader.Close();
               return lcl_objLst_Items2Tmp;
           }
           return lcl_objLst_Quotation;
       }
    }
}
