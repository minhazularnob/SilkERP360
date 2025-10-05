using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    public class RawLIST : SilkERP360.CCL.Validation.ValidationBase
    {

       public RawLIST()
      {

      }
        protected System.UInt64 m_ui64_RMSubCode;
        protected System.String m_str_RMSubName;
        protected System.UInt16 m_ui16_Status;
        protected System.UInt64 m_ui64_RMCode;



        public System.UInt64 RMSubCode
        {
            get { return m_ui64_RMSubCode; }
            set { m_ui64_RMSubCode = value; }
        }
       

        public System.String RMSubName
        {
            get { return m_str_RMSubName; }
            set { m_str_RMSubName = value; }
        }
        

        public System.UInt16 Status
        {
            get { return m_ui16_Status; }
            set { m_ui16_Status = value; }
        }
        

        public System.UInt64 RMCode
        {
            get { return m_ui64_RMCode; }
            set { m_ui64_RMCode = value; }
        }
    }
}
