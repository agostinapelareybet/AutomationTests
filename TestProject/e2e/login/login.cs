using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace logInTests
{
    [TestFixture]
    public class SauceDemoTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductsPage productsPage;
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
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            loginPage = new LoginPage(driver);
            randomUserName = EnvironmentVariables.GetValidUserName();
        }

        [Test, Order(1)]
        public void LoginWithValidCredentials()
        {

            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
        }

        [Test, Order(2)]
        public void LoginWithInvalidUsername()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login("Invalid", EnvironmentVariables.Password);
            Assert.That(loginPage.ErrorMesage.Text, Is.EqualTo(ErrorMessages.LoginErrorMessage));
        }

        [Test, Order(3)]
        public void LoginWithoutUsername()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login("", EnvironmentVariables.Password);
            Assert.That(loginPage.ErrorMesage.Text, Is.EqualTo(ErrorMessages.UsernameRequiredMessage));
        }

        [Test, Order(4)]
        public void LoginWithoutPassword()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login(randomUserName, "");
            Assert.That(loginPage.ErrorMesage.Text, Is.EqualTo(ErrorMessages.PasswordRequiredMessage));
        }

        [Test, Order(5)]
        public void LoginWithoutCredentials()
        {
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            productsPage = loginPage.Login("", "");
            Assert.That(loginPage.ErrorMesage.Text, Is.EqualTo(ErrorMessages.UsernameRequiredMessage));
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