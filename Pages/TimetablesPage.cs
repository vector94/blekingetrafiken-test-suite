using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class TimetablesPage : BasePage
    {
        public TimetablesPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.TimetablesUrl);
            AcceptCookies();
        }

        public bool HasTimetableContent()
        {
            var pageSource = Driver.PageSource.ToLower();
            return pageSource.Contains("tidtabell") || pageSource.Contains("linje") || pageSource.Contains("tåg");
        }

        public bool HasTimetableLinks()
        {
            var links = Driver.FindElements(By.CssSelector("a[href*='pdf'], a[href*='tidtabell'], a[href*='linje']"));
            if (links.Count > 0) return true;

            var headings = Driver.FindElements(By.TagName("h2"));
            return headings.Count > 0;
        }
    }
}
