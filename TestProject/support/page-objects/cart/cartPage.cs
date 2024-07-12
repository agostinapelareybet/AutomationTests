using OpenQA.Selenium;


namespace SeleniumTests.PageObjects
{
    public class CartPage
    {
        private readonly IWebDriver driver;

        public CartPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public IWebElement CartRemoveButton => driver.FindElement(By.CssSelector(".cart_button"));
        public IWebElement YourCartTitle => driver.FindElement(By.CssSelector(".subheader"));
    }
}
