using FluentAssertions;
using MagentoEcommerce.Model;
using MagentoEcommerce.PageObject;
using Reqnroll;

namespace MagentoEcommerce.StepDefinition
{
    [Binding]
    public class Magento_RegisterStepDefinitions
    {
        readonly BasePage _basePage;
        readonly HomePage _homePage;
        readonly ProductDetailsPage _productDetailsPage;
        readonly CheckoutPage _checkoutPage;
        readonly RegisterPage _registerPage;
        readonly ScenarioContext _scenarioContext;
        readonly ProductListPage _productListPage;

        public Magento_RegisterStepDefinitions(ScenarioContext scenarioContext)
        {
            _basePage = scenarioContext.ScenarioContainer.Resolve<BasePage>();
            _homePage = scenarioContext.ScenarioContainer.Resolve<HomePage>();
            _productDetailsPage = scenarioContext.ScenarioContainer.Resolve<ProductDetailsPage>();
            _checkoutPage = scenarioContext.ScenarioContainer.Resolve<CheckoutPage>();
            _registerPage = scenarioContext.ScenarioContainer.Resolve<RegisterPage>();
            _productListPage = scenarioContext.ScenarioContainer.Resolve<ProductListPage>();
            _scenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }

        [StepDefinition("that user is on the homage")]
        public void GivenThatUserIsOnTheHomage()
        {
            _basePage.LoadAUT();
            _scenarioContext.Set(new CustomerProfile(), "customer");
        }

        [StepDefinition("the user registers a new account")]
        public void WhenTheUserRegistersANewAccount()
        {
            var customer = _scenarioContext.Get<CustomerProfile>("customer");
            _registerPage.RegisterNewUser(customer);
        }

        [StepDefinition("user must be successfully logged into their account")]
        public void ThenUserMustBeSuccessfullyLoggedIntoTheirAccount()
        {
            var customer = _scenarioContext.Get<CustomerProfile>("customer");
            _registerPage.GetSuccessfulRegistrationMessage().confirmation_label.Should().Contain("my account");
            _registerPage.GetSuccessfulRegistrationMessage().information_label.Should().Contain(customer.Firstname.ToLower());
            _registerPage.GetSuccessfulRegistrationMessage().information_label.Should().Contain(customer.Lastname.ToLower());
        }

        [StepDefinition("the user completes purchase of a random item")]
        public void WhenTheUserCompletesPurchaseOfARandomItem()
        {
            var customer = _scenarioContext.Get<CustomerProfile>("customer");
            _homePage.SelectRandomProductOnHomepage();
            _productDetailsPage.AddItemToCartFromPDP();
            _checkoutPage.EnterDeliveryDetails(customer);
        }

        [StepDefinition("the user should get order complete messages")]
        public void ThenTheUserShouldGetOrderCompleteMessages()
        {
            _checkoutPage.GetOrderComfirmationMessages().appreciationMessage.Should().Contain("thank you for your purchase");
            _checkoutPage.GetOrderComfirmationMessages().orderNumber.Should().Contain("your order # is");
        }

        [StepDefinition("the user navigates to {string} {string} page")]
        public void WhenTheUserNavigatesToPage(string mainMenu, string subMenu)
        {
            _homePage.NavigateToPage(mainMenu, subMenu);
        }

        [StepDefinition("complete purchase of {int} items")]
        public void WhenCompletePurchaseOfItems(int itemQuantity)
        {
            _productListPage.AddItemToCartFromPLP(itemQuantity);
        }

    }
}