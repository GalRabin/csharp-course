namespace GarageLogic
{
    public class Enums
    {
        public enum VehiclesTypes
        {
            None,
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck
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