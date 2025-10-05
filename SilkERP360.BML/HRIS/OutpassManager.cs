using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class OutpassManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Outpass>
    {
        public OutpassManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Outpass IP_obj_Outpass, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Outpass IP_obj_Outpass)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Outpass Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Outpass Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Outpass Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Outpass Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Outpass> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Outpass> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
