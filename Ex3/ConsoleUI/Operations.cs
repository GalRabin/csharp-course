using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using GarageLogic;
using GarageLogic.Exceptions;
using GarageLogic.Vehicles;

namespace ConsoleUI
{
    public class Operations
    {
        internal static void InsertVehicle(Garage i_Garage)
        {
            List<Type> vehicleTypes = i_Garage.GetVehicleTypes();
            Console.Write(Messages.ChooseVehicleType(vehicleTypes));
            Type vehicleType = vehicleTypes[Utils.GetValidInRangeFromUser(1, vehicleTypes.Count) - 1];
            Dictionary<string, Type> vehicleConfiguration = i_Garage.GetEmptyDictionary(vehicleType);
            Dictionary<string, Type> prettyVehicleConfiguration = Utils.PrettyEmptyDictionary(vehicleConfiguration);
            Dictionary<string, object> vehicleValues = Utils.GetConfigurationByDictionary(prettyVehicleConfiguration, i_Garage, vehicleType);
            
            if(!i_Garage.InsertVehicle(vehicleType, vehicleValues))
            {
                Console.WriteLine("Vehicle already exist in the garage." + Environment.NewLine +
                                "The system use the original configuration and updated vehicle status to in repair." + Environment.NewLine);
            }      
        }
        
        public static void ListVehicles(Garage i_Garage)
        {
            List<string> vehicleStatuses = i_Garage.GetVehicleStatuses();
            Console.WriteLine(Messages.ChooseVehicleStatus(vehicleStatuses));
            string vehicleStatus = vehicleStatuses[Utils.GetValidInRangeFromUser(1, vehicleStatuses.Count) - 1];
            List<string> vehicles = i_Garage.GetLicensesByStatus(vehicleStatus);

            foreach(string str in vehicles)
            {
                Console.WriteLine(str + Environment.NewLine);
            }
        }
        
        public static void ChangeVehicleStatus(Garage i_Garage)
        {
            Console.WriteLine("Enter License Number: " + Environment.NewLine);
            string licenseNumber = Utils.GetValidStringFromUser();
            List<string> vehicleStatuses = i_Garage.GetVehicleStatuses();
            Console.WriteLine(Messages.ChooseVehicleStatus(vehicleStatuses));
            string vehicleStatus = vehicleStatuses[Utils.GetValidInRangeFromUser(1, vehicleStatuses.Count) - 1];
            
            try
            {
                i_Garage.UpadeVehicleStatus(licenseNumber, vehicleStatus);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        
        public static void InflateWheelsToMax(Garage i_Garage)
        {
            Console.WriteLine("Enter License Number: " + Environment.NewLine);
            string licenseNumber = Utils.GetValidStringFromUser();

            try
            {
                i_Garage.InflateWheelsToMax(licenseNumber);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
        
        public static void RefuelVehicle(Garage i_Garage)
        {
            Console.WriteLine("Enter License Number: " + Environment.NewLine);
            string licenseNumber = Utils.GetValidStringFromUser();

            List<string> fuelTypes = i_Garage.GetFuelTypes();
            Console.WriteLine(Messages.ChooseVehicleStatus(fuelTypes));
            string fuelType = fuelTypes[Utils.GetValidInRangeFromUser(1, fuelTypes.Count) - 1];

            Console.WriteLine("Type amount of fuel to refuel " + Environment.NewLine);
            float fuelAmount = Utils.GetValidFloatFromUser();

            try
            {
                i_Garage.Refuel(licenseNumber, fuelType, fuelAmount);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }

        }
        
        public static void RechargeVehicle(Garage i_Garage)
        {
            Console.WriteLine("Enter License Number: " + Environment.NewLine);
            string licenseNumber = Utils.GetValidStringFromUser();

            Console.WriteLine("Type amount of minutes to charge: " + Environment.NewLine);
            float chargeAmount = Utils.GetValidFloatFromUser();

            try
            {
                i_Garage.Recharge(licenseNumber, chargeAmount);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }
        }
        public static void DisplayVehicle(Garage i_Garage)
        {
            Console.WriteLine("Enter License Number: " + Environment.NewLine);
            string licenseNumber = Utils.GetValidStringFromUser();

            try
            {
                Console.WriteLine(i_Garage.GetVehicleInfo(licenseNumber));
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
