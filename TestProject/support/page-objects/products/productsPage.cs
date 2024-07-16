namespace TestProject.support.page_objects.products
{
    using OpenQA.Selenium;
    using commons;

    public class ProductsPage(IWebDriver webDriver) : PageBase(webDriver)
    {
        private readonly IWebDriver _driver = webDriver;


        public IWebElement AppHeader => _driver.FindElement(By.CssSelector(".app_logo"));
        public IWebElement ProductsTitle => _driver.FindElement(By.CssSelector(".product_label"));
        public IWebElement SortDropdown => _driver.FindElement(By.CssSelector(".product_sort_container"));
        public IWebElement AddToCartButton => _driver.FindElement(By.CssSelector("button.btn_primary.btn_inventory:first-of-type"));

        public ProductsPage NavigateProducts(string baseurl)
        {
            _driver.Navigate().GoToUrl(baseurl);
            Assert.That(ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
            Assert.That(AppHeader.Displayed, Is.True);

            return new ProductsPage(_driver);
        }
    }
}