using System;

namespace WaffleTest
{
    public abstract class BehaviorTests
    {
        internal ITestExecutor TestExecutor { get; set; }

        protected WhenContext<T> When<T>(string description, Func<T> getTopic)
        {
            return new WhenContext<T>(description, getTopic);
        }

        protected GivenContext<T> Given<T>(Subject<T> subject)
        {
            return new GivenContext<T>(subject);
        }

        protected void It(string description, Assertion assertion)
        {
            
        }
    }

    internal interface ITestExecutor
    {
    }
}
