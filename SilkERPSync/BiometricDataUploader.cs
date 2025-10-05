using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;


namespace SilkERPSync
{
    /// <summary>
    /// Runs Every 10 min
    /// </summary>
    public class BiometricDataUploader
    {
        /****************************************************************************************************/
        //DUE TO BIO_METRIC SERVER CHANGE.
        private const System.UInt64 BMS_TRANSACTION_START = 5985021;
        private const System.UInt64 BMS_REPOSITORY_START = 5967135;
        /****************************************************************************************************/
        private static System.DateTime m_dt_LastExecutionDateTime = System.DateTime.MinValue;
        public static System.DateTime LastExecutionDateTime
        {
            get { return BiometricDataUploader.m_dt_LastExecutionDateTime; }
            set { BiometricDataUploader.m_dt_LastExecutionDateTime = value; }
        }


        private System.String BIOMETRIC_DATA_SERVER_CONNECTION_STRING = @"Data Source=192.168.48.5, 1433;Initial Catalog=CCFTCentral;Uid=sa;Password=Asdf@12345678;Encrypt=No;TrustServerCertificate=Yes;";
        //private System.String BIOMETRIC_DATA_SERVER_CONNECTION_STRING = @"Data Source=192.168.48.5;Initial Catalog=CCFTCentral;Integrated Security=true;TrustServerCertificate=Yes;";
        // private System.String SILKERP_DATA_SERVER_CONNECTION_STRING = "";// @"Data Source=db; User Id=silkerp; Password=silkerp;";
        private System.Data.DataTable m_obj_BiometricDataTable;

        private SilkERP360.DAL.DBManager m_obj_DBManager = null;
        //private ServiceLog m_obj_ServiceLog;

        /// <summary>
        /// Pre-Condition: IP_obj_DBManager is initialized & opened
        /// </summary>
        /// <param name="IP_obj_DBManager"></param>
        public void Init(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            //this.m_obj_ServiceLog = new ServiceLog();
            //t/his.m_obj_ServiceLog.Init(ServiceLogType.BiometricDataUploader);
            try
            {
                //this.BIOMETRIC_DATA_SERVER_CONNECTION_STRING = IP_str_DatabaseConnectionStringBiometric;
                //this.SILKERP_DATA_SERVER_CONNECTION_STRING = IP_str_DatabaseConnectionStringSilkERPDB;
                this.m_obj_DBManager = IP_obj_DBManager;
                this.m_obj_BiometricDataTable = new System.Data.DataTable();
            }
            catch (System.Exception Ex)
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Initialization Error : " + Ex.Message);
            }
        }

        public BiometricDataUploader()
        {

        }

        //public void ReadAndUpload(System.String IP_str_CSVFile)
        //{
            

        //}
        public void ReadAndUpload()
        {
            System.Data.SqlClient.SqlConnection lcl_obj_BiometricDBConnection = null;
            System.Data.SqlClient.SqlDataAdapter lcl_obj_BiometricDBAdapter = null;
            System.Text.StringBuilder lcl_sb_LogBuilder = null;
            System.Collections.Generic.List<System.String> lcl_objLst_SilkERPInsert = null;
            try
            {
                lcl_sb_LogBuilder = new StringBuilder();
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                lcl_sb_LogBuilder.AppendLine("Biometric Data Synchronization-" + System.DateTime.Now.ToString());
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                System.UInt64 lcl_ui64_MaxCode = 0;
                //System.Data.OracleClient.OracleConnection lcl_obj_SilkERPDatabaseConnection = new System.Data.OracleClient.OracleConnection(BiometricDataUploader.SILKERP_DATA_SERVER_CONNECTION_STRING);
                //lcl_obj_SilkERPDatabaseConnection.Open();
                //this.m_obj_DBManager.Open();
                System.String lcl_str_SilkERPQuery = System.String.Format("SELECT MAX(BMS_TRAN_CODE) FROM BMS_TRANSACTION");
                System.Object lcl_obj_MaxCode = this.m_obj_DBManager.ExecuteScalar(lcl_str_SilkERPQuery);
                if (lcl_obj_MaxCode.ToString() == "")
                {
                    lcl_ui64_MaxCode = 0;
                }
                else
                {
                    lcl_ui64_MaxCode = System.UInt64.Parse(lcl_obj_MaxCode.ToString());
                }

                /**************************************************************************************************************/
                //Adjust Max Code
                lcl_ui64_MaxCode = lcl_ui64_MaxCode - BMS_TRANSACTION_START;
                /**************************************************************************************************************/

                lcl_sb_LogBuilder.AppendLine("Maximum BMS_TRAN_CODE retrieved from SilkERP.BMS_TRANSACTION Database!!!");

                System.String lcl_str_BiometricDBQuery = @"SELECT Employee_ID,convert(varchar,Ttime,106)+' '+convert(varchar,Ttime,108)Ttime,XX,Device_ID,Device_ID_Name,Timelog_ID From (SELECT 
            	CCFTCentral..PersonalDataString.Value as 'Employee_ID',
            	DateAdd(HH,06,CCFTEvent..Event.OccurrenceTime) as 'Ttime', 
            	
            	-- Determine if it is an entry or exit event
            	Case Event.eventtype
            		When 20001 Then '1'			-- This is the EventType which represents an Entry
            		When 20091 Then '1'			-- This is another EventType which represents an Entry
            	Else '2' End XX,					-- The EventType for Exit is '20003'
            	
            	Door.ID as 'Device_ID',			-- ID of the Door. This is internally assigned by Command Centre.
            	Door.Name as 'Device_ID_Name',	-- Name of the Door
            	
            	CCFTEvent..Event.ID as 'Timelog_ID'
            	
            	-- Optional fields
            	-------------------
            	-- Cardholder.Name, 
            	-- CCFTEvent..Event.EventType, 
            	-- CCFTEvent..Event.Message	
                  
            FROM 
            	CCFTEvent..Event 
            	
            -- Get the Cardholder name
            JOIN
            	CCFTEvent..RelatedItems as CardholderRelation
            ON
            	CardholderRelation.EventID = Event.ID and CardholderRelation.RelationCode = 0
            JOIN
            	CCFTCentral..FTItem as Cardholder
            ON
            	Cardholder.ID = CardholderRelation.FTItemID
            
            
            -- Get the Personal Data Field Value
            JOIN
            	CCFTCentral..PersonalDataString 
            ON
            	Cardholder.ID = CCFTCentral..PersonalDataString.CardholderID 	
            
            	
            -- Get the Door name
            JOIN
            	CCFTEvent..RelatedItems as DoorRelation
            ON
            	DoorRelation.EventID = Event.ID and DoorRelation.RelationCode = 2
            JOIN
            	CCFTCentral..FTItem as Door
            ON
            	Door.ID = DoorRelation.FTItemID
            	
            WHERE
              (ccftevent..Event.eventtype = '20001' OR ccftevent..Event.eventtype = '200091' OR ccftevent..Event.eventtype = '20002'  OR ccftevent..Event.eventtype = '20003' OR ccftevent..Event.eventtype = '20004' OR ccftevent..Event.eventtype = '20006' OR ccftevent..Event.eventtype = '20007')
            AND CCFTCentral..PersonalDataString.VAlUE<>' '	-- Change this to suit the ID in your system.
           -- AND
           	--DateAdd(HH,06,CCFTEvent..Event.OccurrenceTime)
         --BETWEEN cast(convert(varchar,getdate(),101) as datetime)+'01/01/1900 00:00:01' AND cast(convert(varchar,getdate(),101) as datetime)+'01/01/1900 23:59:01'
            AND 
            CCFTEvent..Event.ID>" + lcl_ui64_MaxCode + @"
            and Event.eventtype in(20001,200091,20002,20003,20004,20006,20007))X
            ORDER BY Timelog_ID";

                /*************************************************************************************************************/
                //lcl_str_BiometricDBQuery = System.String.Format("SELECT * FROM EVENTTYPE");

                /*************************************************************************************************************/
                lcl_objLst_SilkERPInsert = new List<string>();

                lcl_sb_LogBuilder.AppendLine("Connecting with Biometric Data Server...");
                lcl_obj_BiometricDBConnection = new SqlConnection(BIOMETRIC_DATA_SERVER_CONNECTION_STRING);
                lcl_obj_BiometricDBConnection.Open();
                lcl_sb_LogBuilder.AppendLine("Successfully Connected To Biometric Data Server!!!");
                lcl_obj_BiometricDBAdapter = new SqlDataAdapter(lcl_str_BiometricDBQuery, lcl_obj_BiometricDBConnection);
                lcl_sb_LogBuilder.AppendLine("Fetching Data From Biometric Database Server...");
                lcl_obj_BiometricDBAdapter.Fill(this.m_obj_BiometricDataTable);
                lcl_sb_LogBuilder.AppendLine("Biometric Data Fetched Successfully!!!");
                lcl_obj_BiometricDBConnection.Close();
                /***************************************************************************************************************/
                //for (int j = 0; j < this.m_obj_BiometricDataTable.Rows.Count; j++)
                //{
                //    lcl_sb_LogBuilder.AppendLine("ID : " + this.m_obj_BiometricDataTable.Rows[j]["ID"].ToString());
                //    lcl_sb_LogBuilder.AppendLine("NAME : " + this.m_obj_BiometricDataTable.Rows[j]["NAME"].ToString());
                //}
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                //this.m_obj_ServiceLog.Close();
                /***************************************************************************************************************/
                lcl_sb_LogBuilder.AppendLine("Biometric Database Server Disconnected Successfully!!!");
                System.Text.StringBuilder lcl_obj_SqlInsertBuilder = new StringBuilder();
                System.String lcl_str_SqlInsert = System.String.Empty;
                System.UInt64 lcl_ui64_BMS_TRAN_CODE = 0;
                for (int i = 0; i < this.m_obj_BiometricDataTable.Rows.Count; i++)
                {
                    lcl_ui64_BMS_TRAN_CODE = BMS_TRANSACTION_START + System.UInt64.Parse(this.m_obj_BiometricDataTable.Rows[i][5].ToString());
                    //string fg = this.m_obj_BiometricDataTable.Rows[i][0].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][1].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][2].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][3].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][4].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][5].ToString();
                    lcl_str_SqlInsert = "INSERT INTO BMS_TRANSACTION(BMS_TRAN_CODE,EMPLOYEE_ID,READER_CODE,TRAN_DATE_TIME,READER_NAME) Values(" + lcl_ui64_BMS_TRAN_CODE + ", '" + this.m_obj_BiometricDataTable.Rows[i][0].ToString() + "', '" + this.m_obj_BiometricDataTable.Rows[i][3].ToString() + "',  to_date('" + this.m_obj_BiometricDataTable.Rows[i][1].ToString() + "', 'dd-mon-yyyy hh24:mi:ss'),'" + this.m_obj_BiometricDataTable.Rows[i][4].ToString() + "')";
                    //lcl_obj_SqlInsertBuilder.Append("INSERT INTO BMS_TRANSACTION(BMS_TRAN_CODE,EMPLOYEE_ID,READER_CODE,TRAN_DATE_TIME,READER_NAME) Values(" + lcl_ui64_BMS_TRAN_CODE + ", '" + this.m_obj_BiometricDataTable.Rows[i][0].ToString() + "', '" + this.m_obj_BiometricDataTable.Rows[i][3].ToString() + "',  to_date('" + this.m_obj_BiometricDataTable.Rows[i][1].ToString() + "', 'dd-mon-yyyy hh24:mi:ss'),'" + this.m_obj_BiometricDataTable.Rows[i][4].ToString() + "')");
                    this.m_obj_DBManager.ExecuteNonQuery(lcl_str_SqlInsert);
                    //lcl_objLst_SilkERPInsert.Add(lcl_obj_SqlInsertBuilder.ToString());
                    lcl_obj_SqlInsertBuilder.Length = 0;
                }
                lcl_sb_LogBuilder.AppendLine("Insert Queries Generated For SilkERP.BMS_TRANSACTION input!!!");
                //Insert BMS TRANSACTION IN SILKERP DATABASE
                lcl_sb_LogBuilder.AppendLine("Saving Biometric Transaction Data to SilkERP.BMS_TRANSACTION Database...");
                //System.Data.OracleClient.OracleTransaction lcl_obj_SilkERPTransaction = lcl_obj_SilkERPDatabaseConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                foreach (System.String lcl_str_BMSInsert in lcl_objLst_SilkERPInsert)
                {
                    //Console.WriteLine(lcl_str_BMSInsert);
                    //this.m_obj_DBManager.ExecuteNonQuery(lcl_str_BMSInsert);
                }

                lcl_sb_LogBuilder.AppendLine("Number Of BMS_TRANSACTION Uploaded : " + this.m_obj_BiometricDataTable.Rows.Count.ToString());
                lcl_sb_LogBuilder.AppendLine("Biometric Transaction Data Uploaded Successfully in SilkERP.BMS_TRANSACTION Database!!!");
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
               // this.m_obj_ServiceLog.Close();

                //int a = 0;

            }
            catch (System.Exception Ex)
            {
                if (lcl_obj_BiometricDBConnection != null)
                {
                    if (lcl_obj_BiometricDBConnection.State == System.Data.ConnectionState.Open)
                    {
                        lcl_obj_BiometricDBConnection.Close();
                    }
                }
                if (this.m_obj_DBManager != null)
                {
                    if (this.m_obj_DBManager.ConnectionState == System.Data.ConnectionState.Open)
                    {
                        this.m_obj_DBManager.RollbackTransaction();
                        this.m_obj_DBManager.Close();
                    }
                }
                SilkERP360.SP.HRIS.ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " => Critical Error : " + Ex.Message);
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " => Biometric Data Could Not Be fetched!!!");
               // this.m_obj_ServiceLog.Close();
            }
        }

        public void SynchronizeBiometricRepository(System.String IP_str_CSVFile)
        {
            System.Collections.Generic.List<System.String> lcl_objLst_SilkERPInsert = new List<string>();
            System.String[] lcl_strArr_BiometricDataLines = System.IO.File.ReadAllLines(IP_str_CSVFile);

            System.Text.StringBuilder lcl_obj_SqlInsertBuilder = new StringBuilder();
            System.DateTime lcl_dt_Now = System.DateTime.Now;
            
            //for (int i = 0; i < this.m_obj_BiometricDataTable.Rows.Count; i++)
            //{
            //    /**********************************************************************************************************/
            //    //Reject Any Transaction which is not older than 06 hours
            //    System.DateTime lcl_dt_TransactionDateTime = System.DateTime.Parse(this.m_obj_BiometricDataTable.Rows[i][1].ToString());
            //    System.TimeSpan lcl_ts_HoursDofference = lcl_dt_Now.Subtract(lcl_dt_TransactionDateTime);
            //    if (lcl_ts_HoursDofference.TotalHours < 3.0)
            //    {
            //        continue;
            //    }
            //    /**********************************************************************************************************/
            //    lcl_ui64_BMS_REPO_CODE = BMS_REPOSITORY_START + System.UInt64.Parse(this.m_obj_BiometricDataTable.Rows[i][5].ToString());

            //    string fg = this.m_obj_BiometricDataTable.Rows[i][0].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][1].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][2].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][3].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][4].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][5].ToString();
            //    lcl_obj_SqlInsertBuilder.Append("INSERT INTO BMS_REPOSITORY(BMS_TRAN_CODE,EMPLOYEE_ID,READER_CODE,TRAN_DATE_TIME,READER_NAME) Values(" + lcl_ui64_BMS_REPO_CODE + ", '" + this.m_obj_BiometricDataTable.Rows[i][0].ToString() + "', '" + this.m_obj_BiometricDataTable.Rows[i][3].ToString() + "',  to_date('" + this.m_obj_BiometricDataTable.Rows[i][1].ToString() + "', 'dd-mon-yyyy hh24:mi:ss'),'" + this.m_obj_BiometricDataTable.Rows[i][4].ToString() + "')");
            //    lcl_objLst_SilkERPInsert.Add(lcl_obj_SqlInsertBuilder.ToString());
            //    lcl_obj_SqlInsertBuilder.Length = 0;
            //}
            //lcl_sb_LogBuilder.AppendLine("Insert Queries Generated For SilkERP.BMS_REPOSITORY input!!!");
            ////Insert BMS TRANSACTION IN SILKERP DATABASE
            //lcl_sb_LogBuilder.AppendLine("Saving Biometric Transaction Data to SilkERP.BMS_REPOSITORY Database...");
            //System.Data.OracleClient.OracleTransaction lcl_obj_SilkERPTransaction = lcl_obj_SilkERPDatabaseConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);


            System.UInt64 lcl_ui64_BMS_REPO_CODE = 1;
            for (int i = 0; i < lcl_strArr_BiometricDataLines.Length; i++)
            {
                lcl_ui64_BMS_REPO_CODE++;
                System.String[] lcl_strArr_BiometricDataLineSegments = lcl_strArr_BiometricDataLines[i].Split(new char[] { ',' });
                lcl_obj_SqlInsertBuilder.Append("INSERT INTO BMS_REPOSITORY(BMS_TRAN_CODE,EMPLOYEE_ID,READER_CODE,TRAN_DATE_TIME,READER_NAME) Values(" + lcl_ui64_BMS_REPO_CODE + ", '" + lcl_strArr_BiometricDataLineSegments[0].ToString().Trim() + "', '" + lcl_strArr_BiometricDataLineSegments[3].ToString() + "',  to_date('" + lcl_strArr_BiometricDataLineSegments[1].ToString() + "', 'dd-mon-yyyy hh24:mi:ss'),'" + lcl_strArr_BiometricDataLineSegments[4].ToString() + "')");
                lcl_objLst_SilkERPInsert.Add(lcl_obj_SqlInsertBuilder.ToString());
                lcl_obj_SqlInsertBuilder.Length = 0;
            }
            

             foreach (System.String lcl_str_BMSInsert in lcl_objLst_SilkERPInsert)
            {
                //Console.WriteLine(lcl_str_BMSInsert);
                this.m_obj_DBManager.ExecuteNonQuery(lcl_str_BMSInsert);
            }
             this.m_obj_DBManager.CommitTransaction();
        }

        public void SynchronizeBiometricRepository()
        {
            SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Synchronizing Biometric Data Repository...");
            System.Data.SqlClient.SqlConnection lcl_obj_BiometricDBConnection = null;
            System.Data.SqlClient.SqlDataAdapter lcl_obj_BiometricDBAdapter = null;
            System.Text.StringBuilder lcl_sb_LogBuilder = null;
            System.Collections.Generic.List<System.String> lcl_objLst_SilkERPInsert = null;
            try
            {
                lcl_sb_LogBuilder = new StringBuilder();
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                lcl_sb_LogBuilder.AppendLine("Biometric Data Synchronization" + System.DateTime.Today.Year);
                lcl_sb_LogBuilder.AppendLine("--------------------------------------------------------------------------------------------------------------");
                System.UInt64 lcl_ui64_MaxCode = 0;
                //System.Data.OracleClient.OracleConnection lcl_obj_SilkERPDatabaseConnection = new System.Data.OracleClient.OracleConnection(BiometricDataUploader.SILKERP_DATA_SERVER_CONNECTION_STRING);
                //lcl_obj_SilkERPDatabaseConnection.Open();
                //this.m_obj_DBManager.Open();
                System.String lcl_str_SilkERPQuery = System.String.Format("SELECT MAX(BMS_TRAN_CODE) FROM BMS_REPOSITORY");
                System.Object lcl_obj_MaxCode = this.m_obj_DBManager.ExecuteScalar(lcl_str_SilkERPQuery);
                if (lcl_obj_MaxCode.ToString() == "")
                {
                    lcl_ui64_MaxCode = 0;
                }
                else
                {
                    lcl_ui64_MaxCode = System.UInt64.Parse(lcl_obj_MaxCode.ToString());
                }
                /**************************************************************************************************************/
                //Adjust Max Code
                lcl_ui64_MaxCode = lcl_ui64_MaxCode - BMS_REPOSITORY_START;
                /**************************************************************************************************************/
                lcl_sb_LogBuilder.AppendLine("Maximum BMS_TRAN_CODE retrieved from SilkERP.BMS_REPOSITORY Database!!!");

                System.String lcl_str_BiometricDBQuery = @"SELECT Employee_ID,convert(varchar,Ttime,106)+' '+convert(varchar,Ttime,108)Ttime,XX,Device_ID,Device_ID_Name,Timelog_ID From (SELECT 
            	CCFTCentral..PersonalDataString.Value as 'Employee_ID',
            	DateAdd(HH,06,CCFTEvent..Event.OccurrenceTime) as 'Ttime', 
            	
            	-- Determine if it is an entry or exit event
            	Case Event.eventtype
            		When 20001 Then '1'			-- This is the EventType which represents an Entry
            		When 20091 Then '1'			-- This is another EventType which represents an Entry
            	Else '2' End XX,					-- The EventType for Exit is '20003'
            	
            	Door.ID as 'Device_ID',			-- ID of the Door. This is internally assigned by Command Centre.
            	Door.Name as 'Device_ID_Name',	-- Name of the Door
            	
            	CCFTEvent..Event.ID as 'Timelog_ID'
            	
            	-- Optional fields
            	-------------------
            	-- Cardholder.Name, 
            	-- CCFTEvent..Event.EventType, 
            	-- CCFTEvent..Event.Message	
                  
            FROM 
            	CCFTEvent..Event 
            	
            -- Get the Cardholder name
            JOIN
            	CCFTEvent..RelatedItems as CardholderRelation
            ON
            	CardholderRelation.EventID = Event.ID and CardholderRelation.RelationCode = 0
            JOIN
            	CCFTCentral..FTItem as Cardholder
            ON
            	Cardholder.ID = CardholderRelation.FTItemID
            
            
            -- Get the Personal Data Field Value
            JOIN
            	CCFTCentral..PersonalDataString 
            ON
            	Cardholder.ID = CCFTCentral..PersonalDataString.CardholderID 	
            
            	
            -- Get the Door name
            JOIN
            	CCFTEvent..RelatedItems as DoorRelation
            ON
            	DoorRelation.EventID = Event.ID and DoorRelation.RelationCode = 2
            JOIN
            	CCFTCentral..FTItem as Door
            ON
            	Door.ID = DoorRelation.FTItemID
            	
            WHERE
              (ccftevent..Event.eventtype = '20001' OR ccftevent..Event.eventtype = '200091' OR ccftevent..Event.eventtype = '20002'  OR ccftevent..Event.eventtype = '20003' OR ccftevent..Event.eventtype = '20004' OR ccftevent..Event.eventtype = '20006' OR ccftevent..Event.eventtype = '20007')
            AND CCFTCentral..PersonalDataString.VAlUE<>' '	-- Change this to suit the ID in your system.
           -- AND
           	--DateAdd(HH,06,CCFTEvent..Event.OccurrenceTime)
         --BETWEEN cast(convert(varchar,getdate(),101) as datetime)+'01/01/1900 00:00:01' AND cast(convert(varchar,getdate(),101) as datetime)+'01/01/1900 23:59:01'
            AND 
            CCFTEvent..Event.ID>" + lcl_ui64_MaxCode + @"
            and Event.eventtype in(20001,200091,20002,20003,20004,20006,20007))X
            ORDER BY Timelog_ID";

                /*************************************************************************************************************/
                //lcl_str_BiometricDBQuery = System.String.Format("SELECT * FROM EVENTTYPE");

                /*************************************************************************************************************/
                lcl_objLst_SilkERPInsert = new List<string>();

                lcl_sb_LogBuilder.AppendLine("Connecting with Biometric Data Server...");
                lcl_obj_BiometricDBConnection = new SqlConnection(this.BIOMETRIC_DATA_SERVER_CONNECTION_STRING);
                lcl_obj_BiometricDBConnection.Open();
                lcl_sb_LogBuilder.AppendLine("Successfully Connected To Biometric Data Server!!!");
                lcl_obj_BiometricDBAdapter = new SqlDataAdapter(lcl_str_BiometricDBQuery, lcl_obj_BiometricDBConnection);
                lcl_sb_LogBuilder.AppendLine("Fetching Data From Biometric Database Server...");
                lcl_obj_BiometricDBAdapter.Fill(this.m_obj_BiometricDataTable);
                lcl_sb_LogBuilder.AppendLine("Biometric Data Fetched Successfully!!!");
                lcl_obj_BiometricDBConnection.Close();
                /***************************************************************************************************************/
                //for (int j = 0; j < this.m_obj_BiometricDataTable.Rows.Count; j++)
                //{
                //    lcl_sb_LogBuilder.AppendLine("ID : " + this.m_obj_BiometricDataTable.Rows[j]["ID"].ToString());
                //    lcl_sb_LogBuilder.AppendLine("NAME : " + this.m_obj_BiometricDataTable.Rows[j]["NAME"].ToString());
                //}
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                //this.m_obj_ServiceLog.Close();
                /***************************************************************************************************************/
                lcl_sb_LogBuilder.AppendLine("Biometric Database Server Disconnected Successfully!!!");
                System.Text.StringBuilder lcl_obj_SqlInsertBuilder = new StringBuilder();
                System.DateTime lcl_dt_Now = System.DateTime.Now;
                System.UInt64 lcl_ui64_BMS_REPO_CODE = 0;
                for (int i = 0; i < this.m_obj_BiometricDataTable.Rows.Count; i++)
                {
                    /**********************************************************************************************************/
                    //Reject Any Transaction which is not older than 06 hours
                    System.DateTime lcl_dt_TransactionDateTime = System.DateTime.Parse(this.m_obj_BiometricDataTable.Rows[i][1].ToString());
                    System.TimeSpan lcl_ts_HoursDofference = lcl_dt_Now.Subtract(lcl_dt_TransactionDateTime);
                    if (lcl_ts_HoursDofference.TotalHours < 3.0)
                    {
                        continue;
                    }
                    /**********************************************************************************************************/
                    lcl_ui64_BMS_REPO_CODE = BMS_REPOSITORY_START + System.UInt64.Parse(this.m_obj_BiometricDataTable.Rows[i][5].ToString());

                    string fg = this.m_obj_BiometricDataTable.Rows[i][0].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][1].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][2].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][3].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][4].ToString() + "--" + this.m_obj_BiometricDataTable.Rows[i][5].ToString();
                    lcl_obj_SqlInsertBuilder.Append("INSERT INTO BMS_REPOSITORY(BMS_TRAN_CODE,EMPLOYEE_ID,READER_CODE,TRAN_DATE_TIME,READER_NAME) Values(" + lcl_ui64_BMS_REPO_CODE + ", '" + this.m_obj_BiometricDataTable.Rows[i][0].ToString() + "', '" + this.m_obj_BiometricDataTable.Rows[i][3].ToString() + "',  to_date('" + this.m_obj_BiometricDataTable.Rows[i][1].ToString() + "', 'dd-mon-yyyy hh24:mi:ss'),'" + this.m_obj_BiometricDataTable.Rows[i][4].ToString() + "')");
                    lcl_objLst_SilkERPInsert.Add(lcl_obj_SqlInsertBuilder.ToString());
                    lcl_obj_SqlInsertBuilder.Length = 0;
                }
                lcl_sb_LogBuilder.AppendLine("Insert Queries Generated For SilkERP.BMS_REPOSITORY input!!!");
                //Insert BMS TRANSACTION IN SILKERP DATABASE
                lcl_sb_LogBuilder.AppendLine("Saving Biometric Transaction Data to SilkERP.BMS_REPOSITORY Database...");
                //System.Data.OracleClient.OracleTransaction lcl_obj_SilkERPTransaction = lcl_obj_SilkERPDatabaseConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                foreach (System.String lcl_str_BMSInsert in lcl_objLst_SilkERPInsert)
                {
                    Console.WriteLine(lcl_str_BMSInsert);
                    this.m_obj_DBManager.ExecuteNonQuery(lcl_str_BMSInsert);
                }

                lcl_sb_LogBuilder.AppendLine("Number Of BMS_repository Uploaded : " + lcl_objLst_SilkERPInsert.Count);
                lcl_sb_LogBuilder.AppendLine("Biometric Transaction Data Uploaded Successfully in SilkERP.BMS_REPOSITORY Database!!!");
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                //this.m_obj_ServiceLog.Close();
                //int a = 0;

            }
            catch (System.Exception Ex)
            {
                //if (lcl_obj_BiometricDBConnection != null)
                //{
                //    if (lcl_obj_BiometricDBConnection.State == System.Data.ConnectionState.Open)
                //    {
                //        lcl_obj_BiometricDBConnection.Close();
                //    }
                //}
                //this.m_obj_ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Critical Error : " + Ex.Message);
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Biometric Repository Could Not Be fetched!!!");
                //this.m_obj_ServiceLog();
                
            }
            finally
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData(lcl_sb_LogBuilder.ToString());
                SilkERP360.SP.HRIS.ServiceLog.Flush();
            }
        }
    }
}
