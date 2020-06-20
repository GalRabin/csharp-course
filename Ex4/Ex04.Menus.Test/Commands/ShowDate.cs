using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Commands
{
    public class ShowDate : ICallback
    {
        internal static void PrintDate()
        {
            Console.WriteLine(DateTime.Now.ToString("d"));
        }
        
        public void RunCallback()
        {
            PrintDate();
        }
    }
}