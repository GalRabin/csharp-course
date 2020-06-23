using GarageLogic.Exceptions;
using System;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_WheelBrandName;
        private float m_WheelCurrentPressure;
        private float m_WheelMaxPressure;
       
        public Wheel(string i_WheelBrandName, float i_WheelCurrentPressure, float i_WheelMaxPressure = 0)
        {
            if(i_WheelCurrentPressure > i_WheelMaxPressure)
            {
                throw new ValueOutOfRangeException(0, i_WheelMaxPressure);
            }
            m_WheelBrandName = i_WheelBrandName;
            m_WheelCurrentPressure = i_WheelCurrentPressure;
            m_WheelMaxPressure = i_WheelMaxPressure;
        }
        
        public string BrandName
        {
            get
            {
                return m_WheelBrandName;
            }
            set
            {
                this.m_WheelBrandName = value;
            }
        }

        public float CurrentPressure
        {
            get
            {
                return m_WheelCurrentPressure;
            }
            set
            {
                this.m_WheelCurrentPressure = value;
            }
        }
        public float MaxPressure
        {
            get
            {
                return m_WheelMaxPressure;
            }
        }

        internal void InflateToMax()
        {
            m_WheelCurrentPressure = m_WheelMaxPressure;
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