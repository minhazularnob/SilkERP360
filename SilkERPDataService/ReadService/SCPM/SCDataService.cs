using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
namespace SilkERPDataService.ReadService.SCPM
{
    public class SCDataService : System.IDisposable
    {
        private SilkERP360.DAL.DBManager _DBManager;
        public System.Data.OracleClient.OracleDataReader _OracleDataReader;
        public SCDataService(System.String IP_str_DBConnectionString)
        {
            this._DBManager = new SilkERP360.DAL.DBManager(IP_str_DBConnectionString);
            
        }
        public void Initialize()
        {
            try
            {
                this._DBManager.Initialize();
                this._DBManager.Open();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Data.OracleClient.OracleDataReader GetReader(System.String IP_str_SqlQuery)
        {
            try
            {
                _OracleDataReader = this._DBManager.ExecuteDataReader(IP_str_SqlQuery);
                return _OracleDataReader;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public void CloseReader()
        {

            if (this._OracleDataReader != null)
            {
                this._OracleDataReader.Close();
            }
        }
        public void Dispose()
        {
            if (this._OracleDataReader != null)
            {
                this._OracleDataReader.Close();
            }
            if (this._DBManager != null)
            {
                this._DBManager.Close();
            }
        }
    }
}
