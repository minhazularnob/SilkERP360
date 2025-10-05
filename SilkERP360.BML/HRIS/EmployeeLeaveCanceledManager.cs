using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeLeaveCanceledManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled>
    {
        public EmployeeLeaveCanceledManager()
        {
            this.Initialize();
        }



        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled IP_obj_EmployeeLeaveCanceled, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_LeaveCancelCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.String lcl_str_SqlInsert = IP_obj_EmployeeLeaveCanceled.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return IP_obj_EmployeeLeaveCanceled.LeaveApplicationCode;
            }, "BMLExceptionPolicy");
            return lcl_ui64_LeaveCancelCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeLeaveCanceled> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
