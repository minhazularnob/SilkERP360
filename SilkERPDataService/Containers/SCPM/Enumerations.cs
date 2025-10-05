using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.Containers.SCPM
{
    public enum MachineMeasurementUnit
    {
        Piece = 1,Sheet = 2
    }

    public enum MachineOperationalStatus
    {
        Off = 0, On = 1, ServiceIntervention = 2
    }

    public enum DailySCPMMachineStatus
    {
        MachineUp = 0,
        ShiftOff = 1,
        MachineDownErrorCondition = 2,
        MachineDownDeficientInput = 3,
        MachineDownDeficientOrder = 4,
        MachineDownDeficientSparePart = 5
    }
}