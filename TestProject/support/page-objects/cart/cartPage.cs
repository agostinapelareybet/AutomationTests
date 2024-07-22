namespace TestProject.support.page_objects.cart
{
    using OpenQA.Selenium;
    using pageBase;

    public class CartPage(IWebDriver webDriver) : PageBase(webDriver)
    {
        private readonly IWebDriver _driver = webDriver;
        public IWebElement CartRemoveButton => webDriver.FindElement(By.CssSelector(".cart_button"));
        public IWebElement YourCartTitle => webDriver.FindElement(By.CssSelector(".subheader"));
    }
}
