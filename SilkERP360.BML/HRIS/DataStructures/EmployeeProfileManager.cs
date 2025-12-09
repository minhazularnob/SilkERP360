using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class EmployeeProfileManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeProfileManager()
        {
            this.Initialize();
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <param name="lcl_obj_DBManager"></param>
        /// <returns></returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;
            lcl_obj_EmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT E.EMPLOYEE_CODE, EMPLOYEE_ID,EMPLOYEE_NAME,DEGN_NAME,DEPT_NAME,  NAME,JOINING_DATE,EMPLOYEE_IMAGE_CODE,IMAGE,IMAGE_TYPE, IMAGE_SIZE,e.department_code,E.COMPANY_CODE,e.designation_code

                                                    FROM EMPLOYEE E Left outer join COMPANY C on E.COMPANY_CODE=C.COMPANY_CODE Left outer join DEPARTMENT dp
                                                    On e.department_code=dp.department_code left outer join DESIGNATION D
                                                    on e.designation_code=d.designation_code left outer join EMPLOYEE_IMAGE I
                                                    on E.employee_code=i.employee_code where e.EMPLOYEE_CODE={0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_EmployeeReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error CompanyManager.Get(Company_Code,DBManger)) : Error Retrieving Company Data!");
                }
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfileTmp = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile(IP_ui64_Code);
                lcl_obj_EmployeeReader.Read();

                lcl_obj_EmployeeProfileTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_CODE"].ToString());
                lcl_obj_EmployeeProfileTmp.EmployeeName = lcl_obj_EmployeeReader["EMPLOYEE_NAME"].ToString();
                lcl_obj_EmployeeProfileTmp.EmployeeID = lcl_obj_EmployeeReader["EMPLOYEE_ID"].ToString();
                lcl_obj_EmployeeProfileTmp.JoiningDate = System.DateTime.Parse(lcl_obj_EmployeeReader["JOINING_DATE"].ToString());
                lcl_obj_EmployeeProfileTmp.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(lcl_obj_EmployeeReader["COMPANY_CODE"].ToString()), lcl_obj_EmployeeReader["NAME"].ToString());
                lcl_obj_EmployeeProfileTmp.Designation= new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(lcl_obj_EmployeeReader["designation_code"].ToString()), lcl_obj_EmployeeReader["DEGN_NAME"].ToString());
                lcl_obj_EmployeeProfileTmp.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(lcl_obj_EmployeeReader["department_code"].ToString()), lcl_obj_EmployeeReader["DEPT_NAME"].ToString());
                lcl_obj_EmployeeProfileTmp.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_IMAGE_CODE"].ToString()), lcl_obj_EmployeeReader["IMAGE_TYPE"].ToString(), System.Int32.Parse(lcl_obj_EmployeeReader["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(lcl_obj_EmployeeReader["IMAGE"])));
               
                lcl_obj_EmployeeReader.Close();
                return lcl_obj_EmployeeProfileTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeProfile;
        }
/// <summary>
/// /////
/// </summary>
/// <param name="IP_ui64_Code"></param>
/// <returns></returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfile = null;
            lcl_obj_EmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT E.EMPLOYEE_CODE, EMPLOYEE_ID,EMPLOYEE_NAME,DEGN_NAME,DEPT_NAME,  NAME,JOINING_DATE,EMPLOYEE_IMAGE_CODE,IMAGE,IMAGE_TYPE, IMAGE_SIZE,e.department_code,E.COMPANY_CODE,e.designation_code

                                                    FROM EMPLOYEE E Left outer join COMPANY C on E.COMPANY_CODE=C.COMPANY_CODE Left outer join DEPARTMENT dp
                                                    On e.department_code=dp.department_code left outer join DESIGNATION D
                                                    on e.designation_code=d.designation_code left outer join EMPLOYEE_IMAGE I
                                                    on E.COMPANY_CODE=i.employee_code where e.EMPLOYEE_CODE={0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);

                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (lcl_obj_EmployeeReader.HasRows == false)
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error CompanyManager.Get(Company_Code,DBManger)) : Error Retrieving Company Data!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmployeeProfileTmp = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile(IP_ui64_Code);
                    lcl_obj_EmployeeReader.Read();

                    lcl_obj_EmployeeProfileTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmployeeProfileTmp.EmployeeName = lcl_obj_EmployeeReader["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EmployeeProfileTmp.EmployeeID = lcl_obj_EmployeeReader["EMPLOYEE_ID"].ToString();
                    lcl_obj_EmployeeProfileTmp.JoiningDate = System.DateTime.Parse(lcl_obj_EmployeeReader["JOINING_DATE"].ToString());
                    lcl_obj_EmployeeProfileTmp.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(lcl_obj_EmployeeReader["COMPANY_CODE"].ToString()), lcl_obj_EmployeeReader["NAME"].ToString());
                    lcl_obj_EmployeeProfileTmp.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(lcl_obj_EmployeeReader["designation_code"].ToString()), lcl_obj_EmployeeReader["DEGN_NAME"].ToString());
                    lcl_obj_EmployeeProfileTmp.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(lcl_obj_EmployeeReader["department_code"].ToString()), lcl_obj_EmployeeReader["DEPT_NAME"].ToString());
                    lcl_obj_EmployeeProfileTmp.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_IMAGE_CODE"].ToString()), lcl_obj_EmployeeReader["IMAGE_TYPE"].ToString(), System.Int32.Parse(lcl_obj_EmployeeReader["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(lcl_obj_EmployeeReader["IMAGE"])));

                    lcl_obj_EmployeeReader.Close();
                    return lcl_obj_EmployeeProfileTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeProfile;
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
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
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                }
                 
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile();
                    lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                    lcl_obj_EpmProfile.BankAccountNo = dr["BANK_ACCOUNT_NO"].ToString();
                    lcl_obj_EpmProfile.Tin = dr["TIN"].ToString();
                    lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_ON_ROSTER"].ToString());
                    lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_PF_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["NIGHT_BILL_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                    lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                    lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                    lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                    lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                }
                dr.Close();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmpProfile in lcl_objLst_EpmProfileTemp)
                {
                    //Get Employee Salary Structure
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From Employee_Salary_Structure Where Employee_Code = {0}", lcl_obj_EmpProfile.EmployeeCode);
                    SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_SalaryStructureManager = new EmployeeSalaryStructureManger();
                    lcl_obj_EmpProfile.SalaryStructure = lcl_obj_SalaryStructureManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);
                }
                return lcl_objLst_EpmProfileTemp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }

        

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetEmployeeProfilesByCompany(System.UInt64 IP_ui64_CompanyCode, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                //if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                //{
                //    lcl_obj_DBManager.Open();
                //}
                

                System.Data.DataSet lcl_ds_EmployeeProfile = new System.Data.DataSet("EmployeeProfile");
                //System.Data.DataTable lcl_dt_Employee = lcl_obj_DBManager.Connection.GetSchema("EMPLOYEE");
                //System.Data.DataTable lcl_dt_EmployeeDepartment = lcl_obj_DBManager.Connection.GetSchema("DEPARTMENT");
                //System.Data.DataTable lcl_dt_EmployeeDesignation = lcl_obj_DBManager.Connection.GetSchema("DESIGNATION");
                //System.Data.DataTable lcl_dt_EmployeeCompany = lcl_obj_DBManager.Connection.GetSchema("COMPANY");
                //System.Data.DataTable lcl_dt_EmployeeSalaryStructure = lcl_obj_DBManager.Connection.GetSchema("EMPLOYEE_SALARY_STRUCTURE");
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                try
                {
                    System.String lcl_str_Query = System.String.Format("SELECT * FROM EMPLOYEE EMP JOIN DESIGNATION DESIG ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE JOIN DEPARTMENT DEPT ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE WHERE EMP.COMPANY_CODE = {0} AND (EMPLOYEE_STATUS = {1} OR EMPLOYEE_STATUS = {2} OR EMPLOYEE_STATUS = {3}) AND IS_DELETED = 1 ORDER BY DEPT.RANK,DESIG.RANK ASC", IP_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                    OracleCommand lcl_obj_EmployeeCommand = new OracleCommand(lcl_str_Query, lcl_obj_DBManager.Connection);
                    lcl_obj_EmployeeCommand.Transaction = lcl_obj_DBManager.Transaction;

                    OracleDataAdapter lcl_obj_EmployeeAdapter = new OracleDataAdapter(lcl_obj_EmployeeCommand);
                    lcl_obj_EmployeeAdapter.FillSchema(lcl_ds_EmployeeProfile, System.Data.SchemaType.Source, "EMPLOYEE");
                    lcl_obj_EmployeeAdapter.Fill(lcl_ds_EmployeeProfile, "EMPLOYEE");

                    lcl_str_Query = System.String.Format("SELECT * FROM COMPANY WHERE COMPANY_CODE = {0}", IP_ui64_CompanyCode);
                    OracleCommand lcl_obj_CompanyCommand = new OracleCommand(lcl_str_Query, lcl_obj_DBManager.Connection);
                    lcl_obj_CompanyCommand.Transaction = lcl_obj_DBManager.Transaction;

                    OracleDataAdapter lcl_obj_CompanyAdapter = new OracleDataAdapter(lcl_obj_CompanyCommand);
                    lcl_obj_CompanyAdapter.FillSchema(lcl_ds_EmployeeProfile, System.Data.SchemaType.Source, "COMPANY");
                    lcl_obj_CompanyAdapter.Fill(lcl_ds_EmployeeProfile, "COMPANY");

                    lcl_str_Query = System.String.Format("SELECT DISTINCT(DESIG.DESIGNATION_CODE),DESIG.DEGN_NAME FROM DESIGNATION DESIG JOIN EMPLOYEE EMP ON DESIG.DESIGNATION_CODE = EMP.DESIGNATION_CODE WHERE EMP.COMPANY_CODE = {0}", IP_ui64_CompanyCode);
                    OracleCommand lcl_obj_DesignationCommand = new OracleCommand(lcl_str_Query, lcl_obj_DBManager.Connection);
                    lcl_obj_DesignationCommand.Transaction = lcl_obj_DBManager.Transaction;

                    OracleDataAdapter lcl_obj_DesignationAdapter = new OracleDataAdapter(lcl_obj_DesignationCommand);
                    lcl_obj_DesignationAdapter.FillSchema(lcl_ds_EmployeeProfile, System.Data.SchemaType.Source, "DESIGNATION");
                    lcl_obj_DesignationAdapter.Fill(lcl_ds_EmployeeProfile, "DESIGNATION");

                    lcl_str_Query = System.String.Format("SELECT DISTINCT(DEPT.DEPARTMENT_CODE),DEPT.DEPT_NAME FROM DEPARTMENT DEPT JOIN EMPLOYEE EMP ON DEPT.DEPARTMENT_CODE = EMP.DEPARTMENT_CODE WHERE EMP.COMPANY_CODE = {0}", IP_ui64_CompanyCode);
                    OracleCommand lcl_obj_DepartmentCommand = new OracleCommand(lcl_str_Query, lcl_obj_DBManager.Connection);
                    lcl_obj_DepartmentCommand.Transaction = lcl_obj_DBManager.Transaction;

                    OracleDataAdapter lcl_obj_DepartmentAdapter = new OracleDataAdapter(lcl_obj_DepartmentCommand);
                    lcl_obj_DepartmentAdapter.FillSchema(lcl_ds_EmployeeProfile, System.Data.SchemaType.Source, "DEPARTMENT");
                    lcl_obj_DepartmentAdapter.Fill(lcl_ds_EmployeeProfile, "DEPARTMENT");

                    lcl_str_Query = System.String.Format("SELECT EMP_SAL_ST.* FROM EMPLOYEE_SALARY_STRUCTURE EMP_SAL_ST JOIN EMPLOYEE EMP ON EMP_SAL_ST.EMPLOYEE_CODE = EMP.EMPLOYEE_CODE WHERE EMP.COMPANY_CODE = {0}", IP_ui64_CompanyCode);
                    OracleCommand lcl_obj_SalaryStructureCommand = new OracleCommand(lcl_str_Query, lcl_obj_DBManager.Connection);
                    lcl_obj_SalaryStructureCommand.Transaction = lcl_obj_DBManager.Transaction;

                    OracleDataAdapter lcl_obj_SalaryAdapter = new OracleDataAdapter(lcl_obj_SalaryStructureCommand);
                    lcl_obj_SalaryAdapter.FillSchema(lcl_ds_EmployeeProfile, System.Data.SchemaType.Source, "EMPLOYEE_SALARY_STRUCTURE");
                    lcl_obj_SalaryAdapter.Fill(lcl_ds_EmployeeProfile, "EMPLOYEE_SALARY_STRUCTURE");

                    

                    foreach (System.Data.DataRow lcl_obj_EmployeeDataRow in lcl_ds_EmployeeProfile.Tables["EMPLOYEE"].Rows)
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile();
                        lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeDataRow["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EpmProfile.EmployeeName = lcl_obj_EmployeeDataRow["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EpmProfile.EmployeeID = lcl_obj_EmployeeDataRow["EMPLOYEE_ID"].ToString();
                        lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(lcl_obj_EmployeeDataRow["JOINING_DATE"].ToString());
                        lcl_obj_EpmProfile.BankAccountNo = lcl_obj_EmployeeDataRow["BANK_ACCOUNT_NO"].ToString();
                        lcl_obj_EpmProfile.Tin = lcl_obj_EmployeeDataRow["TIN"].ToString();
                        lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(lcl_obj_EmployeeDataRow["IS_ON_ROSTER"].ToString());
                        lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(lcl_obj_EmployeeDataRow["IS_PF_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(lcl_obj_EmployeeDataRow["IS_OT_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(lcl_obj_EmployeeDataRow["NIGHT_BILL_ELIGIBLE"].ToString());

                        //Get Department
                        System.Data.DataRow lcl_obj_DepartmentRow = lcl_ds_EmployeeProfile.Tables["DEPARTMENT"].Select("DEPARTMENT_CODE = " + lcl_obj_EmployeeDataRow["DEPARTMENT_CODE"].ToString())[0];
                        lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(lcl_obj_DepartmentRow["department_code"].ToString()), lcl_obj_DepartmentRow["DEPT_NAME"].ToString());

                        //Get Designation
                        System.Data.DataRow lcl_obj_DesignationRow = lcl_ds_EmployeeProfile.Tables["DESIGNATION"].Select("DESIGNATION_CODE = " + lcl_obj_EmployeeDataRow["DESIGNATION_CODE"].ToString())[0];
                        lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(lcl_obj_DesignationRow["DESIGNATION_CODE"].ToString()), lcl_obj_DesignationRow["DEGN_NAME"].ToString());

                        //Get Company
                        System.Data.DataRow lcl_obj_CompanyRow = lcl_ds_EmployeeProfile.Tables["COMPANY"].Select("COMPANY_CODE = " + lcl_obj_EmployeeDataRow["COMPANY_CODE"].ToString())[0];
                        lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(lcl_obj_CompanyRow["COMPANY_CODE"].ToString()), lcl_obj_CompanyRow["NAME"].ToString());

                        //Get SALARY STRUCTURE
                        System.Data.DataRow lcl_obj_SalaryStructureRow = lcl_ds_EmployeeProfile.Tables["EMPLOYEE_SALARY_STRUCTURE"].Select("EMPLOYEE_CODE = " + lcl_obj_EpmProfile.EmployeeCode)[0];
                        lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(lcl_obj_CompanyRow["COMPANY_CODE"].ToString()), lcl_obj_CompanyRow["NAME"].ToString());

                        lcl_obj_EpmProfile.SalaryStructure = new CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                        lcl_obj_EpmProfile.SalaryStructure.Basic = System.Decimal.Parse(lcl_obj_SalaryStructureRow["BASIC"].ToString());
                        lcl_obj_EpmProfile.SalaryStructure.Conveyence = System.Decimal.Parse(lcl_obj_SalaryStructureRow["CONVEYENCE"].ToString());
                        lcl_obj_EpmProfile.SalaryStructure.Entertainment = System.Decimal.Parse(lcl_obj_SalaryStructureRow["ENTERTAINMENT"].ToString());
                        lcl_obj_EpmProfile.SalaryStructure.EmployeeCode = lcl_obj_EpmProfile.EmployeeCode;
                        lcl_obj_EpmProfile.SalaryStructure.HouseRent = System.Decimal.Parse(lcl_obj_SalaryStructureRow["HOUSE_RENT"].ToString());
                        lcl_obj_EpmProfile.SalaryStructure.Medical = System.Decimal.Parse(lcl_obj_SalaryStructureRow["MEDICAL"].ToString());
                        lcl_obj_EpmProfile.SalaryStructure.HouseRent = System.Decimal.Parse(lcl_obj_SalaryStructureRow["HOUSE_RENT"].ToString());
                        lcl_obj_EpmProfile.SalaryStructure.Others = System.Decimal.Parse(lcl_obj_SalaryStructureRow["OTHERS"].ToString());
                        lcl_obj_EpmProfile.SalaryStructure.Gross = System.Decimal.Parse(lcl_obj_SalaryStructureRow["GROSS"].ToString());

                        lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);

                    }
                }
                catch (System.Exception x)
                {
                    throw x;
                }
                
                

                return lcl_objLst_EpmProfileTemp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetEmployeeProfiles(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
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

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile();
                    lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                    lcl_obj_EpmProfile.BankAccountNo = dr["BANK_ACCOUNT_NO"].ToString();
                    lcl_obj_EpmProfile.Tin = dr["TIN"].ToString();
                    lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_ON_ROSTER"].ToString());
                    lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_PF_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["NIGHT_BILL_ELIGIBLE"].ToString());

                    lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                    lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                    lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                    
                    lcl_obj_EpmProfile.SalaryStructure = new CCL.BusinessEntities.HRIS.EmployeeSalaryStructure();
                    lcl_obj_EpmProfile.SalaryStructure.Basic = System.Decimal.Parse(dr["BASIC"].ToString());
                    lcl_obj_EpmProfile.SalaryStructure.Conveyence = System.Decimal.Parse(dr["CONVEYENCE"].ToString());
                    lcl_obj_EpmProfile.SalaryStructure.Entertainment = System.Decimal.Parse(dr["ENTERTAINMENT"].ToString());
                    lcl_obj_EpmProfile.SalaryStructure.EmployeeCode = lcl_obj_EpmProfile.EmployeeCode;
                    lcl_obj_EpmProfile.SalaryStructure.HouseRent = System.Decimal.Parse(dr["HOUSE_RENT"].ToString());
                    lcl_obj_EpmProfile.SalaryStructure.Medical = System.Decimal.Parse(dr["MEDICAL"].ToString());
                    lcl_obj_EpmProfile.SalaryStructure.HouseRent = System.Decimal.Parse(dr["HOUSE_RENT"].ToString());
                    lcl_obj_EpmProfile.SalaryStructure.Others = System.Decimal.Parse(dr["OTHERS"].ToString());
                    lcl_obj_EpmProfile.SalaryStructure.Gross = System.Decimal.Parse(dr["GROSS"].ToString());

                    //lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                    lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                }
                dr.Close();

                //foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmpProfile in lcl_objLst_EpmProfileTemp)
                //{
                //    //Get Employee Salary Structure
                //    System.String lcl_str_SqlQuery = System.String.Format("Select * From Employee_Salary_Structure Where Employee_Code = {0}", lcl_obj_EmpProfile.EmployeeCode);
                //    SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_SalaryStructureManager = new EmployeeSalaryStructureManger();

                //    lcl_obj_EmpProfile.SalaryStructure = lcl_obj_SalaryStructureManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);
                //}


                return lcl_objLst_EpmProfileTemp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }

        /// <summary>
        /// ////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetListWithoutImage(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
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

                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile();
                    lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                    lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                    lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                    lcl_obj_EpmProfile.BankAccountNo = dr["BANK_ACCOUNT_NO"].ToString();
                    lcl_obj_EpmProfile.Tin = dr["TIN"].ToString();
                    lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_ON_ROSTER"].ToString());
                    lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_PF_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.IsUniformEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_UNIFORM_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_OT_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["NIGHT_BILL_ELIGIBLE"].ToString());
                    lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                    lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                    lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                    //lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                    lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                }
                dr.Close();

                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EmpProfile in lcl_objLst_EpmProfileTemp)
                {
                    //Get Employee Salary Structure
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From Employee_Salary_Structure Where Employee_Code = {0}", lcl_obj_EmpProfile.EmployeeCode);
                    SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_SalaryStructureManager = new EmployeeSalaryStructureManger();

                    lcl_obj_EmpProfile.SalaryStructure = lcl_obj_SalaryStructureManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);
                }


                return lcl_objLst_EpmProfileTemp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile GetWithoutImage(System.UInt64 IP_ui64_EmployeeCode, System.Object IP_obj_DBManager)
        {
            System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,0 IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE EMP.EMPLOYEE_CODE = {0}", IP_ui64_EmployeeCode);
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmployeeProfile = null;
            lcl_obj_EpmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                }

                dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile();
                lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                lcl_obj_EpmProfile.BankAccountNo = dr["BANK_ACCOUNT_NO"].ToString();
                lcl_obj_EpmProfile.Tin = dr["TIN"].ToString();
                lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_ON_ROSTER"].ToString());
                lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_PF_ELIGIBLE"].ToString());
                lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_OT_ELIGIBLE"].ToString());
                lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["NIGHT_BILL_ELIGIBLE"].ToString());
                lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                    //lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                    //lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                
                dr.Close();

                
                    //Get Employee Salary Structure
                lcl_str_SqlQuery = System.String.Format("Select * From Employee_Salary_Structure Where Employee_Code = {0}", lcl_obj_EpmProfile.EmployeeCode);
                SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_SalaryStructureManager = new EmployeeSalaryStructureManger();
                lcl_obj_EpmProfile.SalaryStructure = lcl_obj_SalaryStructureManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);



                return lcl_obj_EpmProfile;

            }, "BMLExceptionPolicy");
            return lcl_obj_EpmployeeProfile;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile GetWithoutImage(System.String IP_str_EmployeeID, System.Object IP_obj_DBManager)
        {
            System.String lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.EMPLOYEE_ID,EMP.EMPLOYEE_CODE,EMP.BANK_ACCOUNT_NO,EMP.TIN,EMP.EMPLOYEE_NAME,EMP.JOINING_DATE,EMP.IS_ON_ROSTER,EMP.IS_OT_ELIGIBLE,EMP.IS_PF_ELIGIBLE,EMP.NIGHT_BILL_ELIGIBLE,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS,IMG.EMPLOYEE_IMAGE_CODE,IMG.IMAGE,IMG.IMAGE_TYPE,IMG.IMAGE_SIZE,0 IS_DELETED
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        JOIN EMPLOYEE_IMAGE IMG
                                                                        ON EMP.EMPLOYEE_CODE = IMG.EMPLOYEE_CODE
                                                                        WHERE EMP.EMPLOYEE_ID = '{0}'", IP_str_EmployeeID);
            SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmployeeProfile = null;
            lcl_obj_EpmployeeProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                }

                dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile();
                lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                lcl_obj_EpmProfile.BankAccountNo = dr["BANK_ACCOUNT_NO"].ToString();
                lcl_obj_EpmProfile.Tin = dr["TIN"].ToString();
                lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_ON_ROSTER"].ToString());
                lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_PF_ELIGIBLE"].ToString());
                lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_OT_ELIGIBLE"].ToString());
                lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["NIGHT_BILL_ELIGIBLE"].ToString());
                lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                //lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                //lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);

                dr.Close();


                //Get Employee Salary Structure
                lcl_str_SqlQuery = System.String.Format("Select * From Employee_Salary_Structure Where Employee_Code = {0}", lcl_obj_EpmProfile.EmployeeCode);
                SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_SalaryStructureManager = new EmployeeSalaryStructureManger();
                lcl_obj_EpmProfile.SalaryStructure = lcl_obj_SalaryStructureManager.Get(lcl_str_SqlQuery, IP_obj_DBManager);



                return lcl_obj_EpmProfile;

            }, "BMLExceptionPolicy");
            return lcl_obj_EpmployeeProfile;
        }

/// <summary>
/// //////
/// </summary>
/// <param name="IP_str_SqlQuery"></param>
/// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = null;
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                    while (dr.Read())
                    {
                        lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile(System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString()));
                        //lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_EpmProfile.Salary = System.Decimal.Parse(dr["GROSS"].ToString());
                        lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                        lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_ON_ROSTER"].ToString());
                        lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_PF_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_OT_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["NIGHT_BILL_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                        lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                        lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                        lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                        lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                    }
                    dr.Close();

                    lcl_obj_DBManager.InternalResource.Close();
                    return lcl_objLst_EpmProfileTemp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }


        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetListWithoutImage(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = null;
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                    while (dr.Read())
                    {
                        lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile(System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString()));
                        //lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_EpmProfile.Salary = System.Decimal.Parse(dr["GROSS"].ToString());
                        lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                        lcl_obj_EpmProfile.IsRooster = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_ON_ROSTER"].ToString());
                        lcl_obj_EpmProfile.IsPFEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_PF_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.IsOTEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["IS_OT_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.NightBillEligible = (SilkERP360.CCL.Enums.YesNo)System.Int32.Parse(dr["NIGHT_BILL_ELIGIBLE"].ToString());
                        lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                        lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                        lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                        lcl_obj_EpmProfile.Image = null;
                        lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                    }
                    dr.Close();

                    lcl_obj_DBManager.InternalResource.Close();
                    return lcl_objLst_EpmProfileTemp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }


        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetListLeave(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = null;
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                    while (dr.Read())
                    {
                        lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile(System.UInt64.Parse(dr["leave_app_code"].ToString()));
                        //lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                        lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                        lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                        lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());
                        lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                        lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                    }
                    dr.Close();
                    return lcl_objLst_EpmProfileTemp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> GetListAddDed(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfile = null;
            lcl_objLst_EpmProfile = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>>(() =>
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

                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeProfileManager.GetList(SqlQuery,DBManager)) : No EmployeeProfileManager Data Found In The Database!!!");
                    }

                    SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile lcl_obj_EpmProfile = null;
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EpmProfileTemp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                    while (dr.Read())
                    {
                        lcl_obj_EpmProfile = new CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile(System.UInt64.Parse(dr["add_ded_code"].ToString()));
                        //lcl_obj_EpmProfile.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_EpmProfile.EmployeeName = dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_EpmProfile.EmployeeID = dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_EpmProfile.Salary = decimal.Parse(dr["AMOUNT"].ToString());
                        lcl_obj_EpmProfile.JoiningDate = System.DateTime.Parse(dr["JOINING_DATE"].ToString());
                        lcl_obj_EpmProfile.Company = new CCL.BusinessEntities.HRIS.Base.CompanyCore(System.UInt64.Parse(dr["COMPANY_CODE"].ToString()), dr["NAME"].ToString());
                        lcl_obj_EpmProfile.Designation = new CCL.BusinessEntities.HRIS.Base.DesignationCore(System.UInt64.Parse(dr["designation_code"].ToString()), dr["DEGN_NAME"].ToString());
                        lcl_obj_EpmProfile.Department = new CCL.BusinessEntities.HRIS.Base.DepartmentCore(System.UInt64.Parse(dr["department_code"].ToString()), dr["DEPT_NAME"].ToString());


                        // lcl_obj_EpmProfile.Image = new CCL.BusinessEntities.HRIS.Base.EmployeeImageCore(System.UInt64.Parse(dr["EMPLOYEE_IMAGE_CODE"].ToString()), dr["IMAGE_TYPE"].ToString(), System.Int32.Parse(dr["IMAGE_SIZE"].ToString()), System.Convert.ToBase64String((System.Byte[])(dr["IMAGE"])));
                        lcl_objLst_EpmProfileTemp.Add(lcl_obj_EpmProfile);
                    }
                    dr.Close();


                    return lcl_objLst_EpmProfileTemp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EpmProfile;
        }


    }
}
