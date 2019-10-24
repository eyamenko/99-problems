using System;

namespace _99Problems.Models
{
    public class ValueOrTerm<T> : Either<T, Tuple<int, T>>
    {
        public ValueOrTerm(T value) : base(value)
        {
        }

        public ValueOrTerm(Tuple<int, T> term) : base(term)
        {
        }

        public ValueOrTerm(int count, T element) : this(new Tuple<int, T>(count, element))
        {
        }
    }
}
