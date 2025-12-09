using System.Collections.Generic;

namespace SilkERP360.BML.WPMS
{
   public class SalesContractDetailsManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails>
    {
       public SalesContractDetailsManager()
       {
           this.Initialize();
       }

       public ulong Save(CCL.BusinessEntities.WPMS.SalesContractDetails lcl_obj_SalesContractDetails, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_SalesContractDetailsCode = 0;
           System.String lcl_str_Sequence = lcl_obj_SalesContractDetails.GetSequence();
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
           lcl_ui64_SalesContractDetailsCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               lcl_obj_SalesContractDetails.SalesContractDetailsCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = lcl_obj_SalesContractDetails.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
               lcl_obj_DBManager.CommitTransaction();
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_SalesContractDetailsCode;

        }


        public ulong Save(CCL.BusinessEntities.WPMS.SalesContractDetails IP_obj_A)
        {
            throw new System.NotImplementedException();
        }


        public CCL.BusinessEntities.WPMS.SalesContractDetails Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new System.NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.SalesContractDetails Get(ulong IP_ui64_Code)
        {
            throw new System.NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.SalesContractDetails Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new System.NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.SalesContractDetails Get(string IP_str_SqlQuery)
        {
            throw new System.NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.SalesContractDetails> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new System.NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.SalesContractDetails> GetList(string IP_str_SqlQuery)
        {
            throw new System.NotImplementedException();
        }
    }
}

