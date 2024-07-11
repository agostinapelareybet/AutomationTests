using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace productsTests
{
    [TestFixture]
    public class ProductsTests
    {
        private IWebDriver driver;
        private ProductsPage productsPage;
        string productsUrl = "https://www.saucedemo.com/v1/inventory.html";

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
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/inventory.html");
        }

        [Test, Order(1)]
        public void AddProductToCart()
        {
            productsPage.NavigateProducts(productsUrl);
            productsPage.AddToCartButton.Click();
            Assert.That(productsPage.CartBadgeIcon.Displayed, Is.True);
            Assert.That(productsPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));

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