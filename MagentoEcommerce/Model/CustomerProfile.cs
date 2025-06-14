using MagentoEcommerce.Utilities;

namespace MagentoEcommerce.Model
{
    internal class CustomerProfile
    {
        public string Firstname { get; set; } = DataGenerator.GenerateRandomString();
        public string Lastname { get; set; } = DataGenerator.GenerateRandomString();
        public string Email { get; set; } = DataGenerator.GenerateRandomString(16) + "@yahoo.com";
        public string StreetAddress { get; set; } = DataGenerator.GenerateRandomString();
        public string City { get; set; } = DataGenerator.GenerateRandomString();
        public string Province { get; set; } = "Alaska";
        public string PostalCode { get; set; } = DataGenerator.GenerateRandomIntegerString(5) + "-" + DataGenerator.GenerateRandomIntegerString(4);
        public string PhoneNumber { get; set; } = "+1" + DataGenerator.GenerateRandomIntegerString();
        public string Password { get; set; } = DataGenerator.GenerateValidPassword(20);
    }
}