using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.UI.InputModels
{
    public static class OrderBuilder
    {
        public static Order BuildOrderFromInput(InputOrder inputOrder)
        {
            UiEmulator.WriteInputOrder(inputOrder);

            var order = new Order(new OrderConfig
            {
                Id = inputOrder.Id,
                AgentId = inputOrder.AgentId
            });

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