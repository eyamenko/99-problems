using System;

namespace _99Problems.Models
{
    public class Term<T>
    {
        public int Count { get; }
        public T Element { get; }

        public Term(int count, T element)
        {
            Count = count;
            Element = element ?? throw new ArgumentNullException(nameof(element));
        }

        public override int GetHashCode()
        {
            return (Count, Element).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is Term<T> other && other.Count == Count && other.Element.Equals(Element);
        }
    }
}
