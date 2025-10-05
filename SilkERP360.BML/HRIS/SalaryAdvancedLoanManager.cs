using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class SalaryAdvancedLoanManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>
    {
       public SalaryAdvancedLoanManager()
       {
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SalaryAdvndLoan, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_SalaryAdvancedCode = 0;

           lcl_ui64_SalaryAdvancedCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;


               System.Data.OracleClient.OracleParameter lcl_obj_SalaryAdvancedCode = new System.Data.OracleClient.OracleParameter("v_SalaryAdvancedCode", System.Data.OracleClient.OracleType.Number);
               lcl_obj_SalaryAdvancedCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_SalaryAdvancedCode.Value = lcl_obj_SalaryAdvndLoan.SalaryAdvancedCode;

               System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EmployeeCode", System.Data.OracleClient.OracleType.Number);
               lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EmployeeCode.Value = lcl_obj_SalaryAdvndLoan.EmployeeCode;

               System.Data.OracleClient.OracleParameter lcl_obj_EffectMonthe = new System.Data.OracleClient.OracleParameter("v_EffectMonth", System.Data.OracleClient.OracleType.DateTime);
               lcl_obj_EffectMonthe.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_EffectMonthe.Value = lcl_obj_SalaryAdvndLoan.EffectMonth;

               System.Data.OracleClient.OracleParameter lcl_obj_Amount = new System.Data.OracleClient.OracleParameter("v_Amount", System.Data.OracleClient.OracleType.Number);
               lcl_obj_Amount.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Amount.Value = lcl_obj_SalaryAdvndLoan.Amount;

               System.Data.OracleClient.OracleParameter lcl_obj_Remarks = new System.Data.OracleClient.OracleParameter("v_Remarks", System.Data.OracleClient.OracleType.NVarChar, 512);
               lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Remarks.Value = lcl_obj_SalaryAdvndLoan.Remarks;
               System.Data.OracleClient.OracleParameter lcl_obj_NoOfInstallment = new System.Data.OracleClient.OracleParameter("v_NoOfInstallment", System.Data.OracleClient.OracleType.Number);
               lcl_obj_NoOfInstallment.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_NoOfInstallment.Value = lcl_obj_SalaryAdvndLoan.NoOfInstallment;
               System.Data.OracleClient.OracleParameter lcl_obj_PaidUnpaid = new System.Data.OracleClient.OracleParameter("v_PaidUnpaid", System.Data.OracleClient.OracleType.Char, 1);
               lcl_obj_PaidUnpaid.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_PaidUnpaid.Value = lcl_obj_SalaryAdvndLoan.PaidUnpaid;
               System.Data.OracleClient.OracleParameter lcl_obj_LoanNo = new System.Data.OracleClient.OracleParameter("v_LoanNo", System.Data.OracleClient.OracleType.Number);
               lcl_obj_LoanNo.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_LoanNo.Value = lcl_obj_SalaryAdvndLoan.LoanNo;

               System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalaryAdvancedCode, lcl_obj_EmployeeCode, lcl_obj_EffectMonthe, lcl_obj_Amount, lcl_obj_Remarks, lcl_obj_NoOfInstallment, lcl_obj_PaidUnpaid, lcl_obj_LoanNo };
               lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_SALARY_ADVANCED_LOAN", lcl_obj_SP_Parameters);
               return System.UInt64.Parse(lcl_obj_SalaryAdvancedCode.Value.ToString());
           }, "BMLExceptionPolicy");
           return lcl_ui64_SalaryAdvancedCode;
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SalaryAdvndLoan)
       {
          System.UInt64 lcl_ui64_SalaryAdvancedCode = 0;

           lcl_ui64_SalaryAdvancedCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                   using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                   {
                       if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                       {
                           lcl_obj_DBManager.InternalResource.Open();
                       }
                       System.Data.OracleClient.OracleParameter lcl_obj_SalaryAdvancedCode = new System.Data.OracleClient.OracleParameter("v_SalaryAdvancedCode", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_SalaryAdvancedCode.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_SalaryAdvancedCode.Value = lcl_obj_SalaryAdvndLoan.SalaryAdvancedCode;

                       System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EmployeeCode", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_EmployeeCode.Value = lcl_obj_SalaryAdvndLoan.EmployeeCode;

                       System.Data.OracleClient.OracleParameter lcl_obj_EffectMonthe = new System.Data.OracleClient.OracleParameter("v_EffectMonth", System.Data.OracleClient.OracleType.DateTime);
                       lcl_obj_EffectMonthe.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_EffectMonthe.Value = lcl_obj_SalaryAdvndLoan.EffectMonth;

                       System.Data.OracleClient.OracleParameter lcl_obj_Amount = new System.Data.OracleClient.OracleParameter("v_Amount", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_Amount.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_Amount.Value = lcl_obj_SalaryAdvndLoan.Amount;

                       System.Data.OracleClient.OracleParameter lcl_obj_Remarks = new System.Data.OracleClient.OracleParameter("v_Remarks", System.Data.OracleClient.OracleType.NVarChar, 512);
                       lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_Remarks.Value = lcl_obj_SalaryAdvndLoan.Remarks;
                       System.Data.OracleClient.OracleParameter lcl_obj_NoOfInstallment = new System.Data.OracleClient.OracleParameter("v_NoOfInstallment", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_NoOfInstallment.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_NoOfInstallment.Value = lcl_obj_SalaryAdvndLoan.NoOfInstallment;
                       System.Data.OracleClient.OracleParameter lcl_obj_PaidUnpaid = new System.Data.OracleClient.OracleParameter("v_PaidUnpaid", System.Data.OracleClient.OracleType.Char, 1);
                       lcl_obj_PaidUnpaid.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_PaidUnpaid.Value = lcl_obj_SalaryAdvndLoan.PaidUnpaid;
                       System.Data.OracleClient.OracleParameter lcl_obj_LoanNo = new System.Data.OracleClient.OracleParameter("v_LoanNo", System.Data.OracleClient.OracleType.Number);
                       lcl_obj_LoanNo.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_LoanNo.Value = lcl_obj_SalaryAdvndLoan.LoanNo;

                       System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalaryAdvancedCode, lcl_obj_EmployeeCode, lcl_obj_EffectMonthe, lcl_obj_Amount, lcl_obj_Remarks, lcl_obj_NoOfInstallment, lcl_obj_PaidUnpaid, lcl_obj_LoanNo };
                       lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_SALARY_ADVANCED_LOAN", lcl_obj_SP_Parameters);
                       return System.UInt64.Parse(lcl_obj_SalaryAdvancedCode.Value.ToString());
                   }
           }, "BMLExceptionPolicy");
           return lcl_ui64_SalaryAdvancedCode;
       }

       public CCL.BusinessEntities.HRIS.SalaryAdvancedLoan Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoan = null;

           lcl_obj_SlryAdvndLoan = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_ADVANCED_LOAN Where SALARY_ADVANCED_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_SlryAdvndLoanReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_SlryAdvndLoanReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error SalaryAdvancedLoanManager.Get(ID,DBManger)) : Error Retrieving SalaryAdvancedLoan Data!");
               }
               lcl_obj_SlryAdvndLoanReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoanTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan();
               lcl_obj_SlryAdvndLoanTmp.SalaryAdvancedCode = System.UInt64.Parse(lcl_obj_SlryAdvndLoanReader["SALARY_ADVANCED_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_SlryAdvndLoanReader["EMPLOYEE_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Amount = System.Decimal.Parse(lcl_obj_SlryAdvndLoanReader["AMOUNT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EffectMonth = System.DateTime.Parse(lcl_obj_SlryAdvndLoanReader["EFFECT_MONTH"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Remarks = lcl_obj_SlryAdvndLoanReader["REMARKS"].ToString();
               lcl_obj_SlryAdvndLoanTmp.NoOfInstallment = System.UInt16.Parse(lcl_obj_SlryAdvndLoanReader["NO_OF_INSTALLMENT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.PaidUnpaid = lcl_obj_SlryAdvndLoanReader["PAID_UNPAID"].ToString();
               lcl_obj_SlryAdvndLoanTmp.LoanNo = System.UInt16.Parse(lcl_obj_SlryAdvndLoanReader["LOAN_NO"].ToString());

               lcl_obj_SlryAdvndLoanReader.Close();
               return lcl_obj_SlryAdvndLoanTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_SlryAdvndLoan;
       }

       public CCL.BusinessEntities.HRIS.SalaryAdvancedLoan Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoan = null;

           lcl_obj_SlryAdvndLoan = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>(() =>
                {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From SALARY_ADVANCED_LOAN Where SALARY_ADVANCED_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
       if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalaryAdvancedLoanManager.Get(ID)) : No SalaryAdvancedLoan Data Found In The Database!!!");
                    }
                     SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoanTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan();
               lcl_obj_SlryAdvndLoanTmp.SalaryAdvancedCode = System.UInt64.Parse(dr["SALARY_ADVANCED_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EffectMonth = System.DateTime.Parse(dr["EFFECT_MONTH"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Remarks = dr["REMARKS"].ToString();
               lcl_obj_SlryAdvndLoanTmp.NoOfInstallment = System.UInt16.Parse(dr["NO_OF_INSTALLMENT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.PaidUnpaid = dr["PAID_UNPAID"].ToString();
               lcl_obj_SlryAdvndLoanTmp.LoanNo = System.UInt16.Parse(dr["LOAN_NO"].ToString());
               dr.Close();
               return lcl_obj_SlryAdvndLoanTmp;
                }
                }, "BMLExceptionPolicy");
           return lcl_obj_SlryAdvndLoan;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan> lcl_objLst_SlryAdvndLoan = null;
            
            lcl_objLst_SlryAdvndLoan = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalaryAdvancedLoanManager.GetList(SqlQuery,DBManager)) : No SalaryAdvancedLoan Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan> lcl_objLst_SlryAdvndLoanTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoan = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan();
               lcl_obj_SlryAdvndLoan.SalaryAdvancedCode = System.UInt64.Parse(dr["SALARY_ADVANCED_CODE"].ToString());
               lcl_obj_SlryAdvndLoan.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_SlryAdvndLoan.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
               lcl_obj_SlryAdvndLoan.EffectMonth = System.DateTime.Parse(dr["EFFECT_MONTH"].ToString());
               lcl_obj_SlryAdvndLoan.Remarks = dr["REMARKS"].ToString();
               lcl_obj_SlryAdvndLoan.NoOfInstallment = System.UInt16.Parse(dr["NO_OF_INSTALLMENT"].ToString());
               lcl_obj_SlryAdvndLoan.PaidUnpaid = dr["PAID_UNPAID"].ToString();
               lcl_obj_SlryAdvndLoan.LoanNo = System.UInt16.Parse(dr["LOAN_NO"].ToString());
               lcl_objLst_SlryAdvndLoanTmp.Add(lcl_obj_SlryAdvndLoan);
                }
                dr.Close();
                return lcl_objLst_SlryAdvndLoanTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_SlryAdvndLoan;
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan> GetList(string IP_str_SqlQuery)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan> lcl_objLst_SalaryAdvndLoan = null;
            lcl_objLst_SalaryAdvndLoan = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.InternalResource.Open();
                        }

                        System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                        if (!(dr.HasRows))
                        {
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalaryAdvancedLoanManager.GetList(SqlQuery)) : No SalaryAdvancedLoan Data Found In The Database!!!");
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan> lcl_objLst_AttenRawDtlTmp = new
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>();
                        while (dr.Read())
                        {
               SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoan = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan();
               lcl_obj_SlryAdvndLoan.SalaryAdvancedCode = System.UInt64.Parse(dr["SALARY_ADVANCED_CODE"].ToString());
               lcl_obj_SlryAdvndLoan.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_SlryAdvndLoan.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
               lcl_obj_SlryAdvndLoan.EffectMonth = System.DateTime.Parse(dr["EFFECT_MONTH"].ToString());
               lcl_obj_SlryAdvndLoan.Remarks = dr["REMARKS"].ToString();
               lcl_obj_SlryAdvndLoan.NoOfInstallment = System.UInt16.Parse(dr["NO_OF_INSTALLMENT"].ToString());
               lcl_obj_SlryAdvndLoan.PaidUnpaid = dr["PAID_UNPAID"].ToString();
               lcl_obj_SlryAdvndLoan.LoanNo = System.UInt16.Parse(dr["LOAN_NO"].ToString());
               lcl_objLst_AttenRawDtlTmp.Add(lcl_obj_SlryAdvndLoan);
                        }
                        dr.Close();
                        return lcl_objLst_AttenRawDtlTmp;
                    }
                }, "BMLExceptionPolicy");
            return lcl_objLst_SalaryAdvndLoan;
       }

       public CCL.BusinessEntities.HRIS.SalaryAdvancedLoan Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {

           SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoan = null;         
            lcl_obj_SlryAdvndLoan = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_SlryAdvndLoanReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_SlryAdvndLoanReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error SalaryAdvancedLoanManager.Get(SqlQuery,DBManger)) : Error Retrieving SalaryAdvancedLoan Data!");
                }
                lcl_obj_SlryAdvndLoanReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoanTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan();
               lcl_obj_SlryAdvndLoanTmp.SalaryAdvancedCode = System.UInt64.Parse(lcl_obj_SlryAdvndLoanReader["SALARY_ADVANCED_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_SlryAdvndLoanReader["EMPLOYEE_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Amount = System.Decimal.Parse(lcl_obj_SlryAdvndLoanReader["AMOUNT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EffectMonth = System.DateTime.Parse(lcl_obj_SlryAdvndLoanReader["EFFECT_MONTH"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Remarks = lcl_obj_SlryAdvndLoanReader["REMARKS"].ToString();
               lcl_obj_SlryAdvndLoanTmp.NoOfInstallment = System.UInt16.Parse(lcl_obj_SlryAdvndLoanReader["NO_OF_INSTALLMENT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.PaidUnpaid = lcl_obj_SlryAdvndLoanReader["PAID_UNPAID"].ToString();
               lcl_obj_SlryAdvndLoanTmp.LoanNo = System.UInt16.Parse(lcl_obj_SlryAdvndLoanReader["LOAN_NO"].ToString());
               lcl_obj_SlryAdvndLoanReader.Close();
               return lcl_obj_SlryAdvndLoanTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_SlryAdvndLoan;
       }

       public CCL.BusinessEntities.HRIS.SalaryAdvancedLoan Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoan = null;
            lcl_obj_SlryAdvndLoan = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(IP_str_SqlQuery));
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalaryAdvancedLoanManager.Get(SqlQuery)) : No SalaryAdvancedLoan Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan lcl_obj_SlryAdvndLoanTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdvancedLoan();
               lcl_obj_SlryAdvndLoanTmp.SalaryAdvancedCode = System.UInt64.Parse(dr["SALARY_ADVANCED_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.EffectMonth = System.DateTime.Parse(dr["EFFECT_MONTH"].ToString());
               lcl_obj_SlryAdvndLoanTmp.Remarks = dr["REMARKS"].ToString();
               lcl_obj_SlryAdvndLoanTmp.NoOfInstallment = System.UInt16.Parse(dr["NO_OF_INSTALLMENT"].ToString());
               lcl_obj_SlryAdvndLoanTmp.PaidUnpaid = dr["PAID_UNPAID"].ToString();
               lcl_obj_SlryAdvndLoanTmp.LoanNo = System.UInt16.Parse(dr["LOAN_NO"].ToString());
               dr.Close();
               return lcl_obj_SlryAdvndLoanTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SlryAdvndLoan;
       }
    }
}
