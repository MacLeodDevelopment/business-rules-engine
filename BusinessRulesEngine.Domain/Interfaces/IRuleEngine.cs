using System.Collections.Generic;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IRuleEngine
    {
        void ApplyRules(IEnumerable<IRule> rules, Order validOrder);
    }
}