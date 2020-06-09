using System;

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

        private static void RunConsoleUserinterface()
        {
            Garage garageManagement = new Garage();
            Operations operation = Operations.None;
            while (operation != Operations.Exit)
            {
                Utils.printPrettyEnumChoices(typeof(Operations), "Please choose operation in garage", "Choose operation");
                operation = (Operations)Utils.getValidEnumFromUser(typeof(Operations));
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