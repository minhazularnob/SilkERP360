using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    /// <summary>
    /// This class contains Module wise menu permissions and the Companies which data a User is permitted to access Modulewise
    /// </summary>
    public class ModuleMenuCompany : SilkERP360.CCL.BusinessEntities.UI.Module
    {
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore> m_objLst_Companys;

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore> Companys
        {
            get { return this.m_objLst_Companys; }
            set { this.m_objLst_Companys = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.Menu> m_objLst_Menus;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.Menu> Menus
        {
            get { return this.m_objLst_Menus; }
            set { this.m_objLst_Menus = value; }
        }

        public ModuleMenuCompany()
            : base()
        {
            this.m_objLst_Menus = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.Menu>();
            this.m_objLst_Companys = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore>();
        }
    }
}
