using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class AcsFileManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.AcsFile>
    {
       public AcsFileManager()
       {
           Initialize(); 
       }


       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.AcsFile IP_obj_AcsFile)
       {

           System.UInt64 lcl_ui64_AcsFileCode = 0;

           lcl_ui64_AcsFileCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                   SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource;
                   if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.Open();
                   }
                   
                   
                   System.Data.OracleClient.OracleParameter lcl_obj_AcsFileCode = new System.Data.OracleClient.OracleParameter("v_AcsFileCode", System.Data.OracleClient.OracleType.Number);
                   lcl_obj_AcsFileCode.Direction = System.Data.ParameterDirection.Output;
                   
                   System.Data.OracleClient.OracleParameter lcl_obj_UploadDate = new System.Data.OracleClient.OracleParameter("v_UploadDate", System.Data.OracleClient.OracleType.DateTime);
                   lcl_obj_UploadDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_UploadDate.Value = DateTime.Now ;//IP_obj_AcsFile.UploadDate;

                   System.Data.OracleClient.OracleParameter lcl_obj_FileHash = new System.Data.OracleClient.OracleParameter("v_FileHash", System.Data.OracleClient.OracleType.NVarChar,32);
                   lcl_obj_FileHash.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_FileHash.Value = "md5"; //IP_obj_AcsFile.FileHash;

                   System.Data.OracleClient.OracleParameter[] lcl_obj_AFSP_Parameters = { lcl_obj_AcsFileCode, lcl_obj_UploadDate, lcl_obj_FileHash};
                   lcl_obj_DBManager.ExecuteStoredProcedure("ACS_FILE_IU", lcl_obj_AFSP_Parameters);
                  

                   System.UInt64 lcl_ui64_AscFileCode = System.UInt64.Parse(lcl_obj_AcsFileCode.Value.ToString());
                   

                   foreach (SilkERP360.CCL.BusinessEntities.HRIS.AcsFileRow lcl_obj_AcsFileRow in IP_obj_AcsFile.AcsFileRows)
                   {
                       System.Data.OracleClient.OracleParameter lcl_obj_AcsFileRowsCode = new System.Data.OracleClient.OracleParameter("v_AcsFileRowsCode", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_AcsFileRowsCode.Direction = System.Data.ParameterDirection.Output;
                       //lcl_obj_AcsFileRowsCode.Value = lcl_obj_AcsFileRow.AcsFileRows;

                       System.Data.OracleClient.OracleParameter lcl_obj_CardOrEmpid = new System.Data.OracleClient.OracleParameter("v_CardOrEmpid", System.Data.OracleClient.OracleType.NVarChar, 10);
                       lcl_obj_CardOrEmpid.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_CardOrEmpid.Value = lcl_obj_AcsFileRow.CardOREmpId;

                       System.Data.OracleClient.OracleParameter lcl_obj_ReaderName = new System.Data.OracleClient.OracleParameter("v_ReaderName", System.Data.OracleClient.OracleType.NVarChar, 32);
                       lcl_obj_ReaderName.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_ReaderName.Value = lcl_obj_AcsFileRow.ReaderName;

                       System.Data.OracleClient.OracleParameter lcl_obj_TransType = new System.Data.OracleClient.OracleParameter("v_TransType", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_TransType.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_TransType.Value = (System.Int32)lcl_obj_AcsFileRow.TransactionType;

                       System.Data.OracleClient.OracleParameter lcl_obj_TransectionDateTime = new System.Data.OracleClient.OracleParameter("v_TransectionDateTime", System.Data.OracleClient.OracleType.DateTime);
                       lcl_obj_TransectionDateTime.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_TransectionDateTime.Value = lcl_obj_AcsFileRow.TransectionDateTime;

                       System.Data.OracleClient.OracleParameter lcl_obj_AcFileCode = new System.Data.OracleClient.OracleParameter("v_AcFileCode", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_AcFileCode.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_AcFileCode.Value = lcl_ui64_AscFileCode;// lcl_obj_AcsFileRow.AcsFileCode;

                       System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_AcsFileRowsCode, lcl_obj_CardOrEmpid, lcl_obj_ReaderName, lcl_obj_TransType, lcl_obj_TransectionDateTime, lcl_obj_AcFileCode };
                       lcl_obj_DBManager.ExecuteStoredProcedure("ACS_FILE_ROWS_IU", lcl_obj_SP_Parameters);
                       
                   }
                  
                   lcl_obj_DBManager.CommitTransaction();

                   return System.UInt64.Parse(lcl_ui64_AcsFileCode.ToString());
               }, "BMLExceptionPolicy");
           return lcl_ui64_AcsFileCode;
       }

       public CCL.BusinessEntities.HRIS.AcsFile Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.AcsFile Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.AcsFile Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.AcsFile Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.HRIS.AcsFile> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public List<CCL.BusinessEntities.HRIS.AcsFile> GetList(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }


       public ulong Save(CCL.BusinessEntities.HRIS.AcsFile IP_obj_A, System.Object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }
    }
}
