using FluentAssertions;
using MagentoEcommerce.Data;
using OpenQA.Selenium;


namespace MagentoEcommerce.PageObject
{
    internal class ProductListPage : BasePage
    {
        public ProductListPage(IWebDriver driver) : base(driver) { }

        protected PageElement Product_Size(int index, string productSize) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{index}]//div[contains(@aria-describedby,'option-label-size') and text()='{productSize}']"));
        protected PageElement Product_Colour(int index) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{index}]//div[contains(@aria-describedby,'option-label-color')]"));
        


        public void AddItemToCartFromPLP(int itemQuantity)
        {

            var selectedProduct = Product.SelectedProductInformation();
            for (int i = 1; i <= itemQuantity; i++)
            {
                Product_Size(i, selectedProduct.Size).Click();
                Product_Colour(i).Click();
                if (Button_button("add to cart", i).IsDisplayed())
                    Button_button("add to cart", i).Click();
                int.Parse(numberOfProductsInCart.Text.Trim()).Should().Be(i);
            }

            numberOfProductsInCart.Click();
            Button_button("proceed to checkout").Click();
        }
    }
}

