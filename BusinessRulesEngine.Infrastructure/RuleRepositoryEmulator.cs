using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Rules;

namespace BusinessRulesEngine.Infrastructure
{
    public class RuleRepositoryEmulator : IRuleRepository
    {
        private readonly IServiceBus _serviceBus;

        public RuleRepositoryEmulator(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        /// <remarks>
        /// This could load rules from anywhere - use reflection to get classes that implement IRule for example.
        /// For expediency I've hard-coded this for now. 
        /// </remarks>
        public IEnumerable<IRule> AllRules()
        {
            return new List<IRule>
            {
                new GeneratePackingSlipForPhysicalProduct(_serviceBus),
                new GenerateDuplicatePackingSlipForBook(_serviceBus),
                new ActivateMembership(_serviceBus),
                new UpgradeMembership(_serviceBus)
            };
        }
    }
}