using System.Collections.Generic;

namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IRuleRepository
    {
        IEnumerable<IRule> AllRules();
    }
}