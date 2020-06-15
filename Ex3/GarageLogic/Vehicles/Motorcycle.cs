namespace GarageLogic.Vehicles
{
    public abstract class Motocycle : Vehicle
    {
        private static readonly int sr_DefaultNumberOfWheels = 2;
        private static readonly int sr_DefaultMaxWheelsPressure = 30;
        private Enums.eMotorcycleLicenseTypes m_LicenseType;
        private int m_EngineVolume;

        public Motocycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber) :
            base(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber)
        {
        }

        public Enums.eMotorcycleLicenseTypes LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }
        }
    }
}