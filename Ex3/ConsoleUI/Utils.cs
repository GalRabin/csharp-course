using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EX3
{
    public class Utils
    { 
        internal static bool getValidYesNoFromUser()
        {
            string response = Console.ReadLine();
            while (response != "yes" && response != "no")
            {
                Console.Write("Invalid input - enter valid string value: ");
                response = Console.ReadLine();
            }

            return response == "yes";
        }
        internal static int getValidIntegerInRangeFromUser(int min, int max)
        {
            int response = -1;
            while (!int.TryParse(Console.ReadLine(), out response) || min > response || response > max)
            {
                Console.Write("Invalid input - enter valid integer value: ");
            }

            return response;
        }
        internal static int getValidIntegerFromUser()
        {
            int response = -1;
            while (!int.TryParse(Console.ReadLine(), out response))
            {
                Console.Write("Invalid input - enter valid integer value: ");
            }

            return response;
        }
        
        internal static float getValidFloatFromUser()
        {
            float response;
            while (!float.TryParse(Console.ReadLine(), out response))
            {
                Console.Write("Invalid input - enter valid float value: ");
            }

            return response;
        }
        
        internal static string getValidStringFromUser()
        {
            string response;
            while ((response = Console.ReadLine()).Length == 0)
            {
                Console.Write("Invalid input - enter valid string value: ");
            }

            return response;
        }

        internal static object getValidEnumFromUser(Type enumType)
        {
            string keyboardInput = Console.ReadLine();
            int keyboardInputAsInteger;
            while (int.TryParse(keyboardInput, out keyboardInputAsInteger) && !Enum.IsDefined(enumType, keyboardInputAsInteger) || keyboardInput ==null) {
                Console.Write("Invalid input, Please choose valid choice number: ");
                keyboardInput = Console.ReadLine();
            }

            return Convert.ChangeType(Enum.Parse(enumType, keyboardInput), enumType);
        }
        
        private static string SplitCamelCase(string input)
        {
            return Regex.Replace(input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
        }
        
        internal static void printPrettyEnumChoices(Type enumType)
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

        internal static void propertyPrompt(PropertyInfo property)
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

        internal static object getConfigurationByObjectProperty(Type type, bool clearAfterProperty = true)
        {
            object instance = Activator.CreateInstance(type);
            foreach(var prop in type.GetProperties())
            {
                while(true)
                {
                    if (clearAfterProperty)
                    {
                        Console.Clear();
                    }
                    try
                    {
                        propertyPrompt(prop);
                        Type propertyType = prop.PropertyType;
                        object value = null;
                        if (propertyType == typeof(int))
                        { 
                            value = getValidIntegerFromUser();
                        }
                        else if (propertyType == typeof(float))
                        {
                            value = getValidFloatFromUser();
                        }
                        else if (propertyType == typeof(string))
                        {
                            value = getValidStringFromUser();
                        }
                        else if (propertyType.IsEnum)
                        {
                            value = getValidEnumFromUser(propertyType);
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