using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class TrafficInfoPage : BasePage
    {
        private readonly By _trafikverketLink = By.CssSelector("a[href*='trafikverket.se']");

        public TrafficInfoPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.TrafficInfoUrl);
            AcceptCookies();
        }

        public bool HasTrafikverketLink()
        {
            return IsElementDisplayed(_trafikverketLink);
        }

        public string GetTrafikverketLinkHref()
        {
            var link = Driver.FindElement(_trafikverketLink);
            return link.GetAttribute("href") ?? string.Empty;
        }

        public bool HasDisruptionContent()
        {
            var pageSource = Driver.PageSource.ToLower();
            return pageSource.Contains("störning") || pageSource.Contains("trafikläge") || pageSource.Contains("försening");
        }
    }
}
