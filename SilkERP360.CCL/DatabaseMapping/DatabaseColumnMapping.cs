using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.DatabaseMapping
{
    /// <summary>
    /// Used to Map the Table Columns of the DB.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DatabaseColumnMapping : System.Attribute
    {
        /// <summary>
        /// Name of the DB Table Column Name
        /// </summary>
        protected System.String m_str_DatabaseColumnName;
        public System.String DatabaseColumnName
        {
            get { return m_str_DatabaseColumnName; }
            set { m_str_DatabaseColumnName = value; }
        }

        /// <summary>
        /// Data type of the DB Column
        /// </summary>
        protected System.Type m_typ_DataType;
        public System.Type DataType
        {
            get { return m_typ_DataType; }
            set { m_typ_DataType = value; }
        }

        /// <summary>
        /// If DataType is DateTime,
        /// Format Must be maintained
        /// </summary>
        protected SilkERP360.CCL.DatabaseMapping.DateTimeFormat m_enm_DateTimeFormat;
        public SilkERP360.CCL.DatabaseMapping.DateTimeFormat DateTimeFormat
        {
            get { return m_enm_DateTimeFormat; }
            set { m_enm_DateTimeFormat = value; }
        }

        /// <summary>
        /// Indicates if the field is nullable.
        /// True if field is nullable else False
        /// </summary>
        protected System.Boolean m_b_IsNull;
        public System.Boolean IsNull
        {
            get { return this.m_b_IsNull; }
            set { m_b_IsNull = value; }
        }

        /// <summary>
        /// True if Column is a PrimaryKey else False
        /// </summary>
        protected System.Boolean m_b_IsPrimaryKey;
        public System.Boolean IsPrimaryKey
        {
            get { return m_b_IsPrimaryKey; }
            set { m_b_IsPrimaryKey = value; }
        }

        public DatabaseColumnMapping(System.String IP_str_DatabaseColumnName,System.Type IP_obj_DataType,System.Boolean IP_b_IsPrimaryKey,System.Boolean IP_b_IsNull)
            : base()
        {
            this.m_str_DatabaseColumnName = IP_str_DatabaseColumnName;
            this.m_typ_DataType = IP_obj_DataType;
            this.m_b_IsPrimaryKey = IP_b_IsPrimaryKey;
            this.m_b_IsNull = IP_b_IsNull;
            this.DateTimeFormat = DatabaseMapping.DateTimeFormat.DateAndTime;
        }

        public DatabaseColumnMapping(System.String IP_str_DatabaseColumnName, System.Type IP_obj_DataType, System.Boolean IP_b_IsPrimaryKey, System.Boolean IP_b_IsNull,SilkERP360.CCL.DatabaseMapping.DateTimeFormat IP_enm_DateTimeFormat)
            : base()
        {
            this.m_str_DatabaseColumnName = IP_str_DatabaseColumnName;
            this.m_typ_DataType = IP_obj_DataType;
            this.m_b_IsPrimaryKey = IP_b_IsPrimaryKey;
            this.m_b_IsNull = IP_b_IsNull;
            this.DateTimeFormat = DatabaseMapping.DateTimeFormat.DateAndTime;
            this.m_enm_DateTimeFormat = IP_enm_DateTimeFormat;
        }
    }
}
