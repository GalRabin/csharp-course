using System;
using GarageLogic;

namespace ConsoleUI
{
    public class MainMenu
    {
        public MainMenu()
        {
            Garage garage = new Garage();

            eMenuOperations operation = eMenuOperations.None;
            while (operation != eMenuOperations.Exit)
            {
                Console.Clear();
                Console.Write(Messages.MenuOperations());
                operation = (eMenuOperations) Utils.GetValidEnumFromUser(typeof(eMenuOperations));
                Console.Clear();
                switch (operation)
                {
                    case eMenuOperations.InsertVehicle:
                        Operations.InsertVehicle(garage);
                        break;
                    case eMenuOperations.ListPlates:
                        Operations.ListVehicles(garage);
                        break;
                    case eMenuOperations.ChangeStatus:
                        Operations.ChangeVehicleStatus(garage);
                        break;
                    case eMenuOperations.InflateWheels:
                        Operations.InflateWheelsToMax(garage);
                        break;
                    case eMenuOperations.Refuel:
                        Operations.RefuelVehicle(garage);
                        break;
                    case eMenuOperations.Recharge:
                        Operations.RechargeVehicle(garage);
                        break;
                    case eMenuOperations.DisplayVehicle:
                        Operations.DisplayVehicle(garage);
                        break;
                }

                System.Threading.Thread.Sleep(2000);
            }
        }
        
        internal enum eMenuOperations
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
    }
}