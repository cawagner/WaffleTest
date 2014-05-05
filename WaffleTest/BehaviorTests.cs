using System;

namespace WaffleTest
{
    public abstract class BehaviorTests
    {
        protected WhenContext<T> When<T>(string description, Func<T> getTopic)
        {
            return new WhenContext<T>();
        }

        protected void It(string description, Assertion assertion)
        {
            
        }
    }
}
