using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    public class RawProduct : SilkERP360.CCL.Validation.ValidationBase
    {
        public RawProduct()
      {

      }
        //protected SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials m_lcl_obj_RawMaterialsList = new RawMaterials();

        //public SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials lcl_obj_RawMaterialsList
        //{
        //    get { return m_lcl_obj_RawMaterialsList; }
        //    set { m_lcl_obj_RawMaterialsList = value; }
        //}

       protected System.UInt64 m_ui64_RMCode;

        public System.UInt64 RMCode
        {
            get { return m_ui64_RMCode; }
            set { m_ui64_RMCode = value; }
        }
        protected System.String m_ui64_RMName;

        public System.String RMName
        {
            get { return m_ui64_RMName; }
            set { m_ui64_RMName = value; }
        }
        protected System.UInt64 m_ui16_Status;

        public System.UInt64 Status
        {
            get { return m_ui16_Status; }
            set { m_ui16_Status = value; }
        }

    }
}
