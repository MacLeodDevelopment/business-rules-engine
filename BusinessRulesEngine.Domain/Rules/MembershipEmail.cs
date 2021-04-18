using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Domain.Rules
{
    public class MembershipEmail : IRule
    {
        private readonly IServiceBus _serviceBus;

        public MembershipEmail(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public bool IsMatch(Order order)
        {
            if (order?.Product?.ProductType.ToLower() != "membership")
            {
                return false;
            }

            return order.Product.ProductSubType.ToLowerInvariant() == "activate" || order.Product.ProductSubType.ToLowerInvariant() == "upgrade";
        }

        public void Apply(Order order)
        {
            var emailMembershipOwner = new EmailMembershipOwner(order.Id, order.Product.Id, order.Product.ProductSubType);
            _serviceBus.PublishEvent(emailMembershipOwner);
        }
    }
}