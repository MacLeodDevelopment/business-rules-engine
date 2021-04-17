using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain.Models.Events
{
    public class PackingSlipCreated : IBusinessEvent
    {
        public string Message { get; }
        public object Data { get; }

        public PackingSlipCreated(PackingSlip packingSlip, string orderId)
        {
            Message = $"{orderId}: Packing slip CREATED for {packingSlip.Department}.";
            Data = packingSlip;
        }
    }
}