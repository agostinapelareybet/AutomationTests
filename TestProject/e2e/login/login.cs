using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumTests.PageObjects;
using DotNetEnv;


namespace logInTests
{
	[TestFixture]
	public class GoogleTests
	{
		private IWebDriver driver;
		private LoginPage loginPage;
        private ProductsPage productsPage;

        public GoogleTests()
		{
			string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string envFilePath = Path.Combine(projectDir, ".env");
            Env.Load(envFilePath);
        }


		[SetUp]
		public void SetUp()
		{
			new DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			loginPage = new LoginPage(driver);
        }

		[Test]
		public void LoginWithValidCredentials()
		{            
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
			productsPage = loginPage.Login(EnvironmentVariables.UserName, EnvironmentVariables.Password ?? "");
            Assert.That(productsPage.txaProductsTitle.Text, Is.EqualTo(PageTitles.Products));
		}

        [TearDown]
		public void TearDown()
		{
			if (driver != null)
			{
				driver.Quit();
				driver.Dispose();
			}
		}
	}
}