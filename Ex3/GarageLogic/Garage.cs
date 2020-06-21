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
        private Dictionary<string, Vehicle> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, Vehicle>();
        }
        /*
        public bool InsertVehicle(object i_Vehicle, Dictionary<string, object> i_VehicleConfiguration)
        {
            i_Vehicle = i_Vehicle as Vehicle;
            bool success = true;
            
            if (this.IsLicenseNumberExists(vehicle.LicenseNumber))
            {
                vehicle.VehicleStatus = Enums.eVehicleGarageStatus.InRepair;
                success = false;
            }
            else
            {
                this.m_Vehicles.Add(vehicle.LicenseNumber, vehicle);
            }
            
            return success;
        }*/

        public bool InsertVehicle(Type i_VehicleType, Dictionary<string, object> i_VehicleConfiguration)
        {
             Vehicle vehicle = VehicleGenerator.GenerateVehicle((Enums.eVehicleType)Enum.Parse(typeof(Enums.eVehicleType), i_VehicleType.Name),
                 i_VehicleConfiguration);
            bool success = true;

            if (this.IsLicenseNumberExists(vehicle.LicenseNumber))
            {
                vehicle.VehicleStatus = Enums.eVehicleGarageStatus.InRepair;
                success = false;
            }
            else
            {
                this.m_Vehicles.Add(vehicle.LicenseNumber, vehicle);
            }

            return success;
        }
        /*public Vehicle GenerateVehicle(Type i_Type)
        {

            return VehicleGenerator.GenerateVehicle((Enums.eVehicleType)Enum.Parse(typeof(Enums.eVehicleType), i_Type.Name));
        }*/
        /*
        public Dictionary<string, Type> GetEmptyDictionary(Type i_VehicleType, object i_Vehicle)
        {
            if(!(i_Vehicle is Vehicle))
            {
                throw new ArgumentException("no vehicle");
            }
            Vehicle vehicle = i_Vehicle as Vehicle;
            Dictionary<string, Type> vehicleConfiguration = new Dictionary<string, Type>();
            Enums.eVehicleType vehicleType = (Enums.eVehicleType)Enum.Parse(typeof(Enums.eVehicleType), i_VehicleType.Name);
            Type type = i_Vehicle.GetType();

            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (pi.PropertyType == typeof(List<Wheel>))
                {
                    for (int i = 0; i < (int)VehiclesDictionary.dict[vehicleType]["Number Of Wheels"]; i++)
                    {
                        vehicleConfiguration.Add(string.Format("{0} {1}", pi.Name, i + 1), typeof(Wheel));

                    }
                }
                else if (pi.PropertyType == typeof(Engine))
                {
                    if(i_VehicleType.ToString().Contains("Electric"))
                    {
                        vehicleConfiguration.Add("ElectricEngine", typeof(ElectricEngine));
                    }
                    else if (i_VehicleType.ToString().Contains("Fuel"))
                    {
                        vehicleConfiguration.Add("FuelEngine", typeof(FuelEngine));
                    }
                }
                else
                {
                    vehicleConfiguration.Add(pi.Name, pi.PropertyType);
                }
            }

            return vehicleConfiguration;
        }*/
        
        public Dictionary<string, Type> GetEmptyDictionary(Type i_Type)
        {
            Dictionary<string, Type> vehicleConfiguration = new Dictionary<string, Type>();
            ConstructorInfo constructorTypeInfo = i_Type.GetConstructors()[0];
            Enums.eVehicleType vehicleType = (Enums.eVehicleType)Enum.Parse(typeof(Enums.eVehicleType), i_Type.Name);
            
            foreach (ParameterInfo pi in constructorTypeInfo.GetParameters())
            {
                if (pi.ParameterType == typeof(List<Wheel>))
                {
                    for (int i = 0; i < (int)VehiclesDictionary.dict[vehicleType]["Number Of Wheels"]; i++)
                    {

                        vehicleConfiguration.Add(string.Format("{0} {1}", pi.Name, i + 1), typeof(Wheel));

                    }
                }
                else
                {
                    vehicleConfiguration.Add(pi.Name, pi.ParameterType);
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
                float maxEnergy = (float)VehiclesDictionary.dict[vehicleType]["Maximum Air Pressure"];
                
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                i_Parameters[i_Parameters.Length - 1] = maxEnergy;
                obj = ci.Invoke(i_Parameters);
            }
            if (i_Type == typeof(Engines.ElectricEngine))
            {
                float maxEnergy = (float)VehiclesDictionary.dict[vehicleType]["Maximum Energy"];
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                i_Parameters[i_Parameters.Length - 1] = maxEnergy;
                obj = ci.Invoke(i_Parameters);
            }
            else if (i_Type == typeof(Engines.FuelEngine))
            {
                Enums.eFuelTypes fuelType = (Enums.eFuelTypes)VehiclesDictionary.dict[vehicleType]["Fuel Type"];
                float maxEnergy = (float)VehiclesDictionary.dict[vehicleType]["Maximum Energy"];
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                i_Parameters[i_Parameters.Length - 2] = maxEnergy;
                i_Parameters[i_Parameters.Length - 1] = fuelType;
                obj = ci.Invoke(i_Parameters);
            }
            else
            {
                ConstructorInfo ci = i_Type.GetConstructors()[0];
                obj = ci.Invoke(i_Parameters);
            }

            return obj;
        }
        private object parseTypeToEnum(Type i_Type, object i_EnumType)
        {
            object obj = null;

            if (Enum.IsDefined(i_EnumType.GetType(), i_Type.ToString()))
            {
                obj = Enum.Parse(i_EnumType.GetType(), i_Type.ToString());
            }
            else
            {
                throw new ArgumentException("Type does not exist in enum, or enum id not defined at all");
            }

            return obj;
        }

        public string GetVehicleInfo(string i_LicenseNumber)
        {
            Vehicle vehicle = GetVehicle(i_LicenseNumber);

            return vehicle.ToString();
        }
        public List<string> GetLicenses()
        {
            return new List<string>(m_Vehicles.Keys);
        }

        public List<string> GetLicensesByStatus(string i_GarageStatus)
        {
            Enums.eVehicleGarageStatus status = Enums.eVehicleGarageStatus.None;
            if (Enum.IsDefined(typeof(Enums.eVehicleGarageStatus), i_GarageStatus))
            {
                status = (Enums.eVehicleGarageStatus)Enum.Parse(typeof(Enums.eVehicleGarageStatus), i_GarageStatus);
            }
            else
            {
                throw new ArgumentException("Invalid Argument");
            }

            List<string> licenses = new List<string>();
            foreach (KeyValuePair<string, Vehicle> entry in m_Vehicles)
            {
                if (entry.Value.VehicleStatus == status || status == Enums.eVehicleGarageStatus.None)
                {
                    licenses.Add(entry.Key);
                }
            }

            return licenses;
        }

        public void UpadeVehicleStatus(string i_LicenseNumber, string i_Status)
        {
            Enums.eVehicleGarageStatus status = Enums.eVehicleGarageStatus.None;

            if (Enum.IsDefined(typeof(Enums.eVehicleGarageStatus), i_Status))
            {
                status = (Enums.eVehicleGarageStatus)Enum.Parse(typeof(Enums.eVehicleGarageStatus), i_Status);
            }
            else
            {
                GetVehicle(i_LicenseNumber).VehicleStatus = status;
            }
        }

        public bool IsLicenseNumberExists(string i_LicenseNumber)
        {

            return m_Vehicles.ContainsKey(i_LicenseNumber);
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
            Enums.eFuelTypes fuelType = Enums.eFuelTypes.None;

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

        public void Recharge(string i_LicenseNumber, float numberOfHoursToCharge)
        {
            if (m_Vehicles[i_LicenseNumber].Engine.GetType() != typeof(ElectricEngine))
            {
                throw new ArgumentException("Vehicle does not have electric engine.");
            }
            else
            {
                GetVehicle(i_LicenseNumber).Engine.Recharge(numberOfHoursToCharge);
            }
        }
        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle = null;
            if (!this.IsLicenseNumberExists(i_LicenseNumber))
            {
                throw new ArgumentException("License Number does not exist in garage.");
            }
            else
            {
                vehicle = m_Vehicles[i_LicenseNumber];
            }

            return vehicle;
        }
        public List<string> GetFuelTypes()
        {

            return Enum.GetNames(typeof(Enums.eFuelTypes)).Cast<string>().ToList();
        }
        public List<string> GetVehicleStatuses()
        {

            return Enum.GetNames(typeof(Enums.eVehicleGarageStatus)).Cast<string>().ToList();
        }
        public List<Type> GetVehicleTypes()
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
