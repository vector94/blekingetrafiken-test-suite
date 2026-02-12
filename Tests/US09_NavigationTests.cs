using BlekingetrafikenTests.Pages;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("Navigation")]
    [Description("Tests for US9: Navigation Menu feature")]
    public class US09_NavigationTests : BaseTest
    {
        private HomePage _homePage = null!;

        [SetUp]
        public void TestSetup()
        {
            _homePage = new HomePage(Driver);
            _homePage.Open();
        }

        [Test]
        [Description("Verify that clicking 'Biljetter' navigates to the tickets page")]
        public void Navigation_BiljettLink_ShouldNavigateToTicketsPage()
        {
            // Act
            _homePage.NavigateToTickets();

            // Assert
            Assert.That(Driver.Url, Does.Contain("/biljetter"),
                "Clicking 'Biljetter' should navigate to the tickets page");
        }

        [Test]
        [Description("Verify that clicking 'Reseinformation' navigates to the travel info page")]
        public void Navigation_ReseinformationLink_ShouldNavigateToTravelInfoPage()
        {
            // Act
            _homePage.NavigateToTravelInfo();

            // Assert
            Assert.That(Driver.Url, Does.Contain("/reseinformation"),
                "Clicking 'Reseinformation' should navigate to the travel info page");
        }

        [Test]
        [Description("Verify that clicking 'Kundservice' navigates to the customer service page")]
        public void Navigation_KundserviceLink_ShouldNavigateToCustomerServicePage()
        {
            // Act
            _homePage.NavigateToCustomerService();

            // Assert
            Assert.That(Driver.Url, Does.Contain("/kundservice"),
                "Clicking 'Kundservice' should navigate to the customer service page");
        }
    }
}
