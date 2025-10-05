using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
   public class MenuPermission : SilkERP360.CCL.Validation.ValidationBase
   {
       #region public CONSTRUCTOR
       public MenuPermission()
       {

       }
       #endregion

       protected System.UInt64 m_ui64_UserModuleMenusCode;
       protected System.UInt64 m_ui64_ModuleCode;
       protected System.UInt64 m_ui64_UserCode;
       protected System.UInt64 m_ui64_MenuCode;
       protected System.String m_str_MenuName;      
       protected System.String m_str_MenuType;      
       protected System.UInt16 m_ui16_IsDeleted;
       protected System.UInt16 m_ui16_Status;


       public System.UInt64 UserModuleMenusCode
       {
           get { return m_ui64_UserModuleMenusCode; }
           set { this.m_ui64_UserModuleMenusCode = value; }
       }


       public System.UInt64 ModuleCode
       {
           get { return m_ui64_ModuleCode; }
           set { this.m_ui64_ModuleCode = value; }
       }


       public System.UInt64 UserCode
       {
           get { return m_ui64_UserCode; }
           set { this.m_ui64_UserCode = value; }
       }


       public System.UInt64 MenuCode
       {
           get { return m_ui64_MenuCode; }
           set { this.m_ui64_MenuCode = value; }
       }
       public System.String MenuName
       {
           get { return m_str_MenuName; }
           set { m_str_MenuName = value; }
       }
       public System.String MenuType
       {
           get { return m_str_MenuType; }
           set { m_str_MenuType = value; }
       }

       public System.UInt16 IsDeleted
       {
           get { return m_ui16_IsDeleted; }
           set { this.m_ui16_IsDeleted = value; }
       }


       public System.UInt16 Status
       {
           get { return m_ui16_Status; }
           set { this.m_ui16_Status = value; }
       }


   }
}
