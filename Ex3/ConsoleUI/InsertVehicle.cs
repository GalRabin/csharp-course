using System;
using System.Collections.Generic;

namespace EX3
{
    public class InsertVehicle
    {
        private static Type GetTypeFromUser(List<Type> i_Types, string i_PreMessage)
        {
            Console.WriteLine($"{i_PreMessage}:");

            for (int i = 0; i < i_Types.Count; i++)
            {
                string simplifiedType = i_Types[i].ToString().Split('.')[1];
                Console.WriteLine($"   {i + 1}. {simplifiedType}");
            }

            Console.Write("\nEnter your choice: ");

            return i_Types[Utils.GetValidIntegerInRangeFromUser(1, i_Types.Count) - 1];
        }

        private static List<Wheel> getWheelsFromUser(int i_DefaultNumberOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>();
            Console.Write($"Default number of wheels is {i_DefaultNumberOfWheels}, Do you want to change it? (yes|no) ");

            if (Utils.GetValidYesNoFromUser())
            {
                Console.Write("Enter number of wheels: ");
                i_DefaultNumberOfWheels = Utils.GetValidIntegerFromUser();
                Console.Clear();
            }

            for (int i = 0; i < i_DefaultNumberOfWheels; i++)
            {
                Console.WriteLine($"Wheel {i + 1} - {i_DefaultNumberOfWheels}");
                wheels.Add((Wheel)Utils.GetConfigurationByObjectProperty(typeof(Wheel), false));
            }

            return wheels;
        }

        internal static void CreateNewVehicleInGarage(Garage i_Garage)
        {
            // Configure vehicle
            Type vehicleType = GetTypeFromUser(i_Garage.GetVehicleTypes(), "Choose vehicle type");
            Type engineType = GetTypeFromUser(i_Garage.GetEngineTypes(), "Choose engine type");

            Vehicle vehicle = i_Garage.getDefaultProperties(vehicleType, engineType);
            /* 
             * Have to ask only the non default props
             * Maybe give vehicle to utils to ask specific questions
             * * */

            //Vehicle vehicle = (Vehicle)Utils.getConfigurationByObjectProperty(vehicleType);

            GarageVehicle garageVehicle = (GarageVehicle)Utils.GetConfigurationByObjectProperty(typeof(GarageVehicle));      
            
            // check if already exist
            bool isAlreadyInGarage = false;

            if (i_Garage.GetVehicle(vehicle.LicenseNumber) != null)
            {
                isAlreadyInGarage = true;
                garageVehicle = i_Garage.GetVehicle(vehicle.LicenseNumber);
                vehicle = garageVehicle.Vehicle;
                garageVehicle.VehicleStatus = GarageVehicle.eVehicleGarageStatus.InRepair;
                Console.WriteLine("Vehicle is already in garage and move to In Repair mode.\n" +
                    "Next steps will relate to that vehicle\n");
            }
            // Configure vehicle engine
            vehicle.Engine = Utils.GetConfigurationByObjectProperty(engineType);
            // Configure vehicle wheels
            vehicle.Wheels = getWheelsFromUser(vehicle.DefaultNumberOfWheels());

            if (!isAlreadyInGarage)
            {
                // Set up vehicle inside garage
                garageVehicle.Vehicle = vehicle;
                i_Garage.AddGarageVehicle(garageVehicle);
            }
        }
    }
}
