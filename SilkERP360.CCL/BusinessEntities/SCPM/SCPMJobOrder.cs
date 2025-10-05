using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_JOB_ORDER", "SEQ_SCPM_JOB_ORDER")]
    public class SCPMJobOrder : SilkERP360.CCL.Validation.ValidationBase
    {
        public SCPMJobOrder()
        {
            this._AdditionalData = new Dictionary<string, object>();
        }
        [CCL.DatabaseMapping.DatabaseColumnMapping("JOB_ORDER_CODE", typeof(System.UInt64), true,false)]
        protected System.UInt64 m_ui64_JobOrderCode;
        public System.UInt64 JobOrderCode
        {
            get { return m_ui64_JobOrderCode; }
            set { m_ui64_JobOrderCode = value; }
        }

        [CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false,false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { m_ui64_CompanyCode = value; }
        }

        [CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_CustomerCode;
        public System.UInt64 CustomerCode
        {
            get { return m_ui64_CustomerCode; }
            set { m_ui64_CustomerCode = value; }
        }

        [CCL.DatabaseMapping.DatabaseColumnMapping("ORDER_QUANTITY", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_OrderQuantity;
        public System.UInt32 OrderQuantity
        {
            get { return this.m_ui32_OrderQuantity; }
            set { this.m_ui32_OrderQuantity = value; }
        }

        [CCL.DatabaseMapping.DatabaseColumnMapping("COMPLETED_QUANTITY", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_CompletedQuantity;
        public System.UInt32 CompletedQuantity
        {
            get { return this.m_ui32_CompletedQuantity; }
            set { this.m_ui32_CompletedQuantity = value; }
        }

        [CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_SPECIFICATION", typeof(System.String), false, false)]
        protected System.String m_str_ProductSpecification;
        public System.String ProductSpecification
        {
            get { return this.m_str_ProductSpecification; }
            set { this.m_str_ProductSpecification = value; }
        }

        [CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_TYPE", typeof(SilkERP360.CCL.Enums.SCPM.ProductType), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.ProductType m_enm_ProductType;
        public SilkERP360.CCL.Enums.SCPM.ProductType ProductType
        {
            get { return m_enm_ProductType; }
            set { m_enm_ProductType = value; }
        }

        [CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.Status), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.JobOrderStatus m_enm_Status;
        public SilkERP360.CCL.Enums.SCPM.JobOrderStatus Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }

        /// <summary>
        /// Will contain data to be used by Clients or Charts
        /// </summary>
        //protected System.Collections.Generic.Dictionary<System.String, System.Object> m_obj_AdditionalData;
        //public System.Collections.Generic.Dictionary<System.String, System.Object> AdditionalData
        //{
        //    get { return m_obj_AdditionalData; }
        //    set { m_obj_AdditionalData = value; }
        //}

        
    }
}
