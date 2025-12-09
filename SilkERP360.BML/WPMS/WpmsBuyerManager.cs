using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class WpmsBuyerManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.WpmsBuyer>
    {
        public ulong Save(CCL.BusinessEntities.WPMS.WpmsBuyer IP_obj_A, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_BuyerCode = 0;
            System.String lcl_str_Sequence = IP_obj_A.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_BuyerCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_A.BuyerCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_BuyerCode;
        }

        public ulong Save(CCL.BusinessEntities.WPMS.WpmsBuyer IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.WpmsBuyer Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.WpmsBuyer Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.WpmsBuyer Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.WpmsBuyer Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.WpmsBuyer> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.WpmsBuyer> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
