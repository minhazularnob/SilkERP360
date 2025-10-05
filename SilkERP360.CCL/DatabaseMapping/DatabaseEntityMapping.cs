using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.DatabaseMapping
{
    /// <summary>
    /// Used to Map a Class to the Corresponding Table in the Database
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DatabaseEntityMapping : System.Attribute
    {
        /// <summary>
        /// Name of the Corresponding Database Table
        /// </summary>
        protected System.String m_str_DatabaseTableName;
        public System.String DatabaseTableName
        {
            get { return m_str_DatabaseTableName; }
            set { m_str_DatabaseTableName = value; }
        }

        /// <summary>
        /// Every Database table has a Sequence defined which is used to generate the PrimaryKey.
        /// This field contains the name of the Sequence which has already been created in the database.
        /// </summary>
        protected System.String m_str_DatabaseSequence;
        public System.String DatabaseSequence
        {
            get { return m_str_DatabaseSequence; }
            set { m_str_DatabaseSequence = value; }
        }

        public DatabaseEntityMapping(System.String IP_str_DatabaseTableName, System.String IP_str_SequenceName)
            : base()
        {
            this.m_str_DatabaseTableName = IP_str_DatabaseTableName;
            this.m_str_DatabaseSequence = IP_str_SequenceName;
        }
    }
}
