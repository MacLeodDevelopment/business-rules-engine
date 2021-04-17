using System.Collections.Generic;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IServiceBus
    {
        IEnumerable<IBusinessEvent> Events();
        void PublishEvent(IBusinessEvent businessEvent);
        void ClearEvents();
    }
}