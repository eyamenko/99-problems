using System;
using System.Collections.Generic;
using System.Linq;

namespace _99Problems
{
    public static class LogicAndCodes
    {
        /// <summary>
        /// Truth tables for logical expressions. Write a predicate table/3 which prints the truth table of a given logical expression in two variables.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<(bool, bool, bool)> _3_01(Func<bool, bool, bool> func)
        {
            var booleans = new List<bool> { true, false };

            return booleans.SelectMany(a => Lists._1_05(booleans).Select(b => (a, b, func(a, b)))).ToList();
        }

        /// <summary>
        /// Truth tables for logical expressions (2). Continue problem 3.01 by defining and/2, or/2, etc as being operators.
        /// This allows to write the logical expression in the more natural way, as in the example: A and (A or not B).
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<(bool, bool, bool)> _3_02(Func<bool, bool, bool> func)
        {
            return _3_01(func);
        }
    }
}
