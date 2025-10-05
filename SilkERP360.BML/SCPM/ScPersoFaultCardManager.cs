using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScPersoFaultCardManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
   SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard>
    {
        public ScPersoFaultCardManager()
        {
            this.Initialize();
        }

        public bool SaveSCPersoFaultCardList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard> IP_objLst_SCPersoFaultCardList)
        {
            System.Boolean lcl_b_Return = this.ExceptionManager.Process<System.Boolean>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.InternalResource.Open();
                        }
                        foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard lcl_obj_FaultyCard in IP_objLst_SCPersoFaultCardList)
                        {
                            this.Save(lcl_obj_FaultyCard, lcl_obj_DBManager.InternalResource);
                        }
                        lcl_obj_DBManager.InternalResource.CommitTransaction();
                        lcl_obj_DBManager.InternalResource.Close();
                    }
                    return true;
                }, "BMLExceptionPolicy");
            return lcl_b_Return;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard> lcl_list_details = null;
            lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No FaultyPersoCard Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard();
                    lcl_obj.FaultyCardCode = System.UInt64.Parse(dr["FAULTY_CARD_CODE"].ToString());
                    lcl_obj.BatchCode = System.UInt64.Parse(dr["SC_BATCH_CODE"].ToString());
                    lcl_obj.MachineCode = System.UInt64.Parse(dr["MACHINE_CODE"].ToString());
                    lcl_obj.CardSl = System.UInt64.Parse(dr["CARD_SL"].ToString());
                    lcl_obj.FaultType = System.UInt64.Parse(dr["FAULT_TYPE"].ToString());
                    lcl_obj.FaultDateTime = System.DateTime.Parse(dr["FAULT_DATE_TIME"].ToString());
                    lcl_obj.RePersoed = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(dr["RE_PERSOED"].ToString());
                    lcl_obj.RePersoDateTime = System.DateTime.Parse(dr["RE_PERSO_DATE_TIME"].ToString());
                    lcl_obj.RePersoEmpCode = System.UInt64.Parse(dr["RE_PERSO_EMP_CODE"].ToString());
                    lcl_obj.EntryEmpCode = System.UInt64.Parse(dr["ENTRY_EMP_CODE"].ToString());
                    lcl_obj.Remarks = dr["REMARKS"].ToString();
                    lcl_obj_ListTmp.Add(lcl_obj);
                }
                dr.Close();
                return lcl_obj_ListTmp;
            }, "BMLExceptionPolicy");
            return lcl_list_details;
        }

        //public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScFaultyPersoCard> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        //{
        //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScFaultyPersoCard> lcl_list_details = null;
        //    lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScFaultyPersoCard>>(() =>
        //    {
        //        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
        //        if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
        //        {
        //            lcl_obj_DBManager.Open();
        //        }
        //        System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
        //        if (!(dr.HasRows))
        //        {
        //            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No FaultyPersoCard Data Found In The Database!!!");
        //        }
        //        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScFaultyPersoCard> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScFaultyPersoCard>();
        //        while (dr.Read())
        //        {
        //            SilkERP360.CCL.BusinessEntities.SCPM.ScFaultyPersoCard lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.ScFaultyPersoCard();
        //            lcl_obj.FaultyCardCode = System.UInt64.Parse(dr["FAULTY_CARD_CODE"].ToString());
        //            lcl_obj.ScBatchCode = System.UInt64.Parse(dr["SC_BATCH_CODE"].ToString());
        //            lcl_obj.MachineCode = System.UInt64.Parse(dr["MACHINE_CODE"].ToString());
        //            lcl_obj.CardSl = System.UInt64.Parse(dr["CARD_SL"].ToString());
        //            lcl_obj.FaultType = System.UInt64.Parse(dr["FAULT_TYPE"].ToString());
        //            lcl_obj.FaultDateTime = System.DateTime.Parse(dr["FAULT_DATE_TIME"].ToString());
        //            lcl_obj.RePersoed = System.UInt64.Parse(dr["RE_PERSOED"].ToString());
        //            lcl_obj.RePersoDateTime = System.DateTime.Parse(dr["RE_PERSO_DATE_TIME"].ToString());
        //            lcl_obj.RePersoEmpCode = System.UInt64.Parse(dr["RE_PERSO_EMP_CODE"].ToString());
        //            lcl_obj.EntryEmpCode = System.UInt64.Parse(dr["ENTRY_EMP_CODE"].ToString());
        //            lcl_obj.Remarks = dr["REMARKS"].ToString();
        //            lcl_obj_ListTmp.Add(lcl_obj);
        //        }
        //        dr.Close();
        //        return lcl_obj_ListTmp;
        //    }, "BMLExceptionPolicy");
        //    return lcl_list_details;
        //}
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard lcl_obj_FaultyPersoCard, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_FaultyPersoCard = 0;
            lcl_ui64_FaultyPersoCard = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

                System.Data.OracleClient.OracleParameter lcl_obj_FaultyCardCode = new System.Data.OracleClient.OracleParameter("p_FAULTY_CARD_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_FaultyCardCode.Direction = System.Data.ParameterDirection.Output;
                
                System.Data.OracleClient.OracleParameter lcl_obj_ScBatchCode = new System.Data.OracleClient.OracleParameter("p_SC_BATCH_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ScBatchCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ScBatchCode.Value = lcl_obj_FaultyPersoCard.BatchCode;

                System.Data.OracleClient.OracleParameter lcl_obj_MachineCode = new System.Data.OracleClient.OracleParameter("p_MACHINE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_MachineCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MachineCode.Value = lcl_obj_FaultyPersoCard.MachineCode;

                System.Data.OracleClient.OracleParameter lcl_obj_CardSl = new System.Data.OracleClient.OracleParameter("p_CARD_SL", System.Data.OracleClient.OracleType.Number);
                lcl_obj_CardSl.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CardSl.Value = lcl_obj_FaultyPersoCard.CardSl;

                System.Data.OracleClient.OracleParameter lcl_obj_FaultType = new System.Data.OracleClient.OracleParameter("p_FAULT_TYPE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_FaultType.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_FaultType.Value = lcl_obj_FaultyPersoCard.FaultType;

                //System.Data.OracleClient.OracleParameter lcl_obj_FaultDateTime = new System.Data.OracleClient.OracleParameter("p_FAULT_DATE_TIME", System.Data.OracleClient.OracleType.DateTime);
                //lcl_obj_FaultDateTime.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_FaultDateTime.Value = lcl_obj_FaultyPersoCard.FaultDateTime;

                //System.Data.OracleClient.OracleParameter lcl_obj_RePersoed = new System.Data.OracleClient.OracleParameter("p_RE_PERSOED", System.Data.OracleClient.OracleType.Number);
                //lcl_obj_RePersoed.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_RePersoed.Value = lcl_obj_FaultyPersoCard.RePersoed;

                //System.Data.OracleClient.OracleParameter lcl_obj_RePersoDateTime = new System.Data.OracleClient.OracleParameter("p_RE_PERSO_DATE_TIME", System.Data.OracleClient.OracleType.DateTime);
                //lcl_obj_RePersoDateTime.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_RePersoDateTime.Value = lcl_obj_FaultyPersoCard.RePersoDateTime;

                //System.Data.OracleClient.OracleParameter lcl_obj_RePersoEmpCode = new System.Data.OracleClient.OracleParameter("p_RE_PERSO_EMP_CODE", System.Data.OracleClient.OracleType.Number);
                //lcl_obj_RePersoEmpCode.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_RePersoEmpCode.Value = lcl_obj_FaultyPersoCard.RePersoEmpCode;

                System.Data.OracleClient.OracleParameter lcl_obj_EntryEmpCode = new System.Data.OracleClient.OracleParameter("p_ENTRY_EMP_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EntryEmpCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EntryEmpCode.Value = lcl_obj_FaultyPersoCard.EntryEmpCode;

                System.Data.OracleClient.OracleParameter lcl_obj_Remarks = new System.Data.OracleClient.OracleParameter("p_REMARKS", System.Data.OracleClient.OracleType.NVarChar, 521);
                lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Remarks.Value = lcl_obj_FaultyPersoCard.Remarks;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_FaultyCardCode, lcl_obj_ScBatchCode, lcl_obj_MachineCode, lcl_obj_CardSl, lcl_obj_FaultType, lcl_obj_EntryEmpCode, lcl_obj_Remarks };
                lcl_obj_DBManager.ExecuteStoredProcedure("INS_SCPM_SC_FAULTY_PERSO_CARD", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_FaultyCardCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_FaultyPersoCard;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard lcl_obj_FaultyPersoCard)
        {
            System.UInt64 lcl_ui64_FaultyPersoCard = 0;
            lcl_ui64_FaultyPersoCard = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_FaultyCardCode = new System.Data.OracleClient.OracleParameter("p_FAULTY_CARD_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_FaultyCardCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_FaultyCardCode.Value = lcl_obj_FaultyPersoCard.FaultyCardCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_ScBatchCode = new System.Data.OracleClient.OracleParameter("p_SC_BATCH_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ScBatchCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ScBatchCode.Value = lcl_obj_FaultyPersoCard.BatchCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_MachineCode = new System.Data.OracleClient.OracleParameter("p_MACHINE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_MachineCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_MachineCode.Value = lcl_obj_FaultyPersoCard.MachineCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_CardSl = new System.Data.OracleClient.OracleParameter("p_CARD_SL", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_CardSl.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CardSl.Value = lcl_obj_FaultyPersoCard.CardSl;
                    System.Data.OracleClient.OracleParameter lcl_obj_FaultType = new System.Data.OracleClient.OracleParameter("p_FAULT_TYPE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_FaultType.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_FaultType.Value = lcl_obj_FaultyPersoCard.FaultType;
                    System.Data.OracleClient.OracleParameter lcl_obj_FaultDateTime = new System.Data.OracleClient.OracleParameter("p_FAULT_DATE_TIME", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_FaultDateTime.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_FaultDateTime.Value = lcl_obj_FaultyPersoCard.FaultDateTime;
                    System.Data.OracleClient.OracleParameter lcl_obj_RePersoed = new System.Data.OracleClient.OracleParameter("p_RE_PERSOED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_RePersoed.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RePersoed.Value = lcl_obj_FaultyPersoCard.RePersoed;
                    System.Data.OracleClient.OracleParameter lcl_obj_RePersoDateTime = new System.Data.OracleClient.OracleParameter("p_RE_PERSO_DATE_TIME", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_RePersoDateTime.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RePersoDateTime.Value = lcl_obj_FaultyPersoCard.RePersoDateTime;
                    System.Data.OracleClient.OracleParameter lcl_obj_RePersoEmpCode = new System.Data.OracleClient.OracleParameter("p_RE_PERSO_EMP_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_RePersoEmpCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RePersoEmpCode.Value = lcl_obj_FaultyPersoCard.RePersoEmpCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_EntryEmpCode = new System.Data.OracleClient.OracleParameter("p_ENTRY_EMP_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EntryEmpCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EntryEmpCode.Value = lcl_obj_FaultyPersoCard.EntryEmpCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_Remarks = new System.Data.OracleClient.OracleParameter("p_REMARKS", System.Data.OracleClient.OracleType.NVarChar, 512);
                    lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Remarks.Value = lcl_obj_FaultyPersoCard.Remarks;
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_FaultyCardCode, lcl_obj_ScBatchCode, lcl_obj_MachineCode, lcl_obj_CardSl, lcl_obj_FaultType, lcl_obj_FaultDateTime, lcl_obj_RePersoed, lcl_obj_RePersoDateTime, lcl_obj_RePersoEmpCode, lcl_obj_EntryEmpCode, lcl_obj_Remarks };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("SCPM_SC_FAULTY_PERSO_CARD_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_FaultyCardCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_FaultyPersoCard;
        }


        public CCL.BusinessEntities.SCPM.ScPersoFaultCard Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScPersoFaultCard Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScPersoFaultCard Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScPersoFaultCard Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.SCPM.ScPersoFaultCard> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
