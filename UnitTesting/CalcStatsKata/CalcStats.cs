using System;
using System.Linq;

namespace CalcStatsKata
{
    public class CalcStats
    {
        public static int GetMinimumValue(int[] sequence)
        {
            return sequence.Min();
        }

        public static int GetMaximumValue(int[] sequence)
        {
            return sequence.Max();
        }

        public static int GetLengthOfSequence(int[] sequence)
        {
            return sequence.Length;
        }

        public static double GetAverageOfSequence(int[] sequence)
        {
            return sequence.Average();
        }

        public static void IsSequenceValid(int[] sequence)
        {
            if (sequence is null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
