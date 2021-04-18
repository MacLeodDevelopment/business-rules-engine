using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain.Models.Events
{
    public class CommissionPaymentGenerated  : IBusinessEvent
    {
        public string Message { get; }
        public object Data { get; }

        public CommissionPaymentGenerated(string orderId, string agentId)
        {
            Message = $"{orderId}: Commission PAYMENT GENERATED.";
            Data = agentId;
        }
    }
}