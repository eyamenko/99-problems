using System;

namespace _99Problems.Models
{
    public class EitherValueOrList<T> : Either<T, EquatableList<EitherValueOrList<T>>> where T : IEquatable<T>
    {
        public EitherValueOrList(T value) : base(value)
        {
        }

        public EitherValueOrList(params EitherValueOrList<T>[] valuesAndLists) : base(valuesAndLists.ToEquatableList())
        {
        }
    }
}
