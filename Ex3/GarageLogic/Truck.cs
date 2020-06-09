namespace EX3
{
    public class Truck : Vehicle
    {
        private bool containsDangerousMaterials;
        private float cargoVolume;

        public bool ContainsDangerousMaterials
        {
            get
            {
                return containsDangerousMaterials;
            }
            set
            {
                containsDangerousMaterials = value;
            } 
        }

        public float CargoVolume
        {
            get
            {
                return cargoVolume;
            }
            set
            {
                cargoVolume = value;
            }
        }
    }
}