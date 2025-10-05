using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.Base
{
    public abstract class EmployeeCore : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return this.m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        //protected SilkERP360.CCL.Enums.Status m_enm_Status;
        //public SilkERP360.CCL.Enums.Status Status
        //{
        //    get { return this.m_enm_Status; }
        //    set { this.m_enm_Status = value; }
        //}

        //[SilkERP360.CCL.Validation.Attributes.CurrentDate(FieldName="EntryDate",Message="EntryDate Must Be Today's Date!!!")]
        //protected System.DateTime m_dt_EntryDate;
        //public System.DateTime EntryDate
        //{
        //    get { return this.m_dt_EntryDate; }
        //    set { this.m_dt_EntryDate = value; }
        //}

        //protected System.UInt64 m_ui64_UserCode;
        ///// <summary>
        ///// UserCode of the employee who entered the data
        ///// </summary>
        //public System.UInt64 UserCode
        //{
        //    get { return this.m_ui64_UserCode; }
        //    set { this.m_ui64_UserCode = value; }
        //}

        //protected SilkERP360.CCL.Enums.YesNo m_enm_IsDeleted;
        ///// <summary>
        ///// Is Deleted Flag
        ///// </summary>
        //public SilkERP360.CCL.Enums.YesNo IsDeleted
        //{
        //    get { return this.m_enm_IsDeleted; }
        //    set { this.m_enm_IsDeleted = value; }
        //}
    }
}
