using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class EmployeeFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Employee>
    {
        public EmployeeFacade()
        {
            this.Initialize();
        }

        

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage GetEmployeeImageFromCode(System.UInt64 IP_ui64_EmployeeCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImageCore = null;
            lcl_obj_EmployeeImageCore = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage>(() =>
            {
                SilkERP360.BML.HRIS.EmployeeManager lcl_obj_EmployeeManager = new SilkERP360.BML.HRIS.EmployeeManager();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImageCoreTmp = lcl_obj_EmployeeManager.GetEmployeeImageFromCode(IP_ui64_EmployeeCode);
                return lcl_obj_EmployeeImageCoreTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_EmployeeImageCore; 
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeStatusHistory IP_obj_EmployeeStatusHistory)
        {
            System.UInt64 lcl_ui64_EmployeeStatusCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.employeeStatusHistoryManager lcl_obj_employeeStatusHistoryManager = new BML.HRIS.employeeStatusHistoryManager();
                System.UInt64 lcl_ui64_EmployeeStatusCodeTemp = lcl_obj_employeeStatusHistoryManager.Save(IP_obj_EmployeeStatusHistory);
                return lcl_ui64_EmployeeStatusCodeTemp;
            }, "FLExceptionPolicy");
            return lcl_ui64_EmployeeStatusCode;
        }




        public ulong Save(CCL.BusinessEntities.HRIS.Employee IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Employee Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Employee Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Employee> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.HRIS.Employee IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
