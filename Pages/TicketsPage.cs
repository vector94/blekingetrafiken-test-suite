using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Tickets (Biljetter) section.
    /// Covers ticket types overview and individual ticket detail pages.
    /// </summary>
    public class TicketsPage : BasePage
    {
        // Ticket type links confirmed from web scraping
        private readonly By _enkelbiljettLink = By.CssSelector("a[href*='/biljetter/enkelbiljett/']");
        private readonly By _flexbiljettLink = By.CssSelector("a[href*='/biljetter/flexbiljett/']");
        private readonly By _24hLink = By.CssSelector("a[href*='/biljetter/24-timmarsbiljett/']");
        private readonly By _30dLink = By.CssSelector("a[href*='/biljetter/30-dagarsbiljett/']");
        private readonly By _365dLink = By.CssSelector("a[href*='/biljetter/365-dagarsbiljett/']");

        /// <summary>
        /// All five ticket type names that should appear on the page.
        /// Used for data-driven verification.
        /// </summary>
        public static readonly string[] ExpectedTicketTypes =
        {
            "Enkelbiljett",
            "Flexbiljett",
            "24-timmarsbiljett",
            "30-dagarsbiljett",
            "365-dagarsbiljett"
        };

        public TicketsPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.TicketsUrl);
            AcceptCookies();
        }

        /// <summary>
        /// Checks if a specific ticket type link is present on the page.
        /// </summary>
        public bool IsTicketTypeDisplayed(string ticketName)
        {
            var locator = By.XPath($"//a[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{ticketName.ToLower()}')]");
            return IsElementDisplayed(locator);
        }

        /// <summary>
        /// Counts how many of the expected ticket types are displayed.
        /// </summary>
        public int GetDisplayedTicketTypeCount()
        {
            int count = 0;
            foreach (var ticketType in ExpectedTicketTypes)
            {
                if (IsTicketTypeDisplayed(ticketType))
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Clicks on a specific ticket type to navigate to its detail page.
        /// </summary>
        public void ClickTicketType(string ticketName)
        {
            var locator = By.XPath($"//a[contains(text(), '{ticketName}')]");
            var link = WaitHelper.WaitForClickable(Driver, locator);
            ScrollToElement(link);
            link.Click();
        }

        /// <summary>
        /// Checks if the current page URL matches a ticket detail page.
        /// </summary>
        public bool IsOnTicketDetailPage(string ticketName)
        {
            return Driver.Url.ToLower().Contains(ticketName.ToLower().Replace(" ", "-"));
        }
    }
}
