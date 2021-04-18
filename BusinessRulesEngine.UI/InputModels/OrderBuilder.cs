using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.UI.InputModels
{
    public static class OrderBuilder
    {
        public static Order BuildOrderFromInput(InputOrder inputOrder)
        {
            var order = new Order(inputOrder.Id);

            var productConfig = new ProductConfig
            {
                Id = inputOrder.ProductId,
                Name = inputOrder.ProductName,
                Type = inputOrder.ProductType,
                SubType = inputOrder.ProductSubType
            };

            var product = new Product(productConfig);
            order.SetProduct(product);

            return order;
        }
    }
}