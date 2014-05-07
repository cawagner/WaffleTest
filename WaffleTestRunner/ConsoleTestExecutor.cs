using System;
using System.Collections.Generic;
using System.Diagnostics;
using WaffleTest;
using WaffleTest.Structure;

namespace WaffleTestRunner
{
    internal class ConsoleTestExecutor : ITestExecutor
    {
        public int TestsRun { get; private set; }
        public int TestsPassed { get; private set; }

        private int _indent = 0;
        private readonly Stack<GivenContext> _givens = new Stack<GivenContext>();

        public void When<T>(string description, Func<T> getTopic, Action<ResultContext<T>> assert)
        {
            RefreshAllGivens<T>();
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

        private void RefreshAllGivens<T>()
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
        }

        public void Given<T>(string description, Subject<T> subject, Action<Func<T>> withSubject)
        {
            Console.Write(new string(' ', _indent) + "Given " + description + "... ");

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
            Console.Write(new string(' ', _indent) + "Then " + description + "...");
            
            var oldColor = Console.ForegroundColor;
            if (assertion.Passed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" PASS");
                ++TestsPassed;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" FAIL");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(new string(' ', _indent + 1) + assertion.Message);
            }
            Console.ForegroundColor = oldColor;
            ++TestsRun;
        }
    }
}