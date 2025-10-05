using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeePersonal : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR
        public EmployeePersonal()
        {
        }
        #endregion

        #region VALIDATION
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "FatherName", Message = "Father Name Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "MotherName", Message = "Mother Name Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "DateOfBirth", Message = "Date Of Birth Entry")]

    //[SilkERP360.CCL.Validation.Attributes.AgeRange(FieldName = "DateOfBirth", Message = "Date Of Birth Entry")]

    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "MaritalStatus", Message = "Marital Status Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Sex", Message = "Sex Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Religion", Message = "Religion Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Nationality", Message = "Nationality Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "BloodGroup", Message = "Blood Group Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "PresentAddress", Message = "Present Address Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "PermanentAddress", Message = "Permanent Address Entry")]
    #endregion

        #region protected VARIABLES
        protected System.UInt64 m_uint64_EmployeeCode;
        protected System.String m_str_FatherName;
        protected System.String m_str_MotherName;
        protected System.String m_str_SpouseName;
        protected System.DateTime m_Dat_DateOfBirth;
        protected System.String m_str_MaritalStatus;
        protected System.String m_str_Sex;
        protected System.String m_str_Religion;
        protected System.String m_str_Nationality;
        protected System.String m_str_BloodGroup;
        protected System.String m_str_Height;
        protected System.String m_str_Weight;
        protected System.String m_str_Identification;
        protected System.String m_str_MobileNo;
        protected System.String m_str_HomePhoneNo;
        protected System.String m_str_FaxNo;
        protected System.String m_str_Email;
        protected System.String m_str_PresentAddress;
        protected System.String m_str_PresentPo;
        protected System.String m_str_PresentPc;
        protected System.UInt64  m_uint64_PresentDistrictCode;
        protected System.String m_str_PermanentAddress;
        protected System.String m_str_PermanentPo;
        protected System.String m_str_PermanentPc;
        protected System.UInt64 m_uint64_PermanentDistrictCode;
        protected System.String m_str_CitizenCardId;
        protected System.String m_str_PassportNo;
        protected System.UInt16 m_uint16_IsDeleted;
        protected System.UInt16 m_uint16_Status;
        #endregion

        #region PUBLIC PROPERTIES
        public System.UInt64 EmployeeCode
        {
            get { return this.m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
        }
        public System.String FatherName
        {
            get { return this.m_str_FatherName; }
            set { this.m_str_FatherName = value; }
        }
        public System.String MotherName
        {
            get { return this.m_str_MotherName; }
            set { this.m_str_MotherName = value; }
        }
        public System.String SpouseName
        {
            get { return this.m_str_SpouseName; }
            set { this.m_str_SpouseName = value; }
        }
        public System.DateTime DateOfBirth
        {
            get { return this.m_Dat_DateOfBirth; }
            set { this.m_Dat_DateOfBirth = value; }
        }
        public System.String MaritalStatus
        {
            get { return this.m_str_MaritalStatus; }
            set { this.m_str_MaritalStatus = value; }
        }
        public System.String Sex
        {
            get { return this.m_str_Sex; }
            set { this.m_str_Sex = value; }
        }
        public System.String Religion
        {
            get { return this.m_str_Religion; }
            set { this.m_str_Religion = value; }
        }
        public System.String Nationality
        {
            get { return this.m_str_Nationality; }
            set { this.m_str_Nationality = value; }
        }
        public System.String BloodGroup
        {
            get { return this.m_str_BloodGroup; }
            set { this.m_str_BloodGroup = value; }
        }
        public System.String Height
        {
            get { return this.m_str_Height; }
            set { this.m_str_Height = value; }
        }
        public System.String Weight
        {
            get { return this.m_str_Weight; }
            set { this.m_str_Weight = value; }
        }
        public System.String Identification
        {
            get { return this.m_str_Identification; }
            set { this.m_str_Identification = value; }
        }
        public System.String MobileNo
        {
            get { return this.m_str_MobileNo; }
            set { this.m_str_MobileNo = value; }
        }
        public System.String HomePhoneNo
        {
            get { return this.m_str_HomePhoneNo; }
            set { this.m_str_HomePhoneNo = value; }
        }
        public System.String FaxNo
        {
            get { return this.m_str_FaxNo; }
            set { this.m_str_FaxNo = value; }
        }
        public System.String Email
        {
            get { return this.m_str_Email; }
            set { this.m_str_Email = value; }
        }
        public System.String PresentAddress
        {
            get { return this.m_str_PresentAddress; }
            set { this.m_str_PresentAddress = value; }
        }
        public System.String PresentPo
        {
            get { return this.m_str_PresentPo; }
            set { this.m_str_PresentPo = value; }
        }
        public System.String PresentPc
        {
            get { return this.m_str_PresentPc; }
            set { this.m_str_PresentPc = value; }
        }
        public System.UInt64 PresentDistrictCode
        {
            get { return this.m_uint64_PresentDistrictCode; }
            set { this.m_uint64_PresentDistrictCode = value; }
        }
        public System.String PermanentAddress
        {
            get { return this.m_str_PermanentAddress; }
            set { this.m_str_PermanentAddress = value; }
        }
        public System.String PermanentPo
        {
            get { return this.m_str_PermanentPo; }
            set { this.m_str_PermanentPo = value; }
        }
        public System.String PermanentPc
        {
            get { return this.m_str_PermanentPc; }
            set { this.m_str_PermanentPc = value; }
        }
        public System.UInt64 PermanentDistrictCode
        {
            get { return this.m_uint64_PermanentDistrictCode; }
            set { this.m_uint64_PermanentDistrictCode = value; }
        }
        public System.String CitizenCardId
        {
            get { return this.m_str_CitizenCardId; }
            set { this.m_str_CitizenCardId = value; }
        }
        public System.String PassportNo
        {
            get { return this.m_str_PassportNo; }
            set { this.m_str_PassportNo = value; }
        }
        public System.UInt16 IsDeleted
        {
            get { return this.m_uint16_IsDeleted; }
            set { this.m_uint16_IsDeleted = value; }
        }
        public System.UInt16 Status
        {
            get { return this.m_uint16_Status; }
            set { this.m_uint16_Status = value; }
        }
        #endregion
    }
}
