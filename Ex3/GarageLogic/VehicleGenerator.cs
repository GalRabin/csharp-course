using System;
using System.Collections.Generic;
using System.Reflection;
using GarageLogic.Vehicles;

namespace GarageLogic
{
    public class VehicleGenerator
    {
        public static Vehicle GenerateVehicle(Enums.VehiclesTypes i_VehicleType, Dictionary<string, object> i_CommonProperties, Dictionary<string, object> i_specialProperties)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case Enums.VehiclesTypes.FuelMotorcycle:
                    vehicle = new FuelMotorcycle(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber, i_RemainingEnergy);
                    break;
                case Enums.VehiclesTypes.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber, i_RemainingEnergy);
                    break;
                case Enums.VehiclesTypes.FuelCar:
                    vehicle = new FuelCar(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber, i_RemainingEnergy);
                    break;
                case Enums.VehiclesTypes.ElectricCar:
                    vehicle = new ElectricCar(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber, i_RemainingEnergy);
                    break;
                case Enums.VehiclesTypes.Truck:
                    vehicle = new FuelTruck(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber, i_RemainingEnergy);
                    break;
            }
            
            configureSpecialProperties(vehicle, i_specialProperties);
            configureVehicleWheels(vehicle);

            return vehicle;
        }

        private static void configureSpecialProperties(Vehicle i_vehicle, Dictionary<string, object> i_specialProperties)
        {
            foreach (KeyValuePair<string, object> entry in i_specialProperties)
            {
                PropertyInfo propertyInfo = i_vehicle.GetType().GetProperty(entry.Key);
                propertyInfo.SetValue(i_vehicle, entry.Value, null);
            }
        }
        
        private static void configureVehicleWheels(Vehicle i_vehicle)
        {
        }
        
        public static List<Type> GetVehicleTypes()
        {
            return new List<Type>()
            {
                typeof(ElectricMotorcycle),
                typeof(FuelMotorcycle),
                typeof(FuelCar),
                typeof(ElectricCar),
                typeof(FuelTruck)
            };
        }
    }
}