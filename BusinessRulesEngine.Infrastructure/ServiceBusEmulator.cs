using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Infrastructure
{
    [ExcludeFromCodeCoverage(Justification = "because this implementation is an emulator for testing purposes.")]
    public class ServiceBusEmulator : IServiceBus
    {
        private readonly List<IBusinessEvent> _events;
        private readonly ExternalServiceEmulator _externalServiceEmulator;

        public ServiceBusEmulator(ILogger logger)
        {
            _events = new List<IBusinessEvent>();
            _externalServiceEmulator = new ExternalServiceEmulator(logger);
        }

        public IEnumerable<IBusinessEvent> Events()
        {
            return _events;
        }

        public void PublishEvent(IBusinessEvent businessEvent)
        {
            _events.Add(businessEvent);

            _externalServiceEmulator.HandleEvent(businessEvent);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}