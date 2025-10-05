using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SALARY_ADDITION_DEDUCTION","SALARY_ADDITION_DEDUCTION_SEQ")]
    public class SalaryAdditionDeduction : SilkERP360.CCL.Validation.ValidationBase
    {
       
       #region CONSTRUCTOR
       public SalaryAdditionDeduction()
       {
           this.m__AdditionalData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
       }
       #endregion

       #region PEOTECTED VARIABLES
       
       [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADD_DED_CODE",typeof(System.UInt64),false,false)]
       protected System.UInt64 m_ui64_SalaryAddDedCode;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
       protected System.UInt64 m_ui64_EmployeeCode;

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADD_OR_DED", typeof(SilkERP360.CCL.Enums.AdditionOrDeduction), false, false)]
       protected SilkERP360.CCL.Enums.AdditionOrDeduction m_enm_AdditionOrDeduction;

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADD_DED_TYPE", typeof(SilkERP360.CCL.Enums.AdditionDeductionType), false, false)]
       protected SilkERP360.CCL.Enums.AdditionDeductionType m_enm_AdditionDeductionType;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("AMOUNT", typeof(System.Decimal), false, false)]
       protected System.Decimal m_dcm_Amount;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADD_DED_DATE", typeof(System.DateTime), false, false,SilkERP360.CCL.DatabaseMapping.DateTimeFormat.DateOnly)]
       protected System.DateTime m_dt_AdditionDeductionDate;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), false, false)]
       protected System.String m_str_Remarks;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_MONTH", typeof(SilkERP360.CCL.Enums.Month), false, false)]
       protected SilkERP360.CCL.Enums.Month m_enm_EffectiveMonth;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_YEAR", typeof(System.UInt64), false, false)]
       protected System.UInt16 m_ui16_EffectiveYear;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PROCESSED", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
       protected SilkERP360.CCL.Enums.YesNo m_enm_IsProcessed;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.Status), false, false)]
       protected System.UInt16 m_ui16_Status;
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
       protected System.UInt64 m_ui64_EntryEmployeeCode;
        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADD_OR_DED", typeof(SilkERP360.CCL.Enums.AdditionOrDeduction), false, false)]
       protected System.DateTime m_dt_EntryDate;
       /// <summary>
       /// Will contain data to be used by Clients or Charts
       /// </summary>
       protected System.Collections.Generic.Dictionary<System.String, System.Object> m__AdditionalData;
      
       #endregion

       #region PUBLIC PROPERTIES
       public System.UInt64 EmployeeCode
       {
           get { return m_ui64_EmployeeCode; }
           set { this.m_ui64_EmployeeCode = value; }
       }

       public System.UInt64 SalaryAddDedCode
       {
           get { return m_ui64_SalaryAddDedCode; }
           set { this.m_ui64_SalaryAddDedCode = value; }
       }



       public SilkERP360.CCL.Enums.AdditionOrDeduction AdditionOrDeduction
       {
           get { return m_enm_AdditionOrDeduction; }
           set { this.m_enm_AdditionOrDeduction = value; }
       }
       public SilkERP360.CCL.Enums.AdditionDeductionType AdditionDeductionType
       {
           get { return m_enm_AdditionDeductionType; }
           set { this.m_enm_AdditionDeductionType = value; }
       }


       public System.Decimal Amount
       {
           get { return m_dcm_Amount; }
           set { this.m_dcm_Amount = value; }
       }


       public System.DateTime AdditionDeductionDate
       {
           get { return m_dt_AdditionDeductionDate; }
           set 
           {
               //System.DateTime.TryParse(value.ToString(), out this.m_dt_AdditionDeductionDate);
               this.m_dt_AdditionDeductionDate = value; 
           }
       }


       public System.String Remarks
       {
           get { return m_str_Remarks; }
           set { this.m_str_Remarks = value; }
       }


       public SilkERP360.CCL.Enums.Month EffectiveMonth
       {
           get { return m_enm_EffectiveMonth; }
           set { this.m_enm_EffectiveMonth = value; }
       }


       public System.UInt16 EffectiveYear
       {
           get { return m_ui16_EffectiveYear; }
           set { this.m_ui16_EffectiveYear = value; }
       }


       public SilkERP360.CCL.Enums.YesNo IsProcessed
       {
           get { return m_enm_IsProcessed; }
           set { this.m_enm_IsProcessed = value; }
       }


       public System.UInt16 Status
       {
           get { return m_ui16_Status; }
           set { this.m_ui16_Status = value; }
       }


       public System.UInt64 EntryEmployeeCode
       {
           get { return m_ui64_EntryEmployeeCode; }
           set { this.m_ui64_EntryEmployeeCode = value; }
       }


       public System.DateTime EntryDate
       {
           get { return m_dt_EntryDate; }
           set 
           {
               //System.DateTime.TryParse(value.ToString(), out this.m_dt_EntryDate);
               this.m_dt_EntryDate = value; 
           }
       }
       public System.Collections.Generic.Dictionary<System.String, System.Object> _AdditionalData
       {
           get { return m__AdditionalData; }
           set { m__AdditionalData = value; }
       }
       #endregion
      
    }
}
