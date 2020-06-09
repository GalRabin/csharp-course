using System;

namespace EX3
{
    public class Wheel
    {
        private string manufactureName;
        private float currentAirPressure;
        private float maxAirPressure;

        public string ManufactureName
        {
            get
            {
              return manufactureName;
            }
            set
            {
                manufactureName = value;   
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return currentAirPressure;
            }
            set
            {
                currentAirPressure = value;   
            }
        }
        
        public float MaxAirPressure
        {
            get
            {
                return maxAirPressure;
            }
            set
            {
                maxAirPressure = value;   
            }
        }
    }
}