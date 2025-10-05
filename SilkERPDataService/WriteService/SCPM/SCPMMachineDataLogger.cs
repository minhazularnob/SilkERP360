using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.WriteService.SCPM
{
    public class SCPMMachineDataLogger
    {
        public System.UInt64 SaveMachineThroughput(SilkERPDataService.Containers.SCPM.SCMachineThroughput IP_obj_MachineThroughput)
        {
            SilkERP360.DAL.DBManager lcl_obj_DBManager = null;
            try
            {
                System.String lcl_str_Insert = System.String.Format("INSERT INTO SCPM_MACHINE_THROUGHPUT (MACHINE_THROUGHPUT_CODE,MACHINE_CODE,SHIFT_CODE,TARGET_THROUGHPUT,THROUGHPUT_SHFT,THROUGHPUT_DT_TM,ENTRY_EMP_CODE,REMARKS,WASTAGE,DAILY_STATUS) " +
                                                                    "VALUES(SEQ_MACH_THROUGHPUT.NEXTVAL,{0},{1},{2},{3},'{4}',{5},'{6}',{7},{8})", IP_obj_MachineThroughput._MachineCode_UI64.ToString(),
                                                                    IP_obj_MachineThroughput._ShiftCode_UI64, IP_obj_MachineThroughput._TargetThroughput_UI32, IP_obj_MachineThroughput._Throughput_I64,
                                                                    IP_obj_MachineThroughput._ThroughputDateTime_DT.ToString("dd/MMMM/yyyy"), IP_obj_MachineThroughput._EntryEmployeeCode_UI64, IP_obj_MachineThroughput._Remarks_STR,
                                                                    IP_obj_MachineThroughput._Wastage_UI32, (System.Int32)IP_obj_MachineThroughput._DailySCPMMachineStatus);

                lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                lcl_obj_DBManager.ExecuteNonQuery(lcl_str_Insert);
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                return 0;
            }
            catch (System.Exception Ex)
            {
                lcl_obj_DBManager.RollbackTransaction();
                throw Ex;
            }
            finally
            {
                if (lcl_obj_DBManager != null)
                {
                    lcl_obj_DBManager.Close();
                }
            }
        }
    }
}
