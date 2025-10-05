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

    public class Shift : SilkERP360.CCL.Validation.ValidationBase
    {
        #region public CONSTRUCTOR

        public Shift()
        {
        }

        #endregion


        #region protected VARIABLES

        protected System.UInt64 m_ui64_ShiftCode;
        protected System.String m_str_ShiftName;
        protected System.DateTime m_dt_StartTime;
        protected System.DateTime m_dt_EndTime;
        protected System.DateTime m_dt_ToleranceTime;
        protected System.UInt32 m_ui32_SortOrder;
        protected System.UInt64 m_ui64_CompanyCode;
        protected System.UInt16 m_ui16_RegularDutyHour;
        protected System.UInt16 m_ui16_IsDeleted;
        protected System.UInt16 m_ui16_Status;

        #endregion

        #region public PROPERTIES

        public System.UInt64 ShiftCode
        {
            get { return this.m_ui64_ShiftCode; }
            set { this.m_ui64_ShiftCode = value; }
        }
        public System.String ShiftName
        {
            get { return this.m_str_ShiftName; }
            set { this.m_str_ShiftName = value; }
        }
        public System.DateTime StartTime
        {
            get { return this.m_dt_StartTime; }
            set { this.m_dt_StartTime = value; }
        }
        public System.DateTime EndTime
        {
            get { return this.m_dt_EndTime; }
            set { this.m_dt_EndTime = value; }
        }
        public System.DateTime ToleranceTime
        {
            get { return this.m_dt_ToleranceTime; }
            set { this.m_dt_ToleranceTime = value; }
        }
        public System.UInt32 SortOrder
        {
            get { return this.m_ui32_SortOrder; }
            set { this.m_ui32_SortOrder = value; }
        }
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }
        public System.UInt16 RegularDutyHour
        {
            get { return m_ui16_RegularDutyHour; }
            set { this.m_ui16_RegularDutyHour = value; }
        }
       
        public System.UInt16 IsDeleted
        {
            get { return this.m_ui16_IsDeleted; }
            set { this.m_ui16_IsDeleted = value; }
        }
        public System.UInt16 Status
        {
            get { return this.m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }

        #endregion
    }
}