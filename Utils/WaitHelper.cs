using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BlekingetrafikenTests.Utils
{
    /// <summary>
    /// Provides explicit wait utilities to avoid brittle Thread.Sleep calls.
    /// All waits use WebDriverWait with configurable timeouts.
    /// </summary>
    public static class WaitHelper
    {
        private const int DefaultTimeoutSeconds = 15;

        public static IWebElement WaitForElement(IWebDriver driver, By locator, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForClickable(IWebDriver driver, By locator, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool WaitForUrl(IWebDriver driver, string urlContains, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d => d.Url.Contains(urlContains));
        }

        public static bool WaitForTitle(IWebDriver driver, string titleContains, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.TitleContains(titleContains));
        }

        public static bool WaitForElementToDisappear(IWebDriver driver, By locator, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
