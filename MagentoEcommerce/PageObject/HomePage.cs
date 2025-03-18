using OpenQA.Selenium;

namespace MagentoEcommerce.PageObject
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        protected PageElement Product_items => new PageElement(Driver, By.XPath("//li[@class='product-item']"));

        public void SelectedRandomProduct()
        {
            var productElements = Product_items.GetAllElements();
            int randomIndex = new Random().Next(0, productElements.Count);
            productElements[randomIndex].Click();
        }
    }
}
