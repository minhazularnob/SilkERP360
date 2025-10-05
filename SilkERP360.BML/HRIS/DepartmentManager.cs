using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    /// <summary>
    /// This class manages the Department and DepartmentCore objects
    /// </summary>
    public class DepartmentManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Department>
    {
        public DepartmentManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        /// <summary>
        /// Pre-Condition : DBManager Must be initialized and Open
        /// </summary>
        /// <param name="IP_ui64_DepartmentCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>
        /// if function successful but data not found, returns String message in data
        /// 
        /// </returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore GetDepartmentCore(System.UInt64 IP_ui64_DepartmentCode, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_DepartmentCore = null;            
            lcl_obj_DepartmentCore = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.String lcl_str_SqlQuery = System.String.Format("Select DEPT_NAME From DEPARTMENT Where DEPARTMENT_CODE = {0} AND STATUS = {1} AND IS_DELETED = 1", IP_ui64_DepartmentCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_DepartmentReader.HasRows == false)
                {
                    System.String lcl_str_ErrorMessage = System.String.Format("Fatal Error : Department (Code : {0}) Not Found!!!", IP_ui64_DepartmentCode);
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_str_ErrorMessage);
                }
                else
                {
                    lcl_obj_DepartmentReader.Read();
                    lcl_obj_DepartmentCore = new SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore(IP_ui64_DepartmentCode, lcl_obj_DepartmentReader["DEPT_NAME"].ToString());
                    return lcl_obj_DepartmentCore;
                }

            }, "BMLExceptionPolicy");
            return lcl_obj_DepartmentCore;
        }

        /// <summary>
        /// Gets a list of DepartmentCore objects by CompanyCode
        /// </summary>
        /// <param name="IP_ui64_DepartmentCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> GetDepartmentCoresByCompany(System.UInt64 IP_ui64_CompanyCode,System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCoreList = null;            
            lcl_obj_DepartmentCoreList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCoreListTmp = null;
                System.String lcl_str_SqlQuery = System.String.Format("SELECT DEPT.DEPARTMENT_CODE,DEPT.DEPT_NAME " +
                                                                      "FROM DEPARTMENT DEPT JOIN COMPANY COMP " +
                                                                      "ON DEPT.COMPANY_CODE = COMP.COMPANY_CODE " +
                                                                      "WHERE COMP.COMPANY_CODE = {0} AND " +
                                                                      "COMP.STATUS = 1;", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);

                System.Data.OracleClient.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_DepartmentReader.HasRows == false)
                {
                    System.String lcl_str_ErrorMessage = System.String.Format("Fatal Error : No Departments For Company (Code : {0}) was Not Found!!!", IP_ui64_CompanyCode);
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_str_ErrorMessage);
                }
                else
                {
                    lcl_obj_DepartmentCoreListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>();
                    while (lcl_obj_DepartmentReader.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_DepartmentCode = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(
                                                                                                System.UInt64.Parse(lcl_obj_DepartmentReader["DEPARTMENT_CODE"].ToString()), lcl_obj_DepartmentReader["DEPT_NAME"].ToString());
                        lcl_obj_DepartmentCoreListTmp.Add(lcl_obj_DepartmentCode);
                    }
                    lcl_obj_DepartmentReader.Close();
                    //return lcl_obj_DepartmentCoreListTmp;
                }
                return lcl_obj_DepartmentCoreListTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_DepartmentCoreList;
        }

        /// <summary>
        /// Gets a list of DepartmentCore objects by CompanyCode
        /// Gets its own DBManager from DBManager Pool
        /// </summary>
        /// <param name="IP_ui64_DepartmentCode"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> GetDepartmentCoresByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCoreList = null;
            lcl_obj_DepartmentCoreList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> lcl_obj_DepartmentCoreListTmp = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT DEPT.DEPARTMENT_CODE,DEPT.DEPT_NAME 
                                                                          FROM DEPARTMENT DEPT JOIN COMPANY COMP 
                                                                          ON DEPT.COMPANY_CODE = COMP.COMPANY_CODE 
                                                                          WHERE COMP.COMPANY_CODE = {0} AND 
                                                                          COMP.STATUS = 1 ORDER BY DEPT.RANK ASC", IP_ui64_CompanyCode);
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_DepartmentReader.HasRows == false)
                    {
                        System.String lcl_str_ErrorMessage = System.String.Format("Fatal Error : No Departments For Company (Code : {0}) was Not Found!!!", IP_ui64_CompanyCode);
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_str_ErrorMessage);
                    }
                    else
                    {
                        lcl_obj_DepartmentCoreListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>();
                        while (lcl_obj_DepartmentReader.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore lcl_obj_DepartmentCode = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(
                                                                                                    System.UInt64.Parse(lcl_obj_DepartmentReader["DEPARTMENT_CODE"].ToString()), lcl_obj_DepartmentReader["DEPT_NAME"].ToString());
                            lcl_obj_DepartmentCoreListTmp.Add(lcl_obj_DepartmentCode);
                        }
                        lcl_obj_DepartmentReader.Close();
                    }
                }
                return lcl_obj_DepartmentCoreListTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_DepartmentCoreList;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Department, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_DepartmentCode = 0;
            lcl_ui64_DepartmentCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("v_DEPARTMENT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Output;
                // lcl_obj_DepartmentCode.Value = lcl_obj_Department.DepartmentCode;
                System.Data.OracleClient.OracleParameter lcl_obj_DeptName = new System.Data.OracleClient.OracleParameter("v_DEPT_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_DeptName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DeptName.Value = lcl_obj_Department.DeptName;
                System.Data.OracleClient.OracleParameter lcl_obj_ShortName = new System.Data.OracleClient.OracleParameter("v_SHORT_NAME", System.Data.OracleClient.OracleType.NVarChar, 10);
                lcl_obj_ShortName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShortName.Value = lcl_obj_Department.ShortName;
                System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("v_COMPANY_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Department.CompanyCode;
                System.Data.OracleClient.OracleParameter lcl_obj_HeadEmployeeId = new System.Data.OracleClient.OracleParameter("v_HEAD_EMPLOYEE_ID", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_HeadEmployeeId.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_HeadEmployeeId.Value = lcl_obj_Department.HeadEmployeeId;
                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = lcl_obj_Department.IsDeleted;
                System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_Department.Status;
                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_DepartmentCode, lcl_obj_DeptName, lcl_obj_ShortName, lcl_obj_CompanyCode, lcl_obj_HeadEmployeeId, lcl_obj_IsDeleted, lcl_obj_Status, };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.Department_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_DepartmentCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_DepartmentCode;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Department)
        {
            System.UInt64 lcl_ui64_DepartmentCode = 0;
            lcl_ui64_DepartmentCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("v_DEPARTMENT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Output;
                   // lcl_obj_DepartmentCode.Value = lcl_obj_Department.DepartmentCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_DeptName = new System.Data.OracleClient.OracleParameter("v_DEPT_NAME", System.Data.OracleClient.OracleType.NVarChar,100);
                    lcl_obj_DeptName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DeptName.Value = lcl_obj_Department.DeptName;
                    System.Data.OracleClient.OracleParameter lcl_obj_ShortName = new System.Data.OracleClient.OracleParameter("v_SHORT_NAME", System.Data.OracleClient.OracleType.NVarChar,10);
                    lcl_obj_ShortName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ShortName.Value = lcl_obj_Department.ShortName;
                    System.Data.OracleClient.OracleParameter lcl_obj_CompanyCode = new System.Data.OracleClient.OracleParameter("v_COMPANY_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CompanyCode.Value = lcl_obj_Department.CompanyCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_HeadEmployeeId = new System.Data.OracleClient.OracleParameter("v_HEAD_EMPLOYEE_ID", System.Data.OracleClient.OracleType.NVarChar,32);
                    lcl_obj_HeadEmployeeId.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_HeadEmployeeId.Value = lcl_obj_Department.HeadEmployeeId;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = 1;
                    System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = 1;
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_DepartmentCode, lcl_obj_DeptName, lcl_obj_ShortName, lcl_obj_CompanyCode, lcl_obj_HeadEmployeeId, lcl_obj_IsDeleted, lcl_obj_Status };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_DEPARTMENT_IU", lcl_obj_SP_Parameters);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    return System.UInt64.Parse(lcl_obj_DepartmentCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_DepartmentCode;
        }
        public CCL.BusinessEntities.HRIS.Department Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Department lcl_obj_Department = null;
            lcl_obj_Department = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Department>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From DEPARTMENT DEPARTMENT_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorDepartment.Get(ID,DBManger)) : Error Retrieving Department Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Department();
                lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                lcl_obj_Tmp.DeptName = lcl_obj_dr["DEPT_NAME"].ToString();
                lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_Tmp.HeadEmployeeId = lcl_obj_dr["HEAD_EMPLOYEE_CODE"].ToString();
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Department;
        }

        public CCL.BusinessEntities.HRIS.Department Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Department lcl_obj_Department = null;
            lcl_obj_Department = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Department>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From DEPARTMENT DEPARTMENT_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Department.Get(ID)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Department();
                    lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                    lcl_obj_Tmp.DeptName = lcl_obj_dr["DEPT_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.HeadEmployeeId = lcl_obj_dr["HEAD_EMPLOYEE_CODE"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Department;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> lcl_objlist_Department = null;
            lcl_objlist_Department = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Department.GetList(SqlQuery)) : No Department Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Department();
                        lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                        lcl_obj_Tmp.DeptName = lcl_obj_dr["DEPT_NAME"].ToString();
                        lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                        lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                        lcl_obj_Tmp.HeadEmployeeId = lcl_obj_dr["HEAD_EMPLOYEE_ID"].ToString();
                       // lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                       // lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_Department;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> lcl_objlist_Department = null;
            lcl_objlist_Department = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Department.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Department>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Department();
                    lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                    lcl_obj_Tmp.DeptName = lcl_obj_dr["DEPT_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.HeadEmployeeId = lcl_obj_dr["HEAD_EMPLOYEE_CODE"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_Department;
        }


        public CCL.BusinessEntities.HRIS.Department Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Department lcl_obj_Department = null;
            lcl_obj_Department = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Department>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorDepartment.Get(SqlQuery,DBManger)) : Error Retrieving Department Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Department();
                lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                lcl_obj_Tmp.DeptName = lcl_obj_dr["DEPT_NAME"].ToString();
                lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                lcl_obj_Tmp.HeadEmployeeId = lcl_obj_dr["HEAD_EMPLOYEE_CODE"].ToString();
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Department;
        }

        public CCL.BusinessEntities.HRIS.Department Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.Department lcl_obj_Department = null;
            lcl_obj_Department = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Department>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Department.Get(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Department lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Department();
                    lcl_obj_Tmp.DepartmentCode = System.UInt64.Parse(lcl_obj_dr["DEPARTMENT_CODE"].ToString());
                    lcl_obj_Tmp.DeptName = lcl_obj_dr["DEPT_NAME"].ToString();
                    lcl_obj_Tmp.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_Tmp.CompanyCode = System.UInt64.Parse(lcl_obj_dr["COMPANY_CODE"].ToString());
                    lcl_obj_Tmp.HeadEmployeeId = lcl_obj_dr["HEAD_EMPLOYEE_CODE"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Department;
        }

       
    }
}
