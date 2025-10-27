using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.HRIS
{
    public class DesignationFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IFacadeOperations<SilkERP360.CCL.BusinessEntities.HRIS.Designation>
    {

        public DesignationFacade()
        {
            this.Initialize();
        }
        
        public ulong Save(CCL.BusinessEntities.HRIS.Designation IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Designation Get(ulong IP_ui64_DesignationCode)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Designation>(() =>
            {
                SilkERP360.BML.HRIS.DesignationManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.DesignationManager();
                SilkERP360.CCL.BusinessEntities.HRIS.Designation lcl_obj_DesignationTmp = lcl_obj_DesignationManager.Get(IP_ui64_DesignationCode);
                return lcl_obj_DesignationTmp;
            }, "FLExceptionPolicy");

            return lcl_obj_Designation;
        }

        public System.UInt64 SaveDesignation(SilkERP360.CCL.BusinessEntities.HRIS.Designation IP_Obj_Designation)
        {
            System.UInt64 lcl_ui64_DesignationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.DesignationManager lcl_obj_DesignationManager = new BML.HRIS.DesignationManager();
                System.UInt64 lcl_ui64_DesignationCodeTmp = lcl_obj_DesignationManager.Save(IP_Obj_Designation);
                return lcl_ui64_DesignationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_DesignationCode;
        }

        public System.UInt64 UpdateDesignation(SilkERP360.CCL.BusinessEntities.HRIS.Designation IP_Obj_Designation)
        {
            System.UInt64 lcl_ui64_DesignationCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.DesignationManager lcl_obj_DesignationManager = new BML.HRIS.DesignationManager();
                System.UInt64 lcl_ui64_DesignationCodeTmp = lcl_obj_DesignationManager.Update(IP_Obj_Designation);
                return lcl_ui64_DesignationCodeTmp;
            }, "FLExceptionPolicy");
            return lcl_ui64_DesignationCode;
        }

        public bool DeleteDesignation(UInt64 IP_Ui64_designationCode)
        {
            bool isDeleted = this.ExceptionManager.Process<bool>(() =>
            {
                SilkERP360.BML.HRIS.DesignationManager lcl_obj_designationManager = new BML.HRIS.DesignationManager();
                isDeleted = lcl_obj_designationManager.DeleteDesignation(IP_Ui64_designationCode);
                return isDeleted;
            }, "SPExceptionPolicy");
            return isDeleted;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> GetAllDesignationWise(System.UInt64 IP_ui64_companyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"Select DESIGNATION_CODE,DEGN_NAME,SHORT_NAME,COMPANY_CODE,BASIC,HOUSE_RENT,MEDICAL,ENTERTAINMENT,CONVEYENCE,
                PHONE_BILL,OTHERS,GROSS,EFFECTIVE_FROM,IS_OT_ELIGABLE From  DESIGNATION
               where company_code = {0} and is_deleted=1 order by COMPANY_CODE desc", IP_ui64_companyCode);
                SilkERP360.BML.HRIS.DesignationManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.DesignationManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Designation> lcl_obj_DesignationTmp =
                    lcl_obj_DesignationManager.GetList(lcl_str_SqlQuery);
                return lcl_obj_DesignationTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_Designation;
        }


        public CCL.BusinessEntities.HRIS.Designation Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Designation> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public int Update(CCL.BusinessEntities.HRIS.Designation IP_obj_T)
        {
            throw new NotImplementedException();
        }

        public int Update(string IP_str_SqlUpdateQuery)
        {
            throw new NotImplementedException();
        }
    }
}
