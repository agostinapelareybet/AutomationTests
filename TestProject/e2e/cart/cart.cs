
namespace TestProject.e2e.cart
{
    using support;
    using NUnit.Framework;
    using support.page_objects.testBasePage;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using System;
    using System.Security.Cryptography;

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
    
     [Test,Category("Only")]
        public void RemoveProductToCart()
        {
            ProductsPage = LoginPage?.Login(RandomUserName, EnvironmentVariables.Password);

            ProductsPage?.AddToCartButton.Click();
            ProductsPage?.CartBadgeIcon.Click();
            Assert.That(CartPage?.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.That(CartPage?.CartRemoveButton.Displayed, Is.True);
            CartPage.CartRemoveButton.Click();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElements(By.XPath("//button[@class='btn_secondary cart_button']")).Count==0);
            IList<IWebElement> lt = Driver.FindElements(By.XPath("//button[@class='btn_secondary cart_button']"));
            Assert.That(lt.Count, Is.EqualTo(0));
     
     }
             [Test]
        public void ContinueAddingProductsToCart()
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


        }}

    
    
