using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class ItemDetailsManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails>
    {


       public ulong Save(SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails IP_obj_A, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_QuotationMCode = 0;
            System.String lcl_str_Sequence = IP_obj_A.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_QuotationMCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_A.ItemDCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_QuotationMCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails IP_obj_A)
        {
            System.UInt64 lcl_ui64_QuotationMCode = 0;
            System.String lcl_str_Sequence = IP_obj_A.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_QuotationMCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_A.ItemDCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();

                    lcl_obj_DBManager.InternalResource.Close();

                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_QuotationMCode;      
        }

        public SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails> lcl_objLst_Quotation = null;
            lcl_objLst_Quotation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails>>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (QuotationManager.GetList(SqlQuery)) : No Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails> lcl_objLst_Items2Tmp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails>();
                    while (lcl_obj_Reader.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails lcl_obj_QuotationTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemDetails();
                        lcl_obj_QuotationTmp.ItemDCode = System.UInt64.Parse(lcl_obj_Reader["QUOTATION_M_CODE"].ToString());
                        lcl_obj_QuotationTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                        lcl_obj_QuotationTmp.ItemName = lcl_obj_Reader["ITEM_NAME"].ToString();
                        //lcl_obj_QuotationTmp.IsAactive = System.UInt16.Parse(lcl_obj_Reader["IS_ACTIVE"].ToString());
                     

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
