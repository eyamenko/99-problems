using System.Collections.Generic;
using _99Problems.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _99Problems.Tests
{
    [TestClass]
    public class LogicAndCodesTests
    {
        private static IEnumerable<object[]> _3_04_data()
        {
            yield return new object[] { 1, new List<string> { "0", "1" } };
            yield return new object[] { 2, new List<string> { "00", "01", "11", "10" } };
            yield return new object[] { 3, new List<string> { "000", "001", "011", "010", "110", "111", "101", "100" } };
        }

        [TestMethod]
        public void _3_01_should_construct_truth_tables_for_logical_expressions()
        {
            var expected = new List<(bool, bool, bool)>
            {
                (true, false, true),
                (true, true, true),
                (false, false, false),
                (false, true, false),
            };

            var actual = LogicAndCodes._3_01((a, b) => LogicalPredicates.And(a, LogicalPredicates.Or(a, b)));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void _3_02_should_construct_truth_tables_for_logical_expressions()
        {
            var expected = new List<(bool, bool, bool)>
            {
                (true, false, true),
                (true, true, true),
                (false, false, false),
                (false, true, false),
            };

            var actual = LogicAndCodes._3_02((a, b) => a.And(a.Or(b.Not())));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void _3_03_should_construct_truth_tables_for_logical_expressions()
        {
            var expected = new List<(bool, bool, bool, bool)>
            {
                (true, true, false, true),
                (true, true, true, true),
                (true, false, false, true),
                (true, false, true, true),
                (false, true, false, true),
                (false, true, true, true),
                (false, false, false, true),
                (false, false, true, true),
            };

            var actual = LogicAndCodes._3_03((a, b, c) => a.And(b.Or(c)).Equ(a.And(b)).Or(a.And(c)));

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_3_04_data), DynamicDataSourceType.Method)]
        public void _3_04_should_implement_gray_code(int number, List<string> expected)
        {
            var actual = LogicAndCodes._3_04(number);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
