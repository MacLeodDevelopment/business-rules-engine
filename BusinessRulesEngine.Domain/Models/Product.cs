namespace BusinessRulesEngine.Domain.Models
{
    public class Product
    {
        public string Name { get; }
        public string ProductType { get; }
        public string ProductSubType { get; }

        public Product(ProductConfig config)
        {
            Name = config.Name;
            ProductType = config.Type;
            ProductSubType = config.SubType;
        }
    }
}