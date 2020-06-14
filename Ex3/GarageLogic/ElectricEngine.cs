using System;

namespace EX3
{
    public class ElectricEngine
    {
        private float m_RemainingTimeOfEngineHours;
        private float m_MaxTimeOfEngineHours;
        
        public float MaxTimeOfEngineHours
        {
            get
            {

                return  m_MaxTimeOfEngineHours;
            }
            set
            {
                m_MaxTimeOfEngineHours = value;   
            }
        }

        public float RemainingTimeOfEngineHours
        {
            get
            {

                return  m_RemainingTimeOfEngineHours;
            }
            set
            {
                if (value > m_RemainingTimeOfEngineHours)
                {
                    throw new System.Exception("Remain time of battery can not be more than her life time, " + this.m_MaxTimeOfEngineHours);
                }

                m_RemainingTimeOfEngineHours = value;   
            }
        }

        public string getInfo()
        {
            string str = string.Format(
                "Maximum life time battery: {0}\n" +
                "Time remain for empty battery: {1}\n",
                this.m_MaxTimeOfEngineHours,
                this.m_RemainingTimeOfEngineHours);

            return str;
        }
        public void RechargeOperation(float i_HoursToChargeEngine)
        {
            if (i_HoursToChargeEngine + m_RemainingTimeOfEngineHours > m_MaxTimeOfEngineHours)
            {
                throw new ArgumentException("Unable to charge engine because more than max time to charge.");
            }
        }
    }
}