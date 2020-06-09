using System;
using System.Text;

namespace EX1_2
{
    public class Program
    {
        public static StringBuilder CreateSandClock(StringBuilder io_stringBuilder, int i_row, int i_height)
        {
            // Achived required height
            if (i_row == i_height)
            {
                return io_stringBuilder;
            }
            // Build upper sandclock
            if (i_row < i_height / 2)
            {
                io_stringBuilder.AppendLine(new string(' ', i_row) + new string('*', i_height - (2 * i_row)));
            }
            // Build lower sandclock
            else
            {
                io_stringBuilder.AppendLine(new string(' ', i_height - i_row - 1) + new string('*', (2 * i_row) - i_height + 2));
            }
            // recursion until achive height
            CreateSandClock(io_stringBuilder, i_row + 1, i_height);

            return io_stringBuilder;
        }

        public static void RunApp()
        {
            Console.WriteLine(CreateSandClock(new StringBuilder(), 0, 5));
        }
    }
}