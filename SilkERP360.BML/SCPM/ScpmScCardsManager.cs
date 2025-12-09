using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmScCardsManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards>
    {
        public ScpmScCardsManager()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScCards IP_obj_ScCards, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ScCardsCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_CARDS.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_ScCardsCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_ScCards.ScCardCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_ScCards.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScCardsCode;
        }

        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScCards IP_obj_ScCards)
        {
            System.UInt64 lcl_ui64_ScCardsCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_CARDS.NEXTVAL AS ID FROM DUAL", IP_obj_ScCards.GetSequence());
            lcl_ui64_ScCardsCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_ScCards.ScCardCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_ScCards.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScCardsCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScCards Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCards = null;
            lcl_obj_ScCards = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScCards>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_CARDS WHERE SC_CARD_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_TmpScCards = new CCL.BusinessEntities.SCPM.ScpmScCards();
                lcl_obj_TmpScCards.ScCardCode = System.UInt64.Parse(lcl_obj_dr["SC_CARD_CODE"].ToString());
                lcl_obj_TmpScCards.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                lcl_obj_TmpScCards.Denomination = System.UInt64.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                lcl_obj_TmpScCards.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                lcl_obj_TmpScCards.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                lcl_obj_TmpScCards.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                lcl_obj_TmpScCards.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                lcl_obj_TmpScCards.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                lcl_obj_TmpScCards.CardSerial = System.UInt64.Parse(lcl_obj_dr["CARD_SERIAL"].ToString());
                lcl_obj_TmpScCards.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                lcl_obj_TmpScCards.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                lcl_obj_TmpScCards.ScPackingISOCode = System.UInt64.Parse(lcl_obj_dr["SC_PACKING_ISO_CODE"].ToString());
                lcl_obj_TmpScCards.ScDeliveryISOCode = System.UInt64.Parse(lcl_obj_dr["SC_DELIVERY_ISO_CODE"].ToString());
                lcl_obj_TmpScCards.CardStatus = (CCL.Enums.SPM.SCCardStatus)System.Int16.Parse(lcl_obj_dr["CARD_STATUS"].ToString());
                
                lcl_obj_dr.Close();
                return lcl_obj_TmpScCards;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScCards;
        }

        public CCL.BusinessEntities.SCPM.ScpmScCards Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCards = null;
            lcl_obj_ScCards = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScCards>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_CARDS WHERE SC_CARD_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_TmpScCards = new CCL.BusinessEntities.SCPM.ScpmScCards();
                    lcl_obj_TmpScCards.ScCardCode = System.UInt64.Parse(lcl_obj_dr["SC_CARD_CODE"].ToString());
                    lcl_obj_TmpScCards.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                    lcl_obj_TmpScCards.Denomination = System.UInt64.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                    lcl_obj_TmpScCards.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                    lcl_obj_TmpScCards.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScCards.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                    lcl_obj_TmpScCards.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScCards.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScCards.CardSerial = System.UInt64.Parse(lcl_obj_dr["CARD_SERIAL"].ToString());
                    //lcl_obj_TmpScCards.IsPersoComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETE"].ToString());
                    lcl_obj_TmpScCards.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                    //lcl_obj_TmpScCards.IsPackingComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PACKING_COMPLETE"].ToString());
                    lcl_obj_TmpScCards.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                    lcl_obj_TmpScCards.ScPackingISOCode = System.UInt64.Parse(lcl_obj_dr["SC_PACKING_ISO_CODE"].ToString());
                    //lcl_obj_TmpScCards.IsDelivered = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_DELIVERED"].ToString());
                    lcl_obj_TmpScCards.ScDeliveryISOCode = System.UInt64.Parse(lcl_obj_dr["SC_DELIVERY_ISO_CODE"].ToString());
                    lcl_obj_TmpScCards.CardStatus = (CCL.Enums.SPM.SCCardStatus)System.Int16.Parse(lcl_obj_dr["CARD_STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScCards;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScCards;
        }

        public CCL.BusinessEntities.SCPM.ScpmScCards Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCards = null;
            lcl_obj_ScCards = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_TmpScCards = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards();
                lcl_obj_TmpScCards.ScCardCode = System.UInt64.Parse(lcl_obj_dr["SC_CARD_CODE"].ToString());
                lcl_obj_TmpScCards.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                lcl_obj_TmpScCards.Denomination = System.UInt64.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                lcl_obj_TmpScCards.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                lcl_obj_TmpScCards.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                lcl_obj_TmpScCards.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                lcl_obj_TmpScCards.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                lcl_obj_TmpScCards.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                lcl_obj_TmpScCards.CardSerial = System.UInt64.Parse(lcl_obj_dr["CARD_SERIAL"].ToString());
                //lcl_obj_TmpScCards.IsPersoComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETE"].ToString());
                lcl_obj_TmpScCards.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                //lcl_obj_TmpScCards.IsPackingComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PACKING_COMPLETE"].ToString());
                lcl_obj_TmpScCards.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                lcl_obj_TmpScCards.ScPackingISOCode = System.UInt64.Parse(lcl_obj_dr["SC_PACKING_ISO_CODE"].ToString());
                //lcl_obj_TmpScCards.IsDelivered = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_DELIVERED"].ToString());
                lcl_obj_TmpScCards.CardStatus = (CCL.Enums.SPM.SCCardStatus)System.Int16.Parse(lcl_obj_dr["CARD_STATUS"].ToString());
                lcl_obj_TmpScCards.ScDeliveryISOCode = System.UInt64.Parse(lcl_obj_dr["SC_DELIVERY_ISO_CODE"].ToString());
                lcl_obj_dr.Close();

                return lcl_obj_TmpScCards;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScCards;
        }

        public CCL.BusinessEntities.SCPM.ScpmScCards Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_ScCards = null;
            lcl_obj_ScCards = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_TmpScCards = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScCards();
                    lcl_obj_TmpScCards.ScCardCode = System.UInt64.Parse(lcl_obj_dr["SC_CARD_CODE"].ToString());
                    lcl_obj_TmpScCards.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                    lcl_obj_TmpScCards.Denomination = System.UInt64.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                    lcl_obj_TmpScCards.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                    lcl_obj_TmpScCards.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScCards.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                    lcl_obj_TmpScCards.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScCards.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScCards.CardSerial = System.UInt64.Parse(lcl_obj_dr["CARD_SERIAL"].ToString());
                    //lcl_obj_TmpScCards.IsPersoComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETE"].ToString());
                    lcl_obj_TmpScCards.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                    //lcl_obj_TmpScCards.IsPackingComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PACKING_COMPLETE"].ToString());
                    lcl_obj_TmpScCards.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                    lcl_obj_TmpScCards.ScPackingISOCode = System.UInt64.Parse(lcl_obj_dr["SC_PACKING_ISO_CODE"].ToString());
                    //lcl_obj_TmpScCards.IsDelivered = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_DELIVERED"].ToString());
                    lcl_obj_TmpScCards.ScDeliveryISOCode = System.UInt64.Parse(lcl_obj_dr["SC_DELIVERY_ISO_CODE"].ToString());
                    lcl_obj_TmpScCards.CardStatus = (CCL.Enums.SPM.SCCardStatus)System.Int16.Parse(lcl_obj_dr["CARD_STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScCards;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScCards;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScCards> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards> lcl_objlist_ScCardsList = null;
            lcl_objlist_ScCardsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards> lcl_objlist_TmpScCardsList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpScCardsList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_TmpScCards = new CCL.BusinessEntities.SCPM.ScpmScCards();
                    lcl_obj_TmpScCards.ScCardCode = System.UInt64.Parse(lcl_obj_dr["SC_CARD_CODE"].ToString());
                    lcl_obj_TmpScCards.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                    lcl_obj_TmpScCards.Denomination = System.UInt64.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                    lcl_obj_TmpScCards.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                    lcl_obj_TmpScCards.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScCards.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                    lcl_obj_TmpScCards.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScCards.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScCards.CardSerial = System.UInt64.Parse(lcl_obj_dr["CARD_SERIAL"].ToString());
                    //lcl_obj_TmpScCards.IsPersoComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETE"].ToString());
                    lcl_obj_TmpScCards.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                    //lcl_obj_TmpScCards.IsPackingComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PACKING_COMPLETE"].ToString());
                    lcl_obj_TmpScCards.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                    lcl_obj_TmpScCards.ScPackingISOCode = System.UInt64.Parse(lcl_obj_dr["SC_PACKING_ISO_CODE"].ToString());
                    //lcl_obj_TmpScCards.IsDelivered = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_DELIVERED"].ToString());
                    lcl_obj_TmpScCards.ScDeliveryISOCode = System.UInt64.Parse(lcl_obj_dr["SC_DELIVERY_ISO_CODE"].ToString());
                    lcl_obj_TmpScCards.CardStatus = (CCL.Enums.SPM.SCCardStatus)System.Int16.Parse(lcl_obj_dr["CARD_STATUS"].ToString());
                    lcl_objlist_TmpScCardsList.Add(lcl_obj_TmpScCards);
                }
                lcl_obj_dr.Close();


                return lcl_objlist_TmpScCardsList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScCardsList;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScCards> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards> lcl_objlist_ScCardsList = null;
            lcl_objlist_ScCardsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards> lcl_objlist_TmpScCardsList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScCards>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpScCardsList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SCPM.ScpmScCards lcl_obj_TmpScCards = new CCL.BusinessEntities.SCPM.ScpmScCards();
                        lcl_obj_TmpScCards.ScCardCode = System.UInt64.Parse(lcl_obj_dr["SC_CARD_CODE"].ToString());
                        lcl_obj_TmpScCards.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                        lcl_obj_TmpScCards.Denomination = System.UInt64.Parse(lcl_obj_dr["DENOMINATION"].ToString());
                        lcl_obj_TmpScCards.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                        lcl_obj_TmpScCards.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                        lcl_obj_TmpScCards.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                        lcl_obj_TmpScCards.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                        lcl_obj_TmpScCards.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                        lcl_obj_TmpScCards.CardSerial = System.UInt64.Parse(lcl_obj_dr["CARD_SERIAL"].ToString());
                        //lcl_obj_TmpScCards.IsPersoComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETE"].ToString());
                        lcl_obj_TmpScCards.ScPersoCode = System.UInt64.Parse(lcl_obj_dr["SC_PERSO_ISO_CODE"].ToString());
                        //lcl_obj_TmpScCards.IsPackingComplete = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PACKING_COMPLETE"].ToString());
                        lcl_obj_TmpScCards.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                        lcl_obj_TmpScCards.ScPackingISOCode = System.UInt64.Parse(lcl_obj_dr["SC_PACKING_ISO_CODE"].ToString());
                        //lcl_obj_TmpScCards.IsDelivered = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_DELIVERED"].ToString());
                        lcl_obj_TmpScCards.ScDeliveryISOCode = System.UInt64.Parse(lcl_obj_dr["SC_DELIVERY_ISO_CODE"].ToString());
                        lcl_obj_TmpScCards.CardStatus = (CCL.Enums.SPM.SCCardStatus)System.Int16.Parse(lcl_obj_dr["CARD_STATUS"].ToString());
                        lcl_objlist_TmpScCardsList.Add(lcl_obj_TmpScCards);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpScCardsList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScCardsList;
        }
    }
}
