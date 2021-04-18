using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain.Models.Events
{
    public class PackingSlipUpdated : IBusinessEvent
    {
        public string Message { get; }
        public object Data { get; }

        public PackingSlipUpdated(PackingSlip packingSlip, string orderId)
        {
            Message = $"{orderId}: Packing slip UPDATED.";
            Data = packingSlip;
        }
    }
}