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
    }
}
