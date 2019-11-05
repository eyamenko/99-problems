using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _99Problems.Tests
{
    [TestClass]
    public class ArithmeticTests
    {
        private static IEnumerable<object[]> _2_01_data()
        {
            yield return new object[] { 0, false, };
            yield return new object[] { 1, false, };
            yield return new object[] { 2, true, };
            yield return new object[] { 3, true, };
            yield return new object[] { 4, false, };
            yield return new object[] { 5, true, };
            yield return new object[] { 7, true, };
            yield return new object[] { 9, false, };
            yield return new object[] { 11, true, };
            yield return new object[] { 13, true, };
            yield return new object[] { 17, true, };
            yield return new object[] { 19, true, };
            yield return new object[] { 20, false, };
        }

        private static IEnumerable<object[]> _2_02_data()
        {
            yield return new object[] { 0, new List<int>() };
            yield return new object[] { 1, new List<int>() };
            yield return new object[] { 2, new List<int> { 2 } };
            yield return new object[] { 3, new List<int> { 3 } };
            yield return new object[] { 4, new List<int> { 2, 2 } };
            yield return new object[] { 5, new List<int> { 5 } };
            yield return new object[] { 10, new List<int> { 2, 5 } };
            yield return new object[] { 20, new List<int> { 2, 2, 5 } };
            yield return new object[] { 315, new List<int> { 3, 3, 5, 7 } };
        }

        private static IEnumerable<object[]> _2_03_data()
        {
            yield return new object[] { 0, new List<(int, int)>() };
            yield return new object[] { 1, new List<(int, int)>() };
            yield return new object[] { 2, new List<(int, int)> { (1, 2) } };
            yield return new object[] { 3, new List<(int, int)> { (1, 3) } };
            yield return new object[] { 4, new List<(int, int)> { (2, 2) } };
            yield return new object[] { 5, new List<(int, int)> { (1, 5) } };
            yield return new object[] { 10, new List<(int, int)> { (1, 2), (1, 5) } };
            yield return new object[] { 20, new List<(int, int)> { (2, 2), (1, 5) } };
            yield return new object[] { 315, new List<(int, int)> { (2, 3), (1, 5), (1, 7) } };
        }

        private static IEnumerable<object[]> _2_04_data()
        {
            yield return new object[] { 0, 1, new List<int>() };
            yield return new object[] { 2, 2, new List<int> { 2 } };
            yield return new object[] { 0, 20, new List<int> { 2, 3, 5, 7, 11, 13, 17, 19 } };
        }

        private static IEnumerable<object[]> _2_05_data()
        {
            yield return new object[] { 0, default((int, int)) };
            yield return new object[] { 1, default((int, int)) };
            yield return new object[] { 2, default((int, int)) };
            yield return new object[] { 3, default((int, int)) };
            yield return new object[] { 4, (2, 2) };
            yield return new object[] { 5, default((int, int)) };
            yield return new object[] { 6, (3, 3) };
            yield return new object[] { 28, (5, 23) };
        }

        private static IEnumerable<object[]> _2_06_data()
        {
            yield return new object[]
            {
                9, 20, new List<(int, (int, int))> { (10, (3, 7)), (12, (5, 7)), (14, (3, 11)), (16, (3, 13)), (18, (5, 13)), (20, (3, 17)) }
            };
        }

        private static IEnumerable<object[]> _2_07_data()
        {
            yield return new object[] { 36, 63, 9 };
            yield return new object[] { 10, 5, 5 };
            yield return new object[] { 35, 64, 1 };
        }

        private static IEnumerable<object[]> _2_08_data()
        {
            yield return new object[] { 36, 63, false };
            yield return new object[] { 10, 5, false };
            yield return new object[] { 35, 64, true };
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_01_data), DynamicDataSourceType.Method)]
        public void _2_01_should_determine_whether_given_integer_number_is_prime(int number, bool expected)
        {
            var actual = Arithmetic._2_01(number);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_02_data), DynamicDataSourceType.Method)]
        public void _2_02_should_determine_prime_factors_of_given_positive_integer(int number, List<int> expected)
        {
            var actual = Arithmetic._2_02(number);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_03_data), DynamicDataSourceType.Method)]
        public void _2_03_should_determine_prime_factors_of_given_positive_integer(int number, List<(int, int)> expected)
        {
            var actual = Arithmetic._2_03(number);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_04_data), DynamicDataSourceType.Method)]
        public void _2_04_should_construct_list_of_prime_numbers(int fromRange, int toRange, List<int> expected)
        {
            var actual = Arithmetic._2_04(fromRange, toRange);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_05_data), DynamicDataSourceType.Method)]
        public void _2_05_should_find_two_prime_numbers_that_sum_up_to_given_even_integer(int number, (int, int) expected)
        {
            var actual = Arithmetic._2_05(number);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_06_data), DynamicDataSourceType.Method)]
        public void _2_06_should_construct_list_of_Goldbach_compositions(int fromRange, int toRange, List<(int, (int, int))> expected)
        {
            var actual = Arithmetic._2_06(fromRange, toRange);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_07_data), DynamicDataSourceType.Method)]
        public void _2_07_should_determine_greatest_common_divisor_of_two_positive_integer_numbers(int number1, int number2, int expected)
        {
            var actual = Arithmetic._2_07(number1, number2);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(_2_08_data), DynamicDataSourceType.Method)]
        public void _2_08_should_determine_whether_two_positive_integer_numbers_are_coprime(int number1, int number2, bool expected)
        {
            var actual = Arithmetic._2_08(number1, number2);

            Assert.AreEqual(expected, actual);
        }
    }
}
