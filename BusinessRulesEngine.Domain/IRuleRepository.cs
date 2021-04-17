using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Domain
{
    public interface IRuleRepository
    {
        IEnumerable<IRule> AllRules();
    }

    public class RuleRepository : IRuleRepository
    {
        public IEnumerable<IRule> AllRules()
        {
            throw new System.NotImplementedException(); //TODO AMACLEOD
        }
    }
}