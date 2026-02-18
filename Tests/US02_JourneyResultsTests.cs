using BlekingetrafikenTests.Pages;
using BlekingetrafikenTests.Utils;
using OpenQA.Selenium;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("JourneyResults")]
    [Description("Tests for US2: Extended Journey Search feature")]
    public class US02_JourneyResultsTests : BaseTest
    {
        private HomePage _homePage = null!;

        [SetUp]
        public void TestSetup()
        {
            _homePage = new HomePage(Driver);
        }

        [Test]
        [Description("Verify that the journey search page has From/To fields and a search button")]
        public void JourneyResults_FormFieldsShouldBePresent()
        {
            // Arrange
            _homePage.Open();

            // Act
            bool hasPlanner = _homePage.IsJourneyPlannerDisplayed();
            var searchButtons = Driver.FindElements(By.XPath("//button[contains(text(), 'Sök')] | //input[@value='Sök']"));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(hasPlanner, Is.True, "'Från' and 'Till' fields should be present");
                Assert.That(searchButtons.Count, Is.GreaterThan(0), "Search ('Sök') button should be present");
            });
        }

        [Test]
        [Description("Verify that the extended search page exists and loads successfully")]
        public void JourneyResults_ExtendedSearchPageShouldExist()
        {
            // Arrange & Act
            Driver.Navigate().GoToUrl(TestConfig.ExtendedSearchUrl);
            string pageSource = Driver.PageSource.ToLower();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(Driver.Title, Is.Not.Empty, "The extended search page should load with a title");
                Assert.That(pageSource, Does.Contain("resa").Or.Contain("sök"),
                    "The page should contain journey search content");
            });
        }
    }
}
