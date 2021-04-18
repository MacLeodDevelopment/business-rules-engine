using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain.Models.Events
{
    public class MembershipUpgraded : IBusinessEvent
    {
        public string Message { get; }
        public object Data { get; }

        public MembershipUpgraded(string orderId, string membershipId)
        {
            Message = $"{orderId}: Membership UPGRADED.";
            Data = membershipId;
        }
    }
}