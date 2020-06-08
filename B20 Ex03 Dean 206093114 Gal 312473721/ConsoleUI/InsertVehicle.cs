using System;
using System.Collections.Generic;

namespace EX3
{
    public class InsertVehicle
    {
        private static string getModelNameFromUser()
        {
            Console.Write("Enter car model name: ");
            
            return Console.ReadLine();
        }

        private static string getLicenseNumberFromUser()
        {
            Console.Write("Enter car license number: ");
            return Console.ReadLine();
        }
        
        private enum EngineType
        {
            Electric = 1,
            Fuel = 2
        }

        private static ElectricEngine getElectricEngineFromUser()
        {
            float remainingTimeOfEngineHours, maxTimeOfEngineHours;
            Console.Write("Enter engine remaining hours: ");
            while (!float.TryParse(Console.ReadLine(), out remainingTimeOfEngineHours))
            {
                Console.Write("Invalid input - Please enter valid float input: ");
            }
            
            Console.Write("Enter engine max hours: ");
            while (!float.TryParse(Console.ReadLine(), out maxTimeOfEngineHours))
            {
                Console.Write("Invalid input - Please enter valid float input: ");
            }
            
            return new ElectricEngine(remainingTimeOfEngineHours, maxTimeOfEngineHours);
        }

        private static FuelEngine getFuelEngineFromUser()
        {
            FuelEngine.FuelTypes fuelType;
            float currentAmountOfFuelsLiters;
            float maxAmountOfFuelsLiters;
            
            Console.Write("Enter current amount of fuel: ");
            while (!float.TryParse(Console.ReadLine(), out currentAmountOfFuelsLiters))
            {
                Console.Write("Invalid input - Please enter valid float input: ");
            }
            
            Console.Write("Enter max amount of fuel: ");
            while (!float.TryParse(Console.ReadLine(), out maxAmountOfFuelsLiters))
            {
                Console.Write("Invalid input - Please enter valid float input: ");
            }
            
            Console.Write($@"
Please choose fuel type:
{(int)FuelEngine.FuelTypes.Soler}. {FuelEngine.FuelTypes.Soler}.
{(int)FuelEngine.FuelTypes.Octane95}. {FuelEngine.FuelTypes.Octane95}.
{(int)FuelEngine.FuelTypes.Octane96}. {FuelEngine.FuelTypes.Octane96}.
{(int)FuelEngine.FuelTypes.Octane98}. {FuelEngine.FuelTypes.Octane98}.

Please choose fuel type: ");
            while (!FuelEngine.TryParseFuelType(Console.ReadLine(), out fuelType))
            {
                Console.Write("Invalid input - Please enter valid fuel type number: ");
            }
            
            return new FuelEngine(fuelType, currentAmountOfFuelsLiters, maxAmountOfFuelsLiters);
        }

        private static object getEngineFromUser(VehicleTypes vehicleType)
        {
            EngineType engineType;
            object engine = null;
            bool isDefinedResult;
            Console.Write($@"
Please engine of {vehicleType}:
{(int)EngineType.Electric}. {EngineType.Electric}.
{(int)EngineType.Fuel}. {EngineType.Fuel}.

Please choose engine type: ");
            do
            {
                Enum.TryParse(Console.ReadLine(), out engineType);
                isDefinedResult = Enum.IsDefined(typeof(EngineType), (int)engineType);
                if (!isDefinedResult)
                {
                    Console.Write("Invalid input please choose engine type: ");
                }
            } while (!isDefinedResult);

            switch (engineType)
            {
                case EngineType.Electric:
                    engine = getElectricEngineFromUser();
                    break;
                case EngineType.Fuel:
                    engine = getFuelEngineFromUser();
                    break;
            }

            return engine;
        }

        private static Motorcycle CreateMotocycle()
        {
            Motorcycle newMotocycle = new Motorcycle();
            newMotocycle.ModelName = getModelNameFromUser();
            newMotocycle.LicenseNumber = getLicenseNumberFromUser();
            int licenseType;
            int engineVolume;

            Console.Write($@"
Please choose motorcycle license type:
{(int)Motorcycle.MotorCycleLicenseTypes.A1}. {Motorcycle.MotorCycleLicenseTypes.A1}.
{(int)Motorcycle.MotorCycleLicenseTypes.A}. {Motorcycle.MotorCycleLicenseTypes.A}.
{(int)Motorcycle.MotorCycleLicenseTypes.AA}. {Motorcycle.MotorCycleLicenseTypes.AA}.
{(int)Motorcycle.MotorCycleLicenseTypes.B}. {Motorcycle.MotorCycleLicenseTypes.B}.

Please choose license type number: ");
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out licenseType))
                {
                    Console.Write("Invalid input - enter valid license type: ");
                }

                try
                {
                    newMotocycle.LicenseType = (Motorcycle.MotorCycleLicenseTypes)licenseType;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.Write("Invalid input - enter valid license type: ");
                }
            }
            
            Console.Write("Enter motorcycle engine volume as float (e.g. 300): ");
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out engineVolume))
                {
                    Console.Write("Invalid input - enter volume, enter again: ");
                }

                try
                {
                    newMotocycle.EngineVolume = engineVolume;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.Write("Invalid input - enter volume, enter again: ");
                }
            }

            newMotocycle.EngineVolume = engineVolume;
            
            return newMotocycle;
        }

        private static Truck CreateTruck()
        {
            Truck newTruck = new Truck();
            float cargoVolume;
            bool containsDangerousMaterials;
            newTruck.ModelName = getModelNameFromUser();
            newTruck.LicenseNumber = getLicenseNumberFromUser();
            Console.Write("Enter cargo volume as float (e.g. 17.3 in liters): ");
            while (!float.TryParse(Console.ReadLine(), out cargoVolume))
            {
                Console.Write("Invalid input - Please enter valid float input: ");
            }
            newTruck.CargoVolume = cargoVolume;
            Console.Write("Is the cargo include dangerous materials? (true|false) ");
            while (bool.TryParse(Console.ReadLine(), out containsDangerousMaterials))
            {
                
                Console.Write("Invalid input - Please enter true or false: ");
            }

            newTruck.ContainsDangerousMaterials = containsDangerousMaterials;
            
            return newTruck;
        }

        private static Car CreateCar()
        {
            Car newCar = new Car();

            int numberOfDoors;
            int color;
            newCar.ModelName = getModelNameFromUser();
            newCar.LicenseNumber = getLicenseNumberFromUser();
            Console.Write("Enter car number of doors [2-5]: ");
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out numberOfDoors))
                {
                    Console.Write("Invalid input - enter integer in range of 2-5: ");
                }

                try
                {
                    newCar.NumberOfDoors = numberOfDoors;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.Write("Invalid input - enter integer in range of 2-5: ");
                }
            }

            Console.Write($@"
Please choose car color:
{(int) Car.CarColors.Red}. {Car.CarColors.Red}.
{(int) Car.CarColors.Blue}. {Car.CarColors.Blue}.
{(int) Car.CarColors.Black}. {Car.CarColors.Black}.
{(int) Car.CarColors.Gray}. {Car.CarColors.Gray}.

Please choose color number: ");
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out color))
                {
                    Console.Write("Invalid input - enter integer in range of 2-5: ");
                }

                try
                {
                    newCar.Color = (Car.CarColors)color;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.Write("Invalid input - enter integer in range of 2-5: ");
                }
            }

            newCar.Engine = getEngineFromUser(VehicleTypes.Car);

            return newCar;
        }

        private enum VehicleTypes
        {
            Car = 1,
            Truck = 2,
            Motorcycle = 3
        }
        private static VehicleTypes GetVehicleInsertedType()
        {
            string keyboardInput;
            int keyboardInputAsInteger;
            string msg = $@"
Please enter the type of you vehicle:
{(int)VehicleTypes.Car}. Car.
{(int)VehicleTypes.Truck}. Truck.
{(int)VehicleTypes.Motorcycle}. Motorcycle.

Please vehicle type number: ";
            Console.Write(msg);

            keyboardInput = Console.ReadLine();
            while (int.TryParse(keyboardInput, out keyboardInputAsInteger) && !Enum.IsDefined(typeof(VehicleTypes), keyboardInputAsInteger)) {
                Console.Write("Not valid operation,  Please choose valid operation number: ");
                keyboardInput = Console.ReadLine();
            }

            return (VehicleTypes) Enum.Parse(typeof(VehicleTypes), keyboardInput);
        }
        
        internal static void CreateNewVehicleInGarage(Garage garageManagement)
        {
            string ownerPhoneNumber;
            string ownerName;
            Vehicle insertedVehicle = null;
            Console.Write("Enter vehicle owner name: ");
            ownerName = Console.ReadLine();
            Console.Write("Enter owner phone number: ");
            ownerPhoneNumber = Console.ReadLine();
            
            switch (GetVehicleInsertedType())
            {
                case VehicleTypes.Car:
                    insertedVehicle = CreateCar();
                    break;
                case VehicleTypes.Truck:
                    insertedVehicle = CreateTruck();
                    break;
                case VehicleTypes.Motorcycle:
                    insertedVehicle = CreateMotocycle();
                    break;
            }

            garageManagement.AddGarageVehicle(new GarageVehicle(ownerName, ownerPhoneNumber, insertedVehicle));
        }
    }
}