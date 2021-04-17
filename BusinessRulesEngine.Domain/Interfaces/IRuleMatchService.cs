using System.Collections.Generic;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IRuleMatchService
    {
        IEnumerable<IRule> GetMatchingRules(Order order);
    }

    public class RuleMatchService : IRuleMatchService
    {
        public IEnumerable<IRule> GetMatchingRules(Order order)
        {
            throw new System.NotImplementedException(); //TODO AMACLEOD
        }
    }
}