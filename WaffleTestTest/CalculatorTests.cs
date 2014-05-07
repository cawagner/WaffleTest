using System;
using System.Linq;
using System.Threading;
using WaffleTest;
using WaffleTest.AssertionExtensions;
using WaffleTest.Structure;

namespace WaffleTestTest
{
    public class CalculatorTests : BehaviorTests
    {
        public void AdditionTests()
        {
            When("2 + 2 are added", () => 2 + 2, result => {
                Then("the result should equal 4", result.MustEqual(4));
            });
        }

        public void DivisionTests()
        {
            When("dividing numbers by 0", () =>
            {
                When("working with ints", () => 1 / int.Parse("0"), result =>
                {
                    Then("the operation should throw a DivideByZero", result.MustHaveThrown(typeof(DivideByZeroException)));

                    // this shouldn't actually pass
                    Then("the operation should throw a stupid exception", result.MustHaveThrown(typeof(AbandonedMutexException)));
                });

                When("when working with doubles", () => 1.0 / 0.0, result =>
                {
                    Then("the result should be infinite", result.MustBeInfinite());
                });
            });
        }

        public void SummationTests()
        {
            var anEmptyList = Subject.FromFactory(() => new int[] { });

            Given("an empty list", anEmptyList, list => {
                When("the list items are summed", () => list().Sum(), result =>
                {
                    Then("the total should equal 0", result.MustEqual(0));
                });
            });
        }
    }
}
