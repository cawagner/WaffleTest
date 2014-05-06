using WaffleTest;
using WaffleTest.AssertionExtensions;

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

        public void DivisionTests()
        {
            Subject<float> infinity = Subject.FromFactory(() => float.PositiveInfinity);

            Given(infinity).When("dividing it by 1", inf => inf / 1).Then(result =>
            {
                It("should still be infinite", result.ShouldBeInfinite());
            });
        }
    }
}
