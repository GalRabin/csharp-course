using GarageLogic.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.Clear();

            return response;
        }
        internal static int GetValidIntegerFromUser()
        {
            int response = -1;

            while (!int.TryParse(Console.ReadLine(), out response))
            {
                Console.Write(Messages.k_InvalidInput);
            }

            Console.Clear();

            return response;
        }

        internal static float GetValidFloatFromUser()
        {
            float response;

            while (!float.TryParse(Console.ReadLine(), out response))
            {
                Console.Write(Messages.k_InvalidInput);
            }

            Console.Clear();

            return response;
        }

        internal static string GetValidStringFromUser()
        {
            string response;
            while ((response = Console.ReadLine()).Length == 0)
            {
                Console.Write("Invalid input - enter valid string value: ");
            }

            Console.Clear();

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

            while (!int.TryParse(Console.ReadLine(), out keyboardInputAsInteger) || !Enum.IsDefined(i_Enum, keyboardInputAsInteger) || keyboardInputAsInteger == 0)
            {
                Console.Write(Messages.k_InvalidInput);
            }

            Console.Clear();

            return keyboardInputAsInteger;
        }
        /*
        internal static object[] GetValidObjectFromUser(Type i_Type)
        {
            List<PropertyInfo> props = i_Type.GetProperties().ToList<PropertyInfo>();
            object[] parameters = new object[props.Count];
            int i = 0;

            foreach (PropertyInfo pi in props)
            {
                if (hasSetter(pi))
                {
                    PropertyPrompt(ToPrettyString(pi.Name), pi.PropertyType);
                    if (pi.PropertyType == typeof(int))
                    {
                        int keyBoardParam;

                        while (!int.TryParse(Console.ReadLine(), out keyBoardParam))
                        {
                            Console.Write(Messages.k_InvalidInput);
                        }

                        parameters[i] = keyBoardParam;
                        i++;
                    }
                    else if (pi.PropertyType == typeof(float))
                    {
                        float keyBoardParam;

                        while (!float.TryParse(Console.ReadLine(), out keyBoardParam))
                        {
                            Console.Write(Messages.k_InvalidInput);
                        }
                        parameters[i] = keyBoardParam;
                        i++;
                    }
                    else
                    {
                        parameters[i] = Console.ReadLine();
                        i++;
                    }
                }
            }

            Console.Clear();

            return parameters;
        }
        internal static bool hasSetter(PropertyInfo i_Pi)
        {
            bool hasSetter = false;
            
            foreach(MethodInfo mi in i_Pi.GetAccessors())
            {
                if(mi.ReturnType == typeof(void))
                {
                    hasSetter = true;
                }
            }

            return hasSetter;
        }
        */
        internal static object[] GetValidObjectFromUser(Type i_Type)
        {
            ConstructorInfo ci = i_Type.GetConstructors()[0];
            object[] parameters = new object[ci.GetParameters().Length];

            int i = 0;

            foreach (ParameterInfo pi in ci.GetParameters())
            {
                if(pi.HasDefaultValue)
                {
                    continue;
                }
                PropertyPrompt(ToPrettyString(pi.Name), pi.ParameterType);
                if (pi.ParameterType == typeof(int))
                {
                    int keyBoardParam;

                    while (!int.TryParse(Console.ReadLine(), out keyBoardParam))
                    {
                        Console.Write(Messages.k_InvalidInput);
                    }

                    parameters[i] = keyBoardParam;
                    i++;
                }
                else if (pi.ParameterType == typeof(float))
                {
                    float keyBoardParam;

                    while (!float.TryParse(Console.ReadLine(), out keyBoardParam))
                    {
                        Console.Write(Messages.k_InvalidInput);
                    }
                    parameters[i] = keyBoardParam;
                    i++;
                }
                else
                {
                    parameters[i] = Console.ReadLine();
                    i++;
                }
            }

            Console.Clear();

            return parameters;
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
        internal static void PropertyPrompt(string i_Key, Type i_Type)
        {


            if (i_Type == typeof(int) || i_Type == typeof(string) || i_Type == typeof(float))
            {
                Console.Write($"{i_Key} - Enter {SplitCamelCase(i_Key)}: ");
            }
            else if (i_Type.IsEnum)
            {
                Console.Write($"{i_Type} - ");
                PrintPrettyEnumChoices(i_Type);
            }
            else if (i_Type == typeof(bool))
            {
                Console.Write($"{i_Key} - Enter if {SplitCamelCase(i_Key)}: (yes/no)");
            }
        }
        internal static Dictionary<string, Type> PrettyEmptyDictionary(Dictionary<string, Type> i_Dict)
        {
            Dictionary<string, Type> prettyDict = new Dictionary<string, Type>();

            foreach (KeyValuePair<string, Type> pair in i_Dict)
            {
                prettyDict.Add(ToPrettyString(pair.Key), pair.Value);
            }

            return prettyDict;
        }
        internal static string ToPrettyString(string i_Str)
        {
            string prettyString = i_Str.Substring(i_Str.LastIndexOf('_') + 1);

            for (int i = 1; i < prettyString.Length; i++)
            {
                if (char.IsUpper(prettyString[i]))
                {
                    prettyString = prettyString.Insert(i, " ");
                    i++;
                }
            }

            return prettyString;
        }

        internal static Dictionary<string, object> GetConfigurationByDictionary(Dictionary<string, Type> i_DefinerDict,
            GarageLogic.Garage i_Garage, Type i_TargetType)
        {
            Console.Clear();
            Dictionary<string, object> valuesDict = new Dictionary<string, object>();
            
            int i = 0;
            foreach (KeyValuePair<string, Type> pair in i_DefinerDict)
            {
                while (true)
                {
                    try
                    {
                        PropertyPrompt(pair.Key, pair.Value);
                        Type argumentType = pair.Value;
                        object value = null;
                        if (argumentType == typeof(int))
                        {
                            value = GetValidIntegerFromUser();
                        }
                        else if (argumentType == typeof(float))
                        {
                            value = GetValidFloatFromUser();
                        }
                        else if (argumentType == typeof(string))
                        {
                            value = Console.ReadLine();
                        }
                        else if(argumentType == typeof(bool))
                        {
                            value = GetValidYesNoFromUser();
                        }
                        else if (argumentType.IsEnum)
                        {
                            value = GetValidEnumFromUser(argumentType);
                        }
                        else if (argumentType.IsClass)
                        {
                            object[] objectParameters = GetValidObjectFromUser(argumentType);
                            value = i_Garage.CreateObject(objectParameters, argumentType, i_TargetType);
                        }
                        else 
                        { 
                            break;
                        }

                        valuesDict.Add(pair.Key, value);
                      
                        Console.Clear();
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error - {e.InnerException.Message}, press any key to retry...");
                        Console.ReadKey();
                    }
                }
            }

            return valuesDict;
        }
        /*
        public static object createObject(object[] i_Parameters, Type i_Type)
        {
            ConstructorInfo ci = i_Type.GetConstructors()[0];
            object value = ci.Invoke(new object []{ });
            int i = 0;

            foreach (PropertyInfo pi in i_Type.GetProperties())
            {
                foreach (MethodInfo mi in pi.GetAccessors())
                {
                    if (mi.ReturnType == typeof(void))
                    {
                        mi.Invoke(value, new object[] { i_Parameters[i] });
                    }
                }

            }

            return value;
        }
        */
    }
}