using System;

namespace WaffleTest.Structure
{
    public sealed class GivenContext<T>
    {
        private readonly Subject<T> _given;

        internal GivenContext(Subject<T> given)
        {
            _given = given;
        }

        public WhenContext<U> When<U>(string description, Func<T, U> getTopic)
        {
            return new WhenContext<U>(description, () => getTopic(_given.Get()));
        }

        public WhenContext<VoidType> When(string description, Action<T> performActions)
        {
            return When(description, given =>
            {
                performActions(given);
                return VoidType.Value;
            });
        }
    }
}