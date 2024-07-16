using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace productsTests
{
    using TestProject.support.page_objects.cart;
    using TestProject.support.page_objects.commons;
    using TestProject.support.page_objects.products;

    [TestFixture]
    public class ProductsTests
    {
        private IWebDriver driver;
        private PageBase _pageBase;
        private ProductsPage productsPage;
         private CartPage cartPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string envFilePath = Path.Combine(projectDir, ".env");
            Env.Load(envFilePath);

            new DriverManager().SetUpDriver(new ChromeConfig());
            var chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(chromeOptions);
        }

        [SetUp]
        public void SetUp()
        {
            productsPage = new ProductsPage(driver);
            driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
        }

        [Test, Order(1)]
        public void AddProductToCart()
        {
            productsPage.AddToCartButton.Click();
            Assert.That(productsPage.CartBadgeIcon.Displayed, Is.True);
            Assert.That(productsPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));

        }

        [Test, Order(2)]
        public void SortProductsHighToLow()
        {
            productsPage.SortDropdown.Click();
            IWebElement highToLowOption = driver.FindElement(By.XPath("//option[@value='hilo']"));
            highToLowOption.Click();
        }



        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}