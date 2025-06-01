using MagentoEcommerce.Model;

namespace MagentoEcommerce.Data
{
    internal class Product
    {
        public static ProductInformation SelectedProductInformation()
        {
            return new ProductInformation ("XL", "Blue", 1);
        }
    }
}
