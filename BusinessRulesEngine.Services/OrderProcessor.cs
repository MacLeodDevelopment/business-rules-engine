using System;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Services
{
    public class OrderProcessor
    {
        private readonly IRuleMatchService _ruleMatchService;
        private readonly IRuleEngine _ruleEngine;

        public OrderProcessor(IRuleMatchService ruleMatchService, IRuleEngine ruleEngine)
        {
            _ruleMatchService = ruleMatchService;
            _ruleEngine = ruleEngine;
        }

        public void ProcessOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var rules = _ruleMatchService.GetMatchingRules(order);
            _ruleEngine.ApplyRules(rules, order);

            //TODO AMACLEOD Probably need a logger to report back to the UI.
        }
    }
}