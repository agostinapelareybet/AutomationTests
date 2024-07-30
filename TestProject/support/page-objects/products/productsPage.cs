using OpenQA.Selenium;
using TestProject.support.page_objects.pageBase;

namespace TestProject.support.page_objects.products;

public class ProductsPage(IWebDriver webDriver) : PageBase(webDriver)
{
    private readonly IWebDriver _driver = webDriver;
    private object driver;

    public IWebElement AppHeader => _driver.FindElement(By.CssSelector(".app_logo"));
    public IWebElement ProductsTitle => _driver.FindElement(By.CssSelector(".product_label"));
    public IWebElement SortDropdown => _driver.FindElement(By.CssSelector(".product_sort_container"));
    public IWebElement AddToCartButton => _driver.FindElement(By.CssSelector("button.btn_primary.btn_inventory:first-of-type"));
    public IWebElement HighToLowOption => _driver.FindElement(By.XPath("//option[@value='hilo']"));
    public IWebElement LowToHighOption=> _driver.FindElement(By.XPath("//option[@value='lohi']"));
    public IWebElement LowToHighName=> _driver.FindElement(By.XPath("//option[@value='az']"));
    public IWebElement HighToLowName=> _driver.FindElement(By.XPath("//option[@value='za']"));

    public ProductsPage NavigateProducts(string baseurl)
    {
        _driver.Navigate().GoToUrl(baseurl);
        Assert.That(ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
        Assert.That(AppHeader.Displayed, Is.True);

        return new ProductsPage(_driver);
    }

public IList<IWebElement> GetProductPrices()
{
    
    return _driver.FindElements(By.CssSelector(".inventory_item_price"));
}

public IList<IWebElement> GetProductNames()
{
    
    return _driver.FindElements(By.CssSelector(".inventory_item_name"));
}


}