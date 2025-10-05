using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.WPMS
{
    public class SalesContractFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>
    {
        public SalesContractFacade()
        { 
        
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.WPMS.SalesContract IP_obj_SalesContract)
        {
            System.UInt64 lcl_ui64_SalesContractCode = 0;
            {
                SilkERP360.BML.WPMS.SalesContractManager lcl_obj_SalesContractManager = new BML.WPMS.SalesContractManager();
                System.UInt64 lcl_ui64_SalesContractCodeTmp = lcl_obj_SalesContractManager.Save(IP_obj_SalesContract);
                return lcl_ui64_SalesContractCodeTmp;

                return lcl_ui64_SalesContractCode;
            }
        }

        public CCL.BusinessEntities.WPMS.SalesContract Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract = null;
            lcl_obj_SalesContract = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>(() =>
            {
                SilkERP360.BML.WPMS.SalesContractManager lcl_obj_SalesContractManager = new SilkERP360.BML.WPMS.SalesContractManager();
                SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = lcl_obj_SalesContractManager.Get(IP_ui64_Code);
                return lcl_obj_SalesContractTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_SalesContract;
        }

        public CCL.BusinessEntities.WPMS.SalesContract Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContract = null;
            lcl_obj_SalesContract = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>(() =>
            {
                SilkERP360.BML.WPMS.SalesContractManager lcl_obj_SalesContractManager = new SilkERP360.BML.WPMS.SalesContractManager();
                SilkERP360.CCL.BusinessEntities.WPMS.SalesContract lcl_obj_SalesContractTmp = lcl_obj_SalesContractManager.Get(IP_str_SqlQuery);
                return lcl_obj_SalesContractTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_SalesContract;
        }

        public List<CCL.BusinessEntities.WPMS.SalesContract> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract> lcl_obj_SalesContract = null;
            lcl_obj_SalesContract = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract>>(() =>
            {
                SilkERP360.BML.WPMS.SalesContractManager lcl_obj_SalesContractManager = new SilkERP360.BML.WPMS.SalesContractManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContract> SalesContractTmp =
                    lcl_obj_SalesContractManager.GetList(IP_str_SqlQuery);
                return SalesContractTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_SalesContract;
        }

        public int Update(CCL.BusinessEntities.WPMS.SalesContract IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            System.Int32 lcl_i32_RowsUpdated = this.ExceptionManager.Process<System.Int32>(() =>
            {
                System.Int32 lcl_i32_RowsUpdatedTmp = 0;
                SilkERP360.BML.SqlManager lcl_obj_SqlManager = new SilkERP360.BML.SqlManager();
                System.Object lcl_obj_Response = lcl_obj_SqlManager.ExecuteScaler(IP_str_SqlUpdateQuery);
                lcl_obj_SqlManager.Close();
                lcl_i32_RowsUpdatedTmp = System.Int32.Parse(lcl_obj_Response.ToString());
                return lcl_i32_RowsUpdatedTmp;
            }, "FLExceptionPolicy");
            return lcl_i32_RowsUpdated;
        }
    }
}
