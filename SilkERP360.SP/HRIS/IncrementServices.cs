using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Enums;
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
                    System.String lcl_str_DBQuery = System.String.Format(@"SELECT INCREMENT_CODE, EMPLOYEE_CODE, INCREMENT_DATE, PREVIOUS_GROSS, INC_BASIC, INC_HOURSE_RENT, INC_CONVEYENCE, INC_MEDICAL, INC_ENTERTAINMENT, INC_GROSS, ENTRY_DATE, ENTRY_EMPLOYEE_CODE, EFFECTIVE_MONTH, EFFECTIVE_YEAR, {1}  AS IS_APPROVED
                                                                            FROM SALARY_INCREMENT WHERE EMPLOYEE_CODE = {0}
                                                                            UNION ALL
                                                                            SELECT INCREMENT_CODE, EMPLOYEE_CODE, INCREMENT_DATE, PREVIOUS_GROSS, INC_BASIC, INC_HOURSE_RENT, INC_CONVEYENCE, INC_MEDICAL, INC_ENTERTAINMENT, INC_GROSS, ENTRY_DATE, ENTRY_EMPLOYEE_CODE, EFFECTIVE_MONTH, EFFECTIVE_YEAR, is_approved
                                                                            FROM salary_increment_request
                                                                            WHERE EMPLOYEE_CODE = {0}
                                                                            ORDER BY EFFECTIVE_YEAR, EFFECTIVE_MONTH ASC", IP_ui64_EmployeeCode,(int)PromotionStatus.Approved);

                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new BML.HRIS.IncrementManager();
                    lcl_objLst_TmpIncrementList = lcl_obj_IncrementManager.GetList(lcl_str_DBQuery, lcl_obj_DBManager.InternalResource);
                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_objLst_TmpIncrementList;
            }, "SPExceptionPolicy");
            return lcl_objLst_IncrementList;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.IncrementRequest SaveIncrement(SilkERP360.CCL.BusinessEntities.HRIS.IncrementRequest IP_obj_Increment, List<ApproverDetail> IP_obj_ApproverDetails)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.IncrementRequest lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.IncrementRequest>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    SilkERP360.BML.HRIS.IncrementManager lcl_obj_IncrementManager = new BML.HRIS.IncrementManager();
                    IP_obj_Increment.IncrementCode = lcl_obj_IncrementManager.Save(IP_obj_Increment, lcl_obj_DBManager.InternalResource, IP_obj_ApproverDetails);
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

