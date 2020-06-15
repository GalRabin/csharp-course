using GarageLogic.Engines;

namespace GarageLogic.Vehicles
{
    public class ElectricCar : Car
    {
        private static readonly float sr_DefaultMaxElectricChargeHours = 2.1f;

        internal ElectricCar(string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergy) :
            base(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber)
        {
            m_Engine = new ElectricEngine(sr_DefaultMaxElectricChargeHours,i_RemainingEnergy);
        }
    }
}