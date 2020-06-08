using System;
using System.Text;

namespace EX1_3
{
    public class Program
    {
        public static void RunApp()
        {
            int sandClockHeight = 0;
            while (sandClockHeight == 0)
            {
                Console.WriteLine("Enter sand clock height (numeric value):");
                String sandClockHeightString = Console.ReadLine();
                bool isNumeric = int.TryParse(sandClockHeightString, out sandClockHeight);
                if (!isNumeric)
                {
                    Console.WriteLine("Invalid height entered, Please enter only numeric characters!");
                }
                else if (sandClockHeight % 2 == 0)
                {
                    sandClockHeight -= 1;
                }
            }

            StringBuilder sandClock = EX1_2.Program.CreateSandClock(new StringBuilder(), 0, sandClockHeight);
            Console.WriteLine(sandClock);
        }
    }
}