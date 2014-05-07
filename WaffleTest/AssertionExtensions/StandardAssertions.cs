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

        public static Assertion MustHaveThrown<T>(this ResultContext<T> result, Type exceptionType)
        {
            Exception exception;
            return result.TryGetException(out exception)
                ? new Assertion(exception.GetType() == exceptionType, string.Format("Expected exception of type '{0}' but got the following: '{1}'", exceptionType.FullName, exception))
                : new Assertion(false, "No exception was thrown in code that should have thrown");
        }

        public static Assertion MustEqual<T>(this ResultContext<T> result, T expectedValue)
        {
            return result.Must(actualValue =>
                new Assertion(expectedValue.Equals(actualValue), "Expected '{0}' but got '{1}'"));
        }
    }
}