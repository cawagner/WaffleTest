using System;
using WaffleTest.Structure;

namespace WaffleTest.AssertionExtensions
{
    public static class StandardAssertions
    {
        public static Assertion Must<T>(this ResultContext<T> result, Func<T, Assertion> innerAssertion)
        {
            T actualValue;
            Exception exception;

            result.TryGetException(out exception);

            return result.TryGetValue(out actualValue)
                ? innerAssertion(actualValue)
                : new Assertion(false, "An exception was thrown: " + exception);
        }

        public static Assertion MustEqual<T>(this ResultContext<T> result, T expectedValue)
        {
            return result.Must(actualValue =>
                new Assertion(expectedValue.Equals(actualValue), "Expected '{0}' but got '{1}'"));
        }
    }
}