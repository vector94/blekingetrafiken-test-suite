using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Stations (Stationer) page.
    /// Displays station information organized by h2 headings.
    /// No search input exists — stations are listed as static content.
    /// </summary>
    public class StationsPage : BasePage
    {
        private readonly By _stationHeadings = By.TagName("h2");

        public StationsPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.StationsUrl);
            AcceptCookies();
        }

        /// <summary>
        /// Gets the number of station headings displayed on the page.
        /// </summary>
        public int GetStationCount()
        {
            var headings = Driver.FindElements(_stationHeadings);
            return headings.Count;
        }

        /// <summary>
        /// Checks if a specific station name is displayed on the page.
        /// </summary>
        public bool IsStationDisplayed(string stationName)
        {
            // Check h2 headings first, then fall back to page source search
            var locator = By.XPath($"//h2[contains(text(), '{stationName}')]");
            if (IsElementDisplayed(locator)) return true;

            // Fallback: station name might be in different element or casing
            return Driver.PageSource.Contains(stationName);
        }

        /// <summary>
        /// Checks if station details contain transport type sub-sections
        /// (e.g., "Tågtrafik", "Busstrafik").
        /// </summary>
        public bool HasTransportTypeInfo()
        {
            var subHeadings = Driver.FindElements(By.TagName("h3"));
            foreach (var h3 in subHeadings)
            {
                var text = h3.Text.ToLower();
                if (text.Contains("tåg") || text.Contains("buss"))
                    return true;
            }
            return false;
        }
    }
}
