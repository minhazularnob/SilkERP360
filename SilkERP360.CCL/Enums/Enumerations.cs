using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Enums
{

    public enum WellpacSection
    {
        AllSection = 0,
        ProductionSupervision = 1,
        Mixing = 2,
        Blowing = 3,
        Cutting = 4,
        Packaging = 5,
        Recycle = 6,
        ManualWork = 7
    }

    public enum OutpassType
    {
        None = 0,
        /// <summary>
        /// Employee is going out for personal/official business
        /// and he/she will be back again
        /// </summary>
        Temporary = 1,
        /// <summary>
        /// Employee is going out and will not be back again
        /// on the day
        /// </summary>
        Permanent = 2
    }

    public enum ProvidentFundAccountStatus
    {
        None = 0,
        Active = 1,
        Settled = 2
    }
    public enum ProvidentFundTransactionType
    {
        None = 0,
        EmployeeContribution = 1,
        EmployeersContribution = 2,
        Interest = 3,
        Profit = 4,
        /// <summary>
        /// Amount Will be Negative for ExpenseDeduction
        /// </summary>
        ExpenseDeduction = 5
    }

    public enum BonusOccasion
    {
        None = 0,
        EidUlFitr = 1,
        EidUlAzha = 2
    }

    public enum AutobotPenaltyType
    {
        None = 0,
        WorkGroupStatusAND = 1
    }

    public enum WorkGroup
    {
        //Silkcard WorkGroup
        SCExecutive = 1001,
        SCExecutiveWOH = 1002,
        SCProductionD = 1003,
        SCProductionN = 1004,
        SCProductionDWOH = 1005,
        SCProductionNWOH = 1006,
        //Wellpac WorkGroup
        WPExecutive = 2001,
        WPProductionD = 2002,
        WPProductionN = 2003,
    }

    public enum OvertimeEntryType
    {
        None = 0,Automated = 1, Manual = 2
    }

    public enum LeaveType
    {
        None = 0,CL = 1,SL = 2,ML = 3,EL = 4
    }

    public enum LeaveCategory
    {
        None = 0, Paid = 1, Unpaid = 2
    }

    public enum Currency
    {
        BDT = 1, DOLLAR = 2, POUND = 3, EURO = 4
    }
    public enum SCProductionProcess
    {
        Printing = 901,Punching = 902,Milling = 903,Embedding = 904,PlugInPunch = 905, Personalization = 906
    }
    
    public enum AdditionOrDeduction
    {
        Addition = 1,
        Deduction = 2
    }

    public enum SalaryStatus
    {
        None = 0,
        Released = 1,
        HeldUp = 2
    }

    public enum AdditionDeductionType
    {
        None = 0,
        /// <summary>
        /// If Employee Taken any Loan, monthly installament payment
        /// </summary>
        DeductionAdvance = 1,
        DeductionPenalty = 2,
        DeductionIncomeTax = 3,
        DeductionLate = 4,
        DeductionUnpaidLeave = 5,
        DeductionAbsent = 6,
        DeductionOthers = 7,
        DeductionProvidentFund = 8,
        DeductionUniform = 9,
        //DeductionArrear = 9,
        //8-20 Reserved for future use
        AdditionArrear = 21,
        AdditionBonus = 22,
        AdditionPhoneBill = 23,
        AdditionIncentive = 24,
        AdditionAllowance = 25,
        AdditionOthers = 26,
        AdditionNightAllowance = 27,
        AdditionMonthlyAllowance = 28
    }

    public enum CompanyCode : ulong
    {
        Silkcard = (System.UInt64)110000000001,
        Welpac = (System.UInt64)110000000002
    }

    public enum AccessControlFileType
    {
        ProximitySystem = 0,
        BiometricSystem = 1
    }

    public enum AccessControlTransactionType
    {
        Ca = 0,//Valid Card Access
        Cb = 1 //Valid Card Exit
    }

    //public enum ExceptionCategory
    //{
    //    None=0,
    //    DBServerConnection = 1,
    //    DBOperation = 2,
    //    Validation = 3
    //}

    //public enum ErrorGenerator
    //{
    //    USER = 1,
    //    SYSTEM = 2
    //}

    //public enum ModuleCode
    //{
    //    HRIS=101,GL=102
    //}

    /// <summary>
    /// From Which Layer an Exception Originated From
    /// </summary>
    public enum ExceptionOriginatorLayer
    {
        DAL = 0,
        BML = 1,
        FL = 2,
        SL = 3,
        UI = 4,
        CCL = 5
    }

    /// <summary>
    /// Generic Type of Exception
    /// </summary>
    public enum ExceptionType
    {
        UserGeneratedException = 0,
        DatabaseServerException = 1,
        ValidationException = 2,
        CriticalSystemException = 3
    }

    public enum WebServiceExecutionStatus
    {
        Success = 0,
        Error = 1,
        DBServerConnectionError = 2,
        DBOperationError = 3,
        CriticalError = 4
    }
    public enum FunctionExecutionStatus
    {
        Success = 0, //Method Execution Successful And If out put requested, out found
        SuccessError = 1, //Method Execution Successful But Requested Data Not Found
        ValidationError = 2, 
        Error = 3,
        DatabaseConnectionError = 4,
        DatabaseOperationError = 5,
        CriticalError = 6
    }

    public enum Status
    {
        InActive = 0,
        Active = 1
    }
    public enum EmployeeStatus
    {
        Regular=0,
        Temporary=1,
        Probation=2,
        Resigned=3,
        Suspended=4,
        Terminated=5,
        Retired=6
    }
    public enum YesNo
    {
        Yes = 1, 
        No = 0
    }

    public enum WeekDay
    {
        None = 0,
        Saturday = 1, 
        Sunday = 2, 
        Monday = 3, 
        Tuesday = 4, 
        Wednesday = 5, 
        Thursday = 6, 
        Friday = 7
    }

    public enum Month
    {
        January = 1, 
        February = 2, 
        March = 3, 
        April = 4, 
        May = 5, 
        June = 6, 
        July = 7, 
        August = 8, 
        September = 9, 
        October = 10,
        November = 11,
        December = 12
    }

    public enum AttendanceStatus
    {
        NONE = 0,
        PRESENT = 1, 
        ABSENT = 2, 
        LATE = 3, 
        LATE_APPROVED = 4,
        HOLIDAY = 5, 
        ON_LEAVE = 6,
        WEEKEND = 7,
        WORK_ON_HOLIDAY = 8,
        OUTSIDE_DUTY = 9, //Outside Duty
        REPLACEMENT_DUTY = 10,
        ON_FOREIGN_TOUR = 11,
        /// <summary>
        /// When employees WorkGroupData Not Found, LeaveApplication Not Found
        /// </summary>
        ABSENT_NO_DATA_FOUND = 12,
        /// <summary>
        /// Was originally Absent, but overridden to Present
        /// </summary>
        ABSENT_OVERRIDDEN_PRESENT = 13,
        SHIFT_CHANGE_HOLIDAY = 14
    }

    public enum AttendanceEntryType
    {
        ACS = 0,//Promixity Access Control System
        BMS = 1, //Bio-Metric Access Control System
        MANUAL = 2 //Manual
    }

    public enum WorkGroupOperationalStatus
    {
        NotYetInitialized = 0,
        On = 1,
        Off = 2,
        HolidayOff = 3,
        WeekendOff = 4,
        ScheduledOff = 5,
        DutyOnHoliday = 6, //OT Eligible employees will get full OT
        ShiftChangeDuty = 7,
        ShiftChangeOff = 8
    }

    /// <summary>
    /// To be used for field WORK_GROUP_OPERATION_HISTORY.ASSESSMENT_STATUS
    /// </summary>
    public enum AssessmentStatus
    {
        //None = 0,
        Regular = 0,
        LateArrivalRequested = 1,
        SickLeaveRequested = 2
    }

    /// <summary>
    /// Used to represent WORK_GROUP_OPERATION_MASTER.DAY_ATTRIBUTE
    /// </summary>
    public enum DayAttribute
    {
        RegularWorkingDay = 0,
        CasualWorkingDay = 1,
        GeneralStrikeWorkingDay = 2,
        RainyWorkingDay = 3,
        Weekend = 4,
        GovernmentHoliday = 5
    }

    public enum RosterOperationalStatus
    {
        On = 0,
        ShiftOff = 1,
        HolidayOff = 2,
        ShiftChangeDayOff = 3
    }

    /// <summary>
    /// Duty status of a rosterable employee
    /// </summary>
    public enum RosterDutyStatus
    {
        On=0,
        OnLeave = 1,
        ShiftOff = 2
    }

    /// <summary>
    /// Database operation type
    /// </summary>
    public enum TransactionType
    {

    }

    public enum OvertimeProcessingStatus
    {
        NotProcessed = 0,
        Processed = 1
    }

    public enum OperationType
    {
        Save = 1,
        Update = 2,
        Delete = 3,
        Get = 4
    }

    public enum ApproveStatus
    {
        Rejected = 0,
        Pending = 1,
        Approved = 2,
        Promoted = 3
    }
}