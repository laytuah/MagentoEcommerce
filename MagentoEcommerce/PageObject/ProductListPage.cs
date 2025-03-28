using MagentoEcommerce.Data;
using OpenQA.Selenium;


namespace MagentoEcommerce.PageObject
{
    internal class ProductListPage : BasePage
    {
        public ProductListPage(IWebDriver driver) : base(driver) { }

        protected PageElement Product_Size(int index, string productSize) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{index}]//div[contains(@aria-describedby,'option-label-size') and text()='{productSize}']"));
        protected PageElement Product_Colour(int index) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{index}]//div[contains(@aria-describedby,'option-label-color')]"));
        


        public void AddItemToCartFromPLP()
        {

            var selectedProduct = Product.SelectedProductInformation();
            for (int i = 1; i <= 2; i++)
            {
                if (Product_Size(i, selectedProduct.Size).ElementExists() && Product_Size(i, selectedProduct.Size).IsDisplayed())
                    Product_Size(i, selectedProduct.Size).Click();
                if (Product_Colour(i).ElementExists() && Product_Colour(i).IsDisplayed())
                    Product_Colour(i).Click();
                if (Button_button("add to cart", i).IsDisplayed())
                    Button_button("add to cart", i).Click();
            }

            numberOfProductsInCart.Click();
            Button_button("proceed to checkout").Click();
        }
    }
}

