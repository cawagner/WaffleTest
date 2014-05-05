using WaffleTest;

namespace WaffleTestTest
{
    public class CalculatorTests : BehaviorTests
    {
        public void AdditionTests()
        {
            When("the user adds 2 + 2", () => 2 + 2).Then(result => {
                It("should equal 4", result.ShouldEqual(4));
            });
        }
    }
}
