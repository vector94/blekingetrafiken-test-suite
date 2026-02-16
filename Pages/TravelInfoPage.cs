using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class TravelInfoPage : BasePage
    {
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

        public bool HasAllSubSectionLinks()
        {
            return IsElementDisplayed(_timetablesLink)
                && IsElementDisplayed(_stationsLink)
                && IsElementDisplayed(_zonesLink)
                && IsElementDisplayed(_trafficInfoLink);
        }
    }
}
