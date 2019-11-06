using System.Collections.Generic;
using _99Problems.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _99Problems.Tests
{
    [TestClass]
    public class LogicAndCodesTests
    {
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
    }
}
