using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain.Models.Events
{
    public class EmailMembershipOwner : IBusinessEvent
    {
        public string Message { get; }
        public object Data { get; }

        /// <remarks>
        /// Multiple string arguments is a code-smell - but time is a factor.
        /// With more time I would create a config object.
        /// </remarks>
        public EmailMembershipOwner(string orderId, string membershipId, string topic)
        {
            Message = $"{orderId}: Membership Owner EMAILED about {topic.ToUpperInvariant()}.";
            Data = membershipId;
        }
    }
}