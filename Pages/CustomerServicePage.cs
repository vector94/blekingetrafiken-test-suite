using OpenQA.Selenium;
using BlekingetrafikenTests.Utils;

namespace BlekingetrafikenTests.Pages
{
    public class CustomerServicePage : BasePage
    {
        private readonly By _faqLink = By.CssSelector("a[href*='/kundservice/fragor-och-svar/']");
        private readonly By _delayCompensationLink = By.CssSelector("a[href*='/kundservice/forseningsersattning/']");
        private readonly By _lostAndFoundLink = By.CssSelector("a[href*='/kundservice/hittegods/']");
        private readonly By _contactLink = By.CssSelector("a[href*='/kundservice/kontakta-oss/']");

        public CustomerServicePage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            NavigateTo(TestConfig.CustomerServiceUrl);
            AcceptCookies();
        }

        public bool HasFaqLink() => IsElementDisplayed(_faqLink);

        public bool HasDelayCompensationLink() => IsElementDisplayed(_delayCompensationLink);

        public bool HasLostAndFoundLink() => IsElementDisplayed(_lostAndFoundLink);

        public bool HasContactLink() => IsElementDisplayed(_contactLink);

        public bool HasAllServiceLinks()
        {
            return HasFaqLink()
                && HasDelayCompensationLink()
                && HasLostAndFoundLink()
                && HasContactLink();
        }

        public void NavigateToFaq()
        {
            var link = WaitHelper.WaitForClickable(Driver, _faqLink);
            ScrollToElement(link);
            link.Click();
        }
    }
}
