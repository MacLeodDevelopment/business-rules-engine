using System.Collections.Generic;
using BusinessRulesEngine.Domain;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Services
{
    public class RuleMatchService : IRuleMatchService
    {
        private readonly IEnumerable<IRule> _allRules;

        public RuleMatchService(IRuleRepository ruleRepository)
        {
            _allRules = ruleRepository.AllRules();
        }

        public IEnumerable<IRule> GetMatchingRules(Order order)
        {
            var matchingRules = new List<IRule>();

            foreach (var rule in _allRules)
            {
                if (rule.IsMatch(order))
                {
                    matchingRules.Add(rule);
                }
            }

            return matchingRules;
        }
    }
}