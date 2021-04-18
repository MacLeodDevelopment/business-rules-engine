using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Rules;

namespace BusinessRulesEngine.Infrastructure
{
    [ExcludeFromCodeCoverage(Justification = "because this implementation is an emulator for testing purposes.")]
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
                new UpgradeMembership(_serviceBus),
                new MembershipEmail(_serviceBus),
                new AddFreeFirstAidVideoToPackingSlip(_serviceBus)
            };
        }
    }
}