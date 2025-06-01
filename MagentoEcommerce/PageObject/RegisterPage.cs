using MagentoEcommerce.Model;
using OpenQA.Selenium;

namespace MagentoEcommerce.PageObject
{
    internal class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

        protected PageElement RegisterationConfirmation_label => new PageElement(Driver, By.XPath("//h1[@class='page-title']"));

        protected PageElement RegisterationConfirmationInformation_label => new PageElement(Driver, By.XPath("//div[@class='box box-information']//p"));

        public void RegisterNewUser(CustomerProfile customer)
        {
            Link("create an account").Click();
            Textbox("first name").SendKeys(customer.Firstname);
            Textbox("last name").SendKeys(customer.Lastname);
            Textbox("email").SendKeys(customer.Email);
            Textbox("password").SendKeys(customer.Password);
            Textbox("confirm password").SendKeys(customer.Password);
            Button_button("create an account").Click();
        }

        public (string confirmation_label, string information_label) GetSuccessfulRegistrationMessage() => (RegisterationConfirmation_label.Text.ToLower(), RegisterationConfirmationInformation_label.Text.ToLower());
    }
}
