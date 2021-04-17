using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain.Models.Events
{
    public class PackingSlipCreated : IBusinessEvent
    {
        public string Message { get; }

        public PackingSlipCreated()
        {
            Message = "Packing Slip Created";
        }
    }
}