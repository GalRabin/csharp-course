using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public static class Messages
    {
        private static readonly Dictionary<int, string> r_MenuOperations = new Dictionary<int, string>()
        {
            {(int)MainMenu.eMenuOperations.InsertVehicle, "Insert new vehicle"},
            {(int)MainMenu.eMenuOperations.ListPlates, "List plates"},
            {(int)MainMenu.eMenuOperations.ChangeStatus, "Change vehicle status in garage"},
            {(int)MainMenu.eMenuOperations.Refuel, "Refuel vehicle"},
            {(int)MainMenu.eMenuOperations.Recharge, "Recharge vehicle"},
            {(int)MainMenu.eMenuOperations.InflateWheels, "Infalte wheels to maximum"},
            {(int)MainMenu.eMenuOperations.DisplayVehicle, "Display vehicle details"},
            {(int)MainMenu.eMenuOperations.Exit, "Exit"}
        };
        internal const string k_InvalidInput = "Input is not valid, Enter input: ";
        private static readonly string sr_ChooseVehicleType = string.Format("Choose vehicle type:{0}", Environment.NewLine);
        internal const string k_EnterOption = "Enter option: ";
        internal const string k_YesOption = "yes";
        internal const string k_NoOption = "no";
        internal static readonly string k_OptionFormat = "\t{0}. {1}" + Environment.NewLine;
        private static readonly string sr_EnterVehicleStatus = string.Format("Choose vehicle status:{0}", Environment.NewLine);
        private static readonly string sr_ChooseOperationToPerform = string.Format("Choose operation to perform:{0}", Environment.NewLine);
        internal static readonly string sr_VehicleAllreadyExist = string.Format(
                "Vehicle already exist in the garage. {0} The system use the original configuration and updated vehicle status to in repair.{1}",
                Environment.NewLine, Environment.NewLine);
        internal static readonly string sr_EnterLicenseNumber = string.Format("Enter License Number: {0}", Environment.NewLine);
        internal static readonly string sr_TypeAmoutOfFuel = string.Format("Type amount of fuel to refuel {0}", Environment.NewLine);
        internal static readonly string sr_TypeAmountOfCharge = string.Format("Type amount of minutes to charge: {0}", Environment.NewLine);
        
        internal static string MenuOperations()
        {
            StringBuilder message = new StringBuilder();
            message.Append(sr_ChooseOperationToPerform);
            message.Append(Utils.ExtractEnumChoices(typeof(MainMenu.eMenuOperations), r_MenuOperations));
            message.Append(k_EnterOption);
            
            return message.ToString();
        }
        
        internal static string ChooseVehicleType(List<Type> i_VehicleTypes)
        {
            StringBuilder message = new StringBuilder();
            message.Append(sr_ChooseVehicleType);

            for (int i = 0; i < i_VehicleTypes.Count; i++)
            {
                string simplifiedType = Utils.SplitCamelCase(i_VehicleTypes[i].ToString().Split('.')[^1]);
                message.Append(string.Format(k_OptionFormat, i + 1, simplifiedType));
            }

            message.Append(k_EnterOption);
            
            return message.ToString();
        }
        internal static string ChooseVehicleStatus(List<string> i_VehicleStatus)
        {
            StringBuilder message = new StringBuilder();
            message.Append(sr_EnterVehicleStatus);

            for (int i = 0; i < i_VehicleStatus.Count; i++)
            {
                string simplifiedType = Utils.SplitCamelCase(i_VehicleStatus[i].Split('.')[^1]);
                message.Append(string.Format(k_OptionFormat, i + 1, simplifiedType));
            }

            message.Append(k_EnterOption);

            return message.ToString();
        }
        internal static string EnterKey(string i_Key, string i_OrganizeKey)
        {

            return $"{i_Key} - Enter {i_OrganizeKey}: ";
        }
        internal static string EnterYesNoKey(string i_Key, string i_OrganizeKey)
        {

            return $"{i_Key} - Enter {i_OrganizeKey}: (yes/no)";
        }
        internal static string EnterObjectConfigurations(Type i_Type)
        {

            return string.Format("Enter {0} configurations: ", i_Type.Name) + Environment.NewLine;
        }
    }
}