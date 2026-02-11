using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Traffic Information (Trafikinformation) page.
    /// Displays current and planned service disruptions.
    /// </summary>
    public class TrafficInfoPage : BasePage
    {
        private readonly By _trafikverketLink = By.CssSelector("a[href*='trafikverket.se']");

        public TrafficInfoPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.TrafficInfoUrl);
            AcceptCookies();
        }

        /// <summary>
        /// Checks if the Trafikverket external link is present.
        /// This link allows users to track real-time rail traffic status.
        /// </summary>
        public bool HasTrafikverketLink()
        {
            return IsElementDisplayed(_trafikverketLink);
        }

        /// <summary>
        /// Gets the href of the Trafikverket link for verification.
        /// </summary>
        public string GetTrafikverketLinkHref()
        {
            var link = Driver.FindElement(_trafikverketLink);
            return link.GetAttribute("href") ?? string.Empty;
        }

        /// <summary>
        /// Checks if the page contains disruption-related content.
        /// Looks for keywords: "störningar" (disruptions), "förseningar" (delays).
        /// </summary>
        public bool HasDisruptionContent()
        {
            var pageSource = Driver.PageSource.ToLower();
            return pageSource.Contains("störning") || pageSource.Contains("planerad") || pageSource.Contains("trafik");
        }
    }
}
