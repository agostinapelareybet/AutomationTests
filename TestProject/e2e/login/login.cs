using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;

namespace logInTests
{
    [TestFixture]
    public class LogInTests
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
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            randomUserName = EnvironmentVariables.GetValidUserName();            
        }

        [Test, Order(1)]
        public void LoginWithValidCredentials()
        {
            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
        }

        [Test, Order(2)]
        public void loginwithinvalidusername()
        {
            productsPage = loginPage.Login("invalid", EnvironmentVariables.Password);
            Assert.That(loginPage.ErrorMesage.Text, Is.EqualTo(ErrorMessages.LoginErrorMessage));
        }

        [Test, Order(3)]
        public void LoginWithoutUsername()
        {
            productsPage = loginPage.Login("", EnvironmentVariables.Password);
            Assert.That(loginPage.ErrorMesage.Text, Is.EqualTo(ErrorMessages.UsernameRequiredMessage));
        }

        [Test, Order(4)]
        public void LoginWithoutPassword()
        {
            productsPage = loginPage.Login(randomUserName, "");
            Assert.That(loginPage.ErrorMesage.Text, Is.EqualTo(ErrorMessages.PasswordRequiredMessage));
        }

        [Test, Order(5)]
        public void LoginWithoutCredentials()
        {
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