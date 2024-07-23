
namespace TestProject.e2e.inventory
{
    using support;
    using OpenQA.Selenium;
    using support.page_objects.testBasePage;
    using OpenQA.Selenium.Support.UI;

    public class InventoryTests : TestBasePage
    {

        [Test]
        public void AddProductToCart()
        {
            LoginPage?.Login(RandomUserName, EnvironmentVariables.Password);
            Assert.That(ProductsPage?.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));

            InventoryPage?.AddProductToCart();
            Assert.That(InventoryPage?.AppHeader.Displayed, Is.True);
            Assert.That(InventoryPage.CartBadgeIcon.Displayed, Is.True);
            Assert.That(InventoryPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));

            InventoryPage.RemoveButton.Click();
            var removeButtons = Driver.FindElements(By.CssSelector(".btn_secondary.btn_inventory"));
            Assert.That(removeButtons.Count, Is.EqualTo(0));
        }

        [Test]
        public void ProductDetails()
        {
            Driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
            Assert.That(ProductsPage?.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            var inventoryFirstProductName = wait.Until(driver => driver.FindElement(By.XPath("//div[@class='inventory_item_name' and normalize-space(text())='Sauce Labs Backpack']")));

            InventoryPage?.FirstProductName.Click();
            Assert.That(InventoryPage?.AppHeader.Displayed, Is.True);
            Assert.That(InventoryPage.ProductDetails.Text, Is.EqualTo(ProductsPage.ProductName));
        }

        [Test]
        public void BackButtonRedirection()
        {
            Driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
            InventoryPage?.FirstProductName.Click();

            InventoryPage?.BackButton.Click();
            Assert.That(Driver.Url, Is.EqualTo(EnvironmentVariables.ProductsUrl));
            Assert.That(ProductsPage?.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));

        }
    }
}
