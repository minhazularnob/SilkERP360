using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.UI
{
    public class UserProfileFacade : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public UserProfileFacade()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        public SilkERP360.CCL.BusinessEntities.UI.UserProfile CreateProfileForUser(System.UInt64 IP_ui64_UserCode)
        {
            SilkERP360.CCL.BusinessEntities.UI.UserProfile lcl_obj_UserProfile = null;
            lcl_obj_UserProfile = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.UserProfile>(() =>
                {
                    using (SilkERP360.BML.UI.UserProfileManager lcl_obj_UserProfileManager = new SilkERP360.BML.UI.UserProfileManager())
                    {
                        lcl_obj_UserProfile = lcl_obj_UserProfileManager.CreateProfileForUser(IP_ui64_UserCode);
                    }
                    return lcl_obj_UserProfile;
                }, "FLExceptionPolicy");
            return lcl_obj_UserProfile;
        }
    }
}
