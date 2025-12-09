using System;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.BML.HRIS
{
    /// <summary>
    /// This class manages the Designation and DesignationCore objects
    /// </summary>
    public class DesignationManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Designation>
    {
        public DesignationManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        /// <summary>
        /// Pre-Condition : DBManager Must be initialized and Open
        /// </summary>
        /// <param name="IP_ui64_DesignationCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>
        /// if function successful but data not found, returns String message in data
        /// 
        /// </returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore getDesignationCore(System.UInt64 IP_ui64_DesignationCode, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore lcl_obj_DesignationCore = null;
            SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
            lcl_obj_DesignationCore = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("Select DEGN_NAME From Designation Where DESIGNATION_CODE = {0} AND Status = {1} AND IS_DELETED = 1", IP_ui64_DesignationCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DesignationReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_DesignationReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error : Designation (Code : {0}) Not Found!!!");
                }
                else
                {
                    lcl_obj_DesignationReader.Read();
                    lcl_obj_DesignationCore = new SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore(IP_ui64_DesignationCode, lcl_obj_DesignationReader["DEGN_NAME"].ToString());
                }
                return lcl_obj_DesignationCore;
            }, "BMLExceptionPolicy");
            return lcl_obj_DesignationCore;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_DesignationCode = 0;
            lcl_ui64_DesignationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_DesignationCode = new OracleParameter("v_DESIGNATION_CODE", OracleDbType.Int64);
                lcl_obj_DesignationCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DesignationCode.Value = lcl_obj_Designation.DesignationCode;
                OracleParameter lcl_obj_DegnName = new OracleParameter("v_DEGN_NAME", OracleDbType.NVarchar2);
                lcl_obj_DegnName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DegnName.Value = lcl_obj_Designation.DegnName;
                OracleParameter lcl_obj_ShortName = new OracleParameter("v_SHORT_NAME", OracleDbType.NVarchar2);
                lcl_obj_ShortName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShortName.Value = lcl_obj_Designation.ShortName;
                OracleParameter lcl_obj_CompanyCode = new OracleParameter("v_COMPANY_CODE", OracleDbType.Int64);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Designation.CompanyCode;
                OracleParameter lcl_obj_Basic = new OracleParameter("v_BASIC", OracleDbType.Int64);
                lcl_obj_Basic.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Basic.Value = lcl_obj_Designation.Basic;
                OracleParameter lcl_obj_HouseRent = new OracleParameter("v_HOUSE_RENT", OracleDbType.Int64);
                lcl_obj_HouseRent.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_HouseRent.Value = lcl_obj_Designation.HouseRent;
                OracleParameter lcl_obj_Medical = new OracleParameter("v_MEDICAL", OracleDbType.Int64);
                lcl_obj_Medical.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Medical.Value = lcl_obj_Designation.Medical;
                OracleParameter lcl_obj_Entertainment = new OracleParameter("v_ENTERTAINMENT", OracleDbType.Int64);
                lcl_obj_Entertainment.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Entertainment.Value = lcl_obj_Designation.Entertainment;
                OracleParameter lcl_obj_Conveyence = new OracleParameter("v_CONVEYENCE", OracleDbType.Int64);
                lcl_obj_Conveyence.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Conveyence.Value = lcl_obj_Designation.Conveyence;
                OracleParameter lcl_obj_PhoneBill = new OracleParameter("v_PHONE_BILL", OracleDbType.Int64);
                lcl_obj_PhoneBill.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PhoneBill.Value = lcl_obj_Designation.PhoneBill;
                OracleParameter lcl_obj_Others = new OracleParameter("v_OTHERS", OracleDbType.Int64);
                lcl_obj_Others.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Others.Value = lcl_obj_Designation.Others;
                OracleParameter lcl_obj_Gross = new OracleParameter("v_GROSS", OracleDbType.Int64);
                lcl_obj_Gross.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Gross.Value = lcl_obj_Designation.Gross;
                OracleParameter lcl_obj_EffectiveFrom = new OracleParameter("v_EFFECTIVE_FROM", OracleDbType.Date);
                lcl_obj_EffectiveFrom.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EffectiveFrom.Value = lcl_obj_Designation.EffectiveFrom;
                OracleParameter lcl_obj_IsOtEligible = new OracleParameter("v_IS_OT_ELIGIBLE", OracleDbType.Int64);
                lcl_obj_IsOtEligible.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsOtEligible.Value = lcl_obj_Designation.IsOtEligible;
                OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IS_DELETED", OracleDbType.Int64);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = lcl_obj_Designation.IsDeleted;
                OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_Designation.Status;
                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_DesignationCode, lcl_obj_DegnName, lcl_obj_ShortName, lcl_obj_CompanyCode, lcl_obj_Basic, lcl_obj_HouseRent, lcl_obj_Medical, lcl_obj_Entertainment, lcl_obj_Conveyence, lcl_obj_PhoneBill, lcl_obj_Others, lcl_obj_Gross, lcl_obj_EffectiveFrom, lcl_obj_IsOtEligible, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_DESIGNATION_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_DesignationCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_DesignationCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation)
        {
            UInt64 lcl_ui64_DesignationCode = 0;

            lcl_ui64_DesignationCode = this.ExceptionManager.Process<UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    string lcl_str_SqlQuery;
                   
                        // Get max department code
                        lcl_str_SqlQuery = "SELECT MAX(DESIGNATION_CODE) AS MaxDesignationCode FROM DESIGNATION";

                        var lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                        lcl_obj_IDReader.Read();

                        if (lcl_obj_IDReader["MaxDesignationCode"] != DBNull.Value)
                        {
                            lcl_ui64_DesignationCode = Convert.ToUInt64(lcl_obj_IDReader["MaxDesignationCode"]) + 1;
                        }
                        else
                        {
                        lcl_ui64_DesignationCode = 111000000001;
                        }

                        lcl_obj_IDReader.Close();

                    lcl_obj_Designation.DesignationCode = lcl_ui64_DesignationCode;

                        string insertSql = lcl_obj_Designation.GenerateSqlInsert();
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(insertSql);
                    

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                }

                return lcl_ui64_DesignationCode;

            }, "BMLExceptionPolicy");

            return lcl_ui64_DesignationCode;
        }

        public UInt64 Update(SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation)
        {
            UInt64 lcl_ui64_DesignationCode = 0;

            lcl_ui64_DesignationCode = this.ExceptionManager.Process<UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                   
                    // Update
                    lcl_ui64_DesignationCode = lcl_obj_Designation.DesignationCode;
                    string updateSql = lcl_obj_Designation.GenerateSqlUpdate();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(updateSql);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                }

                return lcl_ui64_DesignationCode;

            }, "BMLExceptionPolicy");

            return lcl_ui64_DesignationCode;
        }

        public bool DeleteDesignation(UInt64 IP_Ui64_designationCode)
        {
            bool isDeleted = this.ExceptionManager.Process<bool>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    string insertSql = "update designation set IS_DELETED=" + 0 + ",STATUS=" + 0 + " where designation_code=" + IP_Ui64_designationCode + "";
                    int rowsAffected = lcl_obj_DBManager.InternalResource.ExecuteNonQuery(insertSql);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return rowsAffected > 0;
                }
            }, "BMLExceptionPolicy");
            return isDeleted;
        }

        public CCL.BusinessEntities.HRIS.Designation Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Designation>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From DESIGNATION DESIGNATION_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorDesignation.Get(ID,DBManger)) : Error Retrieving Designation Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Designation();
                lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                lcl_obj_Tmp.DegnName = lcl_obj_dr["DEGN_NAME"].ToString();
                lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Designation;
        }
        
        public CCL.BusinessEntities.HRIS.Designation Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Designation>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select DESIGNATION_CODE
                            ,DEGN_NAME ,SHORT_NAME,COMPANY_CODE,nvl(BASIC,0) BASIC,nvl(HOUSE_RENT,0) HOUSE_RENT,nvl(MEDICAL,0)MEDICAL,nvl(ENTERTAINMENT,0)ENTERTAINMENT,nvl(CONVEYENCE,0)CONVEYENCE,
                            nvl(PHONE_BILL,0)PHONE_BILL,nvl(OTHERS,0)OTHERS,nvl(GROSS,0)GROSS,EFFECTIVE_FROM,IS_OT_ELIGABLE,IS_DELETED,STATUS From DESIGNATION where DESIGNATION_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Designation.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    lcl_obj_dr.Read();
                    SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Designation();
                    lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                    lcl_obj_Tmp.DegnName = lcl_obj_dr["DEGN_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                    lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                    lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    //lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                    //lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                    //lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    //lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                     
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Designation;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> lcl_objlist_Designation = null;
            lcl_objlist_Designation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Designation.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Designation();
                        lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                        lcl_obj_Tmp.DegnName = lcl_obj_dr["DEGN_NAME"].ToString();
                        lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                        lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                        lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                        lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                        lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                        lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                        lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                        lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                        lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                        lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                       // lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                      //  lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                       // lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_Designation;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> lcl_objlist_Designation = null;
            lcl_objlist_Designation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Designation.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Designation();
                    lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                    lcl_obj_Tmp.DegnName = lcl_obj_dr["DEGN_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                    lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                    lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                    lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_Designation;
        }


        public CCL.BusinessEntities.HRIS.Designation Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Designation>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorDesignation.Get(SqlQuery,DBManger)) : Error Retrieving Designation Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Designation();
                lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                lcl_obj_Tmp.DegnName = lcl_obj_dr["DEGN_NAME"].ToString();
                lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Designation;
        }

        public CCL.BusinessEntities.HRIS.Designation Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Designation>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Designation.Get(SqlQuery)) : No Designation Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Designation();
                    lcl_obj_Tmp.DesignationCode = System.UInt64.Parse(lcl_obj_dr["DESIGNATION_CODE"].ToString());
                    lcl_obj_Tmp.DegnName = lcl_obj_dr["DEGN_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.Basic = System.Decimal.Parse(lcl_obj_dr["BASIC"].ToString());
                    lcl_obj_Tmp.HouseRent = System.Decimal.Parse(lcl_obj_dr["HOUSE_RENT"].ToString());
                    lcl_obj_Tmp.Medical = System.Decimal.Parse(lcl_obj_dr["MEDICAL"].ToString());
                    lcl_obj_Tmp.Entertainment = System.Decimal.Parse(lcl_obj_dr["ENTERTAINMENT"].ToString());
                    lcl_obj_Tmp.Conveyence = System.Decimal.Parse(lcl_obj_dr["CONVEYENCE"].ToString());
                    lcl_obj_Tmp.PhoneBill = System.Decimal.Parse(lcl_obj_dr["PHONE_BILL"].ToString());
                    lcl_obj_Tmp.Others = System.Decimal.Parse(lcl_obj_dr["OTHERS"].ToString());
                    lcl_obj_Tmp.Gross = System.Decimal.Parse(lcl_obj_dr["GROSS"].ToString());
                    lcl_obj_Tmp.EffectiveFrom = System.DateTime.Parse(lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                    lcl_obj_Tmp.IsOtEligible = System.UInt16.Parse(lcl_obj_dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Designation;
        }

    }
}
