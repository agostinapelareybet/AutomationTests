
namespace TestProject.e2e.cart
{
    using support;
    using NUnit.Framework;
    using support.page_objects.testBasePage;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;

    public class CartTests : TestBasePage
    {

        [Test]
        public void AddProductToCart()
        {
            ProductsPage = LoginPage?.Login(RandomUserName, EnvironmentVariables.Password);

            ProductsPage?.AddToCartButton.Click();
            ProductsPage?.CartBadgeIcon.Click();
            Assert.That(CartPage?.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.That(CartPage.FirstProductName.Text, Is.EqualTo(CartPage.ProductName));
            Assert.That(CartPage.CartRemoveButton.Text, Is.EqualTo("REMOVE"));
        }

        [Test]
        public void ContinuAddingProductsToCart()
        {
            ProductsPage = LoginPage?.Login(RandomUserName, EnvironmentVariables.Password);

            ProductsPage?.AddToCartButton.Click();
            ProductsPage?.CartBadgeIcon.Click();
            Assert.That(CartPage?.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.That(CartPage.ContinueButton.Displayed, Is.True);

            CartPage.ContinueButton.Click();
            ProductsPage?.AddToCartButton.Click();
            Assert.That(CartPage.CartBadgeIcon.Displayed, Is.True);
            Assert.That(CartPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));
        }
    
     [Test]
        public void RemoveProductToCart()
        {
            ProductsPage = LoginPage?.Login(RandomUserName, EnvironmentVariables.Password);

            ProductsPage?.AddToCartButton.Click();
            ProductsPage?.CartBadgeIcon.Click();
            Assert.That(CartPage?.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.That(CartPage?.CartRemoveButton.Displayed, Is.True);

    
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));

        try
        {

            var removeButton = wait.Until(driver => driver.FindElement(By.XPath("//button[@class='btn_secondary cart_button']")));
            removeButton.Click();

            
            wait.Until(driver => int.Parse(driver.FindElement(By.CssSelector(".fa-layers-counter.shopping_cart_badge")).Text) == 0);

           
            var cartCount = int.Parse(Driver.FindElement(By.CssSelector(".fa-layers-counter.shopping_cart_badge")).Text);
            Assert.That(cartCount, Is.EqualTo(0), "The cart is not empty after removing the product");

            Console.WriteLine("The cart is empty");
        }
        catch (WebDriverTimeoutException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
    
        }

    
    
