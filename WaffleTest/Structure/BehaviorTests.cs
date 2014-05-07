using System;

namespace WaffleTest.Structure
{
    public abstract class BehaviorTests
    {
        private ITestExecutor _testExecutor = new NoopTestExecutor();
        internal ITestExecutor TestExecutor
        {
            get { return _testExecutor; }
            set { _testExecutor = value; }
        }

        protected void When<T>(string description, Func<T> getTopic, Action<ResultContext<T>> assert)
        {
            TestExecutor.When(description, getTopic, assert);
        }

        protected void When(string description, Action performActions, Action<ResultContext<VoidType>> assert)
        {
            When(description, () =>
            {
                performActions();
                return VoidType.Value;
            }, assert);
        }

        protected void When(string description, Action more)
        {
            When(description, () => VoidType.Value, r => more());
        }

        protected void Given<T>(string description, Subject<T> subject, Action<Func<T>> withSubject)
        {
            TestExecutor.Given(description, subject, withSubject);
        }

        protected void Then(string description, Assertion assertion)
        {
            TestExecutor.Then(description, assertion);
        }
    }
}
