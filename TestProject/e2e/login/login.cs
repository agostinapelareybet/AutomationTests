using NUnit.Framework;
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
            productsPage = new ProductsPage(driver);
        }

		[Test]
		public void LoginWithValidCredentials()
		{            
            driver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);
			loginPage.txtUsername.Click();
			loginPage.txtUsername.Clear();
			loginPage.txtUsername.SendKeys(EnvironmentVariables.UserName);

			loginPage.txtPassword.Click();
			loginPage.txtPassword.Clear();
			loginPage.txtPassword.SendKeys(EnvironmentVariables.Password);

			loginPage.btnLogin.Click();
			Assert.AreEqual(PageTitles.Products, productsPage.txaProductsTitle.Text);
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