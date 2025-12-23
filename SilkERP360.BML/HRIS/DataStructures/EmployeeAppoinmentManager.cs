using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS.DataStructures
{
    public class EmployeeAppoinmentManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment>
    {
        public EmployeeAppoinmentManager()
        {
            this.Initialize();
        }
        public ulong Save(CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment IP_obj_A)
        {
            System.UInt64 lcl_ui64_EmployeeCode = this.ExceptionManager.Process<System.UInt64>(() =>
                {
                    SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource;
                    if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.Open();
                    }
                    System.UInt64 lcl_ui64_EmployeeCodeTmp = 0;
                    //lcl_obj_DBManager.Open();
                    if (IP_obj_A.Employee.EmployeeCode != 0)
                    {
                        lcl_ui64_EmployeeCodeTmp = IP_obj_A.Employee.EmployeeCode;
                        ////update Employee Official
                        SilkERP360.BML.HRIS.EmployeeManager lcl_obj_EmployeeManager = new SilkERP360.BML.HRIS.EmployeeManager();
                        lcl_obj_EmployeeManager.update(IP_obj_A.Employee, lcl_obj_DBManager);
                        //update Employee Personal
                        IP_obj_A.EmployeePersonal.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                        SilkERP360.BML.HRIS.EmployeePersonalManger lcl_obj_EmployeePersonalManager = new SilkERP360.BML.HRIS.EmployeePersonalManger();
                        lcl_obj_EmployeePersonalManager.Update(IP_obj_A.EmployeePersonal, lcl_obj_DBManager);

                       // //update salary
                        IP_obj_A.EmployeeSalaryStructure.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                        SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_EmployeeSalaryStructureManger = new EmployeeSalaryStructureManger();
                        lcl_obj_EmployeeSalaryStructureManger.Update(IP_obj_A.EmployeeSalaryStructure, lcl_obj_DBManager);

                       // //update Education
                        SilkERP360.BML.HRIS.EmployeeEducationManager lcl_obj_EmployeeEducationManager = new SilkERP360.BML.HRIS.EmployeeEducationManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmployeeEducation in IP_obj_A.EmployeeEducation)
                        {
                            lcl_obj_EmployeeEducation.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeEducationManager.Update(lcl_obj_EmployeeEducation, lcl_obj_DBManager);
                        }
                        //save EmployeeWeekEnd
                        SilkERP360.BML.HRIS.EmployeeWeekendManager lcl_obj_EmployeeWeekendManager = new SilkERP360.BML.HRIS.EmployeeWeekendManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmployeeWeekend in IP_obj_A.EmployeeWeekend)
                        {
                            lcl_obj_EmployeeWeekend.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeWeekendManager.Update(lcl_obj_EmployeeWeekend, lcl_obj_DBManager);
                        }
                        // update Employee Reference
                        SilkERP360.BML.HRIS.EmployeeReferenceManager lcl_obj_EmployeeReferenceManager = new SilkERP360.BML.HRIS.EmployeeReferenceManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference lcl_obj_EmployeeReference in IP_obj_A.EmployeeReferenceList)
                        {
                            lcl_obj_EmployeeReference.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeReferenceManager.Update(lcl_obj_EmployeeReference, lcl_obj_DBManager);
                        }

                        //Update Employee EntitleLeave
                        SilkERP360.BML.HRIS.EmployeeEntitleLeaveManger lcl_obj_EmployeeEntitleLeaveManger = new SilkERP360.BML.HRIS.EmployeeEntitleLeaveManger();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitledLeave in IP_obj_A.EmployeeEntitledLeaveList)
                        {
                            lcl_obj_EmployeeEntitledLeave.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeEntitleLeaveManger.Update(lcl_obj_EmployeeEntitledLeave, lcl_obj_DBManager);
                        }
                        //update Employee Experience
                        SilkERP360.BML.HRIS.EmployeeExperienceManager lcl_obj_EmployeeExperienceManagerr = new SilkERP360.BML.HRIS.EmployeeExperienceManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience lcl_obj_EmployeeExperience in IP_obj_A.EmployeeExperienceList)
                        {
                            lcl_obj_EmployeeExperience.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeExperienceManagerr.update(lcl_obj_EmployeeExperience, lcl_obj_DBManager);
                        }
                        //update Image
                        if (IP_obj_A.Image.Image1 != null)
                        {
                            IP_obj_A.Image.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            SilkERP360.BML.HRIS.EmployeeImageManager lcl_obj_EmployeeImageManager = new EmployeeImageManager();
                            lcl_obj_EmployeeImageManager.Update(IP_obj_A.Image, lcl_obj_DBManager);
                        }
                        lcl_obj_DBManager.CommitTransaction();

                    }
                    else
                    {

                        ////save Employee Official
                        IP_obj_A.Employee.EmployeeStatus = (ushort)SilkERP360.CCL.Enums.EmployeeStatus.Probation;
                        SilkERP360.BML.HRIS.EmployeeManager lcl_obj_EmployeeManager = new SilkERP360.BML.HRIS.EmployeeManager();
                        lcl_ui64_EmployeeCodeTmp = lcl_obj_EmployeeManager.Save(IP_obj_A.Employee, lcl_obj_DBManager);
                        //save Employee Personal
                        IP_obj_A.EmployeePersonal.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                        SilkERP360.BML.HRIS.EmployeePersonalManger lcl_obj_EmployeePersonalManager = new SilkERP360.BML.HRIS.EmployeePersonalManger();
                        lcl_obj_EmployeePersonalManager.Save(IP_obj_A.EmployeePersonal, lcl_obj_DBManager);

                        //save salary
                        IP_obj_A.EmployeeSalaryStructure.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                        SilkERP360.BML.HRIS.EmployeeSalaryStructureManger lcl_obj_EmployeeSalaryStructureManger = new EmployeeSalaryStructureManger();
                        lcl_obj_EmployeeSalaryStructureManger.Save(IP_obj_A.EmployeeSalaryStructure, lcl_obj_DBManager);

                        //save Education
                        SilkERP360.BML.HRIS.EmployeeEducationManager lcl_obj_EmployeeEducationManager = new SilkERP360.BML.HRIS.EmployeeEducationManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEducation lcl_obj_EmployeeEducation in IP_obj_A.EmployeeEducation)
                        {
                            lcl_obj_EmployeeEducation.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeEducationManager.Save(lcl_obj_EmployeeEducation, lcl_obj_DBManager);
                        }
                        //save EmployeeWeekEnd
                        SilkERP360.BML.HRIS.EmployeeWeekendManager lcl_obj_EmployeeWeekendManager = new SilkERP360.BML.HRIS.EmployeeWeekendManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeWeekend lcl_obj_EmployeeWeekend in IP_obj_A.EmployeeWeekend)
                        {
                            lcl_obj_EmployeeWeekend.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeWeekendManager.Save(lcl_obj_EmployeeWeekend, lcl_obj_DBManager);
                        }
                        //save Employee Reference
                        SilkERP360.BML.HRIS.EmployeeReferenceManager lcl_obj_EmployeeReferenceManager = new SilkERP360.BML.HRIS.EmployeeReferenceManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeReference lcl_obj_EmployeeReference in IP_obj_A.EmployeeReferenceList)
                        {
                            lcl_obj_EmployeeReference.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeReferenceManager.Save(lcl_obj_EmployeeReference, lcl_obj_DBManager);
                        }

                        //save Employee EntitleLeave
                        SilkERP360.BML.HRIS.EmployeeEntitleLeaveManger lcl_obj_EmployeeEntitleLeaveManger = new SilkERP360.BML.HRIS.EmployeeEntitleLeaveManger();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeEntitledLeave lcl_obj_EmployeeEntitledLeave in IP_obj_A.EmployeeEntitledLeaveList)
                        {
                            lcl_obj_EmployeeEntitledLeave.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeEntitleLeaveManger.Save(lcl_obj_EmployeeEntitledLeave, lcl_obj_DBManager);
                        }
                        //save Employee Experience
                        SilkERP360.BML.HRIS.EmployeeExperienceManager lcl_obj_EmployeeExperienceManagerr = new SilkERP360.BML.HRIS.EmployeeExperienceManager();
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeExperience lcl_obj_EmployeeExperience in IP_obj_A.EmployeeExperienceList)
                        {
                            lcl_obj_EmployeeExperience.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_EmployeeExperienceManagerr.Save(lcl_obj_EmployeeExperience, lcl_obj_DBManager);
                        }
                        //save Image
                        IP_obj_A.Image.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                        SilkERP360.BML.HRIS.EmployeeImageManager lcl_obj_EmployeeImageManager = new EmployeeImageManager();
                        lcl_obj_EmployeeImageManager.Save(IP_obj_A.Image, lcl_obj_DBManager);

                        //save Employee Experience
                        if(IP_obj_A.EmployeeCertificateList != null)
                        {
                            SilkERP360.BML.HRIS.EmployeeCertificateManager lcl_obj_EmployeecertificateManager = new SilkERP360.BML.HRIS.EmployeeCertificateManager();
                            foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeCertificate lcl_obj_EmployeeCertificate in IP_obj_A.EmployeeCertificateList)
                            {
                                lcl_obj_EmployeeCertificate.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                                lcl_obj_EmployeecertificateManager.Save(lcl_obj_EmployeeCertificate, lcl_obj_DBManager);
                            }
                        }
                        

                        SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount lcl_obj_EmployeeLeaveAccount = new CCL.BusinessEntities.HRIS.EmployeeLeaveAccount();
                        lcl_obj_EmployeeLeaveAccount.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                        lcl_obj_EmployeeLeaveAccount.SL = 14;

                        SilkERP360.BML.HRIS.EmployeeLeaveAccountManager lcl_obj_EmployeeLeaveAccountManager = new EmployeeLeaveAccountManager();
                        lcl_obj_EmployeeLeaveAccountManager.Initialize();
                        lcl_obj_EmployeeLeaveAccountManager.Save(lcl_obj_EmployeeLeaveAccount, lcl_obj_DBManager);

                        //Create PF Account
                        if (IP_obj_A.Employee.IsPfEligible == 1)
                        {
                            SilkERP360.BML.HRIS.PFAccountManager lcl_obj_PFAccountManager = new PFAccountManager();
                            lcl_obj_PFAccountManager.Initialize();

                            SilkERP360.CCL.BusinessEntities.HRIS.PFAccount lcl_obj_PFAccount = new CCL.BusinessEntities.HRIS.PFAccount();
                            lcl_obj_PFAccount.EmployeeCode = lcl_ui64_EmployeeCodeTmp;
                            lcl_obj_PFAccount.CompanyCode = IP_obj_A.Employee.CompanyCode;
                            lcl_obj_PFAccount.AccountStatus = SilkERP360.CCL.Enums.ProvidentFundAccountStatus.Active;
                            lcl_obj_PFAccount.Remarks = "Synchronized Account";

                            lcl_obj_PFAccountManager.Save(lcl_obj_PFAccount, lcl_obj_DBManager);
                        }

                        lcl_obj_DBManager.CommitTransaction();

                    }

                    
                    

                    return lcl_ui64_EmployeeCodeTmp;
                }, "BMLExceptionPolicy");
            return lcl_ui64_EmployeeCode;
        }

        public CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeAppoinment> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
