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
    }
}
