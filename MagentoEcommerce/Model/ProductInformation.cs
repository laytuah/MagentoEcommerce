namespace MagentoEcommerce.Model
{
    internal class ProductInformation
    {
        public string Size { get; set; }
        public string Colour { get; set; }
        public int Quantity { get; set; }
        

        public ProductInformation(string size, string colour, int quantity)
        {
            Size = size;
            Quantity = quantity;
            Colour = colour;
        }
    }

}
