using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmScDataRepositoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository>
    {
       public ScpmScDataRepositoryManager()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScDataRepository IP_obj_ScDataRepository, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ScDataRepositoryCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_DATA_REPO.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_ScDataRepositoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScDataRepository.ScDataRepoCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScDataRepository.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScDataRepositoryCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScDataRepository IP_obj_ScDataRepository)
       {
           System.UInt64 lcl_ui64_ScDataRepositoryCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_DATA_REPO.NEXTVAL AS ID FROM DUAL", IP_obj_ScDataRepository.GetSequence());
           lcl_ui64_ScDataRepositoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_ScDataRepository.ScDataRepoCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_ScDataRepository.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScDataRepositoryCode;
       }

       public CCL.BusinessEntities.SCPM.ScpmScDataRepository Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepository = null;
           lcl_obj_ScDataRepository = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScDataRepository>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_DATA_REPOSITORY WHERE SC_DATA_REPO_CODE = {0}", IP_ui64_Code);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_TmpScDataRepository = new CCL.BusinessEntities.SCPM.ScpmScDataRepository();
               lcl_obj_TmpScDataRepository.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
               lcl_obj_TmpScDataRepository.BatchNo = System.UInt32.Parse(lcl_obj_dr["BATCH_NO"].ToString());
               lcl_obj_TmpScDataRepository.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
               lcl_obj_TmpScDataRepository.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScDataRepository.LastPersoSerial = System.UInt64.Parse(lcl_obj_dr["LAST_PERSO_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.NextPersoSerial = System.UInt64.Parse(lcl_obj_dr["NEXT_PERSO_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.QuantityPersonalized = System.UInt64.Parse(lcl_obj_dr["QUANTITY_PERSONALIZED"].ToString());
               lcl_obj_TmpScDataRepository.IsPersoCompleted = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETED"].ToString());
               lcl_obj_TmpScDataRepository.PackagedBoxSerialStart = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_START"].ToString());
               lcl_obj_TmpScDataRepository.PackagedBoxSerialEnd = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_END"].ToString());
                    

               lcl_obj_dr.Close();
               return lcl_obj_TmpScDataRepository;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScDataRepository;
       }

       public CCL.BusinessEntities.SCPM.ScpmScDataRepository Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepository = null;
           lcl_obj_ScDataRepository = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScDataRepository>(() =>
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
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_DATA_REPOSITORY WHERE SC_DATA_REPO_CODE = {0}", IP_ui64_Code);
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_TmpScDataRepository = new CCL.BusinessEntities.SCPM.ScpmScDataRepository();
                   lcl_obj_TmpScDataRepository.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.BatchNo = System.UInt32.Parse(lcl_obj_dr["BATCH_NO"].ToString());
                   lcl_obj_TmpScDataRepository.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                   lcl_obj_TmpScDataRepository.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScDataRepository.LastPersoSerial = System.UInt64.Parse(lcl_obj_dr["LAST_PERSO_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.NextPersoSerial = System.UInt64.Parse(lcl_obj_dr["NEXT_PERSO_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.QuantityPersonalized = System.UInt64.Parse(lcl_obj_dr["QUANTITY_PERSONALIZED"].ToString());
                   lcl_obj_TmpScDataRepository.IsPersoCompleted = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETED"].ToString());
                   lcl_obj_TmpScDataRepository.PackagedBoxSerialStart = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_START"].ToString());
                   lcl_obj_TmpScDataRepository.PackagedBoxSerialEnd = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_END"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScDataRepository;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScDataRepository;
       }

       public CCL.BusinessEntities.SCPM.ScpmScDataRepository Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepository = null;
           lcl_obj_ScDataRepository = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository>(() =>
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
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_TmpScDataRepository = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository();
               lcl_obj_TmpScDataRepository.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScDataRepository.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
               lcl_obj_TmpScDataRepository.BatchNo = System.UInt32.Parse(lcl_obj_dr["BATCH_NO"].ToString());
               lcl_obj_TmpScDataRepository.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
               lcl_obj_TmpScDataRepository.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
               lcl_obj_TmpScDataRepository.LastPersoSerial = System.UInt64.Parse(lcl_obj_dr["LAST_PERSO_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.NextPersoSerial = System.UInt64.Parse(lcl_obj_dr["NEXT_PERSO_SERIAL"].ToString());
               lcl_obj_TmpScDataRepository.QuantityPersonalized = System.UInt64.Parse(lcl_obj_dr["QUANTITY_PERSONALIZED"].ToString());
               lcl_obj_TmpScDataRepository.IsPersoCompleted = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETED"].ToString());
               lcl_obj_TmpScDataRepository.PackagedBoxSerialStart = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_START"].ToString());
               lcl_obj_TmpScDataRepository.PackagedBoxSerialEnd = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_END"].ToString());
               lcl_obj_dr.Close();

               return lcl_obj_TmpScDataRepository;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScDataRepository;
       }

       public CCL.BusinessEntities.SCPM.ScpmScDataRepository Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_ScDataRepository = null;
           lcl_obj_ScDataRepository = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository>(() =>
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
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_TmpScDataRepository = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScDataRepository();
                   lcl_obj_TmpScDataRepository.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.BatchNo = System.UInt32.Parse(lcl_obj_dr["BATCH_NO"].ToString());
                   lcl_obj_TmpScDataRepository.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                   lcl_obj_TmpScDataRepository.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScDataRepository.LastPersoSerial = System.UInt64.Parse(lcl_obj_dr["LAST_PERSO_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.NextPersoSerial = System.UInt64.Parse(lcl_obj_dr["NEXT_PERSO_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.QuantityPersonalized = System.UInt64.Parse(lcl_obj_dr["QUANTITY_PERSONALIZED"].ToString());
                   lcl_obj_TmpScDataRepository.IsPersoCompleted = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETED"].ToString());
                   lcl_obj_TmpScDataRepository.PackagedBoxSerialStart = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_START"].ToString());
                   lcl_obj_TmpScDataRepository.PackagedBoxSerialEnd = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_END"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScDataRepository;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScDataRepository;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScDataRepository> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository> lcl_objlist_ScDataRepositoryList = null;
           lcl_objlist_ScDataRepositoryList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository> lcl_objlist_TmpScDataRepositoryList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository>();
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpScDataRepositoryList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_TmpScDataRepository = new CCL.BusinessEntities.SCPM.ScpmScDataRepository();
                   lcl_obj_TmpScDataRepository.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                   lcl_obj_TmpScDataRepository.BatchNo = System.UInt32.Parse(lcl_obj_dr["BATCH_NO"].ToString());
                   lcl_obj_TmpScDataRepository.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                   lcl_obj_TmpScDataRepository.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                   lcl_obj_TmpScDataRepository.LastPersoSerial = System.UInt64.Parse(lcl_obj_dr["LAST_PERSO_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.NextPersoSerial = System.UInt64.Parse(lcl_obj_dr["NEXT_PERSO_SERIAL"].ToString());
                   lcl_obj_TmpScDataRepository.QuantityPersonalized = System.UInt64.Parse(lcl_obj_dr["QUANTITY_PERSONALIZED"].ToString());
                   lcl_obj_TmpScDataRepository.IsPersoCompleted = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETED"].ToString());
                   lcl_obj_TmpScDataRepository.PackagedBoxSerialStart = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_START"].ToString());
                   lcl_obj_TmpScDataRepository.PackagedBoxSerialEnd = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_END"].ToString());
                   lcl_objlist_TmpScDataRepositoryList.Add(lcl_obj_TmpScDataRepository);
               }
               lcl_obj_dr.Close();


               return lcl_objlist_TmpScDataRepositoryList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScDataRepositoryList;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScDataRepository> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository> lcl_objlist_ScDataRepositoryList = null;
           lcl_objlist_ScDataRepositoryList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository> lcl_objlist_TmpScDataRepositoryList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScDataRepository>();
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpScDataRepositoryList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.SCPM.ScpmScDataRepository lcl_obj_TmpScDataRepository = new CCL.BusinessEntities.SCPM.ScpmScDataRepository();
                       lcl_obj_TmpScDataRepository.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                       lcl_obj_TmpScDataRepository.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                       lcl_obj_TmpScDataRepository.ScpmPOItemCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                       lcl_obj_TmpScDataRepository.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                       lcl_obj_TmpScDataRepository.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                       lcl_obj_TmpScDataRepository.BatchNo = System.UInt32.Parse(lcl_obj_dr["BATCH_NO"].ToString());
                       lcl_obj_TmpScDataRepository.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                       lcl_obj_TmpScDataRepository.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                       lcl_obj_TmpScDataRepository.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                       lcl_obj_TmpScDataRepository.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                       lcl_obj_TmpScDataRepository.LastPersoSerial = System.UInt64.Parse(lcl_obj_dr["LAST_PERSO_SERIAL"].ToString());
                       lcl_obj_TmpScDataRepository.NextPersoSerial = System.UInt64.Parse(lcl_obj_dr["NEXT_PERSO_SERIAL"].ToString());
                       lcl_obj_TmpScDataRepository.QuantityPersonalized = System.UInt64.Parse(lcl_obj_dr["QUANTITY_PERSONALIZED"].ToString());
                       lcl_obj_TmpScDataRepository.IsPersoCompleted = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PERSO_COMPLETED"].ToString());
                       lcl_obj_TmpScDataRepository.PackagedBoxSerialStart = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_START"].ToString());
                       lcl_obj_TmpScDataRepository.PackagedBoxSerialEnd = System.UInt32.Parse(lcl_obj_dr["PACKAGED_BOX_SL_END"].ToString());
                       lcl_objlist_TmpScDataRepositoryList.Add(lcl_obj_TmpScDataRepository);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScDataRepositoryList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScDataRepositoryList;
       }
    }
}
