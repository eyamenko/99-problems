using System;

namespace _99Problems.Models
{
    public class Term<T> : IEquatable<Term<T>> where T : IEquatable<T>
    {
        public int Count { get; }
        public T Element { get; }

        public Term(int count, T element)
        {
            Count = count;
            Element = element ?? throw new ArgumentNullException(nameof(element));
        }

        public bool Equals(Term<T> other)
        {
            if (other is null)
            {
                return false;
            }

            return Count == other.Count && Element.Equals(other.Element);
        }
    }
}
