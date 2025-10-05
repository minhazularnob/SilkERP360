using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
   public class EmployeeExperience : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
   {

       #region CONSTRUCTOR
       public EmployeeExperience()
       {
       }
       #endregion

       #region protected VARIABLES
       protected UInt64 m_uint64_ExperienceCode;
       protected System.String m_str_EmployerName;
       protected System.String m_str_Address;
       protected System.String m_str_ContactNo;
       protected System.String m_str_NatureOfJob;
       protected System.String m_str_Responsibility;
       protected System.DateTime m_date_FromDate;
       protected System.DateTime m_date_ToDate;
       protected System.UInt64 m_uint64_EmployeeCode;
       protected System.UInt16 m_uint16_IsDeleted;
       protected System.UInt16 m_uint16_Status;

       #endregion

       #region PUBLIC PROPERTIES
       public UInt64 ExperienceCode
       {
           get { return m_uint64_ExperienceCode; }
           set { this.m_uint64_ExperienceCode = value; }
       }
       

       public System.String EmployerName
       {
           get { return m_str_EmployerName; }
           set { this.m_str_EmployerName = value; }
       }
       
       public System.String Address
       {
           get { return m_str_Address; }
           set { this.m_str_Address = value; }
       }
      
       public System.String ContactNo
       {
           get { return m_str_ContactNo; }
           set { this.m_str_ContactNo = value; }
       }
      
       public System.String NatureOfJob
       {
           get { return m_str_NatureOfJob; }
           set { this.m_str_NatureOfJob = value; }
       }
       
       public System.String Responsibility
       {
           get { return m_str_Responsibility; }
           set { this.m_str_Responsibility = value; }
       }
       
       public System.DateTime FromDate
       {
           get { return m_date_FromDate; }
           set { this.m_date_FromDate = value; }
       }
       
       public System.DateTime ToDate
       {
           get { return m_date_ToDate; }
           set { this.m_date_ToDate = value; }
       }
       
      

       public System.UInt16 IsDeleted
       {
           get { return m_uint16_IsDeleted; }
           set { this.m_uint16_IsDeleted = value; }
       }
      

       protected System.UInt16 Status
       {
           get { return m_uint16_Status; }
           set { this.m_uint16_Status = value; }
       }

       #endregion


   }
}
