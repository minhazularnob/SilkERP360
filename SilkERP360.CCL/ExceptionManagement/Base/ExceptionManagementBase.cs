using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace SilkERP360.CCL.ExceptionManagement.Base
{
    /// <summary>
    /// any class that wish to have ExceptionManagement capability for its code, must inherit from this class
    /// </summary>
    public abstract class ExceptionManagementBase : SilkERP360.CCL.ObjectPool.PooledObject
    {
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

        //private SilkERP360.CCL.Misc.UserContext m_obj_UserContext;
        //public SilkERP360.CCL.Misc.UserContext UserContext
        //{
        //    get { return this.m_obj_UserContext; }
        //    //set { lcl_obj_UserContext = value; }
        //}

        /// <summary>
        /// Derived classes must call this method
        /// </summary>
        public void Initialize()
        {
            //var lcl_obj_Container = new UnityContainer();
            //lcl_obj_Container.AddNewExtension<EnterpriseLibraryCoreExtension>();
            //ExceptionManager lcl_obj_ExceptionManager = lcl_obj_Container.Resolve<ExceptionManager>();
            
            this.m_obj_UnityContainer = new UnityContainer();
            this.m_obj_UnityContainer.AddNewExtension<EnterpriseLibraryCoreExtension>();
            this.m_obj_ExceptionManager = this.m_obj_UnityContainer.Resolve<ExceptionManager>();
            //this.m_obj_ExceptionManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
            //this.m_obj_UserContext = IP_obj_UserContext;
        }


    }
}
