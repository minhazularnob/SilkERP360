using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
   public class ScpmSmPeelOffQCManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>
    {
       public ScpmSmPeelOffQCManager()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC IP_obj_ScpmSmPeelOffQC, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_SMPeelOffCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SM_PEEL_OFF_QC.NEXTVAL AS ID FROM DUAL");
           lcl_ui64_SMPeelOffCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScpmSmPeelOffQC.SMPeelOffCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScpmSmPeelOffQC.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_SMPeelOffCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC IP_obj_A)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_ScpmSmPeelOffQC = null;
           lcl_obj_ScpmSmPeelOffQC = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SM_PEEL_OFF_QC SM_PEEL_OFF_CODE= {0} and STATUS = {1} ", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_TmpScpmSmPeelOffQC = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC();
               lcl_obj_TmpScpmSmPeelOffQC.SMPeelOffCode = System.UInt64.Parse(lcl_obj_dr["SM_PEEL_OFF_CODE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.Sequence = System.UInt32.Parse(lcl_obj_dr["SHEET_SEQUENCE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.TestDateTime = System.DateTime.Parse(lcl_obj_dr["DATE_TIME"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.PeelOffPercentage = System.UInt64.Parse(lcl_obj_dr["PEEL_OFF_PERCENTAGE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.Status =  (CCL.Enums.SCPM.QCTestResult)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
               //lcl_obj_TmpScpmSmPeelOffQC.SMQCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.PossibleGlitch = lcl_obj_dr["POSSIBLE_GLITCH"].ToString();
               
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmPeelOffQC;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmPeelOffQC;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_ScpmSmPeelOffQC = null;
           lcl_obj_ScpmSmPeelOffQC = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select * From SCPM_SM_PEEL_OFF_QC SM_PEEL_OFF_CODE= {0} and STATUS = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_TmpScpmSmPeelOffQC = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC();
                   lcl_obj_TmpScpmSmPeelOffQC.SMPeelOffCode = System.UInt64.Parse(lcl_obj_dr["SM_PEEL_OFF_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.Sequence = System.UInt32.Parse(lcl_obj_dr["SHEET_SEQUENCE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.TestDateTime = System.DateTime.Parse(lcl_obj_dr["DATE_TIME"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.PeelOffPercentage = System.UInt64.Parse(lcl_obj_dr["PEEL_OFF_PERCENTAGE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.Status = (CCL.Enums.SCPM.QCTestResult) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   //lcl_obj_TmpScpmSmPeelOffQC.SMQCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.PossibleGlitch = lcl_obj_dr["POSSIBLE_GLITCH"].ToString();
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmPeelOffQC;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmPeelOffQC;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> lcl_objlist_ScpmSmPeelOffQC = null;
           lcl_objlist_ScpmSmPeelOffQC = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>>(() =>
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
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> lcl_objlist_TmpScpmSmPeelOffQC = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>();
                   while (lcl_obj_dr.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_TmpScpmSmPeelOffQC = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC();
                       lcl_obj_TmpScpmSmPeelOffQC.SMPeelOffCode = System.UInt64.Parse(lcl_obj_dr["SM_PEEL_OFF_CODE"].ToString());
                       lcl_obj_TmpScpmSmPeelOffQC.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                       lcl_obj_TmpScpmSmPeelOffQC.Sequence = System.UInt32.Parse(lcl_obj_dr["SHEET_SEQUENCE"].ToString());
                       lcl_obj_TmpScpmSmPeelOffQC.TestDateTime = System.DateTime.Parse(lcl_obj_dr["DATE_TIME"].ToString());
                       lcl_obj_TmpScpmSmPeelOffQC.PeelOffPercentage = System.UInt64.Parse(lcl_obj_dr["PEEL_OFF_PERCENTAGE"].ToString());
                       lcl_obj_TmpScpmSmPeelOffQC.Status = (CCL.Enums.SCPM.QCTestResult)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                       //lcl_obj_TmpScpmSmPeelOffQC.SMQCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                       lcl_obj_TmpScpmSmPeelOffQC.PossibleGlitch = lcl_obj_dr["POSSIBLE_GLITCH"].ToString();
                       lcl_objlist_TmpScpmSmPeelOffQC.Add(lcl_obj_TmpScpmSmPeelOffQC);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScpmSmPeelOffQC;
               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmPeelOffQC;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> lcl_objlist_ScpmSmPeelOffQC = null;
           lcl_objlist_ScpmSmPeelOffQC = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>>(() =>
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
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> lcl_objlist_TmpScpmSmPeelOffQC = new
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>();
               while (lcl_obj_dr.Read())
               {
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_TmpScpmSmPeelOffQC = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC();
                   lcl_obj_TmpScpmSmPeelOffQC.SMPeelOffCode = System.UInt64.Parse(lcl_obj_dr["SM_PEEL_OFF_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.Sequence = System.UInt32.Parse(lcl_obj_dr["SHEET_SEQUENCE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.TestDateTime = System.DateTime.Parse(lcl_obj_dr["DATE_TIME"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.PeelOffPercentage = System.UInt64.Parse(lcl_obj_dr["PEEL_OFF_PERCENTAGE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.Status = (CCL.Enums.SCPM.QCTestResult) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   //lcl_obj_TmpScpmSmPeelOffQC.SMQCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.PossibleGlitch = lcl_obj_dr["POSSIBLE_GLITCH"].ToString();
                   lcl_objlist_TmpScpmSmPeelOffQC.Add(lcl_obj_TmpScpmSmPeelOffQC);
               }
               lcl_obj_dr.Close();
               return lcl_objlist_TmpScpmSmPeelOffQC;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmSmPeelOffQC;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_ScpmSmPeelOffQCC = null;
           lcl_obj_ScpmSmPeelOffQCC = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>(() =>
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
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_TmpScpmSmPeelOffQC = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC();
               lcl_obj_TmpScpmSmPeelOffQC.SMPeelOffCode = System.UInt64.Parse(lcl_obj_dr["SM_PEEL_OFF_CODE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.Sequence = System.UInt32.Parse(lcl_obj_dr["SHEET_SEQUENCE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.TestDateTime = System.DateTime.Parse(lcl_obj_dr["DATE_TIME"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.PeelOffPercentage = System.UInt64.Parse(lcl_obj_dr["PEEL_OFF_PERCENTAGE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.Status = (CCL.Enums.SCPM.QCTestResult) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
               //lcl_obj_TmpScpmSmPeelOffQC.SMQCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
               lcl_obj_TmpScpmSmPeelOffQC.PossibleGlitch = lcl_obj_dr["POSSIBLE_GLITCH"].ToString();
               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmSmPeelOffQC;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmPeelOffQCC;
       }

       public CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_ScpmSmPeelOffQC = null;
           lcl_obj_ScpmSmPeelOffQC = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC>(() =>
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
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC lcl_obj_TmpScpmSmPeelOffQC = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC();
                   lcl_obj_TmpScpmSmPeelOffQC.SMPeelOffCode = System.UInt64.Parse(lcl_obj_dr["SM_PEEL_OFF_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.SMQCMasterCode = System.UInt64.Parse(lcl_obj_dr["SM_QC_MASTER_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.Sequence = System.UInt32.Parse(lcl_obj_dr["SHEET_SEQUENCE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.TestDateTime = System.DateTime.Parse(lcl_obj_dr["DATE_TIME"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.PeelOffPercentage = System.UInt64.Parse(lcl_obj_dr["PEEL_OFF_PERCENTAGE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.Status = (CCL.Enums.SCPM.QCTestResult) System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   //lcl_obj_TmpScpmSmPeelOffQC.SMQCEngineerCode = System.UInt64.Parse(lcl_obj_dr["QC_ENGINEER_CODE"].ToString());
                   lcl_obj_TmpScpmSmPeelOffQC.PossibleGlitch = lcl_obj_dr["POSSIBLE_GLITCH"].ToString();
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmSmPeelOffQC;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmSmPeelOffQC;
       }
    }
}
