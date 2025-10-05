using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class PFAccountTransactionManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>
    {
        public PFAccountTransactionManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.HRIS.PFAccountTransaction IP_obj_PFAccountTransection, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_PFTransectionCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_PFAccountTransection.GetSequence());
            lcl_ui64_PFTransectionCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_PFAccountTransection.PFTransectionCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_PFAccountTransection.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_PFTransectionCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.PFAccountTransaction IP_obj_PFAccountTransection)
        {
            System.UInt64 lcl_ui64_PFTransectionCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_PFAccountTransection.GetSequence());
            lcl_ui64_PFTransectionCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_PFAccountTransection.PFTransectionCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_PFAccountTransection.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_PFTransectionCode;
        }

        public CCL.BusinessEntities.HRIS.PFAccountTransaction Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransection = null;
            lcl_obj_PFAccountTransection = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.PFAccountTransaction>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From PF_ACCOUNT_TRANSACTION WHERE PF_TRANSACTION_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_TmpPFAccountTransection = new CCL.BusinessEntities.HRIS.PFAccountTransaction();
                lcl_obj_TmpPFAccountTransection.PFTransectionCode = System.UInt64.Parse(lcl_obj_dr["PF_TRANSACTION_CODE"].ToString());
                lcl_obj_TmpPFAccountTransection.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                lcl_obj_TmpPFAccountTransection.PFTransactionType = (SilkERP360.CCL.Enums.ProvidentFundTransactionType)System.UInt16.Parse(lcl_obj_dr["PF_TRANSACTION_TYPE"].ToString());
                lcl_obj_TmpPFAccountTransection.TransactionMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_dr["TRANSACTION_MONTH"].ToString());
                lcl_obj_TmpPFAccountTransection.TransactionYear = System.UInt16.Parse(lcl_obj_dr["TRANSACTION_YEAR"].ToString());
                lcl_obj_TmpPFAccountTransection.TransactionDate = System.DateTime.Parse(lcl_obj_dr["TRANSACTION_DATE"].ToString());
                lcl_obj_TmpPFAccountTransection.Amount = System.Decimal.Parse(lcl_obj_dr["AMOUNT"].ToString());
                lcl_obj_TmpPFAccountTransection.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpPFAccountTransection.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());

                lcl_obj_dr.Close();
                return lcl_obj_TmpPFAccountTransection;
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccountTransection;
        }

        public CCL.BusinessEntities.HRIS.PFAccountTransaction Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransection = null;
            lcl_obj_PFAccountTransection = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.PFAccountTransaction>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From PF_ACCOUNT_TRANSACTION WHERE PF_TRANSACTION_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_TmpPFAccountTransection = new CCL.BusinessEntities.HRIS.PFAccountTransaction();
                    lcl_obj_TmpPFAccountTransection.PFTransectionCode = System.UInt64.Parse(lcl_obj_dr["PF_TRANSACTION_CODE"].ToString());
                    lcl_obj_TmpPFAccountTransection.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                    lcl_obj_TmpPFAccountTransection.PFTransactionType = (SilkERP360.CCL.Enums.ProvidentFundTransactionType)System.UInt16.Parse(lcl_obj_dr["PF_TRANSACTION_TYPE"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_dr["TRANSACTION_MONTH"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionYear = System.UInt16.Parse(lcl_obj_dr["TRANSACTION_YEAR"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionDate = System.DateTime.Parse(lcl_obj_dr["TRANSACTION_DATE"].ToString());
                    lcl_obj_TmpPFAccountTransection.Amount = System.Decimal.Parse(lcl_obj_dr["AMOUNT"].ToString());
                    lcl_obj_TmpPFAccountTransection.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpPFAccountTransection.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpPFAccountTransection;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccountTransection;
        }

        public CCL.BusinessEntities.HRIS.PFAccountTransaction Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransection = null;
            lcl_obj_PFAccountTransection = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>(() =>
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
                SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_TmpPFAccountTransection = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                lcl_obj_TmpPFAccountTransection.PFTransectionCode = System.UInt64.Parse(lcl_obj_dr["PF_TRANSACTION_CODE"].ToString());
                lcl_obj_TmpPFAccountTransection.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                lcl_obj_TmpPFAccountTransection.PFTransactionType = (SilkERP360.CCL.Enums.ProvidentFundTransactionType)System.UInt16.Parse(lcl_obj_dr["PF_TRANSACTION_TYPE"].ToString());
                lcl_obj_TmpPFAccountTransection.TransactionMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_dr["TRANSACTION_MONTH"].ToString());
                lcl_obj_TmpPFAccountTransection.TransactionYear = System.UInt16.Parse(lcl_obj_dr["TRANSACTION_YEAR"].ToString());
                lcl_obj_TmpPFAccountTransection.TransactionDate = System.DateTime.Parse(lcl_obj_dr["TRANSACTION_DATE"].ToString());
                lcl_obj_TmpPFAccountTransection.Amount = System.Decimal.Parse(lcl_obj_dr["AMOUNT"].ToString());
                lcl_obj_TmpPFAccountTransection.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpPFAccountTransection.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpPFAccountTransection;
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccountTransection;
        }

        public CCL.BusinessEntities.HRIS.PFAccountTransaction Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransection = null;
            lcl_obj_PFAccountTransection = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction>(() =>
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
                    SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_TmpPFAccountTransection = new SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction();
                    lcl_obj_TmpPFAccountTransection.PFTransectionCode = System.UInt64.Parse(lcl_obj_dr["PF_TRANSACTION_CODE"].ToString());
                    lcl_obj_TmpPFAccountTransection.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                    lcl_obj_TmpPFAccountTransection.PFTransactionType = (SilkERP360.CCL.Enums.ProvidentFundTransactionType)System.UInt16.Parse(lcl_obj_dr["PF_TRANSACTION_TYPE"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_dr["TRANSACTION_MONTH"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionYear = System.UInt16.Parse(lcl_obj_dr["TRANSACTION_YEAR"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionDate = System.DateTime.Parse(lcl_obj_dr["TRANSACTION_DATE"].ToString());
                    lcl_obj_TmpPFAccountTransection.Amount = System.Decimal.Parse(lcl_obj_dr["AMOUNT"].ToString());
                    lcl_obj_TmpPFAccountTransection.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpPFAccountTransection.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpPFAccountTransection;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_PFAccountTransection;
        }

        public List<CCL.BusinessEntities.HRIS.PFAccountTransaction> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objlist_PFAccountTransection = null;
            lcl_objlist_PFAccountTransection = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objlist_TmpPFAccountTransectionList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpPFAccountTransectionList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_TmpPFAccountTransection = new CCL.BusinessEntities.HRIS.PFAccountTransaction();
                    lcl_obj_TmpPFAccountTransection.PFTransectionCode = System.UInt64.Parse(lcl_obj_dr["PF_TRANSACTION_CODE"].ToString());
                    lcl_obj_TmpPFAccountTransection.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                    lcl_obj_TmpPFAccountTransection.PFTransactionType = (SilkERP360.CCL.Enums.ProvidentFundTransactionType)System.UInt16.Parse(lcl_obj_dr["PF_TRANSACTION_TYPE"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_dr["TRANSACTION_MONTH"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionYear = System.UInt16.Parse(lcl_obj_dr["TRANSACTION_YEAR"].ToString());
                    lcl_obj_TmpPFAccountTransection.TransactionDate = System.DateTime.Parse(lcl_obj_dr["TRANSACTION_DATE"].ToString());
                    lcl_obj_TmpPFAccountTransection.Amount = System.Decimal.Parse(lcl_obj_dr["AMOUNT"].ToString());
                    lcl_obj_TmpPFAccountTransection.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpPFAccountTransection.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_objlist_TmpPFAccountTransectionList.Add(lcl_obj_TmpPFAccountTransection);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpPFAccountTransectionList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_PFAccountTransection;
        }

        public List<CCL.BusinessEntities.HRIS.PFAccountTransaction> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objlist_PFAccountTransectionList = null;
            lcl_objlist_PFAccountTransectionList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction> lcl_objlist_TmpPFAccountTransectionList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.PFAccountTransaction>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpPFAccountTransectionList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_TmpPFAccountTransection = new CCL.BusinessEntities.HRIS.PFAccountTransaction();
                        lcl_obj_TmpPFAccountTransection.PFTransectionCode = System.UInt64.Parse(lcl_obj_dr["PF_TRANSACTION_CODE"].ToString());
                        lcl_obj_TmpPFAccountTransection.PFAccountNumber = System.UInt64.Parse(lcl_obj_dr["PF_ACCOUNT_NUMBER"].ToString());
                        lcl_obj_TmpPFAccountTransection.PFTransactionType = (SilkERP360.CCL.Enums.ProvidentFundTransactionType)System.UInt16.Parse(lcl_obj_dr["PF_TRANSACTION_TYPE"].ToString());
                        lcl_obj_TmpPFAccountTransection.TransactionMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_dr["TRANSACTION_MONTH"].ToString());
                        lcl_obj_TmpPFAccountTransection.TransactionYear = System.UInt16.Parse(lcl_obj_dr["TRANSACTION_YEAR"].ToString());
                        lcl_obj_TmpPFAccountTransection.TransactionDate = System.DateTime.Parse(lcl_obj_dr["TRANSACTION_DATE"].ToString());
                        lcl_obj_TmpPFAccountTransection.Amount = System.Decimal.Parse(lcl_obj_dr["AMOUNT"].ToString());
                        lcl_obj_TmpPFAccountTransection.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpPFAccountTransection.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_objlist_TmpPFAccountTransectionList.Add(lcl_obj_TmpPFAccountTransection);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpPFAccountTransectionList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_PFAccountTransectionList;
        }
    }
}
