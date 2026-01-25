using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.PromotionUpdater
{
    public class Common
    {
        public void ExecuteNonQuery(OracleConnection conn, OracleTransaction tran, string sql)
        {
            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
