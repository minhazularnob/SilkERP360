using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class AttendanceDetails : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR
        public AttendanceDetails()
        {
           
        }
        #endregion

        #region VALIDATION
         ////[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "InDataTime", Message = "In Data Time Entry")]
         ////[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "OutDataTime", Message = "Out Data Time Entry")]
         ////[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "AttanSatus", Message = "Attan Satus Entry")]
        #endregion

        #region protected VARIABLES

        protected UInt64 m_ui64_AtandanceCode;
        protected DateTime m_date_PunchDate;
        protected UInt64 m_uint64_ShiftCode;
        protected DateTime m_date_InDataTime;
        protected DateTime m_date_OutDateTime;
        protected Int16 m_int16_OT;
        protected Int64 m_int16_Late;
        protected System.String str_LateString;

        
        //protected SilkERP360.CCL.Enums.AttendanceStatus m_enm_AttnStatus;
        protected System.String m_str_AttnStatusString;


        protected Int16 m_int16_AttanSatus;
        protected UInt64 m_ui64_AttanMasterCode;
        protected Int16 m_int16_Delete;
        protected Int16 m_int16_Status;
                
        #endregion

        #region PUBLIC PROPERTIES
        public UInt64 AtandanceCode
        {
            get { return m_ui64_AtandanceCode; }
            set { this.m_ui64_AtandanceCode = value; }
        }
        public DateTime PunchDate
        {
            get { return m_date_PunchDate; }
            set { m_date_PunchDate = value; }
        }
        public UInt64 ShiftCode
        {
            get { return m_uint64_ShiftCode; }
            set { m_uint64_ShiftCode = value; }
        }

        public DateTime InDataTime
        {
            get { return m_date_InDataTime; }
            set { this.m_date_InDataTime = value; }
        }

        public DateTime OutDateTime
        {
            get { return m_date_OutDateTime; }
            set { this.m_date_OutDateTime = value; }
        }
        public Int16 OT
        {
            get { return m_int16_OT; }
            set { m_int16_OT = value; }
        }

        public Int64 Late
        {
            get { return m_int16_Late; }
            set { m_int16_Late = value; }
        }

        public System.String LateString
        {
            get { return str_LateString; }
            set { str_LateString = value; }
        }
        public System.String AttnStatusString
        {
            get { return m_str_AttnStatusString; }
            set { m_str_AttnStatusString = value; }
        }
        public Int16 AttanSatus
        {
            get { return m_int16_AttanSatus; }
            set { m_int16_AttanSatus = value; }
        }
        public UInt64 AttanMasterCode
        {
            get { return m_ui64_AttanMasterCode; }
            set { m_ui64_AttanMasterCode = value; }
        }

        public Int16 Delete
        {
            get { return m_int16_Delete; }
            set { m_int16_Delete = value; }
        }
        public Int16 Status
        {
            get { return m_int16_Status; }
            set { m_int16_Status = value; }
        }
        #endregion

    }
}
