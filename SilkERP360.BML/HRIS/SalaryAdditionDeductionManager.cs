using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class SalaryAdditionDeductionManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>
    {
        public SalaryAdditionDeductionManager()
        {
            this.Initialize();
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction IP_obj_SalaryAddDed, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_SalaryAddDedCode = 0;
            
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SALARY_ADDITION_DEDUCTION_SEQ.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_SalaryAddDedCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SalaryAddDed.SalaryAddDedCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SalaryAddDed.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                //lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_SalaryAddDedCode;
            //lcl_ui64_SalaryAddDedCode = this.ExceptionManager.Process<System.UInt64>(() =>
            //{
            //    SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

            //    OracleParameter lcl_obj_SalaryAddDedCode = new OracleParameter("p_ADD_DED_CODE", OracleDbType.Int64);
            //    lcl_obj_SalaryAddDedCode.Direction = System.Data.ParameterDirection.Output;
            //   // lcl_obj_SalaryAddDedCode.Value = lcl_obj_SalaryAddDed.SalaryAddDedCode;

            //    OracleParameter lcl_obj_EmployeeCode = new OracleParameter("p_EMPLOYEE_CODE", OracleDbType.Int64);
            //    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_EmployeeCode.Value = lcl_obj_SalaryAddDed.EmployeeCode;

            //    OracleParameter lcl_obj_AddOrDed = new OracleParameter("p_ADD_OR_DED", OracleDbType.Int64);
            //    lcl_obj_AddOrDed.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_AddOrDed.Value = (System.Int32)lcl_obj_SalaryAddDed.AdditionOrDeduction;

            //    OracleParameter lcl_obj_AddDedType = new OracleParameter("p_ADD_DED_TYPE", OracleDbType.Int64);
            //    lcl_obj_AddDedType.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_AddDedType.Value = (System.Int32)lcl_obj_SalaryAddDed.AdditionDeductionType;

            //    OracleParameter lcl_obj_Amount = new OracleParameter("p_AMOUNT", OracleDbType.Int64);
            //    lcl_obj_Amount.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_Amount.Value = lcl_obj_SalaryAddDed.Amount;

            //    OracleParameter lcl_obj_AddDedDate = new OracleParameter("p_ADD_DED_DATE", OracleDbType.Date);
            //    lcl_obj_AddDedDate.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_AddDedDate.Value = lcl_obj_SalaryAddDed.AdditionDeductionDate;

            //    OracleParameter lcl_obj_Remarks = new OracleParameter("p_REMARKS", OracleDbType.NVarchar2, 512);
            //    lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_Remarks.Value = lcl_obj_SalaryAddDed.Remarks;

            //    OracleParameter lcl_obj_EffectiveMonth = new OracleParameter("p_EFFECTIVE_MONTH", OracleDbType.Int64);
            //    lcl_obj_EffectiveMonth.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_EffectiveMonth.Value = (System.Int32)lcl_obj_SalaryAddDed.EffectiveMonth;

            //    OracleParameter lcl_obj_EffectiveYear = new OracleParameter("p_EFFECTIVE_YEAR", OracleDbType.Int64);
            //    lcl_obj_EffectiveYear.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_EffectiveYear.Value = lcl_obj_SalaryAddDed.EffectiveYear;

            //    OracleParameter lcl_obj_IsProcessed = new OracleParameter("p_IS_PROCESSED", OracleDbType.Int64);
            //    lcl_obj_IsProcessed.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_IsProcessed.Value = (System.Int16)SilkERP360.CCL.Enums.YesNo.No;

            //    OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
            //    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_Status.Value = (System.Int16)SilkERP360.CCL.Enums.Status.Active;

            //    OracleParameter lcl_obj_EntryEmployeeCode = new OracleParameter("p_ENTRY_EMPLOYEE_CODE", OracleDbType.Int64);
            //    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
            //    lcl_obj_Status.Value = lcl_obj_SalaryAddDed.EntryEmployeeCode;


            //    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalaryAddDedCode, lcl_obj_EmployeeCode, lcl_obj_AddOrDed, lcl_obj_AddDedType, lcl_obj_Amount, lcl_obj_AddDedDate, lcl_obj_Remarks, lcl_obj_EffectiveMonth, lcl_obj_EffectiveYear, lcl_obj_IsProcessed, lcl_obj_Status, lcl_obj_EntryEmployeeCode };
            //    lcl_obj_DBManager.ExecuteStoredProcedure("SALARY_ADDITION_DEDUCTION_IU", lcl_obj_SP_Parameters);
            //    return System.UInt64.Parse(lcl_obj_SalaryAddDedCode.Value.ToString());
            //}, "BMLExceptionPolicy");
            //return lcl_ui64_SalaryAddDedCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDed)
       {
          System.UInt64 lcl_ui64_SalaryAddDedCode = 0;

           lcl_ui64_SalaryAddDedCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                   using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                   {
                       if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                       {
                           lcl_obj_DBManager.InternalResource.Open();
                       }
                       OracleParameter lcl_obj_SalaryAddDedCode = new OracleParameter("p_ADD_DED_CODE", OracleDbType.Int64);
                       lcl_obj_SalaryAddDedCode.Direction = System.Data.ParameterDirection.Output;
                       // lcl_obj_SalaryAddDedCode.Value = lcl_obj_SalaryAddDed.SalaryAddDedCode;

                       OracleParameter lcl_obj_EmployeeCode = new OracleParameter("p_EMPLOYEE_CODE", OracleDbType.Int64);
                       lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_EmployeeCode.Value = lcl_obj_SalaryAddDed.EmployeeCode;

                       OracleParameter lcl_obj_AdditionOrDeduction = new OracleParameter("p_ADD_OR_DED", OracleDbType.Int64);
                       lcl_obj_AdditionOrDeduction.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_AdditionOrDeduction.Value = lcl_obj_SalaryAddDed.AdditionOrDeduction;

                       OracleParameter lcl_obj_AdditionDeductionType = new OracleParameter("p_ADD_DED_TYPE", OracleDbType.Int64);
                       lcl_obj_AdditionDeductionType.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_AdditionDeductionType.Value = lcl_obj_SalaryAddDed.AdditionDeductionType;

                       OracleParameter lcl_obj_Amount = new OracleParameter("p_AMOUNT", OracleDbType.Int64);
                       lcl_obj_Amount.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_Amount.Value = lcl_obj_SalaryAddDed.Amount;

                       OracleParameter lcl_obj_AddDedDate = new OracleParameter("p_ADD_DED_DATE", OracleDbType.Date);
                       lcl_obj_AddDedDate.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_AddDedDate.Value = lcl_obj_SalaryAddDed.AdditionDeductionDate;
                       OracleParameter lcl_obj_Remarks = new OracleParameter("p_REMARKS", OracleDbType.NVarchar2, 512);
                       lcl_obj_Remarks.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_Remarks.Value = lcl_obj_SalaryAddDed.Remarks;
                       OracleParameter lcl_obj_EffectiveMonth = new OracleParameter("p_EFFECTIVE_MONTH", OracleDbType.Int64);
                       lcl_obj_EffectiveMonth.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_EffectiveMonth.Value = lcl_obj_SalaryAddDed.EffectiveMonth;
                       OracleParameter lcl_obj_EffectiveYear = new OracleParameter("p_EFFECTIVE_YEAR", OracleDbType.Int64);
                       lcl_obj_EffectiveYear.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_EffectiveYear.Value = lcl_obj_SalaryAddDed.EffectiveYear;
                       OracleParameter lcl_obj_IsProcessed = new OracleParameter("p_IS_PROCESSED", OracleDbType.Int64);
                       lcl_obj_IsProcessed.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_IsProcessed.Value = 0;

                       OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
                       lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_Status.Value = 1;

                       OracleParameter lcl_obj_EntryEmployeeCode = new OracleParameter("p_ENTRY_EMPLOYEE_CODE", OracleDbType.Int64);
                       lcl_obj_EntryEmployeeCode.Direction = System.Data.ParameterDirection.Input;
                       lcl_obj_EntryEmployeeCode.Value = lcl_obj_SalaryAddDed.EntryEmployeeCode;

                       OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalaryAddDedCode, lcl_obj_EmployeeCode, lcl_obj_AdditionOrDeduction, lcl_obj_AdditionDeductionType, lcl_obj_Amount, lcl_obj_AddDedDate, lcl_obj_Remarks, lcl_obj_EffectiveMonth, lcl_obj_EffectiveYear, lcl_obj_IsProcessed, lcl_obj_Status, lcl_obj_EntryEmployeeCode };
                       lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("SALARY_ADDITION_DEDUCTION_IU", lcl_obj_SP_Parameters);

                       lcl_obj_DBManager.InternalResource.CommitTransaction();
                       lcl_obj_DBManager.InternalResource.Close();

                       return System.UInt64.Parse(lcl_obj_SalaryAddDedCode.Value.ToString()); 
                           
                           
                      
                   }
               }, "BMLExceptionPolicy");
            return lcl_ui64_SalaryAddDedCode;
        }

//        public ulong UpdateSalaryAddDED(System.UInt64 IP_obj_EmployeeLeaveRecomanded)
//        {
//            System.UInt64 lcl_ui64_EmployeeLeaveApplicationCode = 0;
//            lcl_ui64_EmployeeLeaveApplicationCode = this.ExceptionManager.Process<System.UInt64>(() =>
//            {

//                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
//                {
//                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
//                    {
//                        lcl_obj_DBManager.InternalResource.Open();
//                    }

//                    System.String lcl_str_SqlQuery = System.String.Format(@"update salary_addition_deduction
//                                                        set status={0} where add_ded_code={0}", IP_obj_EmployeeLeaveRecomanded);
//                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);

//                    lcl_obj_DBManager.InternalResource.CommitTransaction();
//                    lcl_obj_DBManager.InternalResource.Close();

//                    return 0;
//                }
//            }, "BMLExceptionPolicy");
//            return lcl_ui64_EmployeeLeaveApplicationCode;
//        }
        public CCL.BusinessEntities.HRIS.SalaryAdditionDeduction Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDed = null;

           lcl_obj_SalaryAddDed = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }

               System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_ADDITION_DEDUCTION Where ADD_DED_CODE = {0} and STATUS = {1}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SalaryAddDedReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

               if (lcl_obj_SalaryAddDedReader.HasRows == false)
               {
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error SalaryAdditionDeductionManager.Get(ID,DBManger)) : Error Retrieving SalaryAdditionDeduction Data!");
               }
               lcl_obj_SalaryAddDedReader.Read();
               SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDedTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
               lcl_obj_SalaryAddDedTmp.SalaryAddDedCode = System.UInt64.Parse(lcl_obj_SalaryAddDedReader["ADD_DED_CODE"].ToString());
               lcl_obj_SalaryAddDedTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_SalaryAddDedReader["EMPLOYEE_CODE"].ToString());               
               lcl_obj_SalaryAddDedTmp.AdditionOrDeduction = (SilkERP360.CCL.Enums.AdditionOrDeduction)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["ADD_OR_DED"].ToString());
               lcl_obj_SalaryAddDedTmp.AdditionDeductionType = (SilkERP360.CCL.Enums.AdditionDeductionType)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["ADD_DED_TYPE"].ToString());
               lcl_obj_SalaryAddDedTmp.Amount = System.Decimal.Parse(lcl_obj_SalaryAddDedReader["AMOUNT"].ToString());
               lcl_obj_SalaryAddDedTmp.AdditionDeductionDate = System.DateTime.Parse(lcl_obj_SalaryAddDedReader["ADD_DED_DATE"].ToString());
               lcl_obj_SalaryAddDedTmp.Remarks = lcl_obj_SalaryAddDedReader["REMARKS"].ToString();
               lcl_obj_SalaryAddDedTmp.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["EFFECTIVE_MONTH"].ToString());
               lcl_obj_SalaryAddDedTmp.EffectiveYear = System.UInt16.Parse(lcl_obj_SalaryAddDedReader["EFFECTIVE_YEAR"].ToString());
               lcl_obj_SalaryAddDedTmp.IsProcessed = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["IS_PROCESSED"].ToString());
               lcl_obj_SalaryAddDedTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_SalaryAddDedReader["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_SalaryAddDedTmp._AdditionalData["Addition_Deduction"] = lcl_obj_SalaryAddDedTmp.AdditionOrDeduction.ToString();
               lcl_obj_SalaryAddDedTmp._AdditionalData["AdditionDeductionType"] = lcl_obj_SalaryAddDedTmp.AdditionDeductionType.ToString();
               lcl_obj_SalaryAddDedTmp._AdditionalData["EffectiveMonth"] = lcl_obj_SalaryAddDedTmp.EffectiveMonth.ToString();
               lcl_obj_SalaryAddDedReader.Close();
               return lcl_obj_SalaryAddDedTmp;
           }, "BMLExceptionPolicy");
           return lcl_obj_SalaryAddDed;
        }

        public CCL.BusinessEntities.HRIS.SalaryAdditionDeduction Get(ulong IP_ui64_Code)
        {
          SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDed = null;

           lcl_obj_SalaryAddDed = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>(() =>
                {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From SALARY_ADDITION_DEDUCTION Where ADD_DED_CODE = {0} and STATUS = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
       if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalaryAdditionDeductionManager.Get(ID)) : No SalaryAdditionDeduction Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDedTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                    lcl_obj_SalaryAddDedTmp.SalaryAddDedCode = System.UInt64.Parse(dr["ADD_DED_CODE"].ToString());
                    lcl_obj_SalaryAddDedTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_SalaryAddDedTmp.AdditionOrDeduction = (SilkERP360.CCL.Enums.AdditionOrDeduction)System.UInt16.Parse(dr["ADD_OR_DED"].ToString());
                    lcl_obj_SalaryAddDedTmp.AdditionDeductionType = (SilkERP360.CCL.Enums.AdditionDeductionType)System.UInt16.Parse(dr["ADD_DED_TYPE"].ToString());
                    lcl_obj_SalaryAddDedTmp.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
                    lcl_obj_SalaryAddDedTmp.AdditionDeductionDate = System.DateTime.Parse(dr["ADD_DED_DATE"].ToString());
                    lcl_obj_SalaryAddDedTmp.Remarks = dr["REMARKS"].ToString();
                    lcl_obj_SalaryAddDedTmp.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_SalaryAddDedTmp.EffectiveYear = System.UInt16.Parse(dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_SalaryAddDedTmp.IsProcessed = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(dr["IS_PROCESSED"].ToString());
                    lcl_obj_SalaryAddDedTmp.EntryEmployeeCode = System.UInt64.Parse(dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_SalaryAddDedTmp._AdditionalData["Addition_Deduction"] = lcl_obj_SalaryAddDedTmp.AdditionOrDeduction.ToString();
                    lcl_obj_SalaryAddDedTmp._AdditionalData["AdditionDeductionType"] = lcl_obj_SalaryAddDedTmp.AdditionDeductionType.ToString();
                    lcl_obj_SalaryAddDedTmp._AdditionalData["EffectiveMonth"] = lcl_obj_SalaryAddDedTmp.EffectiveMonth.ToString();
               dr.Close();
               return lcl_obj_SalaryAddDedTmp;
                }
                }, "BMLExceptionPolicy");
           return lcl_obj_SalaryAddDed;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager) 
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAddDed = null;
            
            lcl_objLst_SalaryAddDed = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    dr.Close();
                    return null;
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAddDedTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();

                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDed = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                    lcl_obj_SalaryAddDed.SalaryAddDedCode = System.UInt64.Parse(dr["ADD_DED_CODE"].ToString());
                    lcl_obj_SalaryAddDed.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_SalaryAddDed.AdditionOrDeduction = (SilkERP360.CCL.Enums.AdditionOrDeduction)System.UInt16.Parse(dr["ADD_OR_DED"].ToString());
                    lcl_obj_SalaryAddDed.AdditionDeductionType = (SilkERP360.CCL.Enums.AdditionDeductionType)System.UInt16.Parse(dr["ADD_DED_TYPE"].ToString());
                    lcl_obj_SalaryAddDed.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
                    lcl_obj_SalaryAddDed.AdditionDeductionDate = System.DateTime.Parse(dr["ADD_DED_DATE"].ToString());
                    lcl_obj_SalaryAddDed.Remarks = dr["REMARKS"].ToString();
                    lcl_obj_SalaryAddDed.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_SalaryAddDed.EffectiveYear = System.UInt16.Parse(dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_SalaryAddDed.IsProcessed = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(dr["IS_PROCESSED"].ToString());
                    lcl_obj_SalaryAddDed.EntryEmployeeCode = System.UInt64.Parse(dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_SalaryAddDed._AdditionalData["Addition_Deduction"] = lcl_obj_SalaryAddDed.AdditionOrDeduction.ToString();
                    lcl_obj_SalaryAddDed._AdditionalData["AdditionDeductionType"] = lcl_obj_SalaryAddDed.AdditionDeductionType.ToString();
                    lcl_obj_SalaryAddDed._AdditionalData["EffectiveMonth"] = lcl_obj_SalaryAddDed.EffectiveMonth.ToString();
                     lcl_objLst_SalaryAddDedTmp.Add(lcl_obj_SalaryAddDed);
                }
                dr.Close();
                return lcl_objLst_SalaryAddDedTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_SalaryAddDed;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> GetList(string IP_str_SqlQuery)
       {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAddDed = null;
            lcl_objLst_SalaryAddDed = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        {
                            lcl_obj_DBManager.InternalResource.Open();
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> lcl_objLst_SalaryAddDedTmp = new
                           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>();
                        Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                        if (!(dr.HasRows))
                        {
                            return lcl_objLst_SalaryAddDedTmp;
                        }
                       
                        while (dr.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDed = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                            lcl_obj_SalaryAddDed.SalaryAddDedCode = System.UInt64.Parse(dr["ADD_DED_CODE"].ToString());
                            lcl_obj_SalaryAddDed.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                            lcl_obj_SalaryAddDed.AdditionOrDeduction = (SilkERP360.CCL.Enums.AdditionOrDeduction)System.UInt16.Parse(dr["ADD_OR_DED"].ToString());
                            lcl_obj_SalaryAddDed.AdditionDeductionType = (SilkERP360.CCL.Enums.AdditionDeductionType)System.UInt16.Parse(dr["ADD_DED_TYPE"].ToString());
                            lcl_obj_SalaryAddDed.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
                            lcl_obj_SalaryAddDed.AdditionDeductionDate = System.DateTime.Parse(dr["ADD_DED_DATE"].ToString());
                            lcl_obj_SalaryAddDed.Remarks = dr["REMARKS"].ToString();
                            lcl_obj_SalaryAddDed.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(dr["EFFECTIVE_MONTH"].ToString());
                            lcl_obj_SalaryAddDed.EffectiveYear = System.UInt16.Parse(dr["EFFECTIVE_YEAR"].ToString());
                            lcl_obj_SalaryAddDed.IsProcessed = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(dr["IS_PROCESSED"].ToString());
                            lcl_obj_SalaryAddDed.EntryEmployeeCode = System.UInt64.Parse(dr["ENTRY_EMPLOYEE_CODE"].ToString());
                            lcl_obj_SalaryAddDed._AdditionalData["AdditionOrDeduction"] = lcl_obj_SalaryAddDed.AdditionOrDeduction.ToString();
                            lcl_obj_SalaryAddDed._AdditionalData["AdditionDeductionType"] = lcl_obj_SalaryAddDed.AdditionDeductionType.ToString();
                            lcl_obj_SalaryAddDed._AdditionalData["EffectiveMonth"] = lcl_obj_SalaryAddDed.EffectiveMonth.ToString();
                            lcl_objLst_SalaryAddDedTmp.Add(lcl_obj_SalaryAddDed);
                        }
                        dr.Close();
                        return lcl_objLst_SalaryAddDedTmp;
                    }
            }, "BMLExceptionPolicy");
            return lcl_objLst_SalaryAddDed;
        }

        public CCL.BusinessEntities.HRIS.SalaryAdditionDeduction Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
       {

           SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDed = null;         
            lcl_obj_SalaryAddDed = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SalaryAddDedReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_SalaryAddDedReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error SalaryAdditionDeductionManager.Get(SqlQuery,DBManger)) : Error Retrieving SalaryAdditionDeduction Data!");
                }
                lcl_obj_SalaryAddDedReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDedTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                lcl_obj_SalaryAddDedTmp.SalaryAddDedCode = System.UInt64.Parse(lcl_obj_SalaryAddDedReader["ADD_DED_CODE"].ToString());
                lcl_obj_SalaryAddDedTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_SalaryAddDedReader["EMPLOYEE_CODE"].ToString());
                lcl_obj_SalaryAddDedTmp.AdditionOrDeduction = (SilkERP360.CCL.Enums.AdditionOrDeduction)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["ADD_OR_DED"].ToString());
                lcl_obj_SalaryAddDedTmp.AdditionDeductionType = (SilkERP360.CCL.Enums.AdditionDeductionType)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["ADD_DED_TYPE"].ToString());
                lcl_obj_SalaryAddDedTmp.Amount = System.Decimal.Parse(lcl_obj_SalaryAddDedReader["AMOUNT"].ToString());
                lcl_obj_SalaryAddDedTmp.AdditionDeductionDate = System.DateTime.Parse(lcl_obj_SalaryAddDedReader["ADD_DED_DATE"].ToString());
                lcl_obj_SalaryAddDedTmp.Remarks = lcl_obj_SalaryAddDedReader["REMARKS"].ToString();
                lcl_obj_SalaryAddDedTmp.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["EFFECTIVE_MONTH"].ToString());
                lcl_obj_SalaryAddDedTmp.EffectiveYear = System.UInt16.Parse(lcl_obj_SalaryAddDedReader["EFFECTIVE_YEAR"].ToString());
                lcl_obj_SalaryAddDedTmp.IsProcessed = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_SalaryAddDedReader["IS_PROCESSED"].ToString());
                lcl_obj_SalaryAddDedTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_SalaryAddDedReader["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_SalaryAddDedReader.Close();
               return lcl_obj_SalaryAddDedTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryAddDed;
        }

        public CCL.BusinessEntities.HRIS.SalaryAdditionDeduction Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDed = null;
            lcl_obj_SalaryAddDed = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(IP_str_SqlQuery));
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (SalaryAdditionDeductionManager.Get(SqlQuery)) : No SalaryAdditionDeduction Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction lcl_obj_SalaryAddDedTmp = new SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction();
                    lcl_obj_SalaryAddDedTmp.SalaryAddDedCode = System.UInt64.Parse(dr["ADD_DED_CODE"].ToString());
                    lcl_obj_SalaryAddDedTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_SalaryAddDedTmp.AdditionOrDeduction = (SilkERP360.CCL.Enums.AdditionOrDeduction)System.UInt16.Parse(dr["ADD_OR_DED"].ToString());
                    lcl_obj_SalaryAddDedTmp.AdditionDeductionType = (SilkERP360.CCL.Enums.AdditionDeductionType)System.UInt16.Parse(dr["ADD_DED_TYPE"].ToString());
                    lcl_obj_SalaryAddDedTmp.Amount = System.Decimal.Parse(dr["AMOUNT"].ToString());
                    lcl_obj_SalaryAddDedTmp.AdditionDeductionDate = System.DateTime.Parse(dr["ADD_DED_DATE"].ToString());
                    lcl_obj_SalaryAddDedTmp.Remarks = dr["REMARKS"].ToString();
                    lcl_obj_SalaryAddDedTmp.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt16.Parse(dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_SalaryAddDedTmp.EffectiveYear = System.UInt16.Parse(dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_SalaryAddDedTmp.IsProcessed = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(dr["IS_PROCESSED"].ToString());
                    lcl_obj_SalaryAddDedTmp.EntryEmployeeCode = System.UInt64.Parse(dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    dr.Close();
                    return lcl_obj_SalaryAddDedTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SalaryAddDed;
        }

        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.Save(CCL.BusinessEntities.HRIS.SalaryAdditionDeduction IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.Save(CCL.BusinessEntities.HRIS.SalaryAdditionDeduction IP_obj_A)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.SalaryAdditionDeduction CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.SalaryAdditionDeduction CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.SalaryAdditionDeduction CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.SalaryAdditionDeduction CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.SalaryAdditionDeduction>.GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
