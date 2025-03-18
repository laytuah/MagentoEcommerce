using MagentoEcommerce.Model;
using OpenQA.Selenium;

namespace MagentoEcommerce.PageObject
{
    internal class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver) { }

        protected PageElement ProvinceDropdown => new PageElement(Driver, By.XPath("//div[@name='shippingAddress.region_id']//select"));
        protected PageElement ShippingMethod => new PageElement(Driver, By.XPath("//tr[@class='row' and contains(.,'Fixed')]"));
        protected PageElement AppreciationMessage => new PageElement(Driver, By.XPath("//span[@data-ui-id]"));
        protected PageElement OrderNumber => new PageElement(Driver, By.XPath("//div[@class='checkout-success']/p[contains(.,'#')]"));

        public void EnterDeliveryDetails(CustomerProfile customer)
        {
            Textbox("email address",5).SendKeys(customer.Email);
            Textbox("first name").SendKeys(customer.Firstname);
            Textbox("last name").SendKeys(customer.Firstname);
            Textbox("street address").SendKeys(customer.StreetAddress);
            Textbox("city").SendKeys(customer.City);
            Textbox("postal code").SendKeys(customer.PostalCode);
            Textbox("phone number").SendKeys(customer.PhoneNumber);
            ProvinceDropdown.SelectByText(customer.Province);
            ShippingMethod.Click();
            Button_button("next").Click();
            if (Button_button("place order").IsDisplayed())
                Button_button("place order").Click();
            else
                throw new Exception("Order button is not displayed");
        }

        public (string appreciationMessage, string orderNumber) GetOrderComfirmationMessages()
        {
            if (AppreciationMessage.ElementExists() && OrderNumber.ElementExists())
            {
                return (AppreciationMessage.Text.ToLower(), OrderNumber.Text.ToLower());
            }
            return ("confirmation message not displayed", "order number not available");
        }
    }
}
