using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IRule
    {
        bool IsMatch(Order order);
        void Apply(Order order);
    }
}