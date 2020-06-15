using GarageLogic.Exceptions;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_BrandName;
        private float m_CurrentPressure;
        private readonly float r_MaxPressure;
        public Wheel(string i_BrandName, float i_CurrentPressure, float i_MaxPressure)
        {
            m_BrandName = i_BrandName;
            m_CurrentPressure = i_CurrentPressure;
            r_MaxPressure = i_MaxPressure;
        }

        internal string BrandName
        {
            get
            {
                return m_BrandName;
            }
        }

        internal float CurrentPressure
        {
            get
            {
                return m_CurrentPressure;
            }
        }

        internal void InflateToMax()
        {
            m_CurrentPressure = r_MaxPressure;
        }

        internal void Inflate(float i_PressureToAdd)
        {
            if (i_PressureToAdd + m_CurrentPressure > r_MaxPressure)
            {
                throw new ValueOutOfRangeException(0, r_MaxPressure);
            }

            m_CurrentPressure += i_PressureToAdd;
        }
        
        
    }
}