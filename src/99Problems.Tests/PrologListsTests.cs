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

        private static IEnumerable<object[]> _1_03_data()
        {
            yield return new object[] { new List<int>(), 1, 0 };
            yield return new object[] { new List<int> { 1 }, 1, 1 };
            yield return new object[] { new List<int> { 1, 2 }, 1, 1 };
        }

        private static IEnumerable<object[]> _1_04_data()
        {
            yield return new object[] { new List<int>(), 0 };
            yield return new object[] { new List<int> { 1 }, 1 };
            yield return new object[] { new List<int> { 1, 2 }, 2 };
        }

        private static IEnumerable<object[]> _1_05_data()
        {
            yield return new object[] { new List<int>(), new List<int>() };
            yield return new object[] { new List<int> { 1 }, new List<int> { 1 } };
            yield return new object[] { new List<int> { 1, 2 }, new List<int> { 2, 1 } };
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

        [DataTestMethod]
        [DynamicData(nameof(_1_03_data), DynamicDataSourceType.Method)]
        public void _1_03_should_find_kth_element_of_list(List<int> list, int index, int expected)
        {
            var actual = PrologLists._1_03(list, index);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_04_data), DynamicDataSourceType.Method)]
        public void _1_04_should_find_number_of_elements_of_list(List<int> list, int expected)
        {
            var actual = PrologLists._1_04(list);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_05_data), DynamicDataSourceType.Method)]
        public void _1_05_should_reverse_list(List<int> list, List<int> expected)
        {
            var actual = PrologLists._1_05(list);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
