using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class ItemManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.Item>
    {
       public ItemManager()
        {
            this.Initialize();
        }

       public ulong Save(CCL.BusinessEntities.WPMS.Item IP_obj_A, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_BuyerCode = 0;
           System.String lcl_str_Sequence = IP_obj_A.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_BuyerCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_A.ProductCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               lcl_obj_DBManager.CommitTransaction();
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_BuyerCode;
       }

       public ulong Save(CCL.BusinessEntities.WPMS.Item IP_obj_A)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.Item Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.Item Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.Item Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.WPMS.Item Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.WPMS.Item> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.WPMS.Item> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_objLst_Item = null;

           using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
           {
               if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.InternalResource.Open();
               }
               System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);

               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_objLst_ItemTmp = new
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item>();
               while (lcl_obj_Reader.Read())
               {
                   SilkERP360.CCL.BusinessEntities.WPMS.Item lcl_obj_Item = new SilkERP360.CCL.BusinessEntities.WPMS.Item();
                   lcl_obj_Item.ProductCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                   lcl_obj_Item.ItemCatagoryCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CATAGORY_CODE"].ToString());
                   lcl_obj_Item.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                   lcl_obj_Item.ProcessingCost = System.Decimal.Parse(lcl_obj_Reader["PROCESSING_COST"].ToString());
                   lcl_obj_Item.PrintingCharge = System.Decimal.Parse(lcl_obj_Reader["PRINTING_CHARGE"].ToString());
                   //lcl_obj_Item.IsActive = System.Enum.Parse(lcl_obj_Reader["STATUS"].ToString());
                   lcl_obj_Item.Width = System.Decimal.Parse(lcl_obj_Reader["WIDTH"].ToString());
                   lcl_obj_Item.Length = System.Decimal.Parse(lcl_obj_Reader["LENGTH"].ToString());
                   lcl_obj_Item.Gusset = System.UInt16.Parse(lcl_obj_Reader["GUSSET"].ToString());
                   lcl_obj_Item.Density = System.Decimal.Parse(lcl_obj_Reader["DENSITY"].ToString());
                   lcl_obj_Item.Thickness = System.UInt16.Parse(lcl_obj_Reader["THICKNESS"].ToString());
                   lcl_obj_Item.ProductName = lcl_obj_Reader["SPECIFICATION_NAME"].ToString();
                   lcl_obj_Item.Punchout = System.UInt16.Parse(lcl_obj_Reader["PUNCHOUT"].ToString());
                   lcl_objLst_ItemTmp.Add(lcl_obj_Item);
               }
               lcl_obj_Reader.Close();
               return lcl_objLst_ItemTmp;
               return lcl_objLst_Item;
           }
       }
    }
}
