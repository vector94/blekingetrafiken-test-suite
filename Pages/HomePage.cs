using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Page Object for the Blekingetrafiken home page.
    /// Contains the dynamically-loaded journey planner and main navigation.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly By _ticketsLink = By.CssSelector("a[href='/biljetter/']");
        private readonly By _travelInfoLink = By.CssSelector("a[href='/reseinformation/']");
        private readonly By _customerServiceLink = By.CssSelector("a[href='/kundservice/']");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.BaseUrl);
            AcceptCookies();
        }

        /// <summary>
        /// Checks if the journey planner section is present on the page.
        /// Uses multiple fallback selectors since the form is dynamically rendered.
        /// </summary>
        public bool IsJourneyPlannerDisplayed()
        {
            try
            {
                var fromLabel = Driver.FindElements(By.XPath("//*[contains(text(), 'Från')]"));
                var toLabel = Driver.FindElements(By.XPath("//*[contains(text(), 'Till')]"));

                return fromLabel.Count > 0 && toLabel.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the date/time selection area is visible.
        /// Verifies the "När vill du åka?" (When do you want to travel?) section.
        /// </summary>
        public bool IsTimeSelectionDisplayed()
        {
            var timeLabel = Driver.FindElements(By.XPath("//*[contains(text(), 'När vill du åka')]"));
            return timeLabel.Count > 0;
        }

        /// <summary>
        /// Checks if the main navigation menu contains all expected links.
        /// </summary>
        public bool IsNavigationMenuDisplayed()
        {
            return IsElementDisplayed(_ticketsLink)
                && IsElementDisplayed(_travelInfoLink)
                && IsElementDisplayed(_customerServiceLink);
        }

        public void NavigateToTickets()
        {
            WaitHelper.WaitForClickable(Driver, _ticketsLink).Click();
        }

        public void NavigateToTravelInfo()
        {
            WaitHelper.WaitForClickable(Driver, _travelInfoLink).Click();
        }

        public void NavigateToCustomerService()
        {
            WaitHelper.WaitForClickable(Driver, _customerServiceLink).Click();
        }

        /// <summary>
        /// Gets the page title text from the browser tab.
        /// </summary>
        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
