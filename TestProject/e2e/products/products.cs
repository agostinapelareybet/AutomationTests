
namespace TestProject.e2e.products
{
    using support;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using support.page_objects.testBasePage;
    using OpenQA.Selenium.Support.UI;

    public class ProductsTests : TestBasePage
    {
    
        [Test]
        public void AddProductToCart()
        {
            ProductsPage?.NavigateProducts(EnvironmentVariables.ProductsUrl);
            ProductsPage?.AddToCartButton.Click();
            Assert.That(ProductsPage?.CartBadgeIcon.Displayed, Is.True);
            Assert.That(ProductsPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));
        }

        [Test]
        public void SortProductsHighToLow()
        {
            ProductsPage?.NavigateProducts(EnvironmentVariables.ProductsUrl);
            ProductsPage?.SortDropdown.Click();
            ProductsPage?.HighToLowOption.Click();
        
            IList<IWebElement>? productPricesElements = ProductsPage?.GetProductPrices();
            List<decimal> prices = productPricesElements.Select(p => decimal.Parse(p.Text.Replace("$", "").Replace(",", ""))).ToList();

            List<decimal> sortedPrices = new(prices);
            sortedPrices.Sort((a, b) => b.CompareTo(a)); 


            Assert.That(prices, Is.EqualTo(sortedPrices));
        }
    }    
}