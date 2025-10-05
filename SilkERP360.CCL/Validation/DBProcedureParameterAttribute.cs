using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
namespace SilkERP360.CCL.Validation
{
    [System.AttributeUsage(AttributeTargets.Field)]
    class DBProcedureParameterAttribute : System.Attribute
    {
        public System.UInt32 Order { get; set; }
        public System.String ParameterName { get; set; }
        public System.Data.OracleClient.OracleType DataType { get; set; }
        public System.Data.ParameterDirection ParameterDirection;
    }
}
