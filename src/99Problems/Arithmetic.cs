using System;
using System.Linq;

namespace _99Problems
{
    public static class Arithmetic
    {
        /// <summary>
        /// Determine whether a given integer number is prime.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool _2_01(int number)
        {
            return number > 1 && Enumerable.Range(2, Convert.ToInt32(Math.Round(Math.Sqrt(number))) - 1).All(n => number % n != 0);
        }
    }
}
