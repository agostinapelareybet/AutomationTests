using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement UsernameInput => driver.FindElement(By.CssSelector("[data-test='username']"));

        public IWebElement PasswordInput => driver.FindElement(By.CssSelector("[data-test='password']"));

        public IWebElement LoginButton => driver.FindElement(By.CssSelector(".btn_action"));

        public IWebElement ErrorMesage => driver.FindElement(By.CssSelector("[data-test=error]"));

        public ProductsPage Login(string username, string password)
        {
            UsernameInput.Click();
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);

            PasswordInput.Click();
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButton.Click();
            return new ProductsPage(driver);
        }
    }
}