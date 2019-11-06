namespace _99Problems.Helpers
{
    public static class LogicalPredicates
    {
        public static bool And(bool a, bool b)
        {
            return a && b;
        }

        public static bool Or(bool a, bool b)
        {
            return a || b;
        }

        public static bool Not(bool a)
        {
            return !a;
        }

        public static bool Equ(bool a, bool b)
        {
            return a == b;
        }
    }
}
