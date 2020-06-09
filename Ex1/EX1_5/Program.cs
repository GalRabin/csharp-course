using System;

public class Program
{
    private static void reportNumberOfGreaterThanUnits(string i_input)
    {
        char[] digitsArray = i_input.ToCharArray();
        char   units = digitsArray[digitsArray.Length - 1];
        int    numberOfDigitsGreaterthanUnits = 0;
        for (int i = 0; i < digitsArray.Length - 1; i++)
        {
            if (units < digitsArray[i])
            {
                numberOfDigitsGreaterthanUnits++;
            }
        }

        Console.WriteLine(String.Format("The number of digits greater than the unit is {0}", numberOfDigitsGreaterthanUnits));
    }

    private static void reportNumberOfDigitsDividedByThree(string i_input)
    {
        int numberOfDigitsDivdedByThree = 0;
        foreach (char digit in i_input)
        {
            int digitIntger = (int)digit;
            if (digitIntger % 3 == 0)
            {
                numberOfDigitsDivdedByThree++;
            }
        }

        Console.WriteLine(String.Format("The number of digits divide by 3 is {0}", numberOfDigitsDivdedByThree));
    }

    private static void reportSmallestDigit(string i_input)
    {
        char minDigit = '9';
        foreach (char digit in i_input)
        {
            if (digit < minDigit)
            {
                minDigit = digit;
            }
        }

        Console.WriteLine(String.Format("The smallest digit entered {0}", minDigit));
    }

    private static void reportBiggestDigit(string i_input)
    {
        char maxDigit = '0';
        foreach (char digit in i_input)
        {
            if (digit > maxDigit)
            {
                maxDigit = digit;
            }
        }

        Console.WriteLine(String.Format("The biggest digit entered {0}", maxDigit));
    }

    public static void RunApp()
    {
        Console.WriteLine("Please enter positive number with 9 digitis:");
        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int userNumber) && userInput.Length == 9)
        {
            reportBiggestDigit(userInput);
            reportSmallestDigit(userInput);
            reportNumberOfDigitsDividedByThree(userInput);
            reportNumberOfGreaterThanUnits(userInput);
        }
        else
        {
            Console.WriteLine("Invalid input - Only 9 digits and not other letters!");
        }
    }
}