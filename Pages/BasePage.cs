using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string GetTitle() => Driver.Title;

        public string GetCurrentUrl() => Driver.Url;

        public string GetMainHeading()
        {
            var heading = WaitHelper.WaitForElement(Driver, By.TagName("h1"));
            return heading.Text.Trim();
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

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
            }
        }

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

        public IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator);
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
            Thread.Sleep(300);
        }
    }
}
