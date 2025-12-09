using System;
using Oracle.ManagedDataAccess.Client;


namespace SilkERP360.DAL
{
    public enum TransactionState
    {
        Pending,
        Rolledback,
        Committed,
        Closed
    }
    public class DBManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase, IDisposable
    {
        #region Member Variables
        private SilkERP360.DAL.TransactionState m_TransactionState;
        private System.String m_str_ConnectionString;
        private OracleCommand m_obj_OracleCommand;
        private OracleConnection m_obj_OracleConnection;
        private OracleTransaction m_obj_OracleTransaction;
        private OracleDataReader m_obj_OracleDataReader;
        #endregion Member Variables

        #region Properties
        public SilkERP360.DAL.TransactionState TransactionState
        {
            get
            {
                return this.m_TransactionState;
            }
        }
        public System.String ConnectionString
        {
            get
            {
                return this.m_str_ConnectionString;
            }
        }
        public System.Data.ConnectionState ConnectionState
        {
            get
            {
                return this.m_obj_OracleConnection.State;
            }
        }
        public OracleCommand Command
        {
            get
            {
                return this.m_obj_OracleCommand;
            }
        }
        public OracleConnection Connection
        {
            get
            {
                return this.m_obj_OracleConnection;
            }
        }
        public OracleTransaction Transaction
        {
            get
            {
                return this.m_obj_OracleTransaction;
            }
        }
        public OracleDataReader DataReader
        {
            get
            {
                return this.m_obj_OracleDataReader;
            }
        }
        #endregion Properties

        #region Constructor
        public DBManager(System.String IP_str_ConnectionString)
        {
            this.Initialize();//ExceptionManagementBase method
            this.m_str_ConnectionString = IP_str_ConnectionString;
            this.m_obj_OracleCommand = null;
            this.m_obj_OracleConnection = new OracleConnection(IP_str_ConnectionString);
            this.m_obj_OracleDataReader = null;
            this.m_obj_OracleTransaction = null;
            this.m_TransactionState = SilkERP360.DAL.TransactionState.Closed;
        }
        #endregion Constructor

        #region Destructor
        public void Dispose()
        {
            if (this.m_obj_OracleDataReader != null)
            {
                if (!(this.m_obj_OracleDataReader.IsClosed))
                {
                    this.m_obj_OracleDataReader.Close();
                }
            }
            if (this.m_obj_OracleCommand != null)
            {
                this.m_obj_OracleCommand.Dispose();
                this.m_obj_OracleCommand = null;
            }
            if (this.m_obj_OracleConnection.State == System.Data.ConnectionState.Open)
            {
                this.m_obj_OracleConnection.Close();
            }

            if (this.m_obj_OracleConnection != null)
            {
                this.m_obj_OracleConnection.Dispose();
                this.m_obj_OracleConnection = null;
            }
        }
        #endregion Destructor

        #region Methods

        /// <summary>
        /// 1. Opens a connection to the database.
        /// 2. Creates Command Object from the opened Connection
        /// 3. Begins Transaction 
        /// </summary>
        /// <returns>void</returns>
        public void Open()
        {
            //THROWS Error 100
            this.ExceptionManager.Process(() =>
            {
                if (this.m_TransactionState == SilkERP360.DAL.TransactionState.Pending)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.DALException("A Transaction is in a pending state.Cannot open another connection without committing the transaction!!!");
                }
                if (this.m_obj_OracleConnection.State == System.Data.ConnectionState.Open)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.DALException("Cannot open an already opened Connection!!!");
                }
                if (!(this.m_obj_OracleConnection.State == System.Data.ConnectionState.Open))
                {
                    this.m_obj_OracleConnection.Open();
                }
                this.m_obj_OracleTransaction = this.m_obj_OracleConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                this.m_TransactionState = SilkERP360.DAL.TransactionState.Pending;
                this.m_obj_OracleCommand = this.m_obj_OracleConnection.CreateCommand();
                this.m_obj_OracleCommand.Transaction = this.m_obj_OracleTransaction;
            },
                                                    "DALExceptionPolicy");
        }

        /// <summary>
        /// Closes the Database Connection
        /// </summary>
        public void Close()
        {
            if (this.m_obj_OracleConnection != null)
            {
                if (this.m_obj_OracleConnection.State == System.Data.ConnectionState.Open)
                {
                    this.m_obj_OracleConnection.Close();
                    //this.m_obj_OracleConnection.Dispose();
                    //this.m_obj_OracleConnection = null;
                    this.m_TransactionState = SilkERP360.DAL.TransactionState.Closed;
                }
            }
        }

        public void CommitTransaction()
        {
            //throws 101
            this.ExceptionManager.Process(() =>
            {
                if (this.m_TransactionState == SilkERP360.DAL.TransactionState.Pending)
                {
                    this.m_obj_OracleTransaction.Commit();
                    this.m_TransactionState = SilkERP360.DAL.TransactionState.Committed;
                }
            },
                                                   "DALExceptionPolicy");
        }

        public void RollbackTransaction()
        {
            //throws 102
            this.ExceptionManager.Process(() =>
            {
                if (this.m_TransactionState == SilkERP360.DAL.TransactionState.Pending)
                {
                    this.m_obj_OracleTransaction.Rollback();
                    this.m_TransactionState = SilkERP360.DAL.TransactionState.Rolledback;
                }
            },
                                                        "DALExceptionPolicy");
        }

        /// <summary>
        /// Executes a query and returns the first column of the first row  in the result
        /// set as .net data type
        /// Examp: SQL ' "Select COUNT(*) FROM <TABLE>
        ///         Returns the count
        /// /// </summary>
        /// <param name="StrSql"></param>
        /// <returns>System.Object</returns>
        public System.Object ExecuteScalar(System.String SqlQuery)
        {
            System.Object returnObject = null;
            this.ExceptionManager.Process(() =>
            {
                try
                {
                    this.m_obj_OracleCommand.CommandType = System.Data.CommandType.Text;
                    this.m_obj_OracleCommand.CommandText = SqlQuery;
                    returnObject = this.m_obj_OracleCommand.ExecuteScalar();
                    this.m_obj_OracleCommand.Parameters.Clear();
                }
                catch (System.Exception Ex)
                {
                    throw Ex;
                }
            },
            "DALExceptionPolicy");
            return returnObject;
        }

        /// <summary>
        /// Executes the IP_strQuery and returns the number of rows affected
        /// </summary>
        /// <param name = "IP_strQuery" > Query to execute</param>
        /// <returns>Number of Rows affected by the query</returns>
        public System.Int32 ExecuteNonQuery(System.String IP_str_Query)
        {
            //throws Error.104
            System.Int32 rowsAffected = 0;
            this.ExceptionManager.Process(() =>
            {
                try
                {
                    this.m_obj_OracleCommand.CommandType = System.Data.CommandType.Text;
                    this.m_obj_OracleCommand.CommandText = IP_str_Query;
                    rowsAffected = this.m_obj_OracleCommand.ExecuteNonQuery();
                    this.m_obj_OracleCommand.Parameters.Clear();
                }
                catch (System.Exception Ex)
                {
                    throw Ex;
                }
            },
            "DALExceptionPolicy");
            return rowsAffected;
        }




        public System.Data.DataSet ExecuteDataSet(System.String SqlQuery)
        {
            //throws Error.105
            System.Data.DataSet ds = null;
            this.ExceptionManager.Process(() =>
            {
                ds = new System.Data.DataSet();
                System.Data.DataTable dt = new System.Data.DataTable();
                this.m_obj_OracleCommand.CommandType = System.Data.CommandType.Text;
                this.m_obj_OracleCommand.CommandText = SqlQuery;
                OracleDataAdapter dataAdapter = new OracleDataAdapter();
                dataAdapter.SelectCommand = this.m_obj_OracleCommand;
                dataAdapter.Fill(dt);
                ds.Tables.Add(dt);
                this.m_obj_OracleCommand.Parameters.Clear();
                dataAdapter.Dispose();
            },
            "DALExceptionPolicy");
            return ds;
        }

        public System.Data.DataSet ExecuteDataSet(System.String SqlSelect, System.String TableName)
        {
            //throws 106
            System.Data.DataSet ds = null;
            this.ExceptionManager.Process(() =>
            {
                using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
                {
                    this.m_obj_OracleCommand.CommandType = System.Data.CommandType.Text;
                    this.m_obj_OracleCommand.CommandText = SqlSelect;
                    dataAdapter.SelectCommand = this.m_obj_OracleCommand;
                    dataAdapter.Fill(ds, TableName);
                    this.m_obj_OracleCommand.Parameters.Clear();
                }
            },
            "DALExceptionPolicy");
            return ds;
        }


        public System.Data.DataSet ExecuteMultiQueryDataSet(System.String[] SqlQuery)
        {
            //throws Error.107
            System.Data.DataSet ds = null;
            this.ExceptionManager.Process(() =>
            {
                ds = new System.Data.DataSet();
                for (System.Int32 i = 0; i < SqlQuery.Length; i++)
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    this.m_obj_OracleCommand.CommandType = System.Data.CommandType.Text;
                    this.m_obj_OracleCommand.CommandText = SqlQuery[i];
                    OracleDataAdapter dataAdapter = new OracleDataAdapter();
                    dataAdapter.SelectCommand = this.m_obj_OracleCommand;
                    dataAdapter.Fill(dt);
                    ds.Tables.Add(dt);
                    this.m_obj_OracleCommand.Parameters.Clear();
                    dataAdapter.Dispose();
                }
            },
            "DALExceptionPolicy");
            return ds;
        }

        public System.Data.DataSet ExecuteMultiQueryDataSet(System.String[] SqlQuery, System.String[] TableName)
        {
            //throws Error.107
            System.Data.DataSet ds = null;

            this.ExceptionManager.Process(() =>
            {
                ds = new System.Data.DataSet();
                for (System.Int32 i = 0; i < SqlQuery.Length; i++)
                {
                    OracleDataAdapter dataAdapter = new OracleDataAdapter();
                    this.m_obj_OracleCommand.CommandType = System.Data.CommandType.Text;
                    this.m_obj_OracleCommand.CommandText = SqlQuery[i];
                    dataAdapter.SelectCommand = this.m_obj_OracleCommand;
                    dataAdapter.Fill(ds, TableName[i]);
                    this.m_obj_OracleCommand.Parameters.Clear();
                    dataAdapter.Dispose();
                }
            },
            "DALExceptionPolicy");
            return ds;
        }

        /// <summary>
        /// To be used while executing multiple stored procedures under one transaction
        /// </summary>
        /// <param name="SPName">Name of the stored procedure</param>
        /// <param name="SPParameters">SP Parameters</param>
        /// <param name="IP_objTransaction"></param>
        public void ExecuteStoredProcedure(System.String SPName, OracleParameter[] SPParameters)
        {
            //throws Error.108

            this.ExceptionManager.Process(() =>
            {
                try
                {
                    this.m_obj_OracleCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    this.m_obj_OracleCommand.CommandText = SPName;
                    this.m_obj_OracleCommand.Parameters.Clear();
                    this.m_obj_OracleCommand.Parameters.AddRange(SPParameters);
                    System.Int32 rowsAffected = this.m_obj_OracleCommand.ExecuteNonQuery();
                    this.m_obj_OracleCommand.Parameters.Clear();
                }
                catch (System.Exception Ex)
                {
                    int a = 0;
                }
            },
           "DALExceptionPolicy");
        }

        public OracleDataReader ExecuteDataReader(System.String SqlQuery)
        {
            //throws Error.109

            this.ExceptionManager.Process(() =>
            {
                try
                {
                    this.m_obj_OracleCommand.CommandType = System.Data.CommandType.Text;
                    this.m_obj_OracleCommand.CommandText = SqlQuery;
                    this.m_obj_OracleDataReader = this.m_obj_OracleCommand.ExecuteReader();
                }
                catch (System.Exception Ex)
                {
                    throw Ex;
                }

            },
            "DALExceptionPolicy");
            return this.m_obj_OracleDataReader;
        }

        public void CloseReader()
        {
            //throws Error.110

            this.ExceptionManager.Process(() =>
            {
                if (this.m_obj_OracleDataReader == null)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.DALException("The Oracle Data Reader has not been initiated!!!");
                }
                if (!(this.m_obj_OracleDataReader.IsClosed))
                {
                    this.m_obj_OracleDataReader.Close();
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.DALException("The Oracle Data Reader is already closed!!!");
                }
                //if (this.m_obj_OracleDataReader.IsClosed == false)
                //{
                //    this.m_obj_OracleDataReader.Close();
                //}
                this.m_obj_OracleDataReader.Close();
                this.m_obj_OracleDataReader = null;
            },
            "DALExceptionPolicy");
        }
        #endregion Methods
    }
}
