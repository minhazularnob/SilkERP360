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
 public class EmployeeWeekend: SilkERP360.CCL.Validation.ValidationBase
{
     public EmployeeWeekend()
     {
     }

     protected  System.UInt64 m_uint64_WeekendCode;
     protected  System.UInt64 m_uint64_EmployeeCode;
     protected System.UInt64 m_uint64_Day;
     protected  System.UInt16 m_uint16_IsDeleted;
     protected  System.UInt16 m_uint16_Status;

    public System.UInt64 WeekendCode
    {
        get { return m_uint64_WeekendCode; }
        set { this.m_uint64_WeekendCode = value; }
    }
   
     public System.UInt64 EmployeeCode
    {
        get { return m_uint64_EmployeeCode; }
        set { this.m_uint64_EmployeeCode = value; }
    }

     public System.UInt64 Day
    {
        get { return m_uint64_Day; }
        set { this.m_uint64_Day = value; }
    }
    
    public System.UInt16 IsDeleted
    {
        get { return m_uint16_IsDeleted; }
        set { this.m_uint16_IsDeleted = value; }
    }
    
    public System.UInt16 Status
    {
        get { return m_uint16_Status; }
        set { this.m_uint16_Status = value; }
    }


}
  }