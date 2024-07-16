using AngleSharp.Css.Parser;
using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class CommonsPage
    {
        private readonly IWebDriver driver;
        public CommonsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement FirstProductName => driver.FindElement(By.XPath("//div[@class='inventory_item_name' and text()='Sauce Labs Backpack']"));
        public IWebElement CartBadgeIcon => driver.FindElement(By.CssSelector(".fa-layers-counter.shopping_cart_badge"));
        public IWebElement RemoveButton => driver.FindElement(By.CssSelector(".btn_secondary.btn_inventory"));

        public IWebElement ContinueButton => driver.FindElement(By.CssSelector("a.btn_secondary[href='./inventory.html']"));

    }
}