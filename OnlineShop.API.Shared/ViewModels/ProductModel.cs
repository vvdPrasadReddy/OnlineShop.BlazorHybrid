namespace OnlineShop.API.Shared.ViewModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }

    public enum ProductCategory
    {
        Fashion = 0,
        Electronics = 1,
        HomeApplainces = 2,
        Gadgets = 3
    }
}
