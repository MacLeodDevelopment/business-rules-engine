namespace BusinessRulesEngine.Domain.Models
{
    public class Product
    {
        public string ProductType { get; }

        public Product(string productType)
        {
            ProductType = productType;
        }
    }
}