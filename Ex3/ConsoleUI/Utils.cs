using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EX3
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
        internal static int GetValidIntegerInRangeFromUser(int min, int max)
        {
            int response = -1;
            
            while (!int.TryParse(Console.ReadLine(), out response) || min > response || response > max)
            {
                Console.Write("Invalid input - enter valid integer value: ");
            }

            return response;
        }
        internal static int GetValidIntegerFromUser()
        {
            int response = -1;
            
            while (!int.TryParse(Console.ReadLine(), out response))
            {
                Console.Write("Invalid input - enter valid integer value: ");
            }

            return response;
        }
        
        internal static float GetValidFloatFromUser()
        {
            float response;
            
            while (!float.TryParse(Console.ReadLine(), out response))
            {
                Console.Write("Invalid input - enter valid float value: ");
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

        internal static object GetValidEnumFromUser(Type i_EnumType)
        {
            string keyboardInput = Console.ReadLine();
            int keyboardInputAsInteger;
            
            while (int.TryParse(keyboardInput, out keyboardInputAsInteger) && !Enum.IsDefined(i_EnumType, keyboardInputAsInteger) || keyboardInput ==null) {
                Console.Write("Invalid input, Please choose valid choice number: ");
                keyboardInput = Console.ReadLine();
            }

            return Convert.ChangeType(Enum.Parse(i_EnumType, keyboardInput), i_EnumType);
        }
        
        private static string splitCamelCase(string i_Input)
        {

            return Regex.Replace(i_Input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
        }
        
        internal static void PrintPrettyEnumChoices(Type i_EnumType)
        {
            Console.WriteLine($"Choose {splitCamelCase(i_EnumType.Name)}: ");

            foreach (object item in Enum.GetValues(i_EnumType))
            {
                if (item.ToString() != "None")
                {
                    Console.WriteLine($"   {(int)item}. {splitCamelCase(item.ToString())}.");
                }
            }

            Console.Write("\nEnter your choice: ");
        }

        internal static void PropertyPrompt(PropertyInfo i_Property)
        {
            Type type = i_Property.PropertyType;
            string simplifiedType = splitCamelCase(i_Property.DeclaringType.ToString().Split('.')[1]);

            if (type == typeof(int) || type == typeof(string) || type == typeof(float))
            {
                Console.Write($"{simplifiedType} - Enter {splitCamelCase(i_Property.Name)}: ");
            }
            else if (i_Property.PropertyType.IsEnum)
            {
                Console.Write($"{simplifiedType} - ");
                PrintPrettyEnumChoices(i_Property.PropertyType);
            }
        }
        /*internal static object getDefaultConfiguration(Type type)
        {
            object instance = Activator.CreateInstance(type);
            foreach(var prop in type.GetProperties())
            {
                prop.SetValue(instance, prop.GetValue(instance));
            }

            return instance;

        }*/
        internal static object GetConfigurationByObjectProperty(Type i_Type, bool i_ClearAfterProperty = true)
        {
            object instance = Activator.CreateInstance(i_Type);

            foreach(var prop in i_Type.GetProperties())
            {
                while(true)
                {
                    if (i_ClearAfterProperty)
                    {
                        Console.Clear();
                    }

                    try
                    {
                        PropertyPrompt(prop);
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
                            value = GetValidStringFromUser();
                        }
                        else if (propertyType.IsEnum)
                        {
                            value = GetValidEnumFromUser(propertyType);
                        }
                        else
                        { 
                            break;
                        }

                        prop.SetValue(instance, value);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error - {e.InnerException.Message}, press any key to retry...");
                        Console.ReadKey();
                    }
                }
            }

            Console.Clear();

            return instance;
        }
    }
}