using GarageLogic.Engines;
using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    public class FuelMotorcycle : Motorcycle
    {

        
        public FuelMotorcycle(Customer i_Customer, string i_ModelName, string i_LicenseNumber,
            List<Wheel> i_Wheels, FuelEngine i_FuelEngine, Enums.eMotorcycleLicenseTypes i_LicenseType, int i_EngineVolume) :
            base(i_Customer, i_ModelName, i_LicenseNumber, i_Wheels, i_FuelEngine, i_LicenseType, i_EngineVolume)
        {
        }
    }
}