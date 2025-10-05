using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    public class Fixed : SilkERP360.CCL.Validation.ValidationBase
    {
        public Fixed()
        { 
        
        }
                    protected System.UInt64 m_ui64_RelationCode;
                    protected System.UInt64 m_ui64_FinishedProductCode;
                    protected System.UInt64 m_ui64_BuyerCode;
                    protected System.UInt16 m_ui16_Status;
                    protected System.Decimal m_dec_ProcessingCost;
                    protected System.Decimal m_dec_PrintingCharge;
                    protected System.Decimal m_dec_Width;
                    protected System.Decimal m_dec_Length;
                    protected System.Decimal m_dec_Gusset;
                    protected System.Decimal m_dec_Density;
                    protected System.Decimal m_dec_Thickness;
                    protected System.String m_str_SpecificationName;
                    protected System.Decimal m_dec_PunchOut;
                    protected System.UInt64 m_str_ItemCode;

        #region

        public System.UInt64 RelationCode
        {
            get { return m_ui64_RelationCode; }
            set { this.m_ui64_RelationCode = value; }
        }

        public System.UInt64 FinishedProductCode
        {
            get { return m_ui64_FinishedProductCode; }
            set { this.m_ui64_FinishedProductCode = value; }
        }

        public System.UInt64 BuyerCode
        {
            get { return m_ui64_BuyerCode; }
            set { this.m_ui64_BuyerCode = value; }
        }

        public System.UInt16 Status
        {
            get { return m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }
        public System.Decimal ProcessingCost
        {
            get { return m_dec_ProcessingCost; }
            set { this.m_dec_ProcessingCost = value; }
        }
        public System.Decimal PrintingCharge
        {
            get { return m_dec_PrintingCharge; }
            set { this.m_dec_PrintingCharge = value; }
        }

        public System.String SpecificationName
        {
            get { return m_str_SpecificationName; }
            set { m_str_SpecificationName = value; }
        }

        public System.Decimal Thickness
        {
            get { return m_dec_Thickness; }
            set { m_dec_Thickness = value; }
        }

        public System.Decimal Density
        {
            get { return m_dec_Density; }
            set { m_dec_Density = value; }
        }

        public System.Decimal Gusset
        {
            get { return m_dec_Gusset; }
            set { m_dec_Gusset = value; }
        }

        public System.Decimal Length
        {
            get { return m_dec_Length; }
            set { m_dec_Length = value; }
        }

        public System.Decimal Width
        {
            get { return m_dec_Width; }
            set { m_dec_Width = value; }
        }

        public System.Decimal PunchOut
        {
            get { return m_dec_PunchOut; }
            set { m_dec_PunchOut = value; }
        }

        public System.UInt64 ItemCode
        {
            get { return m_str_ItemCode; }
            set { m_str_ItemCode = value; }
        }
        #endregion
    }
}
