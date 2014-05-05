using System;

namespace WaffleTest
{
    public class WhenContext<T>
    {
        public void Then(Action<ResultContext<T>> assertions)
        {

        }
    }
}