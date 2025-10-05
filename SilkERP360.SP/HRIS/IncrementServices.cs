using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class IncrementServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public IncrementServices()
        {
            this.Initialize();
        }
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> GetIncrementListByEmployee(System.UInt64 IP_ui64_EmployeeCode)
        {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_objLst_IncrementList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> lcl_objLst_TmpIncrementList = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_DBQuery = System.String.Format(@"SELECT * FROM SALARY_INCREMENT WHERE EMPLOYEE_CODE = {0} ORDER BY EFFECTIVE_MONTH,EFFECTIVE_YEAR ASC",IP_ui64_EmployeeCode);
                    
                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new BML.HRIS.IncrementManager();
                    lcl_objLst_TmpIncrementList = lcl_obj_IncrementManager.GetList(lcl_str_DBQuery,lcl_obj_DBManager.InternalResource);
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_objLst_TmpIncrementList;
            }, "SPExceptionPolicy");
           return lcl_objLst_IncrementList;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.Increment SaveIncrement(SilkERP360.CCL.BusinessEntities.HRIS.Increment IP_obj_Increment)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new BML.HRIS.IncrementManager();
                    IP_obj_Increment.IncrementCode = lcl_obj_IncrementManager.Save(IP_obj_Increment,lcl_obj_DBManager.InternalResource);
                    /**********************************************************************************************************/
                    //Update Salary Structure
                    System.String lcl_str_SqlUpdate = System.String.Format("UPDATE EMPLOYEE_SALARY_STRUCTURE SET BASIC = {0}, HOUSE_RENT = {1},MEDICAL = {2},CONVEYENCE = {3},ENTERTAINMENT = {4}, GROSS = {5} WHERE EMPLOYEE_CODE = {6}", IP_obj_Increment.IncBasic, IP_obj_Increment.IncHouseRent, IP_obj_Increment.IncMedical, IP_obj_Increment.IncConveyence, IP_obj_Increment.IncEntertainment, IP_obj_Increment.IncGross, IP_obj_Increment.EmployeeCode);
                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlUpdate);
                    /**********************************************************************************************************/
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return IP_obj_Increment;
            }, "SPExceptionPolicy");
            return lcl_obj_Increment;
        }
    }
}

