
namespace TestProject.e2e.cart
{
    using support;
    using NUnit.Framework;
    using support.page_objects.testBasePage;

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
        public void ContinueShopping()
        {
            ProductsPage = LoginPage?.Login(RandomUserName, EnvironmentVariables.Password);

            ProductsPage?.AddToCartButton.Click();
            ProductsPage?.CartBadgeIcon.Click();
            Assert.That(CartPage?.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.NotNull(CartPage.ContinueButton);

            CartPage.ContinueButton.Click();
            ProductsPage?.AddToCartButton.Click();
            Assert.That(CartPage.CartBadgeIcon.Displayed, Is.True);
            Assert.That(CartPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));
        }
    }
}