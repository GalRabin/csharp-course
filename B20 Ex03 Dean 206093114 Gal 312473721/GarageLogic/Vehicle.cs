using System;

namespace EX3
{
    public abstract class Vehicle
    {
        private string modelName;
        private string licenseNumber;
        private object engine;

        public string ModelName
        {
            get
            {
                return modelName;
            }
            set
            {
                modelName = value;   
            }
        }

        public string LicenseNumber
        {
            get
            {
                return licenseNumber;
            }
            set
            {
                licenseNumber = value;
            }
        }

        public object Engine
        {
            get
            {
                return engine;
            }
            set
            {
                engine = value;
            }
        }

        public float RemainingEnergyPrecentage()
        {
            // should get it form engine
            float remainingEnergy = 2;

            return remainingEnergy;
        }
    }
}