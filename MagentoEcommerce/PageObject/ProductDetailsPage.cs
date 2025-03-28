using MagentoEcommerce.Data;
using OpenQA.Selenium;

namespace MagentoEcommerce.PageObject
{
    internal class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver) : base(driver) {}
        protected PageElement Product_Size(string productSize) => new PageElement(Driver, By.XPath($"//div[contains(@aria-labelledby,'option-label-size')]//div[text()='{productSize}']"));
        protected PageElement Product_Colour(string productColour) => new PageElement(Driver, By.XPath($"//div[contains(@aria-labelledby,'option-label-color')]//div[@aria-label='{productColour}']"));
        protected PageElement Product_Quantity => new PageElement(Driver, By.XPath("//input[@id='qty']"));
        
        

        public void AddItemToCartFromPDP()
        {
            var selectedProduct = Product.SelectedProductInformation();
            if (Product_Size(selectedProduct.Size).IsDisplayed())
                Product_Size(selectedProduct.Size).Click();
            else
                throw new Exception("size chart not displayed");

            if (Product_Colour(selectedProduct.Colour).IsDisplayed())
                Product_Colour(selectedProduct.Colour).Click();
            else
                throw new Exception("colour chart not displayed");

            Button_button("add to cart").Click();

            numberOfProductsInCart.Click();
            Button_button("proceed to checkout").Click();
        }
    }
}
