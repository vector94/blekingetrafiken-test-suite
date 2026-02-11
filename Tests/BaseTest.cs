using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Tests
{
    /// <summary>
    /// Base test class providing Setup and Teardown for all test fixtures.
    /// Every test class inherits from this to ensure consistent browser
    /// lifecycle management (create before each test, quit after each test).
    /// </summary>
    public abstract class BaseTest
    {
        protected IWebDriver Driver = null!;

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.CreateDriver();
        }

        [TearDown]
        public void Teardown()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
