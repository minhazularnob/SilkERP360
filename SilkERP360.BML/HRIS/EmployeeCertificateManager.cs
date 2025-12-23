using Oracle.ManagedDataAccess.Client;
using SilkERP360.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeCertificateManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeCertificateManager()
        {
            this.Initialize();
        }
        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeCertificate IP_obj_A, object IP_obj_DBManager)
        {
            ulong certificateCode = 0;

            // Convert certificate to byte[] for Oracle BLOB
            byte[] certificateBytes =
                System.Text.Encoding.UTF8.GetBytes(IP_obj_A.Certificate);

            certificateCode = this.ExceptionManager.Process<ulong>(() =>
            {
                DBManager dbManager = (DBManager)IP_obj_DBManager;

                // Ensure DBManager connection & transaction are open
                if (dbManager.TransactionState != TransactionState.Pending)
                {
                    dbManager.Open();
                }

                OracleConnection conn = dbManager.Connection;

                // 1. Get sequence value
                using (OracleCommand seqCmd = new OracleCommand(
                    "SELECT SEQ_EMP_CERTIFICATE.NEXTVAL FROM DUAL",
                    conn))
                {
                    seqCmd.Transaction = dbManager.Transaction;
                    certificateCode = Convert.ToUInt64(seqCmd.ExecuteScalar());
                }

                // 2. Insert certificate
                string insertSql = @"
            INSERT INTO SILKERP.EMPLOYEE_CERTIFICATE
            (EMPLOYEE_CERTIFICATE_CODE,
             CERTIFICATE,
             FILE_TYPE,
             FILE_SIZE,
             EMPLOYEE_CODE,
             STATUS,
             IS_DELETED)
            VALUES
            (:pCode,
             :pCertificate,
             :pFileType,
             :pFileSize,
             :pEmployeeCode,
             :pStatus,
             :pIsDeleted)";

                using (OracleCommand cmd = new OracleCommand(insertSql, conn))
                {
                    cmd.Transaction = dbManager.Transaction;

                    cmd.Parameters.Add("pCode", OracleDbType.Int64).Value = certificateCode;
                    cmd.Parameters.Add("pCertificate", OracleDbType.Blob).Value = certificateBytes;
                    cmd.Parameters.Add("pFileType", OracleDbType.NVarchar2).Value = IP_obj_A.FileType;
                    cmd.Parameters.Add("pFileSize", OracleDbType.Int64).Value = IP_obj_A.FileSize;
                    cmd.Parameters.Add("pEmployeeCode", OracleDbType.Int64).Value = IP_obj_A.EmployeeCode;
                    cmd.Parameters.Add("pStatus", OracleDbType.Int32).Value = IP_obj_A.Status;
                    cmd.Parameters.Add("pIsDeleted", OracleDbType.Int32).Value = IP_obj_A.IsDeleted;

                    cmd.ExecuteNonQuery();
                }

                return certificateCode;

            }, "BMLExceptionPolicy");

            return certificateCode;
        }
    }
}