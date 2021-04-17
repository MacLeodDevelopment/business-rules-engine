using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Infrastructure
{
    public class ServiceBusEmulator : IServiceBus
    {
        public IEnumerable<IBusinessEvent> Events()
        {
            return new List<IBusinessEvent> {}; //TODO AMACLEOD 
        }

        public void PublishEvent(IBusinessEvent businessEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}