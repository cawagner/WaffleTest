using WaffleTest.Structure;

namespace WaffleTest.AssertionExtensions
{
    public static class FloatAssertions
    {
        public static Assertion ShouldBeInfinite(this ResultContext<float> result)
        {
            return new Assertion();
        }

        public static Assertion ShouldBeNaN(this ResultContext<float> result)
        {
            return new Assertion();
        }
    }
}