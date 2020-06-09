using System;
using System.Text;

public class Program
{
    private static bool isPalindrom(string i_input, int i_position = 0)
    {
        int startPosition = i_position;
        int endPosition = 7 - startPosition;

        if (endPosition < startPosition)
        {
            return true;
        }
        else if (i_input[startPosition] == i_input[endPosition])
        {
            isPalindrom(i_input, ++i_position);
        }

        return false;

    }

    private static void reportIsPalindrom(string i_input)
    {
        StringBuilder msg = new StringBuilder(String.Format("The string {0} is ", i_input));
        if (isPalindrom(i_input))
        {
            msg.Append("not ");
        }

        Console.WriteLine(msg.Append("Palindrom."));
    }

    private static void reportNumberOfCapitalLetters(string i_input)
    {
        int numberOfCaptialLetters = 0;
        foreach (char letter in i_input)
        {
            if (!char.IsLower(letter))
            {
                numberOfCaptialLetters++;
            }
        }

        Console.WriteLine(String.Format("The number of capital letter is {0}", numberOfCaptialLetters));
    }

    private static bool isContainsDigit(string i_number)
    {
        bool isContains = false;
        foreach (char letter in i_number)
        {
            bool isNumeric = char.IsDigit(letter);
            if (isNumeric)
            {
                isContains = true;
            }
        }

        return isContains;
    }


    private static void reportDividedByFive(int i_number)
    {
        StringBuilder msg = new StringBuilder(String.Format("The number {0} is ", i_number));
        if (i_number % 5 != 0)
        {
            msg.Append("not ");
        }

        Console.WriteLine(msg.AppendLine("divided by 5 without reminder"));
    }


    public static void RunApp()
    {
        Console.WriteLine("Please insert 8 letters word - all chars or integers but not bot:");
        string userInput = Console.ReadLine();
        if (userInput.Length == 8)
        {
            if (int.TryParse(userInput, out int integerUserInput))
            {
                reportDividedByFive(integerUserInput);
            }
            else if (!isContainsDigit(userInput))
            {
                reportNumberOfCapitalLetters(userInput);
                reportIsPalindrom(userInput);
            }
            else
            {
                Console.WriteLine("Wrong input eneterd, Please enter only characters or numbers not both!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input - The input length is not 8 characters.");
        }
    }
}