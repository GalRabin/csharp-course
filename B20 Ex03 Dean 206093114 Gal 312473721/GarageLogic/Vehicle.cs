using System;
using System.Collections.Generic;

namespace EX3
{
    public abstract class Vehicle
    {
        private string modelName;
        private string licenseNumber;
        private FuelEngine fuelEngine;
        private ElectricEngine electricEngine;
        private List<Wheel> wheels;

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
                if (electricEngine != null)
                {
                    return electricEngine;
                }
                if (fuelEngine != null)
                {
                    return fuelEngine;
                }

                return null;
            }
            set
            {
                electricEngine = null;
                fuelEngine = null;
                if (value is FuelEngine)
                {
                    fuelEngine = (FuelEngine)value;
                }
                else if (value is ElectricEngine)
                {
                    electricEngine = (ElectricEngine)value;
                }
                else
                {
                    throw new ArgumentException("Not valid engien object");
                }
            }
        }

        public void AppendWheel(Wheel wheel)
        {
            wheels.Add(wheel);
        }

        public float RemainingEnergyPrecentage()
        {
            // TODO implement
            float remainingEnergy = 2;

            return remainingEnergy;
        }
    }
}