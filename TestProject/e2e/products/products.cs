
namespace TestProject.e2e.products
{
    using support;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using support.page_objects.testBasePage;
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
            IWebElement highToLowOption = Driver.FindElement(By.XPath("//option[@value='hilo']"));
            highToLowOption.Click();
        }
    }
}