using FluentAssertions;
using OpenQA.Selenium;


namespace MagentoEcommerce.PageObject
{
    internal class ProductListPage : BasePage
    {
        public ProductListPage(IWebDriver driver) : base(driver) { }

        protected PageElement Product_Size(int productIndex, int sizeIndex = 1) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{productIndex}]//div[contains(@aria-describedby,'option-label-size')][{sizeIndex}]"));
        protected PageElement Product_Colour(int productIndex) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{productIndex}]//div[contains(@aria-describedby,'option-label-color')]"));



        public void AddItemToCartFromPLP(int itemQuantity)
        {
            for (int i = 1; i <= itemQuantity; i++)
            {
                Product_Size(i).Click();
                if ((Product_Size(i).GetAttribute("aria-checked") ?? "").ToLower() != "true")
                    throw new Exception($"Size option at index {i} was clicked but not selected");

                Product_Colour(i).Click();
                if ((Product_Colour(i).GetAttribute("aria-checked") ?? "").ToLower() != "true")
                    throw new Exception($"Colour option at index {i} was clicked but not selected");

                if (Button_button("add to cart", i).IsDisplayed())
                    Button_button("add to cart", i).Click();
            }

            numberOfProductsInCart.Click();
            Button_button("proceed to checkout").Click();
        }

    }
}

