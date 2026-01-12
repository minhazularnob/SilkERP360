using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.IO;
using System.Web.UI;
namespace SilkERP360.UI.Base
{
    public class Command
    {
        #region Command functionality

        private string m_str_CommandName = "";

        public Command(System.String IP_str_CommandName)
        {
            this.m_str_CommandName = IP_str_CommandName;
        }

        public static Command Create(System.String IP_str_CommandName)
        {
            return new Command(IP_str_CommandName);
        }

        public System.Object Execute(System.Object IP_obj_Data)
        {
            System.Type lcl_obj_Type = this.GetType();
            System.Reflection.MethodInfo lcl_obj_Method = lcl_obj_Type.GetMethod(this.m_str_CommandName);
            System.Object[] args = new System.Object[] { IP_obj_Data };
            try
            {
                return lcl_obj_Method.Invoke(this, args);
            }
            catch (System.Exception ex)
            {
                // TODO: Add logging functionality
                throw ex;
            }
        }

        #endregion

        #region Public execution commands

        /// <summary>
        /// returns rendered control's string representation.
        /// object "data" should be passed from javascript method 
        /// as array of objects consisting of two objects,
        /// first - pageID - integer identificator by which we will
        /// lookup real control path; second object may be some data
        /// that the control needs.
        /// </summary>
        public System.Object GetWizardPage(System.Object IP_obj_Data)
        {
            bool errorLogged = false;
            try
            {
                Dictionary<string, object> param = (Dictionary<string, object>)IP_obj_Data;
                int pageID = (int)param["pageID"];
                object customData = param["data"];

                string controlPath = "~/EmployeeEdit/UI/EditEmployee.ascx";
                    //m_NavigationData.Find(x => x.Key == pageID).Value;

                if (!String.IsNullOrEmpty(controlPath))
                {
                    if (
                        controlPath.ToLower()
                        .EndsWith(".htm")
                        ||
                        controlPath.ToLower()
                        .EndsWith(".html")
                        ||
                        controlPath.ToLower()
                        .EndsWith(".txt"))
                    {
                        string result = "";
                        using (TextReader tr = new StreamReader(HttpContext.Current.Server.MapPath(controlPath)))
                        {
                            result = tr.ReadToEnd();
                        }
                        return new SilkERP360.UI.Base.ContentsResponse(result, string.Empty, string.Empty);
                    }
                    else
                    {
                        return SilkERP360.UI.Base.SilkViewManager.RenderView(controlPath, customData);
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Log error
                errorLogged = true;
            }
            if (!errorLogged)
            {
                // Log custom error saying 
                // we did not find the page
            }
            return ContentsResponse.Empty;
        }

        #endregion

        #region Wizard Navigation

        /*private static List<KeyValuePair<int, string>>
            m_NavigationData = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1,Pages.Controls.Welcome),
                new KeyValuePair<int, string>(2,Pages.Controls.AcceptLicenceAgreement),
                new KeyValuePair<int, string>(3,Pages.Controls.PleaseClickProceedButton),
                new KeyValuePair<int, string>(4,Pages.Controls.ConfirmationMessage),
                new KeyValuePair<int, string>(5,Pages.Controls.Installing),
                new KeyValuePair<int, string>(6,Pages.Controls.ThankYouMessage)
            };*/

        #endregion
    }
}