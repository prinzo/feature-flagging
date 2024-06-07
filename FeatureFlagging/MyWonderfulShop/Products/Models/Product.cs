namespace MyWonderfulShop.API.Products.Models
{
    public class Product
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsLocallyProduced { get; set; }
    }
}
