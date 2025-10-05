using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmScPersoISOManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO>
    {
       public ScpmScPersoISOManager()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPersoISO IP_obj_ScPersoISO, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ScPersoISOCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_PERSO_ISO.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_ScPersoISOCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScPersoISO.ScPersoCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScPersoISO.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScPersoISOCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPersoISO IP_obj_ScPersoISO)
       {
           System.UInt64 lcl_ui64_ScPersoISOCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_PERSO_ISO.NEXTVAL AS ID FROM DUAL", IP_obj_ScPersoISO.GetSequence());
           lcl_ui64_ScPersoISOCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
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

                   IP_obj_ScPersoISO.ScPersoCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_ScPersoISO.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScPersoISOCode;
       }

       public CCL.BusinessEntities.SCPM.ScpmScPersoISO Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISO = null;
           lcl_obj_ScPersoISO = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScPersoISO>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_PERSO_ISO WHERE SC_PERSO_ISO_CODE = {0}", IP_ui64_Code);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_TmpScPersoISO = new CCL.BusinessEntities.SCPM.ScpmScPersoISO();
               lcl_obj_TmpScPersoISO.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
               lcl_obj_TmpScPersoISO.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
               lcl_obj_TmpScPersoISO.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScPersoISO.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
               lcl_obj_TmpScPersoISO.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
               lcl_obj_TmpScPersoISO.IsCardsPackaged = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CARDS_PACKAGED"].ToString());
               lcl_obj_TmpScPersoISO.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               
               lcl_obj_dr.Close();
               return lcl_obj_TmpScPersoISO;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScPersoISO;
       }

       public CCL.BusinessEntities.SCPM.ScpmScPersoISO Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISO = null;
           lcl_obj_ScPersoISO = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScPersoISO>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_PERSO_ISO WHERE SC_PERSO_ISO_CODE = {0}", IP_ui64_Code);
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_TmpScPersoISO = new CCL.BusinessEntities.SCPM.ScpmScPersoISO();
                   lcl_obj_TmpScPersoISO.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScPersoISO.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.IsCardsPackaged = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CARDS_PACKAGED"].ToString());
                   lcl_obj_TmpScPersoISO.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScPersoISO;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScPersoISO;
       }

       public CCL.BusinessEntities.SCPM.ScpmScPersoISO Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISO = null;
           lcl_obj_ScPersoISO = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_TmpScPersoISO = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO();
               lcl_obj_TmpScPersoISO.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
               lcl_obj_TmpScPersoISO.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
               lcl_obj_TmpScPersoISO.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
               lcl_obj_TmpScPersoISO.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
               lcl_obj_TmpScPersoISO.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScPersoISO.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
               lcl_obj_TmpScPersoISO.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
               lcl_obj_TmpScPersoISO.IsCardsPackaged = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CARDS_PACKAGED"].ToString());
               lcl_obj_TmpScPersoISO.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               lcl_obj_dr.Close();

               return lcl_obj_TmpScPersoISO;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScPersoISO;
       }

       public CCL.BusinessEntities.SCPM.ScpmScPersoISO Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_ScPersoISO = null;
           lcl_obj_ScPersoISO = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_TmpScPersoISO = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPersoISO();
                   lcl_obj_TmpScPersoISO.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScPersoISO.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.IsCardsPackaged = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CARDS_PACKAGED"].ToString());
                   lcl_obj_TmpScPersoISO.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScPersoISO;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScPersoISO;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScPersoISO> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO> lcl_objlist_ScPersoISOList = null;
           lcl_objlist_ScPersoISOList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO> lcl_objlist_TmpScPersoISOList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO>();
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpScPersoISOList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_TmpScPersoISO = new CCL.BusinessEntities.SCPM.ScpmScPersoISO();
                   lcl_obj_TmpScPersoISO.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                   lcl_obj_TmpScPersoISO.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScPersoISO.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                   lcl_obj_TmpScPersoISO.IsCardsPackaged = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CARDS_PACKAGED"].ToString());
                   lcl_obj_TmpScPersoISO.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_objlist_TmpScPersoISOList.Add(lcl_obj_TmpScPersoISO);
               }
               lcl_obj_dr.Close();


               return lcl_objlist_TmpScPersoISOList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScPersoISOList;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScPersoISO> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO> lcl_objlist_ScPersoISOList = null;
           lcl_objlist_ScPersoISOList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO> lcl_objlist_TmpScPersoISOList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPersoISO>();
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpScPersoISOList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.SCPM.ScpmScPersoISO lcl_obj_TmpScPersoISO = new CCL.BusinessEntities.SCPM.ScpmScPersoISO();
                       lcl_obj_TmpScPersoISO.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                       lcl_obj_TmpScPersoISO.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                       lcl_obj_TmpScPersoISO.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                       lcl_obj_TmpScPersoISO.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                       lcl_obj_TmpScPersoISO.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                       lcl_obj_TmpScPersoISO.IsCardsPackaged = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CARDS_PACKAGED"].ToString());
                       lcl_obj_TmpScPersoISO.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                       lcl_objlist_TmpScPersoISOList.Add(lcl_obj_TmpScPersoISO);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScPersoISOList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScPersoISOList;
       }
    }
}
