using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace inventoryTests
{
    using TestProject.support.page_objects.cart;
    using TestProject.support.page_objects.commons;
    using TestProject.support.page_objects.products;

    [TestFixture]
    public class CartTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private PageBase _pageBase;
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
            _pageBase = new PageBase(driver);
            productsPage = new ProductsPage(driver);
            randomUserName = EnvironmentVariables.GetValidUserName();
        }

        [Test, Order(1)]
        public void AddProductToCart()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            productsPage.AddToCartButton.Click();

            _pageBase.CartBadgeIcon.Click();
            Assert.That(cartPage.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.That(_pageBase.FirstProductName.Text, Is.EqualTo(ProductNames.productName));
            Assert.That(cartPage.CartRemoveButton.Text, Is.EqualTo("REMOVE"));

        }


        [Test, Order(2)]
        public void ContinueShopping()
     {      
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            productsPage.AddToCartButton.Click();
            _pageBase.CartBadgeIcon.Click();
            Assert.That(cartPage.YourCartTitle.Text, Is.EqualTo(PageTitles.YourCart));
            Assert.NotNull(_pageBase.ContinueButton);
            _pageBase.ContinueButton.Click();
            productsPage.AddToCartButton.Click();
            Assert.That(_pageBase.CartBadgeIcon.Displayed, Is.True);
            Assert.That(_pageBase.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));
            
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