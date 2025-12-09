using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeSalaryStructureManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>
    {
        public EmployeeSalaryStructureManger()
        {
            this.Initialize();
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeSalaryStructureCode = 0;
            lcl_ui64_EmployeeSalaryStructureCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_SalaryStructureCode = new OracleParameter("v_SALARY_STRUCTURE_CODE", OracleDbType.Int64);
                lcl_obj_SalaryStructureCode.Direction = System.Data.ParameterDirection.Output;
               

                OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeSalaryStructure.EmployeeCode;

                OracleParameter lcl_obj_Basic = new OracleParameter("v_BASIC", OracleDbType.Int64);
                lcl_obj_Basic.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Basic.Value = lcl_obj_EmployeeSalaryStructure.Basic;

                OracleParameter lcl_obj_HouseRent = new OracleParameter("v_HOUSE_RENT", OracleDbType.Int64);
                lcl_obj_HouseRent.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_HouseRent.Value = lcl_obj_EmployeeSalaryStructure.HouseRent;

                OracleParameter lcl_obj_Medical = new OracleParameter("v_MEDICAL", OracleDbType.Int64);
                lcl_obj_Medical.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Medical.Value = lcl_obj_EmployeeSalaryStructure.Medical;

                OracleParameter lcl_obj_Entertainment = new OracleParameter("v_ENTERTAINMENT", OracleDbType.Int64);
                lcl_obj_Entertainment.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Entertainment.Value = lcl_obj_EmployeeSalaryStructure.Entertainment;

                OracleParameter lcl_obj_Conveyence = new OracleParameter("v_CONVEYENCE", OracleDbType.Int64);
                lcl_obj_Conveyence.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Conveyence.Value = lcl_obj_EmployeeSalaryStructure.Conveyence;

                OracleParameter lcl_obj_PhoneBill = new OracleParameter("v_PHONE_BILL", OracleDbType.Int64);
                lcl_obj_PhoneBill.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PhoneBill.Value = lcl_obj_EmployeeSalaryStructure.PhoneBill;

                OracleParameter lcl_obj_Others = new OracleParameter("v_OTHERS", OracleDbType.Int64);
                lcl_obj_Others.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Others.Value = lcl_obj_EmployeeSalaryStructure.Others;

                OracleParameter lcl_obj_Gross = new OracleParameter("v_GROSS", OracleDbType.Int64);
                lcl_obj_Gross.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Gross.Value = lcl_obj_EmployeeSalaryStructure.Gross;

                OracleParameter lcl_obj_EffectiveFrom = new OracleParameter("v_EFFECTIVE_FROM", OracleDbType.Date);
                lcl_obj_EffectiveFrom.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EffectiveFrom.Value = lcl_obj_EmployeeSalaryStructure.EffectiveFrom;

                OracleParameter lcl_obj_EffectiveUpto = new OracleParameter("v_EFFECTIVE_UPTO", OracleDbType.Date);
                lcl_obj_EffectiveUpto.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EffectiveUpto.Value = lcl_obj_EmployeeSalaryStructure.EffectiveUpto;

                OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = 1;

                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalaryStructureCode,lcl_obj_EmployeeCode, lcl_obj_Basic, lcl_obj_HouseRent, lcl_obj_Medical, lcl_obj_Entertainment, lcl_obj_Conveyence, lcl_obj_PhoneBill, lcl_obj_Others, lcl_obj_Gross, lcl_obj_EffectiveFrom, lcl_obj_EffectiveUpto, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_SALARY_STRUCTURE_IU", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_SalaryStructureCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeSalaryStructureCode;
        }


        public ulong Update(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeSalaryStructureCode = 0;
            lcl_ui64_EmployeeSalaryStructureCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_SalaryStructureCode = new OracleParameter("v_SALARY_STRUCTURE_CODE", OracleDbType.Int64);
                lcl_obj_SalaryStructureCode.Direction = System.Data.ParameterDirection.Output;


                OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeSalaryStructure.EmployeeCode;

                OracleParameter lcl_obj_Basic = new OracleParameter("v_BASIC", OracleDbType.Int64);
                lcl_obj_Basic.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Basic.Value = lcl_obj_EmployeeSalaryStructure.Basic;

                OracleParameter lcl_obj_HouseRent = new OracleParameter("v_HOUSE_RENT", OracleDbType.Int64);
                lcl_obj_HouseRent.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_HouseRent.Value = lcl_obj_EmployeeSalaryStructure.HouseRent;

                OracleParameter lcl_obj_Medical = new OracleParameter("v_MEDICAL", OracleDbType.Int64);
                lcl_obj_Medical.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Medical.Value = lcl_obj_EmployeeSalaryStructure.Medical;

                OracleParameter lcl_obj_Entertainment = new OracleParameter("v_ENTERTAINMENT", OracleDbType.Int64);
                lcl_obj_Entertainment.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Entertainment.Value = lcl_obj_EmployeeSalaryStructure.Entertainment;

                OracleParameter lcl_obj_Conveyence = new OracleParameter("v_CONVEYENCE", OracleDbType.Int64);
                lcl_obj_Conveyence.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Conveyence.Value = lcl_obj_EmployeeSalaryStructure.Conveyence;

                OracleParameter lcl_obj_PhoneBill = new OracleParameter("v_PHONE_BILL", OracleDbType.Int64);
                lcl_obj_PhoneBill.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PhoneBill.Value = lcl_obj_EmployeeSalaryStructure.PhoneBill;

                OracleParameter lcl_obj_Others = new OracleParameter("v_OTHERS", OracleDbType.Int64);
                lcl_obj_Others.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Others.Value = lcl_obj_EmployeeSalaryStructure.Others;

                OracleParameter lcl_obj_Gross = new OracleParameter("v_GROSS", OracleDbType.Int64);
                lcl_obj_Gross.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Gross.Value = lcl_obj_EmployeeSalaryStructure.Gross;

                //OracleParameter lcl_obj_EffectiveFrom = new OracleParameter("v_EFFECTIVE_FROM", OracleDbType.Date);
                //lcl_obj_EffectiveFrom.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_EffectiveFrom.Value = lcl_obj_EmployeeSalaryStructure.EffectiveFrom;

                //OracleParameter lcl_obj_EffectiveUpto = new OracleParameter("v_EFFECTIVE_UPTO", OracleDbType.Date);
                //lcl_obj_EffectiveUpto.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_EffectiveUpto.Value = lcl_obj_EmployeeSalaryStructure.EffectiveUpto;

                //OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                //lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_IsDeleted.Value = 1;

                //OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                //lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_Status.Value = 1;

                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalaryStructureCode, lcl_obj_EmployeeCode, lcl_obj_Basic, lcl_obj_HouseRent, lcl_obj_Medical, lcl_obj_Entertainment, lcl_obj_Conveyence, lcl_obj_PhoneBill, lcl_obj_Others, lcl_obj_Gross };//lcl_obj_EffectiveFrom, lcl_obj_EffectiveUpto,, lcl_obj_IsDeleted, lcl_obj_Status,
                lcl_obj_DBManager.ExecuteStoredProcedure("EMP_SALARY_STRUCTURE_UPDT_IU", lcl_obj_SP_Parameters);

                return 0;
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeSalaryStructureCode;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure)
        {
            System.UInt64 lcl_ui64_EmployeeSalaryStructureCode = 0;
            lcl_ui64_EmployeeSalaryStructureCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_SalaryStructureCode = new OracleParameter("v_SALARY_STRUCTURE_CODE", OracleDbType.Int64);
                    lcl_obj_SalaryStructureCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SalaryStructureCode.Value = lcl_obj_EmployeeSalaryStructure.SalaryStructureCode;
                    OracleParameter lcl_obj_EmployeeCode = new OracleParameter("v_EMPLOYEE_CODE", OracleDbType.Int64);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeSalaryStructure.EmployeeCode;
                    OracleParameter lcl_obj_Basic = new OracleParameter("v_BASIC", OracleDbType.Int64);
                    lcl_obj_Basic.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Basic.Value = lcl_obj_EmployeeSalaryStructure.Basic;
                    OracleParameter lcl_obj_HouseRent = new OracleParameter("v_HOUSE_RENT", OracleDbType.Int64);
                    lcl_obj_HouseRent.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_HouseRent.Value = lcl_obj_EmployeeSalaryStructure.HouseRent;
                    OracleParameter lcl_obj_Medical = new OracleParameter("v_MEDICAL", OracleDbType.Int64);
                    lcl_obj_Medical.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Medical.Value = lcl_obj_EmployeeSalaryStructure.Medical;
                    OracleParameter lcl_obj_Entertainment = new OracleParameter("v_ENTERTAINMENT", OracleDbType.Int64);
                    lcl_obj_Entertainment.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Entertainment.Value = lcl_obj_EmployeeSalaryStructure.Entertainment;
                    OracleParameter lcl_obj_Conveyence = new OracleParameter("v_CONVEYENCE", OracleDbType.Int64);
                    lcl_obj_Conveyence.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Conveyence.Value = lcl_obj_EmployeeSalaryStructure.Conveyence;
                    OracleParameter lcl_obj_PhoneBill = new OracleParameter("v_PHONE_BILL", OracleDbType.Int64);
                    lcl_obj_PhoneBill.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PhoneBill.Value = lcl_obj_EmployeeSalaryStructure.PhoneBill;
                    OracleParameter lcl_obj_Others = new OracleParameter("v_OTHERS", OracleDbType.Int64);
                    lcl_obj_Others.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Others.Value = lcl_obj_EmployeeSalaryStructure.Others;
                    OracleParameter lcl_obj_Gross = new OracleParameter("v_GROSS", OracleDbType.Int64);
                    lcl_obj_Gross.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Gross.Value = lcl_obj_EmployeeSalaryStructure.Gross;
                    OracleParameter lcl_obj_EffectiveFrom = new OracleParameter("v_EFFECTIVE_FROM", OracleDbType.Date);
                    lcl_obj_EffectiveFrom.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EffectiveFrom.Value = lcl_obj_EmployeeSalaryStructure.EffectiveFrom;
                    OracleParameter lcl_obj_EffectiveUpto = new OracleParameter("v_EFFECTIVE_UPTO", OracleDbType.Date);
                    lcl_obj_EffectiveUpto.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EffectiveUpto.Value = lcl_obj_EmployeeSalaryStructure.EffectiveUpto;
                    OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj_EmployeeSalaryStructure.IsDeleted;
                    OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_EmployeeSalaryStructure.Status;
                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SalaryStructureCode, lcl_obj_EmployeeCode, lcl_obj_Basic, lcl_obj_HouseRent, lcl_obj_Medical, lcl_obj_Entertainment, lcl_obj_Conveyence, lcl_obj_PhoneBill, lcl_obj_Others, lcl_obj_Gross, lcl_obj_EffectiveFrom, lcl_obj_EffectiveUpto, lcl_obj_IsDeleted, lcl_obj_Status, };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.EmployeeSalaryStructure_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_SalaryStructureCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeSalaryStructureCode;
        }
        public CCL.BusinessEntities.HRIS.EmployeeSalaryStructure Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure = null;
            lcl_obj_EmployeeSalaryStructure = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_SALARY_STRUCTURE WHERE EMPLOYEE_CODE= {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeeSalaryStructure.Get(ID,DBManger)) : Error Retrieving EmployeeSalaryStructure Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                lcl_obj_Tmp.SalaryStructureCode = System.UInt64.Parse(lcl_obj_dr["SALARY_STRUCTURE_CODE"].ToString());
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
               // lcl_obj_Tmp.EffectiveUpto = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_UPTO"].ToString());
                lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeSalaryStructure;
        }

        public CCL.BusinessEntities.HRIS.EmployeeSalaryStructure Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure = null;
            lcl_obj_EmployeeSalaryStructure = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_SALARY_STRUCTURE EMPLOYEE_SALARY_STRUCTURE_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeSalaryStructure.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                    lcl_obj_Tmp.SalaryStructureCode = System.UInt64.Parse(lcl_obj_dr["SALARY_STRUCTURE_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                    lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                    lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                   // lcl_obj_Tmp.EffectiveUpto = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_UPTO"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeSalaryStructure;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure> lcl_objlist_EmployeeSalaryStructure = null;
            lcl_objlist_EmployeeSalaryStructure = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeSalaryStructure.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                        lcl_obj_Tmp.SalaryStructureCode = System.UInt64.Parse(lcl_obj_dr["SALARY_STRUCTURE_CODE"].ToString());
                        lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                        lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                        lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                        lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                        lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                        lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                        lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                        lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                        lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                        //lcl_obj_Tmp.EffectiveUpto = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_UPTO"].ToString());
                        lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                        lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeSalaryStructure;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure> lcl_objlist_EmployeeSalaryStructure = null;
            lcl_objlist_EmployeeSalaryStructure = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeSalaryStructure.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                    lcl_obj_Tmp.SalaryStructureCode = System.UInt64.Parse(lcl_obj_dr["SALARY_STRUCTURE_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                    lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                    lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                    //lcl_obj_Tmp.EffectiveUpto = ((lcl_obj_dr["EFFECTIVE_UPTO"] == null) ? System.DateTime.MinValue : System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_UPTO"].ToString()));
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeeSalaryStructure;
        }



        public CCL.BusinessEntities.HRIS.EmployeeSalaryStructure Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure = null;
            lcl_obj_EmployeeSalaryStructure = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    lcl_obj_dr.Close();
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeeSalaryStructure.Get(SqlQuery,DBManger)) : Error Retrieving EmployeeSalaryStructure Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                lcl_obj_Tmp.SalaryStructureCode = System.UInt64.Parse(lcl_obj_dr["SALARY_STRUCTURE_CODE"].ToString());
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
               // lcl_obj_Tmp.EffectiveUpto = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_UPTO"].ToString());
                lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeSalaryStructure;
        }

        public CCL.BusinessEntities.HRIS.EmployeeSalaryStructure Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_EmployeeSalaryStructure = null;
            lcl_obj_EmployeeSalaryStructure = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeSalaryStructure.Get(SqlQuery)) : No EmployeeSalaryStructure Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                    lcl_obj_Tmp.SalaryStructureCode = System.UInt64.Parse(lcl_obj_dr["SALARY_STRUCTURE_CODE"].ToString());
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                    lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                    lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                    //lcl_obj_Tmp.EffectiveUpto = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_UPTO"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.Int16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.Int16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeSalaryStructure;
        }

       }
}