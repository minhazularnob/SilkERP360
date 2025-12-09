using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

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

                   OracleParameter lcl_obj_AcsFileCode = new OracleParameter("v_AcsFileCode", OracleDbType.Int32);
                   lcl_obj_AcsFileCode.Direction = ParameterDirection.Output;


                   OracleParameter lcl_obj_UploadDate = new OracleParameter("v_UploadDate", OracleDbType.Date);
                   lcl_obj_UploadDate.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_UploadDate.Value = DateTime.Now;

                   OracleParameter lcl_obj_FileHash = new OracleParameter("v_FileHash", OracleDbType.NVarchar2, 32);
                   lcl_obj_FileHash.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_FileHash.Value = "md5"; //IP_obj_AcsFile.FileHash;

                   OracleParameter[] lcl_obj_AFSP_Parameters = { lcl_obj_AcsFileCode, lcl_obj_UploadDate, lcl_obj_FileHash};
                   lcl_obj_DBManager.ExecuteStoredProcedure("ACS_FILE_IU", lcl_obj_AFSP_Parameters);
                  

                   System.UInt64 lcl_ui64_AscFileCode = System.UInt64.Parse(lcl_obj_AcsFileCode.Value.ToString());
                   

                   foreach (SilkERP360.CCL.BusinessEntities.HRIS.AcsFileRow lcl_obj_AcsFileRow in IP_obj_AcsFile.AcsFileRows)
                   {
                       OracleParameter lcl_obj_AcsFileRowsCode = new OracleParameter("v_AcsFileRowsCode", OracleDbType.Int64);
                       lcl_obj_AcsFileRowsCode.Direction = System.Data.ParameterDirection.Output;
                       //lcl_obj_AcsFileRowsCode.Value = lcl_obj_AcsFileRow.AcsFileRows;

                       OracleParameter lcl_obj_CardOrEmpid = new OracleParameter("v_CardOrEmpid", OracleDbType.NVarchar2, 10);
                       lcl_obj_CardOrEmpid.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_CardOrEmpid.Value = lcl_obj_AcsFileRow.CardOREmpId;

                       OracleParameter lcl_obj_ReaderName = new OracleParameter("v_ReaderName", OracleDbType.NVarchar2, 32);
                       lcl_obj_ReaderName.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_ReaderName.Value = lcl_obj_AcsFileRow.ReaderName;

                       OracleParameter lcl_obj_TransType = new OracleParameter("v_TransType", OracleDbType.Int64);
                       lcl_obj_TransType.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_TransType.Value = (System.Int32)lcl_obj_AcsFileRow.TransactionType;

                       OracleParameter lcl_obj_TransectionDateTime = new OracleParameter("v_TransectionDateTime", OracleDbType.Date);
                       lcl_obj_TransectionDateTime.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_TransectionDateTime.Value = lcl_obj_AcsFileRow.TransectionDateTime;

                       OracleParameter lcl_obj_AcFileCode = new OracleParameter("v_AcFileCode", OracleDbType.Int64);
                       lcl_obj_AcFileCode.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_AcFileCode.Value = lcl_ui64_AscFileCode;// lcl_obj_AcsFileRow.AcsFileCode;

                       OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_AcsFileRowsCode, lcl_obj_CardOrEmpid, lcl_obj_ReaderName, lcl_obj_TransType, lcl_obj_TransectionDateTime, lcl_obj_AcFileCode };
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
