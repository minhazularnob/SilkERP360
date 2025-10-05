using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.SCPM
{
    public class SCPersoFaultCardFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard>
    {
        public SCPersoFaultCardFacade()
        {
            this.Initialize();
        }
        public bool SaveSCFaultPersoCardList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScPersoFaultCard> IP_objLst_SCPersoFaultCardList)
        {
            System.Boolean lcl_b_Return = this.ExceptionManager.Process<System.Boolean>(()=>
                {
                    SilkERP360.BML.SCPM.ScPersoFaultCardManager lcl_obj_FaultyCardManager = new BML.SCPM.ScPersoFaultCardManager();
                    System.Boolean lcl_b_ReturnTmp = lcl_obj_FaultyCardManager.SaveSCPersoFaultCardList(IP_objLst_SCPersoFaultCardList);
                    return lcl_b_ReturnTmp;
                },"FLExceptionPolicy");
            return lcl_b_Return;    
        }
        public ulong Save(CCL.BusinessEntities.SCPM.ScPersoFaultCard IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScPersoFaultCard Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.ScPersoFaultCard Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.SCPM.ScPersoFaultCard> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.SCPM.ScPersoFaultCard IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
