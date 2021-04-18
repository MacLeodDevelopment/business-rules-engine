using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Domain.Rules
{
    public class UpgradeMembership : IRule
    {
        private readonly IServiceBus _serviceBus;

        public UpgradeMembership(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductType.ToLowerInvariant() == "membership"
                   && order.Product.ProductSubType.ToLowerInvariant() == "upgrade";
        }

        public void Apply(Order order)
        {
            var membershipUpgraded = new MembershipUpgraded(order.Id, order.Product.Id);
            _serviceBus.PublishEvent(membershipUpgraded);
        }
    }
}