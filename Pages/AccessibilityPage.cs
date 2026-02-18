using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class AccessibilityPage : BasePage
    {
        private readonly By _webAccessibilityLink = By.CssSelector(
            "a[href*='tillganglighetsredogorelse'], a[href*='accessibility']"
        );

        public AccessibilityPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.AccessibilityUrl);
            AcceptCookies();
        }

        public bool HasBusSection()
        {
            return PageContainsText("Buss");
        }

        public bool HasTrainSection()
        {
            return PageContainsText("Tåg") || PageContainsText("tåg");
        }

        public bool HasFerrySection()
        {
            return PageContainsText("Båt") || PageContainsText("båt");
        }

        public bool HasAllTransportSections()
        {
            return HasBusSection() && HasTrainSection() && HasFerrySection();
        }

        public bool HasAccessibilityStatementLinks()
        {
            return IsElementDisplayed(_webAccessibilityLink);
        }

        private bool PageContainsText(string text)
        {
            return Driver.PageSource.Contains(text);
        }
    }
}
