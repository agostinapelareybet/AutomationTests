using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class ProductPage
    {
        private readonly IWebDriver driver;

        public ProductPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //public IWebElement searchbox => driver.FindElement(By.CssSelector("[product_sort_container']"));

        //public IWebElement txtPassword => driver.FindElement(By.CssSelector("[data-test='password']"));

        //public IWebElement btnLogin => driver.FindElement(By.CssSelector(".btn_action"));
    }
}