using System;
using System.Collections.Generic;
using GarageLogic;
using GarageLogic.Exceptions;

namespace ConsoleUI
{
    public static class Operations
    {
        internal static void InsertVehicle(Garage i_Garage)
        {
            List<Type> vehicleTypes = Garage.GetVehicleTypes();
            Console.Write(Messages.ChooseVehicleType(vehicleTypes));
            Type vehicleType = vehicleTypes[Utils.GetValidInRangeFromUser(1, vehicleTypes.Count) - 1];
            Dictionary<string, Type> emptyVehicleConfigurations = i_Garage.GetEmptyDictionary(vehicleType);
            Dictionary<string, Type> prettyEmptyVehicleConfiguration = Utils.PrettyEmptyDictionary(emptyVehicleConfigurations);
            Dictionary<string, object> vehicleConfigurations = Utils.GetConfigurationByDictionary(prettyEmptyVehicleConfiguration, i_Garage, vehicleType);
            
            if(!i_Garage.InsertVehicle(vehicleType, vehicleConfigurations))
            {
                Console.WriteLine(Messages.sr_VehicleAllreadyExist);
            }      
        }
        
        public static void ListVehicles(Garage i_Garage)
        {
            List<string> vehicleStatuses = Garage.GetVehicleStatuses();
            Console.WriteLine(Messages.ChooseVehicleStatus(vehicleStatuses));
            string vehicleStatus = vehicleStatuses[Utils.GetValidInRangeFromUser(1, vehicleStatuses.Count) - 1];
            IEnumerable<string> vehicles = i_Garage.GetLicensesByStatus(vehicleStatus);

            foreach(string str in vehicles)
            {
                Console.WriteLine(str + Environment.NewLine);
            }
        }
        
        public static void ChangeVehicleStatus(Garage i_Garage)
        {
            Console.WriteLine(Messages.sr_EnterLicenseNumber);
            string licenseNumber = Utils.GetValidStringFromUser();
            List<string> vehicleStatuses = Garage.GetVehicleStatuses();
            Console.WriteLine(Messages.ChooseVehicleStatus(vehicleStatuses));
            string vehicleStatus = vehicleStatuses[Utils.GetValidInRangeFromUser(1, vehicleStatuses.Count) - 1];
            
            try
            {
                i_Garage.UpdateVehicleStatus(licenseNumber, vehicleStatus);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public static void InflateWheelsToMax(Garage i_Garage)
        {
            Console.WriteLine(Messages.sr_EnterLicenseNumber);
            string licenseNumber = Utils.GetValidStringFromUser();

            try
            {
                i_Garage.InflateWheelsToMax(licenseNumber);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        
        public static void RefuelVehicle(Garage i_Garage)
        {
            Console.WriteLine(Messages.sr_EnterLicenseNumber);
            string licenseNumber = Utils.GetValidStringFromUser();
            List<string> fuelTypes = Garage.GetFuelTypes();
            Console.WriteLine(Messages.ChooseVehicleStatus(fuelTypes));
            string fuelType = fuelTypes[Utils.GetValidInRangeFromUser(1, fuelTypes.Count) - 1];
            Console.WriteLine(Messages.sr_TypeAmoutOfFuel);
            float fuelAmount = Utils.GetValidFloatFromUser();

            try
            {
                i_Garage.Refuel(licenseNumber, fuelType, fuelAmount);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public static void RechargeVehicle(Garage i_Garage)
        {
            Console.WriteLine(Messages.sr_EnterLicenseNumber);
            string licenseNumber = Utils.GetValidStringFromUser();
            Console.WriteLine(Messages.sr_TypeAmountOfCharge);
            float chargeAmount = Utils.GetValidFloatFromUser();

            try
            {
                i_Garage.Recharge(licenseNumber, chargeAmount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DisplayVehicle(Garage i_Garage)
        {
            Console.WriteLine(Messages.sr_EnterLicenseNumber);
            string licenseNumber = Utils.GetValidStringFromUser();

            try
            {
                Console.WriteLine(i_Garage.GetVehicleInfo(licenseNumber));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
