using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.UnitTests.Events
{
    public class PackingSlipDuplicated : IBusinessEvent
    {
        public string Message { get; }
        public object Data { get; }

        public PackingSlipDuplicated(PackingSlip packingSlip, string orderId)
        {
            Message = $"{orderId}: Packing slip DUPLICATED for {packingSlip.Department}.";
            Data = packingSlip;
        }
    }
}