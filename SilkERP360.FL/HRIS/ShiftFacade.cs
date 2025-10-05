using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class ShiftFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
          SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Shift>
    {
        public ShiftFacade()
        {
            this.Initialize();
        }


        public System.UInt64 SaveShift(SilkERP360.CCL.BusinessEntities.HRIS.Shift IP_Obj_Shift)
        {
            System.UInt64 lcl_ui64_ShiftCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.ShiftManager lcl_obj_ShiftManager = new BML.HRIS.ShiftManager();
                System.UInt64 lcl_ui64_ShiftCodeTmp = lcl_obj_ShiftManager.Save(IP_Obj_Shift);
                return lcl_ui64_ShiftCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_ShiftCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Shift IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Shift Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Shift Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Shift> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.HRIS.Shift IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
