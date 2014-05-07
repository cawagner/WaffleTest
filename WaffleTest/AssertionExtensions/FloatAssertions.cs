using WaffleTest.Structure;

namespace WaffleTest.AssertionExtensions
{
    public static class FloatAssertions
    {
        public static Assertion MustBeInfinite(this ResultContext<double> result)
        {
            return result.Must(v => new Assertion(double.IsInfinity(v), string.Format("Expected +/-Infinity but got '{0}'", v)));
        }

        public static Assertion MustBeNaN(this ResultContext<double> result)
        {
            return result.Must(v => new Assertion(double.IsNaN(v), string.Format("Expected NaN but got '{0}'", v)));
        }
    }
}