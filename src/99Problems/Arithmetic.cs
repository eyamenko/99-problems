using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Determine the prime factors of a given positive integer. Construct a flat list containing the prime factors in ascending order.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<int> _2_02(int number, List<int> result = null)
        {
            result ??= new List<int>();

            if (number < 2)
            {
                return result;
            }

            var primeFactor = Enumerable.Range(2, number - 1).Where(_2_01).FirstOrDefault(n => number % n == 0);

            if (primeFactor == default)
            {
                return result;
            }

            result.Add(primeFactor);

            return _2_02(number / primeFactor, result);
        }
    }
}
