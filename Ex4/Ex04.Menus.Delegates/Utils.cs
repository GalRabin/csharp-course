using System;

namespace Ex04.Menus.Delegates
{
    public static class Utils
    {
        internal static int GetValidInRangeFromUser(int i_Min, int i_Max)
        {
            int response;
            while (!int.TryParse(Console.ReadLine(), out response) || i_Min > response || response > i_Max)
            {
                Console.Write(Messages.InvalidInput(response, i_Min, i_Max));
            }

            return response;
        }

        internal static void PressAnyKeyToContinue()
        {
            Console.WriteLine(Messages.PressAnyKey());
            Console.ReadKey();
            Console.Clear();
        }
    }
}