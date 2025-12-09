using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    public class DuplicateRowEliminator
    {
        private SilkERP360.DAL.DBManager m_obj_DBManager = null;

        public void Init(System.String IP_str_DatabaseConnectionString)
        {
            try
            {
                this.m_obj_DBManager = new SilkERP360.DAL.DBManager(IP_str_DatabaseConnectionString);
                this.m_obj_DBManager.Initialize();
            }
            catch (System.Exception Ex)
            {
                
            }
        }

        public void Init(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                this.m_obj_DBManager = IP_obj_DBManager;
            }
            catch (System.Exception Ex)
            {
                
            }
        }

        //Steps
        //1-> Find Duplicate Rows in Work_Group_Operation_Master Table
        //2-> For each entry in Work_Group_Operation_Master, search corresponding Work_Group_OperationHistory
        public void EliminateWorkGroupDuplicates()
        {
            try
            {
                //this.m_obj_DBManager.Open();
                System.Collections.Generic.List<string> lcl_objLst_DuplicateWorkGroupOperationMasterCode = new List<string>();
                System.String lcl_str_Query = System.String.Format("SELECT  * FROM    (SELECT  WGOM.*, ROW_NUMBER() OVER (PARTITION BY WORK_GROUP_CODE, WORK_DATE ORDER BY WG_OPERATION_MASTER_CODE) AS rn FROM    WORK_GROUP_OPERATION_MASTER WGOM ) WHERE   rn > 1");
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupOperationMasterReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_Query);
                if (lcl_obj_WorkGroupOperationMasterReader.HasRows == false)
                {
                    lcl_obj_WorkGroupOperationMasterReader.Close();
                }
                else
                {
                    while (lcl_obj_WorkGroupOperationMasterReader.Read())
                    {
                        System.String lcl_str_WorkGroupMasterCode = lcl_obj_WorkGroupOperationMasterReader["WG_OPERATION_MASTER_CODE"].ToString();
                        lcl_objLst_DuplicateWorkGroupOperationMasterCode.Add(lcl_str_WorkGroupMasterCode);
                    }
                    lcl_obj_WorkGroupOperationMasterReader.Close();

                    foreach (System.String lcl_str_DuplicateWorkGroupOperationMasterCode in lcl_objLst_DuplicateWorkGroupOperationMasterCode)
                    {
                        lcl_str_Query = System.String.Format("DELETE WORK_GROUP_OPERATION_HISTORY WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_str_DuplicateWorkGroupOperationMasterCode);
                  //      this.m_obj_DBManager.ExecuteScalar(lcl_str_Query);
                        lcl_str_Query = System.String.Format("DELETE WORK_GROUP_OPERATION_MASTER WHERE WG_OPERATION_MASTER_CODE = {0}", lcl_str_DuplicateWorkGroupOperationMasterCode);
                   //     this.m_obj_DBManager.ExecuteScalar(lcl_str_Query);
                    }
                }
                //this.m_obj_DBManager.CommitTransaction();
                this.m_obj_DBManager.Close();
                int A = 0;
            }
            catch (System.Exception Ex)
            {
                this.m_obj_DBManager.Close();
            }
        }

        public void EliminateDuplicateLeaveApplication()
        {
            try
            {
                this.m_obj_DBManager.Open();
                System.Collections.Generic.List<string> lcl_objLst_DuplicateLeaveApplicationCode = new List<string>();
                System.String lcl_str_Query = System.String.Format("SELECT  * FROM    (SELECT  ELA.*, ROW_NUMBER() OVER (PARTITION BY EMPLOYEE_CODE, LEAVE_START_DATE ORDER BY LEAVE_APPLICATION_CODE) AS rn FROM    EMPLOYEE_LEAVE_APPLICATION ELA ) WHERE   rn > 1");
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DuplicateLeaveApplicationReader = this.m_obj_DBManager.ExecuteDataReader(lcl_str_Query);
                if (lcl_obj_DuplicateLeaveApplicationReader.HasRows == false)
                {
                    lcl_obj_DuplicateLeaveApplicationReader.Close();
                }
                else
                {
                    while (lcl_obj_DuplicateLeaveApplicationReader.Read())
                    {
                        System.String lcl_str_LeaveApplicationCode = lcl_obj_DuplicateLeaveApplicationReader["LEAVE_APPLICATION_CODE"].ToString();
                        lcl_objLst_DuplicateLeaveApplicationCode.Add(lcl_str_LeaveApplicationCode);
                    }
                    lcl_obj_DuplicateLeaveApplicationReader.Close();

                    foreach (System.String lcl_str_DuplicateLeaveApplicationCode in lcl_objLst_DuplicateLeaveApplicationCode)
                    {
                        lcl_str_Query = System.String.Format("DELETE EMPLOYEE_LEAVE_APPLICATION WHERE LEAVE_APPLICATION_CODE = {0}", lcl_str_DuplicateLeaveApplicationCode);
                        //this.m_obj_DBManager.ExecuteScalar(lcl_str_Query);
                    }
                }
                //this.m_obj_DBManager.CommitTransaction();
                //this.m_obj_DBManager.Close();
                int A = 0;
            }
            catch (System.Exception Ex)
            {
                this.m_obj_DBManager.Close();
            }
        }
    }
}
