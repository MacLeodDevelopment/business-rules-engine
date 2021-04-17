using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Domain.Rules
{
    public class GenerateDuplicatePackingSlipForBook : IRule
    {
        private readonly IServiceBus _serviceBus;

        public GenerateDuplicatePackingSlipForBook(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductSubType.ToLowerInvariant() == "book";
        }

        public void Apply(Order order)
        {
            var packingSlip = new PackingSlip("Royalty Department");
            packingSlip.AddProduct($"{order.Product.Name} ({order.Product.ProductSubType})");

            _serviceBus.PublishEvent(new PackingSlipDuplicated(packingSlip, order.Id));
        }
    }
}