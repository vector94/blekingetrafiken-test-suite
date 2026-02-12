using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Zones (Zoner) page.
    /// Displays zone map, zone categories, and fare structure.
    /// </summary>
    public class ZonesPage : BasePage
    {
        public ZonesPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.ZonesUrl);
            AcceptCookies();
        }

        /// <summary>
        /// Checks if the page contains zone-related content.
        /// </summary>
        public bool HasZoneContent()
        {
            var pageSource = Driver.PageSource;
            return pageSource.Contains("zon") || pageSource.Contains("Zon");
        }

        /// <summary>
        /// Checks if the page has sub-section headings (h2 or h3).
        /// </summary>
        public bool HasSubSections()
        {
            var headings = Driver.FindElements(By.CssSelector("h2, h3"));
            return headings.Count > 0;
        }

        /// <summary>
        /// Checks if the page contains downloadable content (PDF links or images).
        /// </summary>
        public bool HasDownloadableContent()
        {
            var pdfLinks = Driver.FindElements(By.CssSelector("a[href*='.pdf'], a[href*='pdf'], a[href*='karta']"));
            var images = Driver.FindElements(By.CssSelector("img"));
            return pdfLinks.Count > 0 || images.Count > 1; // More than just logo
        }

        /// <summary>
        /// Checks if a specific text is present anywhere on the page.
        /// </summary>
        public bool PageContainsText(string text)
        {
            return Driver.PageSource.Contains(text);
        }
    }
}
