using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace SilkERP360.CCL.Validation
{
    [System.AttributeUsage(AttributeTargets.Field)]
    public class DBColumnAttribute : System.Attribute
    {
        public System.String FieldName { get; set; }
        public System.Data.OracleClient.OracleType DataType { get; set; }
    }
}
