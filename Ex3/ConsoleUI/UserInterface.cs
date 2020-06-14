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

        private static GarageVehicle.eVehicleGarageStatus getStatusFromUser()
        {
            Type statusType = typeof(GarageVehicle.eVehicleGarageStatus);
            Utils.PrintPrettyEnumChoices(statusType);

            return (GarageVehicle.eVehicleGarageStatus) Utils.GetValidEnumFromUser(statusType);
        }
        
        private static FuelEngine.eFuelTypes getFuelTypeFromUser()
        {
            Type fuelType = typeof(FuelEngine.eFuelTypes);
            Utils.PrintPrettyEnumChoices(fuelType);

            return (FuelEngine.eFuelTypes) Utils.GetValidEnumFromUser(fuelType);
        }

        private static void waitToUserInteraction()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        
        private static void listPlates (Garage i_Garage)
        {
            Console.WriteLine("Choose status of vehicles to list or 0 for all of them:");
            GarageVehicle.eVehicleGarageStatus status = getStatusFromUser();
            List<string> plates = null; 

            if (status == GarageVehicle.eVehicleGarageStatus.None)
            {
                plates = i_Garage.ListAllVehicleLicenseNumber();
            }
            else
            {
                plates = i_Garage.ListVehicleLicenseNumberByStatus(status);
            }
            
            foreach (string plate in plates)
            {
                Console.WriteLine(plate);
            }

            waitToUserInteraction();
        }

        private static void changeStatus(Garage i_Garage)
        {
            string licenseNumber;

            while (true)
            {
                try
                {
                    Console.Write("Type car license number: ");
                    licenseNumber = Console.ReadLine();
                    i_Garage.ChangeVehicleStatus(licenseNumber, getStatusFromUser());
                    break;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"Error - Enter valid number from menu: /n");
                }
            }
        }
        
        private static void inflateWheels(Garage i_Garage)
        {
            string licenseNumber;

            while (true)
            {
                try
                {
                    Console.Write("Type car license number: ");
                    licenseNumber = Console.ReadLine();
                    i_Garage.InflateWheelsToMax(licenseNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: \n");
                }
            }
        }
        
        private static void refuel(Garage i_Garage)
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
                    fuelToRefuel = Utils.GetValidFloatFromUser();
                    Console.WriteLine("Choose fuel type");
                    i_Garage.RefuelEngine(licenseNumber, getFuelTypeFromUser(), fuelToRefuel);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: ");
                }
            }
        }
        
        private static void recharge(Garage i_Garage)
        {
            string licenseNumber;

            while (true)
            {
                try
                {
                    Console.Write("Type car license number: ");
                    licenseNumber = Console.ReadLine();
                    Console.Write("How much hours to charge: ");
                    i_Garage.ChargeEngine(licenseNumber, Utils.GetValidFloatFromUser());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: ");
                }
            }
        }

        private static void displayVehicle(Garage i_Garage)
        {
            string licenseNumber;
            GarageVehicle vehicle = null;

            while (true)
            {
                try
                {
                    Console.Write("Type car license number or -1 to exit: ");
                    licenseNumber = Console.ReadLine();
                    if(licenseNumber == "-1")
                    {
                        break;
                    }
                    vehicle = i_Garage.GetVehicle(licenseNumber);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e.Message}, Enter valid value again: ");
                }
            }

            if (licenseNumber != "-1")
            {
                string display = string.Format(
                    "License Number: {0}\n" +
                    "Model Name: {1}\n" +
                    "Owner Name: {2}\n" +
                    "Vehicle Status: {3}\n" +
                    "Wheels Info:\n {4}\n" +
                    "Engine Info:\n {5}\n" +
                    "Phone number for contact: {6}\n",
                    vehicle.Vehicle.LicenseNumber,
                    vehicle.Vehicle.ModelName,
                    vehicle.OwnerName,
                    vehicle.VehicleStatus,
                    vehicle.Vehicle.getWheelsInfo(),
                    vehicle.Vehicle.getEngineInfo(),
                    vehicle.PhoneNumber);

                Console.WriteLine(display);
            }
        }
        

        private static void RunConsoleUserInterface()
        {
            Garage garage = new Garage();
            Operations operation = Operations.None;

            while (operation != Operations.Exit)
            {
                Utils.PrintPrettyEnumChoices(typeof(Operations));
                operation = (Operations)Utils.GetValidEnumFromUser(typeof(Operations));

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
                        displayVehicle(garage);
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