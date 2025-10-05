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
    public class HolidayMaster : SilkERP360.CCL.Validation.ValidationBase
    {
        #region CONSTRUCTOR
        public HolidayMaster()
        {
        }
        #endregion

        #region protected VARIABLES

        protected  System.UInt64 m_uint64_HolidayMasterCode;
        protected System.UInt64 m_uint64_CompanyCode;
        protected  System.DateTime m_Dat_DecDate;
        protected  System.UInt16 m_uint64_NumOfDays;
        protected  System.UInt16 m_uint16_Status;
        protected  System.UInt16 m_uint16_IsDeleted;
        protected  System.DateTime m_Dat_StartDate;
        protected  System.DateTime m_dat_EndDate;
        protected  System.String m_str_Remarks;
        protected  System.String m_str_HolidayName;
        #endregion

        #region public PROPERTIES
        public System.UInt64 HolidayMasterCode
        {
            get { return m_uint64_HolidayMasterCode; }
            set { this.m_uint64_HolidayMasterCode = value; }
        }
        
        public System.UInt64 CompanyCode
        {
            get { return m_uint64_CompanyCode; }
            set { this.m_uint64_CompanyCode = value; }
        }
        
        public System.DateTime DecDate
        {
            get { return this.m_Dat_DecDate; }
            set { this.m_Dat_DecDate = value; }
        }
        public System.UInt16 NumOfDays
        {
            get { return m_uint64_NumOfDays; }
            set { this.m_uint64_NumOfDays = value; }
        }
        public System.UInt16 Status
        {
            get { return m_uint16_Status; }
            set { this.m_uint16_Status = value; }
        }
        public System.UInt16 IsDeleted
        {
            get { return m_uint16_IsDeleted; }
            set { this.m_uint16_IsDeleted = value; }
        }


        public System.DateTime StartDate
        {
            get { return this.m_Dat_StartDate; }
            set { this.m_Dat_StartDate = value; }
        }
        public System.DateTime EndDate
        {
            get { return m_dat_EndDate; }
            set { this.m_dat_EndDate = value; }
        }
        
        public System.String Remarks
        {
            get { return this.m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }
        public System.String HolidayName
        {
            get { return this.m_str_HolidayName; }
            set { this.m_str_HolidayName = value; }
        }
        #endregion
    }
}