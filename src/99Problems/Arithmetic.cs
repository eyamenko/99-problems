﻿using System;
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
        /// Determine the prime factors of a given positive integer.
        /// Construct a flat list containing the prime factors in ascending order.
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
        /// Determine the prime factors of a given positive integer (2).
        /// Construct a list containing the prime factors and their multiplicity. The solution of problem 1.10 may be helpful.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<(int, int)> _2_03(int number)
        {
            return Lists._1_10(_2_02(number));
        }

        /// <summary>
        /// A list of prime numbers.
        /// Given a range of integers by its lower and upper limit, construct a list of all prime numbers in that range.
        /// </summary>
        /// <param name="fromRange"></param>
        /// <param name="toRange"></param>
        /// <returns></returns>
        public static List<int> _2_04(int fromRange, int toRange)
        {
            return Lists._1_22(fromRange, toRange).Where(_2_01).ToList();
        }

        /// <summary>
        /// Goldbach's conjecture.
        /// Goldbach's conjecture says that every positive even number greater than 2 is the sum of two prime numbers.
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

        /// <summary>
        /// Determine the greatest common divisor of two positive integer numbers.
        /// Use Euclid's algorithm.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public static int _2_07(int number1, int number2)
        {
            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            if (number1 > number2)
            {
                return _2_07(number1 - number2, number2);
            }

            return _2_07(number1, number2 - number1);
        }

        /// <summary>
        /// Determine whether two positive integer numbers are coprime.
        /// Two numbers are coprime if their greatest common divisor equals 1.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public static bool _2_08(int number1, int number2)
        {
            return _2_07(number1, number2) == 1;
        }

        /// <summary>
        /// Calculate Euler's totient function phi(m).
        /// Euler's so-called totient function phi(m) is defined as the number of positive integers r (1 <= r < m) that are coprime to m.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int _2_09(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return Lists._1_22(1, number - 1).Count(n => _2_08(n, number));
        }

        /// <summary>
        /// Calculate Euler's totient function phi(m) (2).
        /// See problem 2.09 for the definition of Euler's totient function.
        /// If the list of the prime factors of a number m is known in the form of problem 2.03 then the function phi(m) can be efficiently calculated as follows:
        /// Let [[p1,m1],[p2,m2],[p3,m3],...] be the list of prime factors (and their multiplicities) of a given number m.
        /// Then phi(m) can be calculated with the following formula: phi(m) = (p1 - 1) * p1**(m1 - 1) * (p2 - 1) * p2**(m2 - 1) * (p3 - 1) * p3**(m3 - 1) * ...
        /// Note that a**b stands for the b'th power of a.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int _2_10(int number)
        {
            return _2_03(number).Aggregate(1, (acc, i) => acc * (i.Item2 - 1) * Convert.ToInt32(Math.Pow(i.Item2, i.Item1 - 1)));
        }
    }
}
