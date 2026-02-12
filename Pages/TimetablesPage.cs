using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Timetables (Tidtabeller) page.
    /// The page content may be dynamically rendered (Angular-based).
    /// </summary>
    public class TimetablesPage : BasePage
    {
        public TimetablesPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.TimetablesUrl);
            AcceptCookies();
        }

        /// <summary>
        /// Checks if the timetable page has content (headings, forms, or timetable links).
        /// </summary>
        public bool HasTimetableContent()
        {
            var pageSource = Driver.PageSource.ToLower();
            return pageSource.Contains("tidtabell") || pageSource.Contains("linje") || pageSource.Contains("tåg");
        }

        /// <summary>
        /// Checks if the page has interactive or informational content about timetables.
        /// Uses broad selectors since the page may render dynamically.
        /// </summary>
        public bool HasTimetableLinks()
        {
            // Check for any links related to timetables or PDF downloads
            var links = Driver.FindElements(By.CssSelector("a[href*='pdf'], a[href*='tidtabell'], a[href*='linje']"));
            if (links.Count > 0) return true;

            // Fallback: check for sub-headings that indicate timetable sections
            var headings = Driver.FindElements(By.TagName("h2"));
            return headings.Count > 0;
        }
    }
}
