using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class ItemInkManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk>
    {
        public ItemInkManager()
        {
            this.Initialize();
        }

        public System.Boolean SaveItemInkList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk> IP_objLst_ItemInk)
        {
            System.Boolean lcl_b_Response = false;
            lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    foreach (SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInk in IP_objLst_ItemInk)
                    {
                        this.Save(lcl_obj_ItemInk, lcl_obj_DBManager.InternalResource);
                    }
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return true;
            }, "BMLExceptionPolicy");
            return lcl_b_Response;
        }

        public ulong Save(CCL.BusinessEntities.WPMS.ItemInk IP_obj_A, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ItemInkCode = 0;
            System.String lcl_str_Sequence = IP_obj_A.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_ItemInkCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_A.InkCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_ItemInkCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.WPMS.ItemInk IP_obj_A)
        {
            System.UInt64 lcl_ui64_ItemInkCode = 0;
            System.String lcl_str_Sequence = IP_obj_A.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_ItemInkCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_A.InkCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();


                    lcl_obj_DBManager.InternalResource.Close();

                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_ItemInkCode;
        }

        public CCL.BusinessEntities.WPMS.ItemInk Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInk = null;

            lcl_obj_ItemInk = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_ITEM_INK Where INK_CODE = {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_Reader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error ItemInkManager.Get(ItemCode,DBManger)) : Error Retrieving ItemInk Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInkTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemInk();

                lcl_obj_ItemInkTmp.InkCode = System.UInt64.Parse(lcl_obj_Reader["INK_CODE"].ToString());
                lcl_obj_ItemInkTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                lcl_obj_ItemInkTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                lcl_obj_ItemInkTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                lcl_obj_ItemInkTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();

                lcl_obj_Reader.Close();
                return lcl_obj_ItemInkTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_ItemInk;
        }
        public CCL.BusinessEntities.WPMS.ItemInk Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInk = null;
            lcl_obj_ItemInk = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From WPMS_ITEM_INK Where INK_CODE = {0}", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ItemInkManager.Get(ID)) : No ItemInk Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInkTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemInk();

                    lcl_obj_ItemInkTmp.InkCode = System.UInt64.Parse(lcl_obj_Reader["INK_CODE"].ToString());
                    lcl_obj_ItemInkTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                    lcl_obj_ItemInkTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                    lcl_obj_ItemInkTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                    lcl_obj_ItemInkTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                    lcl_obj_Reader.Close();
                    return lcl_obj_ItemInkTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ItemInk;
        }

        public CCL.BusinessEntities.WPMS.ItemInk Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInk = null;

            lcl_obj_ItemInk = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error ItemInkManager.Get(SqlQuery,DBManger)) : Error Retrieving ItemInk Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInkTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemInk();
                lcl_obj_ItemInkTmp.InkCode = System.UInt64.Parse(lcl_obj_Reader["INK_CODE"].ToString());
                lcl_obj_ItemInkTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                lcl_obj_ItemInkTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                lcl_obj_ItemInkTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                lcl_obj_ItemInkTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                lcl_obj_Reader.Close();
                return lcl_obj_ItemInkTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_ItemInk;
        }

        public CCL.BusinessEntities.WPMS.ItemInk Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInk = null;
            lcl_obj_ItemInk = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (ItemInkManager.Get(SqlQuery)) : No ItemInk Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInkTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemInk();
                    lcl_obj_ItemInkTmp.InkCode = System.UInt64.Parse(lcl_obj_Reader["INK_CODE"].ToString());
                    lcl_obj_ItemInkTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                    lcl_obj_ItemInkTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                    lcl_obj_ItemInkTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                    lcl_obj_ItemInkTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                    lcl_obj_Reader.Close();
                    return lcl_obj_ItemInk;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ItemInk;
        }

        public List<CCL.BusinessEntities.WPMS.ItemInk> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk> lcl_objLst_ItemInk = null;

            lcl_objLst_ItemInk = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_Reader.HasRows))
                {
                    return null;
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk> lcl_objLst_ItemInkTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemInk>();
                while (lcl_obj_Reader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInkTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemInk();
                    lcl_obj_ItemInkTmp.InkCode = System.UInt64.Parse(lcl_obj_Reader["INK_CODE"].ToString());
                    lcl_obj_ItemInkTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                    lcl_obj_ItemInkTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                    lcl_obj_ItemInkTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                    lcl_obj_ItemInkTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                    lcl_objLst_ItemInkTmp.Add(lcl_obj_ItemInkTmp);
                }
                lcl_obj_Reader.Close();
                return lcl_objLst_ItemInkTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_ItemInk;
        }

        public List<CCL.BusinessEntities.WPMS.ItemInk> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemInk> lcl_objlist_ItemInkList = null;
            lcl_objlist_ItemInkList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemInk>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    
                    System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemInk> lcl_objlist_TmpItemInkList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.WPMS.ItemInk>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        return lcl_objlist_TmpItemInkList;
                    }

                    while (lcl_obj_Reader.Read())
                    {
                        CCL.BusinessEntities.WPMS.ItemInk lcl_obj_ItemInkTmp = new CCL.BusinessEntities.WPMS.ItemInk();
                        lcl_obj_ItemInkTmp.InkCode = System.UInt64.Parse(lcl_obj_Reader["INK_CODE"].ToString());
                        lcl_obj_ItemInkTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                        lcl_obj_ItemInkTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                        lcl_obj_ItemInkTmp.PantoneColor = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                        lcl_obj_ItemInkTmp.ColorHex = lcl_obj_Reader["COLOR_HEX"].ToString();
                        lcl_objlist_TmpItemInkList.Add(lcl_obj_ItemInkTmp);
                    }
                    lcl_obj_Reader.Close();
                    return lcl_objlist_TmpItemInkList;
                    
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_ItemInkList;
            }
        }
    }
