using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Infrastructure
{
    public class ServiceBusEmulator : IServiceBus
    {
        private readonly ILogger _logger;
        private readonly List<IBusinessEvent> _events;

        public ServiceBusEmulator(ILogger logger)
        {
            _logger = logger;
            _events = new List<IBusinessEvent>();
        }

        public IEnumerable<IBusinessEvent> Events()
        {
            return _events;
        }

        public void PublishEvent(IBusinessEvent businessEvent)
        {
            _logger.Log(businessEvent.Message);
            _events.Add(businessEvent);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}