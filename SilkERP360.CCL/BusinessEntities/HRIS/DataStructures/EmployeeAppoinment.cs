using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class EmployeeAppoinment : SilkERP360.CCL.Validation.ValidationBase
    {
        private SilkERP360.CCL.BusinessEntities.HRIS.Employee m_obj_Employee = null;

        public SilkERP360.CCL.BusinessEntities.HRIS.Employee Employee
        {
            get { return this.m_obj_Employee; }
            set { this.m_obj_Employee = value; }
        }
        private SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal m_obj_EmployeePersonal = null;

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal EmployeePersonal
        {
            get { return this.m_obj_EmployeePersonal; }
            set { this.m_obj_EmployeePersonal = value; }
        }

        private SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure m_obj_EmployeeSalaryStructure = null;

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure EmployeeSalaryStructure
        {
            get { return this.m_obj_EmployeeSalaryStructure; }
            set { this.m_obj_EmployeeSalaryStructure = value; }
        }
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> m_objLst_EmployeeWeekend;

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend> EmployeeWeekend
        {
            get { return this.m_objLst_EmployeeWeekend; }
            set { m_objLst_EmployeeWeekend = value; }
        }



        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> m_objLst_EmployeeEducation;
        
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation> EmployeeEducation
        {
            get { return this.m_objLst_EmployeeEducation; }
            set { this.m_objLst_EmployeeEducation = value; }
        }
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> m_objLst_EmployeeEntitledLeaveList;

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave> EmployeeEntitledLeaveList
        {
            get { return this.m_objLst_EmployeeEntitledLeaveList; }
            set { this.m_objLst_EmployeeEntitledLeaveList = value; }
        }
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference> m_objList_EmployeeReferenceList;

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference> EmployeeReferenceList
        {
            get { return m_objList_EmployeeReferenceList; }
            set { m_objList_EmployeeReferenceList = value; }
        }
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience> m_objList_EmployeeExperienceList;

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience> EmployeeExperienceList
        {
            get { return m_objList_EmployeeExperienceList; }
            set { m_objList_EmployeeExperienceList = value; }
        }
        private SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount m_obj_BankAccount;

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeBankAccount BankAccount
        {
            get { return this.m_obj_BankAccount; }
            set { this.m_obj_BankAccount = value; }
        }
        private SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund m_obj_ProvidentFund;

        public SilkERP360.CCL.BusinessEntities.HRIS.ProvidentFund ProvidentFund
        {
            get { return this.m_obj_ProvidentFund; }
            set { this.m_obj_ProvidentFund = value; }
        }
        private SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage m_obj_Image;

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage Image
        {
            get { return this.m_obj_Image; }
            set { this.m_obj_Image = value; }
        }

        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeCertificate> m_objList_EmployeeCertificateList;

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeCertificate> EmployeeCertificateList
        {
            get { return m_objList_EmployeeCertificateList; }
            set { m_objList_EmployeeCertificateList = value; }
        }
    }
}
