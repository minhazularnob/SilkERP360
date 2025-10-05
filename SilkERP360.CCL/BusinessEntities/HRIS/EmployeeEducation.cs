using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeeEducation : SilkERP360.CCL.Validation.ValidationBase
    {
        #region CONSTRUCTOR
        public EmployeeEducation()
        {
        }

        #endregion

        #region VALIDATION
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "ExamName", Message = "Exam Name Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "BoardUniversity", Message = "Board University Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "PassYear", Message = "Pass Year Entry")]
    #endregion

        #region protected VARIABLES
        protected System.UInt64 m_uint64_EducationCode;
        protected System.String m_str_ExamName;
        protected System.String m_str_InstName;
        protected System.String m_str_BoardUniversity;
        protected System.String m_str_MajorSubject;
        protected System.String m_str_DivisionClass;
        protected System.String m_str_Cgpa;
        protected System.UInt16 m_dcm_PassYear;
        protected System.UInt64 m_uint64_EmployeeCode;
        protected System.Int16 m_int16_IsDeleted;
        protected System.Int16 m_int16_Status;


        #endregion

        #region PUBLIC PROPERTIES
        public System.UInt64 EducationCode
        {
            get { return this.m_uint64_EducationCode; }
            set { this.m_uint64_EducationCode = value; }
        }
        public System.String ExamName
        {
            get { return this.m_str_ExamName; }
            set { this.m_str_ExamName = value; }
        }
        public System.String InstName
        {
            get { return this.m_str_InstName; }
            set { this.m_str_InstName = value; }
        }
        public System.String BoardUniversity
        {
            get { return this.m_str_BoardUniversity; }
            set { this.m_str_BoardUniversity = value; }
        }
        public System.String MajorSubject
        {
            get { return this.m_str_MajorSubject; }
            set { this.m_str_MajorSubject = value; }
        }
        public System.String DivisionClass
        {
            get { return this.m_str_DivisionClass; }
            set { this.m_str_DivisionClass = value; }
        }
        public System.String Cgpa
        {
            get { return this.m_str_Cgpa; }
            set { this.m_str_Cgpa = value; }
        }
        public System.UInt16 PassYear
        {
            get { return this.m_dcm_PassYear; }
            set { this.m_dcm_PassYear = value; }
        }
        public System.UInt64 EmployeeCode
        {
            get { return this.m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
        }
       
        public System.Int16 IsDeleted
        {
            get { return this.m_int16_IsDeleted; }
            set { this.m_int16_IsDeleted = value; }
        }
        public System.Int16 Status
        {
            get { return this.m_int16_Status; }
            set { this.m_int16_Status = value; }
        }
         #endregion
    }
}