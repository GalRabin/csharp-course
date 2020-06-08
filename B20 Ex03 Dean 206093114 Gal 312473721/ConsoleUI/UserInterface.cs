using System;

namespace EX3
{
    public class UserInterface
    {
        private enum Operations
        {
            Idle,
            InsertVehicle,
            ListPlates,
            ChangeStatus,
            InflateWheels,
            Refuel,
            Recharge,
            DisplayVehicle,
            Exit
        }

        private static Operations ChooseOperationToPerformInGarage()
        {
            string msg = $@"
Welcome to our garage!

Please choose operation you want to perform:
{(int)Operations.InsertVehicle}. Insert new vehicle to garage.
{(int)Operations.ListPlates}. List current license plates in garage.
{(int)Operations.ChangeStatus}. Change vehicle repair status.
{(int)Operations.InflateWheels}. Inflate wheels in vehicle to Maximum capacity.
{(int)Operations.Refuel}. Refuel vehicle.
{(int)Operations.Recharge}. Recharge vehicle.
{(int)Operations.DisplayVehicle}. Display vehicle information.
{(int)Operations.Exit}. Exit program.

Please choose you desired operation number: ";
            Console.Write(msg);
            
            int keyboardInputAsInteger;
            string keyboardInput = Console.ReadLine();
            while (int.TryParse(keyboardInput, out keyboardInputAsInteger) && !Enum.IsDefined(typeof(Operations), keyboardInputAsInteger)) {
                Console.Write("Not valid operation,  Please choose valid operation number: ");
                keyboardInput = Console.ReadLine();
            }
            Console.Clear();
            
            return (Operations)Enum.Parse(typeof(Operations), keyboardInput);
        }
        
        private static void RunConsoleUserinterface()
        {
            Garage garageManagement = new Garage();
            Operations operation = Operations.Idle;
            while (operation != Operations.Exit)
            {
                operation = ChooseOperationToPerformInGarage();
                switch (operation)
                {
                    case Operations.InsertVehicle:
                        InsertVehicle.CreateNewVehicleInGarage(garageManagement);
                        break;
                    case Operations.ListPlates:
                        break;
                    case Operations.ChangeStatus:
                        break;
                    case Operations.InflateWheels:
                        break;
                    case Operations.Refuel:
                        break;
                    case Operations.Recharge:
                        break;
                    case Operations.DisplayVehicle:
                        break;
                }
            }
        }
        public static void Main()
        {
            RunConsoleUserinterface();
        }
        
    }
}