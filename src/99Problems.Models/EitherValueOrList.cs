using System.Collections.Generic;
using System.Linq;

namespace _99Problems.Models
{
    public class EitherValueOrList<T> : Either<T, List<EitherValueOrList<T>>>
    {
        public EitherValueOrList(T value) : base(value)
        {
        }

        public EitherValueOrList(params EitherValueOrList<T>[] valuesAndLists) : base(valuesAndLists.ToList())
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is EitherValueOrList<T> other && ((other.HasValue1 && HasValue1 && other.Value1.Equals(Value1)) || (other.HasValue2 && HasValue2 && other.Value2.SequenceEqual(Value2)));
        }
    }
}
