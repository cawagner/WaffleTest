using WaffleTest.Structure;

namespace WaffleTest.AssertionExtensions
{
    public static class StandardAssertions
    {
        public static Assertion MustEqual<T>(this ResultContext<T> result, T value)
        {
            return new Assertion();
        }
    }
}