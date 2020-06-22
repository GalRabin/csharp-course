using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Commands
{
    public class ShowTime : ICallback
    {
        internal static void PrintTime()
        {
            Console.WriteLine(DateTime.Now.ToString("T"));
        }
        
        public void RunCallback()
        {
            PrintTime();
        }
    }
}