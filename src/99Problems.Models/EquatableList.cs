using System;
using System.Collections.Generic;
using System.Linq;

namespace _99Problems.Models
{
    public class EquatableList<T> : List<T>, IEquatable<EquatableList<T>>
    {
        public EquatableList(IEnumerable<T> collection) : base(collection)
        {
        }

        public bool Equals(EquatableList<T> other)
        {
            if (other is null)
            {
                return false;
            }

            return this.SequenceEqual(other);
        }
    }

    public static class EquatableListExtensions
    {
        public static EquatableList<T> ToEquatableList<T>(this IEnumerable<T> collection)
        {
            return new EquatableList<T>(collection);
        }
    }
}
