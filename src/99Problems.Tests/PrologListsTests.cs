using System;
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

        private static IEnumerable<object[]> _1_06_data()
        {
            yield return new object[] { new List<int>(), true };
            yield return new object[] { new List<int> { 1 }, true };
            yield return new object[] { new List<int> { 1, 2 }, false };
            yield return new object[] { new List<int> { 1, 2, 1 }, true };
            yield return new object[] { new List<int> { 1, 2, 2, 1 }, true };
            yield return new object[] { new List<int> { 1, 2, 3, 2, 1 }, true };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 6 }, false };
        }

        private static IEnumerable<object[]> _1_07_data()
        {
            yield return new object[] { new List<object>(), new List<object>() };
            yield return new object[] { new List<object> { 1 }, new List<object> { 1 } };
            yield return new object[] { new List<object> { 1, 2, 3, 4, 5 }, new List<object> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<object> { 1, new List<object> { 2, new List<object> { 3, 4 }, 5 } }, new List<object> { 1, 2, 3, 4, 5 } };
        }

        private static IEnumerable<object[]> _1_08_data()
        {
            yield return new object[] { new List<int>(), new List<int>() };
            yield return new object[] { new List<int> { 1 }, new List<int> { 1 } };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<int> { 1, 1, 1, 1, 2, 3, 3, 1, 1, 4, 5, 5, 5, 5 }, new List<int> { 1, 2, 3, 1, 4, 5 } };
        }

        private static IEnumerable<object[]> _1_09_data()
        {
            yield return new object[] { new List<int>(), new List<List<int>>() };
            yield return new object[] { new List<int> { 1 }, new List<List<int>> { new List<int> { 1 } } };
            yield return new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<List<int>> { new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 5 } }
            };
            yield return new object[]
            {
                new List<int> { 1, 1, 1, 1, 2, 3, 3, 1, 1, 4, 5, 5, 5, 5 },
                new List<List<int>> { new List<int> { 1, 1, 1, 1 }, new List<int> { 2 }, new List<int> { 3, 3 }, new List<int> { 1, 1 }, new List<int> { 4 }, new List<int> { 5, 5, 5, 5 } }
            };
        }

        private static IEnumerable<object[]> _1_10_data()
        {
            yield return new object[] { new List<int>(), new List<Tuple<int, int>>() };
            yield return new object[] { new List<int> { 1 }, new List<Tuple<int, int>> { new Tuple<int, int>(1, 1) } };
            yield return new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<Tuple<int, int>> { new Tuple<int, int>(1, 1), new Tuple<int, int>(1, 2), new Tuple<int, int>(1, 3), new Tuple<int, int>(1, 4), new Tuple<int, int>(1, 5) }
            };
            yield return new object[]
            {
                new List<int> { 1, 1, 1, 1, 2, 3, 3, 1, 1, 4, 5, 5, 5, 5 },
                new List<Tuple<int, int>> { new Tuple<int, int>(4, 1), new Tuple<int, int>(1, 2), new Tuple<int, int>(2, 3), new Tuple<int, int>(2, 1), new Tuple<int, int>(1, 4), new Tuple<int, int>(4, 5) }
            };
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

        [DataTestMethod]
        [DynamicData(nameof(_1_06_data), DynamicDataSourceType.Method)]
        public void _1_06_should_find_out_whether_list_is_palindrome(List<int> list, bool expected)
        {
            var actual = PrologLists._1_06(list);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_07_data), DynamicDataSourceType.Method)]
        public void _1_07_should_flatten_nested_list_structure(List<object> list, List<object> expected)
        {
            var actual = PrologLists._1_07(list);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_08_data), DynamicDataSourceType.Method)]
        public void _1_08_should_eliminate_consecutive_duplicates_of_list_elements(List<int> list, List<int> expected)
        {
            var actual = PrologLists._1_08(list);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_09_data), DynamicDataSourceType.Method)]
        public void _1_09_should_pack_consecutive_duplicates_of_list_elements_into_sublists(List<int> list, List<List<int>> expected)
        {
            var actual = PrologLists._1_09(list);

            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0, j = 0; i < expected.Count && j < actual.Count; i++, j++)
            {
                CollectionAssert.AreEqual(expected[i], actual[j]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_10_data), DynamicDataSourceType.Method)]
        public void _1_10_should_run_length_encoding_of_list(List<int> list, List<Tuple<int, int>> expected)
        {
            var actual = PrologLists._1_10(list);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
