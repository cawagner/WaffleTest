using System;

namespace WaffleTest
{
    public sealed class Subject<T>
    {
        private readonly Func<T> _factory;

        internal Subject(Func<T> factory)
        {
            _factory = factory;
        }

        public T Get()
        {
            return _factory();
        }
    }

    public static class Subject
    {
        public static Subject<T> FromFactory<T>(Func<T> factory)
        {
            return new Subject<T>(factory);
        }
    }
}