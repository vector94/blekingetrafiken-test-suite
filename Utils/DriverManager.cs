using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BlekingetrafikenTests.Utils
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddExcludedArgument("enable-automation");

            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            return driver;
        }
    }
}
