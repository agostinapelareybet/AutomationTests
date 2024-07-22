namespace TestProject.support.page_objects.login
{
    using OpenQA.Selenium;
    using products;

    public class LoginPage(IWebDriver webDriver)
    {
        private IWebElement UsernameInput => webDriver.FindElement(By.CssSelector("[data-test='username']"));
        public IWebElement ErrorMessage => webDriver.FindElement(By.CssSelector("[data-test=error]"));
        public IWebElement PasswordInput => webDriver.FindElement(By.CssSelector("[data-test='password']"));
        public IWebElement LoginButton => webDriver.FindElement(By.CssSelector(".btn_action"));

        public ProductsPage Login(string? username, string password)
        {
            webDriver.Navigate().GoToUrl(EnvironmentVariables.BaseUrl);

            UsernameInput.Click();
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);

            PasswordInput.Click();
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButton.Click();
            return new ProductsPage(webDriver);
        }
    }
}