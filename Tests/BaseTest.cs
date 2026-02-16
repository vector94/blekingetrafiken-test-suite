using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Tests
{
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
