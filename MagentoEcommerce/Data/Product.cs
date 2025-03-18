using MagentoEcommerce.Model;

namespace MagentoEcommerce.Data
{
    internal class Product
    {
        public static ProductInformation SelectedProductInformation()
        {
            return new ProductInformation {Size = "XL", Colour = "Blue", Quantity = "1"};
        }
    }
}
