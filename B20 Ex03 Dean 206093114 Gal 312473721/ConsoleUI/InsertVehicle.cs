using System;
using System.Security.Policy;

namespace EX3
{
    public class InsertVehicle
    {
        private static ElectricEngine getElectricEngineFromUser()
        { 
            ElectricEngine newEngine = new ElectricEngine();
            Console.Write("Enter engine remaining hours: ");
            Utils.getValidPropertyFromUser(newEngine,"RemainingTimeOfEngineHours", typeof(float));
            Console.Write("Enter engine max hours: ");
            Utils.getValidPropertyFromUser(newEngine, "MaxTimeOfEngineHours", typeof(float));

            return newEngine;
        }

        private static Wheel getWheelFromUser()
        {
            Wheel newWheel = new Wheel();
            Console.Write("Enter wheel manufacture name: ");
            Utils.getValidPropertyFromUser(newWheel, "ManufactureName");
            Console.Write("Enter wheel max presure: ");
            Utils.getValidPropertyFromUser(newWheel, "MaxAirPressure");
            Console.Write("Enter wheel current presure: ");
            Utils.getValidPropertyFromUser(newWheel, "CurrentAirPressure");

            return newWheel;
        }

        private static void getWheels(Vehicle vehicle, int numberOfWheels)
        {
            for (int i = 0; i < numberOfWheels; i++)
            {
                vehicle.AppendWheel(getWheelFromUser());
            }
        }

        private static FuelEngine getFuelEngineFromUser()
        {
            FuelEngine newEngine = new FuelEngine();
            // Remaining fuel
            Console.Write("Enter current amount of fuel: ");
            Utils.getValidPropertyFromUser(newEngine, "CurrentAmountOfFuelsLiters", typeof(float));
            // Max fuel
            Console.Write("Enter max amount of fuel: ");
            Utils.getValidPropertyFromUser(newEngine, "MaxAmountOfFuelsLiters", typeof(float));
            // Get fuel type
            Utils.printPrettyEnumChoices(typeof(FuelEngine.FuelTypes), "Please choose fuel type", "Choose fuel type");
            newEngine.FuelType = (FuelEngine.FuelTypes)Utils.getValidEnumFromUser(typeof(FuelEngine.FuelTypes));

            return newEngine;
        }

        private static void getEngineFromUser(Vehicle vehicle)
        {
            Utils.printPrettyEnumChoices(typeof(Utils.EngineType), "Please choose engine type", "Choose engine type");
            switch (Utils.getValidEnumFromUser(typeof(Utils.EngineType)))
            {
                case Utils.EngineType.Electric:
                    vehicle.Engine = getElectricEngineFromUser();
                    break;
                case Utils.EngineType.Fuel:
                    vehicle.Engine = getFuelEngineFromUser();
                    break;
            }
        }
        
        private static void getSharedVehicleParametersFromUser(Vehicle vehicle)
        {
            Console.Write("Enter car model name: ");
            vehicle.ModelName = Console.ReadLine();
            Console.Write("Enter car license number: ");
            vehicle.LicenseNumber = Console.ReadLine();
        }

        private static Motorcycle CreateMotocycle()
        {
            Motorcycle newMotocycle = new Motorcycle();
            // Model and plate
            getSharedVehicleParametersFromUser(newMotocycle);
            // License type configuration
            Utils.printPrettyEnumChoices(typeof(Motorcycle.MotorCycleLicenseTypes), "Please choose motorcycle license type", "Choose license type");
            newMotocycle.LicenseType = (Motorcycle.MotorCycleLicenseTypes)Utils.getValidEnumFromUser(typeof(Motorcycle.MotorCycleLicenseTypes));
            // Engine volume configuration
            Console.Write("Enter motorcycle engine volume as float (e.g. 300): ");
            Utils.getValidPropertyFromUser(newMotocycle, "EngineVolume", typeof(int));
            // Get wheels from user
            getWheels(newMotocycle, 2);

            return newMotocycle;
        }

        private static Truck CreateTruck()
        {
            Truck newTruck = new Truck();
            // Model and plate
            getSharedVehicleParametersFromUser(newTruck);
            // Cargo volume configuration
            Console.Write("Enter cargo volume as float (e.g. 17.3 in liters): ");
            Utils.getValidPropertyFromUser(newTruck,"CargoVolume", typeof(float));
            // Cargo dangerous material configuration
            Console.Write("Is the cargo include dangerous materials? (true|false) ");
            Utils.getValidPropertyFromUser(newTruck,"ContainsDangerousMaterials", typeof(bool));
            // Get wheels from user
            getWheels(newTruck, 4);

            return newTruck;
        }

        private static Car CreateCar()
        {
            Car newCar = new Car();
            // Model and plate
            getSharedVehicleParametersFromUser(newCar);
            // Doors configuration
            Console.Write("Enter car number of doors [2-5]: ");
            Utils.getValidPropertyFromUser(newCar, "NumberOfDoors", typeof(int));
            // Color configuration
            Utils.printPrettyEnumChoices(typeof(Car.CarColors), "Please choose car color", "Choose color");
            newCar.Color = (Car.CarColors)Utils.getValidEnumFromUser(typeof(Car.CarColors));
            // Get wheels from user
            getWheels(newCar,4);
            
            return newCar;
        }

        internal static void CreateNewVehicleInGarage(Garage garageManagement)
        {
            GarageVehicle newVehicle = new GarageVehicle();
            // Phone and name of car owner
            Console.Write("Enter vehicle owner name: ");
            Utils.getValidPropertyFromUser(newVehicle, "OwnerName");
            Console.Write("Enter owner phone number: ");
            Utils.getValidPropertyFromUser(newVehicle, "PhoneNumber");
            // Get Vehicle detalis
            Utils.printPrettyEnumChoices(typeof(Utils.VehicleTypes), "Please choose car type", "Choose type");
            switch (Utils.getValidEnumFromUser(typeof(Utils.VehicleTypes)))
            {
                case Utils.VehicleTypes.Car:
                    newVehicle.Vehicle = CreateCar();
                    break;
                case Utils.VehicleTypes.Truck:
                    newVehicle.Vehicle = CreateTruck();
                    break;
                case Utils.VehicleTypes.Motorcycle:
                    newVehicle.Vehicle = CreateMotocycle();
                    break;
            }

            getEngineFromUser(newVehicle.Vehicle);

            garageManagement.AddGarageVehicle(newVehicle);
            Console.Clear();
        }
    }
}