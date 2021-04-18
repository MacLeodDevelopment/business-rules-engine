using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain.Models.Events
{
    public class MembershipActivated : IBusinessEvent
    {
        public string Message { get; }
        public object Data { get; }

        public MembershipActivated(string orderId, string membershipId)
        {
            Message = $"{orderId}: Membership ACTIVATED.";
            Data = membershipId;
        }
    }
}