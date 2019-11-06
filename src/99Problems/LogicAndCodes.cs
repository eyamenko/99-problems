using System;
using System.Collections.Generic;
using System.Linq;

namespace _99Problems
{
    public static class LogicAndCodes
    {
        /// <summary>
        /// Truth tables for logical expressions.
        /// Write a predicate table/3 which prints the truth table of a given logical expression in two variables.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<(bool, bool, bool)> _3_01(Func<bool, bool, bool> func)
        {
            var booleans = new List<bool> { true, false };

            return booleans.SelectMany(a => Lists._1_05(booleans).Select(b => (a, b, func(a, b)))).ToList();
        }

        /// <summary>
        /// Truth tables for logical expressions (2).
        /// Continue problem 3.01 by defining and/2, or/2, etc as being operators.
        /// This allows to write the logical expression in the more natural way, as in the example: A and (A or not B).
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<(bool, bool, bool)> _3_02(Func<bool, bool, bool> func)
        {
            return _3_01(func);
        }

        /// <summary>
        /// Truth tables for logical expressions (3).
        /// Generalize problem 3.02 in such a way that the logical expression may contain any number of logical variables.
        /// Define table/2 in a way that table(List,Expr) prints the truth table for the expression Expr, which contains the logical variables enumerated in List.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<(bool, bool, bool, bool)> _3_03(Func<bool, bool, bool, bool> func)
        {
            var booleans = new List<bool> { true, false };

            return booleans.SelectMany(a => _3_01((b, c) => func(a, b, c)).Select(i => (a, i.Item1, i.Item2, i.Item3))).ToList();
        }

        /// <summary>
        /// Gray code.
        /// An n-bit Gray code is a sequence of n-bit strings constructed according to certain rules. For example,
        /// n = 1: C(1) = ['0','1'].
        /// n = 2: C(2) = ['00','01','11','10'].
        /// n = 3: C(3) = ['000','001','011','010','110','111','101','100'].
        /// Find out the construction rules and write a predicate with the following specification:
        /// % gray(N,C) :- C is the N-bit Gray code
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<string> _3_04(int number)
        {
            if (number == 1)
            {
                return new List<string> { "0", "1" };
            }

            var left = _3_04(number - 1);
            var right = Lists._1_05(left);

            return left.Select(i => "0" + i).Concat(right.Select(i => "1" + i)).ToList();
        }
    }
}
