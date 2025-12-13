using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class IncrementAndPromotionHistory
    {
        public UInt64 EmployeeCode { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PreviousDesignation { get; set; }
        public string NewDesignation { get; set; }
        public DateTime ? PromotionEffectiveDate { get; set; }
        public string Type { get; set; }
        public decimal? PreviousGross { get; set; }
        public decimal? IncGross { get; set; }
        public decimal? IncBasic { get; set; }
        public decimal? IncHouseRent { get; set; }
        public decimal? IncConveyance { get; set; }
        public decimal? IncMedical { get; set; }
        public decimal? IncEntertainment { get; set; }
        public int? IncEffectiveMonth { get; set; }
        public int? IncEffectiveYear { get; set; }
    }
}
