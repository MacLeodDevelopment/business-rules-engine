using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Domain.Rules
{
    public class GenerateCommissionPayment : IRule
    {
        private readonly IServiceBus _serviceBus;

        public GenerateCommissionPayment(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductType?.ToLowerInvariant() == "physical" 
                   || order?.Product?.ProductSubType?.ToLowerInvariant() == "book";
        }

        public void Apply(Order order)
        {
            _serviceBus.PublishEvent(new CommissionPaymentGenerated(order.Id, order.AgentId));
        }
    }
}