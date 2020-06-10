using System;

namespace EX3
{
    public class ElectricEngine
    {
        private float remainingTimeOfEngineHours;
        private float maxTimeOfEngineHours;
        
        public float MaxTimeOfEngineHours
        {
            get
            {
                return  maxTimeOfEngineHours;
            }
            set
            {
                maxTimeOfEngineHours = value;   
            }
        }

        public float RemainingTimeOfEngineHours
        {
            get
            {
                return  remainingTimeOfEngineHours;
            }
            set
            {
                remainingTimeOfEngineHours = value;   
            }
        }

        public void RechargeOperation(float hoursToChargeEngine)
        {
            if (hoursToChargeEngine + remainingTimeOfEngineHours > maxTimeOfEngineHours)
            {
                throw new ArgumentException("Unable to charge engine because more than max time to charge.");
            }
        }
    }
}