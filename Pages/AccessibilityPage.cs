using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Accessibility (Tillgänglighet) page.
    /// Contains information about accessibility features for buses, trains, and ferries.
    /// Sections may use h2, h3, or strong tags for sub-headings.
    /// </summary>
    public class AccessibilityPage : BasePage
    {
        // Accessibility statement links
        private readonly By _webAccessibilityLink = By.CssSelector(
            "a[href*='tillganglighetsredogorelse'], a[href*='tillganglighet'], a[href*='accessibility']"
        );

        public AccessibilityPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.AccessibilityUrl);
            AcceptCookies();
        }

        /// <summary>
        /// Checks if the Bus accessibility section is present.
        /// Searches across multiple heading levels and page content.
        /// </summary>
        public bool HasBusSection()
        {
            return PageContainsText("Buss");
        }

        /// <summary>
        /// Checks if the Train accessibility section is present.
        /// </summary>
        public bool HasTrainSection()
        {
            return PageContainsText("Tåg") || PageContainsText("tåg");
        }

        /// <summary>
        /// Checks if the Ferry (Båt) accessibility section is present.
        /// </summary>
        public bool HasFerrySection()
        {
            return PageContainsText("Båt") || PageContainsText("båt");
        }

        /// <summary>
        /// Checks that all three transport type sections are mentioned on the page.
        /// </summary>
        public bool HasAllTransportSections()
        {
            return HasBusSection() && HasTrainSection() && HasFerrySection();
        }

        /// <summary>
        /// Checks if accessibility statement links are present.
        /// </summary>
        public bool HasAccessibilityStatementLinks()
        {
            return IsElementDisplayed(_webAccessibilityLink);
        }

        /// <summary>
        /// Checks if the page contains specific text in its source.
        /// </summary>
        private bool PageContainsText(string text)
        {
            return Driver.PageSource.Contains(text);
        }
    }
}
