using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using System.Linq;
using System.Text;



namespace SilkERP360.BML.HRIS
{
   public class CompanyManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Company>


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
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
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
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
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
        /// /////////
        /// </summary>
        /// <param name="lcl_obj_Company"></param>
        /// <returns></returns>
        public UInt64 Save(CCL.BusinessEntities.HRIS.Company lcl_obj_Company)
        {
            

            UInt64 lcl_ui64_CompanyCode = 0;

            lcl_ui64_CompanyCode = this.ExceptionManager.Process<UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    string lcl_str_SqlQuery;

                    // If CompanyCode is 0 -> INSERT
                    if (lcl_obj_Company.CompanyCode == 0)
                    {
                        // Get max company code
                        lcl_str_SqlQuery = "SELECT MAX(COMPANY_CODE) AS MaxCompanyCode FROM COMPANY";

                        var lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                        lcl_obj_IDReader.Read();

                        if (lcl_obj_IDReader["MaxCompanyCode"] != DBNull.Value)
                        {
                            lcl_ui64_CompanyCode = Convert.ToUInt64(lcl_obj_IDReader["MaxCompanyCode"]) + 1;
                        }
                        else
                        {
                            lcl_ui64_CompanyCode = 110000000001;
                        }

                        lcl_obj_IDReader.Close();

                        lcl_obj_Company.CompanyCode = lcl_ui64_CompanyCode;

                        string insertSql = lcl_obj_Company.GenerateSqlInsert();
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(insertSql);
                    }
                    else
                    {
                        // Update path
                        lcl_ui64_CompanyCode = lcl_obj_Company.CompanyCode;
                        string updateSql = lcl_obj_Company.GenerateSqlUpdate(); // You must implement this method as we discussed earlier
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(updateSql);
                    }

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                }

                return lcl_ui64_CompanyCode;

            }, "BMLExceptionPolicy");
            return lcl_ui64_CompanyCode;
        }

        public bool DeleteCompany(CCL.BusinessEntities.HRIS.Company lcl_obj_Company)
        {
            bool isDeleted = this.ExceptionManager.Process<bool>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    //string insertSql = "delete company where company_code=" + lcl_obj_Company.CompanyCode + "";
                    string insertSql = "update company set IS_DELETED="+0+",STATUS="+0+" where company_code=" + lcl_obj_Company.CompanyCode + "";

                    int rowsAffected = lcl_obj_DBManager.InternalResource.ExecuteNonQuery(insertSql);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return rowsAffected > 0;
                }

                

            }, "BMLExceptionPolicy");
            return isDeleted;
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
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_CompanyReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error CompanyManager.Get(Company_Code,DBManger)) : Error Retrieving Company Data!");
                }
                lcl_obj_CompanyReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_CompanyTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                lcl_obj_CompanyTmp.CompanyCode = Convert.ToUInt64(lcl_obj_CompanyReader["COMPANY_CODE"].ToString());
                lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["Name"].ToString();
                //lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["ADDRESS"].ToString();
                //lcl_obj_CompanyTmp.Name = lcl_obj_CompanyReader["PHONE_NO"].ToString();
                lcl_obj_CompanyTmp.FaxNo = lcl_obj_CompanyReader["FAX_NO"].ToString();
                lcl_obj_CompanyTmp.Email = lcl_obj_CompanyReader["EMAIL"].ToString();
                lcl_obj_CompanyTmp.WebSite = lcl_obj_CompanyReader["WEB_SITE"].ToString();
                lcl_obj_CompanyTmp.WebSite = lcl_obj_CompanyReader["COMPANY_SHORT_NAME"].ToString();
                lcl_obj_CompanyTmp.IsDeleted = Convert.ToInt16(lcl_obj_CompanyReader["IS_DELETED"].ToString());
                lcl_obj_CompanyTmp.Status = Convert.ToInt16(lcl_obj_CompanyReader["STATUS"].ToString());

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
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From COMPANY Where COMPANY_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CompanyManager.Get(ID)) : No Company Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_CompanyTmp = new SilkERP360.CCL.BusinessEntities.HRIS.Company();
                    lcl_obj_CompanyTmp.CompanyCode = Convert.ToUInt64(dr["COMPANY_CODE"]);
                    lcl_obj_CompanyTmp.Name = dr["Name"].ToString();
                    lcl_obj_CompanyTmp.Name = dr["ADDRESS"].ToString();
                    lcl_obj_CompanyTmp.Name = dr["PHONE_NO"].ToString();
                    lcl_obj_CompanyTmp.FaxNo = dr["FAX_NO"].ToString();
                    lcl_obj_CompanyTmp.Email = dr["EMAIL"].ToString();
                    lcl_obj_CompanyTmp.WebSite = dr["WEB_SITE"].ToString();
                    lcl_obj_CompanyTmp.WebSite = dr["COMPANY_SHORT_NAME"].ToString();
                    lcl_obj_CompanyTmp.IsDeleted = Convert.ToInt16(dr["IS_DELETED"]);
                    lcl_obj_CompanyTmp.Status = Convert.ToInt16(dr["STATUS"]);

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
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
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
                    lcl_obj_Company.CompanyCode = Convert.ToUInt64(dr["COMPANY_CODE"]);
                    lcl_obj_Company.Name = dr["Name"].ToString();
                    lcl_obj_Company.Address = dr["ADDRESS"].ToString();
                    lcl_obj_Company.PhoneNo = dr["PHONE_NO"].ToString();
                    lcl_obj_Company.FaxNo = dr["FAX_NO"].ToString();
                    lcl_obj_Company.Email = dr["EMAIL"].ToString();
                    lcl_obj_Company.WebSite = dr["WEB_SITE"].ToString();
                    lcl_obj_Company.CompanyShortName = dr["COMPANY_SHORT_NAME"].ToString();
                    lcl_obj_Company.IsDeleted = Convert.ToInt16(dr["IS_DELETED"]);
                    lcl_obj_Company.Status = Convert.ToInt16(dr["STATUS"]);
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

                        Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                        if (!(dr.HasRows))
                        {
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CompanyManager.GetList(SqlQuery)) : No Company Data Found In The Database!!!");
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_CompanyTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company>();
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
                            lcl_obj_Company.CompanyShortName = dr["COMPANY_SHORT_NAME"].ToString();
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

        public List<SilkERP360.CCL.ModelClass.Employee> GetAllEmployeeList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee> lcl_objLst_Employee = null;
            lcl_objLst_Employee  = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (CompanyManager.GetAllEmployeeList(SqlQuery)) : No Company Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee> lcl_objLst_EmployeeTmp = new System.Collections.Generic.List<SilkERP360.CCL.ModelClass.Employee>();

                    while (dr.Read())
                    {
                        SilkERP360.CCL.ModelClass.Employee lcl_obj_Employee = new SilkERP360.CCL.ModelClass.Employee();
                        lcl_obj_Employee.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_Employee.EmployeeId = dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_Employee.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_Employee.DesignationName = dr["DEGN_NAME"].ToString();
                        lcl_obj_Employee.DepartmentName = dr["DEPT_NAME"].ToString();
                        lcl_objLst_EmployeeTmp.Add(lcl_obj_Employee);
                    }
                    dr.Close();
                    return lcl_objLst_EmployeeTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_Employee;
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
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CompanyReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

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
                lcl_obj_CompanyTmp.IsDeleted = Convert.ToInt16(lcl_obj_CompanyReader["IS_DELETED"].ToString());
                lcl_obj_CompanyTmp.Status = Convert.ToInt16(lcl_obj_CompanyReader["STATUS"].ToString());

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
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
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
                    lcl_obj_CompanyTmp.IsDeleted = Convert.ToInt16(dr["IS_DELETED"].ToString());
                    lcl_obj_CompanyTmp.Status = Convert.ToInt16(dr["STATUS"].ToString());

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
