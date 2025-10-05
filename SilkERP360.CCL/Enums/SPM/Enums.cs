using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Enums.SPM
{

    public enum ScratchCardHRNCover
    {
        None = 0,
        SingleLabel = 1,
        SandwichLabel = 2,
        FlexoLabel = 3
    }

    public enum SPMProductType
    {
        None = 0,
        SIM = 1,
        ScratchCard = 2,
        BankCard = 3
    }

    public enum SimChipType
    {
        None = 0,
        Native = 1,
        Java = 2
    }

    public enum SimChipSize
    {
        None = 0,
        k16 = 1,
        k32 = 2,
        k64 = 3,
        k128 = 4
    }

    public enum SCPackagedBoxStatus
    {
        None = 0,
        /// <summary>
        /// Data Has been Uploaded. 
        /// Card is personalizeable
        /// </summary>
        Initialized = 1,
        /// <summary>
        /// All cards in the Box has been personalized
        /// Updated after Perso ISO
        /// Box is Packageable
        /// </summary>
        Personalized = 2,
        /// <summary>
        /// All cards have been packaged in the box
        /// After packaging ISO
        /// Box is deliverable
        /// </summary>
        BoxDeliverable = 3,
        /// <summary>
        /// Box has been Packaged but delivery has been heldup
        /// </summary>
        HeldUpDelivery = 4,
        /// <summary>
        ///Box Delivered. Updated after delivery chalan
        /// </summary>
        Delivered = 5
    }

    public enum SCCardStatus
    {
        None = 0,
        /// <summary>
        /// Card data has been uploaded
        /// Card waiting to be personalized
        /// </summary>
        Initialized = 1,
        /// <summary>
        /// Card has been Personalized.
        /// Updated after Perso ISO
        /// Card is packagable
        /// </summary>
        Personalized = 2,
        /// <summary>
        /// Card has been packaged into a box
        /// Card is deliverable
        /// </summary>
        Packaged = 3,
        /// <summary>
        /// Card has been delivered
        /// </summary>
        Delivered = 4
    }

    public enum ScratchCardDenomination
    {
        None = 0,
        OneInOne = 1,
        TwoInOne = 2,
        ThreeInOne = 3,
        FourInOne = 4,
        FiveInOne = 5,
        SixInOne = 6,
        SevenInOne = 7,
        EightInOne = 8,
        NineInOne = 9,
        TenInOne = 10
    }

    public enum SpmMeasurementUnit
    {
        None = 0,
        Piece = 1,
        PIN = 2,
        Sheet = 3
    }

    public enum DeliveryStatus
    {
        None = 0,
        Complete = 1,
        Incomplete = 2
    }
}