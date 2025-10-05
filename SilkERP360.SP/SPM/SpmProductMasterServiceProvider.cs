using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.SPM
{
    public class SpmProductMasterServiceProvider : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SpmProductMasterServiceProvider()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster> GetProductMasterListByCustomer(System.UInt64 IP_ui64_CustomerCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster> lcl_objLst_SpmProductMaster = null;
            lcl_objLst_SpmProductMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster>>(() =>
            {
                
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_DBQuery = System.String.Format("SELECT * FROM SPM_PRODUCT_MASTER WHERE CUSTOMER_CODE = {0}", IP_ui64_CustomerCode);
                    SilkERP360.BML.SPM.SpmProductMasterManager lcl_obj_SpmProductMasterManager = new BML.SPM.SpmProductMasterManager();
                    lcl_obj_SpmProductMasterManager.Initialize();
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster> lcl_objLst_SpmProductMasterTmp = lcl_obj_SpmProductMasterManager.GetList(lcl_str_DBQuery, lcl_obj_DBManager.InternalResource);
                    return lcl_objLst_SpmProductMasterTmp;
                }
            }, "SPExceptionPolicy");
            return lcl_objLst_SpmProductMaster;
        }
    }
}
