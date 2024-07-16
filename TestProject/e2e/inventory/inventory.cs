using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace inventoryTests
{
    using TestProject.support.page_objects.commons;
    using TestProject.support.page_objects.products;

    [TestFixture]
    public class InventoryTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private PageBase _pageBase;
        private ProductsPage productsPage;
        private InventoryPage _inventoryPage;

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
            _pageBase = new PageBase(driver);
            productsPage = new ProductsPage(driver);
            _inventoryPage = new InventoryPage(driver, _pageBase);
            randomUserName = EnvironmentVariables.GetValidUserName();

        }

        [Test, Order(1), Category("FIXME BUG")]
        public void AddProductToCart()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);

            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));

            _inventoryPage = _inventoryPage.AddProductToCart();
            Assert.That(_inventoryPage.AppHeader.Displayed, Is.True);
            Assert.That(_pageBase.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE")); // Sometimes fails because the text is not changing after clicking the button.
            Assert.That(_pageBase.CartBadgeIcon.Displayed, Is.True);
        }

        [Test, Order(2)]
        public void ProductDetails()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));

            _pageBase.FirstProductName.Click();
            Assert.That(_inventoryPage.AppHeader.Displayed, Is.True);
            Assert.That(_inventoryPage.ProductDetails.Text, Is.EqualTo(ProductNames.productName));
        }

        [Test, Order(3)]
        public void BackButtonRedirection()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
            _pageBase.FirstProductName.Click();

            _inventoryPage.BackButton.Click();
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