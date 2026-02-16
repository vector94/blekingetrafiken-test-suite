using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class StationsPage : BasePage
    {
        private readonly By _stationHeadings = By.TagName("h2");

        public StationsPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.StationsUrl);
            AcceptCookies();
        }

        public int GetStationCount()
        {
            var headings = Driver.FindElements(_stationHeadings);
            return headings.Count;
        }

        public bool IsStationDisplayed(string stationName)
        {
            var locator = By.XPath($"//h2[contains(text(), '{stationName}')]");
            if (IsElementDisplayed(locator)) return true;

            return Driver.PageSource.Contains(stationName);
        }

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
