using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM.SM
{
    public class SpmSmPackagedBoxSerialsManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>
    {
        public SpmSmPackagedBoxSerialsManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials IP_obj_SpmSmPackagedBoxSerials, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SmPackagedBoxSerialCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPackagedBoxSerials.GetSequence());
            lcl_ui64_SmPackagedBoxSerialCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmSmPackagedBoxSerials.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPackagedBoxSerialCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials IP_obj_SpmSmPackagedBoxSerials)
        {
            System.UInt64 lcl_ui64_SmPackagedBoxSerialCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmSmPackagedBoxSerials.GetSequence());
            lcl_ui64_SmPackagedBoxSerialCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmSmPackagedBoxSerials.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_SmPackagedBoxSerialCode;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_SpmSmPackagedBoxSerials = null;
            lcl_obj_SpmSmPackagedBoxSerials = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PACKAGED_BOX_SERIALS WHERE SM_PACKAGED_BOX_SERIAL_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_TmpSpmSmPackagedBoxSerials = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials();
                lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_SERIAL_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());                

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPackagedBoxSerials;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBoxSerials;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_SpmSmPackagedBoxSerials = null;
            lcl_obj_SpmSmPackagedBoxSerials = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_SM_PACKAGED_BOX_SERIALS WHERE SM_PACKAGED_BOX_SERIAL_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_TmpSpmSmPackagedBoxSerials = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials();
                    lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_SERIAL_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString()); 
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPackagedBoxSerials;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBoxSerials;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_SpmSmPackagedBoxSerials = null;
            lcl_obj_SpmSmPackagedBoxSerials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_TmpSpmSmPackagedBoxSerials = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials();
                lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_SERIAL_CODE"].ToString());
                lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString()); 
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmSmPackagedBoxSerials;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBoxSerials;
        }

        public CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_SpmSmPackagedBoxSerials = null;
            lcl_obj_SpmSmPackagedBoxSerials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_TmpSpmSmPackagedBoxSerials = new SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials();
                    lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_SERIAL_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString()); 
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmSmPackagedBoxSerials;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmSmPackagedBoxSerials;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials> lcl_objlist_SpmSmPackagedBoxSerialsList = null;
            lcl_objlist_SpmSmPackagedBoxSerialsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials> lcl_objlist_TmpSpmSmPackagedBoxSerialsList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmSmPackagedBoxSerialsList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_TmpSpmSmPackagedBoxSerials = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials();
                    lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_SERIAL_CODE"].ToString());
                    lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                    lcl_objlist_TmpSpmSmPackagedBoxSerialsList.Add(lcl_obj_TmpSpmSmPackagedBoxSerials);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmSmPackagedBoxSerialsList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPackagedBoxSerialsList;
        }

        public List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials> lcl_objlist_SpmSmPackagedBoxSerialsList = null;
            lcl_objlist_SpmSmPackagedBoxSerialsList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials> lcl_objlist_TmpSpmSmPackagedBoxSerialsList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmSmPackagedBoxSerialsList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials lcl_obj_TmpSpmSmPackagedBoxSerials = new CCL.BusinessEntities.SPM.SM.SpmSmPackagedBoxSerials();
                        lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxSerialCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_SERIAL_CODE"].ToString());
                        lcl_obj_TmpSpmSmPackagedBoxSerials.SmPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SM_PACKAGED_BOX_CODE"].ToString());
                        lcl_objlist_TmpSpmSmPackagedBoxSerialsList.Add(lcl_obj_TmpSpmSmPackagedBoxSerials);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmSmPackagedBoxSerialsList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmSmPackagedBoxSerialsList;
        }
    }
}
