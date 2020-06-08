namespace EX3
{
    public class FuelEngine
    {
        public enum FuelTypes
        {
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
    }
}