using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BusinessRulesEngine.Domain.Models
{
    public class PackingSlip
    {
        public string Department { get; }
        public List<string> Products { get; }

        public PackingSlip(string department)
        {
            Department = department;
            Products = new List<string>();
        }

        [ExcludeFromCodeCoverage(Justification = "Empty constructor only exists for mocking purposes.")]
        public PackingSlip() { }

        public void AddProduct(string productName)
        {
            Products.Add(productName);
        }
    }
}