namespace EX3
{
    public class Truck : Vehicle
    {
        private bool m_ContainsDangerousMaterials;
        private float m_CargoVolume;

        public bool ContainsDangerousMaterials
        {
            get
            {

                return m_ContainsDangerousMaterials;
            }
            set
            {
                m_ContainsDangerousMaterials = value;
            } 
        }

        public float CargoVolume
        {
            get
            {

                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
            }
        }
        public override int DefaultNumberOfWheels()
        {

            return 6;
        }

    }
}