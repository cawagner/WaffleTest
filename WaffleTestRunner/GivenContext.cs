using System;

namespace WaffleTestRunner
{
    internal class GivenContext
    {
        public string Description { get; private set; }
        public Action Refresh { get; private set; }

        public GivenContext(string description, Action refresh)
        {
            Description = description;
            Refresh = refresh;
        }
    }
}