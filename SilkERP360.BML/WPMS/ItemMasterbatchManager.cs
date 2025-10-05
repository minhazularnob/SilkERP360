using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class ItemMasterbatchManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch>
    {
       public ItemMasterbatchManager()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.WPMS.ItemMasterbatch IP_obj_A, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ItemMasterbatchCode = 0;
           System.String lcl_str_Sequence = IP_obj_A.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_ItemMasterbatchCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_A.MasterBatchCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               lcl_obj_DBManager.CommitTransaction();
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_ItemMasterbatchCode;
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch IP_obj_A)
       {
           System.UInt64 lcl_ui64_ItemMasterbatchCode = 0;
           System.String lcl_str_Sequence = IP_obj_A.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_ItemMasterbatchCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                   IP_obj_A.MasterBatchCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();


                   lcl_obj_DBManager.InternalResource.Close();

                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_ItemMasterbatchCode;
       }

       public CCL.BusinessEntities.WPMS.ItemMasterbatch Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatch = null;

           lcl_obj_ItemMasterbatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_ITEM_MASTERBATCH Where MASTERBATCH_CODE = {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_Reader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error ItemMasterbatchManager.Get(ItemCode,DBManger)) : Error Retrieving ItemMasterbatch Data!");
               }
               lcl_obj_Reader.Read();
               SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatchTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch();

               lcl_obj_ItemMasterbatchTmp.MasterBatchCode = System.UInt64.Parse(lcl_obj_Reader["MASTERBATCH_CODE"].ToString());
               lcl_obj_ItemMasterbatchTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
               lcl_obj_ItemMasterbatchTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
               lcl_obj_ItemMasterbatchTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
               lcl_obj_ItemMasterbatchTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
               lcl_obj_ItemMasterbatchTmp.Percentage = System.Decimal.Parse(lcl_obj_Reader["PERCENTAGE"].ToString());

               lcl_obj_Reader.Close();
               return lcl_obj_ItemMasterbatchTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_ItemMasterbatch;
       }

       public CCL.BusinessEntities.WPMS.ItemMasterbatch Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatch = null;
           lcl_obj_ItemMasterbatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From WPMS_ITEM_MASTERBATCH Where MASTERBATCH_CODE = {0}", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                   if (!(lcl_obj_Reader.HasRows))
                   {
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ItemMasterbatchManager.Get(ID)) : No ItemMasterbatch Data Found In The Database!!!");
                   }
                   SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatchTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch();

                   lcl_obj_ItemMasterbatchTmp.MasterBatchCode = System.UInt64.Parse(lcl_obj_Reader["MASTERBATCH_CODE"].ToString());
                   lcl_obj_ItemMasterbatchTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                   lcl_obj_ItemMasterbatchTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                   lcl_obj_ItemMasterbatchTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                   lcl_obj_ItemMasterbatchTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                   lcl_obj_ItemMasterbatchTmp.Percentage = System.Decimal.Parse(lcl_obj_Reader["PERCENTAGE"].ToString());
                   lcl_obj_Reader.Close();
                   return lcl_obj_ItemMasterbatchTmp;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ItemMasterbatch;
       }

       public CCL.BusinessEntities.WPMS.ItemMasterbatch Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatch = null;

           lcl_obj_ItemMasterbatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch>(() =>
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
                   return null;
               }
               lcl_obj_Reader.Read();
               SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatchTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch();
               lcl_obj_ItemMasterbatchTmp.MasterBatchCode = System.UInt64.Parse(lcl_obj_Reader["MASTERBATCH_CODE"].ToString());
               lcl_obj_ItemMasterbatchTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
               lcl_obj_ItemMasterbatchTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
               lcl_obj_ItemMasterbatchTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
               lcl_obj_ItemMasterbatchTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
               lcl_obj_ItemMasterbatchTmp.Percentage = System.Decimal.Parse(lcl_obj_Reader["PERCENTAGE"].ToString());
               lcl_obj_Reader.Close();
               return lcl_obj_ItemMasterbatchTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_ItemMasterbatch;
       }

       public CCL.BusinessEntities.WPMS.ItemMasterbatch Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatch = null;
           lcl_obj_ItemMasterbatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch>(() =>
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
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ItemMasterbatchManager.Get(SqlQuery)) : No ItemMasterbatch Data Found In The Database!!!");
                   }
                   SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatchTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch();
                   lcl_obj_ItemMasterbatchTmp.MasterBatchCode = System.UInt64.Parse(lcl_obj_Reader["MASTERBATCH_CODE"].ToString());
                   lcl_obj_ItemMasterbatchTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                   lcl_obj_ItemMasterbatchTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                   lcl_obj_ItemMasterbatchTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                   lcl_obj_ItemMasterbatchTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                   lcl_obj_ItemMasterbatchTmp.Percentage = System.Decimal.Parse(lcl_obj_Reader["PERCENTAGE"].ToString());
                   lcl_obj_Reader.Close();
                   return lcl_obj_ItemMasterbatch;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ItemMasterbatch;
       }

       public List<CCL.BusinessEntities.WPMS.ItemMasterbatch> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch> lcl_objLst_ItemMasterbatch = null;

           lcl_objLst_ItemMasterbatch = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_Reader.HasRows))
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error ItemMasterbatchManager.GetList(SqlQuery,DBManager)) : No ItemMasterbatch Data Found In The Database!!!");
               }
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch> lcl_objLst_ItemMasterbatchTmp = new
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch>();
               while (lcl_obj_Reader.Read())
               {
                   SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatchTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemMasterbatch();
                   lcl_obj_ItemMasterbatchTmp.MasterBatchCode = System.UInt64.Parse(lcl_obj_Reader["MASTERBATCH_CODE"].ToString());
                   lcl_obj_ItemMasterbatchTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                   lcl_obj_ItemMasterbatchTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                   lcl_obj_ItemMasterbatchTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                   lcl_obj_ItemMasterbatchTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                   lcl_obj_ItemMasterbatchTmp.Percentage = System.Decimal.Parse(lcl_obj_Reader["PERCENTAGE"].ToString());
               }
               lcl_obj_Reader.Close();
               return lcl_objLst_ItemMasterbatchTmp;

           }, "BMLExceptionPolicy");
           return lcl_objLst_ItemMasterbatch;
       }

       public List<CCL.BusinessEntities.WPMS.ItemMasterbatch> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemMasterbatch> lcl_objlist_ItemMasterbatchList = null;
           lcl_objlist_ItemMasterbatchList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemMasterbatch>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemMasterbatch> lcl_objlist_TmpItemMasterbatchList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemMasterbatch>();
                   System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_Reader.HasRows))
                   {
                       return lcl_objlist_TmpItemMasterbatchList;
                   }

                   while (lcl_obj_Reader.Read())
                   {
                       CCL.BusinessEntities.WPMS.ItemMasterbatch lcl_obj_ItemMasterbatchTmp = new CCL.BusinessEntities.WPMS.ItemMasterbatch();
                       lcl_obj_ItemMasterbatchTmp.MasterBatchCode = System.UInt64.Parse(lcl_obj_Reader["MASTERBATCH_CODE"].ToString());
                       lcl_obj_ItemMasterbatchTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                       lcl_obj_ItemMasterbatchTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                       lcl_obj_ItemMasterbatchTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                       lcl_obj_ItemMasterbatchTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                       lcl_obj_ItemMasterbatchTmp.Percentage = System.Decimal.Parse(lcl_obj_Reader["PERCENTAGE"].ToString());
                       lcl_objlist_TmpItemMasterbatchList.Add(lcl_obj_ItemMasterbatchTmp);
                   }
                   lcl_obj_Reader.Close();
                   return lcl_objlist_TmpItemMasterbatchList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ItemMasterbatchList;
       }
    }
}
