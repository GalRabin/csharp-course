using System;
using System.Collections.Generic;

namespace EX3
{
    public class Garage
    {
        private static readonly Dictionary<eVehicleTypes , object[]> sr_VehiclesDictionary = new Dictionary<eVehicleTypes, object[]>()
        {
            {eVehicleTypes.RegularMotorcycle, new object[] {2, 30, typeof(FuelEngine), FuelEngine.eFuelTypes.Octane95, 7 } },
            {eVehicleTypes.ElectricMotorcycle, new object[]{2, 30, typeof(ElectricEngine), 1.2} },
            {eVehicleTypes.RugularCar, new object[]{4, 32, typeof(FuelEngine), FuelEngine.eFuelTypes.Octane96, 60} },
            {eVehicleTypes.ElectricCar, new object[]{4, 32, typeof(ElectricEngine), 2.1} },
            {eVehicleTypes.Truck, new object[]{16, 28, typeof(FuelEngine), FuelEngine.eFuelTypes.Soler, 120} }
        };

        private Dictionary<string, GarageVehicle> m_GarageVehicles = new Dictionary<string, GarageVehicle>();

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
        public void AddGarageVehicle(GarageVehicle i_Vehicle)
        {
            string vehicleLicenseNumber = i_Vehicle.Vehicle.LicenseNumber;

            if (m_GarageVehicles.ContainsKey(vehicleLicenseNumber))
            {
                throw new ArgumentException($"Vehicle with plate {vehicleLicenseNumber} already exists");
            }

            m_GarageVehicles.Add(vehicleLicenseNumber, i_Vehicle);
        }

        public List<string> ListVehicleLicenseNumberByStatus(GarageVehicle.eVehicleGarageStatus status)
        {
            List<string> licensesNumbers = new List<string>();

            foreach(KeyValuePair<string, GarageVehicle> vehicle in m_GarageVehicles)
            {
                if (vehicle.Value.VehicleStatus == status)
                {
                    licensesNumbers.Add(vehicle.Key);
                }
            }

            return licensesNumbers;
        }
        public List<string> ListAllVehicleLicenseNumber()
        {
            List<string> licensesNumbers = new List<string>();

            foreach (KeyValuePair<string, GarageVehicle> vehicle in m_GarageVehicles)
            {
                licensesNumbers.Add(vehicle.Key);
            }

            return licensesNumbers;
        }
        public void ChangeVehicleStatus(string i_LicenseNumber, GarageVehicle.eVehicleGarageStatus i_Status)
        {
            try
            {
                m_GarageVehicles[i_LicenseNumber].VehicleStatus = i_Status;
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} not exists in garage.");
            }
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            try
            {
                m_GarageVehicles[i_LicenseNumber].InflateAllWheels();  
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} not exists in garage.\n");
            }
        }
        
        public void RefuelEngine(string i_LicenseNumber, FuelEngine.eFuelTypes i_FuelType, float i_LitersToFill)
        {
            try
            {
                m_GarageVehicles[i_LicenseNumber].RefuelEngine(i_FuelType, i_LitersToFill);  
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} not exists in garage.");
            }        
        }
        
        public void ChargeEngine(string i_LicenseNumber, float i_HoursToCharge)
        {
            try
            {
                m_GarageVehicles[i_LicenseNumber].ChargeEngine(i_HoursToCharge);  
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} not exists in garage.");
            }        
        }

        public GarageVehicle GetVehicle(string i_LicenseNumber)
        {
            GarageVehicle vehicle = null;
            
            try
            {
                vehicle = m_GarageVehicles[i_LicenseNumber];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} not exists in garage.");
            }

            return vehicle; 
        }

        public Vehicle getDefaultProperties(Type i_VehicleType, Type i_EngineType)
        {
            Vehicle vehicle = null;

            // Regular Motorcycle
            if (i_VehicleType == typeof(Motorcycle) && i_EngineType == typeof(FuelEngine))
            {
                object[] props = sr_VehiclesDictionary[eVehicleTypes.RugularCar];
                vehicle = new Motorcycle();
                vehicle.Wheels = new List<Wheel>();

                for (int i = 0; i < (int)props[0]; i++)
                {
                    Wheel wheel = new Wheel();
                    wheel.MaxAirPressure = (int)props[1];
                    vehicle.Wheels.Add(wheel);
                }

                vehicle.Engine = props[2];
                vehicle.SetFuelType((FuelEngine.eFuelTypes)props[3]);
                vehicle.SetFuelMax((int)props[4]);
            }

            // Electric Motorcycle
            else if (i_VehicleType == typeof(Motorcycle) && i_EngineType == typeof(ElectricEngine))
            {
                object[] props = sr_VehiclesDictionary[eVehicleTypes.RugularCar];
                vehicle = new Motorcycle();
                vehicle.Wheels = new List<Wheel>();

                for (int i = 0; i < (int)props[0]; i++)
                {
                    Wheel wheel = new Wheel();
                    wheel.MaxAirPressure = (int)props[1];
                    vehicle.Wheels.Add(wheel);
                }

                vehicle.Engine = props[2];
                vehicle.SetElectricMax((int)props[3]);
            }
            // Regular Car
            else if (i_VehicleType == typeof(Car) && i_EngineType == typeof(FuelEngine))
            {
                object [] props = sr_VehiclesDictionary[eVehicleTypes.RugularCar];
                vehicle = new Car();
                vehicle.Wheels = new List<Wheel>();

                for(int i = 0; i < (int)props[0]; i++)
                {
                    Wheel wheel = new Wheel();
                    wheel.MaxAirPressure = (int)props[1];
                    vehicle.Wheels.Add(wheel);
                }

                vehicle.Engine = props[2];
                vehicle.SetFuelType((FuelEngine.eFuelTypes)props[3]);
                vehicle.SetFuelMax((int)props[4]);
            }
            // Electric Car
            else if (i_VehicleType == typeof(Car) && i_EngineType == typeof(ElectricEngine))
            {
                object[] props = sr_VehiclesDictionary[eVehicleTypes.RugularCar];
                vehicle = new Car();
                vehicle.Wheels = new List<Wheel>();

                for (int i = 0; i < (int)props[0]; i++)
                {
                    Wheel wheel = new Wheel();
                    wheel.MaxAirPressure = (int)props[1];
                    vehicle.Wheels.Add(wheel);
                }

                vehicle.Engine = props[2];
                vehicle.SetElectricMax((int)props[4]);
            }

            // Truck
            else if (i_VehicleType == typeof(Truck))
            {
                object[] props = sr_VehiclesDictionary[eVehicleTypes.RugularCar];
                vehicle = new Truck();
                vehicle.Wheels = new List<Wheel>();

                for (int i = 0; i < (int)props[0]; i++)
                {
                    Wheel wheel = new Wheel();
                    wheel.MaxAirPressure = (int)props[1];
                    vehicle.Wheels.Add(wheel);
                }

                vehicle.Engine = props[2];
                vehicle.SetFuelType((FuelEngine.eFuelTypes)props[3]);
                vehicle.SetFuelMax((int)props[4]);
            }

            return vehicle;
        }

        public enum eVehicleTypes
        {
            RegularMotorcycle,
            ElectricMotorcycle,
            RugularCar, 
            ElectricCar,
            Truck
        }
    }
}