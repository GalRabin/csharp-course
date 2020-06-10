using System;
using System.Collections.Generic;

namespace EX3
{
    public class InsertVehicle
    {
        private static Type GetTypeFromUser(List<Type> types, string preMessage)
        {
            Console.WriteLine($"{preMessage}:");
            for (int i = 0; i < types.Count; i++)
            {
                string simplifiedType = types[i].ToString().Split('.')[1];
                Console.WriteLine($"   {i + 1}. {simplifiedType}");
            }

            Console.Write("\nEnter your choice: ");

            return types[Utils.getValidIntegerInRangeFromUser(1, types.Count) - 1];
        }

        private static List<Wheel> getWheelsFromUser(int defaultNumberOfWheels)
        { 
            List<Wheel> wheels = new List<Wheel>();
            Console.Write($"Default number of wheels is {defaultNumberOfWheels}, Do you want to change it? (yes|no) ");
            if (Utils.getValidYesNoFromUser())
            {
                Console.Write("Enter number of wheels: ");
                defaultNumberOfWheels = Utils.getValidIntegerFromUser();
                Console.Clear();
            }
            for (int i = 0; i < defaultNumberOfWheels; i++)
            {
                Console.WriteLine($"Wheel {i + 1} - {defaultNumberOfWheels}");
                wheels.Add((Wheel)Utils.getConfigurationByObjectProperty(typeof(Wheel), false));
            }

            return wheels;
        }
        
        internal static void CreateNewVehicleInGarage(Garage garage)
        {
            GarageVehicle garageVehicle = (GarageVehicle) Utils.getConfigurationByObjectProperty(typeof(GarageVehicle));
            // Configure vehicle
            Type vehicleType = GetTypeFromUser(garage.GetVehicleTypes(), "Choose vehicle type");
            Vehicle vehicle = (Vehicle)Utils.getConfigurationByObjectProperty(vehicleType);
            // Configure vehicle engine
            Type engineType = GetTypeFromUser(garage.GetEngineTypes(), "Choose engine type");
            vehicle.Engine = Utils.getConfigurationByObjectProperty(engineType);
            // Configure vehicle wheels
            vehicle.Wheels = getWheelsFromUser(vehicle.DefaultNumberOfWheels());
            // Set up vehicle inside garage
            garageVehicle.Vehicle = vehicle;
            
            garage.AddGarageVehicle(garageVehicle);
        }
    }
}