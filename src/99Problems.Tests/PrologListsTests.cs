using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _99Problems.Tests
{
    [TestClass]
    public class PrologListsTests
    {
        private static IEnumerable<object[]> _1_01_data()
        {
            yield return new object[] { new List<int>(), 0 };
            yield return new object[] { new List<int> { 1 }, 1 };
            yield return new object[] { new List<int> { 1, 2 }, 2 };
        }

        private static IEnumerable<object[]> _1_02_data()
        {
            yield return new object[] { new List<int>(), 0 };
            yield return new object[] { new List<int> { 1 }, 0 };
            yield return new object[] { new List<int> { 1, 2 }, 1 };
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_01_data), DynamicDataSourceType.Method)]
        public void _1_01_should_find_last_element_of_list(List<int> list, int expected)
        {
            var actual = PrologLists._1_01(list);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_02_data), DynamicDataSourceType.Method)]
        public void _1_02_should_find_last_but_one_element_of_list(List<int> list, int expected)
        {
            var actual = PrologLists._1_02(list);

            Assert.AreEqual(expected, actual);
        }
    }
}
