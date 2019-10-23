using System;

namespace _99Problems.Models
{
    public class Either<T1, T2>
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

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is Either<T1, T2> other && ((other.HasValue1 && HasValue1 && other.Value1.Equals(other.Value1)) || (other.HasValue2 && HasValue2 && other.Value2.Equals(other.Value2)));
        }

        public override int GetHashCode()
        {
            return (Value1, Value2).GetHashCode();
        }
    }
}
