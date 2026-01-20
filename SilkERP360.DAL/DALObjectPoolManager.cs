using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.DAL
{
    /// <summary>
    /// A class to manage DBManager objects in the pool.
    /// This class is sealed to prevent further Inheritance
    /// and is based on Singleton pattern
    /// </summary>
    public static class DALObjectPoolManager
    {
        //public const string CONNECTION_STRING = "User Id=silkerp; Password=silkerp; Data Source=localhost:1522/ORCLPDB;";
        //private const System.String CONNECTION_STRING = "Data Source=ORCL; User Id=silkerp; Password=silkerp;";
        public const System.String CONNECTION_STRING = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.55)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl3)));User Id=silkerp;Password=silkerp;";

        //private const System.String CONNECTION_STRING = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.4)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DB)));User Id=silkerp;Password=silkerp;";
        //private const System.String CONNECTION_STRING = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=silkapp)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DB)));User Id=silkerp;Password=silkerp;";
        private static SilkERP360.CCL.ObjectPool.ObjectPool<SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>> m_obj_DBManagerPool = null;

        public static SilkERP360.CCL.ObjectPool.ObjectPool<SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>> DBManagerPool
        {
            get { return SilkERP360.DAL.DALObjectPoolManager.m_obj_DBManagerPool; }
            //set { DALObjectPoolManager.m_obj_DBManagerPool = value; }
        }
        /// <summary>
        /// static constructor that gets called only once throughout the lifetime of the application
        /// </summary>
        static DALObjectPoolManager()
        {
            SilkERP360.DAL.DALObjectPoolManager.m_obj_DBManagerPool = new SilkERP360.CCL.ObjectPool.ObjectPool<SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>>(() => new SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>(new SilkERP360.DAL.DBManager(SilkERP360.DAL.DALObjectPoolManager.CONNECTION_STRING)) { WrapperReleaseResourcesAction = (r) => SilkERP360.DAL.DALObjectPoolManager.ExternalResourceReleaseResource(r), WrapperResetStateAction = (r) => SilkERP360.DAL.DALObjectPoolManager.ExternalResourceResetState(r) });
        }

        public static void ExternalResourceResetState(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            // External Resource reset state code
            IP_obj_DBManager.Close();
            IP_obj_DBManager.Open();
        }

        public static void ExternalResourceReleaseResource(SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            // External Resource release code
        }
    }
}
