using Newtonsoft.Json.Linq;
using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.ModelClass;
using SilkERP360.CCL.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;



namespace SilkERP360.BML.HRIS
{
    public class EmployeeTaxManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        CommonManager _commonManager = new CommonManager();
        bool sendSms = GlobalFlags.SendSms;
        bool sendMail = GlobalFlags.SendMail;

        public EmployeeTaxManager()
        {
            this.Initialize();

        }

        public ulong SaveEmployeeTax(List<EmployeeTax> employeeTaxes)
        {
            return this.ExceptionManager.Process<ulong>(() =>
            {
                using (var dbManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (dbManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        dbManager.InternalResource.Open();

                    foreach (var employeeTax in employeeTaxes)
                    {
                        if (employeeTax.TaxCode == null) // Insert new record
                        {
                            // Get the max tax_code from Employee_tax
                            string maxCodeSql = "SELECT NVL(MAX(tax_code), 1200000000) FROM Employee_tax";
                            object result = dbManager.InternalResource.ExecuteScalar(maxCodeSql);
                            ulong newTaxCode = Convert.ToUInt64(result) + 1;

                            string sqlInsert = $"INSERT INTO Employee_tax (tax_code, Employee_code, tax_amount, is_tax_deduction) " +
                                               $"VALUES ({newTaxCode}, {employeeTax.EmployeeCode}, {employeeTax.TaxAmount}, {employeeTax.IsTaxDeduction})";

                            dbManager.InternalResource.ExecuteScalar(sqlInsert);
                        }
                        else // Update existing record
                        {
                            string updateSql = $"UPDATE Employee_tax SET tax_amount = {employeeTax.TaxAmount}, " +
                                               $"is_tax_deduction = {employeeTax.IsTaxDeduction} " +
                                               $"WHERE Employee_code = {employeeTax.EmployeeCode}";

                            dbManager.InternalResource.ExecuteScalar(updateSql);
                        }

                    }
                    dbManager.InternalResource.CommitTransaction();
                    return 1; // just a dummy value for success
                }
            }, "BMLExceptionPolicy");
        }
        public List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax> GetEmployeeTaxList(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Execute reader
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax> employeeTaxList = new List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax>();

                        if (!lcl_obj_dr.HasRows)
                        {
                            return employeeTaxList;
                        }

                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax();

                            // Safe parsing
                            item.TaxCode = lcl_obj_dr["tax_code"] != DBNull.Value? Convert.ToUInt64(lcl_obj_dr["tax_code"]) : (UInt64?)null;
                            item.EmployeeCode = Convert.ToUInt64(lcl_obj_dr["employee_code"]);
                            item.EmployeeId = Convert.ToString(lcl_obj_dr["employee_id"]);
                            item.EmployeeName = Convert.ToString(lcl_obj_dr["employee_name"]);
                            item.IsTaxDeduction = Convert.ToUInt16(lcl_obj_dr["is_tax_deduction"]);
                            item.TaxAmount = Convert.ToDecimal(lcl_obj_dr["tax_amount"]);
                            item.TaxAmount = Convert.ToDecimal(lcl_obj_dr["tax_amount"]);
                            item.Basic = Convert.ToDecimal(lcl_obj_dr["basic"]);
                            item.Gross = Convert.ToDecimal(lcl_obj_dr["gross"]);

                            employeeTaxList.Add(item);
                        }

                        return employeeTaxList;
                    }
                }
            }, "BMLExceptionPolicy");
        }
    }
}