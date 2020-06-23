using GarageLogic.Vehicles;
using System;

namespace GarageLogic
{
    public class Enums
    {
        public enum eEngineTypes
        {
            None,
            ElectricEngine,
            FuelEngine
        }
        public enum eVehicleType
        {
            None,
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            FuelTruck
        }
        public enum eMotorcycleLicenseTypes
        {
            None,
            A,
            A1,
            AA,
            B
        }
        public enum eCarColors
        {
            None,
            Red,
            White,
            Black,
            Silver
        }
        public enum eFuelTypes
        {
            None,
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }
        
        public enum eVehicleGarageStatus
        {
            None,
            InRepair,
            Repaired,
            Payed
        }
    }
}