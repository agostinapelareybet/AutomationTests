namespace TestProject.support.page_objects.commons
{
    using OpenQA.Selenium;

    public abstract class PageBase(IWebDriver webDriver)
    {
        public IWebElement FirstProductName => webDriver.FindElement(By.XPath("//div[@class='inventory_item_name' and text()='Sauce Labs Backpack']"));
        public IWebElement CartBadgeIcon => webDriver.FindElement(By.CssSelector(".fa-layers-counter.shopping_cart_badge"));
        public IWebElement RemoveButton => webDriver.FindElement(By.CssSelector(".btn_secondary.btn_inventory"));
        public IWebElement ContinueButton => webDriver.FindElement(By.CssSelector("a.btn_secondary[href='./inventory.html']"));
    }
}