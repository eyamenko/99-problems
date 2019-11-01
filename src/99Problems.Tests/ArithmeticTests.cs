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

        [DataTestMethod]
        [DynamicData(nameof(_2_01_data), DynamicDataSourceType.Method)]
        public void _2_01_should_determine_whether_given_integer_number_is_prime(int number, bool expected)
        {
            var actual = Arithmetic._2_01(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
