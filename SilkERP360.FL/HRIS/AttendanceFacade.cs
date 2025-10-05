using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
   public class AttendanceFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>
    {
       public AttendanceFacade()
        {
            this.Initialize();
        }

       public ulong Save(CCL.BusinessEntities.HRIS.Attendance IP_obj_T)
       {
           System.UInt64 lcl_ui64_AttendanceCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new BML.HRIS.AttendanceManager();
               System.UInt64 lcl_ui64_AttendanceCodeTmp = lcl_obj_AttendanceManager.Save(IP_obj_T);
               return lcl_ui64_AttendanceCodeTmp;
           }, "FLExceptionPolicy");
           return lcl_ui64_AttendanceCode;
        }

       public CCL.BusinessEntities.HRIS.Attendance Get(ulong IP_ui64_Code)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = null;
           lcl_obj_Attendance = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>(() =>
           {
               SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
               SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_AttendanceTmp = lcl_obj_AttendanceManager.Get(IP_ui64_Code);
               return lcl_obj_AttendanceTmp;
           }, "FLExceptionPolicy");

           return lcl_obj_Attendance;
        }

       public CCL.BusinessEntities.HRIS.Attendance Get(string IP_str_SqlQuery)
       {
           SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_Attendance = null;
           lcl_obj_Attendance = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>(() =>
           {
               SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
               SilkERP360.CCL.BusinessEntities.HRIS.Attendance lcl_obj_AttendanceTmp = lcl_obj_AttendanceManager.Get(IP_str_SqlQuery);
               return lcl_obj_AttendanceTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_Attendance;
        }

       public List<CCL.BusinessEntities.HRIS.Attendance> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Attendance> lcl_obj_Attendance = null;
           lcl_obj_Attendance = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>>(() =>
           {
               SilkERP360.BML.HRIS.AttendanceManager lcl_obj_AttendanceManager = new SilkERP360.BML.HRIS.AttendanceManager();
               System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Attendance> lcl_obj_AttendanceTmp =
                   lcl_obj_AttendanceManager.GetList(IP_str_SqlQuery);
               return lcl_obj_AttendanceTmp;
           }, "FLExceptionPolicy");
           return lcl_obj_Attendance;
        }

        public int Update(CCL.BusinessEntities.HRIS.Attendance IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            System.Int32 lcl_i32_RowsUpdated = this.ExceptionManager.Process<System.Int32>(() =>
            {
                System.Int32 lcl_i32_RowsUpdatedTmp = 0;
                SilkERP360.BML.SqlManager lcl_obj_SqlManager = new SilkERP360.BML.SqlManager();
                lcl_obj_SqlManager.Initialize();
                System.Object lcl_obj_Response = lcl_obj_SqlManager.ExecuteScaler(IP_str_SqlUpdateQuery);
                lcl_obj_SqlManager.Close();
                lcl_i32_RowsUpdatedTmp = System.Int32.Parse(lcl_obj_Response.ToString());
                return lcl_i32_RowsUpdatedTmp;
            }, "FLExceptionPolicy");
            return lcl_i32_RowsUpdated;
        }
    }
}
