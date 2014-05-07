using System;
using WaffleTest.Structure;

namespace WaffleTest
{
    internal class NoopTestExecutor : ITestExecutor
    {
        public void When<T>(string description, Func<T> getTopic, Action<ResultContext<T>> assert)
        {
        }

        public void Given<T>(string description, Subject<T> subject, Action<Func<T>> withSubject)
        {
        }

        public void Then(string description, Assertion assertion)
        {
        }
    }
}