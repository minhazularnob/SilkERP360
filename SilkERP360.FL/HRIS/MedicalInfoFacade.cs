using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
        public class MedicalInfoFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>
   {

        public MedicalInfoFacade()
        {
            this.Initialize();
        }


        public ulong Save(CCL.BusinessEntities.HRIS.MedicalInfo IP_obj_T)
        {
            System.UInt64 lcl_ui64_MedicineCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.MedicalInfoManager lcl_obj_MedicalInfoManager = new BML.HRIS.MedicalInfoManager();
                System.UInt64 lcl_ui64_MedicineCodeTmp = lcl_obj_MedicalInfoManager.Save(IP_obj_T);
                return lcl_ui64_MedicineCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_MedicineCode;
        }


//        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo> GetMedicalInfoData()
//        {
//            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo> lcl_obj_MedicalInfo = null;
//            lcl_obj_MedicalInfo = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>>(() =>
//            {
//                System.String lcl_str_SqlQuery = System.String.Format(@"Select MDCN_INFO_CODE,EMPLOYEE_CODE,AGE,SEX,VISITED_DATE,REMARKS,BLOOD_GROUP,DIAGNOSIS From  MEDICALE_INFO
//where MDCN_INFO_CODE = {0} order by VISITED_DATE desc");
//                SilkERP360.BML.HRIS.MedicalInfoManager lcl_obj_MedicalInfoManager = new SilkERP360.BML.HRIS.MedicalInfoManager();
//                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo> lcl_obj_MedicalInfoTmp =
//                    lcl_obj_MedicalInfoManager.GetList(lcl_str_SqlQuery);
//                return lcl_obj_MedicalInfoTmp;
//            }, "FLExceptionPolicy");
//            return lcl_obj_MedicalInfo;
//        }


        public CCL.BusinessEntities.HRIS.MedicalInfo Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_MedicalInfo = null;
            lcl_obj_MedicalInfo = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>(() =>
            {
                SilkERP360.BML.HRIS.MedicalInfoManager lcl_obj_MedicalInfoManager = new SilkERP360.BML.HRIS.MedicalInfoManager();
                SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_MedicalInfoTmp = lcl_obj_MedicalInfoManager.Get(IP_ui64_Code);
                return lcl_obj_MedicalInfoTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_MedicalInfo;
        }

        public CCL.BusinessEntities.HRIS.MedicalInfo Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_MedicalInfo = null;
            lcl_obj_MedicalInfo = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>(() =>
            {
                SilkERP360.BML.HRIS.MedicalInfoManager lcl_obj_MedicalInfoManager = new SilkERP360.BML.HRIS.MedicalInfoManager();
                SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_MedicalInfoTmp = lcl_obj_MedicalInfoManager.Get(IP_str_SqlQuery);
                return lcl_obj_MedicalInfoTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_MedicalInfo;
        }

        public List<CCL.BusinessEntities.HRIS.MedicalInfo> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo> lcl_obj_MedicalInfo = null;
            lcl_obj_MedicalInfo = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>>(() =>
            {
                SilkERP360.BML.HRIS.MedicalInfoManager lcl_obj_MedicalInfoManager = new SilkERP360.BML.HRIS.MedicalInfoManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo> lcl_obj_MedicalInfoTmp =
                    lcl_obj_MedicalInfoManager.GetList(IP_str_SqlQuery);
                return lcl_obj_MedicalInfoTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_MedicalInfo;
        }

        public int Update(CCL.BusinessEntities.HRIS.MedicalInfo IP_obj_T)
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
