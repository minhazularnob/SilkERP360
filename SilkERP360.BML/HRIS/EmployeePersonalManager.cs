using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;

namespace SilkERP360.BML.HRIS
{
    public class EmployeePersonalManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>
    {
        public EmployeePersonalManger()
        {
            this.Initialize();
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_EmployeePersonal, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeePersonalCode = 0;
            lcl_ui64_EmployeePersonalCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeePersonal.EmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_FatherName = new System.Data.OracleClient.OracleParameter("v_FATHER_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_FatherName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_FatherName.Value = lcl_obj_EmployeePersonal.FatherName;

                System.Data.OracleClient.OracleParameter lcl_obj_MotherName = new System.Data.OracleClient.OracleParameter("v_MOTHER_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_MotherName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MotherName.Value = lcl_obj_EmployeePersonal.MotherName;

                System.Data.OracleClient.OracleParameter lcl_obj_SpouseName = new System.Data.OracleClient.OracleParameter("v_SPOUSE_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_SpouseName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SpouseName.Value = lcl_obj_EmployeePersonal.SpouseName;

                System.Data.OracleClient.OracleParameter lcl_obj_DateOfBirth = new System.Data.OracleClient.OracleParameter("v_DATE_OF_BIRTH", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_DateOfBirth.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DateOfBirth.Value = lcl_obj_EmployeePersonal.DateOfBirth;

                System.Data.OracleClient.OracleParameter lcl_obj_MaritalStatus = new System.Data.OracleClient.OracleParameter("v_MARITAL_STATUS", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_MaritalStatus.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MaritalStatus.Value = lcl_obj_EmployeePersonal.MaritalStatus;

                System.Data.OracleClient.OracleParameter lcl_obj_Sex = new System.Data.OracleClient.OracleParameter("v_SEX", System.Data.OracleClient.OracleType.Char, 1);
                lcl_obj_Sex.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Sex.Value = lcl_obj_EmployeePersonal.Sex;

                System.Data.OracleClient.OracleParameter lcl_obj_Religion = new System.Data.OracleClient.OracleParameter("v_RELIGION", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_Religion.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Religion.Value = lcl_obj_EmployeePersonal.Religion;

                System.Data.OracleClient.OracleParameter lcl_obj_Nationality = new System.Data.OracleClient.OracleParameter("v_NATIONALITY", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_Nationality.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Nationality.Value = lcl_obj_EmployeePersonal.Nationality;

                System.Data.OracleClient.OracleParameter lcl_obj_BloodGroup = new System.Data.OracleClient.OracleParameter("v_BLOOD_GROUP", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_BloodGroup.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BloodGroup.Value = lcl_obj_EmployeePersonal.BloodGroup;

                System.Data.OracleClient.OracleParameter lcl_obj_Height = new System.Data.OracleClient.OracleParameter("v_HEIGHT", System.Data.OracleClient.OracleType.NVarChar, 10);
                lcl_obj_Height.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Height.Value = lcl_obj_EmployeePersonal.Height;

                System.Data.OracleClient.OracleParameter lcl_obj_Weight = new System.Data.OracleClient.OracleParameter("v_WEIGHT", System.Data.OracleClient.OracleType.NVarChar, 10);
                lcl_obj_Weight.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Weight.Value = lcl_obj_EmployeePersonal.Weight;

                System.Data.OracleClient.OracleParameter lcl_obj_Identification = new System.Data.OracleClient.OracleParameter("v_IDENTIFICATION", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_Identification.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Identification.Value = lcl_obj_EmployeePersonal.Identification;

                System.Data.OracleClient.OracleParameter lcl_obj_MobileNo = new System.Data.OracleClient.OracleParameter("v_MOBILE_NO", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_MobileNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MobileNo.Value = lcl_obj_EmployeePersonal.MobileNo;

                System.Data.OracleClient.OracleParameter lcl_obj_HomePhoneNo = new System.Data.OracleClient.OracleParameter("v_HOME_PHONE_NO", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_HomePhoneNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_HomePhoneNo.Value = lcl_obj_EmployeePersonal.HomePhoneNo;

                System.Data.OracleClient.OracleParameter lcl_obj_FaxNo = new System.Data.OracleClient.OracleParameter("v_FAX_NO", System.Data.OracleClient.OracleType.NVarChar, 20);
                lcl_obj_FaxNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_FaxNo.Value = lcl_obj_EmployeePersonal.FaxNo;

                System.Data.OracleClient.OracleParameter lcl_obj_Email = new System.Data.OracleClient.OracleParameter("v_EMAIL", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_Email.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Email.Value = lcl_obj_EmployeePersonal.Email;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentAddress = new System.Data.OracleClient.OracleParameter("v_PRESENT_ADDRESS", System.Data.OracleClient.OracleType.NVarChar, 256);
                lcl_obj_PresentAddress.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentAddress.Value = lcl_obj_EmployeePersonal.PresentAddress;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentPo = new System.Data.OracleClient.OracleParameter("v_PRESENT_PO", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_PresentPo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentPo.Value = lcl_obj_EmployeePersonal.PresentPo;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentPc = new System.Data.OracleClient.OracleParameter("v_PRESENT_PC", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_PresentPc.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentPc.Value = lcl_obj_EmployeePersonal.PresentPc;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentDistrictCode = new System.Data.OracleClient.OracleParameter("v_PRESENT_DISTRICT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PresentDistrictCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentDistrictCode.Value = lcl_obj_EmployeePersonal.PresentDistrictCode;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentAddress = new System.Data.OracleClient.OracleParameter("v_PERMANENT_ADDRESS", System.Data.OracleClient.OracleType.NVarChar, 256);
                lcl_obj_PermanentAddress.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentAddress.Value = lcl_obj_EmployeePersonal.PermanentAddress;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentPo = new System.Data.OracleClient.OracleParameter("v_PERMANENT_PO", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_PermanentPo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentPo.Value = lcl_obj_EmployeePersonal.PermanentPo;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentPc = new System.Data.OracleClient.OracleParameter("v_PERMANENT_PC", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_PermanentPc.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentPc.Value = lcl_obj_EmployeePersonal.PermanentPc;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentDistrictCode = new System.Data.OracleClient.OracleParameter("v_PERMANENT_DISTRICT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PermanentDistrictCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentDistrictCode.Value = lcl_obj_EmployeePersonal.PermanentDistrictCode;

                System.Data.OracleClient.OracleParameter lcl_obj_CitizenCardId = new System.Data.OracleClient.OracleParameter("v_CITIZEN_CARD_ID", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_CitizenCardId.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CitizenCardId.Value = lcl_obj_EmployeePersonal.CitizenCardId;

                System.Data.OracleClient.OracleParameter lcl_obj_PassportNo = new System.Data.OracleClient.OracleParameter("v_PASSPORT_NO", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_PassportNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PassportNo.Value = lcl_obj_EmployeePersonal.PassportNo;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_FatherName, lcl_obj_MotherName, lcl_obj_SpouseName, lcl_obj_DateOfBirth, lcl_obj_MaritalStatus, lcl_obj_Sex, lcl_obj_Religion, lcl_obj_Nationality, lcl_obj_BloodGroup, lcl_obj_Height, lcl_obj_Weight, lcl_obj_Identification, lcl_obj_MobileNo, lcl_obj_HomePhoneNo, lcl_obj_FaxNo, lcl_obj_Email, lcl_obj_PresentAddress, lcl_obj_PresentPo, lcl_obj_PresentPc, lcl_obj_PresentDistrictCode, lcl_obj_PermanentAddress, lcl_obj_PermanentPo, lcl_obj_PermanentPc, lcl_obj_PermanentDistrictCode, lcl_obj_CitizenCardId, lcl_obj_PassportNo };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_EMPLOYEE_PERSONAL", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeePersonalCode;

        }

        public ulong Update(SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_EmployeePersonal, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeePersonalCode = 0;
            lcl_ui64_EmployeePersonalCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeePersonal.EmployeeCode;

                System.Data.OracleClient.OracleParameter lcl_obj_FatherName = new System.Data.OracleClient.OracleParameter("v_FATHER_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_FatherName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_FatherName.Value = lcl_obj_EmployeePersonal.FatherName;

                System.Data.OracleClient.OracleParameter lcl_obj_MotherName = new System.Data.OracleClient.OracleParameter("v_MOTHER_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_MotherName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MotherName.Value = lcl_obj_EmployeePersonal.MotherName;

                System.Data.OracleClient.OracleParameter lcl_obj_SpouseName = new System.Data.OracleClient.OracleParameter("v_SPOUSE_NAME", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_SpouseName.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SpouseName.Value = lcl_obj_EmployeePersonal.SpouseName;

                System.Data.OracleClient.OracleParameter lcl_obj_DateOfBirth = new System.Data.OracleClient.OracleParameter("v_DATE_OF_BIRTH", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_DateOfBirth.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DateOfBirth.Value = lcl_obj_EmployeePersonal.DateOfBirth;

                System.Data.OracleClient.OracleParameter lcl_obj_MaritalStatus = new System.Data.OracleClient.OracleParameter("v_MARITAL_STATUS", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_MaritalStatus.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MaritalStatus.Value = lcl_obj_EmployeePersonal.MaritalStatus;

                System.Data.OracleClient.OracleParameter lcl_obj_Sex = new System.Data.OracleClient.OracleParameter("v_SEX", System.Data.OracleClient.OracleType.Char, 1);
                lcl_obj_Sex.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Sex.Value = lcl_obj_EmployeePersonal.Sex;

                System.Data.OracleClient.OracleParameter lcl_obj_Religion = new System.Data.OracleClient.OracleParameter("v_RELIGION", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_Religion.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Religion.Value = lcl_obj_EmployeePersonal.Religion;

                System.Data.OracleClient.OracleParameter lcl_obj_Nationality = new System.Data.OracleClient.OracleParameter("v_NATIONALITY", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_Nationality.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Nationality.Value = lcl_obj_EmployeePersonal.Nationality;

                System.Data.OracleClient.OracleParameter lcl_obj_BloodGroup = new System.Data.OracleClient.OracleParameter("v_BLOOD_GROUP", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_BloodGroup.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_BloodGroup.Value = lcl_obj_EmployeePersonal.BloodGroup;

                System.Data.OracleClient.OracleParameter lcl_obj_Height = new System.Data.OracleClient.OracleParameter("v_HEIGHT", System.Data.OracleClient.OracleType.NVarChar, 10);
                lcl_obj_Height.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Height.Value = lcl_obj_EmployeePersonal.Height;

                System.Data.OracleClient.OracleParameter lcl_obj_Weight = new System.Data.OracleClient.OracleParameter("v_WEIGHT", System.Data.OracleClient.OracleType.NVarChar, 10);
                lcl_obj_Weight.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Weight.Value = lcl_obj_EmployeePersonal.Weight;

                System.Data.OracleClient.OracleParameter lcl_obj_Identification = new System.Data.OracleClient.OracleParameter("v_IDENTIFICATION", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_Identification.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Identification.Value = lcl_obj_EmployeePersonal.Identification;

                System.Data.OracleClient.OracleParameter lcl_obj_MobileNo = new System.Data.OracleClient.OracleParameter("v_MOBILE_NO", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_MobileNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MobileNo.Value = lcl_obj_EmployeePersonal.MobileNo;

                System.Data.OracleClient.OracleParameter lcl_obj_HomePhoneNo = new System.Data.OracleClient.OracleParameter("v_HOME_PHONE_NO", System.Data.OracleClient.OracleType.NVarChar, 100);
                lcl_obj_HomePhoneNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_HomePhoneNo.Value = lcl_obj_EmployeePersonal.HomePhoneNo;

                System.Data.OracleClient.OracleParameter lcl_obj_FaxNo = new System.Data.OracleClient.OracleParameter("v_FAX_NO", System.Data.OracleClient.OracleType.NVarChar, 20);
                lcl_obj_FaxNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_FaxNo.Value = lcl_obj_EmployeePersonal.FaxNo;

                System.Data.OracleClient.OracleParameter lcl_obj_Email = new System.Data.OracleClient.OracleParameter("v_EMAIL", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_Email.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Email.Value = lcl_obj_EmployeePersonal.Email;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentAddress = new System.Data.OracleClient.OracleParameter("v_PRESENT_ADDRESS", System.Data.OracleClient.OracleType.NVarChar, 256);
                lcl_obj_PresentAddress.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentAddress.Value = lcl_obj_EmployeePersonal.PresentAddress;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentPo = new System.Data.OracleClient.OracleParameter("v_PRESENT_PO", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_PresentPo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentPo.Value = lcl_obj_EmployeePersonal.PresentPo;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentPc = new System.Data.OracleClient.OracleParameter("v_PRESENT_PC", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_PresentPc.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentPc.Value = lcl_obj_EmployeePersonal.PresentPc;

                System.Data.OracleClient.OracleParameter lcl_obj_PresentDistrictCode = new System.Data.OracleClient.OracleParameter("v_PRESENT_DISTRICT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PresentDistrictCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PresentDistrictCode.Value = lcl_obj_EmployeePersonal.PresentDistrictCode;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentAddress = new System.Data.OracleClient.OracleParameter("v_PERMANENT_ADDRESS", System.Data.OracleClient.OracleType.NVarChar, 256);
                lcl_obj_PermanentAddress.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentAddress.Value = lcl_obj_EmployeePersonal.PermanentAddress;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentPo = new System.Data.OracleClient.OracleParameter("v_PERMANENT_PO", System.Data.OracleClient.OracleType.NVarChar, 128);
                lcl_obj_PermanentPo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentPo.Value = lcl_obj_EmployeePersonal.PermanentPo;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentPc = new System.Data.OracleClient.OracleParameter("v_PERMANENT_PC", System.Data.OracleClient.OracleType.NVarChar, 64);
                lcl_obj_PermanentPc.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentPc.Value = lcl_obj_EmployeePersonal.PermanentPc;

                System.Data.OracleClient.OracleParameter lcl_obj_PermanentDistrictCode = new System.Data.OracleClient.OracleParameter("v_PERMANENT_DISTRICT_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_PermanentDistrictCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PermanentDistrictCode.Value = lcl_obj_EmployeePersonal.PermanentDistrictCode;

                System.Data.OracleClient.OracleParameter lcl_obj_CitizenCardId = new System.Data.OracleClient.OracleParameter("v_CITIZEN_CARD_ID", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_CitizenCardId.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CitizenCardId.Value = lcl_obj_EmployeePersonal.CitizenCardId;

                System.Data.OracleClient.OracleParameter lcl_obj_PassportNo = new System.Data.OracleClient.OracleParameter("v_PASSPORT_NO", System.Data.OracleClient.OracleType.NVarChar, 32);
                lcl_obj_PassportNo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_PassportNo.Value = lcl_obj_EmployeePersonal.PassportNo;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_FatherName, lcl_obj_MotherName, lcl_obj_SpouseName, lcl_obj_DateOfBirth, lcl_obj_MaritalStatus, lcl_obj_Sex, lcl_obj_Religion, lcl_obj_Nationality, lcl_obj_BloodGroup, lcl_obj_Height, lcl_obj_Weight, lcl_obj_Identification, lcl_obj_MobileNo, lcl_obj_HomePhoneNo, lcl_obj_FaxNo, lcl_obj_Email, lcl_obj_PresentAddress, lcl_obj_PresentPo, lcl_obj_PresentPc, lcl_obj_PresentDistrictCode, lcl_obj_PermanentAddress, lcl_obj_PermanentPo, lcl_obj_PermanentPc, lcl_obj_PermanentDistrictCode, lcl_obj_CitizenCardId, lcl_obj_PassportNo };
                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_PERSONAL_UPDT_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeePersonalCode;

        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_EmployeePersonal)
        {
            System.UInt64 lcl_ui64_EmployeePersonalCode = 0;
            lcl_ui64_EmployeePersonalCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeePersonal.EmployeeCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_FatherName = new System.Data.OracleClient.OracleParameter("v_FATHER_NAME", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_FatherName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_FatherName.Value = lcl_obj_EmployeePersonal.FatherName;
                    System.Data.OracleClient.OracleParameter lcl_obj_MotherName = new System.Data.OracleClient.OracleParameter("v_MOTHER_NAME", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_MotherName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_MotherName.Value = lcl_obj_EmployeePersonal.MotherName;
                    System.Data.OracleClient.OracleParameter lcl_obj_SpouseName = new System.Data.OracleClient.OracleParameter("v_SPOUSE_NAME", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_SpouseName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SpouseName.Value = lcl_obj_EmployeePersonal.SpouseName;
                    System.Data.OracleClient.OracleParameter lcl_obj_DateOfBirth = new System.Data.OracleClient.OracleParameter("v_DATE_OF_BIRTH", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_DateOfBirth.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DateOfBirth.Value = lcl_obj_EmployeePersonal.DateOfBirth;
                    System.Data.OracleClient.OracleParameter lcl_obj_MaritalStatus = new System.Data.OracleClient.OracleParameter("v_MARITAL_STATUS", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_MaritalStatus.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_MaritalStatus.Value = lcl_obj_EmployeePersonal.MaritalStatus;
                    System.Data.OracleClient.OracleParameter lcl_obj_Sex = new System.Data.OracleClient.OracleParameter("v_SEX", System.Data.OracleClient.OracleType.Char);
                    lcl_obj_Sex.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Sex.Value = lcl_obj_EmployeePersonal.Sex;
                    System.Data.OracleClient.OracleParameter lcl_obj_Religion = new System.Data.OracleClient.OracleParameter("v_RELIGION", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Religion.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Religion.Value = lcl_obj_EmployeePersonal.Religion;
                    System.Data.OracleClient.OracleParameter lcl_obj_Nationality = new System.Data.OracleClient.OracleParameter("v_NATIONALITY", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Nationality.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Nationality.Value = lcl_obj_EmployeePersonal.Nationality;
                    System.Data.OracleClient.OracleParameter lcl_obj_BloodGroup = new System.Data.OracleClient.OracleParameter("v_BLOOD_GROUP", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_BloodGroup.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_BloodGroup.Value = lcl_obj_EmployeePersonal.BloodGroup;
                    System.Data.OracleClient.OracleParameter lcl_obj_Height = new System.Data.OracleClient.OracleParameter("v_HEIGHT", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Height.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Height.Value = lcl_obj_EmployeePersonal.Height;
                    System.Data.OracleClient.OracleParameter lcl_obj_Weight = new System.Data.OracleClient.OracleParameter("v_WEIGHT", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Weight.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Weight.Value = lcl_obj_EmployeePersonal.Weight;
                    System.Data.OracleClient.OracleParameter lcl_obj_Identification = new System.Data.OracleClient.OracleParameter("v_IDENTIFICATION", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Identification.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Identification.Value = lcl_obj_EmployeePersonal.Identification;
                    System.Data.OracleClient.OracleParameter lcl_obj_MobileNo = new System.Data.OracleClient.OracleParameter("v_MOBILE_NO", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_MobileNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_MobileNo.Value = lcl_obj_EmployeePersonal.MobileNo;
                    System.Data.OracleClient.OracleParameter lcl_obj_HomePhoneNo = new System.Data.OracleClient.OracleParameter("v_HOME_PHONE_NO", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_HomePhoneNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_HomePhoneNo.Value = lcl_obj_EmployeePersonal.HomePhoneNo;
                    System.Data.OracleClient.OracleParameter lcl_obj_FaxNo = new System.Data.OracleClient.OracleParameter("v_FAX_NO", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_FaxNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_FaxNo.Value = lcl_obj_EmployeePersonal.FaxNo;
                    System.Data.OracleClient.OracleParameter lcl_obj_Email = new System.Data.OracleClient.OracleParameter("v_EMAIL", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_Email.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Email.Value = lcl_obj_EmployeePersonal.Email;
                    System.Data.OracleClient.OracleParameter lcl_obj_PresentAddress = new System.Data.OracleClient.OracleParameter("v_PRESENT_ADDRESS", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_PresentAddress.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PresentAddress.Value = lcl_obj_EmployeePersonal.PresentAddress;
                    System.Data.OracleClient.OracleParameter lcl_obj_PresentPo = new System.Data.OracleClient.OracleParameter("v_PRESENT_PO", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_PresentPo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PresentPo.Value = lcl_obj_EmployeePersonal.PresentPo;
                    System.Data.OracleClient.OracleParameter lcl_obj_PresentPc = new System.Data.OracleClient.OracleParameter("v_PRESENT_PC", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_PresentPc.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PresentPc.Value = lcl_obj_EmployeePersonal.PresentPc;
                    System.Data.OracleClient.OracleParameter lcl_obj_PresentDistrictCode = new System.Data.OracleClient.OracleParameter("v_PRESENT_DISTRICT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_PresentDistrictCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PresentDistrictCode.Value = lcl_obj_EmployeePersonal.PresentDistrictCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_PermanentAddress = new System.Data.OracleClient.OracleParameter("v_PERMANENT_ADDRESS", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_PermanentAddress.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PermanentAddress.Value = lcl_obj_EmployeePersonal.PermanentAddress;
                    System.Data.OracleClient.OracleParameter lcl_obj_PermanentPo = new System.Data.OracleClient.OracleParameter("v_PERMANENT_PO", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_PermanentPo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PermanentPo.Value = lcl_obj_EmployeePersonal.PermanentPo;
                    System.Data.OracleClient.OracleParameter lcl_obj_PermanentPc = new System.Data.OracleClient.OracleParameter("v_PERMANENT_PC", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_PermanentPc.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PermanentPc.Value = lcl_obj_EmployeePersonal.PermanentPc;
                    System.Data.OracleClient.OracleParameter lcl_obj_PermanentDistrictCode = new System.Data.OracleClient.OracleParameter("v_PERMANENT_DISTRICT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_PermanentDistrictCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PermanentDistrictCode.Value = lcl_obj_EmployeePersonal.PermanentDistrictCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_CitizenCardId = new System.Data.OracleClient.OracleParameter("v_CITIZEN_CARD_ID", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_CitizenCardId.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CitizenCardId.Value = lcl_obj_EmployeePersonal.CitizenCardId;
                    System.Data.OracleClient.OracleParameter lcl_obj_PassportNo = new System.Data.OracleClient.OracleParameter("v_PASSPORT_NO", System.Data.OracleClient.OracleType.NVarChar);
                    lcl_obj_PassportNo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_PassportNo.Value = lcl_obj_EmployeePersonal.PassportNo;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj_EmployeePersonal.IsDeleted;
                    System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_EmployeePersonal.Status;

                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeCode, lcl_obj_FatherName, lcl_obj_MotherName, lcl_obj_SpouseName, lcl_obj_DateOfBirth, lcl_obj_MaritalStatus, lcl_obj_Sex, lcl_obj_Religion, lcl_obj_Nationality, lcl_obj_BloodGroup, lcl_obj_Height, lcl_obj_Weight, lcl_obj_Identification, lcl_obj_MobileNo, lcl_obj_HomePhoneNo, lcl_obj_FaxNo, lcl_obj_Email, lcl_obj_PresentAddress, lcl_obj_PresentPo, lcl_obj_PresentPc, lcl_obj_PresentDistrictCode, lcl_obj_PermanentAddress, lcl_obj_PermanentPo, lcl_obj_PermanentPc, lcl_obj_PermanentDistrictCode, lcl_obj_CitizenCardId, lcl_obj_PassportNo, lcl_obj_IsDeleted, lcl_obj_Status, };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.EmployeePersonal_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_EmployeeCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeePersonalCode;
        }
        public CCL.BusinessEntities.HRIS.EmployeePersonal Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_EmployeePersonal = null;
            lcl_obj_EmployeePersonal = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_PERSONAL EMPLOYEE_PERSONAL_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeePersonal.Get(ID,DBManger)) : Error Retrieving EmployeePersonal Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal();
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.FatherName = lcl_obj_dr["FATHER_NAME"].ToString();
                lcl_obj_Tmp.MotherName = lcl_obj_dr["MOTHER_NAME"].ToString();
                lcl_obj_Tmp.SpouseName = lcl_obj_dr["SPOUSE_NAME"].ToString();
                lcl_obj_Tmp.DateOfBirth = System.DateTime.Parse(lcl_obj_dr["DATE_OF_BIRTH"].ToString());
                lcl_obj_Tmp.MaritalStatus = lcl_obj_dr["MARITAL_STATUS"].ToString();
                lcl_obj_Tmp.Sex = lcl_obj_dr["SEX"].ToString();
                lcl_obj_Tmp.Religion = lcl_obj_dr["RELIGION"].ToString();
                lcl_obj_Tmp.Nationality = lcl_obj_dr["NATIONALITY"].ToString();
                lcl_obj_Tmp.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                lcl_obj_Tmp.Height = lcl_obj_dr["HEIGHT"].ToString();
                lcl_obj_Tmp.Weight = lcl_obj_dr["WEIGHT"].ToString();
                lcl_obj_Tmp.Identification = lcl_obj_dr["IDENTIFICATION"].ToString();
                lcl_obj_Tmp.MobileNo = lcl_obj_dr["MOBILE_NO"].ToString();
                lcl_obj_Tmp.HomePhoneNo = lcl_obj_dr["HOME_PHONE_NO"].ToString();
                lcl_obj_Tmp.FaxNo = lcl_obj_dr["FAX_NO"].ToString();
                lcl_obj_Tmp.Email = lcl_obj_dr["EMAIL"].ToString();
                lcl_obj_Tmp.PresentAddress = lcl_obj_dr["PRESENT_ADDRESS"].ToString();
                lcl_obj_Tmp.PresentPo = lcl_obj_dr["PRESENT_PO"].ToString();
                lcl_obj_Tmp.PresentPc = lcl_obj_dr["PRESENT_PC"].ToString();
                lcl_obj_Tmp.PresentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PRESENT_DISTRICT_CODE"].ToString());
                lcl_obj_Tmp.PermanentAddress = lcl_obj_dr["PERMANENT_ADDRESS"].ToString();
                lcl_obj_Tmp.PermanentPo = lcl_obj_dr["PERMANENT_PO"].ToString();
                lcl_obj_Tmp.PermanentPc = lcl_obj_dr["PERMANENT_PC"].ToString();
                lcl_obj_Tmp.PermanentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PERMANENT_DISTRICT_CODE"].ToString());
                lcl_obj_Tmp.CitizenCardId = lcl_obj_dr["CITIZEN_CARD_ID"].ToString();
                lcl_obj_Tmp.PassportNo = lcl_obj_dr["PASSPORT_NO"].ToString();
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePersonal;
        }

        public CCL.BusinessEntities.HRIS.EmployeePersonal Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_EmployeePersonal = null;
            lcl_obj_EmployeePersonal = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_PERSONAL EMPLOYEE_PERSONAL_CODE= {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePersonal.Get(ID)) : No EmployeePersonal Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.FatherName = lcl_obj_dr["FATHER_NAME"].ToString();
                    lcl_obj_Tmp.MotherName = lcl_obj_dr["MOTHER_NAME"].ToString();
                    lcl_obj_Tmp.SpouseName = lcl_obj_dr["SPOUSE_NAME"].ToString();
                    lcl_obj_Tmp.DateOfBirth = System.DateTime.Parse(lcl_obj_dr["DATE_OF_BIRTH"].ToString());
                    lcl_obj_Tmp.MaritalStatus = lcl_obj_dr["MARITAL_STATUS"].ToString();
                    lcl_obj_Tmp.Sex = lcl_obj_dr["SEX"].ToString();
                    lcl_obj_Tmp.Religion = lcl_obj_dr["RELIGION"].ToString();
                    lcl_obj_Tmp.Nationality = lcl_obj_dr["NATIONALITY"].ToString();
                    lcl_obj_Tmp.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                    lcl_obj_Tmp.Height = lcl_obj_dr["HEIGHT"].ToString();
                    lcl_obj_Tmp.Weight = lcl_obj_dr["WEIGHT"].ToString();
                    lcl_obj_Tmp.Identification = lcl_obj_dr["IDENTIFICATION"].ToString();
                    lcl_obj_Tmp.MobileNo = lcl_obj_dr["MOBILE_NO"].ToString();
                    lcl_obj_Tmp.HomePhoneNo = lcl_obj_dr["HOME_PHONE_NO"].ToString();
                    lcl_obj_Tmp.FaxNo = lcl_obj_dr["FAX_NO"].ToString();
                    lcl_obj_Tmp.Email = lcl_obj_dr["EMAIL"].ToString();
                    lcl_obj_Tmp.PresentAddress = lcl_obj_dr["PRESENT_ADDRESS"].ToString();
                    lcl_obj_Tmp.PresentPo = lcl_obj_dr["PRESENT_PO"].ToString();
                    lcl_obj_Tmp.PresentPc = lcl_obj_dr["PRESENT_PC"].ToString();
                    lcl_obj_Tmp.PresentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PRESENT_DISTRICT_CODE"].ToString());
                    lcl_obj_Tmp.PermanentAddress = lcl_obj_dr["PERMANENT_ADDRESS"].ToString();
                    lcl_obj_Tmp.PermanentPo = lcl_obj_dr["PERMANENT_PO"].ToString();
                    lcl_obj_Tmp.PermanentPc = lcl_obj_dr["PERMANENT_PC"].ToString();
                    lcl_obj_Tmp.PermanentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PERMANENT_DISTRICT_CODE"].ToString());
                    lcl_obj_Tmp.CitizenCardId = lcl_obj_dr["CITIZEN_CARD_ID"].ToString();
                    lcl_obj_Tmp.PassportNo = lcl_obj_dr["PASSPORT_NO"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePersonal;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal> lcl_objlist_EmployeePersonal = null;
            lcl_objlist_EmployeePersonal = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePersonal.GetList(SqlQuery)) : No Attandance Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal();
                        lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_Tmp.FatherName = lcl_obj_dr["FATHER_NAME"].ToString();
                        lcl_obj_Tmp.MotherName = lcl_obj_dr["MOTHER_NAME"].ToString();
                        lcl_obj_Tmp.SpouseName = lcl_obj_dr["SPOUSE_NAME"].ToString();
                        lcl_obj_Tmp.DateOfBirth = System.DateTime.Parse(lcl_obj_dr["DATE_OF_BIRTH"].ToString());
                        lcl_obj_Tmp.MaritalStatus = lcl_obj_dr["MARITAL_STATUS"].ToString();
                        lcl_obj_Tmp.Sex = lcl_obj_dr["SEX"].ToString();
                        lcl_obj_Tmp.Religion = lcl_obj_dr["RELIGION"].ToString();
                        lcl_obj_Tmp.Nationality = lcl_obj_dr["NATIONALITY"].ToString();
                        lcl_obj_Tmp.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                        lcl_obj_Tmp.Height = lcl_obj_dr["HEIGHT"].ToString();
                        lcl_obj_Tmp.Weight = lcl_obj_dr["WEIGHT"].ToString();
                        lcl_obj_Tmp.Identification = lcl_obj_dr["IDENTIFICATION"].ToString();
                        lcl_obj_Tmp.MobileNo = lcl_obj_dr["MOBILE_NO"].ToString();
                        lcl_obj_Tmp.HomePhoneNo = lcl_obj_dr["HOME_PHONE_NO"].ToString();
                        lcl_obj_Tmp.FaxNo = lcl_obj_dr["FAX_NO"].ToString();
                        lcl_obj_Tmp.Email = lcl_obj_dr["EMAIL"].ToString();
                        lcl_obj_Tmp.PresentAddress = lcl_obj_dr["PRESENT_ADDRESS"].ToString();
                        lcl_obj_Tmp.PresentPo = lcl_obj_dr["PRESENT_PO"].ToString();
                        lcl_obj_Tmp.PresentPc = lcl_obj_dr["PRESENT_PC"].ToString();
                        lcl_obj_Tmp.PresentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PRESENT_DISTRICT_CODE"].ToString());
                        lcl_obj_Tmp.PermanentAddress = lcl_obj_dr["PERMANENT_ADDRESS"].ToString();
                        lcl_obj_Tmp.PermanentPo = lcl_obj_dr["PERMANENT_PO"].ToString();
                        lcl_obj_Tmp.PermanentPc = lcl_obj_dr["PERMANENT_PC"].ToString();
                        lcl_obj_Tmp.PermanentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PERMANENT_DISTRICT_CODE"].ToString());
                        lcl_obj_Tmp.CitizenCardId = lcl_obj_dr["CITIZEN_CARD_ID"].ToString();
                        lcl_obj_Tmp.PassportNo = lcl_obj_dr["PASSPORT_NO"].ToString();
                        lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                        lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeePersonal;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal> lcl_objlist_EmployeePersonal = null;
            lcl_objlist_EmployeePersonal = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePersonal.GetList(SqlQuery,DBManager)) : No Attandance Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal> lcl_objlist_Tmp = new
                 System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>();
                while (lcl_obj_dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.FatherName = lcl_obj_dr["FATHER_NAME"].ToString();
                    lcl_obj_Tmp.MotherName = lcl_obj_dr["MOTHER_NAME"].ToString();
                    lcl_obj_Tmp.SpouseName = lcl_obj_dr["SPOUSE_NAME"].ToString();
                    lcl_obj_Tmp.DateOfBirth = System.DateTime.Parse(lcl_obj_dr["DATE_OF_BIRTH"].ToString());
                    lcl_obj_Tmp.MaritalStatus = lcl_obj_dr["MARITAL_STATUS"].ToString();
                    lcl_obj_Tmp.Sex = lcl_obj_dr["SEX"].ToString();
                    lcl_obj_Tmp.Religion = lcl_obj_dr["RELIGION"].ToString();
                    lcl_obj_Tmp.Nationality = lcl_obj_dr["NATIONALITY"].ToString();
                    lcl_obj_Tmp.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                    lcl_obj_Tmp.Height = lcl_obj_dr["HEIGHT"].ToString();
                    lcl_obj_Tmp.Weight = lcl_obj_dr["WEIGHT"].ToString();
                    lcl_obj_Tmp.Identification = lcl_obj_dr["IDENTIFICATION"].ToString();
                    lcl_obj_Tmp.MobileNo = lcl_obj_dr["MOBILE_NO"].ToString();
                    lcl_obj_Tmp.HomePhoneNo = lcl_obj_dr["HOME_PHONE_NO"].ToString();
                    lcl_obj_Tmp.FaxNo = lcl_obj_dr["FAX_NO"].ToString();
                    lcl_obj_Tmp.Email = lcl_obj_dr["EMAIL"].ToString();
                    lcl_obj_Tmp.PresentAddress = lcl_obj_dr["PRESENT_ADDRESS"].ToString();
                    lcl_obj_Tmp.PresentPo = lcl_obj_dr["PRESENT_PO"].ToString();
                    lcl_obj_Tmp.PresentPc = lcl_obj_dr["PRESENT_PC"].ToString();
                    lcl_obj_Tmp.PresentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PRESENT_DISTRICT_CODE"].ToString());
                    lcl_obj_Tmp.PermanentAddress = lcl_obj_dr["PERMANENT_ADDRESS"].ToString();
                    lcl_obj_Tmp.PermanentPo = lcl_obj_dr["PERMANENT_PO"].ToString();
                    lcl_obj_Tmp.PermanentPc = lcl_obj_dr["PERMANENT_PC"].ToString();
                    lcl_obj_Tmp.PermanentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PERMANENT_DISTRICT_CODE"].ToString());
                    lcl_obj_Tmp.CitizenCardId = lcl_obj_dr["CITIZEN_CARD_ID"].ToString();
                    lcl_obj_Tmp.PassportNo = lcl_obj_dr["PASSPORT_NO"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_objlist_EmployeePersonal;
        }


        public CCL.BusinessEntities.HRIS.EmployeePersonal Get(string IP_str_SqlQuery,System.Object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_EmployeePersonal = null;
            lcl_obj_EmployeePersonal = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal ErrorEmployeePersonal.Get(SqlQuery,DBManger)) : Error Retrieving EmployeePersonal Data!");
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal();
                lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_Tmp.FatherName = lcl_obj_dr["FATHER_NAME"].ToString();
                lcl_obj_Tmp.MotherName = lcl_obj_dr["MOTHER_NAME"].ToString();
                lcl_obj_Tmp.SpouseName = lcl_obj_dr["SPOUSE_NAME"].ToString();
                lcl_obj_Tmp.DateOfBirth = System.DateTime.Parse(lcl_obj_dr["DATE_OF_BIRTH"].ToString());
                lcl_obj_Tmp.MaritalStatus = lcl_obj_dr["MARITAL_STATUS"].ToString();
                lcl_obj_Tmp.Sex = lcl_obj_dr["SEX"].ToString();
                lcl_obj_Tmp.Religion = lcl_obj_dr["RELIGION"].ToString();
                lcl_obj_Tmp.Nationality = lcl_obj_dr["NATIONALITY"].ToString();
                lcl_obj_Tmp.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                lcl_obj_Tmp.Height = lcl_obj_dr["HEIGHT"].ToString();
                lcl_obj_Tmp.Weight = lcl_obj_dr["WEIGHT"].ToString();
                lcl_obj_Tmp.Identification = lcl_obj_dr["IDENTIFICATION"].ToString();
                lcl_obj_Tmp.MobileNo = lcl_obj_dr["MOBILE_NO"].ToString();
                lcl_obj_Tmp.HomePhoneNo = lcl_obj_dr["HOME_PHONE_NO"].ToString();
                lcl_obj_Tmp.FaxNo = lcl_obj_dr["FAX_NO"].ToString();
                lcl_obj_Tmp.Email = lcl_obj_dr["EMAIL"].ToString();
                lcl_obj_Tmp.PresentAddress = lcl_obj_dr["PRESENT_ADDRESS"].ToString();
                lcl_obj_Tmp.PresentPo = lcl_obj_dr["PRESENT_PO"].ToString();
                lcl_obj_Tmp.PresentPc = lcl_obj_dr["PRESENT_PC"].ToString();
                lcl_obj_Tmp.PresentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PRESENT_DISTRICT_CODE"].ToString());
                lcl_obj_Tmp.PermanentAddress = lcl_obj_dr["PERMANENT_ADDRESS"].ToString();
                lcl_obj_Tmp.PermanentPo = lcl_obj_dr["PERMANENT_PO"].ToString();
                lcl_obj_Tmp.PermanentPc = lcl_obj_dr["PERMANENT_PC"].ToString();
                lcl_obj_Tmp.PermanentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PERMANENT_DISTRICT_CODE"].ToString());
                lcl_obj_Tmp.CitizenCardId = lcl_obj_dr["CITIZEN_CARD_ID"].ToString();
                lcl_obj_Tmp.PassportNo = lcl_obj_dr["PASSPORT_NO"].ToString();
                lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_Tmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePersonal;
        }

        public CCL.BusinessEntities.HRIS.EmployeePersonal Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_EmployeePersonal = null;
            lcl_obj_EmployeePersonal = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeePersonal.Get(SqlQuery)) : No EmployeePersonal Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeePersonal();
                    lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_Tmp.FatherName = lcl_obj_dr["FATHER_NAME"].ToString();
                    lcl_obj_Tmp.MotherName = lcl_obj_dr["MOTHER_NAME"].ToString();
                    lcl_obj_Tmp.SpouseName = lcl_obj_dr["SPOUSE_NAME"].ToString();
                    lcl_obj_Tmp.DateOfBirth = System.DateTime.Parse(lcl_obj_dr["DATE_OF_BIRTH"].ToString());
                    lcl_obj_Tmp.MaritalStatus = lcl_obj_dr["MARITAL_STATUS"].ToString();
                    lcl_obj_Tmp.Sex = lcl_obj_dr["SEX"].ToString();
                    lcl_obj_Tmp.Religion = lcl_obj_dr["RELIGION"].ToString();
                    lcl_obj_Tmp.Nationality = lcl_obj_dr["NATIONALITY"].ToString();
                    lcl_obj_Tmp.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                    lcl_obj_Tmp.Height = lcl_obj_dr["HEIGHT"].ToString();
                    lcl_obj_Tmp.Weight = lcl_obj_dr["WEIGHT"].ToString();
                    lcl_obj_Tmp.Identification = lcl_obj_dr["IDENTIFICATION"].ToString();
                    lcl_obj_Tmp.MobileNo = lcl_obj_dr["MOBILE_NO"].ToString();
                    lcl_obj_Tmp.HomePhoneNo = lcl_obj_dr["HOME_PHONE_NO"].ToString();
                    lcl_obj_Tmp.FaxNo = lcl_obj_dr["FAX_NO"].ToString();
                    lcl_obj_Tmp.Email = lcl_obj_dr["EMAIL"].ToString();
                    lcl_obj_Tmp.PresentAddress = lcl_obj_dr["PRESENT_ADDRESS"].ToString();
                    lcl_obj_Tmp.PresentPo = lcl_obj_dr["PRESENT_PO"].ToString();
                    lcl_obj_Tmp.PresentPc = lcl_obj_dr["PRESENT_PC"].ToString();
                    lcl_obj_Tmp.PresentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PRESENT_DISTRICT_CODE"].ToString());
                    lcl_obj_Tmp.PermanentAddress = lcl_obj_dr["PERMANENT_ADDRESS"].ToString();
                    lcl_obj_Tmp.PermanentPo = lcl_obj_dr["PERMANENT_PO"].ToString();
                    lcl_obj_Tmp.PermanentPc = lcl_obj_dr["PERMANENT_PC"].ToString();
                    lcl_obj_Tmp.PermanentDistrictCode = System.UInt64.Parse(lcl_obj_dr["PERMANENT_DISTRICT_CODE"].ToString());
                    lcl_obj_Tmp.CitizenCardId = lcl_obj_dr["CITIZEN_CARD_ID"].ToString();
                    lcl_obj_Tmp.PassportNo = lcl_obj_dr["PASSPORT_NO"].ToString();
                    lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                    lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeePersonal;
        }

        }
}