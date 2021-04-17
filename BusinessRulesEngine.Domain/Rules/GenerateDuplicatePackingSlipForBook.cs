using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Rules
{
    public class GenerateDuplicatePackingSlipForBook : IRule
    {
        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductSubType == "Book";
        }

        public void Apply(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}