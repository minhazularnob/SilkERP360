using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeeTax : ValidationBase
    {
        public EmployeeTax()
        {

        }

        public UInt64 EmployeeCode { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public UInt64? TaxCode { get; set; }
        public int IsTaxDeduction { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal? Basic { get; set; }
        public decimal? Gross { get; set; }
    }
}