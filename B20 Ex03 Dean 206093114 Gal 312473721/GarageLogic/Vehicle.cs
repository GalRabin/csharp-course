namespace EX3
{
    public abstract class Vehicle
    {
        private string modelName;
        private string licenseNumber;
        private ElectricEngine electricEngine;
        private FuelEngine fuelEngine;

        public Vehicle(string modelName, string licenseNumber)
        {
            this.modelName = modelName;
            this.licenseNumber = licenseNumber;
        }

        public string ModelName => modelName;

        public string LicenseNumber => licenseNumber;

        public float RemainingEnergyPrecentage()
        {
            // should get it form engine
            float remainingEnergy = 2;

            return remainingEnergy;
        }

        public void SetEngine(object engine)
        {
            // TODO same for all, errors handling
        }
    }
}