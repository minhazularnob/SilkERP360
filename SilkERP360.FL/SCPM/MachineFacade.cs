using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SilkERP360.FL.SCPM
{
    public class MachineFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine>
        
    {
        public MachineFacade()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.SCPM.SCPMMachine IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.SCPMMachine Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.SCPMMachine Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.SCPM.SCPMMachine> GetList(string IP_str_SqlQuery)
        {
            List<CCL.BusinessEntities.SCPM.SCPMMachine> lcl_objLst_SCPMMachine = this.ExceptionManager.Process<List<CCL.BusinessEntities.SCPM.SCPMMachine>>(() =>
            {
                
                SilkERP360.BML.SCPM.MachineManger lcl_obj_MachineManager = new SilkERP360.BML.SCPM.MachineManger();
                List<CCL.BusinessEntities.SCPM.SCPMMachine> lcl_objLst_SCPMMachineTmp = lcl_obj_MachineManager.GetList(IP_str_SqlQuery);
                return lcl_objLst_SCPMMachineTmp;
            }, "FLExceptionPolicy");
            return lcl_objLst_SCPMMachine;  
        }

        public int Update(CCL.BusinessEntities.SCPM.SCPMMachine IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }

       
    }
}
