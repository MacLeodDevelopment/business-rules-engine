using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models.Events;

namespace BusinessRulesEngine.Infrastructure
{
    public class ServiceBusEmulator : IServiceBus
    {
        public IEnumerable<IBusinessEvent> Events()
        {
            return new List<IBusinessEvent> {}; //TODO AMACLEOD 
        }
    }
}