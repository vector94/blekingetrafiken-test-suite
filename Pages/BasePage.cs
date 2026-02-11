using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    /// <summary>
    /// Base class for all Page Objects.
    /// Contains shared functionality: navigation, cookie handling, common waits.
    /// All page classes inherit from this to avoid code duplication.
    /// </summary>
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string GetTitle() => Driver.Title;

        public string GetCurrentUrl() => Driver.Url;

        /// <summary>
        /// Gets the text content of the main h1 heading on the page.
        /// </summary>
        public string GetMainHeading()
        {
            var heading = WaitHelper.WaitForElement(Driver, By.TagName("h1"));
            return heading.Text.Trim();
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Handles the Cookiebot consent banner that appears on first visit.
        /// Uses JavaScript click as fallback to avoid StaleElementReferenceException,
        /// which occurs when the banner DOM updates between finding and clicking.
        /// </summary>
        public void AcceptCookies()
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                var button = wait.Until(d =>
                {
                    try
                    {
                        var selectors = new[]
                        {
                            "CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll",
                            "CybotCookiebotDialogBodyButtonAccept"
                        };

                        foreach (var id in selectors)
                        {
                            var elements = d.FindElements(By.Id(id));
                            if (elements.Count > 0 && elements[0].Displayed)
                                return elements[0];
                        }
                        return null;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                });

                if (button != null)
                {
                    try
                    {
                        button.Click();
                    }
                    catch (StaleElementReferenceException)
                    {
                        // Element went stale — use JavaScript click as fallback
                        ((IJavaScriptExecutor)Driver).ExecuteScript(
                            "document.getElementById('CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll')?.click() || " +
                            "document.getElementById('CybotCookiebotDialogBodyButtonAccept')?.click();"
                        );
                    }
                    Thread.Sleep(500);
                }
            }
            catch (WebDriverTimeoutException)
            {
                // Cookie banner not present — continue
            }
        }

        /// <summary>
        /// Checks if a specific element is displayed on the page.
        /// Returns false if the element is not found (no exception thrown).
        /// </summary>
        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets all elements matching the locator.
        /// </summary>
        public IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator);
        }

        /// <summary>
        /// Scrolls to an element to ensure it's in the viewport before interaction.
        /// </summary>
        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
            Thread.Sleep(300);
        }
    }
}
