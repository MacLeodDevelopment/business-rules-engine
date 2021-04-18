using System.Collections.Generic;

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

        public PackingSlip() { }

        public void AddProduct(string productName)
        {
            Products.Add(productName);
        }
    }
}