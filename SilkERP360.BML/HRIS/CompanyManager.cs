using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class CompanyManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Company>


    {
       public CompanyManager()
       {
           //ExceptionManagement Initialization
           this.Initialize();
       }

       /// <summary>
       /// Pre-Condition : DBManager Must be initialized and Open
       /// </summary>
       /// <param name="IP_ui64_CompanyCode"></param>
       /// <param name="IP_obj_DBManager"></param>
       /// <returns>
       /// if function successful but data not found, returns String message in data
       /// 
       /// </returns>
       public SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore getCompanyCore(System.UInt64 IP_ui64_CompanyCode, System.Object IP_obj_DBManager)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore lcl_obj_CompanyCore = null;
          
           lcl_obj_CompanyCore = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               System.String lcl_str_SqlQuery = System.String.Format("Select NAME From COMPANY Where COMPANY_CODE = {0} AND Status = {1} AND IS_DELETED = 1", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
               System.Data.OracleClient.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_CompanyReader.HasRows == false)
               {
                   System.String lcl_str_ErrorMessage = System.String.Format("Fatal Error : Company (Code : {0}) Not Found!!!", IP_ui64_CompanyCode);
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_str_ErrorMessage);
               }
               else
               {
                   lcl_obj_CompanyReader.Read();
                   lcl_obj_CompanyCore = new SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore(IP_ui64_CompanyCode, lcl_obj_CompanyReader["NAME"].ToString());
               }
               lcl_obj_CompanyReader.Close();
               return lcl_obj_CompanyCore;

           }, "BMLExceptionPolicy");
           return lcl_obj_CompanyCore;
       }


       /// <summary>
       /// Will have it's own DBManager fetched from DBManager Pool
       /// </summary>
       /// <param name="IP_ui64_CompanyCode"></param>
       /// <returns>
       /// if function successful but data not found, returns String message in data
       /// 
       /// </returns>
       public SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore getCompanyCore(System.UInt64 IP_ui64_CompanyCode)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore lcl_obj_CompanyCore = null;
           lcl_obj_CompanyCore = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   System.String lcl_str_SqlQuery = System.String.Format("Select COMPANY_NAME From COMPANY Where COMPANY_CODE = {0} AND Status = {1} AND IS_DELETED = 1", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                   System.Data.OracleClient.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_CompanyReader.HasRows == false)
                   {
                       System.String lcl_str_ErrorMessage = System.String.Format("Fatal Error : Company (Code : {0}) Not Found!!!", IP_ui64_CompanyCode);
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_str_ErrorMessage);
                   }
                   else
                   {
                       lcl_obj_CompanyReader.Read();
                       lcl_obj_CompanyCore = new SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore(IP_ui64_CompanyCode, lcl_obj_CompanyReader["NAME"].ToString());
                   }
               }
               return lcl_obj_CompanyCore;

           }, "BMLExceptionPolicy");
           return lcl_obj_CompanyCore;
       }

        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="IP_ui64_DesignationCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        /// 
       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company,System.Object IP_obj_DBManager)
              {
            System.UInt64 lcl_ui64_CompanyCode = 0;
          
            lcl_ui64_CompanyCode = this.ExceptionManager.Process<System.UInt64>(() =>            
              
                {
                    SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                    if (lcl_obj_Company.Validate() == false)
                    {
                        System.Text.StringBuilder lcl_objSB_Msg = new System.Text.StringBuilder();
                        SilkERP360.CCL.Validation.Collections.ValidationErrorCollection lcl_obj_ValidationErrors = lcl_obj_Company.ValidationErrorsCollection;
                        foreach (SilkERP360.CCL.Validation.ErrorsExceptions.ValidationError lcl_obj_ValidationError in lcl_obj_ValidationErrors)
                        {
                            lcl_objSB_Msg.Append(lcl_obj_ValidationError.ErrorMessage);
                            lcl_objSB_Msg.Append("<br/>");
                        }
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_objSB_Msg.ToString());
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("v_CompanyCode", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_CompanyCode.Value = lcl_obj_Company.CompanyCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_Name = new System.Data.OracleClient.OracleParameter("v_Name", System.Data.OracleClient.OracleType.NVarChar,200);
                    lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Name.Value = lcl_obj_Company.Name;

                    System.Data.OracleClient.OracleParameter lcl_obj_Address = new System.Data.OracleClient.OracleParameter("v_Address", System.Data.OracleClient.OracleType.NVarChar,200);
                    lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Address.Value = lcl_obj_Company.Address;

                    System.Data.OracleClient.OracleParameter lcl_obj_PhoneNo = new System.Data.OracleClient.OracleParameter("v_PhoneNO", System.Data.OracleClient.OracleType.NVarChar,100);
                    lcl_obj_PhoneNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PhoneNo.Value = lcl_obj_Company.PhoneNo;

                    System.Data.OracleClient.OracleParameter lcl_obj_FaxNo = new System.Data.OracleClient.OracleParameter("v_FaxNo", System.Data.OracleClient.OracleType.NVarChar,100);
                    lcl_obj_FaxNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_FaxNo.Value = lcl_obj_Company.FaxNo;

                    System.Data.OracleClient.OracleParameter lcl_obj_Email = new System.Data.OracleClient.OracleParameter("v_Email", System.Data.OracleClient.OracleType.NVarChar,200);
                    lcl_obj_Email.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Email.Value = lcl_obj_Company.Email;

                    System.Data.OracleClient.OracleParameter lcl_obj_WebSite = new System.Data.OracleClient.OracleParameter("v_WebSite", System.Data.OracleClient.OracleType.NVarChar,100);
                    lcl_obj_WebSite.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_WebSite.Value = lcl_obj_Company.WebSite;

                    System.Data.OracleClient.OracleParameter lcl_obj_CompanyShortName = new System.Data.OracleClient.OracleParameter("v_CompanyShortName", System.Data.OracleClient.OracleType.NVarChar, 100);
                    lcl_obj_CompanyShortName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CompanyShortName.Value = lcl_obj_Company.CompanyShortName;

                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IsDeleted", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj_Company.IsDeleted;

                    System.Data.OracleClient.OracleParameter lcl_obj_status = new System.Data.OracleClient.OracleParameter("v_Status", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_status.Value = lcl_obj_Company.Status;

                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_CompanyCode, lcl_obj_Name, lcl_obj_Address, lcl_obj_PhoneNo, lcl_obj_FaxNo, lcl_obj_Email, lcl_obj_WebSite, lcl_obj_CompanyShortName, lcl_obj_IsDeleted, lcl_obj_status };
                    lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_COMPANY", lcl_obj_SP_Parameters);

                    return System.UInt64.Parse(lcl_obj_CompanyCode.Value.ToString());
                }, "BMLExceptionPolicy");

                return lcl_ui64_CompanyCode;
            }

    /// <summary>
/// /////////
/// </summary>
/// <param name="lcl_obj_EmployeeAttandance"></param>
/// <returns></returns>

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company)
       {
          System.UInt64 lcl_ui64_CompanyCode = 0;

           lcl_ui64_CompanyCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("v_CompanyCode", System.Data.OracleClient.OracleType.Number);
              lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Output;
             // lcl_obj_CompanyCode.Value = lcl_obj_Company.CompanyCode;

              System.Data.OracleClient.OracleParameter lcl_obj_Name = new System.Data.OracleClient.OracleParameter("v_Name", System.Data.OracleClient.OracleType.NVarChar, 200);
              lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_Name.Value = lcl_obj_Company.Name;

              System.Data.OracleClient.OracleParameter lcl_obj_Address = new System.Data.OracleClient.OracleParameter("v_Address", System.Data.OracleClient.OracleType.NVarChar, 200);
              lcl_obj_Address.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_Address.Value = lcl_obj_Company.Address;

              System.Data.OracleClient.OracleParameter lcl_obj_PhoneNo = new System.Data.OracleClient.OracleParameter("v_PhoneNO", System.Data.OracleClient.OracleType.NVarChar, 100);
              lcl_obj_PhoneNo.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_PhoneNo.Value = lcl_obj_Company.PhoneNo;

              System.Data.OracleClient.OracleParameter lcl_obj_FaxNo = new System.Data.OracleClient.OracleParameter("v_FaxNo", System.Data.OracleClient.OracleType.NVarChar, 100);
              lcl_obj_FaxNo.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_FaxNo.Value = lcl_obj_Company.FaxNo;

              System.Data.OracleClient.OracleParameter lcl_obj_Email = new System.Data.OracleClient.OracleParameter("v_Email", System.Data.OracleClient.OracleType.NVarChar, 200);
              lcl_obj_Email.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_Email.Value = lcl_obj_Company.Email;

              System.Data.OracleClient.OracleParameter lcl_obj_WebSite = new System.Data.OracleClient.OracleParameter("v_WebSite", System.Data.OracleClient.OracleType.NVarChar, 100);
              lcl_obj_WebSite.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_WebSite.Value = lcl_obj_Company.WebSite;

              System.Data.OracleClient.OracleParameter lcl_obj_CompanyShortName = new System.Data.OracleClient.OracleParameter("v_CompanyShortName", System.Data.OracleClient.OracleType.NVarChar, 100);
              lcl_obj_CompanyShortName.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_CompanyShortName.Value = lcl_obj_Company.CompanyShortName;

              System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IsDeleted", System.Data.OracleClient.OracleType.Number);
              lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_IsDeleted.Value = 1;

              System.Data.OracleClient.OracleParameter lcl_obj_status = new System.Data.OracleClient.OracleParameter("v_Status", System.Data.OracleClient.OracleType.Number);
              lcl_obj_status.Direction = System.Data.ParameterDirection.Input;
              lcl_obj_status.Value = 1;

              System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_CompanyCode, lcl_obj_Name, lcl_obj_Address, lcl_obj_PhoneNo, lcl_obj_FaxNo, lcl_obj_Email, lcl_obj_WebSite,lcl_obj_CompanyShortName, lcl_obj_IsDeleted, lcl_obj_status };
              lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INS_COMPANY", lcl_obj_SP_Parameters);

              lcl_obj_DBManager.InternalResource.CommitTransaction();
              lcl_obj_DBManager.InternalResource.Close();

              return System.UInt64.Parse(lcl_obj_CompanyCode.Value.ToString());
                }
          }, "BMLExceptionPolicy");

        return lcl_ui64_CompanyCode;
    }   



        public SilkERP360.CCL.BusinessEntities.HRIS.Company Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = null;
            
            lcl_obj_Company = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Company>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From COMPANY Where COMPANY_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_CompanyReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error CompanyManager.Get(Company_Code,DBManger)) : Error Retrieving Company Data!");
                }
                lcl_obj_CompanyReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_CompanyTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                lcl_obj_CompanyTmp.CompanyCode = System.UInt64.Parse(lcl_obj_CompanyReader["COMPANY_CODE"].ToString());
                lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["Name"].ToString();
                //lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["ADDRESS"].ToString();
                //lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["PHONE_NO"].ToString();
                lcl_obj_CompanyTmp.FaxNo = lcl_obj_CompanyReader["FAX_NO"].ToString();
                lcl_obj_CompanyTmp.Email = lcl_obj_CompanyReader["EMAIL"].ToString();
                lcl_obj_CompanyTmp.WebSite = lcl_obj_CompanyReader["WEB_SITE"].ToString();
                lcl_obj_CompanyTmp.WebSite = lcl_obj_CompanyReader["COMPANY_SHORT_NAME"].ToString();
                lcl_obj_CompanyTmp.IsDeleted = System.UInt16.Parse(lcl_obj_CompanyReader["IS_DELETED"].ToString());
                lcl_obj_CompanyTmp.Status = System.UInt16.Parse(lcl_obj_CompanyReader["STATUS"].ToString());

                lcl_obj_CompanyReader.Close();
                return lcl_obj_CompanyTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Company;
        }
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <returns></returns>

        public CCL.BusinessEntities.HRIS.Company Get(ulong IP_ui64_Code)
        {
           SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = null;
           lcl_obj_Company = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Company>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From COMPANY Where COMPANY_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CompanyManager.Get(ID)) : No Company Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_CompanyTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                    lcl_obj_CompanyTmp.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                    lcl_obj_CompanyTmp.Name = dr["Name"].ToString();
                    lcl_obj_CompanyTmp.Name = dr["ADDRESS"].ToString();
                    lcl_obj_CompanyTmp.Name = dr["PHONE_NO"].ToString();
                    lcl_obj_CompanyTmp.FaxNo = dr["FAX_NO"].ToString();
                    lcl_obj_CompanyTmp.Email = dr["EMAIL"].ToString();
                    lcl_obj_CompanyTmp.WebSite = dr["WEB_SITE"].ToString();
                    lcl_obj_CompanyTmp.WebSite = dr["COMPANY_SHORT_NAME"].ToString();
                    lcl_obj_CompanyTmp.IsDeleted = System.UInt16.Parse(dr["IS_DELETED"].ToString());
                    lcl_obj_CompanyTmp.Status = System.UInt16.Parse(dr["STATUS"].ToString());

                    dr.Close();
                    return lcl_obj_CompanyTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Company;
            }

        /// <summary>
        /// ////////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>


        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> GetList(string IP_str_SqlQuery,System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_Company = null;
           
            lcl_objLst_Company = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                //if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                //{
                //    lcl_obj_DBManager.Open();
                //}
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    dr.Close();
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CompanyManager.GetList(SqlQuery,DBManager)) : No Company Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_CompanyTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                    lcl_obj_Company.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                    lcl_obj_Company.Name = dr["Name"].ToString();
                    lcl_obj_Company.Address = dr["ADDRESS"].ToString();
                    lcl_obj_Company.PhoneNo = dr["PHONE_NO"].ToString();
                    lcl_obj_Company.FaxNo = dr["FAX_NO"].ToString();
                    lcl_obj_Company.Email = dr["EMAIL"].ToString();
                    lcl_obj_Company.WebSite = dr["WEB_SITE"].ToString();
                    lcl_obj_Company.CompanyShortName = dr["COMPANY_SHORT_NAME"].ToString();
                    lcl_obj_Company.IsDeleted = System.UInt16.Parse(dr["IS_DELETED"].ToString());
                    lcl_obj_Company.Status = System.UInt16.Parse(dr["STATUS"].ToString());
                    lcl_objLst_CompanyTmp.Add(lcl_obj_Company);
                }
                    dr.Close();
                    return lcl_objLst_CompanyTmp;
                
            }, "BMLExceptionPolicy");
            return lcl_objLst_Company;
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <returns></returns>


        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> GetList(string IP_str_SqlQuery)
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_Company = null;
                lcl_objLst_Company = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company>>(() =>
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
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CompanyManager.GetList(SqlQuery)) : No Company Data Found In The Database!!!");
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_CompanyTmp = new
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company>();
                        while (dr.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                            lcl_obj_Company.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                            lcl_obj_Company.Name = dr["NAME"].ToString();
                            lcl_obj_Company.Address = dr["ADDRESS"].ToString();
                            lcl_obj_Company.PhoneNo = dr["PHONE_NO"].ToString();
                            lcl_obj_Company.FaxNo = dr["FAX_NO"].ToString();
                            lcl_obj_Company.Email = dr["EMAIL"].ToString();
                            lcl_obj_Company.WebSite = dr["WEB_SITE"].ToString();
                            lcl_obj_Company.WebSite = dr["COMPANY_SHORT_NAME"].ToString();
                           // lcl_obj_Company.IsDeleted = System.UInt16.Parse(dr["IS_DELETED"].ToString());
                           // lcl_obj_Company.Status = System.UInt16.Parse(dr["STATUS"].ToString());
                            lcl_objLst_CompanyTmp.Add(lcl_obj_Company);
                        }
                        dr.Close();
                        return lcl_objLst_CompanyTmp;
                    }
                }, "BMLExceptionPolicy");
                return lcl_objLst_Company;
        
        }




        public CCL.BusinessEntities.HRIS.Company Get(string IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = null;
            
            lcl_obj_Company = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Company>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_CompanyReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error CompanyManager.Get(SqlQuery,DBManger)) : Error Retrieving Company Data!");
                }
                lcl_obj_CompanyReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_CompanyTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                lcl_obj_CompanyTmp.CompanyCode = System.UInt64.Parse(lcl_obj_CompanyReader["COMPANY_CODE"].ToString());
                lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["Name"].ToString();
                lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["ADDRESS"].ToString();
                lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["PHONE_NO"].ToString();
                lcl_obj_CompanyTmp.FaxNo = lcl_obj_CompanyReader["FAX_NO"].ToString();
                lcl_obj_CompanyTmp.Email = lcl_obj_CompanyReader["EMAIL"].ToString();
                lcl_obj_CompanyTmp.WebSite = lcl_obj_CompanyReader["WEB_SITE"].ToString();
                lcl_obj_CompanyTmp.WebSite = lcl_obj_CompanyReader["COMPANY_SHORT_NAME"].ToString();
                lcl_obj_CompanyTmp.IsDeleted = System.UInt16.Parse(lcl_obj_CompanyReader["IS_DELETED"].ToString());
                lcl_obj_CompanyTmp.Status = System.UInt16.Parse(lcl_obj_CompanyReader["STATUS"].ToString());

                lcl_obj_CompanyReader.Close();
                return lcl_obj_CompanyTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Company;
        }

        public CCL.BusinessEntities.HRIS.Company Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company = null;
            lcl_obj_Company = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Company>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CompanyManager.Get(SqlQuery)) : No Company Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_CompanyTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                    lcl_obj_CompanyTmp.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                    lcl_obj_CompanyTmp.Name = dr["Name"].ToString();
                    lcl_obj_CompanyTmp.Name = dr["ADDRESS"].ToString();
                    lcl_obj_CompanyTmp.Name = dr["PHONE_NO"].ToString();
                    lcl_obj_CompanyTmp.FaxNo = dr["FAX_NO"].ToString();
                    lcl_obj_CompanyTmp.Email = dr["EMAIL"].ToString();
                    lcl_obj_CompanyTmp.WebSite = dr["WEB_SITE"].ToString();
                    lcl_obj_CompanyTmp.WebSite = dr["COMPANY_SHORT_NAME"].ToString();
                    lcl_obj_CompanyTmp.IsDeleted = System.UInt16.Parse(dr["IS_DELETED"].ToString());
                    lcl_obj_CompanyTmp.Status = System.UInt16.Parse(dr["STATUS"].ToString());

                    dr.Close();
                    return lcl_obj_CompanyTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Company;
        }



        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.Save(CCL.BusinessEntities.HRIS.Company IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.Save(CCL.BusinessEntities.HRIS.Company IP_obj_A)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.Company CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.Company CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.Company CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.Company CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.HRIS.Company> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.HRIS.Company> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Company>.GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
