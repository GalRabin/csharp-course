using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GarageLogic.Vehicles;

namespace GarageLogic
{
    public static class VehicleGenerator
    {
        public static Vehicle GenerateVehicle(Enums.eVehicleType i_VehicleType, Dictionary<string, object> i_Properties)
        {
            Vehicle vehicle = null;
            List<Wheel> wheels = buildWheels(i_Properties.Values);

            switch (i_VehicleType)
            {
                case Enums.eVehicleType.FuelMotorcycle:
                    vehicle = createFuelMotorcycle(i_Properties, wheels);
                    break;
                case Enums.eVehicleType.ElectricMotorcycle:
                    vehicle = createElectricMotorcycle(i_Properties, wheels);
                    break;
                case Enums.eVehicleType.FuelCar:
                    vehicle = createFuelCar(i_Properties, wheels);
                    break;
                case Enums.eVehicleType.ElectricCar:
                    vehicle = createElectricCar(i_Properties, wheels);
                    break;
                case Enums.eVehicleType.FuelTruck:
                    vehicle = createFuelTruck(i_Properties, wheels);
                    break;
            }

            return vehicle;
        }

        private static List<Wheel> buildWheels(Dictionary<string, object>.ValueCollection i_Values)
        {
            List<Wheel> wheels = new List<Wheel>();

            foreach (var v in i_Values)
            {
                if (v.GetType() == typeof(Wheel))
                {
                    wheels.Add((Wheel)v);
                }
            }

            return wheels;
        }
        private static FuelMotorcycle createFuelMotorcycle(Dictionary<string, object> i_Properties, List<Wheel> i_Wheels)
        {

            return new FuelMotorcycle((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                         (string)i_Properties["License Number"], i_Wheels,
                         (Engines.FuelEngine)i_Properties["Fuel Engine"],
                         (Enums.eMotorcycleLicenseTypes)i_Properties["License Type"], (int)i_Properties["Engine Volume"]);
        }
        private static ElectricMotorcycle createElectricMotorcycle(Dictionary<string, object> i_Properties, List<Wheel> i_Wheels)
        {

            return new ElectricMotorcycle((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                        (string)i_Properties["License Number"], i_Wheels,
                        (Engines.ElectricEngine)i_Properties["Electric Engine"],
                        (Enums.eMotorcycleLicenseTypes)i_Properties["License Type"], (int)i_Properties["Engine Volume"]);
        }
        private static FuelCar createFuelCar(Dictionary<string, object> i_Properties, List<Wheel> i_Wheels)
        {

            return new FuelCar((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                              (string)i_Properties["License Number"], i_Wheels,
                              (Engines.FuelEngine)i_Properties["Fuel Engine"],
                              (Enums.eCarColors)i_Properties["Car Color"], (int)i_Properties["Number Of Doors"]);
        }
        private static ElectricCar createElectricCar(Dictionary<string, object> i_Properties, List<Wheel> i_Wheels)
        {

            return new ElectricCar((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                               (string)i_Properties["License Number"], i_Wheels,
                               (Engines.ElectricEngine)i_Properties["Electric Engine"],
                               (Enums.eCarColors)i_Properties["Car Color"], (int)i_Properties["Number Of Doors"]);
        }
        private static FuelTruck createFuelTruck(Dictionary<string, object> i_Properties, List<Wheel> i_Wheels)
        {

            return new FuelTruck((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                              (string)i_Properties["License Number"], i_Wheels,
                              (Engines.FuelEngine)i_Properties["Fuel Engine"],
                              (float)i_Properties["Cargo Volume"], (bool)i_Properties["Dangerous Cargo"]);
        }
    }
}