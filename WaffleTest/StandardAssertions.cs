namespace WaffleTest
{
    public static class StandardAssertions
    {
        public static Assertion ShouldEqual<T>(this ResultContext<T> result, T value)
        {
            return new Assertion();
        }
    }
}