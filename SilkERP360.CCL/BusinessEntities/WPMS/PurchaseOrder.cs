using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_PURCHASE_ORDER", "SEQ_WPMS_PURCHASE_ORDER")]
    public class PurchaseOrder : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PURCHASE_ORDER_CODE", typeof(System.UInt64), false, false)]
        System.UInt64 m_ui64_PurchaseOrderCode;

        public System.UInt64 PurchaseOrderCode
        {
            get { return m_ui64_PurchaseOrderCode; }
            set { m_ui64_PurchaseOrderCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BUYER_CODE", typeof(System.UInt64), false, false)]
        System.UInt64 m_ui64_BuyerCode;

        public System.UInt64 BuyerCode
        {
            get { return m_ui64_BuyerCode; }
            set { m_ui64_BuyerCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PURCHASE_ORDER_DATE", typeof(System.DateTime), false, false)]
        System.DateTime m_dt_PurchaseOrderDate;

        public System.DateTime PurchaseOrderDate
        {
            get { return m_dt_PurchaseOrderDate; }
            set { m_dt_PurchaseOrderDate = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(System.UInt64), false, false)]
        System.UInt16 m_ui64_IsActive;

        public System.UInt16 IsActive
        {
            get { return m_ui64_IsActive; }
            set { m_ui64_IsActive = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_REQ", typeof(System.String), false, false)]
        System.String m_str_CustomerReq;

        public System.String CustomerReq
        {
            get { return m_str_CustomerReq; }
            set { m_str_CustomerReq = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COM_NAME", typeof(System.String), false, false)]
        System.String m_str_ComName;

        public System.String ComName
        {
            get { return m_str_ComName; }
            set { m_str_ComName = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COM_ADDRESS", typeof(System.String), false, false)]
        System.String m_str_ComAddress;

        public System.String ComAddress
        {
            get { return m_str_ComAddress; }
            set { m_str_ComAddress = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COM_PHONE", typeof(System.String), false, false)]
        System.String m_str_ComPhone;

        public System.String ComPhone
        {
            get { return m_str_ComPhone; }
            set { m_str_ComPhone = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COM_EMAIL", typeof(System.String), false, false)]
        System.String m_str_ComEmail;

        public System.String ComEmail
        {
            get { return m_str_ComEmail; }
            set { m_str_ComEmail = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COM_AMOUNT", typeof(System.Decimal), false, false)]
        System.Decimal m_dec_ComAmount;

        public System.Decimal ComAmount
        {
            get { return m_dec_ComAmount; }
            set { m_dec_ComAmount = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_CODE", typeof(System.UInt64), false, false)]
        System.UInt64 m_ui64_QuotationCode;

        public System.UInt64 QuotationCode
        {
            get { return m_ui64_QuotationCode; }
            set { m_ui64_QuotationCode = value; }
        }
    }
}
