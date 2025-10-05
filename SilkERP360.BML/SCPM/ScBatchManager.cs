using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
   public class ScBatchManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch>
    {
       public ScBatchManger()
        {
            this.Initialize();
        }
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch> lcl_list_details = null;
            lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No Batch Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.ScBatch lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.ScBatch();
                    lcl_obj.BatchCode = System.UInt64.Parse(dr["SC_BATCH_CODE"].ToString());
                    lcl_obj.ScBatchName = dr["SC_BATCH"].ToString();
                    lcl_obj.ScJOCode = System.UInt64.Parse(dr["SC_J_O_CODE"].ToString());
                    lcl_obj.Quantity = System.UInt64.Parse(dr["QUANTITY"].ToString());
                    lcl_obj.StartSl = System.UInt64.Parse(dr["START_SL"].ToString());
                    lcl_obj.EndSl = System.UInt64.Parse(dr["END_SL"].ToString());
                    lcl_obj.ProductionStatus = (SilkERP360.CCL.SCPMEnumerations.JobOrderProductionStatus)System.Int32.Parse(dr["PRODUCTION_STATUS"].ToString());
                    lcl_obj.Status = (SilkERP360.CCL.SCPMEnumerations.Status)System.Int32.Parse(dr["STATUS"].ToString());
                    lcl_obj_ListTmp.Add(lcl_obj);
                }
                dr.Close();
                return lcl_obj_ListTmp;
            }, "BMLExceptionPolicy");
            return lcl_list_details;
        }

        //public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        //{
        //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch> lcl_list_details = null;
        //    lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch>>(() =>
        //    {
        //        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
        //        if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
        //        {
        //            lcl_obj_DBManager.Open();
        //        }
        //        System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
        //        if (!(dr.HasRows))
        //        {
        //            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No Batch Data Found In The Database!!!");
        //        }
        //        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScBatch>();
        //        while (dr.Read())
        //        {
        //            SilkERP360.CCL.BusinessEntities.SCPM.ScBatch lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.ScBatch();
        //            lcl_obj.BatchCode= System.UInt16.Parse(dr["SC_BATCH_CODE"].ToString());
        //            lcl_obj.ScBatch = dr["SC_BATCH"].ToString();
        //            lcl_obj.ScJOCode = System.UInt64.Parse(dr["SC_J_O_CODE"].ToString());
        //            lcl_obj.Quantity = System.UInt64.Parse(dr["QUANTITY"].ToString());
        //            lcl_obj.StartSl = System.UInt64.Parse(dr["START_SL"].ToString());
        //            lcl_obj.EndSl = System.UInt64.Parse(dr["END_SL"].ToString());
        //            lcl_obj.ProductionStatus = System.UInt64.Parse(dr["PRODUCTION_STATUS"].ToString());
        //            lcl_obj.Status = System.UInt16.Parse(dr["STATUS"].ToString());
        //            lcl_obj_ListTmp.Add(lcl_obj);
        //        }
        //        dr.Close();
        //        return lcl_obj_ListTmp;
        //    }, "BMLExceptionPolicy");
        //    return lcl_list_details;
        //}
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.ScBatch lcl_obj_Batch, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_Batch = 0;
            lcl_ui64_Batch = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_ScBatchCode = new System.Data.OracleClient.OracleParameter("p_SC_BATCH_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ScBatchCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ScBatchCode.Value = lcl_obj_Batch.BatchCode;
                System.Data.OracleClient.OracleParameter lcl_obj_ScBatch = new System.Data.OracleClient.OracleParameter("p_SC_BATCH", System.Data.OracleClient.OracleType.NVarChar,256);
                lcl_obj_ScBatch.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ScBatch.Value = lcl_obj_Batch.ScBatchName;
                System.Data.OracleClient.OracleParameter lcl_obj_ScJOCode = new System.Data.OracleClient.OracleParameter("p_SC_J_O_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ScJOCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ScJOCode.Value = lcl_obj_Batch.ScJOCode;
                System.Data.OracleClient.OracleParameter lcl_obj_Quantity = new System.Data.OracleClient.OracleParameter("p_QUANTITY", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Quantity.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Quantity.Value = lcl_obj_Batch.Quantity;
                System.Data.OracleClient.OracleParameter lcl_obj_StartSl = new System.Data.OracleClient.OracleParameter("p_START_SL", System.Data.OracleClient.OracleType.Number);
                lcl_obj_StartSl.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_StartSl.Value = (System.Object)lcl_obj_Batch.StartSl;
                System.Data.OracleClient.OracleParameter lcl_obj_EndSl = new System.Data.OracleClient.OracleParameter("p_END_SL", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EndSl.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EndSl.Value = (System.Object)lcl_obj_Batch.EndSl;
                System.Data.OracleClient.OracleParameter lcl_obj_ProductionStatus = new System.Data.OracleClient.OracleParameter("p_PRODUCTION_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ProductionStatus.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ProductionStatus.Value = lcl_obj_Batch.ProductionStatus;
                System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("p_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_Batch.Status;
                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ScBatchCode, lcl_obj_ScBatch, lcl_obj_ScJOCode, lcl_obj_Quantity, lcl_obj_StartSl, lcl_obj_EndSl, lcl_obj_ProductionStatus, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.Batch_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_ScBatchCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_Batch;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.ScBatch lcl_obj_Batch)
        {
            System.UInt64 lcl_ui64_Batch = 0;
            lcl_ui64_Batch = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_ScBatchCode = new System.Data.OracleClient.OracleParameter("p_SC_BATCH_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ScBatchCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ScBatchCode.Value = lcl_obj_Batch.BatchCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_ScBatch = new System.Data.OracleClient.OracleParameter("p_SC_BATCH", System.Data.OracleClient.OracleType.NVarChar,256);
                    lcl_obj_ScBatch.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ScBatch.Value = lcl_obj_Batch.ScBatchName;
                    System.Data.OracleClient.OracleParameter lcl_obj_ScJOCode = new System.Data.OracleClient.OracleParameter("p_SC_J_O_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ScJOCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ScJOCode.Value = lcl_obj_Batch.ScJOCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_Quantity = new System.Data.OracleClient.OracleParameter("p_QUANTITY", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Quantity.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Quantity.Value = lcl_obj_Batch.Quantity;
                    System.Data.OracleClient.OracleParameter lcl_obj_StartSl = new System.Data.OracleClient.OracleParameter("p_START_SL", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_StartSl.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_StartSl.Value = (System.Object)lcl_obj_Batch.StartSl;
                    System.Data.OracleClient.OracleParameter lcl_obj_EndSl = new System.Data.OracleClient.OracleParameter("p_END_SL", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EndSl.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EndSl.Value = (System.Object)lcl_obj_Batch.EndSl;
                    System.Data.OracleClient.OracleParameter lcl_obj_ProductionStatus = new System.Data.OracleClient.OracleParameter("p_PRODUCTION_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ProductionStatus.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ProductionStatus.Value = lcl_obj_Batch.ProductionStatus;
                    System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("p_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_Batch.Status;
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ScBatchCode, lcl_obj_ScBatch, lcl_obj_ScJOCode, lcl_obj_Quantity, lcl_obj_StartSl, lcl_obj_EndSl, lcl_obj_ProductionStatus, lcl_obj_Status};
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.Batch_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_ScBatchCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_Batch;
        }


        public CCL.BusinessEntities.SCPM.ScBatch Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScBatch Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScBatch Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScBatch Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.SCPM.ScBatch> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.Save(CCL.BusinessEntities.SCPM.ScBatch IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.Save(CCL.BusinessEntities.SCPM.ScBatch IP_obj_A)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.SCPM.ScBatch CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.SCPM.ScBatch CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.SCPM.ScBatch CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.SCPM.ScBatch CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.SCPM.ScBatch> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.SCPM.ScBatch> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.SCPM.ScBatch>.GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
