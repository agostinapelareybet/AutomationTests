namespace TestProject.support.page_objects.pageBase
{
    using OpenQA.Selenium;

    public abstract class PageBase(IWebDriver webDriver)
    {
        public string ProductName = "Sauce Labs Backpack";
        public IWebElement FirstProductName => webDriver.FindElement(By.XPath("//div[@class='inventory_item_name' and normalize-space(text())='Sauce Labs Backpack']"));
        public IWebElement ContinueButton => webDriver.FindElement(By.CssSelector("a.btn_secondary[href='./inventory.html']"));
        public IWebElement CartBadgeIcon => webDriver.FindElement(By.CssSelector(".fa-layers-counter.shopping_cart_badge"));
        public IWebElement RemoveButton => webDriver.FindElement(By.CssSelector(".btn_secondary.btn_inventory"));
    }
}