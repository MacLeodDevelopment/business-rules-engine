using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Services
{
    public class RuleEngine : IRuleEngine
    {
        public void ApplyRules(IEnumerable<IRule> rules, Order order)
        {
            foreach (var rule in rules)
            {
                rule.Apply(order);
            }
        }
    }
}