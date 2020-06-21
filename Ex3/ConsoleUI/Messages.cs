using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Messages
    {
        private static Dictionary<int, string> menuOperations = new Dictionary<int, string>()
        {
            {(int)Enums.eMenuOperations.InsertVehicle, "Insert new vehicle"},
            {(int)Enums.eMenuOperations.ListPlates, "List plates"},
            {(int)Enums.eMenuOperations.ChangeStatus, "Change vehicle status in garage"},
            {(int)Enums.eMenuOperations.Refuel, "Refuel vehicle"},
            {(int)Enums.eMenuOperations.Recharge, "Recharge vehicle"},
            {(int)Enums.eMenuOperations.InflateWheels, "Infalte wheels to maximum"},
            {(int)Enums.eMenuOperations.DisplayVehicle, "Display vehicle details"},
            {(int)Enums.eMenuOperations.Exit, "Exit"}
        };

        internal const string k_InvalidInput = "Input is not valid, Enter input: ";

        internal static string MenuOperations()
        {
            StringBuilder message = new StringBuilder();
            message.Append(string.Format("Choose operation to perform:{0}", Environment.NewLine));
            message.Append(Utils.ExtractEnumChoices(typeof(Enums.eMenuOperations), menuOperations));
            message.Append("Enter option: ");
            
            return message.ToString();
        }
        
        internal static string ChooseVehicleType(List<Type> i_VehicleTypes)
        {
            StringBuilder message = new StringBuilder();
            message.Append(string.Format("Choose vehicle type:{0}", Environment.NewLine));
            for (int i = 0; i < i_VehicleTypes.Count; i++)
            {
                string simplifiedType = Utils.SplitCamelCase(i_VehicleTypes[i].ToString().Split('.')[^1]);
                message.Append(string.Format("\t{0}. {1}.{2}", i + 1, simplifiedType, Environment.NewLine));
            }
            message.Append("Enter option: ");
            
            return message.ToString();
        }
        internal static string ChooseVehicleStatus(List<string> i_VehicleStatus)
        {
            StringBuilder message = new StringBuilder();
            message.Append(string.Format("Choose vehicle status:{0}", Environment.NewLine));
            for (int i = 0; i < i_VehicleStatus.Count; i++)
            {
                string simplifiedType = Utils.SplitCamelCase(i_VehicleStatus[i].Split('.')[^1]);
                message.Append(string.Format("\t{0}. {1}.{2}", i + 1, simplifiedType, Environment.NewLine));
            }
            message.Append("Enter option: ");

            return message.ToString();
        }
    }
}