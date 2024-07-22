
namespace TestProject.support.page_objects.inventory
{
    using OpenQA.Selenium;
    using pageBase;

    public class InventoryPage(IWebDriver webDriver) : PageBase(webDriver)
    {
        public IWebElement BackButton => _driver.FindElement(By.CssSelector(".inventory_details_back_button"));
        public IWebElement ProductDetails => _driver.FindElement(By.CssSelector(".inventory_details_name"));
        public IWebElement AppHeader => _driver.FindElement(By.CssSelector("[id=header_container]"));
        public IWebElement AddCartButton => _driver.FindElement(By.CssSelector(".btn_primary"));
        private readonly IWebDriver _driver = webDriver;

        public InventoryPage AddProductToCart()
        {
            FirstProductName.Click();
            AddCartButton.Click();

            return this;
        }
    }
}
