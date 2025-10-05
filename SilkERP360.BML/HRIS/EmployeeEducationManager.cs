using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    class EmployeeEducationManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>
    {

        public EmployeeEducationManager()
        {
            this.Initialize();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui64_DesignationCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmployeeEducation, System.Object IP_obj_DBManager)
        {
             System.UInt64 lcl_ui64_EducationCode = 0;
            
            lcl_ui64_EducationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_EducationCode = new System.Data.OracleClient.OracleParameter("p_EDUCATION_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EducationCode.Direction = System.Data.ParameterDirection.Output;


                System.Data.OracleClient.OracleParameter lcl_obj_ExamName = new System.Data.OracleClient.OracleParameter("p_EXAM_NAME", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_ExamName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ExamName.Value = lcl_obj_EmployeeEducation.ExamName;

                System.Data.OracleClient.OracleParameter lcl_obj_InstName = new System.Data.OracleClient.OracleParameter("p_INST_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_InstName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_InstName.Value = lcl_obj_EmployeeEducation.InstName;

                System.Data.OracleClient.OracleParameter lcl_obj_BoardUniversity = new System.Data.OracleClient.OracleParameter("p_BOARD_UNIVERSITY", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_BoardUniversity.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BoardUniversity.Value = lcl_obj_EmployeeEducation.BoardUniversity;

                System.Data.OracleClient.OracleParameter lcl_obj_MajorSubject = new System.Data.OracleClient.OracleParameter("p_MAJOR_SUBJECT", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_MajorSubject.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MajorSubject.Value = lcl_obj_EmployeeEducation.MajorSubject;

                System.Data.OracleClient.OracleParameter lcl_obj_DivisionClass = new System.Data.OracleClient.OracleParameter("p_DIVISION_CLASS", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_DivisionClass.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DivisionClass.Value = lcl_obj_EmployeeEducation.DivisionClass;

                System.Data.OracleClient.OracleParameter lcl_obj_Cgpa = new System.Data.OracleClient.OracleParameter("p_CGPA", System.Data.OracleClient.OracleType.NVarChar, 8);
                lcl_obj_Cgpa.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Cgpa.Value = lcl_obj_EmployeeEducation.Cgpa;

                System.Data.OracleClient.OracleParameter lcl_obj_PassYear = new System.Data.OracleClient.OracleParameter("p_PASS_YEAR", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PassYear.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PassYear.Value = lcl_obj_EmployeeEducation.PassYear;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeEducation.EmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("p_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("p_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = 1;


                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EducationCode, lcl_obj_ExamName, lcl_obj_InstName, lcl_obj_BoardUniversity, lcl_obj_MajorSubject, lcl_obj_DivisionClass, lcl_obj_Cgpa, lcl_obj_PassYear, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_EDUCATION_IU", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_EducationCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_EducationCode;
        
        }

        public ulong Update(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmployeeEducation, System.Object IP_obj_DBManager)
           {
            System.UInt64 lcl_ui64_EducationCode = 0;

            lcl_ui64_EducationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleParameter lcl_obj_EducationCode = new System.Data.OracleClient.OracleParameter("p_EDUCATION_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EducationCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EducationCode.Value = lcl_obj_EmployeeEducation.EducationCode;

                System.Data.OracleClient.OracleParameter lcl_obj_ExamName = new System.Data.OracleClient.OracleParameter("p_EXAM_NAME", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_ExamName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ExamName.Value = lcl_obj_EmployeeEducation.ExamName;

                System.Data.OracleClient.OracleParameter lcl_obj_InstName = new System.Data.OracleClient.OracleParameter("p_INST_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_InstName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_InstName.Value = lcl_obj_EmployeeEducation.InstName;

                System.Data.OracleClient.OracleParameter lcl_obj_BoardUniversity = new System.Data.OracleClient.OracleParameter("p_BOARD_UNIVERSITY", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_BoardUniversity.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BoardUniversity.Value = lcl_obj_EmployeeEducation.BoardUniversity;

                System.Data.OracleClient.OracleParameter lcl_obj_MajorSubject = new System.Data.OracleClient.OracleParameter("p_MAJOR_SUBJECT", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_MajorSubject.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MajorSubject.Value = lcl_obj_EmployeeEducation.MajorSubject;

                System.Data.OracleClient.OracleParameter lcl_obj_DivisionClass = new System.Data.OracleClient.OracleParameter("p_DIVISION_CLASS", System.Data.OracleClient.OracleType.NVarChar, 50);
                lcl_obj_DivisionClass.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DivisionClass.Value = lcl_obj_EmployeeEducation.DivisionClass;

                System.Data.OracleClient.OracleParameter lcl_obj_Cgpa = new System.Data.OracleClient.OracleParameter("p_CGPA", System.Data.OracleClient.OracleType.NVarChar, 8);
                lcl_obj_Cgpa.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Cgpa.Value = lcl_obj_EmployeeEducation.Cgpa;

                System.Data.OracleClient.OracleParameter lcl_obj_PassYear = new System.Data.OracleClient.OracleParameter("p_PASS_YEAR", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PassYear.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PassYear.Value = lcl_obj_EmployeeEducation.PassYear;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeEducation.EmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("p_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = 1;

                System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("p_STATUS", System.Data.OracleClient.OracleType.Number);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = 1;


                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EducationCode, lcl_obj_ExamName, lcl_obj_InstName, lcl_obj_BoardUniversity, lcl_obj_MajorSubject, lcl_obj_DivisionClass, lcl_obj_Cgpa, lcl_obj_PassYear, lcl_obj_EmployeeCode, lcl_obj_IsDeleted, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_UPDT_EMPLOYEE_EDUCATION", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_EducationCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_EducationCode;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_obj_A"></param>
        /// <returns></returns>
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmployeeEducation)
        {
            System.UInt64 lcl_ui64_EducationCode = 0;

            lcl_ui64_EducationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }


                    System.Data.OracleClient.OracleParameter lcl_obj_EducationCode = new System.Data.OracleClient.OracleParameter("v_EDUCATION_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EducationCode.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_EducationCode.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_ExamName = new System.Data.OracleClient.OracleParameter("v_EXAM_NAME", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ExamName.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_ExamName.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_InstName = new System.Data.OracleClient.OracleParameter("v_INST_NAME", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_InstName.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_InstName.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_BoardUniversity = new System.Data.OracleClient.OracleParameter("v_BOARD_UNIVERSITY", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_BoardUniversity.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_BoardUniversity.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_MajorSubject = new System.Data.OracleClient.OracleParameter("v_MAJOR_SUBJECT", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_MajorSubject.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_MajorSubject.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_DivisionClass = new System.Data.OracleClient.OracleParameter("v_DIVISION_CLASS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_DivisionClass.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_DivisionClass.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_Cgpa = new System.Data.OracleClient.OracleParameter("v_Cgpa", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Cgpa.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_Cgpa.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_PassYear = new System.Data.OracleClient.OracleParameter("v_PASS_YEAR", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_PassYear.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_PassYear.Value = lcl_obj_EmployeeEducation.EducationCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeEducation.EducationCode;

                   
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EducationCode, lcl_obj_ExamName, lcl_obj_InstName, lcl_obj_BoardUniversity, lcl_obj_MajorSubject, lcl_obj_DivisionClass, lcl_obj_Cgpa, lcl_obj_PassYear, lcl_obj_EmployeeCode };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INSERT_EMPLOYEE_EDUCATION", lcl_obj_SP_Parameters);

                    return System.UInt64.Parse(lcl_obj_EducationCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");

            return lcl_ui64_EducationCode;
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <param name="lcl_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeEducation Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmployeeEducation = null;

            lcl_obj_EmployeeEducation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_EDUCATION Where EDUCATION_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_EmpEducationReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_EmpEducationReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error EducationManager.Get(ID,DBManger)) : Error Retrieving Education Data!");
                }
                lcl_obj_EmpEducationReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EducationTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation();
                lcl_obj_EducationTmp.EducationCode = System.UInt64.Parse(lcl_obj_EmpEducationReader["EDUCATION_CODE"].ToString());
                lcl_obj_EducationTmp.ExamName = lcl_obj_EmpEducationReader["EXAM_NAME"].ToString();
                lcl_obj_EducationTmp.InstName = lcl_obj_EmpEducationReader["INST_NAME"].ToString();
                lcl_obj_EducationTmp.BoardUniversity = lcl_obj_EmpEducationReader["BOARD_UNIVERSITY"].ToString();
                lcl_obj_EducationTmp.MajorSubject = lcl_obj_EmpEducationReader["MAJOR_SUBJECT"].ToString();
                lcl_obj_EducationTmp.DivisionClass = lcl_obj_EmpEducationReader["DIVISION_CLASS"].ToString();
                lcl_obj_EducationTmp.Cgpa = lcl_obj_EmpEducationReader["CGPA"].ToString();
                lcl_obj_EducationTmp.PassYear = System.UInt16.Parse(lcl_obj_EmpEducationReader["PASS_YEAR"].ToString());
                lcl_obj_EducationTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmpEducationReader["EMPLOYEE_CODE"].ToString());
                lcl_obj_EmpEducationReader.Close();
                return lcl_obj_EducationTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeEducation;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <returns></returns>

        public CCL.BusinessEntities.HRIS.EmployeeEducation Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmployeeEducation = null;
           lcl_obj_EmployeeEducation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_EDUCATION Where EDUCATION_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EducationManager.Get(ID)) : No Education Data Found In The Database!!!");
                    }
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EducationTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation();
                lcl_obj_EducationTmp.EducationCode = System.UInt64.Parse(dr["EDUCATION_CODE"].ToString());
                lcl_obj_EducationTmp.ExamName = dr["EXAM_NAME"].ToString();
                lcl_obj_EducationTmp.InstName = dr["INST_NAME"].ToString();
                lcl_obj_EducationTmp.BoardUniversity = dr["BOARD_UNIVERSITY"].ToString();
                lcl_obj_EducationTmp.MajorSubject = dr["MAJOR_SUBJECT"].ToString();
                lcl_obj_EducationTmp.DivisionClass = dr["DIVISION_CLASS"].ToString();
                lcl_obj_EducationTmp.Cgpa = dr["CGPA"].ToString();
                lcl_obj_EducationTmp.PassYear = System.UInt16.Parse(dr["PASS_YEAR"].ToString());
                lcl_obj_EducationTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                dr.Close();
                return lcl_obj_EducationTmp;
                }
            }, "BMLExceptionPolicy");
           return lcl_obj_EmployeeEducation;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> lcl_objList_Education = null;

            lcl_objList_Education = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EducationManager.GetList(SqlQuery,DBManager)) : No Education Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> lcl_objLst_EductnTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_Education = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation();
                    lcl_obj_Education.EducationCode = System.UInt64.Parse(dr["EDUCATION_CODE"].ToString());
                    lcl_obj_Education.ExamName = dr["EXAM_NAME"].ToString();
                    lcl_obj_Education.InstName = dr["INST_NAME"].ToString();
                    lcl_obj_Education.BoardUniversity = dr["BOARD_UNIVERSITY"].ToString();
                    lcl_obj_Education.MajorSubject = dr["MAJOR_SUBJECT"].ToString();
                    lcl_obj_Education.DivisionClass = dr["DIVISION_CLASS"].ToString();
                    lcl_obj_Education.Cgpa = dr["CGPA"].ToString();
                    lcl_obj_Education.PassYear = System.UInt16.Parse(dr["PASS_YEAR"].ToString());
                    lcl_obj_Education.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    lcl_objLst_EductnTmp.Add(lcl_obj_Education);
                }
                dr.Close();
                return lcl_objLst_EductnTmp;

            }, "BMLExceptionPolicy");
            return lcl_objList_Education;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> GetList(string IP_str_SqlQuery)
        {
             System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> lcl_objList_Education = null;
            lcl_objList_Education = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>>(() =>
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
                            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EducationManager.GetList(SqlQuery)) : No Education Data Found In The Database!!!");
                        }
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> lcl_objLst_EductnTmp = new
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>();
                        while (dr.Read())
                        {
                            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_Education = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation();
                            lcl_obj_Education.EducationCode = System.UInt64.Parse(dr["EDUCATION_CODE"].ToString());
                            lcl_obj_Education.ExamName = dr["EXAM_NAME"].ToString();
                            lcl_obj_Education.InstName = dr["INST_NAME"].ToString();
                            lcl_obj_Education.BoardUniversity = dr["BOARD_UNIVERSITY"].ToString();
                            lcl_obj_Education.MajorSubject = dr["MAJOR_SUBJECT"].ToString();
                            lcl_obj_Education.DivisionClass = dr["DIVISION_CLASS"].ToString();
                            lcl_obj_Education.Cgpa = dr["CGPA"].ToString();
                            lcl_obj_Education.PassYear = System.UInt16.Parse(dr["PASS_YEAR"].ToString());
                            lcl_obj_Education.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                            lcl_objLst_EductnTmp.Add(lcl_obj_Education);
                        }
                        dr.Close();
                        return lcl_objLst_EductnTmp;
                    }
            }, "BMLExceptionPolicy");
            return lcl_objList_Education;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeEducation Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmpEducation = null;         
            lcl_obj_EmpEducation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_EmpEducationReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_EmpEducationReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error EducationManager.Get(SqlQuery,DBManger)) : Error Retrieving Education Data!");
                }
                lcl_obj_EmpEducationReader.Read();
                
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EducationTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation();
                lcl_obj_EducationTmp.EducationCode = System.UInt64.Parse(lcl_obj_EmpEducationReader["EDUCATION_CODE"].ToString());
                lcl_obj_EducationTmp.ExamName = lcl_obj_EmpEducationReader["EXAM_NAME"].ToString();
                lcl_obj_EducationTmp.InstName = lcl_obj_EmpEducationReader["INST_NAME"].ToString();
                lcl_obj_EducationTmp.BoardUniversity = lcl_obj_EmpEducationReader["BOARD_UNIVERSITY"].ToString();
                lcl_obj_EducationTmp.MajorSubject = lcl_obj_EmpEducationReader["MAJOR_SUBJECT"].ToString();
                lcl_obj_EducationTmp.DivisionClass = lcl_obj_EmpEducationReader["DIVISION_CLASS"].ToString();
                lcl_obj_EducationTmp.Cgpa = lcl_obj_EmpEducationReader["CGPA"].ToString();
                lcl_obj_EducationTmp.PassYear = System.UInt16.Parse(lcl_obj_EmpEducationReader["PASS_YEAR"].ToString());
                lcl_obj_EducationTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmpEducationReader["EMPLOYEE_CODE"].ToString());
                lcl_obj_EmpEducationReader.Close();
                return lcl_obj_EducationTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmpEducation;
        }

        public CCL.BusinessEntities.HRIS.EmployeeEducation Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmpEducation = null;
            lcl_obj_EmpEducation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EducationManager.Get(SqlQuery)) : No Education Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EducationTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation();
                    lcl_obj_EducationTmp.EducationCode = System.UInt64.Parse(dr["EDUCATION_CODE"].ToString());
                    lcl_obj_EducationTmp.ExamName = dr["EXAM_NAME"].ToString();
                    lcl_obj_EducationTmp.InstName = dr["INST_NAME"].ToString();
                    lcl_obj_EducationTmp.BoardUniversity = dr["BOARD_UNIVERSITY"].ToString();
                    lcl_obj_EducationTmp.MajorSubject = dr["MAJOR_SUBJECT"].ToString();
                    lcl_obj_EducationTmp.DivisionClass = dr["DIVISION_CLASS"].ToString();
                    lcl_obj_EducationTmp.Cgpa = dr["CGPA"].ToString();
                    lcl_obj_EducationTmp.PassYear = System.UInt16.Parse(dr["PASS_YEAR"].ToString());
                    lcl_obj_EducationTmp.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());
                    dr.Close();
                    return lcl_obj_EducationTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmpEducation;
        
            }
        }
}
