using MagentoEcommerce.Configuration;
using OpenQA.Selenium;

namespace MagentoEcommerce.PageObject
{
    public class BasePage
    {
        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        protected PageElement Button_button(string buttonText, int index = 1) => new PageElement(Driver, By.XPath($"(//button[normalize-space(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'))='{buttonText}'])[{index}]"));

        protected PageElement Link(string linkText, int index = 1) => new PageElement(Driver, By.XPath($"(//a[@href and contains(normalize-space(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')), '{linkText}')])[{index}]"));

        protected PageElement Textbox(string textboxName, int index = 1) => new PageElement(Driver, By.XPath($"(//label[contains(normalize-space(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')), '{textboxName}')]/following::input)[{index}]"));

        public void LoadAUT()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.Url);
            if (Button_button("agree").ElementExists() && Button_button("agree").IsDisplayed())
                Button_button("agree").Click();
        }
    }
}
