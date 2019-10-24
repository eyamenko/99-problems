namespace _99Problems.Models
{
    public class ValueOrTerm<T> : Either<T, (int, T)>
    {
        public ValueOrTerm(T value) : base(value)
        {
        }

        public ValueOrTerm((int, T) term) : base(term)
        {
        }

        public ValueOrTerm(int count, T element) : this((count, element))
        {
        }
    }
}
