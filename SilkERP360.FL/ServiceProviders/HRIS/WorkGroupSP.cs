using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.ServiceProviders.HRIS
{
    public class WorkGroupSP :   SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public WorkGroupSP()
        {
            this.Initialize();
        }

        public System.Int32 UpdateWorkGroupOperationMaster(SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile IP_obj_WorkGroupOperationMasterProfile)
        {
            System.Int32 Response = this.ExceptionManager.Process<System.Int32>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                lcl_obj_WorkGroupFactory.Initialize();
                return lcl_obj_WorkGroupFactory.UpdateWorkGroupOperationMaster(IP_obj_WorkGroupOperationMasterProfile);
            }, "FLExceptionPolicy");
            return Response;
        }

        public System.Int32 DeleteWorkGroupOperationMaster(List<UInt64> IP_obj_workGroupMasterCodeList, string User)
        {
            System.Int32 Response = this.ExceptionManager.Process<System.Int32>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                return lcl_obj_WorkGroupFactory.DeleteWorkGroupOperationMaster(IP_obj_workGroupMasterCodeList,User);
            }, "FLExceptionPolicy");
            return Response;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile> GetWorkGroupSchedules(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_Date)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile> lcl_objLst_WorkGroupOperationMasterProfileRet = null;
            lcl_objLst_WorkGroupOperationMasterProfileRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile>>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                lcl_obj_WorkGroupFactory.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.WorkGroupOperationMasterProfile> lcl_objLst_WorkGroupOperationMasterProfile = lcl_obj_WorkGroupFactory.GetWorkGroupSchedules(IP_ui64_CompanyCode, IP_dt_Date);
                return lcl_objLst_WorkGroupOperationMasterProfile;
            }, "FLExceptionPolicy");
            return lcl_objLst_WorkGroupOperationMasterProfileRet;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule> GetEmployeeWorkGroupScheduleByDate(System.UInt64 IP_ui64_CompanyCode, System.DateTime IP_dt_Date)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule> lcl_objLst_EmployeeWorkGroupScheduleRet = null;
            lcl_objLst_EmployeeWorkGroupScheduleRet = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule>>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                lcl_obj_WorkGroupFactory.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeWorkGroupSchedule> lcl_objLst_EmployeeWorkGroupSchedule = lcl_obj_WorkGroupFactory.GetEmployeeWorkGroupScheduleByDate(IP_ui64_CompanyCode,IP_dt_Date);
                return lcl_objLst_EmployeeWorkGroupSchedule;
            }, "FLExceptionPolicy");
            return lcl_objLst_EmployeeWorkGroupScheduleRet;
        }

        public SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup ProvideWorkGroupDetailsByDate(System.UInt64 IP_ui64_WorkGroupCode, System.DateTime IP_dt_Date)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup lcl_obj_WorkGroup = null;
            lcl_obj_WorkGroup = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroup>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                return lcl_obj_WorkGroupFactory.ManufWorkGroupEntityInDetail(IP_ui64_WorkGroupCode, IP_dt_Date);
            }, "FLExceptionPolicy");
            return lcl_obj_WorkGroup;
        }

        public System.Boolean SynchronizeEmployeeInclusion(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_IncludedWorkGroupOperationHistory)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                return lcl_obj_WorkGroupFactory.SynchronizeEmployeeInclusion(IP_objLst_IncludedWorkGroupOperationHistory);
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.Boolean SynchronizeEmployeeRemoval(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_DeletableWorkGroupOperationHistory)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                return lcl_obj_WorkGroupFactory.SynchronizeEmployeeRemoval(IP_objLst_DeletableWorkGroupOperationHistory);
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.Boolean SynchronizeEmployeeAssessmentStatus(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_UpdateableWorkGroupOperationHistory)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                return lcl_obj_WorkGroupFactory.SynchronizeEmployeeAssessmentStatus(IP_objLst_UpdateableWorkGroupOperationHistory);
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public System.Boolean SynchronizeWorkGroupOperationHistory(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_InsertableWorkGroupOperationHistory,
                                                                                  System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_EditableWorkGroupOperationHistory,
                                                                                  System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.WorkGroupOperationHistory> IP_objLst_DeletableWorkGroupOperationHistory)
        {
            System.Boolean lcl_b_Response = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                SilkERP360.BML.HRISFactory.WorkGroupFactory lcl_obj_WorkGroupFactory = new BML.HRISFactory.WorkGroupFactory();
                return lcl_obj_WorkGroupFactory.SynchronizeWorkGroupOperationHistory(IP_objLst_InsertableWorkGroupOperationHistory,
                    IP_objLst_EditableWorkGroupOperationHistory, IP_objLst_DeletableWorkGroupOperationHistory);
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }
    }
}
