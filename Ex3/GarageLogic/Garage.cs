using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GarageLogic.Engines;
using GarageLogic.Exceptions;
using GarageLogic.Vehicles;

namespace GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_Vehicles;

        public Garage()
        {
            r_Vehicles = new Dictionary<string, Vehicle>();
        }

        public bool InsertVehicle(Type i_VehicleType, Dictionary<string, object> i_VehicleConfiguration)
        {
            Vehicle vehicle = VehicleGenerator.GenerateVehicle((Enums.eVehicleType)Enum.Parse(typeof(Enums.eVehicleType), i_VehicleType.Name),
                i_VehicleConfiguration);
            bool successRegistration = true;

            if (IsLicenseNumberExists(vehicle.LicenseNumber))
            {
                vehicle.VehicleStatus = Enums.eVehicleGarageStatus.InRepair;
                successRegistration = false;
            }
            else
            {
                r_Vehicles.Add(vehicle.LicenseNumber, vehicle);
            }

            return successRegistration;
        }

        public Dictionary<string, Type> GetEmptyDictionary(Type i_Type)
        {
            Dictionary<string, Type> vehicleConfiguration = new Dictionary<string, Type>();
            ConstructorInfo constructorTypeInfo = i_Type.GetConstructors()[0];
            Enums.eVehicleType vehicleType = (Enums.eVehicleType)Enum.Parse(typeof(Enums.eVehicleType), i_Type.Name);

            foreach (ParameterInfo instanceParameter in constructorTypeInfo.GetParameters())
            {
                if (instanceParameter.ParameterType == typeof(List<Wheel>))
                {
                    for (int i = 0; i < (int)VehiclesDictionary.sr_DefaultDictionary[vehicleType]["Number Of Wheels"]; i++)
                    {
                        vehicleConfiguration.Add(string.Format("Wheel {0}", i + 1), typeof(Wheel));
                    }
                }
                else
                {
                    vehicleConfiguration.Add(instanceParameter.Name, instanceParameter.ParameterType);
                }
            }

            return vehicleConfiguration;
        }

        public object CreateObject(object[] i_Parameters, Type i_Type, Type i_VehicleType)
        {
            object obj;
            Enums.eVehicleType vehicleType = (Enums.eVehicleType)Enum.Parse(typeof(Enums.eVehicleType), i_VehicleType.Name);

            if (i_Type == typeof(Wheel))
            {
                float maxEnergy = (float)VehiclesDictionary.sr_DefaultDictionary[vehicleType]["Maximum Air Pressure"];
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                i_Parameters[^1] = maxEnergy;
                obj = new Wheel((string)i_Parameters[0],(float) i_Parameters[1], (float)i_Parameters[2]);
            }
            if (i_Type == typeof(ElectricEngine))
            {
                float maxEnergy = (float)VehiclesDictionary.sr_DefaultDictionary[vehicleType]["Maximum Energy"];
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                i_Parameters[^1] = maxEnergy;
                obj = new ElectricEngine((float)i_Parameters[0], (float)i_Parameters[1]); 
            }
            else if (i_Type == typeof(FuelEngine))
            {
                Enums.eFuelTypes fuelType = (Enums.eFuelTypes)VehiclesDictionary.sr_DefaultDictionary[vehicleType]["Fuel Type"];
                float maxEnergy = (float)VehiclesDictionary.sr_DefaultDictionary[vehicleType]["Maximum Energy"];
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                i_Parameters[^2] = maxEnergy;
                i_Parameters[^1] = fuelType;
                obj = new FuelEngine((float)i_Parameters[0], (float)i_Parameters[1], (Enums.eFuelTypes)i_Parameters[2]);
            }
            else
            {
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                obj = ci.Invoke(i_Parameters);
            }

            return obj;
        }

        public string GetVehicleInfo(string i_LicenseNumber)
        {

            return GetVehicle(i_LicenseNumber).ToString();
        }

        public IEnumerable<string> GetLicensesByStatus(string i_GarageStatus)
        {
            Enums.eVehicleGarageStatus status;

            if (Enum.IsDefined(typeof(Enums.eVehicleGarageStatus), i_GarageStatus))
            {
                status = (Enums.eVehicleGarageStatus)Enum.Parse(typeof(Enums.eVehicleGarageStatus), i_GarageStatus);
            }
            else
            {
                throw new ArgumentException("Invalid Argument");
            }

            List<string> licenses = new List<string>();

            foreach (KeyValuePair<string, Vehicle> entry in r_Vehicles)
            {
                if (entry.Value.VehicleStatus == status || status == Enums.eVehicleGarageStatus.None)
                {
                    licenses.Add(entry.Key);
                }
            }

            return licenses;
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, string i_Status)
        {
            Enums.eVehicleGarageStatus vehicleStatus = Enums.eVehicleGarageStatus.None;

            if (Enum.IsDefined(typeof(Enums.eVehicleGarageStatus), i_Status))
            {
                vehicleStatus = (Enums.eVehicleGarageStatus)Enum.Parse(typeof(Enums.eVehicleGarageStatus), i_Status);
            }
            else
            {
                GetVehicle(i_LicenseNumber).VehicleStatus = vehicleStatus;
            }
        }

        private bool IsLicenseNumberExists(string i_LicenseNumber)
        {

            return r_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            foreach (Wheel wheel in GetVehicle(i_LicenseNumber).Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void Refuel(string i_LicenseNumber, string i_FuelType, float i_FuelAmount)
        {
            Enums.eFuelTypes fuelType;

            if (!Enum.IsDefined(typeof(Enums.eFuelTypes), i_FuelType))
            {
                throw new ArgumentException("Fuel Type does not exist in garage.");
            }
            else if (GetVehicle(i_LicenseNumber).Engine.GetType() != typeof(FuelEngine))
            {
                throw new ArgumentException("Vehicle does not have fuel engine.");
            }
            else
            {
                fuelType = (Enums.eFuelTypes)Enum.Parse(typeof(Enums.eFuelTypes), i_FuelType);
                GetVehicle(i_LicenseNumber).Engine.Refuel(fuelType, i_FuelAmount);
            }
        }

        public void Recharge(string i_LicenseNumber, float i_NumberOfHoursToCharge)
        {
            if (r_Vehicles[i_LicenseNumber].Engine.GetType() != typeof(ElectricEngine))
            {
                throw new ArgumentException("Vehicle does not have electric engine.");
            }
            else
            {
                GetVehicle(i_LicenseNumber).Engine.Recharge(i_NumberOfHoursToCharge);
            }
        }

        private Vehicle GetVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle;
            if (!IsLicenseNumberExists(i_LicenseNumber))
            {
                throw new ArgumentException("License Number does not exist in garage.");
            }
            else
            {
                vehicle = r_Vehicles[i_LicenseNumber];
            }

            return vehicle;
        }

        public static List<string> GetFuelTypes()
        {

            return Enum.GetNames(typeof(Enums.eFuelTypes)).ToList();
        }

        public static List<string> GetVehicleStatuses()
        {

            return Enum.GetNames(typeof(Enums.eVehicleGarageStatus)).ToList();
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
