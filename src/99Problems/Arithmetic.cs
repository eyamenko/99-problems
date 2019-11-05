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
            if (number < 2)
            {
                return false;
            }

            return Enumerable.Range(2, Convert.ToInt32(Math.Round(Math.Sqrt(number))) - 1).All(n => number % n != 0);
        }

        /// <summary>
        /// Determine the prime factors of a given positive integer. Construct a flat list containing the prime factors in ascending order.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<int> _2_02(int number)
        {
            if (number < 2)
            {
                return new List<int>();
            }

            return Enumerable.Range(2, number - 1)
                             .Where(_2_01)
                             .SkipWhile(n => number % n != 0)
                             .Take(1)
                             .SelectMany(n => new List<int> { n }.Concat(_2_02(number / n)))
                             .ToList();
        }

        /// <summary>
        /// Determine the prime factors of a given positive integer (2). Construct a list containing the prime factors and their multiplicity.
        /// The solution of problem 1.10 may be helpful.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<(int, int)> _2_03(int number)
        {
            return Lists._1_10(_2_02(number));
        }

        /// <summary>
        /// A list of prime numbers. Given a range of integers by its lower and upper limit, construct a list of all prime numbers in that range.
        /// </summary>
        /// <param name="fromRange"></param>
        /// <param name="toRange"></param>
        /// <returns></returns>
        public static List<int> _2_04(int fromRange, int toRange)
        {
            return Lists._1_22(fromRange, toRange).Where(_2_01).ToList();
        }

        /// <summary>
        /// Goldbach's conjecture. Goldbach's conjecture says that every positive even number greater than 2 is the sum of two prime numbers.
        /// Example: 28 = 5 + 23. It is one of the most famous facts in number theory that has not been proved to be correct in the general case.
        /// It has been numerically confirmed up to very large numbers. Write a predicate to find the two prime numbers that sum up to a given even integer.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (int, int) _2_05(int number)
        {
            if (number % 2 != 0)
            {
                return default;
            }

            var primeNumbers = _2_04(2, number);

            return primeNumbers.Select(n => (n, number - n)).FirstOrDefault(i => primeNumbers.Contains(i.Item2));
        }

        /// <summary>
        /// A list of Goldbach compositions.
        /// Given a range of integers by its lower and upper limit, print a list of all even numbers and their Goldbach composition.
        /// </summary>
        /// <param name="fromRange"></param>
        /// <param name="toRange"></param>
        /// <returns></returns>
        public static List<(int, (int, int))> _2_06(int fromRange, int toRange)
        {
            return Lists._1_22(fromRange, toRange).Where(n => n % 2 == 0).Select(n => (n, _2_05(n))).ToList();
        }
    }
}
