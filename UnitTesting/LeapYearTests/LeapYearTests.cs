using System;
using LeapYearKata;
using NUnit.Framework;

namespace LeapYearTests
{
    public class LeapYearTests
    {
        [TestCase(2015)]
        [TestCase(1970)]
        [TestCase(2100)]
        [TestCase(1800)]
        [TestCase(1234)]
        public void IsLeapYear_ReturnFalse(int year)
        {
            Assert.False(LeapYear.IsLeapYear(year));
        }

        [TestCase(1996)]
        [TestCase(2000)]
        [TestCase(2020)]
        [TestCase(2008)]
        public void IsLeapYear_ReturnTrue(int year)
        {
            Assert.True(LeapYear.IsLeapYear(year));
        }

        [TestCase(-1996)]
        [TestCase(-2000)]
        [TestCase(0)]
        public void IsLeapYear_ThrowsArgumentException(int year)
        {
            Assert.Throws<ArgumentException>(() => LeapYear.IsLeapYear(year));
        }

        [TestCase(null)]
        public void IsLeapYear_ThrowsArgumentNullException(int number)
        {
            Assert.Throws<ArgumentNullException>(() => LeapYear.IsLeapYear(number));
        }
    }
}