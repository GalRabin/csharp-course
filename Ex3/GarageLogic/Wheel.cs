using GarageLogic.Exceptions;
using System;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_BrandName;
        private float m_CurrentPressure;
        private float m_MaxPressure;
       
        public Wheel(string i_BrandName, float i_CurrentPressure, float i_MaxPressure = 0)
        {
            m_BrandName = i_BrandName;
            m_CurrentPressure = i_CurrentPressure;
            m_MaxPressure = i_MaxPressure;
        }
        
        public string BrandName
        {
            get
            {
                return m_BrandName;
            }
            set
            {
                this.m_BrandName = value;
            }
        }

        public float CurrentPressure
        {
            get
            {
                return m_CurrentPressure;
            }
            set
            {
                this.m_CurrentPressure = value;
            }
        }
        public float MaxPressure
        {
            get
            {
                return m_MaxPressure;
            }
        }

        internal void InflateToMax()
        {
            m_CurrentPressure = m_MaxPressure;
        }

        internal void Inflate(float i_PressureToAdd)
        {
            if (i_PressureToAdd + m_CurrentPressure > m_MaxPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxPressure);
            }

            m_CurrentPressure += i_PressureToAdd;
        }

        public override string ToString()
        {
            return string.Format("Wheel brand name: {0}" + Environment.NewLine +
                                 "Wheel current pressure: {1}" + Environment.NewLine +
                                 "Wheel max pressure: {2}" + Environment.NewLine,
                                  this.BrandName,
                                  this.CurrentPressure,
                                  this.MaxPressure);
        }
    }
}