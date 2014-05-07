using System;

namespace WaffleTest.Structure
{
    public class ResultContext<T>
    {
        private readonly Exception _exception;
        private readonly bool _hasValue;
        private readonly T _value;

        private ResultContext(bool hasValue, T result, Exception exception)
        {
            _hasValue = hasValue;
            _value = result;
            _exception = exception;
        }

        internal static ResultContext<T> FromException(Exception ex)
        {
            return new ResultContext<T>(false, default(T), ex);
        }

        internal static ResultContext<T> FromValue(T value)
        {
            return new ResultContext<T>(true, value, null);
        }

        public bool TryGetException(out Exception exception)
        {
            exception = _exception;
            return !_hasValue;
        }

        public bool TryGetValue(out T value)
        {
            value = default(T);
            if (_hasValue)
            {
                value = _value;
            }
            return _hasValue;
        }
    }
}