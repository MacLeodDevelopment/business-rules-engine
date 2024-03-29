﻿using System;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Services
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IRuleMatchService _ruleMatchService;
        private readonly IRuleEngine _ruleEngine;
        private readonly ILogger _logger;

        public OrderProcessor(IRuleMatchService ruleMatchService, IRuleEngine ruleEngine, ILogger logger)
        {
            _ruleMatchService = ruleMatchService;
            _ruleEngine = ruleEngine;
            _logger = logger;
        }

        public void ProcessOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            try
            {
                var rules = _ruleMatchService.GetMatchingRules(order);
                _ruleEngine.ApplyRules(rules, order);
            }
            catch (Exception e)
            {
                _logger.Log($"{order.Id} failed with error: {e.Message}", MessageType.Error);
            }
        }
    }
}