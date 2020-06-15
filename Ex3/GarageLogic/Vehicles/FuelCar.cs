using GarageLogic.Engines;

namespace GarageLogic.Vehicles
{
    public class FuelCar : Car
    {
        private static readonly float sr_DefaultMaxFuelCapactity = 60;
        private static readonly Enums.eFuelTypes sr_DefaultFuelType = Enums.eFuelTypes.Octan96;
        
        public FuelCar(string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergy) :
            base(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber)
        {
            m_Engine = new FuelEngine(sr_DefaultMaxFuelCapactity, i_RemainingEnergy, sr_DefaultFuelType);
        }
    }
}