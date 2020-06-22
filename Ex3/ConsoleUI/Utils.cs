using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    public class Utils
    {
        private static bool getValidYesNoFromUser()
        {
            string response = Console.ReadLine();

            while (response != Messages.k_YesOption && response != Messages.k_NoOption)
            {
                Console.Write(Messages.k_InvalidInput);
                response = Console.ReadLine();
            }

            return response == Messages.k_YesOption;
        }

        internal static int GetValidInRangeFromUser(int min, int max)
        {
            int response;

            while (!int.TryParse(Console.ReadLine(), out response) || min > response || response > max)
            {
                Console.Write(Messages.k_InvalidInput);
            }

            Console.Clear();

            return response;
        }

        private static int getValidIntegerFromUser()
        {
            int response;

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
                Console.Write(Messages.k_InvalidInput);
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
                message.Append(string.Format(Messages.k_OptionFormat, i, i_EnumTranslation[i]));
            }

            return message.ToString();
        }

        internal static int GetValidEnumFromUser(Type i_Enum)
        {
            int keyboardInputAsInteger;

            while (!int.TryParse(Console.ReadLine(), out keyboardInputAsInteger) ||
                !Enum.IsDefined(i_Enum, keyboardInputAsInteger) || keyboardInputAsInteger == 0)
            {
                Console.Write(Messages.k_InvalidInput);
            }

            Console.Clear();

            return keyboardInputAsInteger;
        }

        private static object[] GetValidObjectFromUser(Type i_Type)
        {
            ConstructorInfo ci = i_Type.GetConstructors()[0];
            object[] parameters = new object[ci.GetParameters().Length];
            int i = 0;

            foreach (ParameterInfo pi in ci.GetParameters())
            {
                if (pi.HasDefaultValue)
                {
                    continue;
                }

                PropertyPrompt(ToPrettyString(pi.Name), pi.ParameterType);

                if (pi.ParameterType == typeof(int))
                {
                    parameters[i] = ReadInt();
                    i++;
                }
                else if (pi.ParameterType == typeof(float))
                {
                    parameters[i] = ReadFloat();
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

        internal static int ReadInt()
        {
            int keyBoardParam;

            while (!int.TryParse(Console.ReadLine(), out keyBoardParam))
            {
                Console.Write(Messages.k_InvalidInput);
            }

            return keyBoardParam;
        }

        internal static float ReadFloat()
        {
            float keyBoardParam;

            while (!float.TryParse(Console.ReadLine(), out keyBoardParam))
            {
                Console.Write(Messages.k_InvalidInput);
            }

            return keyBoardParam;
        }
        internal static string SplitCamelCase(string i_Input)
        {

            return Regex.Replace(i_Input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
        }

        internal static void PrintPrettyEnumChoices(Type i_EnumType)
        {
            Console.WriteLine($"Choose {SplitCamelCase(i_EnumType.Name)}: ");

            foreach (object item in Enum.GetValues(i_EnumType))
            {
                if (item.ToString() != "None")
                {
                    Console.WriteLine($"   {(int)item}. {SplitCamelCase(item.ToString())}.");
                }
            }

            Console.Write(Messages.k_EnterOption);
        }

        internal static void PropertyPrompt(string i_Key, Type i_Type)
        {
            if (i_Type == typeof(int) || i_Type == typeof(string) || i_Type == typeof(float))
            {
                Console.Write(Messages.EnterKey(i_Key, SplitCamelCase(i_Key)));
            }
            else if (i_Type.IsEnum)
            {
                Console.Write($"{i_Type} - ");
                PrintPrettyEnumChoices(i_Type);
            }
            else if (i_Type == typeof(bool))
            {
                Console.Write(Messages.EnterYesNoKey(i_Key, SplitCamelCase(i_Key)));
            }
            else if (i_Type.IsClass)
            {
                Console.WriteLine(i_Key + Environment.NewLine);
                Console.WriteLine(Messages.EnterObjectConfigurations(i_Type));
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

            foreach ((string key, Type argumentType) in i_DefinerDict)
            {
                while (true)
                {
                    try
                    {
                        object value = GetPropertyFromUser(key, argumentType, i_Garage, i_TargetType);
                        
                        if(value == null)
                        {
                            break;
                        }

                        valuesDict.Add(key, value);

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
        internal static object GetPropertyFromUser(string i_Key, Type i_ArgumentType, GarageLogic.Garage i_Garage,
            Type i_TargetType)
        {
            object value;
            PropertyPrompt(i_Key, i_ArgumentType);

            if (i_ArgumentType == typeof(int))
            {
                value = getValidIntegerFromUser();
            }
            else if (i_ArgumentType == typeof(float))
            {
                value = GetValidFloatFromUser();
            }
            else if (i_ArgumentType == typeof(string))
            {
                value = Console.ReadLine();
            }
            else if (i_ArgumentType == typeof(bool))
            {
                value = getValidYesNoFromUser();
            }
            else if (i_ArgumentType.IsEnum)
            {
                value = GetValidEnumFromUser(i_ArgumentType);
            }
            else if (i_ArgumentType.IsClass)
            {
                while (true)
                {
                    object[] objectParameters = GetValidObjectFromUser(i_ArgumentType);
                    try
                    {
                        value = i_Garage.CreateObject(objectParameters, i_ArgumentType, i_TargetType);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                value = null;
            }

            return value;
        }
    }
}