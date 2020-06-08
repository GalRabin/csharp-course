using System;

namespace EX3
{
    public class ElectricEngine
    {
        private float remainingTimeOfEngineHours;
        private float maxTimeOfEngineHours;

        public ElectricEngine(float remainingTimeOfEngineHours, float maxTimeOfEngineHours)
        {
            this.remainingTimeOfEngineHours = remainingTimeOfEngineHours;
            this.maxTimeOfEngineHours = maxTimeOfEngineHours;
        }

        public float RemainingTimeOfEngineHours => remainingTimeOfEngineHours;

        public float MaxTimeOfEngineHours => maxTimeOfEngineHours;

        public void RechargeOperation(float hoursToChargeEngine)
        {
            //TODO implement, throw error if not successfull
        }
    }
}