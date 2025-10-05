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
    public class Leave : SilkERP360.CCL.Validation.ValidationBase
    {
        #region CONOSTRUCTOR
        public Leave()
        {

        }
        public Leave(System.UInt64 IP_ui64_LeaveCode, UInt64 IP_ui64_CompanyCode, System.String IP_str_LeaveName, System.String IP_str_ShortName, System.UInt32 IP_ui32_NoOfDays, System.Nullable<UInt64> IP_ui16_IsCarryForwarded)
        {
            this.m_ui64_LeaveCode = IP_ui64_LeaveCode;
            this.m_ui64_CompanyCode = IP_ui64_CompanyCode;
            this.m_str_LeaveName = IP_str_LeaveName;
            this.m_str_ShortName = IP_str_ShortName;
            this.m_ui32_NoOfDays = IP_ui32_NoOfDays;
            this.m_ui16_IsCarryForwarded = IP_ui16_IsCarryForwarded;
        }
        #endregion

        #region VALIDATION
        //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "LeaveName", Message = "Leave Name Entry")]
        //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "NoOfDays", Message = "No Of Days Entry")]
        //[SilkERP360.CCL.Validation.Attributes.IntegerRange(FieldName = "NoOfDays", Message = "No Of Days Entry")]
        #endregion

        #region VARIABLE

        protected System.UInt64 m_ui64_LeaveCode;
        protected System.UInt64 m_ui64_CompanyCode;
        protected System.String m_str_LeaveName;
        protected System.String m_str_ShortName;
        protected System.UInt32 m_ui32_NoOfDays;

        protected System.Nullable<UInt64> m_ui16_IsCarryForwarded;
        protected System.UInt16 m_ui16_IsDeleted;
        protected System.UInt16 m_ui16_Status;

        #endregion

        #region PROPERTIES
        public System.UInt64 LeaveCode
        {
            get { return this.m_ui64_LeaveCode; }
            set { this.m_ui64_LeaveCode = value; }
        }
        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }
        public System.String LeaveName
        {
            get { return this.m_str_LeaveName; }
            set { this.m_str_LeaveName = value; }
        }
        public System.String ShortName
        {
            get { return this.m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }
        public System.UInt32 NoOfDays
        {
            get { return this.m_ui32_NoOfDays; }
            set { this.m_ui32_NoOfDays = value; }
        }        
        public System.Nullable<UInt64 > IsCarryForwarded
        {
            get { return this.m_ui16_IsCarryForwarded; }
            set { this.m_ui16_IsCarryForwarded = (System.Nullable<UInt64>)value; }
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