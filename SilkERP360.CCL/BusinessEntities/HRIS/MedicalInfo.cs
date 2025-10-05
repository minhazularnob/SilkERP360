using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("MEDICALE_INFO", "SEQ_MEDICALE_INFO")]
    public class MedicalInfo : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MDCN_INFO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_MedicalInfoCode;
        public System.UInt64 MedicalInfoCode
        {
            get { return m_ui64_MedicalInfoCode; }
            set { this.m_ui64_MedicalInfoCode = value; }
        }
       
         
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("AGE", typeof(System.String), true, false)]
        protected System.String m_str_Age;
        public System.String Age
        {
            get { return m_str_Age; }
            set { this.m_str_Age = value; }
        }
        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SEX", typeof(System.String), true, false)]
        protected System.String m_str_Sex;
        public System.String Sex
        {
            get { return m_str_Sex; }
            set { m_str_Sex = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("VISITED_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_VisitedDate;
        public System.DateTime VisitedDate
        {
            get { return m_dt_VisitedDate; }
            set { m_dt_VisitedDate = value; }
        }
        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(System.UInt16), true, false)]
        protected System.UInt16 m_ui16_Status;
        public System.UInt16 Status
        {
            get { return m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BLOOD_GROUP", typeof(System.String), true, false)]
        protected System.String m_str_BloodGroup;
        public System.String BloodGroup
        {
            get { return m_str_BloodGroup; }
            set { m_str_BloodGroup = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DIAGNOSIS", typeof(System.String), true, false)]
        protected System.String m_str_Diagnosis;
        public System.String Diagnosis
        {
            get { return m_str_Diagnosis; }
            set { m_str_Diagnosis = value; }
        }
        
    }
}
