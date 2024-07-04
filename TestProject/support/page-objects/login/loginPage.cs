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

        public IWebElement txtUsername => driver.FindElement(By.CssSelector("[data-test='username']"));

        public IWebElement txtPassword => driver.FindElement(By.CssSelector("[data-test='password']"));

        public IWebElement btnLogin => driver.FindElement(By.CssSelector(".btn_action"));
    }
}