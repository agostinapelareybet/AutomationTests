using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace inventoryTests
{
    [TestFixture]
    public class InventoryTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private CommonsPage commonsPage;
        private ProductsPage productsPage;
        private InventoryPage inventoryPage;

        private string randomUserName;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string envFilePath = Path.Combine(projectDir, ".env");
            Env.Load(envFilePath);

            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            commonsPage = new CommonsPage(driver);
            productsPage = new ProductsPage(driver);
            inventoryPage = new InventoryPage(driver, commonsPage);
            randomUserName = EnvironmentVariables.GetValidUserName();

        }

        [Test, Order(1), Category("FIXME BUG")]
        public void AddProductToCart()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);

            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));

            inventoryPage = inventoryPage.AddProductToCart();
            Assert.That(inventoryPage.AppHeader.Displayed, Is.True);
            Assert.That(commonsPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE")); // Sometimes fails because the text is not changing after clicking the button.
            Assert.That(commonsPage.CartBadgeIcon.Displayed, Is.True);
        }

        [Test, Order(2)]
        public void ProductDetails()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));

            commonsPage.FirstProductName.Click();
            Assert.That(inventoryPage.AppHeader.Displayed, Is.True);
            Assert.That(inventoryPage.ProductDetails.Text, Is.EqualTo(ProductNames.productName));
        }

        [Test, Order(3)]
        public void BackButtonRedirection()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
            commonsPage.FirstProductName.Click();

            inventoryPage.BackButton.Click();
            Assert.That(driver.Url, Is.EqualTo(EnvironmentVariables.ProductsUrl));
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));

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