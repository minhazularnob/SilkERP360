using System;
using Oracle.ManagedDataAccess.Client;
namespace SilkERP360.CCL.Validation
{
    [System.AttributeUsage(AttributeTargets.Field)]
    class DBProcedureParameterAttribute : System.Attribute
    {
        public System.UInt32 Order { get; set; }
        public System.String ParameterName { get; set; }
        public OracleDbType DataType { get; set; }
        public System.Data.ParameterDirection ParameterDirection;
    }
}
