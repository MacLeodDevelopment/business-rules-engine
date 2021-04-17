using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Infrastructure
{
    public class ServiceBusEmulator : IServiceBus
    {
        private readonly List<IBusinessEvent> _events;

        public ServiceBusEmulator()
        {
            _events = new List<IBusinessEvent>();
        }

        public IEnumerable<IBusinessEvent> Events()
        {
            return _events;
        }

        public void PublishEvent(IBusinessEvent businessEvent)
        {
            _events.Add(businessEvent);
        }
    }
}