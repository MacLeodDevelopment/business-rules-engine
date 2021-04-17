using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Rules
{
    public class GeneratePackingSlipForPhysicalProduct : IRule
    {
        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductType == "Physical";
        }

        public void Apply(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}