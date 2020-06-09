using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EX3
{
    public class Utils
    {
        internal enum VehicleTypes
        {
            None,
            Car,
            Truck,
            Motorcycle
        }
        
        internal enum EngineType
        {
            None,
            Electric,
            Fuel
        }
        
        internal static void getValidPropertyFromUser(object target, string targetProperty, Type type = null)
        {
            string otherResponse = "";
            int integerResponse = -1;
            float floatResponse = -1;
            bool boolResponse = false;
            Type targetType = target.GetType();
            PropertyInfo property = targetType.GetProperty(targetProperty);
            while (true)
            {
                if (type == typeof(int))
                {
                    while (!int.TryParse(Console.ReadLine(), out integerResponse))
                    {
                        Console.Write("Invalid input - enter valid integer value: ");
                    }
                }
                else if (type == typeof(float))
                {
                    while (!float.TryParse(Console.ReadLine(), out floatResponse))
                    {
                        Console.Write("Invalid input - enter valid float value: ");
                    }
                } 
                else if (type == typeof(bool))
                {
                    while (!bool.TryParse(Console.ReadLine(), out boolResponse))
                    {
                        Console.Write("Invalid input - enter valid bool value: ");
                    }
                }
                else
                {
                    while ((otherResponse = Console.ReadLine()).Length == 0)
                    {
                        Console.Write("Invalid input - enter valid string value: ");
                    }
                }

                try
                {
                    if (type == typeof(int))
                    {
                        property.SetValue (target, integerResponse, null);
                    }
                    else if (type == typeof(float))
                    {
                        property.SetValue (target, floatResponse, null);
                    }
                    else if (type == typeof(bool))
                    {
                        property.SetValue (target, boolResponse, null);
                    }
                    else
                    {
                        property.SetValue (target, otherResponse, null);
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.Write($"Invalid input - {e.Message}, Enter value again: ");
                }
            }
        }
        
        internal static object getValidEnumFromUser(Type enumType)
        {
            string keyboardInput = Console.ReadLine();
            int keyboardInputAsInteger;
            while (int.TryParse(keyboardInput, out keyboardInputAsInteger) && !Enum.IsDefined(enumType, keyboardInputAsInteger) || keyboardInput ==null) {
                Console.Write("Invalid input, Please choose valid choice number: ");
                keyboardInput = Console.ReadLine();
            }
            Console.Clear();
            return Convert.ChangeType(Enum.Parse(enumType, keyboardInput), enumType);
        }
        
        public static string SplitCamelCase(string input)
        {
            return Regex.Replace(input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
        }
        
        internal static void printPrettyEnumChoices(Type enumType, string preMessage, string postMessage)
        {
            Console.WriteLine($"\n{preMessage}: ");
            foreach (object item in Enum.GetValues(enumType))
            {
                if (item.ToString() != "None")
                {
                    Console.WriteLine($"{(int)item}. {SplitCamelCase(item.ToString())}.");
                }
            }
            Console.Write($"\n{postMessage}: ");
        }
    }
}