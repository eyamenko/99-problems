using System;

namespace _99Problems.Models
{
    public class EitherValueOrTerm<T> : Either<T, Term<T>> where T : IEquatable<T>
    {
        public EitherValueOrTerm(T value) : base(value)
        {
        }

        public EitherValueOrTerm(Term<T> term) : base(term)
        {
        }

        public EitherValueOrTerm(int count, T element) : base(new Term<T>(count, element))
        {
        }
    }
}
