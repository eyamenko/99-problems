using System.Collections.Generic;
using System.Linq;

namespace _99Problems.Models
{
    public class ValueOrList<T> : Either<T, List<ValueOrList<T>>>
    {
        public ValueOrList(T value) : base(value)
        {
        }

        public ValueOrList(List<ValueOrList<T>> list) : base(list)
        {
        }

        public ValueOrList(params ValueOrList<T>[] valuesAndLists) : this(valuesAndLists.ToList())
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is ValueOrList<T> other && other.HasValue2 && HasValue2)
            {
                return other.Value2.SequenceEqual(Value2);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                if (HasValue2)
                {
                    return Value2.Aggregate(19, (hash, i) => hash * 31 + i.GetHashCode());
                }

                return base.GetHashCode();
            }
        }
    }
}
