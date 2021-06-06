using System;

namespace LeapYearKata
{
    public class LeapYear
    {
        public static bool IsLeapYear(int? year)
        {
            if (year is null)
            {
                throw new ArgumentNullException();
            }

            if (year <= 0)
            {
                throw new ArgumentException();
            }

            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
