using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class BonusServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        

        /// <summary>
        /// Gets all BonusMaster For Company
        /// </summary>
        /// <param name="IP_ui32_CompanyCode"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster> GetBonusMasterListByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster> lcl_objLst_BonusMasterList = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster>>(() =>
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster> lcl_obj_TmpBonusMasterList = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_Query = System.String.Format("SELECT * FROM BONUS_MASTER WHERE COMPANY_CODE = {0}", IP_ui64_CompanyCode);

                    SilkERP360.BML.HRIS.BonusMasterManager lcl_obj_BonusMasterManager = new SilkERP360.BML.HRIS.BonusMasterManager();
                    lcl_obj_TmpBonusMasterList = lcl_obj_BonusMasterManager.GetList(lcl_str_Query, lcl_obj_DBManager.InternalResource);

                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpBonusMasterList;
            }, "SPExceptionPolicy");
            return lcl_objLst_BonusMasterList;
        }


        /// <summary>
        /// Gets the BonusMaster with list of Bonus Object in BonusMaster.BonusList
        /// </summary>
        /// <param name="IP_ui64_BonusMasterCode"></param>
        /// <returns></returns>
        public SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster GetBonusMasterByBonusMasterCode(System.UInt64 IP_ui64_BonusMasterCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster>(() =>
            {
                SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_TmpBonusMaster = null;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_Query = System.String.Format("SELECT * FROM BONUS_MASTER WHERE BONUS_MASTER_CODE = {0}", IP_ui64_BonusMasterCode);

                    SilkERP360.BML.HRIS.BonusMasterManager lcl_obj_BonusMasterManager = new SilkERP360.BML.HRIS.BonusMasterManager();
                    lcl_obj_TmpBonusMaster = lcl_obj_BonusMasterManager.Get(IP_ui64_BonusMasterCode, lcl_obj_DBManager.InternalResource);

                    lcl_obj_DBManager.InternalResource.Close();
                }
                return lcl_obj_TmpBonusMaster;
            }, "SPExceptionPolicy");
            return lcl_obj_BonusMaster;
        }
    }
}
