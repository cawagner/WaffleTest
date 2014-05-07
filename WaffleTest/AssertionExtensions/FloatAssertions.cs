using WaffleTest.Structure;

namespace WaffleTest.AssertionExtensions
{
    public static class FloatAssertions
    {
        public static Assertion MustBeInfinite(this ResultContext<float> result)
        {
            return result.Must(v => new Assertion(float.IsInfinity(v), string.Format("Expected +/-Infinity but got '{0}'", v)));
        }

        public static Assertion MustBeNaN(this ResultContext<float> result)
        {
            return result.Must(v => new Assertion(float.IsNaN(v), string.Format("Expected NaN but got '{0}'", v)));
        }
    }
}