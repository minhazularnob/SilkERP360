using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmScPackagedBoxManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox>
    {
        public ScpmScPackagedBoxManager()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPackagedBox IP_obj_ScPackagedBox, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ScPackagedBoxCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_PKGED_BOX.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_ScPackagedBoxCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_ScPackagedBox.ScPackagedBoxCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_ScPackagedBox.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScPackagedBoxCode;
        }

        public ulong Save(CCL.BusinessEntities.SCPM.ScpmScPackagedBox IP_obj_ScPackagedBox)
        {
            System.UInt64 lcl_ui64_ScPackagedBoxCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_PKGED_BOX.NEXTVAL AS ID FROM DUAL", IP_obj_ScPackagedBox.GetSequence());
            lcl_ui64_ScPackagedBoxCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_ScPackagedBox.ScPackagedBoxCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_ScPackagedBox.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_ScPackagedBoxCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPackagedBox Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBox = null;
            lcl_obj_ScPackagedBox = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScPackagedBox>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_PACKAGED_BOX WHERE SC_PKGED_BOX_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_TmpScPackagedBox = new CCL.BusinessEntities.SCPM.ScpmScPackagedBox();
                lcl_obj_TmpScPackagedBox.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScIsoPackingCode = System.UInt64.Parse(lcl_obj_dr["SC_ISO_PACKING_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                lcl_obj_TmpScPackagedBox.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                lcl_obj_TmpScPackagedBox.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                lcl_obj_TmpScPackagedBox.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                lcl_obj_TmpScPackagedBox.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpScPackagedBox.BoxStatus = (SilkERP360.CCL.Enums.SPM.SCPackagedBoxStatus)System.UInt16.Parse(lcl_obj_dr["BOX_STATUS"].ToString());

                lcl_obj_dr.Close();
                return lcl_obj_TmpScPackagedBox;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPackagedBox;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPackagedBox Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBox = null;
            lcl_obj_ScPackagedBox = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScPackagedBox>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_PACKAGED_BOX WHERE SC_PKGED_BOX_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_TmpScPackagedBox = new CCL.BusinessEntities.SCPM.ScpmScPackagedBox();
                    lcl_obj_TmpScPackagedBox.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScIsoPackingCode = System.UInt64.Parse(lcl_obj_dr["SC_ISO_PACKING_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                    lcl_obj_TmpScPackagedBox.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpScPackagedBox.BoxStatus = (SilkERP360.CCL.Enums.SPM.SCPackagedBoxStatus)System.UInt16.Parse(lcl_obj_dr["BOX_STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScPackagedBox;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPackagedBox;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPackagedBox Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBox = null;
            lcl_obj_ScPackagedBox = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox>(() =>
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
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_TmpScPackagedBox = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox();
                lcl_obj_TmpScPackagedBox.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScIsoPackingCode = System.UInt64.Parse(lcl_obj_dr["SC_ISO_PACKING_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                lcl_obj_TmpScPackagedBox.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                lcl_obj_TmpScPackagedBox.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                lcl_obj_TmpScPackagedBox.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                lcl_obj_TmpScPackagedBox.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                lcl_obj_TmpScPackagedBox.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                lcl_obj_TmpScPackagedBox.BoxStatus = (SilkERP360.CCL.Enums.SPM.SCPackagedBoxStatus)System.UInt16.Parse(lcl_obj_dr["BOX_STATUS"].ToString());
                lcl_obj_dr.Close();

                return lcl_obj_TmpScPackagedBox;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPackagedBox;
        }

        public CCL.BusinessEntities.SCPM.ScpmScPackagedBox Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_ScPackagedBox = null;
            lcl_obj_ScPackagedBox = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_TmpScPackagedBox = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScPackagedBox();
                    lcl_obj_TmpScPackagedBox.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScIsoPackingCode = System.UInt64.Parse(lcl_obj_dr["SC_ISO_PACKING_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                    lcl_obj_TmpScPackagedBox.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpScPackagedBox.BoxStatus = (SilkERP360.CCL.Enums.SPM.SCPackagedBoxStatus)System.UInt16.Parse(lcl_obj_dr["BOX_STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScPackagedBox;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScPackagedBox;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox> lcl_objlist_ScPackagedBoxList = null;
            lcl_objlist_ScPackagedBoxList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox> lcl_objlist_TmpScPackagedBoxList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpScPackagedBoxList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_TmpScPackagedBox = new CCL.BusinessEntities.SCPM.ScpmScPackagedBox();
                    lcl_obj_TmpScPackagedBox.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScIsoPackingCode = System.UInt64.Parse(lcl_obj_dr["SC_ISO_PACKING_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                    lcl_obj_TmpScPackagedBox.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                    lcl_obj_TmpScPackagedBox.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                    lcl_obj_TmpScPackagedBox.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                    lcl_obj_TmpScPackagedBox.BoxStatus = (SilkERP360.CCL.Enums.SPM.SCPackagedBoxStatus)System.UInt16.Parse(lcl_obj_dr["BOX_STATUS"].ToString());
                    lcl_objlist_TmpScPackagedBoxList.Add(lcl_obj_TmpScPackagedBox);
                }
                lcl_obj_dr.Close();


                return lcl_objlist_TmpScPackagedBoxList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScPackagedBoxList;
        }

        public List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox> lcl_objlist_ScPackagedBoxList = null;
            lcl_objlist_ScPackagedBoxList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox> lcl_objlist_TmpScPackagedBoxList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScPackagedBox>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpScPackagedBoxList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SCPM.ScpmScPackagedBox lcl_obj_TmpScPackagedBox = new CCL.BusinessEntities.SCPM.ScpmScPackagedBox();
                        lcl_obj_TmpScPackagedBox.ScPackagedBoxCode = System.UInt64.Parse(lcl_obj_dr["SC_PKGED_BOX_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.ScIsoPackingCode = System.UInt64.Parse(lcl_obj_dr["SC_ISO_PACKING_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.BoxSerial = System.UInt32.Parse(lcl_obj_dr["BOX_SERIAL"].ToString());
                        lcl_obj_TmpScPackagedBox.ProductCode = System.UInt64.Parse(lcl_obj_dr["PRODUCT_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.ScpmPOItemCode = System.UInt32.Parse(lcl_obj_dr["SCPM_PO_ITEM_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.ScJOItemCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_ITEM_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.ScDataRepoCode = System.UInt64.Parse(lcl_obj_dr["SC_DATA_REPO_CODE"].ToString());
                        lcl_obj_TmpScPackagedBox.BatchName = lcl_obj_dr["BATCH_NAME"].ToString();
                        lcl_obj_TmpScPackagedBox.StartSerial = System.UInt64.Parse(lcl_obj_dr["START_SERIAL"].ToString());
                        lcl_obj_TmpScPackagedBox.EndSerial = System.UInt64.Parse(lcl_obj_dr["END_SERIAL"].ToString());
                        lcl_obj_TmpScPackagedBox.Quantity = System.UInt64.Parse(lcl_obj_dr["QUANTITY"].ToString());
                        lcl_obj_TmpScPackagedBox.BoxStatus = (SilkERP360.CCL.Enums.SPM.SCPackagedBoxStatus)System.UInt16.Parse(lcl_obj_dr["BOX_STATUS"].ToString());
                        lcl_objlist_TmpScPackagedBoxList.Add(lcl_obj_TmpScPackagedBox);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpScPackagedBoxList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScPackagedBoxList;
        }
    }
}
