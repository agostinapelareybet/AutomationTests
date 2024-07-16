namespace TestProject.e2e.login
{
    using DotNetEnv;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SeleniumTests.PageObjects;
    using support.page_objects.products;
    using WebDriverManager;
    using WebDriverManager.DriverConfigs.Impl;

    [TestFixture]
    public class LogInTests
    {
        private IWebDriver _driver;
        private LoginPage loginPage;
        private ProductsPage productsPage;
        private string randomUserName;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            if (projectDir != null)
            {
                var envFilePath = Path.Combine(projectDir, ".env");
                Env.Load(envFilePath);
            }

            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(_driver);
            productsPage = new ProductsPage(_driver);
            _driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
            randomUserName = EnvironmentVariables.GetValidUserName();            
        }

        [Test, Order(1)]
        public void LoginWithValidCredentials()
        {
            productsPage = loginPage.Login(randomUserName, EnvironmentVariables.Password);
            Assert.That(productsPage.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
        }

        [Test, Order(2)]
        public void LoginWithInvalidUsername()
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
            _driver.Quit();
            _driver.Dispose();
        }
    }
}