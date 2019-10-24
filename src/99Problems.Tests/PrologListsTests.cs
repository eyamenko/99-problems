using System.Collections.Generic;
using _99Problems.Models;
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
            yield return new object[] { new List<ValueOrList<int>>(), new List<int>() };
            yield return new object[] { new List<ValueOrList<int>> { new ValueOrList<int>(1) }, new List<int> { 1 } };
            yield return new object[]
            {
                new List<ValueOrList<int>>
                {
                    new ValueOrList<int>(1),
                    new ValueOrList<int>(2),
                    new ValueOrList<int>(3),
                    new ValueOrList<int>(4),
                    new ValueOrList<int>(5),
                },
                new List<int> { 1, 2, 3, 4, 5 }
            };
            yield return new object[]
            {
                new List<ValueOrList<int>>
                {
                    new ValueOrList<int>(1),
                    new ValueOrList<int>(
                        new ValueOrList<int>(2),
                        new ValueOrList<int>(new ValueOrList<int>(3), new ValueOrList<int>(4)),
                        new ValueOrList<int>(5)),
                },
                new List<int> { 1, 2, 3, 4, 5 }
            };
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
                new List<List<int>>
                {
                    new List<int> { 1, 1, 1, 1 },
                    new List<int> { 2 },
                    new List<int> { 3, 3 },
                    new List<int> { 1, 1 },
                    new List<int> { 4 },
                    new List<int> { 5, 5, 5, 5 }
                }
            };
        }

        private static IEnumerable<object[]> _1_10_data()
        {
            yield return new object[] { new List<int>(), new List<(int, int)>() };
            yield return new object[] { new List<int> { 1 }, new List<(int, int)> { (1, 1) } };
            yield return new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<(int, int)> { (1, 1), (1, 2), (1, 3), (1, 4), (1, 5) }
            };
            yield return new object[]
            {
                new List<int> { 1, 1, 1, 1, 2, 3, 3, 1, 1, 4, 5, 5, 5, 5 },
                new List<(int, int)> { (4, 1), (1, 2), (2, 3), (2, 1), (1, 4), (4, 5) }
            };
        }

        private static IEnumerable<object[]> _1_11_data()
        {
            yield return new object[] { new List<int>(), new List<ValueOrTerm<int>>() };
            yield return new object[] { new List<int> { 1 }, new List<ValueOrTerm<int>> { new ValueOrTerm<int>(1) } };
            yield return new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<ValueOrTerm<int>>
                {
                    new ValueOrTerm<int>(1),
                    new ValueOrTerm<int>(2),
                    new ValueOrTerm<int>(3),
                    new ValueOrTerm<int>(4),
                    new ValueOrTerm<int>(5)
                }
            };
            yield return new object[]
            {
                new List<int> { 1, 1, 1, 1, 2, 3, 3, 1, 1, 4, 5, 5, 5, 5 },
                new List<ValueOrTerm<int>>
                {
                    new ValueOrTerm<int>(4, 1),
                    new ValueOrTerm<int>(2),
                    new ValueOrTerm<int>(2, 3),
                    new ValueOrTerm<int>(2, 1),
                    new ValueOrTerm<int>(4),
                    new ValueOrTerm<int>(4, 5)
                }
            };
        }

        private static IEnumerable<object[]> _1_12_data()
        {
            yield return new object[] { new List<ValueOrTerm<int>>(), new List<int>() };
            yield return new object[] { new List<ValueOrTerm<int>> { new ValueOrTerm<int>(1) }, new List<int> { 1 } };
            yield return new object[]
            {
                new List<ValueOrTerm<int>>
                {
                    new ValueOrTerm<int>(1),
                    new ValueOrTerm<int>(2),
                    new ValueOrTerm<int>(3),
                    new ValueOrTerm<int>(4),
                    new ValueOrTerm<int>(5)
                },
                new List<int> { 1, 2, 3, 4, 5 }
            };
            yield return new object[]
            {
                new List<ValueOrTerm<int>>
                {
                    new ValueOrTerm<int>(4, 1),
                    new ValueOrTerm<int>(2),
                    new ValueOrTerm<int>(2, 3),
                    new ValueOrTerm<int>(2, 1),
                    new ValueOrTerm<int>(4),
                    new ValueOrTerm<int>(4, 5)
                },
                new List<int> { 1, 1, 1, 1, 2, 3, 3, 1, 1, 4, 5, 5, 5, 5 },
            };
        }

        private static IEnumerable<object[]> _1_13_data()
        {
            yield return new object[] { new List<int>(), new List<ValueOrTerm<int>>() };
            yield return new object[] { new List<int> { 1 }, new List<ValueOrTerm<int>> { new ValueOrTerm<int>(1) } };
            yield return new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<ValueOrTerm<int>>
                {
                    new ValueOrTerm<int>(1),
                    new ValueOrTerm<int>(2),
                    new ValueOrTerm<int>(3),
                    new ValueOrTerm<int>(4),
                    new ValueOrTerm<int>(5)
                }
            };
            yield return new object[]
            {
                new List<int> { 1, 1, 1, 1, 2, 3, 3, 1, 1, 4, 5, 5, 5, 5 },
                new List<ValueOrTerm<int>>
                {
                    new ValueOrTerm<int>(4, 1),
                    new ValueOrTerm<int>(2),
                    new ValueOrTerm<int>(2, 3),
                    new ValueOrTerm<int>(2, 1),
                    new ValueOrTerm<int>(4),
                    new ValueOrTerm<int>(4, 5)
                }
            };
        }

        private static IEnumerable<object[]> _1_14_data()
        {
            yield return new object[] { new List<int>(), new List<int>() };
            yield return new object[] { new List<int> { 1 }, new List<int> { 1, 1 } };
            yield return new object[] { new List<int> { 1, 2 }, new List<int> { 1, 1, 2, 2 } };
            yield return new object[] { new List<int> { 1, 2, 3, 3, 4 }, new List<int> { 1, 1, 2, 2, 3, 3, 3, 3, 4, 4 } };
        }

        private static IEnumerable<object[]> _1_15_data()
        {
            yield return new object[] { new List<int>(), 3, new List<int>() };
            yield return new object[] { new List<int> { 1 }, 3, new List<int> { 1, 1, 1 } };
            yield return new object[] { new List<int> { 1, 2 }, 3, new List<int> { 1, 1, 1, 2, 2, 2 } };
            yield return new object[] { new List<int> { 1, 2, 3, 3, 4 }, 3, new List<int> { 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4 } };
        }

        private static IEnumerable<object[]> _1_16_data()
        {
            yield return new object[] { new List<int>(), 2, new List<int>() };
            yield return new object[] { new List<int> { 1 }, 2, new List<int> { 1 } };
            yield return new object[] { new List<int> { 1, 2 }, 2, new List<int> { 1 } };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new List<int> { 1, 3, 5, 7, 9 } };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, new List<int> { 1, 2, 4, 5, 7, 8, 10 } };
        }

        private static IEnumerable<object[]> _1_17_data()
        {
            yield return new object[]
            {
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                3,
                (new List<int> { 1, 2, 3 }, new List<int> { 4, 5, 6, 7, 8, 9, 10 })
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
        public void _1_07_should_flatten_nested_list_structure(List<ValueOrList<int>> list, List<int> expected)
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
        public void _1_10_should_perform_run_length_encoding_of_list(List<int> list, List<(int, int)> expected)
        {
            var actual = PrologLists._1_10(list);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_11_data), DynamicDataSourceType.Method)]
        public void _1_11_should_perform_modified_run_length_encoding_of_list(List<int> list, List<ValueOrTerm<int>> expected)
        {
            var actual = PrologLists._1_11(list);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_12_data), DynamicDataSourceType.Method)]
        public void _1_12_should_decode_run_length_encoded_list(List<ValueOrTerm<int>> list, List<int> expected)
        {
            var actual = PrologLists._1_12(list);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_13_data), DynamicDataSourceType.Method)]
        public void _1_13_should_perform_direct_run_length_encoding_of_list(List<int> list, List<ValueOrTerm<int>> expected)
        {
            var actual = PrologLists._1_13(list);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_14_data), DynamicDataSourceType.Method)]
        public void _1_14_should_duplicate_elements_of_list(List<int> list, List<int> expected)
        {
            var actual = PrologLists._1_14(list);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_15_data), DynamicDataSourceType.Method)]
        public void _1_15_should_duplicate_elements_of_list_given_number_of_times(List<int> list, int times, List<int> expected)
        {
            var actual = PrologLists._1_15(list, times);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_16_data), DynamicDataSourceType.Method)]
        public void _1_16_should_drop_every_n_th_element_from_list(List<int> list, int number, List<int> expected)
        {
            var actual = PrologLists._1_16(list, number);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_1_17_data), DynamicDataSourceType.Method)]
        public void _1_17_should_split_list_into_two_parts(List<int> list, int length, (List<int>, List<int>) expected)
        {
            var actual = PrologLists._1_17(list, length);

            CollectionAssert.AreEqual(expected.Item1, actual.Item1);
            CollectionAssert.AreEqual(expected.Item2, actual.Item2);
        }
    }
}
