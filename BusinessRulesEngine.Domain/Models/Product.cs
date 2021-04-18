namespace BusinessRulesEngine.Domain.Models
{
    public class Product
    {
        public string Id { get; }
        public string Name { get; }
        public string ProductType { get; }
        public string ProductSubType { get; }

        public Product(ProductConfig config)
        {
            Id = config.Id;
            Name = config.Name;
            ProductType = config.Type;
            ProductSubType = config.SubType;
        }
    }
}