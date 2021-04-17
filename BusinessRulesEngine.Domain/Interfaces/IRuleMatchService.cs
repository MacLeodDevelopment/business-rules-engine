using System.Collections.Generic;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IRuleMatchService
    {
        IEnumerable<IRule> GetMatchingRules(Order order);
    }
}