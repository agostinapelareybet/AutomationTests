namespace TestProject.support.page_objects.cart
{
    using OpenQA.Selenium;

    public class CartPage(IWebDriver webDriver)
    {
        public IWebElement CartRemoveButton => webDriver.FindElement(By.CssSelector(".cart_button"));
        public IWebElement YourCartTitle => webDriver.FindElement(By.CssSelector(".subheader"));
    }
}
