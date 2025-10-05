using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    public class ScBatch : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_ScBatchCode;
        protected System.String m_str_ScBatch;
        protected System.UInt64 m_ui64_ScJOCode;
        protected System.UInt64 m_ui64_Quantity;
        protected System.UInt64 m_ui64_StartSl;
        protected System.UInt64 m_ui64_EndSl;
        protected SilkERP360.CCL.SCPMEnumerations.JobOrderProductionStatus m_enm_ProductionStatus;
        protected SilkERP360.CCL.SCPMEnumerations.Status m_enm_Status;


        public System.UInt64 BatchCode
        {
            get { return m_ui64_ScBatchCode; }
            set { m_ui64_ScBatchCode = value; }
        }


        public System.String ScBatchName
        {
            get { return m_str_ScBatch; }
            set { m_str_ScBatch = value; }
        }


        public System.UInt64 ScJOCode
        {
            get { return m_ui64_ScJOCode; }
            set { m_ui64_ScJOCode = value; }
        }


        public System.UInt64 Quantity
        {
            get { return m_ui64_Quantity; }
            set { m_ui64_Quantity = value; }
        }


        public System.UInt64 StartSl
        {
            get { return m_ui64_StartSl; }
            set { m_ui64_StartSl = value; }
        }


        public System.UInt64 EndSl
        {
            get { return m_ui64_EndSl; }
            set { m_ui64_EndSl = value; }
        }


        public SilkERP360.CCL.SCPMEnumerations.JobOrderProductionStatus ProductionStatus
        {
            get { return m_enm_ProductionStatus; }
            set { m_enm_ProductionStatus = value; }
        }


        public SilkERP360.CCL.SCPMEnumerations.Status Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }
    }
}
