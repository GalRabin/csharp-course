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
                    vehicle = new FuelMotorcycle((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                         (string)i_Properties["License Number"], wheels,
                         (Engines.FuelEngine)i_Properties["Fuel Engine"],
                         (Enums.eMotorcycleLicenseTypes)i_Properties["License Type"], (int)i_Properties["Engine Volume"]);
                    break;
                case Enums.eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                        (string)i_Properties["License Number"], wheels,
                        (Engines.ElectricEngine)i_Properties["Electric Engine"],
                        (Enums.eMotorcycleLicenseTypes)i_Properties["License Type"], (int)i_Properties["Engine Volume"]);
                    break;
                case Enums.eVehicleType.FuelCar:
                    vehicle = new FuelCar((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                              (string)i_Properties["License Number"], wheels,
                              (Engines.FuelEngine)i_Properties["Fuel Engine"],
                              (Enums.eCarColors)i_Properties["Car Color"], (int)i_Properties["Number Of Doors"]);
                    break;
                case Enums.eVehicleType.ElectricCar:
                    vehicle = new ElectricCar((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                               (string)i_Properties["License Number"], wheels,
                               (Engines.ElectricEngine)i_Properties["Electric Engine"],
                               (Enums.eCarColors)i_Properties["Car Color"], (int)i_Properties["Number Of Doors"]);
                    break;
                case Enums.eVehicleType.FuelTruck:
                    vehicle = new FuelTruck((Customer)i_Properties["Customer"], (string)i_Properties["Model Name"],
                              (string)i_Properties["License Number"], wheels,
                              (Engines.FuelEngine)i_Properties["Fuel Engine"],
                              (float)i_Properties["Cargo Volume"], (bool)i_Properties["Dangerous Cargo"]);
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
    }
}