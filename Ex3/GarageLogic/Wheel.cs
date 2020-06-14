using System;

namespace EX3
{
    public class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public string ManufactureName
        {
            get
            {

              return m_ManufactureName;
            }
            set
            {
                m_ManufactureName = value;   
            }
        }

        public float CurrentAirPressure
        {
            get
            {

                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;   
            }
        }
        
        public float MaxAirPressure
        {
            get
            {

                return m_MaxAirPressure;
            }
            set
            {
                if (value < m_CurrentAirPressure)
                {
                    throw new System.Exception("Maximal amount of air pressure in wheel can not be less than current, " +
                        + this.m_CurrentAirPressure);
                }

                m_MaxAirPressure = value;   
            }
        }
        public string getInfo()
        {
            string str = String.Format(
                "Manufacture name: {0}\n" +
                "Max air pressure: {1}\n" +
                "Current air pressure: {2}\n",
                this.m_ManufactureName,
                this.m_MaxAirPressure,
                this.m_CurrentAirPressure);

            return str;
        }
    }
}