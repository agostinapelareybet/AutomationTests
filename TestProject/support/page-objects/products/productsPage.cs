namespace TestProject.support.page_objects.products
{
    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using pageBase;
    public class ProductsPage(IWebDriver webDriver) : PageBase(webDriver)
    {
        private readonly IWebDriver _driver = webDriver;
        private object driver;

        public IWebElement AppHeader => _driver.FindElement(By.CssSelector(".app_logo"));
        public IWebElement ProductsTitle => _driver.FindElement(By.CssSelector(".product_label"));
        public IWebElement SortDropdown => _driver.FindElement(By.CssSelector(".product_sort_container"));
        public IWebElement AddToCartButton => _driver.FindElement(By.CssSelector("button.btn_primary.btn_inventory:first-of-type"));

        public IWebElement HighToLowOption => _driver.FindElement(By.XPath("//option[@value='hilo']"));
         public IWebElement InventoryPrice => _driver.FindElement(By.CssSelector(".inventory_item_price"));

        public ProductsPage NavigateProducts(string baseurl)
        {
            _driver.Navigate().GoToUrl(baseurl);
            Assert.That(ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
            Assert.That(AppHeader.Displayed, Is.True);

            return new ProductsPage(_driver);
        }


     public IWebElement SortDropdownProducts
    {
        get
        {
            return SortDropdown; 
        }
    }

  
    public IWebElement HighToLowOptionProducts
    {
        get
        {
            return HighToLowOption;
        }
    }

   
    public IList<IWebElement> GetProductPrices()
    {
        
        return (IList<IWebElement>)_driver.FindElements(By.CssSelector(".inventory_item_price"));
    }
}

}