using System;
using NUnit.Framework;
using FizzBuzzKata;

namespace FizzBuzzTest
{
    public class FizzBuzzTest
    {
        [TestCase(0, ExpectedResult = "0")]
        [TestCase(3, ExpectedResult = "Fizz")]
        [TestCase(5, ExpectedResult = "Buzz")]
        [TestCase(15, ExpectedResult = "FizzBuzz")]
        [TestCase(30, ExpectedResult = "FizzBuzz")]
        [TestCase(33, ExpectedResult = "Fizz")]
        [TestCase(28, ExpectedResult = "28")]
        [TestCase(100, ExpectedResult = "Buzz")]
        public string IsNumberMultiplesTreeOrFiveOrBoth_WithCorrectDigits(int number)
        {
            return FizzBuzz.IsNumberMultiplesTreeOrFiveOrBoth(number);
        }

        [TestCase(0, ExpectedResult = true)]
        [TestCase(-1, ExpectedResult = false)]
        [TestCase(2, ExpectedResult = false)]
        public bool IsFirstNumberValid_ReturnTrueOrFalse(int number)
        {
            return FizzBuzz.IsFirstNumberValid(number);
        }

        [TestCase(100, ExpectedResult = true)]
        [TestCase(-101, ExpectedResult = false)]
        [TestCase(99, ExpectedResult = false)]
        public bool IsLastNumberValid_ReturnTrueOrFalse(int number)
        {
            return FizzBuzz.IsLastNumberValid(number);
        }

        [TestCase(null)]
        public void IsNumberValid_NumberIsNull_ThrowsArgumentNullException(int number)
        {
            Assert.Throws<ArgumentNullException>(() => FizzBuzz.IsNumberValid(number));
        }
    }
}