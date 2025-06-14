using OpenQA.Selenium;
using System.Diagnostics;

namespace MagentoEcommerce.PageObject
{
    internal class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver) : base(driver) { }
        protected PageElement All_Product_Sizes => new PageElement(Driver, By.XPath("//div[contains(@aria-labelledby,'option-label-size')]//div"));
        protected PageElement All_Product_Colours => new PageElement(Driver, By.XPath("//div[contains(@aria-labelledby,'option-label-color')]//div"));
        protected PageElement Product_Quantity => new PageElement(Driver, By.XPath("//input[@id='qty']"));

        public void AddItemToCartFromPDP()
        {
            SelectFirstAvailableOption(All_Product_Sizes);
            SelectFirstAvailableOption(All_Product_Colours);

            Button_button("add to cart").Click();
            numberOfProductsInCart.Click();
            Button_button("proceed to checkout").Click();
        }

        private void SelectFirstAvailableOption(PageElement allAvailableOptions)
        {
            var stopwatch = Stopwatch.StartNew();
            List<PageElement> options = new List<PageElement>();

            while (stopwatch.Elapsed < TimeSpan.FromSeconds(10))
            {
                options = allAvailableOptions.GetAllElements();
                if (options != null && options.Count > 0)
                    break;
            }

            if (options == null || options.Count == 0)
                throw new Exception("No selectable options found after waiting.");

            foreach (var option in allAvailableOptions.GetAllElements())
            {
                if (option.IsDisplayed() && option.Enabled)
                {
                    option.Click();
                    if ((option.GetAttribute("aria-checked") ?? "").ToLower() == "true")
                        return;

                    Console.WriteLine($"[WARN] Option '{option.Text}' clicked but not selected.");
                }
            }

            throw new Exception("Failed to select any available option.");
        }
    }
}
