
namespace TestProject.support.page_objects.testBasePage
{
    using cart;
    using login;
    using products;
    using DotNetEnv;
    using System.IO;
    using inventory;
    using OpenQA.Selenium;
    using NUnit.Framework;
    using WebDriverManager;
    using OpenQA.Selenium.Chrome;
    using WebDriverManager.DriverConfigs.Impl;


    public class TestBasePage
    {
        public CartPage? CartPage;
        public LoginPage? LoginPage;
        public ProductsPage? ProductsPage;
        public InventoryPage? InventoryPage;
        public string? RandomUserName;

        public IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void OneTimeTestBase()
        {
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            if (projectDir != null)
            {
                var envFilePath = Path.Combine(projectDir, ".env");
                Env.Load(envFilePath);
            }
            var options = new ChromeOptions();
            options.AddArgument("--headless"); 
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920x1080");

            var driver = new ChromeDriver(options);

            var options = new ChromeOptions();
            options.AddArgument("--headless"); 
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }

        [SetUp]
        public void SetUpTestBase()
        {
            CartPage = new CartPage(Driver);
            LoginPage = new LoginPage(Driver);
            ProductsPage = new ProductsPage(Driver);
            InventoryPage = new InventoryPage(Driver);
            RandomUserName = EnvironmentVariables.GetValidUserName();
        }

        [OneTimeTearDown]
        public void OneTimeTearDownBase()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}