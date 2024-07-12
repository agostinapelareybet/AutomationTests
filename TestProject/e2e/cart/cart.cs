using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace inventoryTests
{
    [TestFixture]
    public class CartTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private CommonsPage commonsPage;
        private ProductsPage productsPage;
        private CartPage cartPage;

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
            cartPage = new CartPage(driver);
            loginPage = new LoginPage(driver);
            commonsPage = new CommonsPage(driver);
            productsPage = new ProductsPage(driver);
            randomUserName = EnvironmentVariables.GetValidUserName();
        }

        [Test, Order(1)]
        public void AddProductToCart()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            productsPage.AddToCartButton.Click();

            commonsPage.CartBadgeIcon.Click();
            Assert.That(cartPage.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.That(commonsPage.FirstProductName.Text, Is.EqualTo(ProductNames.productName));
            Assert.That(cartPage.CartRemoveButton.Text, Is.EqualTo("REMOVE"));

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