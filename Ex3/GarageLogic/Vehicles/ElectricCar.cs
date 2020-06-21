using GarageLogic.Engines;
using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    public class ElectricCar : Car
    {
        public ElectricCar(Customer i_Customer,string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels,
             ElectricEngine i_ElectricEngine, Enums.eCarColors i_CarColor, int i_NumberOfDoors) :
            base(i_Customer, i_ModelName, i_LicenseNumber, i_Wheels, i_ElectricEngine, i_CarColor, i_NumberOfDoors)
        {
        }
    }
}