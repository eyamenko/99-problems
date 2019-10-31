using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _99Problems.Tests.Helpers
{
    public static class NestedCollectionAssert
    {
        public static void AreEqual<T>(ICollection<T> expected, ICollection<T> actual) where T : ICollection
        {
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0, j = 0; i < expected.Count && j < actual.Count; i++, j++)
            {
                CollectionAssert.AreEqual(expected.ElementAt(i), actual.ElementAt(j));
            }
        }
    }
}
