using System;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Domain.Rules
{
    public class AddFreeFirstAidVideoToPackingSlip : IRule
    {
        private readonly IServiceBus _serviceBus;

        public AddFreeFirstAidVideoToPackingSlip(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public bool IsMatch(Order order)
        {
            if (order.Timestamp.Year <= 1997) 
            {
                return false;
            }

            return order?.Product?.ProductSubType.ToLowerInvariant() == "video" 
                   && order.Product.Name.ToLowerInvariant() == "learning to ski";
        }

        public void Apply(Order order)
        {
            order.PackingSlip.AddProduct("First Aid (Video)");
            _serviceBus.PublishEvent(new PackingSlipUpdated(order.PackingSlip, order.Id));
        }
    }
}