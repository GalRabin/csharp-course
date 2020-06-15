using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    public class Utils
    {
        internal static bool GetValidYesNoFromUser()
        {
            string response = Console.ReadLine();

            while (response != "yes" && response != "no")
            {
                Console.Write("Invalid input - enter valid string value: ");
                response = Console.ReadLine();
            }

            return response == "yes";
        }
        internal static int GetValidInRangeFromUser(int min, int max)
        {
            int response = -1;
            
            while (!int.TryParse(Console.ReadLine(), out response) || min > response || response > max)
            {
                Console.Write(Messages.k_InvalidInput);
            }

            return response;
        }
        internal static int GetValidIntegerFromUser()
        {
            int response = -1;
            
            while (!int.TryParse(Console.ReadLine(), out response))
            {
                Console.Write(Messages.k_InvalidInput);
            }

            return response;
        }
        
        internal static float GetValidFloatFromUser()
        {
            float response;
            
            while (!float.TryParse(Console.ReadLine(), out response))
            {
                Console.Write(Messages.k_InvalidInput);
            }

            return response;
        }
        
        internal static string GetValidStringFromUser()
        {
            string response;
            while ((response = Console.ReadLine()).Length == 0)
            {
                Console.Write("Invalid input - enter valid string value: ");
            }

            return response;
        }

        internal static string ExtractEnumChoices(Type i_EnumType, Dictionary<int, string> i_EnumTranslation)
        {
            StringBuilder message = new StringBuilder();
            string[] enumNames = Enum.GetNames(i_EnumType);
            
            for (int i = 1; i < enumNames.Length; i++)
            {
                message.Append(string.Format("\t{0}. {1}{2}", i, i_EnumTranslation[i], Environment.NewLine));
            }

            return message.ToString();
        }
        
        internal static int GetValidEnumFromUser(Type i_Enum)
        {
            int keyboardInputAsInteger;
            
            while (int.TryParse(Console.ReadLine(), out keyboardInputAsInteger) && !Enum.IsDefined(i_Enum, keyboardInputAsInteger)) {
                Console.Write(Messages.k_InvalidInput);
            }

            return keyboardInputAsInteger;
        }
        
        internal static string SplitCamelCase(string input)
        {
            return Regex.Replace(input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
        }
     
        internal static void PrintPrettyEnumChoices(Type enumType)
        {
            Console.WriteLine($"Choose {SplitCamelCase(enumType.Name)}: ");
            foreach (object item in Enum.GetValues(enumType))
            {
                if (item.ToString() != "None")
                {
                    Console.WriteLine($"   {(int)item}. {SplitCamelCase(item.ToString())}.");
                }
            }
            Console.Write("\nEnter your choice: ");
        }
        internal static void PropertyPrompt(PropertyInfo property)
        {
            Type type = property.PropertyType;
            string simplifiedType = SplitCamelCase(property.DeclaringType.ToString().Split('.')[1]);
            if (type == typeof(int) || type == typeof(string) || type == typeof(float))
            {
                Console.Write($"{simplifiedType} - Enter {SplitCamelCase(property.Name)}: ");
            }
            else if (property.PropertyType.IsEnum)
            {
                Console.Write($"{simplifiedType} - ");
                printPrettyEnumChoices(property.PropertyType);
            }
        }

        internal static Dictionary<string, object> GetConfigurationByPropertiesType(Type type)
        {
            Dictionary<string, object> objectConfiguration = new Dictionary<string, object>();
            foreach(var prop in type.GetProperties())
            {
                while(true)
                {
                    try
                    {
                        propertyPrompt(prop);
                        Type propertyType = prop.PropertyType;
                        object value = null;
                        if (propertyType == typeof(int))
                        { 
                            value = GetValidIntegerFromUser();
                        }
                        else if (propertyType == typeof(float))
                        {
                            value = GetValidFloatFromUser();
                        }
                        else if (propertyType == typeof(string))
                        {
                            value = Console.ReadLine();
                        }
                        else if (propertyType.IsEnum)
                        {
                            value = GetValidEnumFromUser(propertyType);
                        }
                        else
                        { 
                            break;
                        }

                        objectConfiguration[prop.ToString()] = value;
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error - {e.InnerException.Message}, press any key to retry...");
                        Console.ReadKey();
                    }
                }
            }
            
            return objectConfiguration;
        }
        
    }
}