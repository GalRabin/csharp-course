using System;
using System.Collections.Generic;

namespace EX3
{
    public class Garage
    {
        private Dictionary<string, GarageVehicle> garageVehicles = new Dictionary<string, GarageVehicle>();

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
            // TODO should implement

            return licensesNumbers;
        }

        public void ChangeVehicleStatus(float licenseNumber, GarageVehicle.VehicleGarageStatus status)
        {
            // TODO implement
        }

        public void InflateWheelsToMax(float licenseNumber)
        {
            // TODO implement
        }
        
        public void RefuelEngine(float licenseNumber, FuelEngine.FuelTypes fuelType, float litersToFill)
        {
            // TODO implement, throw error if not fuel engine or more than maximum
        }
        
        public void ChargeEngine(float licenseNumber, float hoursToCharge)
        {
            // TODO implement, throw error if not electric engine or more than maximum
        }

        public GarageVehicle GetVehicle(string licenseNumber)
        {
            // TODO handling if not exists

            return garageVehicles[licenseNumber];
        }
    }

    public class GarageRegistrationException : Exception
    {
        public GarageRegistrationException(string message)
            : base(message)
        {
        }
    }
}