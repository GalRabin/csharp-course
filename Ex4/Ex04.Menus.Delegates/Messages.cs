using System;

namespace Ex04.Menus.Delegates
{
    public static class Messages
    {
        internal const string k_EnterUserChoice = "Please enter choice: ";
        private const string k_InvalidInput = "Invalid choice {0}, please enter choice within range {1}-{2}: ";
        private const string k_PressAnyKey = "{0}Press any key to continue...";

        internal static string InvalidInput(int i_UserChoice, int i_RangeStart, int i_RangeEnd)
        {
            return string.Format(k_InvalidInput, i_UserChoice, i_RangeStart, i_RangeEnd);
        }

        internal static string PressAnyKey()
        {
            return string.Format(k_PressAnyKey, Environment.NewLine);
        }
    }
}