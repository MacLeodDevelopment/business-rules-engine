using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Order order);
    }
}