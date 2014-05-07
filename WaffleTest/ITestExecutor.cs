using System;
using WaffleTest.Structure;

namespace WaffleTest
{
    internal interface ITestExecutor
    {
        void When<T>(string description, Func<T> getTopic, Action<ResultContext<T>> assert);
        void Given<T>(string description, Subject<T> subject, Action<Func<T>> withSubject);
        void Then(string description, Assertion assertion);
    }
}