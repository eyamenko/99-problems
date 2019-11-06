namespace _99Problems.Helpers
{
    public static class BoolExtensions
    {
        public static bool And(this bool a, bool b)
        {
            return LogicalPredicates.And(a, b);
        }

        public static bool Or(this bool a, bool b)
        {
            return LogicalPredicates.Or(a, b);
        }

        public static bool Not(this bool a)
        {
            return LogicalPredicates.Not(a);
        }
    }
}
