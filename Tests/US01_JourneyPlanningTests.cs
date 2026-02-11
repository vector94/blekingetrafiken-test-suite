using BlekingetrafikenTests.Pages;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("JourneyPlanning")]
    [Description("Tests for US1: Journey Planning feature")]
    public class US01_JourneyPlanningTests : BaseTest
    {
        private HomePage _homePage = null!;

        [SetUp]
        public void TestSetup()
        {
            _homePage = new HomePage(Driver);
            _homePage.Open();
        }

        [Test]
        [Description("Verify that the journey planner form with fields and time selection is displayed")]
        public void JourneyPlanner_ShouldBeDisplayedWithTimeSelection()
        {
            // Act
            bool isDisplayed = _homePage.IsJourneyPlannerDisplayed();
            bool hasTimeSelection = _homePage.IsTimeSelectionDisplayed();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isDisplayed, Is.True,
                    "The journey planner form with 'Från' and 'Till' fields should be visible");
                Assert.That(hasTimeSelection, Is.True,
                    "The 'När vill du åka?' time selection should be visible");
            });
        }

    }
}
