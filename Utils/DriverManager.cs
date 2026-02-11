using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BlekingetrafikenTests.Utils
{
    /// <summary>
    /// Manages WebDriver lifecycle: creation, configuration, and disposal.
    /// Centralizes browser setup so all tests use a consistent configuration.
    /// Uses Selenium 4's built-in Selenium Manager to auto-resolve the correct
    /// ChromeDriver version matching the installed Chrome browser.
    /// </summary>
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            // Suppress "Chrome is being controlled by automated test software" bar
            options.AddExcludedArgument("enable-automation");

            // Selenium 4.6+ includes Selenium Manager which automatically
            // downloads and uses the correct ChromeDriver for the installed Chrome version.
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            return driver;
        }
    }
}
