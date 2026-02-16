using BlekingetrafikenTests.Pages;
using BlekingetrafikenTests.Utils;
using OpenQA.Selenium;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("JourneyResults")]
    [Description("Tests for US2: Journey Results feature")]
    public class US02_JourneyResultsTests : BaseTest
    {
        private HomePage _homePage = null!;

        [SetUp]
        public void TestSetup()
        {
            _homePage = new HomePage(Driver);
        }

        [Test]
        [Description("Verify that the journey planner form fields are present for trip search input")]
        public void JourneyResults_FormFieldsShouldBePresent()
        {
            // Arrange
            _homePage.Open();

            // Act
            var fromLabels = Driver.FindElements(By.XPath("//*[contains(text(), 'Från')]"));
            var toLabels = Driver.FindElements(By.XPath("//*[contains(text(), 'Till')]"));
            var searchButtons = Driver.FindElements(By.XPath("//button[contains(text(), 'Sök')] | //input[@value='Sök']"));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(fromLabels.Count, Is.GreaterThan(0), "'Från' (From) field label should be present");
                Assert.That(toLabels.Count, Is.GreaterThan(0), "'Till' (To) field label should be present");
                Assert.That(searchButtons.Count, Is.GreaterThan(0), "Search ('Sök') button should be present");
            });
        }

        [Test]
        [Description("Verify that the extended search page exists and provides journey search direction")]
        public void JourneyResults_ExtendedSearchPageShouldExist()
        {
            // Arrange & Act
            Driver.Navigate().GoToUrl(TestConfig.BaseUrl + "/reseinformation/sok-resa/");
            string pageSource = Driver.PageSource.ToLower();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(Driver.Title, Is.Not.Empty, "The extended search page should load with a title");
                Assert.That(pageSource, Does.Contain("resa").Or.Contain("sök").Or.Contain("app"),
                    "The page should contain journey search or app redirect content");
            });
        }
    }
}
