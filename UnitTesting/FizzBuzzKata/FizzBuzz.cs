using System;
using System.Collections.Generic;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        private const int fizzNumber = 3;
        private const int buzzNumer = 5;

        public static void PrintFizzBuzz(int firstNumber, int lastNumber)
        {
            List<string> result = null;

            if (IsFirstNumberValid(firstNumber) && IsLastNumberValid(lastNumber))
            {
                for (int i = firstNumber; i <= lastNumber; i++)
                {
                    result.Add(IsNumberMultiplesTreeOrFiveOrBoth(i));
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static string IsNumberMultiplesTreeOrFiveOrBoth(int number)
        {
            if (number % fizzNumber == 0 && number % buzzNumer == 0)
                return "FizzBuzz";
            else if (number % fizzNumber == 0)
                return "Fizz";
            else if (number % buzzNumer == 0)
                return "Buzz";
            else
                return number.ToString();
        }

        public static bool IsFirstNumberValid(int firstNumber)
        {
            if (firstNumber != 1)
            {
                return false;
            }

            return true;
        }

        public static bool IsLastNumberValid(int lastNumber)
        {
            if (lastNumber != 100)
            {
                return false;
            }

            return true;
        }
    }
}