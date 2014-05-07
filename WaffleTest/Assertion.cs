namespace WaffleTest
{
    public sealed class Assertion
    {
        public bool Passed { get; private set; }
        public string Message { get; private set; }

        public Assertion(bool passed, string message)
        {
            Passed = passed;
            Message = passed ? "" : message;
        }
    }
}