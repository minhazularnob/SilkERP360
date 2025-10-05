using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
   public class EmployeeStatusHistory
    {
       public EmployeeStatusHistory()
       {
       }

       protected System.UInt64 m_ui64_EmployeeCode;
       protected SilkERP360.CCL.Enums.EmployeeStatus m_enm_CurrentStatusCode;
       protected SilkERP360.CCL.Enums.EmployeeStatus m_enm_OldtStatusCode;
       protected System.DateTime m_dt_EffectDate;

       public System.UInt64 EmployeeCode
       {
           get { return m_ui64_EmployeeCode; }
           set { this.m_ui64_EmployeeCode = value; }
       }
       public SilkERP360.CCL.Enums.EmployeeStatus CurrentStatusCode
       {
           get { return m_enm_CurrentStatusCode; }
           set { this.m_enm_CurrentStatusCode = value; }
       }

       public SilkERP360.CCL.Enums.EmployeeStatus OldtStatusCode
       {
           get { return m_enm_OldtStatusCode; }
           set { this.m_enm_OldtStatusCode = value; }
       }
       public System.DateTime EffectDate
       {
           get { return m_dt_EffectDate; }
           set { this.m_dt_EffectDate = value; }
       }

       //protected SilkERP360.CCL.Enums.YesNo m_enm_IsDeleted;
       //protected UInt16 m_ui16_Status;

    }
}