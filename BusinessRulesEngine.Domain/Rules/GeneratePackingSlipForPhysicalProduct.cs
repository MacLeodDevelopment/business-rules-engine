using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Domain.Rules
{
    public class GeneratePackingSlipForPhysicalProduct : IRule
    {
        private readonly IServiceBus _serviceBus;

        public GeneratePackingSlipForPhysicalProduct(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductType.ToLowerInvariant() == "physical";
        }

        public void Apply(Order order)
        {
            var packingSlip = new PackingSlip("Shipping");
            packingSlip.AddProduct($"{order.Product.Name} ({order.Product.ProductSubType})");
            
            order.SetPackingSlip(packingSlip);

            _serviceBus.PublishEvent(new PackingSlipCreated(packingSlip, order.Id));
        }
    }
}