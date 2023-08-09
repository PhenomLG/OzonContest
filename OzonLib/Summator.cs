namespace OzonLib
{
    public class Summator
    {
        private double _a, _b;

        private Summator(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public static Summator SetValues(double a, double b)
        {
            return new Summator(a, b);
        }

        public double Sum() => _a + _b;
    }
}