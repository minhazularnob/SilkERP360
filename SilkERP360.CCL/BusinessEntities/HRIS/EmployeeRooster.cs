using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeeRooster : SilkERP360.CCL.Validation.ValidationBase

 {
      #region CONSTRUCTOR
       public EmployeeRooster()
        {
           
        }
        #endregion

      #region VALIDATION
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "DutyDate", Message = "Duty Date Entry")]
    //[SilkERP360.CCL.Validation.Attributes.CurrentDate(FieldName = "DutyDate", Message = "Duty Date Entry")]
    #endregion
       
       #region protectedMEMBER

       protected System.UInt64 m_uint64_EmployeeRoosterCode;
       protected System.UInt64 m_uint64_EmployeeRoosterMasterCode;
       protected System.DateTime m_Date_DutyDate;
       protected System.UInt64 m_uint64_EmployeeCode;
       protected System.Int16 m_int16_IsDeleted;
       protected System.Int16 m_int16_Status;


        #endregion

        #region PROPERTIES

       public System.UInt64 EmployeeRoosterCode
       {
           get { return m_uint64_EmployeeRoosterCode; }
           set { m_uint64_EmployeeRoosterCode = value; }
       }
       public System.UInt64 EmployeeRoosterMasterCode
       {
           get { return m_uint64_EmployeeRoosterMasterCode; }
           set { m_uint64_EmployeeRoosterMasterCode = value; }
       }
       public System.DateTime DutyDate
       {
           get { return m_Date_DutyDate; }
           set { m_Date_DutyDate = value; }
       }

       public System.UInt64 EmployeeCode
       {
           get { return m_uint64_EmployeeCode; }
           set { m_uint64_EmployeeCode = value; }
       }

       public System.Int16 IsDeleted
       {
           get { return m_int16_IsDeleted; }
           set { m_int16_IsDeleted = value; }
       }
       public System.Int16 Status
       {
           get { return m_int16_Status; }
           set { m_int16_Status = value; }
       }
        #endregion
    }
}
