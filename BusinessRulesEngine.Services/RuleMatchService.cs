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
            //throw new System.NotImplementedException(); //TODO AMACLEOD
            return new List<IRule>();
        }
    }
}