using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Travel Information (Reseinformation) section.
    /// Provides access to timetables, stations, zones, traffic info, and accessibility.
    /// </summary>
    public class TravelInfoPage : BasePage
    {
        // Sub-section links confirmed from web scraping
        private readonly By _timetablesLink = By.CssSelector("a[href*='/reseinformation/tidtabeller/']");
        private readonly By _stationsLink = By.CssSelector("a[href*='/reseinformation/stationer/']");
        private readonly By _zonesLink = By.CssSelector("a[href*='/reseinformation/zoner/']");
        private readonly By _trafficInfoLink = By.CssSelector("a[href*='/reseinformation/trafikinformation/']");
        private readonly By _accessibilityLink = By.CssSelector("a[href*='/reseinformation/tillganglighet/']");

        public TravelInfoPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.TravelInfoUrl);
            AcceptCookies();
        }

        public void NavigateToTimetables()
        {
            var link = WaitHelper.WaitForClickable(Driver, _timetablesLink);
            ScrollToElement(link);
            link.Click();
        }

        public void NavigateToStations()
        {
            var link = WaitHelper.WaitForClickable(Driver, _stationsLink);
            ScrollToElement(link);
            link.Click();
        }

        public void NavigateToZones()
        {
            var link = WaitHelper.WaitForClickable(Driver, _zonesLink);
            ScrollToElement(link);
            link.Click();
        }

        public void NavigateToTrafficInfo()
        {
            var link = WaitHelper.WaitForClickable(Driver, _trafficInfoLink);
            ScrollToElement(link);
            link.Click();
        }

        public void NavigateToAccessibility()
        {
            var link = WaitHelper.WaitForClickable(Driver, _accessibilityLink);
            ScrollToElement(link);
            link.Click();
        }

        /// <summary>
        /// Checks that all expected sub-section links are present.
        /// </summary>
        public bool HasAllSubSectionLinks()
        {
            return IsElementDisplayed(_timetablesLink)
                && IsElementDisplayed(_stationsLink)
                && IsElementDisplayed(_zonesLink)
                && IsElementDisplayed(_trafficInfoLink);
        }
    }
}
