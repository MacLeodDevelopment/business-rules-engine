using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface ILogger
    {
        void Log(string message, MessageType messageType);
    }
}