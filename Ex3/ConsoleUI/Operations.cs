using System;
using System.Collections.Generic;
using System.Dynamic;
using GarageLogic;
using GarageLogic.Vehicles;

namespace ConsoleUI
{
    public class Operations
    {
        private static Dictionary<string, object> GetCommonVehicleProperties(Garage i_Garage)
        {
            Dictionary<string,object> commonPropertirs = new Dictionary<string, object>();
            Console.Write("Enter vehicle license number:");
            commonPropertirs["i_LicenseNumber"] = Utils.GetValidStringFromUser();
            if (i_Garage.IsLicenseNumberExists((string)commonPropertirs["i_LicenseNumber"]))
            {
                Console.WriteLine("Vehicle with license number {0} found, edit existing vehicle");
            }
            Console.Write("Enter vehicle owner name:");
            commonPropertirs["i_OwnerName"] = Utils.GetValidStringFromUser();
            Console.Write("Enter vehicle owner phone number:");
            commonPropertirs["i_OwnerPhoneNumber"] = Utils.GetValidStringFromUser();
            Console.Write("Enter vehicle model:");
            commonPropertirs["i_ModelName"] = Utils.GetValidStringFromUser();

            return commonPropertirs;
        }
        internal static void InsertVehicle(Garage i_Garage)
        {
            List<Type> vehicleTypes = VehicleGenerator.GetVehicleTypes();
            Console.Write(Messages.ChooseVehicleType(vehicleTypes));
            Type vehicleType = vehicleTypes[Utils.GetValidInRangeFromUser(1, vehicleTypes.Count) - 1];

            Dictionary<string, object> vehicleConfiguration = Utils.GetConfigurationByPropertiesType(vehicleType);
            Vehicle vehicle = VehicleGenerator.GenerateVehicle()
        }
        
        public static void ListVehicles(Garage i_Garage)
        {
            
        }
        
        public static void ChangeVehicleStatus(Garage i_Garage)
        {
            
        }
        
        public static void InflateWheelsToMax(Garage i_Garage)
        {
            
        }
        
        public static void RefuelVehicle(Garage i_Garage)
        {
            
        }
        
        public static void RechargeVehicle(Garage i_Garage)
        {
            
        }
        
        public static void DisplayVehicle(Garage i_Garage)
        {
            
        }
    }
}
