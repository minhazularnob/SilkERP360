using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Utils
{
    public class SMQCRandomGenerator
    {
        protected SilkERP360.CCL.Enums.SCPM.SMQCTestTypes m_enm_SMQCTestTypes;
        public SilkERP360.CCL.Enums.SCPM.SMQCTestTypes SMQCTestTypes
        {
            get { return this.m_enm_SMQCTestTypes; }
            set { this.m_enm_SMQCTestTypes = value; }
        }

        protected System.Int32 m_i32_BatchQuantity;
        public System.Int32 BatchQuantity
        {
            get { return this.m_i32_BatchQuantity; }
            set { this.m_i32_BatchQuantity = value; }
        }

        protected System.UInt16 m_ui16_StandardRandomPercentage;
        /// <summary>
        /// Defines what percentage of BatchQuantity needs to be tested for the selected QC type
        /// </summary>
        public System.UInt16 StandardRandomPercentage
        {
            get { return m_ui16_StandardRandomPercentage; }
            //set { m_ui32_StandardRandomPercentage = value; }
        }

        protected System.Collections.Generic.List<System.Int32> m_objLst_RandomSequences;
        public System.Collections.Generic.List<System.Int32> RandomSequences
        {
            get { return this.m_objLst_RandomSequences; }
        }

        /// <summary>
        /// Pre-Condition : SMQCTestTypes,BatchQuantity must be initialised
        /// Desc : 
        /// 1. Initialises RandomSequences List object and StandardRandomPercentage
        /// 2. Generates Random sequence and stores in RandomSequences list object
        /// </summary>
        public void GenerateRandomSequence()
        {
            try
            {
                this.m_objLst_RandomSequences = new System.Collections.Generic.List<System.Int32>();
                switch (this.m_enm_SMQCTestTypes)
                {
                    case Enums.SCPM.SMQCTestTypes.PeelOff:
                        this.m_ui16_StandardRandomPercentage = SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC.S_TEST_PERCENTAGE;
                        break;
                }
                //Calculate Number of Sheet/Cards needs to be tested for the BatchQuantity
                System.UInt16 lcl_ui16_NumberOfRandoms = (System.UInt16)((this.m_ui16_StandardRandomPercentage * this.m_i32_BatchQuantity) / 100);
                System.Random lcl_obj_Random = new System.Random();
                for (System.UInt32 i = 0; i < lcl_ui16_NumberOfRandoms; i++)
                {
                    System.Int32 lcl_i32_RandomNumber = lcl_obj_Random.Next(1, this.m_i32_BatchQuantity);
                    if (this.m_objLst_RandomSequences.Exists(e => e.Equals(lcl_i32_RandomNumber)))
                    {
                        i--;
                        continue;
                    }
                    this.m_objLst_RandomSequences.Add(lcl_i32_RandomNumber);
                }

                this.m_objLst_RandomSequences.Sort();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
