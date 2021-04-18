using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Domain.Rules
{
    public class ActivateMembership : IRule
    {
        private readonly IServiceBus _serviceBus;

        public ActivateMembership(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductType.ToLowerInvariant() == "membership" 
                   && order.Product.ProductSubType.ToLowerInvariant() == "activate";
        }

        public void Apply(Order order)
        {
            var membershipActivated = new MembershipActivated(order.Id, order.Product.Id);
            _serviceBus.PublishEvent(membershipActivated);
        }
    }
}