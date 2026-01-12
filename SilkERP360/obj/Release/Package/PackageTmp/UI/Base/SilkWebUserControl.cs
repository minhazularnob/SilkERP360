using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SilkERP360.UI.Base
{
    public abstract class SilkWebUserControl : System.Web.UI.UserControl
    {
        private object m_Data = null;

        public object Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        private string m_StartupScript = string.Empty;

        public string StartupScript
        {
            get { return m_StartupScript; }
            set { m_StartupScript = value; }
        }

        private string m_CustomStyleSheet = string.Empty;

        public string CustomStyleSheet
        {
            get { return m_CustomStyleSheet; }
            set { m_CustomStyleSheet = value; }
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