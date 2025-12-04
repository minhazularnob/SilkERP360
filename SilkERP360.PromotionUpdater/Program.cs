using Oracle.ManagedDataAccess.Client;
using SilkERP360.CCL.Enums;
using SilkERP360.DAL;
using System;

namespace SilkERP360.PromotionUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = DALObjectPoolManager.CONNECTION_STRING;
            var executor = new PromotionUpdater(connStr);
            executor.ExecutePromotionsAndIncrement();
        }
    }
}