using System;
using System.Collections.Generic;
using WaffleTest;
using WaffleTest.Structure;

namespace WaffleTestRunner
{
    internal class ConsoleTestExecutor : ITestExecutor
    {
        private int _indent = 0;
        private readonly Stack<GivenContext> _givens = new Stack<GivenContext>();

        public void When<T>(string description, Func<T> getTopic, Action<ResultContext<T>> assert)
        {
            foreach (var given in _givens)
            {
                try
                {
                    given.Refresh();
                }
                catch (Exception ex)
                { 
                    Console.WriteLine("Error satisfying given '{0}': {1}", given.Description, ex);
                }
            }
            Console.WriteLine(new string(' ', _indent) + "When " + description + "...");

            _indent++;
            try
            {
                assert(ResultContext<T>.FromValue(getTopic()));
            }
            catch (Exception ex)
            {
                assert(ResultContext<T>.FromException(ex));
            }
            --_indent;
        }

        public void Given<T>(string description, Subject<T> subject, Action<Func<T>> withSubject)
        {
            Console.WriteLine(new string(' ', _indent) + "Given " + description + "...");

            T givenValue = default(T);
            var given = new GivenContext(description, () => givenValue = subject.Get());
            Func<T> getGiven = () => givenValue;

            _givens.Push(given);
            ++_indent;

            withSubject(getGiven);

            --_indent;
            _givens.Pop();
        }

        public void Then(string description, Assertion assertion)
        {
            Console.WriteLine(new string(' ', _indent) + "Then " + description + "...");
        }
    }
}