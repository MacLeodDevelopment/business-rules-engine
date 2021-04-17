using System.Collections.Generic;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IRuleEngine
    {
        void ApplyRules(IEnumerable<IRule> rules, Order validOrder);
    }

    public class RuleEngine : IRuleEngine
    {
        public void ApplyRules(IEnumerable<IRule> rules, Order validOrder)
        {
            //throw new System.NotImplementedException(); //TODO AMACLEOD
        }
    }
}