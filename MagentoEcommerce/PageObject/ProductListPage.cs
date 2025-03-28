using MagentoEcommerce.Data;
using OpenQA.Selenium;


namespace MagentoEcommerce.PageObject
{
    internal class ProductListPage : BasePage
    {
        public ProductListPage(IWebDriver driver) : base(driver) { }

        protected PageElement Product_items => new PageElement(Driver, By.XPath("//li[@class='item product product-item']"));
        protected PageElement Product_Size(int index, string productSize) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{index}]//div[contains(@aria-describedby,'option-label-size') and text()='{productSize}']"));
        protected PageElement Product_Colour(int index) => new PageElement(Driver, By.XPath($"//li[@class='item product product-item'][{index}]//div[contains(@aria-describedby,'option-label-color')]"));

        
        protected PageElement Navigation_Menu(string menuLabel) => new PageElement(Driver, By.XPath($"//nav[@class='navigation']//span[text()='{menuLabel}']"));
        protected PageElement Navigation_SubMenu(string menuLabel, string submenuLabel) => new PageElement(Driver, By.XPath($"//nav[@class='navigation']//li[contains(.,'{menuLabel}')]//span[text()='{submenuLabel}']"));
        

        public void AddItemToCartFromPLP()
        {

            var selectedProduct = Product.SelectedProductInformation();
            var productElements = Product_items.GetAllElements();
            for (int i = 3; 1 <= 5; i++)
            {
                productElements[i].Hover();
                Product_Size(i, selectedProduct.Size).Click();
                Product_Colour(i).Click();
                Button_button("add to cart").Click();
            }
            //numberOfProductsInCart.Click();
            //Button_button("proceed to checkout").Click();
        }
    }
}

