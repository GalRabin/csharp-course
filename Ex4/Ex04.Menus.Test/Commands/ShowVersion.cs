using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Commands
{
    public class ShowVersion : ICallback
    {
        internal static void PrintVersion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }
        
        public void RunCallback()
        {
            PrintVersion();
        }
    }
}