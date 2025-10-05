using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmSmMasterBatchManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>
    {
        public ScpmSmMasterBatchManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmMasterBatch IP_obj_A, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_MasterBatchCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_MASTER_BATCH.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_MasterBatchCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_A.MasterBatchCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_MasterBatchCode;
        }

        public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmMasterBatch IP_obj_A)
        {
            System.UInt64 lcl_ui64_MasterBatchCode = 0;
            System.String lcl_str_SqlQuery = System.String.Empty;
            System.UInt64 lcl_ui64_ID = 0;
            lcl_ui64_MasterBatchCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                
                using(var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    /************************************************************************************************************************/
                    //check if MasterBatch already saved in system
                    lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_MASTER_BATCH WHERE MASTER_BATCH = '{0}'", IP_obj_A.MasterBatch);
                    //System.Int32 lcl_i32_MasterBatchCount = lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);
                    System.Data.OracleClient.OracleDataReader lcl_obj_MasterBatchReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    /************************************************************************************************************************/
                    if (lcl_obj_MasterBatchReader.HasRows == false)
                    {
                        lcl_obj_MasterBatchReader.Close();
                        //MasterBatch Not saved. Save MasterBatch
                        lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_MASTER_BATCH.NEXTVAL AS ID FROM DUAL");
                        System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                        lcl_obj_IDReader.Read();
                        lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                        lcl_obj_IDReader.Close();
                        IP_obj_A.MasterBatchCode = lcl_ui64_ID;
                        System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);

                    }
                    else
                    {
                        //MasterBatch has already been saved. Get MasterBatch details
                        lcl_obj_MasterBatchReader.Read();
                        IP_obj_A.MasterBatchCode = System.UInt64.Parse(lcl_obj_MasterBatchReader["MASTER_BATCH_CODE"].ToString());
                        IP_obj_A.TotalQuantity = System.UInt32.Parse(lcl_obj_MasterBatchReader["TOTAL_QUANTITY"].ToString());
                        IP_obj_A.TotalWastageQuantity = System.UInt32.Parse(lcl_obj_MasterBatchReader["TOTAL_WASTAGE"].ToString());
                        IP_obj_A.TotalReleasedQuantity = System.UInt32.Parse(lcl_obj_MasterBatchReader["TOTAL_RELEASED"].ToString());
                        IP_obj_A.TotalStockQuantity = System.UInt16.Parse(lcl_obj_MasterBatchReader["TOTAL_REMAINING"].ToString());
                        IP_obj_A.MasterBatchDate = System.DateTime.Parse(lcl_obj_MasterBatchReader["MASTER_BATCH_DATE"].ToString());
                        IP_obj_A.Status = (CCL.Enums.SCPM.SMMasterBatchStatus)System.UInt16.Parse(lcl_obj_MasterBatchReader["STATUS"].ToString());
                        lcl_obj_MasterBatchReader.Close();
                    }

                    if (IP_obj_A.ScpmSmSubBatchList.Count > 0)
                    {
                        //Save SubBatchList
                        SilkERP360.BML.SCPM.ScpmSmSubBatchManager lcl_obj_ScpmSubBatchManager = new ScpmSmSubBatchManager();
                        foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch lcl_obj_ScpmSmSubBatch in IP_obj_A.ScpmSmSubBatchList)
                        {
                            lcl_obj_ScpmSmSubBatch.MasterBatchCode = IP_obj_A.MasterBatchCode;
                            System.UInt64 lcl_ui64_ScpmSmSubBatchCode = lcl_obj_ScpmSubBatchManager.Save(lcl_obj_ScpmSmSubBatch, lcl_obj_DBManager.InternalResource);
                            //Save InputBatchReference
                            if (lcl_obj_ScpmSmSubBatch.SMInputBatchRefList.Count > 0)
                            {
                                SilkERP360.BML.SCPM.ScpmSmInputBatchRefManager lcl_obj_ScpmSmInputBatchRefManager = new ScpmSmInputBatchRefManager();
                                foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef lcl_obj_InputBatchRef in lcl_obj_ScpmSmSubBatch.SMInputBatchRefList)
                                {
                                    lcl_obj_InputBatchRef.BatchCode = lcl_ui64_ScpmSmSubBatchCode;
                                    lcl_obj_ScpmSmInputBatchRefManager.Save(lcl_obj_InputBatchRef, lcl_obj_DBManager.InternalResource);
                                }
                            }
                            if (lcl_obj_ScpmSmSubBatch.SMQCMasterList.Count > 0)
                            {
                                SilkERP360.BML.SCPM.ScpmSmQCMasterManager lcl_obj_ScpmSmQCMasterManager = new SilkERP360.BML.SCPM.ScpmSmQCMasterManager();
                                foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster in lcl_obj_ScpmSmSubBatch.SMQCMasterList)
                                {
                                    lcl_obj_ScpmSmQCMaster.BatchCode = lcl_ui64_ScpmSmSubBatchCode;
                                    lcl_obj_ScpmSmQCMasterManager.Save(lcl_obj_ScpmSmQCMaster, lcl_obj_DBManager.InternalResource);
                                }
                            }
                            /******************************************************************************************************************/
                            //Save Vendor Ref
                            //if (lcl_obj_ScpmSmSubBatch.RMVendorRefList.Count > 0)
                            //{
                            //    SilkERP360.BML.SCPM. lcl_obj_ScpmSmQCMasterManager = new SilkERP360.BML.SCPM.ScpmSmQCMasterManager();
                            //    foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster lcl_obj_ScpmSmQCMaster in lcl_obj_ScpmSmSubBatch.SMQCMasterList)
                            //    {
                            //        lcl_obj_ScpmSmQCMaster.BatchCode = lcl_ui64_ScpmSmSubBatchCode;
                            //        lcl_obj_ScpmSmQCMasterManager.Save(lcl_obj_ScpmSmQCMaster, lcl_obj_DBManager.InternalResource);
                            //    }
                            //}
                            /******************************************************************************************************************/
                        }
                        /******************************************************************************************************************/
                        //Update MasterBatch Quantity
                        System.String lcl_str_SqlUpdate = System.String.Format("UPDATE SCPM_MASTER_BATCH SET TOTAL_QUANTITY = TOTAL_QUANTITY + {0},TOTAL_WASTAGE = TOTAL_WASTAGE + {1} WHERE MASTER_BATCH_CODE = {2}",
                            IP_obj_A.ScpmSmSubBatchList[0].Quantity, IP_obj_A.ScpmSmSubBatchList[0].Wastage, IP_obj_A.MasterBatchCode);
                        int a = lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlUpdate);
                        /******************************************************************************************************************/
                    }
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    return lcl_ui64_ID;
                }
             }, "BMLExceptionPolicy");
            return lcl_ui64_MasterBatchCode;
        }

        public CCL.BusinessEntities.SCPM.ScpmSmMasterBatch Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_ScpmSmMasterBatch = null;
            lcl_obj_ScpmSmMasterBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_MASTER_BATCH MASTER_BATCH_CODE= {0} and STATUS = {1} ", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_TmpScpmSmMasterBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch();
                lcl_obj_TmpScpmSmMasterBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.MasterBatch = lcl_obj_dr["MASTER_BATCH"].ToString();
                lcl_obj_TmpScpmSmMasterBatch.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.ProcessCode = System.UInt64.Parse(lcl_obj_dr["PROCESS_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.JobOrderCode = System.UInt32.Parse(lcl_obj_dr["JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_QUANTITY"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalWastageQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_WASTAGE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalReleasedQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalStockQuantity = System.UInt16.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.MasterBatchDate = System.DateTime.Parse(lcl_obj_dr["MASTER_BATCH_DATE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.Status = (CCL.Enums.SCPM.SMMasterBatchStatus) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();

                //get SCPM_BATCH
                lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_BATCH WHERE MASTER_BATCH_CODE = {0}", lcl_obj_TmpScpmSmMasterBatch.MasterBatchCode);
                SilkERP360.BML.SCPM.ScpmSmSubBatchManager lcl_obj_ScpmSmSubBatchManager = new ScpmSmSubBatchManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> lcl_objLst_ScpmSmSubBatch = lcl_obj_ScpmSmSubBatchManager.GetList(lcl_str_SqlQuery, lcl_obj_DBManager);
                lcl_obj_TmpScpmSmMasterBatch.ScpmSmSubBatchList = lcl_objLst_ScpmSmSubBatch;

                lcl_obj_DBManager.Close();
                return lcl_obj_TmpScpmSmMasterBatch;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScpmSmMasterBatch;
        }

        public CCL.BusinessEntities.SCPM.ScpmSmMasterBatch Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_ScpmSmMasterBatch = null;
            lcl_obj_ScpmSmMasterBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select * From SCPM_MASTER_BATCH MASTER_BATCH_CODE= {0} and STATUS = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_TmpScpmSmMasterBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch();
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatch = lcl_obj_dr["MASTER_BATCH"].ToString();
                    lcl_obj_TmpScpmSmMasterBatch.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.ProcessCode = System.UInt64.Parse(lcl_obj_dr["PROCESS_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.JobOrderCode = System.UInt32.Parse(lcl_obj_dr["JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_QUANTITY"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalWastageQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_WASTAGE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalReleasedQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalStockQuantity = System.UInt16.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatchDate = System.DateTime.Parse(lcl_obj_dr["MASTER_BATCH_DATE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.Status = (CCL.Enums.SCPM.SMMasterBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());

                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScpmSmMasterBatch;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScpmSmMasterBatch;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch> lcl_objlist_ScpmSmMasterBatch = null;
            lcl_objlist_ScpmSmMasterBatch = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch> lcl_objlist_TmpScpmSmMasterBatch = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_TmpScpmSmMasterBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch();
                        lcl_obj_TmpScpmSmMasterBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.MasterBatch = lcl_obj_dr["MASTER_BATCH"].ToString();
                        lcl_obj_TmpScpmSmMasterBatch.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.ProcessCode = System.UInt64.Parse(lcl_obj_dr["PROCESS_CODE"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.JobOrderCode = System.UInt32.Parse(lcl_obj_dr["JOB_ORDER_CODE"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.TotalQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_QUANTITY"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.TotalWastageQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_WASTAGE"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.TotalReleasedQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.TotalStockQuantity = System.UInt16.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.MasterBatchDate = System.DateTime.Parse(lcl_obj_dr["MASTER_BATCH_DATE"].ToString());
                        lcl_obj_TmpScpmSmMasterBatch.Status = (CCL.Enums.SCPM.SMMasterBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_TmpScpmSmMasterBatch.Add(lcl_obj_TmpScpmSmMasterBatch);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpScpmSmMasterBatch;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScpmSmMasterBatch;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch> lcl_objlist_ScpmSmMasterBatch = null;
            lcl_objlist_ScpmSmMasterBatch = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return null;
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch> lcl_objlist_TmpScpmSmMasterBatch = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_TmpScpmSmMasterBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch();
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatch = lcl_obj_dr["MASTER_BATCH"].ToString();
                    lcl_obj_TmpScpmSmMasterBatch.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.ProcessCode = System.UInt64.Parse(lcl_obj_dr["PROCESS_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.JobOrderCode = System.UInt32.Parse(lcl_obj_dr["JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_QUANTITY"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalWastageQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_WASTAGE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalReleasedQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalStockQuantity = System.UInt16.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatchDate = System.DateTime.Parse(lcl_obj_dr["MASTER_BATCH_DATE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.Status = (CCL.Enums.SCPM.SMMasterBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_TmpScpmSmMasterBatch.Add(lcl_obj_TmpScpmSmMasterBatch);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpScpmSmMasterBatch;
            }, "BMLExceptionPolicy");
            return lcl_objlist_ScpmSmMasterBatch;
        }

        public CCL.BusinessEntities.SCPM.ScpmSmMasterBatch Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_ScpmSmMasterBatch = null;
            lcl_obj_ScpmSmMasterBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>(() =>
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
                SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_TmpScpmSmMasterBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch();
                lcl_obj_TmpScpmSmMasterBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.MasterBatch = lcl_obj_dr["MASTER_BATCH"].ToString();
                lcl_obj_TmpScpmSmMasterBatch.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.ProcessCode = System.UInt64.Parse(lcl_obj_dr["PROCESS_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.JobOrderCode = System.UInt32.Parse(lcl_obj_dr["JOB_ORDER_CODE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_QUANTITY"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalWastageQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_WASTAGE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalReleasedQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.TotalStockQuantity = System.UInt16.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.MasterBatchDate = System.DateTime.Parse(lcl_obj_dr["MASTER_BATCH_DATE"].ToString());
                lcl_obj_TmpScpmSmMasterBatch.Status = (CCL.Enums.SCPM.SMMasterBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpScpmSmMasterBatch;
            }, "BMLExceptionPolicy");
            return lcl_obj_ScpmSmMasterBatch;
        }

        public CCL.BusinessEntities.SCPM.ScpmSmMasterBatch Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_ScpmSmSubBatch = null;
            lcl_obj_ScpmSmSubBatch = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch>(() =>
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
                    lcl_obj_dr.Read();
                    SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch lcl_obj_TmpScpmSmMasterBatch = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmMasterBatch();
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatchCode = System.UInt64.Parse(lcl_obj_dr["MASTER_BATCH_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatch = lcl_obj_dr["MASTER_BATCH"].ToString();
                    lcl_obj_TmpScpmSmMasterBatch.MachineCode = System.UInt64.Parse(lcl_obj_dr["MACHINE_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.ShiftCode = System.UInt64.Parse(lcl_obj_dr["SHIFT_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.ProcessCode = System.UInt64.Parse(lcl_obj_dr["PROCESS_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.JobOrderCode = System.UInt32.Parse(lcl_obj_dr["JOB_ORDER_CODE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_QUANTITY"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalWastageQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_WASTAGE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalReleasedQuantity = System.UInt32.Parse(lcl_obj_dr["TOTAL_RELEASED"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.TotalStockQuantity = System.UInt16.Parse(lcl_obj_dr["TOTAL_REMAINING"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.MasterBatchDate = System.DateTime.Parse(lcl_obj_dr["MASTER_BATCH_DATE"].ToString());
                    lcl_obj_TmpScpmSmMasterBatch.Status = (CCL.Enums.SCPM.SMMasterBatchStatus)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpScpmSmMasterBatch;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_ScpmSmSubBatch;
        }
    }
}
