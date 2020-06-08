using System;

public class Program
{
    private static void reportBiggestNumber(int[] numbers)
    {
        int maxNumber = 0;
        foreach (int number in numbers)
        {
            if (number > maxNumber)
            {
                maxNumber = number;
            }
        }

        Console.WriteLine(string.Format("The biggest number entered is {0}", maxNumber));
    }

    private static bool isNumberIncreasing(int number)
    {
        string text = number.ToString();
        char   previous = '0';
        bool   isIncreasing = true;
        foreach (char c in text)
        {
            if (c <= previous)
                isIncreasing = false;
            previous = c;
        }

        return isIncreasing;
    }

    private static void reportCountIncreasingNumber(int[] io_numbers)
    {
        int countPowerOfIncreasingNumber = 0;
        foreach (int number in io_numbers)
        {
            if (isNumberIncreasing(number))
            {
                countPowerOfIncreasingNumber++;
            }
        }

        Console.WriteLine(string.Format("{0} number has incresing digits", countPowerOfIncreasingNumber));
    }

    private static bool isPowerOfTwo(uint i_number)
    {
        bool isPowerOfTwo = (i_number != 0) && ((i_number & (i_number - 1)) == 0);

        return isPowerOfTwo;
    }

    private static void reportCountPowerOfTwo(int[] io_numbers)
    {
        int countPowerOfTwo = 0;
        foreach (int number in io_numbers)
        {
            if (isPowerOfTwo((uint)number))
            {
                countPowerOfTwo++;
            }
        }

        Console.WriteLine(string.Format("{0} numbers is power of 2", countPowerOfTwo));
    }

    private static void reportAverageNumberOf(string[] io_numbersAsBinaryStrings, char i_digit)
    {
        int numberOfDigit = 0;
        foreach (string binaryNumber in io_numbersAsBinaryStrings)
        {
            foreach (char letter in binaryNumber)
            {
                if (i_digit == letter)
                {
                    numberOfDigit++;
                }
            }
        }

        Console.WriteLine(string.Format("Average repeats of {0} is {1}.", i_digit, numberOfDigit / io_numbersAsBinaryStrings.Length));
    }

    private static int convertToDecimal(string i_input)
    {
        int    decimalInput = 0;
        char[] inputAsCharArray = i_input.ToCharArray();
        for (int i = 0; i < inputAsCharArray.Length - 1; i++)
        {
            int currentDigit = (int)(inputAsCharArray[i] - '0');
            int twoPowerOf = inputAsCharArray.Length - 1 - i;
            decimalInput += (int)(Math.Pow(2, twoPowerOf)) * currentDigit;
        }

        return decimalInput;
    }

    private static bool isValidBinaryNumber(string i_input, int i_length)
    {
        char[] inputAsCharArray = i_input.ToCharArray();
        bool   isValid = true;

        if (i_input.Length != i_length)
        {
            isValid = false;
        }

        if (isValid)
        {
            foreach (char digit in inputAsCharArray)
            {
                if (!(digit != '1' || digit != '0'))
                {
                    isValid = false;
                }
            }
        }


        return isValid;
    }

    public static void RunApp()
    {
        int[]    userInputNumbers = new int[3];
        String[] userInputNumbersAsString = new string[3];
        bool     isValidInput = false;
        for (int i = 0; i < 3; i++)
        {
            while (!isValidInput)
            {
                Console.WriteLine(string.Format("Enter binary number {0} out of {1}:", i + 1, 3));
                string userInput = Console.ReadLine();
                isValidInput = isValidBinaryNumber(userInput, 9);
                if (isValidInput)
                {
                    userInputNumbersAsString[i] = userInput;
                    userInputNumbers[i] = convertToDecimal(userInput);
                    Console.WriteLine(String.Format("Entered number as Decimal {0:d}", userInputNumbers[i]));
                }
            }
        }

        reportAverageNumberOf(userInputNumbersAsString, '0');
        reportAverageNumberOf(userInputNumbersAsString, '1');
        reportCountPowerOfTwo(userInputNumbers);
        reportCountIncreasingNumber(userInputNumbers);
        reportBiggestNumber(userInputNumbers);
    }
}
