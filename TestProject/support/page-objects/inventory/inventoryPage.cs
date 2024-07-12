using OpenQA.Selenium;


namespace SeleniumTests.PageObjects
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;
        private readonly CommonsPage commonsPage;

        public InventoryPage(IWebDriver webDriver, CommonsPage commonsPage)
        {
            driver = webDriver;
            this.commonsPage = commonsPage;
        }

        public IWebElement BackButton => driver.FindElement(By.CssSelector(".inventory_details_back_button"));
        public IWebElement ProductDetails => driver.FindElement(By.CssSelector(".inventory_details_name"));
        public IWebElement AppHeader => driver.FindElement(By.CssSelector("[id=header_container]"));
        public IWebElement AddCartButton => driver.FindElement(By.CssSelector(".btn_primary"));

        public InventoryPage AddProductToCart()
        {
            commonsPage.FirstProductName.Click();
            AddCartButton.Click();

            return this;
        }
    }
}
