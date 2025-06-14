using OpenQA.Selenium;

namespace MagentoEcommerce.PageObject
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        protected PageElement SelectedProduct(int itemIndex = 2) => new PageElement(Driver, By.XPath($"//li[@class='product-item'][{itemIndex}]//a[@class='product-item-link']"));
        protected PageElement Navigation_Menu(string menuLabel) => new PageElement(Driver, By.XPath($"//nav[@class='navigation']//span[text()='{menuLabel}']"));
        protected PageElement Navigation_SubMenu(string menuLabel, string submenuLabel) => new PageElement(Driver, By.XPath($"//nav[@class='navigation']//li[contains(.,'{menuLabel}')]//span[text()='{submenuLabel}']"));

        public void SelectRandomProductOnHomepage()
        {
            SelectedProduct().ScrollIntoView();
            SelectedProduct().Click();
        }

        public void NavigateToPage(string mainMenu, string subMenu)
        {
            Navigation_Menu(mainMenu).Hover();
            Navigation_SubMenu(mainMenu, subMenu).Click();
        }
    }
}
