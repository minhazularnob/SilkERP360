using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SilkERP360.CCL.Misc
{
    /// <summary>
    /// Contains detail data about a web service
    /// </summary>
    public abstract class SilkWebService : System.Web.Services.WebService
    {
        private readonly System.String m_str_WebServiceCode;
        public System.String WebServiceCode
        {
            get { return this.m_str_WebServiceCode; }
        }

        private Microsoft.Practices.Unity.UnityContainer m_obj_UnityContainer;
        public Microsoft.Practices.Unity.UnityContainer UnityContainer
        {
            get { return this.m_obj_UnityContainer; }
            //set { m_obj_UnityContainer = value; }
        }


        private Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionManager m_obj_ExceptionManager = null;
        public Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionManager ExceptionManager
        {
            get { return this.m_obj_ExceptionManager; }
            //set { this.m_obj_ExceptionManager = value; }
        }
        /// <summary>
        /// Derived classes must call this method
        /// </summary>
        public void Initialize()
        {
            this.m_obj_UnityContainer = new UnityContainer();
            this.m_obj_UnityContainer.AddNewExtension<EnterpriseLibraryCoreExtension>();
            this.m_obj_ExceptionManager = this.m_obj_UnityContainer.Resolve<ExceptionManager>();
         }
    }
}
