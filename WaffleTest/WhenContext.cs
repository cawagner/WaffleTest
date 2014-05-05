using System;

namespace WaffleTest
{
    public sealed class WhenContext<T>
    {
        private readonly string _description;
        private readonly Func<T> _getTopic;

        internal WhenContext(string description, Func<T> getTopic)
        {
            _description = description;
            _getTopic = getTopic;
        }

        public void Then(Action<ResultContext<T>> assertions)
        {

        }
    }
}