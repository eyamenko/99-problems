using System;

namespace _99Problems.Models
{
    public class Either<T1, T2> : IEquatable<Either<T1, T2>>
        where T1 : IEquatable<T1>
        where T2 : IEquatable<T2>
    {
        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public bool HasValue1 { get; }
        public bool HasValue2 { get; }

        public Either(T1 value)
        {
            Value1 = value ?? throw new ArgumentNullException(nameof(value));
            HasValue1 = true;
        }

        public Either(T2 value)
        {
            Value2 = value ?? throw new ArgumentNullException(nameof(value));
            HasValue2 = true;
        }

        public bool Equals(Either<T1, T2> other)
        {
            if (other is null)
            {
                return false;
            }

            return (HasValue1 && other.HasValue1 && Value1.Equals(other.Value1)) || (HasValue2 && other.HasValue2 && Value2.Equals(other.Value2));
        }
    }
}
