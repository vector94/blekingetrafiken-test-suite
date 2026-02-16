using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class TicketsPage : BasePage
    {
        private readonly By _enkelbiljettLink = By.CssSelector("a[href*='/biljetter/enkelbiljett/']");
        private readonly By _flexbiljettLink = By.CssSelector("a[href*='/biljetter/flexbiljett/']");
        private readonly By _24hLink = By.CssSelector("a[href*='/biljetter/24-timmarsbiljett/']");
        private readonly By _30dLink = By.CssSelector("a[href*='/biljetter/30-dagarsbiljett/']");
        private readonly By _365dLink = By.CssSelector("a[href*='/biljetter/365-dagarsbiljett/']");

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

        public bool IsTicketTypeDisplayed(string ticketName)
        {
            var locator = By.XPath($"//a[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{ticketName.ToLower()}')]");
            return IsElementDisplayed(locator);
        }

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

        public void ClickTicketType(string ticketName)
        {
            var locator = By.XPath($"//a[contains(text(), '{ticketName}')]");
            var link = WaitHelper.WaitForClickable(Driver, locator);
            ScrollToElement(link);
            link.Click();
        }

        public bool IsOnTicketDetailPage(string ticketName)
        {
            return Driver.Url.ToLower().Contains(ticketName.ToLower().Replace(" ", "-"));
        }
    }
}
