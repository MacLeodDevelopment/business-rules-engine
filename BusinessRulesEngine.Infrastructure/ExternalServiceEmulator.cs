using System;
using System.Diagnostics.CodeAnalysis;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Infrastructure
{
    [ExcludeFromCodeCoverage(Justification = "because this implementation is an emulator for testing purposes.")]
    public class ExternalServiceEmulator
    {
        private readonly ILogger _logger;

        public ExternalServiceEmulator(ILogger logger)
        {
            _logger = logger;
        }

        /// <remarks>
        /// This emulates an external service subscriber reacting to events published on the service bus. 
        /// </remarks>
        public void HandleEvent(IBusinessEvent businessEvent)
        {
            var eventType = businessEvent.GetType().FullName;
            switch (eventType)
            {
                case "BusinessRulesEngine.Domain.Models.Events.PackingSlipCreated":
                case "BusinessRulesEngine.Domain.Models.Events.PackingSlipDuplicated":
                case "BusinessRulesEngine.Domain.Models.Events.MembershipActivated":
                case "BusinessRulesEngine.Domain.Models.Events.MembershipUpgraded":
                case "BusinessRulesEngine.Domain.Models.Events.CommissionPaymentGenerated":
                case "BusinessRulesEngine.Domain.Models.Events.EmailMembershipOwner":
                    LogEvent(businessEvent, MessageType.Success);
                    break;
                case "BusinessRulesEngine.Domain.Models.Events.PackingSlipUpdated":
                    LogEvent(businessEvent, MessageType.Warning);
                    break;
                default:
                    throw new Exception($"Unknown event type [{eventType}]");
            }
        }

        private void LogEvent(IBusinessEvent packingSlipEvent, MessageType messageType)
        {
            _logger.Log(packingSlipEvent.Message, messageType);

            if (packingSlipEvent.Data is PackingSlip packingSlip && packingSlip.Products.Count > 0)
            {
                LogPackingSlipRows(packingSlip);
            }
        }

        private void LogPackingSlipRows(PackingSlip packingSlip)
        {
            _logger.Log("Products on Packing Slip:", MessageType.Information);

            foreach (var product in packingSlip.Products)
            {
                _logger.Log(product, MessageType.Information);
            }
        }
    }
}