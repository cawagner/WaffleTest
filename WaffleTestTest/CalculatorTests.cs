using System.Linq;
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

        public void SummationTests()
        {
            var anEmptyList = Subject.FromFactory(() => new[] { 0 });

            Given("an empty list", anEmptyList, list => {
                When("the list items are summed", () => list().Sum(), result =>
                {
                    Then("the total should equal 0", result.MustEqual(0));
                });
            });
        }
    }
}
