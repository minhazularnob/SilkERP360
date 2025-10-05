using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class OvertimeHistory
    {
        protected System.Decimal m_dcm_OvertimeRate;
        public System.Decimal OvertimeRate
        {
            get { return m_dcm_OvertimeRate; }
            set { m_dcm_OvertimeRate = value; }
        }

        protected System.Double m_dbl_TotalOvertime;
        public System.Double TotalOvertime
        {
            get { return m_dbl_TotalOvertime; }
            set { m_dbl_TotalOvertime = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile m_obj_EmployeeProfile;
        public SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile EmployeeProfile
        {
            get { return this.m_obj_EmployeeProfile; }
            set { this.m_obj_EmployeeProfile = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> m_objLst_OvertimeList;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> OvertimeList
        {
            get { return m_objLst_OvertimeList; }
            set { m_objLst_OvertimeList = value; }
        }

    }
}
