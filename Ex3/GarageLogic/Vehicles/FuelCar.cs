using GarageLogic.Engines;
using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    public class FuelCar : Car
    {

        
        public FuelCar(Customer i_Customer, string i_ModelName, string i_LicenseNumber,List<Wheel> i_Wheels,
            FuelEngine i_FuelEngine, Enums.eCarColors i_CarColor, int i_NumberOfDoors) :
            base(i_Customer, i_ModelName, i_LicenseNumber,i_Wheels, i_FuelEngine, i_CarColor, i_NumberOfDoors)
        {
        }
    }
}