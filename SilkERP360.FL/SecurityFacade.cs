using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL
{
    public class SecurityFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SecurityFacade()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }
        public System.String GenerateSecurityToken()
        {
            System.String lcl_str_Token = System.String.Empty;
            lcl_str_Token = this.ExceptionManager.Process<System.String>(() =>
                {
                    SilkERP360.BML.SecurityManager lcl_obj_SecurityManager = new SilkERP360.BML.SecurityManager();
                    return lcl_obj_SecurityManager.GenerateSecurityToken();
                }, "FLExceptionPolicy");
            return lcl_str_Token;
        }
    }
    
    
}
