using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
    public class CurrencyFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.Currency>
    {
        public CurrencyFacade()
        {
        
        }

        public ulong Save(CCL.BusinessEntities.WPMS.Currency IP_obj_CurrencyManger)
        {
            System.UInt64 lcl_ui64_BuyerCode = 0;
            {
                SilkERP360.BML.WPMS.CurrencyManger lcl_obj_CurrencyManger = new BML.WPMS.CurrencyManger();
                System.UInt64 lcl_ui64_BuyerCodeTmp = lcl_obj_CurrencyManger.Save(IP_obj_CurrencyManger);
                return lcl_ui64_BuyerCodeTmp;
            }
            return lcl_ui64_BuyerCode;
        }

        public CCL.BusinessEntities.WPMS.Currency Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.Currency Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.Currency> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.WPMS.Currency IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
