namespace EX3
{
    public class Truck : Vehicle
    {
        private bool containsDangerousMaterials;
        private float cargoVolume;
        
        public Truck(string modelName, string licenseNumber, float cargoVolume, bool containsDangerousMaterials) : base(modelName, licenseNumber)
        {
            this.cargoVolume = cargoVolume;
            this.containsDangerousMaterials = containsDangerousMaterials;
        }

        public bool ContainsDangerousMaterials => containsDangerousMaterials;

        public float CargoVolume => cargoVolume;
    }
}