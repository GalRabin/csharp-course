using System;

namespace EX3
{
    public class FuelEngine
    {
        public enum FuelTypes
        {
            None,
            Soler,
            Octane95,
            Octane96,
            Octane98
        }

        private FuelTypes fuelType;
        private float currentAmountOfFuelsLiters;
        private float maxAmountOfFuelsLiters;

        public FuelTypes FuelType
        {
            get
            {
                return fuelType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(FuelTypes), (int) value))
                {
                    fuelType = FuelTypes.None;
                    throw new ArgumentException("Invalid fuel type");
                }

                fuelType = value;  
            } 
        }

        public float MaxAmountOfFuelsLiters
        {
            get
            {
                return maxAmountOfFuelsLiters;
            }
            set
            {
                maxAmountOfFuelsLiters = value;  
            } 
        }

        public float CurrentAmountOfFuelsLiters
        {
            get
            {
                return currentAmountOfFuelsLiters;
            }
            set
            {
                currentAmountOfFuelsLiters = value;   
            }
        }

        public void RefuelOperation(float litersToRefuel)
        {
            // TODO refuel , throw error if exceeds max
        }
    }
}