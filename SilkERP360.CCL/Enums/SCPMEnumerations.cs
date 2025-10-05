using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.SCPMEnumerations
{
    public enum Machines
    {
        Colamark1 = 1,
        Colamark2 = 2,
        Colamark3 = 3,
        Colamark4 = 4,
        Colamark5 = 5,
        Colamark6 = 6,
        Colamark7 = 7
    }

    public enum ScratchCardFaultType
    {
        PrintError = 1,
        LabelError = 2,
        OverprintError = 3,
        PhysicalError = 4,
        BarcodeError = 5
    }

    public enum ScratchCardMeasurementUnit
    {
        Sheet = 1,
        Card = 2
    }

    public enum JobOrderProductionStatus
    {
        Completed = 0,
        NotCompleted = 1
    }

    public enum Status
    {
        Active=1,
        InActive = 0
    }
    public enum MachineOperationalStatus
    {
        Active = 1,
        InActive = 0
    }

}