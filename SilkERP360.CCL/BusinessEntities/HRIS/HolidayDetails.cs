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
    public class HolidayDetails : SilkERP360.CCL.Validation.ValidationBase
    {




        private System.UInt64 m_uint64_HolidayDtlCode;
        private System.UInt64 m_uint64_HolidayMasterCode;
        private System.Decimal m_dcm_WeekDayName;
        private System.DateTime m_Dat_HolidayDate;

        public System.UInt64 HolidayDtlCode
        {
            get { return this.m_uint64_HolidayDtlCode; }
            set { this.m_uint64_HolidayDtlCode = value; }
        }
        public System.UInt64 HolidayMasterCode
        {
            get { return this.m_uint64_HolidayMasterCode; }
            set { this.m_uint64_HolidayMasterCode = value; }
        }
        public System.Decimal WeekDayName
        {
            get { return this.m_dcm_WeekDayName; }
            set { this.m_dcm_WeekDayName = value; }
        }
        public System.DateTime HolidayDate
        {
            get { return this.m_Dat_HolidayDate; }
            set { this.m_Dat_HolidayDate = value; }
        }
    }
}