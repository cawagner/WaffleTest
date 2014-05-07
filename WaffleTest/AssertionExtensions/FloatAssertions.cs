using WaffleTest.Structure;

namespace WaffleTest.AssertionExtensions
{
    public static class FloatAssertions
    {
        public static Assertion MustBeInfinite(this ResultContext<float> result)
        {
            return new Assertion();
        }

        public static Assertion MustBeNaN(this ResultContext<float> result)
        {
            return new Assertion();
        }
    }
}