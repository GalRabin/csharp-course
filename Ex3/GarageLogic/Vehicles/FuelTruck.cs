using GarageLogic.Engines;

namespace GarageLogic.Vehicles
{
    public class FuelTruck : Vehicle
    {
        private static readonly int sr_DefaultNumberOfWheels = 16;
        private static readonly int sr_DefaultMaxWheelsPressure = 28;
        private static readonly float sr_DefaultMaxFuelCapactity = 120;
        private static readonly Enums.eFuelTypes sr_DefaultFuelType = Enums.eFuelTypes.Soler;
        private float m_CargoVolume;
        private bool m_DangerousCargo;
        
        public FuelTruck(string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergy) : 
            base(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber)
        {
            m_Engine = new FuelEngine(sr_DefaultMaxFuelCapactity, i_RemainingEnergy, sr_DefaultFuelType);

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

        public bool DangerousCargo
        {
            get
            {
                return m_DangerousCargo;
            }
            set
            {
                m_DangerousCargo = value;
            }
        }
    }
}