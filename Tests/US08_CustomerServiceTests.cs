using BlekingetrafikenTests.Pages;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("CustomerService")]
    [Description("Tests for US8: Customer Service feature")]
    public class US08_CustomerServiceTests : BaseTest
    {
        private CustomerServicePage _customerServicePage = null!;

        [SetUp]
        public void TestSetup()
        {
            _customerServicePage = new CustomerServicePage(Driver);
            _customerServicePage.Open();
        }

        [Test]
        [Description("Verify that the customer service page heading is displayed")]
        public void CustomerService_ShouldDisplayHeading()
        {
            // Act
            string heading = _customerServicePage.GetMainHeading();

            // Assert
            Assert.That(heading.Length, Is.GreaterThan(0),
                "The customer service page should display a heading");
            Assert.That(Driver.Url, Does.Contain("/kundservice"),
                "Should be on the customer service page");
        }

        [Test]
        [Description("Verify that all main customer service links are present")]
        public void CustomerService_ShouldHaveAllServiceLinks()
        {
            // Act
            bool hasAll = _customerServicePage.HasAllServiceLinks();

            // Assert
            Assert.That(hasAll, Is.True,
                "All service links should be present (FAQ, delay compensation, lost & found, contact)");
        }

    }
}
