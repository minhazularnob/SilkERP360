using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.Services.SCPM
{
    public class ScratchCardServices : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public ScratchCardServices()
        {
            this.Initialize();
        }

        //public CCL.BusinessEntities.SCPM.ScpmProductMaster GetProductDetailsByJobOrderItemCode(System.UInt64 IP_ui64_SCJobOrderItemCode, DAL.DBManager IP_obj_DBmanager)
        //{
        //    CCL.BusinessEntities.SCPM.ScpmProductMaster lcl_obj_ScpmProductMaster = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmProductMaster>(() =>
        //    {
        //        if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
        //        {
        //            IP_obj_DBmanager.Open();
        //        }
        //        System.String lcl_str_SqlQuery = System.String.Format(@"SELECT SPM.* FROM SCPM_PRODUCT_MASTER SPM JOIN SCPM_SC_JOB_ORDER_ITEM SSJOI ON SPM.PRODUCT_CODE = SSJOI.PRODUCT_CODE WHERE SSJOI.SC_JO_ITEM_CODE = {0}",IP_ui64_SCJobOrderItemCode);
        //        BML.SCPM.ScpmProductMasterManager lcl_obj_ScpmProductMasterManager = new BML.SCPM.ScpmProductMasterManager();
        //        lcl_obj_ScpmProductMasterManager.Initialize();
        //        CCL.BusinessEntities.SCPM.ScpmProductMaster lcl_obj_TmpScpmProductMaster = lcl_obj_ScpmProductMasterManager.Get(lcl_str_SqlQuery, IP_obj_DBmanager);
        //        return lcl_obj_TmpScpmProductMaster;
        //    }, "BMLExceptionPolicy");
        //    return lcl_obj_ScpmProductMaster;
        //}

        /// <summary>
        /// Will Upload Data in SCPM_SC_DATA_REPOSITORY
        /// Pre-Condition :
        /// 1. IP_obj_ScpmScDataRepository fields are initialized: SCPM_PO_CODE/SCPM_PO_ITEM_CODE/SC_JO_CODE/SC_JO_ITEM_CODE/BATCH_NAME,START_SERIAL/
        /// END_SERIAL
        /// 2. IP_obj_DBManager is initialized
        /// Functionality:
        /// 1. Figureout following field before inserting IP_obj_ScpmScDataRepository : BATCH_NO/QUANTITY/PACKAGED_BOX_SL_START/PACKAGED_BOX_SL_END
        /// 2. create ScpmScPackagedBox instance list
        /// 3. Create ScpmScCards and ScpmScPin instances
        /// VALIDATIONS:
        /// 1. Combined quantity of all ScpmScDataRepository.Quantity for SC_JO_ITEM_CODE must not exceed ScpmScJobOrderItem.Quantity
        /// 
        /// Flow-Of-Events :
        /// 1. Get SCPM_PRODUCT_MASTER for SC_JO_ITEM_CODE
        /// 2. Get ScpmScJobOrderItem for IP_obj_ScpmScDataRepository.ScJOItemCode
        /// 2. Get All Previous instance of SCPM_SC_DATA_REPOSITORY (ORDER BY BATCH_NO ASC) for the provided SCPM_PO_CODE/SCPM_PO_ITEM_CODE/SC_JO_CODE/SC_JO_ITEM_CODE
        /// if Previous instance exists -> Get last instance of the list
        /// then
        ///     this.BATCH_NO = Last instance of SCPM_SC_DATA_REPOSITORY.BATCH_NO + 1
        ///     this.PACKAGED_BOX_SL_START = Last instance of SCPM_SC_DATA_REPOSITORY.PACKAGED_BOX_SL_END + 1
        ///     this.PACKAGED_BOX_SL_END = this.QUANTITY / ScpmScJobOrderItem.OuterBox
        /// 3. 
        /// </summary>
        /// <param name="IP_obj_ScpmScDataRepository"></param>
        /// <param name="IP_obj_DBmanager"></param>
        /// <returns></returns>
        public CCL.Misc.WSResponse UploadSCDataToRepository(CCL.BusinessEntities.SCPM.ScpmScDataRepository IP_obj_ScpmScDataRepository, DAL.DBManager IP_obj_DBmanager)
        {
            throw new NotImplementedException();
            //CCL.Misc.WSResponse lcl_obj_WSResponse = this.ExceptionManager.Process<CCL.Misc.WSResponse>(() =>
            //{
            //    if (IP_obj_DBmanager.ConnectionState != System.Data.ConnectionState.Open)
            //    {
            //        IP_obj_DBmanager.Open();
            //    }
            //    System.String lcl_str_SqlQuery = System.String.Format(@"SELECT SPM.* FROM SCPM_PRODUCT_MASTER SPM JOIN SCPM_SC_JOB_ORDER_ITEM SSJOI ON SPM.PRODUCT_CODE = SSJOI.PRODUCT_CODE WHERE SSJOI.SC_JO_ITEM_CODE = {0}", IP_ui64_SCJobOrderItemCode);
            //    BML.SCPM.ScpmProductMasterManager lcl_obj_ScpmProductMasterManager = new BML.SCPM.ScpmProductMasterManager();
            //    lcl_obj_ScpmProductMasterManager.Initialize();
            //    CCL.BusinessEntities.SCPM.ScpmProductMaster lcl_obj_TmpScpmProductMaster = lcl_obj_ScpmProductMasterManager.Get(lcl_str_SqlQuery, IP_obj_DBmanager);
            //    //return lcl_obj_TmpScpmProductMaster;
            //}, "BMLExceptionPolicy");
            //return lcl_obj_WSResponse;
        }
    }
}
