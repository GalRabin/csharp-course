using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EX3
{
    public class UserInterface
    {
        private enum Operations
        {
            None,
            InsertVehicle,
            ListPlates,
            ChangeStatus,
            InflateWheels,
            Refuel,
            Recharge,
            DisplayVehicle,
            Exit
        }

        private static GarageVehicle.VehicleGarageStatus getStatusFromUser()
        {
            Type statusType = typeof(GarageVehicle.VehicleGarageStatus);
            Utils.printPrettyEnumChoices(statusType);

            return (GarageVehicle.VehicleGarageStatus) Utils.getValidEnumFromUser(statusType);
        }
        
        private static FuelEngine.FuelTypes getFuelTypeFromUser()
        {
            Type fuelType = typeof(FuelEngine.FuelTypes);
            Utils.printPrettyEnumChoices(fuelType);

            return (FuelEngine.FuelTypes) Utils.getValidEnumFromUser(fuelType);
        }

        private static void waitToUserInteraction()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        
        private static void listPlates (Garage garage)
        {
            Console.WriteLine("Choose status of vehicles to list:");
            List<string> plates = garage.ListVehicleLicenseNumber(getStatusFromUser());
            foreach (string plate in plates)
            {
                Console.WriteLine(plate);
            }

            waitToUserInteraction();
        }

        private static void changeStatus(Garage garage)
        {
            string licenseNumber;
            while (true)
            {
                try
                {
                    Console.Write("Type car license number: ");
                    licenseNumber = Console.ReadLine();
                    garage.ChangeVehicleStatus(licenseNumber, getStatusFromUser());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: ");
                }
            }
        }
        
        private static void inflateWheels(Garage garage)
        {
            string licenseNumber;
            while (true)
            {
                try
                {
                    Console.Write("Type car license number: ");
                    licenseNumber = Console.ReadLine();
                    garage.InflateWheelsToMax(licenseNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: ");
                }
            }
        }
        
        private static void refuel(Garage garage)
        {
            string licenseNumber;
            float fuelToRefuel;
            while (true)
            {
                try
                {
                    Console.Write("Type car license number: ");
                    licenseNumber = Console.ReadLine();
                    Console.Write("How much to fuel in liters: ");
                    fuelToRefuel = Utils.getValidFloatFromUser();
                    Console.WriteLine("Choose fuel type");
                    garage.RefuelEngine(licenseNumber, getFuelTypeFromUser(), fuelToRefuel);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: ");
                }
            }
        }
        
        private static void recharge(Garage garage)
        {
            string licenseNumber;
            while (true)
            {
                try
                {
                    Console.Write("Type car license number: ");
                    licenseNumber = Console.ReadLine();
                    Console.Write("How much hours to charge: ");
                    garage.ChargeEngine(licenseNumber, Utils.getValidFloatFromUser());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: ");
                }
            }
        }

        private static void displayVehicle(Garage garage)
        {
            // TODO 
        }
        

        private static void RunConsoleUserInterface()
        {
            Garage garage = new Garage();
            Operations operation = Operations.None;
            while (operation != Operations.Exit)
            {
                Utils.printPrettyEnumChoices(typeof(Operations));
                operation = (Operations)Utils.getValidEnumFromUser(typeof(Operations));
                switch (operation)
                {
                    case Operations.InsertVehicle:
                        InsertVehicle.CreateNewVehicleInGarage(garage);
                        break;
                    case Operations.ListPlates:
                        listPlates(garage);
                        break;
                    case Operations.ChangeStatus:
                        changeStatus(garage);
                        break;
                    case Operations.InflateWheels:
                        inflateWheels(garage);
                        break;
                    case Operations.Refuel:
                        refuel(garage);
                        break;
                    case Operations.Recharge:
                        recharge(garage);
                        break;
                    case Operations.DisplayVehicle:
                        break;
                }
            }
        }
        public static void Main()
        {
            RunConsoleUserInterface();
        }
        
    }
}