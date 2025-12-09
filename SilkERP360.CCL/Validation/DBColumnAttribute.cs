using System;
using Oracle.ManagedDataAccess.Client;


namespace SilkERP360.CCL.Validation
{
    [System.AttributeUsage(AttributeTargets.Field)]
    public class DBColumnAttribute : System.Attribute
    {
        public System.String FieldName { get; set; }
        public OracleDbType DataType { get; set; }
    }
}
