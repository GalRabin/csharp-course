using System;
using System.Collections.Generic;

namespace EX3
{
    public class Garage
    {
        private Dictionary<string, GarageVehicle> garageVehicles = new Dictionary<string, GarageVehicle>();

        public List<Type> GetVehicleTypes()
        {
            return new List<Type>()
            {
                typeof(Car),
                typeof(Truck),
                typeof(Motorcycle)
            };
        }
        
        public List<Type> GetEngineTypes()
        {
            return new List<Type>()
            {
                typeof(FuelEngine),
                typeof(ElectricEngine)
            };
        }
        public void AddGarageVehicle(GarageVehicle vehicle)
        {
            string vehicleLicenseNumber = vehicle.Vehicle.LicenseNumber;
            if (garageVehicles.ContainsKey(vehicleLicenseNumber))
            {
                throw new ArgumentException($"Vehicle with plate {vehicleLicenseNumber} already exists");
            }
            garageVehicles.Add(vehicleLicenseNumber, vehicle);
        }

        public List<string> ListVehicleLicenseNumber(GarageVehicle.VehicleGarageStatus status)
        {
            List<string> licensesNumbers = new List<string>();
            foreach(KeyValuePair<string, GarageVehicle> vehicle in garageVehicles)
            {
                if (vehicle.Value.VehicleStatus == status)
                {
                    licensesNumbers.Add(vehicle.Key);
                }
            }

            return licensesNumbers;
        }

        public void ChangeVehicleStatus(string licenseNumber, GarageVehicle.VehicleGarageStatus status)
        {
            try
            {
                garageVehicles[licenseNumber].VehicleStatus = status;
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {licenseNumber} not exists in garage.");
            }
        }

        public void InflateWheelsToMax(string licenseNumber)
        {
            try
            {
                garageVehicles[licenseNumber].InflateAllWheels();  
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {licenseNumber} not exists in garage.");
            }
        }
        
        public void RefuelEngine(string licenseNumber, FuelEngine.FuelTypes fuelType, float litersToFill)
        {
            try
            {
                garageVehicles[licenseNumber].RefuelEngine(fuelType, litersToFill);  
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {licenseNumber} not exists in garage.");
            }        
        }
        
        public void ChargeEngine(string licenseNumber, float hoursToCharge)
        {
            try
            {
                garageVehicles[licenseNumber].ChargeEngine(hoursToCharge);  
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {licenseNumber} not exists in garage.");
            }        
        }

        public GarageVehicle GetVehicle(string licenseNumber)
        {
            return garageVehicles[licenseNumber];
        }
    }
}