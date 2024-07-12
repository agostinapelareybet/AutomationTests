using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class ProductsPage
    {
        public IWebElement ProductsTitle => driver.FindElement(By.CssSelector(".product_label"));
        public IWebElement CartBadgeIcon => driver.FindElement(By.CssSelector(".fa-layers-counter.shopping_cart_badge"));
        public IWebElement AddToCartButton => driver.FindElement(By.CssSelector("button.btn_primary.btn_inventory:first-of-type"));
        public IWebElement RemoveButton => driver.FindElement(By.CssSelector(".btn_secondary.btn_inventory"));
        public IWebElement AppHeader => driver.FindElement(By.CssSelector(".app_logo"));
        public IWebElement SortDropdown => driver.FindElement(By.CssSelector(".product_sort_container"));

        private readonly IWebDriver driver;
        public ProductsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public ProductsPage NavigateProducts(string baseurl)
        {
            driver.Navigate().GoToUrl(baseurl);
            Assert.That(ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
            Assert.That(AppHeader.Displayed, Is.True);

            return new ProductsPage(driver);
        }
    }
}