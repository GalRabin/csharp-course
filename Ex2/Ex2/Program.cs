using System;
using System.Text;
using ex2;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Press any key to start \'Memory Game\'\n" +
                              "Or Esc to Exit");
            ConsoleKey key = Console.ReadKey().Key;
            
            if (!key.Equals(ConsoleKey.Escape)){
                Ex02.ConsoleUtils.Screen.Clear();
                UserInterface ui = new UserInterface();
                ui.ConfigureGame();
                ui.StartGame();    
            }
            else
            {
                break;
            }

            System.Threading.Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
        }
    }
}