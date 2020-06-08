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

        public FuelEngine(FuelTypes fuelType, float currentAmountOfFuelsLiters, float maxAmountOfFuelsLiters)
        {
            this.fuelType = fuelType;
            this.currentAmountOfFuelsLiters = currentAmountOfFuelsLiters;
            this.maxAmountOfFuelsLiters = maxAmountOfFuelsLiters;
        }

        public FuelTypes FuelType => fuelType;

        public float MaxAmountOfFuelsLiters => maxAmountOfFuelsLiters;
        
        public float CurrentAmountOfFuelsLiters => currentAmountOfFuelsLiters;

        public void RefuelOperation(float litersToRefuel)
        {
            // TODO refuel , throw error if exceeds max
        }
        
        public static bool TryParseFuelType(string fuelValue, out FuelTypes o_fuelType)
        {
            bool validFuelType = false;
            int fuelAsInteger;
            
            if (int.TryParse(fuelValue, out fuelAsInteger) && Enum.IsDefined(typeof(FuelTypes), fuelAsInteger))
            {
                Enum.TryParse(fuelValue, out o_fuelType);
                validFuelType = true;
            }
            else
            {
                o_fuelType = FuelTypes.None;
            }
            
            return validFuelType;
        }
    }
}