using BlekingetrafikenTests.Pages;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("TicketInfo")]
    [Description("Tests for US6: Ticket Information feature")]
    public class US06_TicketInfoTests : BaseTest
    {
        private TicketsPage _ticketsPage = null!;

        [SetUp]
        public void TestSetup()
        {
            _ticketsPage = new TicketsPage(Driver);
            _ticketsPage.Open();
        }

        [Test]
        [Description("Verify each individual ticket type is displayed on the page")]
        [TestCase("Enkelbiljett")]
        [TestCase("Flexbiljett")]
        [TestCase("24-timmarsbiljett")]
        [TestCase("30-dagarsbiljett")]
        [TestCase("365-dagarsbiljett")]
        public void Tickets_ShouldDisplaySpecificTicketType(string ticketType)
        {
            // Act
            bool isDisplayed = _ticketsPage.IsTicketTypeDisplayed(ticketType);

            // Assert
            Assert.That(isDisplayed, Is.True,
                $"Ticket type '{ticketType}' should be displayed on the tickets page");
        }
    }
}
