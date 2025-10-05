using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.FL.ServiceProviders.WPMS
{
    public class PantoneCodeSP : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public PantoneCodeSP()
        {
            this.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_obj_PantoneColor"></param>
        /// <returns></returns>
        public SilkERP360.CCL.Misc.WSResponse SavePantoneColor(SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor IP_obj_PantoneColor)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = null;
            lcl_obj_WSResponse = this.ExceptionManager.Process<SilkERP360.CCL.Misc.WSResponse>(() =>
            {
                SilkERP360.BML.WPMS.PantoneColorManager lcl_obj_PantoneColorManager = new BML.WPMS.PantoneColorManager();
                System.UInt64 lcl_ui64_PantonColorCode =  lcl_obj_PantoneColorManager.Save(IP_obj_PantoneColor);
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponseTmp = new CCL.Misc.WSResponse(SilkERP360.CCL.Enums.WebServiceExecutionStatus.Success, 0, "Pantone Color Saved Successfully in the Database!!!", true, null);
                return lcl_obj_WSResponseTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_WSResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_PantoneCode">
        /// Pantone Code
        /// Exmp:
        /// Green : 354C
        /// </param>
        /// <returns></returns>
        public SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor GetPantoneColorByPantoneCode(System.String IP_str_PantoneCode)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColor = null;
            lcl_obj_PantoneColor = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM WPMS_PANTONE_COLORS WHERE PANTONE_COLOR = '{0}'", IP_str_PantoneCode);
                SilkERP360.BML.WPMS.PantoneColorManager lcl_obj_PantoneColorManager = new BML.WPMS.PantoneColorManager();
                SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColorTmp = lcl_obj_PantoneColorManager.Get(lcl_str_SqlQuery);
                return lcl_obj_PantoneColorTmp;
            }, "FLExceptionPolicy");
            return lcl_obj_PantoneColor;
        }
    }
}
