using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;
using OpenQA.Selenium.DevTools.V124.Browser;

namespace productsTests
{
    [TestFixture]
    public class ProductsTests
    {
        private IWebDriver driver;
        private CommonsPage commonsPage;
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
            commonsPage = new CommonsPage(driver);
            productsPage = new ProductsPage(driver);
            driver.Navigate().GoToUrl(EnvironmentVariables.ProductsUrl);
        }

        [Test, Order(1)]
        public void AddProductToCart()
        {
            productsPage.AddToCartButton.Click();
            Assert.That(commonsPage.CartBadgeIcon.Displayed, Is.True);
            Assert.That(commonsPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));

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