using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;

        public ProductsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement ProductsTitle => driver.FindElement(By.CssSelector(".product_label"));
    }
}