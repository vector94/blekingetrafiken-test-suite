using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class ZonesPage : BasePage
    {
        public ZonesPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.ZonesUrl);
            AcceptCookies();
        }

        public bool HasZoneContent()
        {
            var pageSource = Driver.PageSource;
            return pageSource.Contains("zon") || pageSource.Contains("Zon");
        }

        public bool HasSubSections()
        {
            var headings = Driver.FindElements(By.CssSelector("h2, h3"));
            return headings.Count > 0;
        }

        public bool HasDownloadableContent()
        {
            var pdfLinks = Driver.FindElements(By.CssSelector("a[href*='.pdf'], a[href*='karta']"));
            var zoneImages = Driver.FindElements(By.CssSelector("img[src*='zon'], img[alt*='zon'], img[src*='karta'], img[alt*='karta']"));
            return pdfLinks.Count > 0 || zoneImages.Count > 0;
        }

        public bool PageContainsText(string text)
        {
            return Driver.PageSource.Contains(text);
        }
    }
}
