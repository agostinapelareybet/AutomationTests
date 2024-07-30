
namespace TestProject.e2e.products
{
    using support;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using support.page_objects.testBasePage;
    using OpenQA.Selenium.Support.UI;

    public class ProductsTests : TestBasePage
    {
    
        [Test]
        public void AddProductToCart()
        {
            ProductsPage?.NavigateProducts(EnvironmentVariables.ProductsUrl);
            ProductsPage?.AddToCartButton.Click();
            Assert.That(ProductsPage?.CartBadgeIcon.Displayed, Is.True);
            Assert.That(ProductsPage.RemoveButton.Text.Trim(), Is.EqualTo("REMOVE"));
        }

        [Test]
        public void SortProductsHighToLow()
        {
            ProductsPage?.NavigateProducts(EnvironmentVariables.ProductsUrl);
            ProductsPage?.SortDropdown.Click();
        
            IList<IWebElement>? productPricesElements = ProductsPage?.GetProductPrices();
            List<decimal> prices = productPricesElements.Select(p => decimal.Parse(p.Text.Replace("$", "").Replace(",", ""))).ToList();
            
 
            prices.Sort((a, b) => b.CompareTo(a));
            ProductsPage?.HighToLowOption.Click();
            productPricesElements = ProductsPage?.GetProductPrices();
            List<decimal> sortedPrices = productPricesElements.Select(p => decimal.Parse(p.Text.Replace("$", "").Replace(",", ""))).ToList();

            Assert.That(prices, Is.EqualTo(sortedPrices));
    
        }

         [Test]
         public void SortProductsLowToHighByPrices()
       {
            ProductsPage?.NavigateProducts(EnvironmentVariables.ProductsUrl);
            ProductsPage?.SortDropdown.Click();
        
            IList<IWebElement>? productPricesElements = ProductsPage?.GetProductPrices();
            List<decimal> prices = productPricesElements.Select(p => decimal.Parse(p.Text.Replace("$", "").Replace(",", ""))).ToList();
            
 
            prices.Sort((a,b) => a.CompareTo(b));
            ProductsPage?.LowToHighOption.Click();
            productPricesElements = ProductsPage?.GetProductPrices();
            List<decimal> sortedPrices = productPricesElements.Select(p => decimal.Parse(p.Text.Replace("$", "").Replace(",", ""))).ToList();
 
            Assert.That(prices, Is.EqualTo(sortedPrices));

       }
       
     [Test]
         public void SortProductsHighToLowByNames()
       {
            ProductsPage?.NavigateProducts(EnvironmentVariables.ProductsUrl);
            ProductsPage?.SortDropdown.Click();
        
            IList<IWebElement>? productNamesElements = ProductsPage?.GetProductNames();
            List<string> names = productNamesElements.Select(p => p.Text).ToList();
            Console.WriteLine("Nombres antes de ser ordenados alfabéticamente:");
            Console.WriteLine(string.Join(", ", names));
            
 
            names.Sort((a,b) => b.CompareTo(a));
            ProductsPage?.HighToLowName.Click();
            Console.WriteLine("Nombres despues de ordenar");
            Console.WriteLine(string.Join(", ", names));
            
            productNamesElements = ProductsPage?.GetProductNames();
            List<string> sortedNames = productNamesElements.Select(p => p.Text).ToList();
            Console.WriteLine("Nombres ordenados alfabéticamente de Z a A:");
            Console.WriteLine(string.Join(", ", sortedNames));

 
            Assert.That(names, Is.EqualTo(sortedNames));
        
       }

       [Test]
         public void SortProductsHighToLowByNames1()
       {
            ProductsPage?.NavigateProducts(EnvironmentVariables.ProductsUrl);
            ProductsPage?.SortDropdown.Click();
       
            IList<IWebElement>? productNamesElements = ProductsPage?.GetProductNames();
            List<string> names = productNamesElements.Select(p => p.Text).ToList();
            Console.WriteLine("Nombres antes de ser ordenados alfabéticamente:");
            Console.WriteLine(string.Join(", ", names));
 
            names.Sort((a,b) => a.CompareTo(b));
            Console.WriteLine("Nombres despues de ordenar");
            Console.WriteLine(string.Join(", ", names));
           
            ProductsPage?.HighToLowName.Click();
            productNamesElements = ProductsPage?.GetProductNames();
           
            List<string> sortedNames = productNamesElements.Select(p => p.Text).ToList();
            Console.WriteLine("Nombres ordenados alfabéticamente de A a Z:");
            Console.WriteLine(string.Join(", ", sortedNames));
 
 
            Assert.That(sortedNames, Is.EqualTo(names));
       
       }
    
    
    }    
}