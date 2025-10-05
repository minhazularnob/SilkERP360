using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    /// <summary>
    /// Represents GROUP_SALARY_PROFILE entity.
    /// Before running any salary related monthly services, this entity is checked.
    /// If the salary profile of a sister concern is not created for a particular Month/Year, no service runs
    /// If profile created, service checkes if it has already run for this month. If already run, Service exists
    /// Class will be used by SalaryService only
    /// </summary>
    public class GroupSalaryProfile
    {
        public UInt16 SalaryProfileCode;
        public UInt64 CompanyCode;
        public CCL.Enums.Month Month;
        public UInt16 Year;
        /// <summary>
        /// YES for already processed else NO
        /// </summary>
        public CCL.Enums.YesNo MonthlyAllowanceProcessorStatus;
        public System.DateTime MonthlyAllowanceProcessorRunDateTime;

        /// <summary>
        /// YES for already processed else NO
        /// </summary>
        public CCL.Enums.YesNo TaxProcessorStatus;
        public System.DateTime TaxProcessorRunDateTime;

        /// <summary>
        /// YES for already processed else NO
        /// </summary>
        public CCL.Enums.YesNo ProvidentFundProcessorStatus;
        public System.DateTime ProvidentFundProcessorRunDateTime;

        /// <summary>
        /// YES for already processed else NO
        /// </summary>
        public CCL.Enums.YesNo SalaryProcessorStatus;
        public System.DateTime SalaryProcessorRunDateTime;
    }
}
