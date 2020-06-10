using System;

namespace EX3
{
    public class GarageVehicle
    {
        public enum VehicleGarageStatus
        {
            None,
            InRepair,
            Repaired,
            PayedFor
        }
        
        private string ownerName;
        private string phoneNumber;
        private Vehicle vehicle;
        private VehicleGarageStatus vehicleStatus;

        public string OwnerName
        {
            get
            {
                return ownerName;
            }
            set
            {
                ownerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
            }
        }

        public VehicleGarageStatus VehicleStatus
        {
            get
            {
                return vehicleStatus;
            }
            set
            {
                vehicleStatus = value;
            }
        }

        public void InflateAllWheels()
        {
            foreach (Wheel wheel in vehicle.Wheels)
            {
                float missingPressure = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.CurrentAirPressure += missingPressure;
            }
        }
        
        public void RefuelEngine(FuelEngine.FuelTypes fuelType, float litersToFill)
        {
            if (vehicle.Engine is FuelEngine)
            {
                FuelEngine fuelEngine = vehicle.Engine as FuelEngine;
                if (fuelEngine.FuelType != fuelType)
                {
                    throw new ArgumentException("Unable to fuel wrong type of fuel.");
                }
                fuelEngine.RefuelOperation(litersToFill);
            }
            else
            {
                throw new ArgumentException("Can't fuel car because engine is not fuel.");
            }
        }

        public void ChargeEngine(float hoursToCharge)
        {
            if (vehicle.Engine is ElectricEngine)
            {
                ElectricEngine electricEngine = vehicle.Engine as ElectricEngine; 
                electricEngine.RechargeOperation(hoursToCharge);
            }
            else
            {
                throw new ArgumentException("Can't charge car because engine is not electric.");
            }
        }
    }
}