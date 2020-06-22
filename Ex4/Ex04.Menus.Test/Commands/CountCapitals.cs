using System;
using System.Linq;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Commands
{
    public class CountCapitals : ICallback
    {
        private static int CountCapitalsAmout(string i_Sentence = "")
        {
            int count = 0;
            foreach (char character in i_Sentence.Where(char.IsUpper))
            {
                count++;
            }

            return count;
        }
        
        internal static void CountCapitalsFromUserInput()
        {
            Console.Write("Please type sentence: ");
            string userInput = Console.ReadLine();
            Console.WriteLine(string.Format("Number of capital letters is {0}", CountCapitalsAmout(userInput)));
        }
        
        public void RunCallback()
        {
            CountCapitalsFromUserInput();
        }
    }
}