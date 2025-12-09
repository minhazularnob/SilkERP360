using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class RawProductManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct>
    {
       public RawProductManager()
       { 
       
       }
       
       public ulong Save(CCL.BusinessEntities.WPMS.RawProduct IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public ulong Save(CCL.BusinessEntities.WPMS.RawProduct IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.RawProduct Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.RawProduct Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.RawProduct Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.RawProduct Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.RawProduct lcl_obj_RawMaterials = null;
            lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RawMaterialsManager.Get(SqlQuery)) : No RawMaterials Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.RawProduct lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawProduct();
                   lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                       lcl_obj_RawMaterialsTmp.RMName = lcl_obj_Reader["RM_NAME"].ToString();
                       lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_Reader.Close();
                    return lcl_obj_RawMaterialsTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_RawMaterials;
        }

        public List<CCL.BusinessEntities.WPMS.RawProduct> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.RawProduct> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_objLst_Quotation = null;
        
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                  
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_objLst_Items2Tmp = new
                       System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct>();
                   while (lcl_obj_Reader.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.WPMS.RawProduct lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawProduct();
                       lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                       lcl_obj_RawMaterialsTmp.RMName = lcl_obj_Reader["RM_NAME"].ToString();
                       lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                       lcl_objLst_Items2Tmp.Add(lcl_obj_RawMaterialsTmp);
                   }
                   lcl_obj_Reader.Close();
                   return lcl_objLst_Items2Tmp;
               }
                     return lcl_objLst_Quotation;
       }


        public List<CCL.BusinessEntities.WPMS.RawProduct> GetListJoin(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_objLst_Quotation = null;

            using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
            {
                if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.InternalResource.Open();
                }

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct> lcl_objLst_Items2Tmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawProduct>();
                while (lcl_obj_Reader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.WPMS.RawProduct lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawProduct();
                    lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.RMName = lcl_obj_Reader["RM_NAME"].ToString();
                    //lcl_obj_RawMaterialsTmp.Month= System.DateTime.Parse(lcl_obj_Reader["MONTH"].ToString());
                    //lcl_obj_RawMaterialsTmp.lcl_obj_RawMaterialsList.PriceMTon=System.UInt64.Parse(lcl_obj_Reader["PRICE_M_TON"].ToString());

                    lcl_objLst_Items2Tmp.Add(lcl_obj_RawMaterialsTmp);
                }
                lcl_obj_Reader.Close();
                return lcl_objLst_Items2Tmp;
            }
            return lcl_objLst_Quotation;
        }
        }
    }

