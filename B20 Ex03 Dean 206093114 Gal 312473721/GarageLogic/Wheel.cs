using System;

namespace EX3
{
    public class Wheel
    {
        private string manufacturName;
        private float currentAirPressure;
        private float maxAirPressure;

        public Wheel(string manufacturName, float currentAirPressure, float maxAirPressure)
        {
            this.manufacturName = manufacturName;
            this.currentAirPressure = currentAirPressure;
            this.maxAirPressure = maxAirPressure;
        }

        public string ManufacturName => manufacturName;

        public float CurrentAirPressure => currentAirPressure;

        public float MaxAirPressure => maxAirPressure;

        public void InflateAction(float pressureToAdd)
        {
            // should throw exception if over load
        }
    }
    
    public class WheelException : Exception
    {
        public WheelException(string message)
            : base(message)
        {
        }
    }
}