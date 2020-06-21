using System;
using System.Reflection;
using GarageLogic;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleUI
{
    public class Menu
    {
        public Menu()
        {
            Garage garage = new Garage();
            
            Enums.eMenuOperations operation = Enums.eMenuOperations.None;
            while (operation != Enums.eMenuOperations.Exit)
            {
                Console.Clear();
                Console.Write(Messages.MenuOperations());
                operation = (Enums.eMenuOperations)Utils.GetValidEnumFromUser(typeof(Enums.eMenuOperations));
                Console.Clear();
                switch (operation)
                {
                    case Enums.eMenuOperations.InsertVehicle:
                        Operations.InsertVehicle(garage);
                        break;
                    case Enums.eMenuOperations.ListPlates:
                        Operations.ListVehicles(garage);
                        break;
                    case Enums.eMenuOperations.ChangeStatus:
                        Operations.ChangeVehicleStatus(garage);
                        break;
                    case Enums.eMenuOperations.InflateWheels:
                        Operations.InflateWheelsToMax(garage);
                        break;
                    case Enums.eMenuOperations.Refuel:
                        Operations.RefuelVehicle(garage);
                        break;
                    case Enums.eMenuOperations.Recharge:
                        Operations.RechargeVehicle(garage);
                        break;
                    case Enums.eMenuOperations.DisplayVehicle:
                        Operations.DisplayVehicle(garage);
                        break;
                }
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}